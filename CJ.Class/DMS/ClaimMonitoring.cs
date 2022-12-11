// <summary>
// Company: Transcom Electronics Limited
// Author: Md. Humayun Rashid
// Date: Mar 06, 2021
// Time : 09:59 AM
// Description: Class for ClaimSettlement.
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
    public class ClaimSettlement
    {
        private int _nTranID;
        private int _nCustomerID;
        private int _nClaimType;
        private DateTime _dClaimDate;
        private DateTime _dSettlementDate;
        private string _sSettlementType;
        private string _sRemarks;

        private string _sRegionName;
        private string _sAreaName;
        private string _sTerritoryName;
        private string _sCustomerCode;
        private string _sCustomerName;
        private string _sCustomerTypeName;
        private double _InvoiceAmount;

        private int _nInvoiceTypeID;
        private string _sInvoiceTypeName;

        private int _nInvoiceID;

        private int _nIsApproved;

        public int InvoiceID
        {
            get { return _nInvoiceID; }
            set { _nInvoiceID = value; }
        }

        public int IsApproved
        {
            get { return _nIsApproved; }
            set { _nIsApproved = value; }
        }


        public int InvoiceTypeID
        {
            get { return _nInvoiceTypeID; }
            set { _nInvoiceTypeID = value; }
        }

        public string InvoiceTypeName
        {
            get { return _sInvoiceTypeName; }
            set { _sInvoiceTypeName = value.Trim(); }
        }

        // <summary>
        // Get set property for TranID
        // </summary>
        public int TranID
        {
            get { return _nTranID; }
            set { _nTranID = value; }
        }

        // <summary>
        // Get set property for CustomerID
        // </summary>
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }

        // <summary>
        // Get set property for ClaimType
        // </summary>
        public int ClaimType
        {
            get { return _nClaimType; }
            set { _nClaimType = value; }
        }

        // <summary>
        // Get set property for ClaimDate
        // </summary>
        public DateTime ClaimDate
        {
            get { return _dClaimDate; }
            set { _dClaimDate = value; }
        }

        // <summary>
        // Get set property for SettlementDate
        // </summary>
        public DateTime SettlementDate
        {
            get { return _dSettlementDate; }
            set { _dSettlementDate = value; }
        }

        // <summary>
        // Get set property for SettlementType
        // </summary>
        public string SettlementType
        {
            get { return _sSettlementType; }
            set { _sSettlementType = value.Trim(); }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        public string RegionName
        {
            get { return _sRegionName; }
            set { _sRegionName = value.Trim(); }
        }

        public string AreaName
        {
            get { return _sAreaName; }
            set { _sAreaName = value.Trim(); }
        }

        public string TerritoryName
        {
            get { return _sTerritoryName; }
            set { _sTerritoryName = value.Trim(); }
        }

        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value.Trim(); }
        }

        public double InvoiceAmount
        {
            get { return _InvoiceAmount; }
            set { _InvoiceAmount = value; }
        }


        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }

        public string CustomerTypeName
        {
            get { return _sCustomerTypeName; }
            set { _sCustomerTypeName = value.Trim(); }
        }




        public void Add(string sCustomerCode)
        {
            int nMaxTranID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_ClaimSettlement";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = Convert.ToInt32(maxID) + 1;
                }
                _nTranID = nMaxTranID;
                sSql = "INSERT INTO t_ClaimSettlement (TranID, CustomerID, ClaimType, ClaimDate, SettlementDate, SettlementType, Remarks,IsApproved,InvoiceID) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("CustomerID", sCustomerCode);
                cmd.Parameters.AddWithValue("ClaimType", _nClaimType);
                if (!(_dClaimDate == default(DateTime)))
                    cmd.Parameters.AddWithValue("ClaimDate", _dClaimDate);
                else
                {
                    cmd.Parameters.AddWithValue("_dClaimDate", null);
                }
                cmd.Parameters.AddWithValue("SettlementDate", _dSettlementDate);
                cmd.Parameters.AddWithValue("SettlementType", _sSettlementType);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsApproved", 1);
                cmd.Parameters.AddWithValue("InvoiceID", _nInvoiceID);

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
                sSql = "UPDATE t_ClaimSettlement SET CustomerID = ?, ClaimType = ?, ClaimDate = ?, SettlementDate = ?, SettlementType = ?, Remarks = ? WHERE TranID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("ClaimType", _nClaimType);
                cmd.Parameters.AddWithValue("ClaimDate", _dClaimDate);
                cmd.Parameters.AddWithValue("SettlementDate", _dSettlementDate);
                cmd.Parameters.AddWithValue("SettlementType", _sSettlementType);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("TranID", _nTranID);

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
                sSql = "DELETE FROM t_ClaimSettlement WHERE [TranID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", _nTranID);
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
                cmd.CommandText = "SELECT * FROM t_ClaimSettlement where TranID =?";
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nTranID = (int)reader["TranID"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _nClaimType = (int)reader["ClaimType"];
                    _dClaimDate = Convert.ToDateTime(reader["ClaimDate"].ToString());
                    _dSettlementDate = Convert.ToDateTime(reader["SettlementDate"].ToString());
                    _sSettlementType = (string)reader["SettlementType"];
                    _sRemarks = (string)reader["Remarks"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void editDate()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_ClaimSettlement SET ClaimDate = ? WHERE TranID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ClaimDate", _dClaimDate);

                cmd.Parameters.AddWithValue("TranID", _nTranID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddClaimDate()
        {
            int nMaxTranID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT MAX([TranID]) FROM t_ClaimSettlement";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = Convert.ToInt32(maxID) + 1;
                }
                _nTranID = nMaxTranID;

                sSql = "INSERT INTO t_ClaimSettlement VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("ClaimType", 1);
                cmd.Parameters.AddWithValue("ClaimDate", DateTime.Now);
                cmd.Parameters.AddWithValue("SettlementDate", _dSettlementDate.ToShortDateString());
                cmd.Parameters.AddWithValue("SettlementType", _sSettlementType);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsApproved", 1);
                cmd.Parameters.AddWithValue("InvoiceID", _nInvoiceID);

                cmd.ExecuteNonQuery();

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertClaim(int nInvoiceTypeID)
        {
            int nMaxTranID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";


            try
            {

                cmd = DBController.Instance.GetCommand();
                sSql = "SELECT MAX([TranID]) FROM t_CustomerTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _nTranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ClaimSettlement VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("ClaimType", _nInvoiceTypeID);
                cmd.Parameters.AddWithValue("ClaimDate", DateTime.Now);
                cmd.Parameters.AddWithValue("SettlementDate", _dSettlementDate.ToShortDateString());
                cmd.Parameters.AddWithValue("SettlementType", _sSettlementType);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsApproved", 1);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "Select a.CustomerID,CustomerCode From  " +
                          "  (" +
                         "  Select CustomerID, CustomerCode  " +
                         "     From v_CustomerDetails  " +
                         "    ) a  " +
                         "   Left Outer Join  " +
                         "    (  " +
                         "    Select CustomerID From t_ClaimSettlement  " +
                         "    ) b on a.CustomerID = b.CustomerID  " +
                         "    where CustomerCode = ? ";

            cmd.Parameters.AddWithValue("CustomerCode", _sCustomerCode);

            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCustomerID = int.Parse(reader["CustomerID"].ToString());
                    _sCustomerCode = (string)reader["CustomerCode"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool ClaimDateCheck()
        {
            int Count = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from [t_ClaimSettlement] where CustomerID=? and ClaimType=? and SettlementDate=? and IsApproved=?";
            cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
            cmd.Parameters.AddWithValue("ClaimType", 1);
            cmd.Parameters.AddWithValue("SettlementDate", _dSettlementDate);
            cmd.Parameters.AddWithValue("IsApproved", 1);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Count++;
                }
                reader.Close();
                if (Count == 0) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        //public void Add(DSPromotionContribution _oDSPromotionContribution)
        //{
        //    int nMaxBankDiscountID = 0;
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "";
        //    try
        //    {
        //        sSql = "SELECT MAX([BankDiscountID]) FROM t_PromoDiscountBank";
        //        cmd.CommandText = sSql;
        //        object maxID = cmd.ExecuteScalar();
        //        if (maxID == DBNull.Value)
        //        {
        //            nMaxBankDiscountID = 1;
        //        }
        //        else
        //        {
        //            nMaxBankDiscountID = Convert.ToInt32(maxID) + 1;
        //        }
        //        _nBankDiscountID = nMaxBankDiscountID;
        //        sSql = "INSERT INTO t_PromoDiscountBank (BankDiscountID, BankID, AGID, BrandID, DiscountPercent, IsActive, Status, FromDate, ToDate, CreateUserID, CreateDate,PaymentModeID,MaxDiscountAmount,IsBankDiscount,CardType,Contribution) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;

        //        cmd.Parameters.AddWithValue("BankDiscountID", _nBankDiscountID);
        //        cmd.Parameters.AddWithValue("BankID", _nBankID);
        //        cmd.Parameters.AddWithValue("AGID", _nAGID);
        //        cmd.Parameters.AddWithValue("BrandID", _nBrandID);
        //        cmd.Parameters.AddWithValue("DiscountPercent", _DiscountPercent);
        //        cmd.Parameters.AddWithValue("IsActive", _nIsActive);
        //        cmd.Parameters.AddWithValue("Status", _nStatus);
        //        cmd.Parameters.AddWithValue("FromDate", _dFromDate);
        //        cmd.Parameters.AddWithValue("ToDate", _dToDate);
        //        cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
        //        cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
        //        cmd.Parameters.AddWithValue("PaymentModeID", _PaymentModeID);
        //        cmd.Parameters.AddWithValue("MaxDiscountAmount", _MaxDiscountAmount);
        //        cmd.Parameters.AddWithValue("IsBankDiscount", _IsBankDiscount);
        //        cmd.Parameters.AddWithValue("CardType", _CardType);
        //        cmd.Parameters.AddWithValue("Contribution", _Contribution);

        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();


        //        foreach (DSPromotionContribution.PromotionContributionRow oPromotionContributionRow in _oDSPromotionContribution.PromotionContribution)
        //        {
        //            PromoDiscountContributor oPromoDiscountContributor = new PromoDiscountContributor();
        //            oPromoDiscountContributor.ConsumerPromoID = _nBankDiscountID;
        //            oPromoDiscountContributor.DiscountContributorID = oPromotionContributionRow.DiscountContributorID;
        //            oPromoDiscountContributor.Amount = oPromotionContributionRow.Amount;
        //            oPromoDiscountContributor.Type = oPromotionContributionRow.Type;
        //            if (oPromoDiscountContributor.Amount > 0)
        //            {
        //                oPromoDiscountContributor.AddDiscountBankContribution();
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
    }
    public class ClaimSettlements : CollectionBase
    {
        public ClaimSettlement this[int i]
        {
            get { return (ClaimSettlement)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ClaimSettlement oClaimSettlement)
        {
            InnerList.Add(oClaimSettlement);
        }
        public int GetIndex(int nTranID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].TranID == nTranID)
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
            string sSql = "SELECT * FROM t_ClaimSettlement";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClaimSettlement oClaimSettlement = new ClaimSettlement();
                    oClaimSettlement.TranID = (int)reader["TranID"];
                    oClaimSettlement.CustomerID = (int)reader["CustomerID"];
                    oClaimSettlement.ClaimType = (int)reader["ClaimType"];
                    oClaimSettlement.ClaimDate = Convert.ToDateTime(reader["ClaimDate"].ToString());
                    oClaimSettlement.SettlementDate = Convert.ToDateTime(reader["SettlementDate"].ToString());
                    oClaimSettlement.SettlementType = (string)reader["SettlementType"];
                    oClaimSettlement.Remarks = (string)reader["Remarks"];
                    InnerList.Add(oClaimSettlement);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<ClaimSettlement> RefreshMonitoring(int CustomerID, DateTime fromDate, DateTime toDate)
        {
            var list = new List<ClaimSettlement>();
            InnerList.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = @" select RegionName,AreaName,TerritoryName,a.CustomerID,CustomerCode,CustomerName,CustomerTypeName,InvoiceDate as ClaimDate,InvoiceAmount, 
            InvoiceTypeName as SettlementType,Remarks, ClaimType= case when a.InvoiceTypeID=3 then 'Replacement' when  a.InvoiceTypeID=15 then 'TP'
            else  'Others' end 
            from t_SalesInvoice a,   t_InvoiceType b, v_CustomerDetails c
            where a.InvoiceTypeID=b.InvoiceTypeID and a.CustomerID=c.CustomerID and a.InvoiceTypeID in (3,15,17)";
            string str = "";
            if (CustomerID == -1)
            {
                str = "and InvoiceDate between '" + fromDate + "' and '" + toDate + "'";

            }
            else
            {
                str = "and a.CustomerID = " + CustomerID + " and InvoiceDate between '" + fromDate + "' and '" + toDate + "'";
            }

            sSql = string.Format(sSql, str);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClaimSettlement oClaimSettlement = new ClaimSettlement();

                    oClaimSettlement.RegionName = (string)reader["RegionName"];                    
                    oClaimSettlement.AreaName = (string)reader["AreaName"];
                    oClaimSettlement.TerritoryName = (string)reader["TerritoryName"];
                    oClaimSettlement.CustomerCode = (string)reader["CustomerCode"];
                    oClaimSettlement.CustomerName = (string)reader["CustomerName"];
                    oClaimSettlement.CustomerTypeName = (string)reader["CustomerTypeName"];
                    if (!reader.IsDBNull(10))
                        oClaimSettlement.InvoiceAmount = Double.Parse(reader["InvoiceAmount"].ToString());
                    else
                        oClaimSettlement.InvoiceAmount = 0;
                    if (!reader.IsDBNull(11))
                        oClaimSettlement.ClaimDate = Convert.ToDateTime(reader["ClaimDate"].ToString());
                    else
                        oClaimSettlement.ClaimDate = default(DateTime);
                    oClaimSettlement.SettlementType = (string)reader["SettlementType"];
                    oClaimSettlement.Remarks = (string)reader["Remarks"];

                    //if (!reader.IsDBNull(12))
                    //    oDMSReplaceClaim.ReplacementRecDate = Convert.ToDateTime(reader["ReplacementRecDate"].ToString());
                    //else
                    //    oDMSReplaceClaim.ReplacementRecDate = default(DateTime);
                    //if (!reader.IsDBNull(13))
                    //    oDMSReplaceClaim.ApprovalDate = Convert.ToDateTime(reader["ApprovalDate"].ToString());
                    //else
                    //    oDMSReplaceClaim.ApprovalDate = default(DateTime);
                    //if (!reader.IsDBNull(14))
                    //    oDMSReplaceClaim.DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"].ToString());
                    //else
                    //    oDMSReplaceClaim.DeliveryDate = default(DateTime);

                    InnerList.Add(oClaimSettlement);
                    list.Add(oClaimSettlement);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return list;
        }

        public void ClaimRefresh(int nStatus, int CustomerID, DateTime fromDate, DateTime toDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "";
            {
                sSql = " select RegionName,AreaName,TerritoryName,CustomerCode,CustomerName,CustomerTypeName,ClaimType,a.CustomerID,SettlementDate,SettlementType,Remarks " +
                        " from t_ClaimSettlement a, v_CustomerDetails b " +
                        " where a.CustomerID = b.CustomerID and IsApproved = 1 and ClaimDate between '" + fromDate + "' and '" + toDate + "' and ClaimDate< '" + toDate + "' ";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND ClaimType=" + nStatus + "";
            }
            if (CustomerID != -1)
            {
                sSql = sSql + " AND a.CustomerID =" + CustomerID + "";
            }

            sSql = sSql + " Order by SettlementDate";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClaimSettlement oClaimSettlement = new ClaimSettlement();
                    oClaimSettlement.RegionName = (string)reader["RegionName"];
                    oClaimSettlement.AreaName = (string)reader["AreaName"];
                    oClaimSettlement.TerritoryName = (string)reader["TerritoryName"];
                    oClaimSettlement.CustomerCode = (string)reader["CustomerCode"];
                    oClaimSettlement.CustomerName = (string)reader["CustomerName"];
                    oClaimSettlement.CustomerTypeName = (string)reader["CustomerTypeName"];
                    oClaimSettlement.ClaimType = (int)reader["ClaimType"];
                    oClaimSettlement.SettlementDate = Convert.ToDateTime(reader["SettlementDate"].ToString());
                    oClaimSettlement.CustomerID = (int)reader["CustomerID"];
                    oClaimSettlement.SettlementType = (string)reader["SettlementType"];
                    oClaimSettlement.Remarks = (string)reader["Remarks"];

                    InnerList.Add(oClaimSettlement);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshReplacement(DateTime dFromDate, DateTime dToDate, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = @"
select RegionName,AreaName,TerritoryName,CustomerCode,CustomerName,CustomerTypeName, ClaimDate,InvoiceDate,InvoiceTypeName ,InvoiceAmount, 
Remarks,CustomerID,InvoiceID
from
(
select RegionName,AreaName,TerritoryName,main.CustomerID,CustomerCode,CustomerName,CustomerTypeName,ClaimDate,InvoiceDate,InvoiceTypeName ,InvoiceAmount, 
Remarks,IsApproved,main.InvoiceID
from
(
select RegionName,AreaName,TerritoryName,a.CustomerID,CustomerCode,CustomerName,CustomerTypeName,InvoiceDate ,InvoiceTypeName ,InvoiceAmount, 
Remarks,InvoiceID
from t_SalesInvoice a,   t_InvoiceType b, v_CustomerDetails c
where a.InvoiceTypeID=b.InvoiceTypeID and a.CustomerID=c.CustomerID and a.InvoiceTypeID in (3)
) as Main
left outer join
(
Select CustomerID,ClaimDate,SettlementDate,IsApproved,InvoiceID
from [dbo].[t_ClaimSettlement] where ClaimType=1
) as claim on Main.CustomerID=claim.CustomerID and  Main.InvoiceID=claim.InvoiceID 
) as final  ";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " where  IsApproved is null and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate<'" + dToDate + "'";
            }

            sSql = sSql + " order by RegionName desc ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   
                    ClaimSettlement oClaimSettlement = new ClaimSettlement();

                    oClaimSettlement.RegionName = (string)reader["RegionName"];
                    oClaimSettlement.AreaName = (string)reader["AreaName"];
                    oClaimSettlement.TerritoryName = (string)reader["TerritoryName"];
                    
                    oClaimSettlement.CustomerCode = (string)reader["CustomerCode"];
                    oClaimSettlement.CustomerName = (string)reader["CustomerName"];
                    oClaimSettlement.CustomerTypeName = (string)reader["CustomerTypeName"];
                    if (!reader.IsDBNull(6))
                        oClaimSettlement.ClaimDate = Convert.ToDateTime(reader["ClaimDate"].ToString());
                    else
                        oClaimSettlement.ClaimDate = default(DateTime);
                    oClaimSettlement.SettlementDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oClaimSettlement.SettlementType = (string)reader["InvoiceTypeName"];
                    if (!reader.IsDBNull(9))
                        oClaimSettlement.InvoiceAmount = Double.Parse(reader["InvoiceAmount"].ToString());
                    else
                        oClaimSettlement.InvoiceAmount = 0;
                    oClaimSettlement.Remarks = (string)reader["Remarks"];
                    oClaimSettlement.CustomerID = (int)reader["CustomerID"];
                    oClaimSettlement.InvoiceID = int.Parse(reader["InvoiceID"].ToString());

                    InnerList.Add(oClaimSettlement);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void CheckDuplicateData()
        {

        }

        public void RefreshClaimType()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select InvoiceTypeID,InvoiceTypeName,SettType= case when InvoiceTypeID=15 then 'TP Settlement' else 'KPI Settlement' end from t_InvoiceType where InvoiceTypeID in (15,16) ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClaimSettlement oClaimSettlement = new ClaimSettlement();

                    oClaimSettlement.InvoiceTypeID = Convert.ToInt32(reader["InvoiceTypeID"].ToString());
                    oClaimSettlement.InvoiceTypeName = (string)reader["InvoiceTypeName"];
                    oClaimSettlement.SettlementType = (string)reader["SettType"];

                    InnerList.Add(oClaimSettlement);

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

