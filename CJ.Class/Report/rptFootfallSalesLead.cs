using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Report
{
    public class rptFootfallSalesLead
    {
        private string _sZone;
        private string _sOutlet;
        private string _sASG;
        private string _nProductCode;
        private string _sProductName;
        private string _sCustomerName;
        private string _sPhoneNo;
        private string _sFootFallNo;
        private DateTime _dtFootFallDate;
        private DateTime _dtFormDate;
        private DateTime _dtTodate;
        private string _sCustomerType;
        private int _nRSP;
        private string _sSalesPerson;
        private DateTime _dtFollowUpDate;


        public DateTime FollowUpDate
        {
            get { return _dtFollowUpDate; }
            set { _dtFollowUpDate = value; }
        }
        public string SalesPerson
        {
            get { return _sSalesPerson; }
            set { _sSalesPerson = value; }
        }
        public int RSP
        {
            get { return _nRSP; }
            set { _nRSP = value; }
        }
        public string CustomerType
        {
            get { return _sCustomerType; }
            set { _sCustomerType = value; }
        }
        public string Zone
        {
            get { return _sZone; }
            set { _sZone = value; }
        }
        public string Outlet
        {
            get { return _sOutlet; }
            set { _sOutlet = value; }
        }
        public string ASG
        {
            get { return _sASG; }
            set { _sASG = value; }
        }
        public string ProductCode
        {
            get { return _nProductCode; }
            set { _nProductCode=value; }
        }
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
        public string PhoneNo
        {
            get { return _sPhoneNo; }
            set { _sPhoneNo = value; }
        }
        public string FootFallNo
        {
            get { return _sFootFallNo; }
            set { _sFootFallNo = value; }
        }
        public DateTime FootFallDate
        {
            get { return _dtFootFallDate; }
            set {_dtFootFallDate=value;; }
        }
        public DateTime FromDate
        {
            get { return _dtFormDate; }
            set { _dtFormDate = value; }
        }
        public DateTime ToDate
        {
            get { return _dtTodate; }
            set { _dtTodate = value; }
        }
    }

    public class rptFootfallSalesLeads : CollectionBaseCustom
    {
        public void Add(rptFootfallSalesLead oFootFall)
        {
            this.List.Add(oFootFall);
        }
        public rptFootfallSalesLead this[int i]
        {
            get { return (rptFootfallSalesLead)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void GetSalesLeadData(int nTDZoneID, int nOutletID, int nASGID, DateTime dtFromDate, DateTime dtToDate, string sProductCode, string sProductName)
        {
            DateTime dToDate = dtToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select TerritoryID as ZoneID, TerritoryName as Zone, b.CustomerID as OutletID, left(b.Customername,3)Outlet,FootFallNo,FootFallDate, " +
                         "Convert(datetime,replace(convert(varchar, a.FollowupDate,6),'','-'),1)FollowupDate, " +
                         "CONVERT(CHAR(4), FollowupDate, 120)AS FollowUpYear, CONVERT(CHAR(3), FollowupDate, 109) AS FollowupMonth, " +
                         "CustType = case " +
                         "When customertype = 0 then 'WalkIn' " +
                         "When customertype = 1 then 'Corporate' " +
                         "When customertype = 2 then 'OutdoorIndividual' else 'Others' end, a.CustomerName,MobileNo, " +
                         "SalesPersonName,ProductCode, ProductName, ASGID, ASGName, RSP  from t_footfallmanagement a, v_CustomerDetails b, v_ProductDetails c, " +
                         "t_FootfallsalesPerson d " +
                         "Where a.OutletID=b.CustomerID and a.ProductID=c.ProductID and d.SalesPersonID=a.SalesPersonID and " +
                         "ReasonNo=2 and " +
                         "followupDate between '" + dtFromDate + "' and '" + dToDate + "' and followupDate < '" + dToDate + "' " +
                         " and OutletID <> 0 ";

            if (nTDZoneID != -1)
            {
                sSql = sSql + " and TerritoryID= " + nTDZoneID + "  ";
            }
            if (nASGID != -1)
            {
                sSql = sSql + " and ASGID  = " + nASGID + "  ";
            }

            if (nOutletID != -1)
            {
                sSql = sSql + " and OutletID = " + nOutletID + "  ";
            }
            if (sProductCode != "")
            {
                sSql = sSql + " and ProductCode = '" + sProductCode + "'  ";
            }
            if (sProductName != "")
            {
                sSql = sSql + " and ProductName like '%" + sProductName + "%'  ";
            }

            cmd.CommandTimeout = 0;
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptFootfallSalesLead oSalesLead = new rptFootfallSalesLead();
                    oSalesLead.Zone = (string)reader["Zone"];
                    oSalesLead.Outlet = (string)reader["Outlet"];
                    oSalesLead.ASG = (string)reader["ASGName"];
                    oSalesLead.FootFallNo = (string)reader["FootFallNo"];
                    oSalesLead.FootFallDate = DateTime.Parse(reader["FootFallDate"].ToString());
                    oSalesLead.FollowUpDate = DateTime.Parse(reader["FollowupDate"].ToString());
                    oSalesLead.CustomerName = (string)reader["CustomerName"];
                    oSalesLead.CustomerType = (string)reader["CustType"];
                    oSalesLead.PhoneNo = (string)reader["MobileNo"];
                    oSalesLead.ProductCode = (string)reader["ProductCode"];
                    oSalesLead.ProductName = (string)reader["ProductName"];
                    oSalesLead.SalesPerson = (string)reader["SalesPersonName"];
                    oSalesLead.RSP = int.Parse(reader["RSP"].ToString());
                    InnerList.Add(oSalesLead);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
