// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: January 21, 2013
// Time :  10:00 AM
// Description: Class for Gift Voucher Entry
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

using System.Collections;
using System.Data;
using System.Data.OleDb;


namespace CJ.Class
{
    public class GiftVoucher
    {
        private int _nProductID;
        private int _nSerialNo;
        private double _UnitPrice;
        private double _DiscountAmount;
        private int _nWarehouseID;
        private int _nValidMonth;
        private string _sCustomerName;
        private string _sCustomerAddress;
        private string _sContactNo;
        private string _sEmail;
        private string _sInvoiceNo;
        private DateTime _dSaleDate;
        private DateTime _dExpireDate;
        private string _sDiscountRemarks;
        private int _nDiscountEnteredBy;
        private DateTime _dDiscountEntryDate;
        private int _nStatus;
        private string _sIsRedeem;
        private string _sRedeemOutlet;
        private string _sSoldOutlet;
        private DateTime _dRedeemDate;


        //Gift Voucher History
        private int _GiftVoucherHistoryID;
        private int _SerialNo;
        private int _FromWHID;
        private int _ToWHID;
        private int _Status;
        private DateTime _StatusDate;
        private int _UserID;
        private string _sRemarks;


        /// <summary>
        /// Get set property for ProductID
        /// </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        /// <summary>
        /// Get set property for SerialNo
        /// </summary>
        public int SerialNo
        {
            get { return _nSerialNo; }
            set { _nSerialNo = value; }
        }
        /// <summary>
        /// Get set property for UnitPrice
        /// </summary>
        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }
        /// <summary>
        /// Get set property for DiscountAmount
        /// </summary>
        public double DiscountAmount
        {
            get { return _DiscountAmount; }
            set { _DiscountAmount = value; }
        }
        /// <summary>
        /// Get set property for WarehouseID
        /// </summary>
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }
        /// <summary>
        /// Get set property for ValidMonth
        /// </summary>
        public int ValidMonth
        {
            get { return _nValidMonth; }
            set { _nValidMonth = value; }
        }
        /// <summary>
        /// Get set property for CustomerName
        /// </summary>
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
        /// <summary>
        /// Get set property for CustomerAddress
        /// </summary>
        public string CustomerAddress
        {
            get { return _sCustomerAddress; }
            set { _sCustomerAddress = value; }
        }
        /// <summary>
        /// Get set property for ContactNo
        /// </summary>
        public string ContactNo
        {
            get { return _sContactNo; }
            set { _sContactNo = value; }
        }
        /// <summary>
        /// Get set property for Email
        /// </summary>
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value; }
        }
        /// <summary>
        /// Get set property for InvoiceNo
        /// </summary>
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }
        /// <summary>
        /// Get set property for SaleDate
        /// </summary>
        public DateTime SaleDate
        {
            get { return _dSaleDate; }
            set { _dSaleDate = value; }
        }
        /// <summary>
        /// Get set property for ExpireDate
        /// </summary>
        public DateTime ExpireDate
        {
            get { return _dExpireDate; }
            set { _dExpireDate = value; }
        }
        /// <summary>
        /// Get set property for TransferRemarks
        /// </summary>
        public string DiscountRemarks
        {
            get { return _sDiscountRemarks; }
            set { _sDiscountRemarks = value; }
        }
        /// <summary>
        /// Get set property for DiscountEnteredBy
        /// </summary>
        public int DiscountEnteredBy
        {
            get { return _nDiscountEnteredBy; }
            set { _nDiscountEnteredBy = value; }
        }
        /// <summary>
        /// Get set property for DiscountEntryDate
        /// </summary>
        public DateTime DiscountEntryDate
        {
            get { return _dDiscountEntryDate; }
            set { _dDiscountEntryDate = value; }
        }
        /// <summary>
        /// Get set property for Status
        /// </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        /// <summary>
        /// Get set property for IsRedeem
        /// </summary>
        public string IsRedeem
        {
            get { return _sIsRedeem; }
            set { _sIsRedeem = value; }
        }
        /// <summary>
        /// Get set property for RedeemOutlet
        /// </summary>
        public string RedeemOutlet
        {
            get { return _sRedeemOutlet; }
            set { _sRedeemOutlet = value; }
        }
        /// <summary>
        /// Get set property for RedeemDate
        /// </summary>
        public DateTime RedeemDate
        {
            get { return _dRedeemDate; }
            set { _dRedeemDate = value; }
        }
        /// <summary>
        /// Get set property for SoldOutlet
        /// </summary>
        public string SoldOutlet
        {
            get { return _sSoldOutlet; }
            set { _sSoldOutlet = value; }
        }


        /// <summary>
        /// Get set property for GiftVoucherHistoryID
        /// </summary>
        public int GiftVoucherHistoryID
        {
            get { return _GiftVoucherHistoryID; }
            set { _GiftVoucherHistoryID = value; }
        }
        /// <summary>
        /// Get set property for SerialNo
        /// </summary>
        public int HSerialNo
        {
            get { return _SerialNo; }
            set { _SerialNo = value; }
        }
        /// <summary>
        /// Get set property for FromWHID
        /// </summary>
        public int HFromWHID
        {
            get { return _FromWHID; }
            set { _FromWHID = value; }
        }
        /// <summary>
        /// Get set property for ToWHID
        /// </summary>
        public int ToWHID
        {
            get { return _ToWHID; }
            set { _ToWHID = value; }
        }
        /// <summary>
        /// Get set property for Status
        /// </summary>
        public int HStatus
        {
            get { return _Status; }
            set { _Status = value; }
        }
        /// <summary>
        /// Get set property for StatusDate
        /// </summary>
        public DateTime StatusDate
        {
            get { return _StatusDate; }
            set { _StatusDate = value; }
        }
        /// <summary>
        /// Get set property for UserID
        /// </summary>
        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }

        private int nFromSerialNo;
        public int FromSerialNo
        {
            get { return nFromSerialNo; }
            set { nFromSerialNo = value; }
        }

        private int nQty;
        public int Qty
        {
            get { return nQty; }
            set { nQty = value; }
        }

        private string sProductName;
        public string ProductName
        {
            get { return sProductName; }
            set { sProductName = value; }
        }

        private string sWarehouseName;
        public string WarehouseName
        {
            get { return sWarehouseName; }
            set { sWarehouseName = value; }
        }


        public void Add()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nMaxHistoryID = 0;
            try
            {

                for (long i = 0; i < nQty; i++)
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    sSql = "INSERT INTO t_GiftVoucher (ProductID,SerialNo,UnitPrice,WarehouseID,ValidMonth, " +
                            "CustomerName,ContactNo,InvoiceNo,Status) VALUES(?,?,?,?,?,?,?,?,?)";

                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("ProductID", _nProductID);
                    cmd.Parameters.AddWithValue("SerialNo", _nSerialNo + i);
                    cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                    cmd.Parameters.AddWithValue("WarehouseID", Convert.ToInt32(ConfigurationManager.AppSettings["CentralRetailWarehouse"].ToString()));
                    cmd.Parameters.AddWithValue("ValidMonth", _nValidMonth);
                    cmd.Parameters.AddWithValue("CustomerName", "");
                    cmd.Parameters.AddWithValue("ContactNo", "");
                    cmd.Parameters.AddWithValue("InvoiceNo", "");
                    cmd.Parameters.AddWithValue("Status", (int)Dictionary.GiftVoucherStatus.Create);

                    cmd.ExecuteNonQuery();


                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    sSql = "SELECT MAX([GiftVoucherHistoryID]) FROM t_GiftVoucherHistory";
                    cmd.CommandText = sSql;
                    object maxID = cmd.ExecuteScalar();
                    if (maxID == DBNull.Value)
                    {
                        nMaxHistoryID = 1;
                    }
                    else
                    {
                        nMaxHistoryID = Convert.ToInt32(maxID) + 1;
                    }
                    _GiftVoucherHistoryID = nMaxHistoryID;
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    sSql = "INSERT INTO t_GiftVoucherHistory (GiftVoucherHistoryID,SerialNo,FromWHID,ToWHID,Status,StatusDate,UserID) VALUES(?,?,?,?,?,?,?)";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("GiftVoucherHistoryID", _GiftVoucherHistoryID);
                    cmd.Parameters.AddWithValue("HSerialNo", _nSerialNo + i);
                    cmd.Parameters.AddWithValue("HFromWHID", (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE);
                    cmd.Parameters.AddWithValue("ToWHID", Convert.ToInt32(ConfigurationManager.AppSettings["CentralRetailWarehouse"].ToString()));
                    cmd.Parameters.AddWithValue("HStatus", (int)Dictionary.GiftVoucherStatus.Create);
                    cmd.Parameters.AddWithValue("StatusDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("UserID", Utility.UserId);

                    cmd.ExecuteNonQuery();
                    //cmd.Dispose();
                }
                //DBController.Instance.OpenNewConnection();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddHistory()
        {
            int nMaxHistoryID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT MAX([GiftVoucherHistoryID]) FROM t_GiftVoucherHistory";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxHistoryID = 1;
                }
                else
                {
                    nMaxHistoryID = Convert.ToInt32(maxID) + 1;
                }
                _GiftVoucherHistoryID = nMaxHistoryID;

                sSql = "INSERT INTO t_GiftVoucherHistory VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("GiftVoucherHistoryID", _GiftVoucherHistoryID);
                cmd.Parameters.AddWithValue("HSerialNo", _nSerialNo);
                cmd.Parameters.AddWithValue("HFromWHID", _FromWHID);
                cmd.Parameters.AddWithValue("ToWHID", _ToWHID);
                cmd.Parameters.AddWithValue("HStatus",_Status);
                cmd.Parameters.AddWithValue("StatusDate", DateTime.Now);
                cmd.Parameters.AddWithValue("UserID", Utility.UserId);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.ExecuteNonQuery();

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Transfer()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "UPDATE t_GiftVoucher SET WarehouseID=?,Status=? WHERE SerialNo=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("SerialNo", _nSerialNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Discount()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "UPDATE t_GiftVoucher SET DiscountAmount=?,DiscountRemarks=?,DiscountEnteredBy=?,DiscountEntryDate=? WHERE SerialNo=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DiscountAmount", _DiscountAmount);
                cmd.Parameters.AddWithValue("DiscountRemarks", _sDiscountRemarks);
                cmd.Parameters.AddWithValue("DiscountEnteredBy", Utility.UserId);
                cmd.Parameters.AddWithValue("DiscountEntryDate", DateTime.Now);

                cmd.Parameters.AddWithValue("SerialNo", _nSerialNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddSale()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "UPDATE t_GiftVoucher SET CustomerName=?,CustomerAddress=?,ContactNo=?,Email=?,SaleDate=?,ExpireDate=?,Status=? WHERE SerialNo=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                cmd.Parameters.AddWithValue("CustomerAddress", _sCustomerAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("SaleDate", DateTime.Now);
                cmd.Parameters.AddWithValue("ExpireDate", _dExpireDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("SerialNo", _nSerialNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Redeem()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "UPDATE t_GiftVoucher SET WarehouseID=?,InvoiceNo=?, Status=? WHERE SerialNo=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("SerialNo", _nSerialNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshBySerialNo(int nSerialNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "SELECT SerialNo,ValidMonth,WarehouseID,IsNull(ExpireDate,GetDate()) as ExpireDate,Status FROM t_GiftVoucher where SerialNo=?";
                cmd.Parameters.AddWithValue("SerialNo", nSerialNo);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _nSerialNo = (int)reader["SerialNo"];
                    _nValidMonth = (int)reader["ValidMonth"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _dExpireDate = Convert.ToDateTime(reader["ExpireDate"].ToString());
                    _nStatus = (int)reader["Status"];
                   

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckStatus()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_GiftVoucher where Status=2 AND SerialNo=? AND ExpireDate > ?";
            cmd.Parameters.AddWithValue("SerialNo", _nSerialNo);
            cmd.Parameters.AddWithValue("ExpireDate", _dExpireDate);

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
                return false;
            else return true;
        }
        public void GetMaxSerialNo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            
            try
            {
                cmd.CommandText = "SELECT Max(SerialNo) as SerialNo FROM t_GiftVoucher where ProductID=?";
                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nSerialNo = (int)reader["SerialNo"];
                    
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
         
    }

    public class GiftVouchers : CollectionBase
    {
        public GiftVoucher this[int i]
        {
            get { return (GiftVoucher)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(GiftVoucher oGiftVoucher)
        {
            InnerList.Add(oGiftVoucher);
        }

        public void Refresh(int nProductID, int nWarehouseID,String StartSL, String EndSL)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select SerialNo,ProductName,UnitPrice, WarehouseName,IsNull(DiscountAmount,0) as DiscountAmount,GV.WarehouseID,CustomerName, " +
                            "IsNull(CustomerAddress,'') as CustomerAddress,ContactNo,IsNull(Email,'') as Email,InvoiceNo,IsNull(ExpireDate,Getdate())as ExpireDate, "+
                            "IsNull(DiscountRemarks,'') as DiscountRemarks,IsNull(DiscountEnteredBy,0)as DiscountEnteredBy,IsNull(DiscountEntryDate,Getdate()) as DiscountEntryDate, Status  " +
                            "from t_GiftVoucher GV INNER JOIN t_Warehouse W ON GV.WarehouseID=W.WarehouseID "+
                            "INNER JOIN t_Product P ON P.ProductID=GV.ProductID where Status IN (0,1)";

            if (nProductID != 0)
            {
                sSql = sSql + " and GV.ProductID ='" + nProductID + "'";
            }
            if (nWarehouseID > -1)
            {
                sSql = sSql + "AND GV.WarehouseID ='" + nWarehouseID + "'";
            }
            if (StartSL != "" && EndSL != "")
            {
                sSql = sSql + " AND SerialNo Between '" + StartSL + "' AND '" + EndSL + "'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    GiftVoucher oGiftVoucher = new GiftVoucher();

                    oGiftVoucher.SerialNo = (int)reader["SerialNo"];
                    oGiftVoucher.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                    oGiftVoucher.ProductName = (string)reader["ProductName"];
                    oGiftVoucher.WarehouseName = (string)reader["WarehouseName"];
                    oGiftVoucher.DiscountAmount = Convert.ToDouble(reader["DiscountAmount"].ToString());
                    oGiftVoucher.WarehouseID = (int)reader["WarehouseID"];
                    oGiftVoucher.CustomerName = (string)reader["CustomerName"];
                    oGiftVoucher.CustomerAddress = (string)reader["CustomerAddress"];
                    oGiftVoucher.ContactNo = (string)reader["ContactNo"];
                    oGiftVoucher.Email = (string)reader["Email"];
                    oGiftVoucher.InvoiceNo = (string)reader["InvoiceNo"];
                    oGiftVoucher.ExpireDate = Convert.ToDateTime(reader["ExpireDate"].ToString());
                    oGiftVoucher.DiscountRemarks = (string)reader["DiscountRemarks"];
                    oGiftVoucher.DiscountEnteredBy = (int)reader["DiscountEnteredBy"];
                    oGiftVoucher.DiscountEntryDate = Convert.ToDateTime(reader["DiscountEntryDate"].ToString());
                    oGiftVoucher.Status = (int)reader["Status"];

                    InnerList.Add(oGiftVoucher);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshForSale(DateTime dtFromDate, DateTime dtToDate, int nWarehouseID, string sSerialNo)
        {
            dtToDate = dtToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select SerialNo,CustomerName,ContactNo,UnitPrice,DiscountAmount,SaleDate,ExpireDate,WarehouseID, Status,IsRedeem,RedeemOutlet " +
                            "from (Select SerialNo,CustomerName,ContactNo,UnitPrice, IsNull(DiscountAmount,0) as DiscountAmount, " +
                            "SaleDate,ExpireDate,WarehouseID, Status, 'No' as IsRedeem , '' as RedeemOutlet from t_GiftVoucher where Status = 2 UNION ALL " +
                            "Select GV.SerialNo,CustomerName,ContactNo,UnitPrice, IsNull(DiscountAmount,0) as DiscountAmount, SaleDate,ExpireDate,FromWHID, " +
                            "GVH.Status,'Yes' as IsRedeem , ShortCode as RedeemOutlet from t_GiftVoucherHistory GVH INNER JOIN t_GiftVoucher GV " +
                            "ON GVH.SerialNo=GV.SerialNo Left OUter JOIN t_Warehouse W ON W.WarehouseID=GVH.ToWHID Where GVH.Status =3 " +
                            ")Final Where SaleDate Between ? AND ? AND SaleDate < ? AND WarehouseID=? ";

            cmd.Parameters.AddWithValue("SaleDate", dtFromDate);
            cmd.Parameters.AddWithValue("SaleDate", dtToDate);
            cmd.Parameters.AddWithValue("SaleDate", dtToDate);
            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

            if (sSerialNo != "")
            {
                sSql = sSql + " and SerialNo ='" + sSerialNo + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    GiftVoucher oGiftVoucher = new GiftVoucher();

                    oGiftVoucher.SerialNo = (int)reader["SerialNo"];
                    oGiftVoucher.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                    oGiftVoucher.DiscountAmount = Convert.ToDouble(reader["DiscountAmount"].ToString());
                    oGiftVoucher.WarehouseID = (int)reader["WarehouseID"];
                    oGiftVoucher.CustomerName = (string)reader["CustomerName"];
                    oGiftVoucher.ContactNo = (string)reader["ContactNo"];
                    oGiftVoucher.SaleDate = Convert.ToDateTime(reader["SaleDate"].ToString());
                    oGiftVoucher.ExpireDate = Convert.ToDateTime(reader["ExpireDate"].ToString());
                    oGiftVoucher.Status = (int)reader["Status"];
                    oGiftVoucher.IsRedeem = (string)reader["IsRedeem"];
                    oGiftVoucher.RedeemOutlet = (string)reader["RedeemOutlet"];

                    InnerList.Add(oGiftVoucher);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshForRedeem(DateTime dtFromDate, DateTime dtToDate, int nWarehouseID, string sSerialNo)
        {
            dtToDate = dtToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select GV.SerialNo,CustomerName,ContactNo,UnitPrice, IsNull(DiscountAmount,0) as DiscountAmount, " +
                            "SaleDate,ExpireDate,GV.WarehouseID, Status, SaleDate,RedeemDate, w.ShortCode as SoldOutlet from t_GiftVoucher GV INNER JOIN " +
                            "(Select SerialNo, FromWHID,Convert(datetime,replace(convert(varchar, StatusDate,6),'','-'),1) as RedeemDate " +
                            "from t_GiftVoucherHistory Where Status=3) as GVH ON GV.SerialNo=GVH.SerialNo " +
                            "Inner JOIN t_Warehouse W On W.WarehouseID=GVH.FromWHID where GV.Status =3 " +
                            "AND RedeemDate Between ? AND ? AND RedeemDate <? AND GV.WarehouseID=?";


            cmd.Parameters.AddWithValue("RedeemDate", dtFromDate);
            cmd.Parameters.AddWithValue("RedeemDate", dtToDate);
            cmd.Parameters.AddWithValue("RedeemDate", dtToDate);
            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

            if (sSerialNo != "")
            {
                sSql = sSql + " and SerialNo ='" + sSerialNo + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    GiftVoucher oGiftVoucher = new GiftVoucher();

                    oGiftVoucher.SerialNo = (int)reader["SerialNo"];
                    oGiftVoucher.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                    oGiftVoucher.DiscountAmount = Convert.ToDouble(reader["DiscountAmount"].ToString());
                    oGiftVoucher.WarehouseID = (int)reader["WarehouseID"];
                    oGiftVoucher.CustomerName = (string)reader["CustomerName"];
                    oGiftVoucher.ContactNo = (string)reader["ContactNo"];
                    oGiftVoucher.SaleDate = Convert.ToDateTime(reader["SaleDate"].ToString());
                    oGiftVoucher.RedeemDate = Convert.ToDateTime(reader["RedeemDate"].ToString());
                    oGiftVoucher.ExpireDate = Convert.ToDateTime(reader["ExpireDate"].ToString());
                    oGiftVoucher.Status = (int)reader["Status"];
                    oGiftVoucher.SoldOutlet = (string)reader["SoldOutlet"];

                    InnerList.Add(oGiftVoucher);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshSale(int nWarehouseID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select SerialNo,UnitPrice, IsNull(DiscountAmount,0) as DiscountAmount, WarehouseID, Status " +
                            "from t_GiftVoucher where Status =1 AND WarehouseID=?";

            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    GiftVoucher oGiftVoucher = new GiftVoucher();

                    oGiftVoucher.SerialNo = (int)reader["SerialNo"];
                    oGiftVoucher.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                    oGiftVoucher.DiscountAmount = Convert.ToDouble(reader["DiscountAmount"].ToString());
                    oGiftVoucher.WarehouseID = (int)reader["WarehouseID"];
                    //oGiftVoucher.CustomerName = (string)reader["CustomerName"];
                    //oGiftVoucher.ContactNo = (string)reader["ContactNo"];
                    oGiftVoucher.Status = (int)reader["Status"];

                    InnerList.Add(oGiftVoucher);
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
