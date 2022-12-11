// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Nov 24, 2019
// Time : 12:27 PM
// Description: Class for OutletSiteInfo.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.BasicData
{
    public class OutletSiteInfoDetail
    {
        private int _nID;
        private int _nSiteID;
        private int _nAreaType;
        private int _nArea;
        private double _RentAmount;
        private double _AdvancedAmount;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for SiteID
        // </summary>
        public int SiteID
        {
            get { return _nSiteID; }
            set { _nSiteID = value; }
        }

        // <summary>
        // Get set property for AreaType
        // </summary>
        public int AreaType
        {
            get { return _nAreaType; }
            set { _nAreaType = value; }
        }

        // <summary>
        // Get set property for Area
        // </summary>
        public int Area
        {
            get { return _nArea; }
            set { _nArea = value; }
        }

        // <summary>
        // Get set property for RentAmount
        // </summary>
        public double RentAmount
        {
            get { return _RentAmount; }
            set { _RentAmount = value; }
        }

        // <summary>
        // Get set property for AdvancedAmount
        // </summary>
        public double AdvancedAmount
        {
            get { return _AdvancedAmount; }
            set { _AdvancedAmount = value; }
        }

        public void Add(int _nSiteID)
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_OutletSiteInfoDetails";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = Convert.ToInt32(maxID) + 1;
                }
                _nID = nMaxID;
                sSql = "INSERT INTO t_OutletSiteInfoDetails (ID, SiteID, AreaType, Area, RentAmount, AdvancedAmount) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("SiteID", _nSiteID);
                cmd.Parameters.AddWithValue("AreaType", _nAreaType);
                cmd.Parameters.AddWithValue("Area", _nArea);
                cmd.Parameters.AddWithValue("RentAmount", _RentAmount);
                cmd.Parameters.AddWithValue("AdvancedAmount", _AdvancedAmount);

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
                sSql = "UPDATE t_OutletSiteInfoDetails SET SiteID = ?, AreaType = ?, Area = ?, RentAmount = ?, AdvancedAmount = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SiteID", _nSiteID);
                cmd.Parameters.AddWithValue("AreaType", _nAreaType);
                cmd.Parameters.AddWithValue("Area", _nArea);
                cmd.Parameters.AddWithValue("RentAmount", _RentAmount);
                cmd.Parameters.AddWithValue("AdvancedAmount", _AdvancedAmount);

                cmd.Parameters.AddWithValue("ID", _nID);

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
                sSql = "DELETE FROM t_OutletSiteInfoDetails WHERE [ID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
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
                cmd.CommandText = "SELECT * FROM t_OutletSiteInfoDetails where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nSiteID = (int)reader["SiteID"];
                    _nAreaType = (int)reader["AreaType"];
                    _nArea = (int)reader["Area"];
                    _RentAmount = Convert.ToDouble(reader["RentAmount"].ToString());
                    _AdvancedAmount = Convert.ToDouble(reader["AdvancedAmount"].ToString());
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
      public class OutletSiteInfo : CollectionBase
        {
            public OutletSiteInfoDetail this[int i]
            {
                get { return (OutletSiteInfoDetail)InnerList[i]; }
                set { InnerList[i] = value; }
            }
            public void Add(OutletSiteInfoDetail oOutletSiteInfoDetail)
            {
                InnerList.Add(oOutletSiteInfoDetail);
            }
        private int _nSiteID;
        private string _sSiteName;
        private DateTime _sEntryDate;
        private DateTime _nCreateDate;
        private int _nCreateBy;
        private string _sOutletCode;
        private string _sOwnersName;
        private string _sOwnersAddress;
        private string _sMobileNo;
        private double _RentalIncrement;
        private double _ContactPeriod;
        private string _sAdvanceAdjustment;
        private string _sCommercialPermission;
        private int _nElectricityLoad;
        private DateTime _sHandOverDate;
        private DateTime _sEffectiveDate;
        private string _sCellingHeight;
        private string _sParking;
        private string _sGovtVatTax;
        private string _sUtilityCharges;
        private string _sLandLordProvide;
        private string _sOutletBenchMark;
        private int _nOutletFeasibilityID;


        // <summary>
        // Get set property for SiteID
        // </summary>
        public int SiteID
        {
            get { return _nSiteID; }
            set { _nSiteID = value; }
        }

        // <summary>
        // Get set property for SiteName
        // </summary>
        public string SiteName
        {
            get { return _sSiteName; }
            set { _sSiteName = value.Trim(); }
        }

        // <summary>
        // Get set property for EntryDate
        // </summary>
        public DateTime EntryDate
        {
            get { return _sEntryDate; }
            set { _sEntryDate = value; }
        }

        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _nCreateDate; }
            set { _nCreateDate = value; }
        }

        // <summary>
        // Get set property for CreateBy
        // </summary>
        public int CreateBy
        {
            get { return _nCreateBy; }
            set { _nCreateBy = value; }
        }

        // <summary>
        // Get set property for OutletCode
        // </summary>
        public string OutletCode
        {
            get { return _sOutletCode; }
            set { _sOutletCode = value.Trim(); }
        }

        // <summary>
        // Get set property for OwnersName
        // </summary>
        public string OwnersName
        {
            get { return _sOwnersName; }
            set { _sOwnersName = value.Trim(); }
        }

        // <summary>
        // Get set property for OwnersAddress
        // </summary>
        public string OwnersAddress
        {
            get { return _sOwnersAddress; }
            set { _sOwnersAddress = value.Trim(); }
        }

        // <summary>
        // Get set property for MobileNo
        // </summary>
        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value.Trim(); }
        }

        // <summary>
        // Get set property for RentalIncrement
        // </summary>
        public double RentalIncrement
        {
            get { return _RentalIncrement; }
            set { _RentalIncrement = value; }
        }

        // <summary>
        // Get set property for ContactPeriod
        // </summary>
        public double ContactPeriod
        {
            get { return _ContactPeriod; }
            set { _ContactPeriod = value; }
        }

        // <summary>
        // Get set property for AdvanceAdjustment
        // </summary>
        public string AdvanceAdjustment
        {
            get { return _sAdvanceAdjustment; }
            set { _sAdvanceAdjustment = value.Trim(); }
        }

        // <summary>
        // Get set property for CommercialPermission
        // </summary>
        public string CommercialPermission
        {
            get { return _sCommercialPermission; }
            set { _sCommercialPermission = value.Trim(); }
        }

        // <summary>
        // Get set property for ElectricityLoad
        // </summary>
        public int ElectricityLoad
        {
            get { return _nElectricityLoad; }
            set { _nElectricityLoad = value; }
        }

        // <summary>
        // Get set property for HandOverDate
        // </summary>
        public DateTime HandOverDate
        {
            get { return _sHandOverDate; }
            set { _sHandOverDate = value; }
        }

        // <summary>
        // Get set property for EffectiveDate
        // </summary>
        public DateTime EffectiveDate
        {
            get { return _sEffectiveDate; }
            set { _sEffectiveDate = value; }
        }

        // <summary>
        // Get set property for CellingHeight
        // </summary>
        public string CellingHeight
        {
            get { return _sCellingHeight; }
            set { _sCellingHeight = value.Trim(); }
        }

        // <summary>
        // Get set property for Parking
        // </summary>
        public string Parking
        {
            get { return _sParking; }
            set { _sParking = value.Trim(); }
        }

        // <summary>
        // Get set property for GovtVatTax
        // </summary>
        public string GovtVatTax
        {
            get { return _sGovtVatTax; }
            set { _sGovtVatTax = value.Trim(); }
        }

        // <summary>
        // Get set property for UtilityCharges
        // </summary>
        public string UtilityCharges
        {
            get { return _sUtilityCharges; }
            set { _sUtilityCharges = value.Trim(); }
        }

        // <summary>
        // Get set property for LandLordProvide
        // </summary>
        public string LandLordProvide
        {
            get { return _sLandLordProvide; }
            set { _sLandLordProvide = value.Trim(); }
        }

        // <summary>
        // Get set property for OutletBenchMark
        // </summary>
        public string OutletBenchMark
        {
            get { return _sOutletBenchMark; }
            set { _sOutletBenchMark = value.Trim(); }
        }

        // <summary>
        // Get set property for OutletFeasibilityID
        // </summary>
        public int OutletFeasibilityID
        {
            get { return _nOutletFeasibilityID; }
            set { _nOutletFeasibilityID = value; }
        }

        public void Add()
        {
            int nMaxSiteID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([SiteID]) FROM t_OutletSiteInfo";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSiteID = 1;
                }
                else
                {
                    nMaxSiteID = Convert.ToInt32(maxID) + 1;
                }
                _nSiteID = nMaxSiteID;
                sSql = "INSERT INTO t_OutletSiteInfo (SiteID, SiteName, EntryDate, CreateDate, CreateBy, OutletCode, OwnersName, OwnersAddress, MobileNo, RentalIncrement, ContactPeriod, AdvanceAdjustment,ElectricityLoad, HandOverDate, EffectiveDate, CellingHeight, Parking, GovtVatTax, UtilityCharges, LandLordProvide, OutletBenchMark) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SiteID", _nSiteID);
                cmd.Parameters.AddWithValue("SiteName", _sSiteName);
                cmd.Parameters.AddWithValue("EntryDate", _sEntryDate);
                cmd.Parameters.AddWithValue("CreateDate", _nCreateDate);
                cmd.Parameters.AddWithValue("CreateBy", _nCreateBy);
                cmd.Parameters.AddWithValue("OutletCode", _sOutletCode);
                cmd.Parameters.AddWithValue("OwnersName", _sOwnersName);
                cmd.Parameters.AddWithValue("OwnersAddress", _sOwnersAddress);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("RentalIncrement", _RentalIncrement);
                cmd.Parameters.AddWithValue("ContactPeriod", _ContactPeriod);
                cmd.Parameters.AddWithValue("AdvanceAdjustment", _sAdvanceAdjustment);
                cmd.Parameters.AddWithValue("ElectricityLoad", _nElectricityLoad);
                cmd.Parameters.AddWithValue("HandOverDate", _sHandOverDate);
                cmd.Parameters.AddWithValue("EffectiveDate", _sEffectiveDate);
                cmd.Parameters.AddWithValue("CellingHeight", _sCellingHeight);
                cmd.Parameters.AddWithValue("Parking", _sParking);
                cmd.Parameters.AddWithValue("GovtVatTax", _sGovtVatTax);
                cmd.Parameters.AddWithValue("UtilityCharges", _sUtilityCharges);
                cmd.Parameters.AddWithValue("LandLordProvide", _sLandLordProvide);
                cmd.Parameters.AddWithValue("OutletBenchMark", _sOutletBenchMark);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                foreach (OutletSiteInfoDetail oOutletSiteInfoDetail in this)
                {
                    oOutletSiteInfoDetail.Add(_nSiteID);
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
                sSql = "UPDATE t_OutletSiteInfo SET SiteName = ?, EntryDate = ?, CreateDate = ?, CreateBy = ?, OutletCode = ?, OwnersName = ?, OwnersAddress = ?, MobileNo = ?, RentalIncrement = ?, ContactPeriod = ?, AdvanceAdjustment = ?,ElectricityLoad = ?, HandOverDate = ?, EffectiveDate = ?, CellingHeight = ?, Parking = ?, GovtVatTax = ?, UtilityCharges = ?, LandLordProvide = ?, OutletBenchMark = ? WHERE SiteID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SiteName", _sSiteName);
                cmd.Parameters.AddWithValue("EntryDate", _sEntryDate);
                cmd.Parameters.AddWithValue("CreateDate", _nCreateDate);
                cmd.Parameters.AddWithValue("CreateBy", _nCreateBy);
                cmd.Parameters.AddWithValue("OutletCode", _sOutletCode);
                cmd.Parameters.AddWithValue("OwnersName", _sOwnersName);
                cmd.Parameters.AddWithValue("OwnersAddress", _sOwnersAddress);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("RentalIncrement", _RentalIncrement);
                cmd.Parameters.AddWithValue("ContactPeriod", _ContactPeriod);
                cmd.Parameters.AddWithValue("AdvanceAdjustment", _sAdvanceAdjustment);
                cmd.Parameters.AddWithValue("ElectricityLoad", _nElectricityLoad);
                cmd.Parameters.AddWithValue("HandOverDate", _sHandOverDate);
                cmd.Parameters.AddWithValue("EffectiveDate", _sEffectiveDate);
                cmd.Parameters.AddWithValue("CellingHeight", _sCellingHeight);
                cmd.Parameters.AddWithValue("Parking", _sParking);
                cmd.Parameters.AddWithValue("GovtVatTax", _sGovtVatTax);
                cmd.Parameters.AddWithValue("UtilityCharges", _sUtilityCharges);
                cmd.Parameters.AddWithValue("LandLordProvide", _sLandLordProvide);
                cmd.Parameters.AddWithValue("OutletBenchMark", _sOutletBenchMark);

                cmd.Parameters.AddWithValue("SiteID", _nSiteID);

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
                sSql = "DELETE FROM t_OutletSiteInfo WHERE [SiteID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SiteID", _nSiteID);
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
                cmd.CommandText = "SELECT * FROM t_OutletSiteInfo where SiteID =?";
                cmd.Parameters.AddWithValue("SiteID", _nSiteID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nSiteID = (int)reader["SiteID"];
                    _sSiteName = (string)reader["SiteName"];
                    _sEntryDate = (DateTime)reader["EntryDate"];
                    _nCreateDate = (DateTime)reader["CreateDate"];
                    _nCreateBy = (int)reader["CreateBy"];
                    _sOutletCode = (string)reader["OutletCode"];
                    _sOwnersName = (string)reader["OwnersName"];
                    _sOwnersAddress = (string)reader["OwnersAddress"];
                    _sMobileNo = (string)reader["MobileNo"];
                    _RentalIncrement = Convert.ToDouble(reader["RentalIncrement"].ToString());
                    _ContactPeriod = Convert.ToDouble(reader["ContactPeriod"].ToString());
                    _sAdvanceAdjustment = (string)reader["AdvanceAdjustment"];
                    _sCommercialPermission = (string)reader["CommercialPermission"];
                    _nElectricityLoad = (int)reader["ElectricityLoad"];
                    _sHandOverDate = (DateTime)reader["HandOverDate"];
                    _sEffectiveDate = (DateTime)reader["EffectiveDate"];
                    _sCellingHeight = (string)reader["CellingHeight"];
                    _sParking = (string)reader["Parking"];
                    _sGovtVatTax = (string)reader["GovtVatTax"];
                    _sUtilityCharges = (string)reader["UtilityCharges"];
                    _sLandLordProvide = (string)reader["LandLordProvide"];
                    _sOutletBenchMark = (string)reader["OutletBenchMark"];
                    _nOutletFeasibilityID = (int)reader["OutletFeasibilityID"];
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
    public class OutletSiteInfos : CollectionBase
    {
        public OutletSiteInfo this[int i]
        {
            get { return (OutletSiteInfo)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(OutletSiteInfo oOutletSiteInfo)
        {
            InnerList.Add(oOutletSiteInfo);
        }
        public int GetIndex(int nSiteID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].SiteID == nSiteID)
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
            string sSql = "SELECT * FROM t_OutletSiteInfo";            
            sSql = sSql + " Order by Outlet";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletSiteInfo oOutletSiteInfo = new OutletSiteInfo();
                    oOutletSiteInfo.SiteID = (int)reader["SiteID"];
                    oOutletSiteInfo.SiteName = (string)reader["SiteName"];
                    oOutletSiteInfo.EntryDate = (DateTime)reader["EntryDate"];
                    oOutletSiteInfo.CreateDate = (DateTime)reader["CreateDate"];
                    oOutletSiteInfo.CreateBy = (int)reader["CreateBy"];
                    oOutletSiteInfo.OutletCode = (string)reader["OutletCode"];
                    oOutletSiteInfo.OwnersName = (string)reader["OwnersName"];
                    oOutletSiteInfo.OwnersAddress = (string)reader["OwnersAddress"];
                    oOutletSiteInfo.MobileNo = (string)reader["MobileNo"];
                    oOutletSiteInfo.RentalIncrement = Convert.ToDouble(reader["RentalIncrement"].ToString());
                    oOutletSiteInfo.ContactPeriod = Convert.ToDouble(reader["ContactPeriod"].ToString());
                    oOutletSiteInfo.AdvanceAdjustment = (string)reader["AdvanceAdjustment"];
                    oOutletSiteInfo.CommercialPermission = (string)reader["CommercialPermission"];
                    oOutletSiteInfo.ElectricityLoad = (int)reader["ElectricityLoad"];
                    oOutletSiteInfo.HandOverDate = (DateTime)reader["HandOverDate"];
                    oOutletSiteInfo.EffectiveDate = (DateTime)reader["EffectiveDate"];
                    oOutletSiteInfo.CellingHeight = (string)reader["CellingHeight"];
                    oOutletSiteInfo.Parking = (string)reader["Parking"];
                    oOutletSiteInfo.GovtVatTax = (string)reader["GovtVatTax"];
                    oOutletSiteInfo.UtilityCharges = (string)reader["UtilityCharges"];
                    oOutletSiteInfo.LandLordProvide = (string)reader["LandLordProvide"];
                    oOutletSiteInfo.OutletBenchMark = (string)reader["OutletBenchMark"];
                    oOutletSiteInfo.OutletFeasibilityID = (int)reader["OutletFeasibilityID"];
                    InnerList.Add(oOutletSiteInfo);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshBySiteInfo(DateTime dFromDate, DateTime dToDate, string sCode, bool IsCheck)
        {
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_OutletSiteInfo where 1=1";
            if (IsCheck == false)
            {
                sSql = sSql + " AND EntryDate between '" + dFromDate + "' and '" + dToDate + "' and EntryDate<'" + dToDate + "' ";
            }
            if (sCode != "<All>")
            {
                sSql = sSql + " AND OutletCode ='" + sCode + "'";
            }
            //if (nIsActive != -1)
            //{
            //    sSql = sSql + " AND IsActive=" + nIsActive + "";
            //}
            sSql = sSql + " Order by OutletCode";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletSiteInfo oOutletSiteInfo = new OutletSiteInfo();
                    oOutletSiteInfo.SiteID = (int)reader["SiteID"];
                    oOutletSiteInfo.SiteName = (string)reader["SiteName"];
                    oOutletSiteInfo.EntryDate = (DateTime)reader["EntryDate"];
                    oOutletSiteInfo.CreateDate = (DateTime)reader["CreateDate"];
                    oOutletSiteInfo.CreateBy = (int)reader["CreateBy"];
                    oOutletSiteInfo.OutletCode = (string)reader["OutletCode"];
                    oOutletSiteInfo.OwnersName = (string)reader["OwnersName"];
                    oOutletSiteInfo.OwnersAddress = (string)reader["OwnersAddress"];
                    oOutletSiteInfo.MobileNo = (string)reader["MobileNo"];
                    oOutletSiteInfo.RentalIncrement = Convert.ToDouble(reader["RentalIncrement"].ToString());
                    oOutletSiteInfo.ContactPeriod = Convert.ToDouble(reader["ContactPeriod"].ToString());
                    oOutletSiteInfo.AdvanceAdjustment = (string)reader["AdvanceAdjustment"];
                    oOutletSiteInfo.ElectricityLoad = (int)reader["ElectricityLoad"];
                    oOutletSiteInfo.HandOverDate = (DateTime)reader["HandOverDate"];
                    oOutletSiteInfo.EffectiveDate = (DateTime)reader["EffectiveDate"];
                    oOutletSiteInfo.CellingHeight = (string)reader["CellingHeight"];
                    oOutletSiteInfo.Parking = (string)reader["Parking"];
                    oOutletSiteInfo.GovtVatTax = (string)reader["GovtVatTax"];
                    oOutletSiteInfo.UtilityCharges = (string)reader["UtilityCharges"];
                    oOutletSiteInfo.LandLordProvide = (string)reader["LandLordProvide"];
                    oOutletSiteInfo.OutletBenchMark = (string)reader["OutletBenchMark"];
                    InnerList.Add(oOutletSiteInfo);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshBySiteInfoDetail(int nSiteID)
        {
            InnerList.Clear();
            //dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_OutletSiteInfoDetails where SiteID="+nSiteID+"";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletSiteInfoDetail oOutletSiteInfoDetail = new OutletSiteInfoDetail();
                    oOutletSiteInfoDetail.ID = (int)reader["ID"];
                    oOutletSiteInfoDetail.SiteID = (int)reader["SiteID"];
                    oOutletSiteInfoDetail.AreaType = (int)reader["AreaType"];
                    oOutletSiteInfoDetail.Area = (int)reader["Area"];
                    oOutletSiteInfoDetail.RentAmount = (double)reader["RentAmount"];
                    oOutletSiteInfoDetail.AdvancedAmount = (double)reader["AdvancedAmount"];
                    InnerList.Add(oOutletSiteInfoDetail);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshBySiteInfoOther(int nSiteID)
        {
            InnerList.Clear();
            //dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_OutletSiteInfoOther where SiteID=" + nSiteID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletSiteInfoOther oOutletSiteInfoOther = new OutletSiteInfoOther();
                    oOutletSiteInfoOther.ID = (int)reader["ID"];
                    oOutletSiteInfoOther.SiteID = (int)reader["SiteID"];
                    oOutletSiteInfoOther.SignageType = (int)reader["SignageType"];
                    oOutletSiteInfoOther.Size= (string)reader["Size"];
                    oOutletSiteInfoOther.verticalSize = (string)reader["verticalSize"];
                    oOutletSiteInfoOther.CommercialPermission = (string)reader["CommercialPermission"];
                    InnerList.Add(oOutletSiteInfoOther);
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






    