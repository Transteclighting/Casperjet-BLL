// <summary>
// Compamy: Transcom Electronics Limited
// Author: Rifat Farhana- ISA
// Date: Dec 08, 2014
// Time : 04:58 PM
// Description: Class for Market.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;


namespace CJ.Class.DMS
{
    public class ElectricMarket
    {
        private int _nMarketCode;
        private int _nAreaID;
        private int _nTerritoryID;
        private string _sAreaName;
        private string _sTerritoryName;
       
        private string _sMarketName;
        private string _sCustomerCode;
        private string _sCustomerName;
        private int _nStatus;
        private int _nCustomerID;
       
        private int _nOutletID;
        private string _sOutletCode;
        private string _sOutletName;
        private int _nMarketID;
        private int _nRouteID;
        private string _sAddress;
        private string _sOwner;
        private string _sMobile1;
        private string _sMobile2;
        private string _sTelephone;
        private double _nBalance;
        private double _nAgreedSlab;
        private int _nOutletType;
        private int _nOptionID;
        private double _nAgreedValue;        
        private int _nOutletCatagory;
        private int _nOutletSubCatagory;
        private int _nDistrictID;
        private string  _sCategoryName;


        public int DistrictID
        {
            get { return _nDistrictID; }
            set { _nDistrictID = value; }
        }
        public int AreaID
        {
            get { return _nAreaID; }
            set { _nAreaID = value; }
        }
        public int TerritoryID
        {
            get { return _nTerritoryID; }
            set { _nTerritoryID = value; }
        }

        public double Balance
        {
            get { return _nBalance; }
            set { _nBalance = value; }
        }
        
        public int OutletCatagory
        {
            get { return _nOutletCatagory; }
            set { _nOutletCatagory = value; }
        }

        public int OutletSubCatagory
        {
            get { return _nOutletSubCatagory; }
            set { _nOutletSubCatagory = value; }
        }

       
        // <summary>
        // Get set property for MarketCode
        // </summary>
        public int MarketCode
        {
            get { return _nMarketCode; }
            set { _nMarketCode = value; }
        }

        // <summary>
        // Get set property for MarketName
        // </summary>
        public string MarketName
        {
            get { return _sMarketName; }
            set { _sMarketName = value.Trim(); }
        }

        // <summary>
        // Get set property for CustomerCode
        // </summary>
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value.Trim(); }
        }

        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        public int OutletID
        {
            get { return _nOutletID; }
            set { _nOutletID = value; }
        }

        public string OutletCode
        {
            get { return _sOutletCode; }
            set { _sOutletCode = value; }
        }
                

        public string OutletName
        {
            get { return _sOutletName; }
            set { _sOutletName = value; }
        }

        
        public int MarketID
        {
            get { return _nMarketID; }
            set { _nMarketID = value; }
        }

        public int RouteID
        {
            get { return _nRouteID; }
            set { _nRouteID = value; }
        }

        public string Owner
        {
            get { return _sOwner; }
            set { _sOwner = value; }
        }

        public string Mobile1
        {
            get { return _sMobile1; }
            set { _sMobile1 = value; }
        }

        public string Mobile2
        {
            get { return _sMobile2; }
            set { _sMobile2 = value; }
        }

        public string Telephone
        {
            get { return _sTelephone; }
            set { _sTelephone = value; }
        }

        public double AgreedSlab
        {
            get { return _nAgreedSlab; }
            set { _nAgreedSlab = value; }
        }

        public int OutletType
        {
            get { return _nOutletType; }
            set { _nOutletType = value; }
        }

        public int OptionID
        {
            get { return _nOptionID; }
            set { _nOptionID = value; }
        }

        public double AgreedValue
        {
            get { return _nAgreedValue; }
            set { _nAgreedValue = value; }
        }

        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value; }
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
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }
        public string CategoryName
        {
            get { return _sCategoryName; }
            set { _sCategoryName = value.Trim(); }
        }

        public void Add()
        {
            int nMaxMarketCode = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([MarketCode]) FROM t_Market";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxMarketCode = 1;
                }
                else
                {
                    nMaxMarketCode = Convert.ToInt32(maxID) + 1;
                }
                _nMarketCode = nMaxMarketCode;
                sSql = "INSERT INTO t_Market (MarketCode, MarketName, CustomerCode, Status) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("MarketCode", _nMarketCode);
                cmd.Parameters.AddWithValue("MarketName", _sMarketName);
                cmd.Parameters.AddWithValue("CustomerCode", _sCustomerCode);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddOutlet()
        {
            int nOutletID = 0;
            string sOutletCode;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([OutletID]) FROM t_DMSOutlet ";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nOutletID = 1;
                }
                else
                {
                    nOutletID = Convert.ToInt32(maxID) + 1;
                }
                _nOutletID = nOutletID;
                sOutletCode = _sOutletCode + _nOutletID.ToString();
                sSql = "INSERT INTO t_DMSOutlet ( OutletID,DistributorID,OutletCode,OutletName,Address,Owner, ContactNo,MobileNo1,Mobile2,MarketID,RouteID,Balance,OutletCatagory,OutletSubCatagory, AgreedSlab,OptionID,AgreedValue,Isactive) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("OutletID", _nOutletID);
                cmd.Parameters.AddWithValue("DistributorID", _nCustomerID);
                cmd.Parameters.AddWithValue("OutletCode", sOutletCode);
                cmd.Parameters.AddWithValue("OutletName", _sOutletName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("Owner",_sOwner );

                cmd.Parameters.AddWithValue("ContactNo", _sTelephone);
                cmd.Parameters.AddWithValue("MobileNo1", _sMobile1);
                cmd.Parameters.AddWithValue("Mobile2", _sMobile2);

                cmd.Parameters.AddWithValue("MarketID", _nMarketID);
                cmd.Parameters.AddWithValue("RouteID", 0);
                cmd.Parameters.AddWithValue("Balance", 0);
                cmd.Parameters.AddWithValue("OutletCatagory", _nOutletCatagory);
                cmd.Parameters.AddWithValue("OutletSubCatagory", _nOutletSubCatagory);
                cmd.Parameters.AddWithValue("AgreedSlab", _nAgreedSlab);
                cmd.Parameters.AddWithValue("OptionID", _nOptionID);

                cmd.Parameters.AddWithValue("AgreedValue", _nAgreedValue);
                cmd.Parameters.AddWithValue("Isactive", 1 );
                           
                


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
                sSql = "UPDATE t_DMSMarket SET MarketName = ?, CustomerCode = ?, Status = ? WHERE MarketCode = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("MarketName", _sMarketName);
                cmd.Parameters.AddWithValue("CustomerCode", _sCustomerCode);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("MarketCode", _nMarketCode);

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
                sSql = "DELETE FROM t_DMSMarket WHERE [MarketCode]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("MarketCode", _nMarketCode);
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
                cmd.CommandText = "SELECT * FROM t_DMSMarket where MarketCode =?";
                cmd.Parameters.AddWithValue("MarketCode", _nMarketCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nMarketCode = (int)reader["MarketCode"];
                    _sMarketName = (string)reader["MarketName"];
                    _sCustomerCode = (string)reader["CustomerCode"];
                    _nStatus = (int)reader["Status"];
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
    public class ElectricMarkets : CollectionBase
    {
        public Market this[int i]
        {
            get { return (Market)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(Market oMarket)
        {
            InnerList.Add(oMarket);
        }
        public int GetIndex(int nMarketCode)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].MarketCode == nMarketCode)
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
            string sSql = "SELECT * FROM t_DMSMarket";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ElectricMarket oMarket = new ElectricMarket();
                    oMarket.MarketCode = (int)reader["MarketCode"];
                    oMarket.MarketName = (string)reader["MarketName"];
                    oMarket.CustomerCode = (string)reader["CustomerCode"];
                    oMarket.Status = (int)reader["Status"];
                    InnerList.Add(oMarket);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshAll(int nCustomerID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DMSMarket where MarketTypeID=2 and DistributorID=" + nCustomerID + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ElectricMarket oMarket = new ElectricMarket();
                    oMarket.MarketID =Convert.ToInt32(reader["MarketID"]);
                    oMarket.MarketCode = (int)reader["MarketCode"];
                    oMarket.MarketName = (string)reader["MarketName"];
                    oMarket.CustomerID = (int)reader["DistributorID"];                    
                    InnerList.Add(oMarket);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshOutlet(int nAreaID, int nTerritoryID, int nCustomerID,int nDistrictID,int nMarketID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = @"" ;
            if (nAreaID != -1)
            {
                sSql = sSql + " where areaid = " + nAreaID + "";

            }
            if (nTerritoryID != -1)
            {
                sSql = sSql + " and territoryid = " + nTerritoryID + "";

            }
            if (nCustomerID != -1)
            {
                sSql = sSql + " and CustomerID = " + nAreaID + "";

            }
            if (nMarketID != -1)
            {
                sSql = sSql + " and marketid = " + nTerritoryID + "";

            }
            if (nDistrictID != -1)
            {
                sSql = sSql + " and districtid = " + nTerritoryID + "";

            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ElectricMarket oMarket = new ElectricMarket();
                    oMarket.AreaID = Convert.ToInt32(reader["AreaID"]);
                    oMarket.AreaName = (string)reader["AreaName"];
                    oMarket.TerritoryID = Convert.ToInt32(reader["TerritoryID"]);
                    oMarket.TerritoryName = (string)reader["TerritoryName"];
                    oMarket.CustomerID = (int)reader["CustomerID"];
                    oMarket.CustomerName = (string)reader["CustomerName"];
                    oMarket.OutletID = Convert.ToInt32(reader["OutletID"]);
                    oMarket.OutletCode = (string)reader["OutletCode"];
                    oMarket.OutletName = (string)reader["OutletName"];
                    oMarket.DistrictID = Convert.ToInt32(reader["DistrictID"]);
                   
                    oMarket.MarketID = Convert.ToInt32(reader["MarketID"]);
                    
                    oMarket.MarketName = (string)reader["MarketName"];
                    oMarket.CategoryName = (string)reader["CategoryName"];
                    
                    InnerList.Add(oMarket);
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
