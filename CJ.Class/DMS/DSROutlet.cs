// <summary>
// Compamy: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Aug 12, 2015
// Time : 11:51 AM
// Description: Class for DMSOutlet.
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
    public class DMSOutlet
    {
        private int _nOutletID;
        private int _nDistributorID;
        private string _sOutletCode;
        private string _sOutletName;
        private string _sAddress;
        private string _sOwner;
        private string _sContactNo;
        private string _sMobileNo1;
        private string _sMobile2;
        private int _nMarketID;
        private int _nRouteID;
        private int _nDistrictID;
        private double _Balance;
        private string _sOutletCatagory;
        private int _nOutletSubCatagory;
        private int _nAgreedSlab;
        private int _nOptionID;
        private double _AgreedValue;
        private int _nIsActive;


        // <summary>
        // Get set property for OutletID
        // </summary>
        public int OutletID
        {
            get { return _nOutletID; }
            set { _nOutletID = value; }
        }

        // <summary>
        // Get set property for DistributorID
        // </summary>
        public int DistributorID
        {
            get { return _nDistributorID; }
            set { _nDistributorID = value; }
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
        // Get set property for OutletName
        // </summary>
        public string OutletName
        {
            get { return _sOutletName; }
            set { _sOutletName = value.Trim(); }
        }

        // <summary>
        // Get set property for Address
        // </summary>
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value.Trim(); }
        }

        // <summary>
        // Get set property for Owner
        // </summary>
        public string Owner
        {
            get { return _sOwner; }
            set { _sOwner = value.Trim(); }
        }

        // <summary>
        // Get set property for ContactNo
        // </summary>
        public string ContactNo
        {
            get { return _sContactNo; }
            set { _sContactNo = value.Trim(); }
        }

        // <summary>
        // Get set property for MobileNo1
        // </summary>
        public string MobileNo1
        {
            get { return _sMobileNo1; }
            set { _sMobileNo1 = value.Trim(); }
        }

        // <summary>
        // Get set property for Mobile2
        // </summary>
        public string Mobile2
        {
            get { return _sMobile2; }
            set { _sMobile2 = value.Trim(); }
        }

        // <summary>
        // Get set property for MarketID
        // </summary>
        public int MarketID
        {
            get { return _nMarketID; }
            set { _nMarketID = value; }
        }

        // <summary>
        // Get set property for RouteID
        // </summary>
        public int RouteID
        {
            get { return _nRouteID; }
            set { _nRouteID = value; }
        }

        // <summary>
        // Get set property for DistrictID
        // </summary>
        public int DistrictID
        {
            get { return _nDistrictID; }
            set { _nDistrictID = value; }
        }

        // <summary>
        // Get set property for Balance
        // </summary>
        public double Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }

        // <summary>
        // Get set property for OutletCatagory
        // </summary>
        public string OutletCatagory
        {
            get { return _sOutletCatagory; }
            set { _sOutletCatagory = value.Trim(); }
        }

        // <summary>
        // Get set property for OutletSubCatagory
        // </summary>
        public int OutletSubCatagory
        {
            get { return _nOutletSubCatagory; }
            set { _nOutletSubCatagory = value; }
        }

        // <summary>
        // Get set property for AgreedSlab
        // </summary>
        public int AgreedSlab
        {
            get { return _nAgreedSlab; }
            set { _nAgreedSlab = value; }
        }

        // <summary>
        // Get set property for OptionID
        // </summary>
        public int OptionID
        {
            get { return _nOptionID; }
            set { _nOptionID = value; }
        }

        // <summary>
        // Get set property for AgreedValue
        // </summary>
        public double AgreedValue
        {
            get { return _AgreedValue; }
            set { _AgreedValue = value; }
        }

        // <summary>
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }

        public void Add()
        {
            int nMaxOutletID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([OutletID]) FROM t_DMSOutlet";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxOutletID = 1;
                }
                else
                {
                    nMaxOutletID = Convert.ToInt32(maxID) + 1;
                }
                _nOutletID = nMaxOutletID;
                sSql = "INSERT INTO t_DMSOutlet (OutletID, DistributorID, OutletCode, OutletName, Address, Owner, ContactNo, MobileNo1, Mobile2, MarketID, RouteID, DistrictID, Balance, OutletCatagory, OutletSubCatagory, AgreedSlab, OptionID, AgreedValue, IsActive) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OutletID", _nOutletID);
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.Parameters.AddWithValue("OutletCode", _sOutletCode);
                cmd.Parameters.AddWithValue("OutletName", _sOutletName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("Owner", _sOwner);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("MobileNo1", _sMobileNo1);
                cmd.Parameters.AddWithValue("Mobile2", _sMobile2);
                cmd.Parameters.AddWithValue("MarketID", _nMarketID);
                cmd.Parameters.AddWithValue("RouteID", _nRouteID);
                cmd.Parameters.AddWithValue("DistrictID", _nDistrictID);
                cmd.Parameters.AddWithValue("Balance", _Balance);
                cmd.Parameters.AddWithValue("OutletCatagory", _sOutletCatagory);
                cmd.Parameters.AddWithValue("OutletSubCatagory", _nOutletSubCatagory);
                cmd.Parameters.AddWithValue("AgreedSlab", _nAgreedSlab);
                cmd.Parameters.AddWithValue("OptionID", _nOptionID);
                cmd.Parameters.AddWithValue("AgreedValue", _AgreedValue);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

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
                sSql = "UPDATE t_DMSOutlet SET DistributorID = ?, OutletCode = ?, OutletName = ?, Address = ?, Owner = ?, ContactNo = ?, MobileNo1 = ?, Mobile2 = ?, MarketID = ?, RouteID = ?, DistrictID = ?, Balance = ?, OutletCatagory = ?, OutletSubCatagory = ?, AgreedSlab = ?, OptionID = ?, AgreedValue = ?, IsActive = ? WHERE OutletID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.Parameters.AddWithValue("OutletCode", _sOutletCode);
                cmd.Parameters.AddWithValue("OutletName", _sOutletName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("Owner", _sOwner);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("MobileNo1", _sMobileNo1);
                cmd.Parameters.AddWithValue("Mobile2", _sMobile2);
                cmd.Parameters.AddWithValue("MarketID", _nMarketID);
                cmd.Parameters.AddWithValue("RouteID", _nRouteID);
                cmd.Parameters.AddWithValue("DistrictID", _nDistrictID);
                cmd.Parameters.AddWithValue("Balance", _Balance);
                cmd.Parameters.AddWithValue("OutletCatagory", _sOutletCatagory);
                cmd.Parameters.AddWithValue("OutletSubCatagory", _nOutletSubCatagory);
                cmd.Parameters.AddWithValue("AgreedSlab", _nAgreedSlab);
                cmd.Parameters.AddWithValue("OptionID", _nOptionID);
                cmd.Parameters.AddWithValue("AgreedValue", _AgreedValue);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.Parameters.AddWithValue("OutletID", _nOutletID);

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
                sSql = "DELETE FROM t_DMSOutlet WHERE [OutletID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OutletID", _nOutletID);
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
                cmd.CommandText = "SELECT * FROM t_DMSOutlet where OutletID =?";
                cmd.Parameters.AddWithValue("OutletID", _nOutletID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nOutletID = (int)reader["OutletID"];
                    _nDistributorID = (int)reader["DistributorID"];
                    _sOutletCode = (string)reader["OutletCode"];
                    _sOutletName = (string)reader["OutletName"];
                    _sAddress = (string)reader["Address"];
                    _sOwner = (string)reader["Owner"];
                    _sContactNo = (string)reader["ContactNo"];
                    _sMobileNo1 = (string)reader["MobileNo1"];
                    _sMobile2 = (string)reader["Mobile2"];
                    _nMarketID = (int)reader["MarketID"];
                    _nRouteID = (int)reader["RouteID"];
                    _nDistrictID = (int)reader["DistrictID"];
                    _Balance = Convert.ToDouble(reader["Balance"].ToString());
                    _sOutletCatagory = (string)reader["OutletCatagory"];
                    _nOutletSubCatagory = (int)reader["OutletSubCatagory"];
                    _nAgreedSlab = (int)reader["AgreedSlab"];
                    _nOptionID = (int)reader["OptionID"];
                    _AgreedValue = Convert.ToDouble(reader["AgreedValue"].ToString());
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
    }
    public class DMSOutlets : CollectionBase
    {
        public DMSOutlet this[int i]
        {
            get { return (DMSOutlet)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DMSOutlet oDMSOutlet)
        {
            InnerList.Add(oDMSOutlet);
        }
        public int GetIndex(int nOutletID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].OutletID == nOutletID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(int nCustomerId)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from t_dmsoutlet where Isactive =1 and distributorid= ?";
            cmd.Parameters.AddWithValue("DistributorID", nCustomerId);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSOutlet oDMSOutlet = new DMSOutlet();
                    //oDMSOutlet.OutletID = (int)reader["OutletID"];
                    //oDMSOutlet.DistributorID = (int)reader["DistributorID"];
                    //oDMSOutlet.OutletCode = (string)reader["OutletCode"];
                    oDMSOutlet.OutletName = (string)reader["OutletName"];
                    //oDMSOutlet.Address = (string)reader["Address"];
                    //oDMSOutlet.Owner = (string)reader["Owner"];
                    //oDMSOutlet.ContactNo = (string)reader["ContactNo"];
                    //oDMSOutlet.MobileNo1 = (string)reader["MobileNo1"];
                    //oDMSOutlet.Mobile2 = (string)reader["Mobile2"];
                    //oDMSOutlet.MarketID = (int)reader["MarketID"];
                    //oDMSOutlet.RouteID = (int)reader["RouteID"];
                    //oDMSOutlet.DistrictID = (int)reader["DistrictID"];
                    //oDMSOutlet.Balance = Convert.ToDouble(reader["Balance"].ToString());
                    //oDMSOutlet.OutletCatagory = (string)reader["OutletCatagory"];
                    //oDMSOutlet.OutletSubCatagory = (int)reader["OutletSubCatagory"];
                    //oDMSOutlet.AgreedSlab = (int)reader["AgreedSlab"];
                    //oDMSOutlet.OptionID = (int)reader["OptionID"];
                    //oDMSOutlet.AgreedValue = Convert.ToDouble(reader["AgreedValue"].ToString());
                    //oDMSOutlet.IsActive = (int)reader["IsActive"];
                    InnerList.Add(oDMSOutlet);
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


