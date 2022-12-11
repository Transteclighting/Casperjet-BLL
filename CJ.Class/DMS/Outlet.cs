// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: July 20, 2011
// Time :  02:00 PM
// Description: Class for DMS Outlet information.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.DMS
{
    public class Outlet
    {
        private int _nOutletID;
        private int _nDistributorID;
        private int _nOutletCode;
        private string _sOutletName;
        private string _sAddress;
        private string _sOwner;
        private string _sContactNo;
        private int _nMarketID;
        private int _nRouteID;
        private int _nOutletCatagory;
        private int _nOutletSubCatagory;
        private double _Balance;
        private int _nIsActive;
         private int _nQty;


        /// <summary>
        /// Get set property for OutletID
        /// </summary>
        public int OutletID
        {
            get { return _nOutletID; }
            set { _nOutletID = value; }
        }

        /// <summary>
        /// Get set property for DistributorID
        /// </summary>
        public int DistributorID
        {
            get { return _nDistributorID; }
            set { _nDistributorID = value; }
        }

        /// <summary>
        /// Get set property for OutletCode
        /// </summary>
        public int OutletCode
        {
            get { return _nOutletCode; }
            set { _nOutletCode = value; }
        }

        /// <summary>
        /// Get set property for OutletName
        /// </summary>
        public string OutletName
        {
            get { return _sOutletName; }
            set { _sOutletName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for Address
        /// </summary>
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value.Trim(); }
        }

        /// <summary>
        /// Get set property for Owner
        /// </summary>
        public string Owner
        {
            get { return _sOwner; }
            set { _sOwner = value.Trim(); }
        }

        /// <summary>
        /// Get set property for ContactNo
        /// </summary>
        public string ContactNo
        {
            get { return _sContactNo; }
            set { _sContactNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for MarketID
        /// </summary>
        public int MarketID
        {
            get { return _nMarketID; }
            set { _nMarketID = value; }
        }

        /// <summary>
        /// Get set property for RouteID
        /// </summary>
        public int RouteID
        {
            get { return _nRouteID; }
            set { _nRouteID = value; }
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

        /// <summary>
        /// Get set property for Balance
        /// </summary>
        public double Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }

        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }
          public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }
        public void Add()
        {
            int nMaxOutletID = 0;
            int nMaxOutletCode = 0;
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

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "SELECT MAX([OutletCode]) FROM t_DMSOutlet";
                cmd.CommandText = sSql;
                object maxCode = cmd.ExecuteScalar();
                if (maxCode == DBNull.Value)
                {
                    nMaxOutletCode= 400001;
                }
                else
                {
                    nMaxOutletCode=(Convert.ToInt32(maxCode) + 1);
                }
                _nOutletCode = nMaxOutletCode;
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();


                sSql = "INSERT INTO t_DMSOutlet VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OutletID", _nOutletID);
                cmd.Parameters.AddWithValue("DistributorID",_nDistributorID);
                cmd.Parameters.AddWithValue("OutletCode", _nOutletCode);
                cmd.Parameters.AddWithValue("OutletName", _sOutletName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("Owner", _sOwner);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("MarketID", _nMarketID);
                cmd.Parameters.AddWithValue("RouteID", null);                
                cmd.Parameters.AddWithValue("Balance", 0);
                cmd.Parameters.AddWithValue("OutletCatagory", _nOutletCatagory);
                cmd.Parameters.AddWithValue("OutletSubCatagory", _nOutletSubCatagory);
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

                sSql = "UPDATE t_DMSOutlet SET OutletCode=?,OutletName=?, Address=?, Owner=?, ContactNo=?, MarketID=?, OutletCatagory=?,OutletSubCatagory=?, IsActive=? WHERE OutletID=? and DistributorID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;               
                cmd.Parameters.AddWithValue("OutletCode", _nOutletCode);
                cmd.Parameters.AddWithValue("OutletName", _sOutletName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("Owner", _sOwner);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("MarketID", _nMarketID);                
                cmd.Parameters.AddWithValue("OutletCatagory", _nOutletCatagory);
                cmd.Parameters.AddWithValue("OutletSubCatagory", _nOutletSubCatagory);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.Parameters.AddWithValue("OutletID", _nOutletID);
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);

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
                sSql = "DELETE FROM t_DMSOutlet WHERE OutletID =? and DistributorID=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OutletID", _nOutletID);
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        public int NextOutletCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([OutletCode]) FROM t_DMSOutlet";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    return 400001;
                }
                else
                {
                    return (Convert.ToInt32(maxID) + 1);
                }
               
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public bool GetOuletID()
        {
            int nCOunt = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DMSOutlet where DistributorID=? and OutletCode=?";
            cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
            cmd.Parameters.AddWithValue("OutletCode", _nOutletCode);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   _nOutletID = (int)reader["OutletID"];
                   nCOunt++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            if (nCOunt != 0) return true;
            else return false;

        }

        public void Refresh()
        {
          
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DMSOutlet where DistributorID=? and OutletID=? and Isactive=1";
            cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
            cmd.Parameters.AddWithValue("OutletID", _nOutletID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {  
                    _nOutletID = (int)reader["OutletID"];
                    _nOutletCode = (int)reader["OutletCode"];
                    _sOutletName = (string)reader["OutletName"];  
                 

                 
                }
                reader.Close();              

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshBy()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DMSOutlet where OutletID=? and Isactive=1";
        
            cmd.Parameters.AddWithValue("OutletID", _nOutletID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nOutletID = (int)reader["OutletID"];
                    _nOutletCode = (int)reader["OutletCode"];
                    _sOutletName = (string)reader["OutletName"];


                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckCode()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT * FROM t_DMSOutlet where OutletCode=? ";
                cmd.Parameters.AddWithValue("OutletCode", _nOutletCode);
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
                return true;
            else return false;
        }
    }
    public class Outlets : CollectionBase
    {

        public Outlet this[int i]
        {
            get { return (Outlet)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public int GetIndexByID(int nOutletID)
        {
            int i = 0;
            foreach (Outlet oOutlet in this)
            {
                if (oOutlet.OutletID == nOutletID)
                    return i;
                i++;
            }
            return -1;
        }


        public void Add(Outlet oOutlet)
        {
            InnerList.Add(oOutlet);
        }

        public void Refresh(int nUserID)
        {         
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DMSOutlet where DistributorID=? ORDER BY OutletCode DESC";
            cmd.Parameters.AddWithValue("DistributorID", nUserID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Outlet oOutlet = new Outlet();

                    oOutlet.OutletID = (int)reader["OutletID"];
                    oOutlet.DistributorID = (int)reader["DistributorID"];
                    oOutlet.OutletCode = (int)reader["OutletCode"];
                    oOutlet.OutletName = (string)reader["OutletName"];
                    oOutlet.Address = (string)reader["Address"];
                    oOutlet.Owner = (string)reader["Owner"];
                    oOutlet.ContactNo = (string)reader["ContactNo"];
                    oOutlet.MarketID = (int)reader["MarketID"];
                    if (reader["RouteID"] != DBNull.Value)
                        oOutlet.RouteID = (int)reader["RouteID"];
                    else oOutlet.RouteID = -1;
                    oOutlet.OutletCatagory = (int)reader["OutletCatagory"];
                    if (reader["OutletSubCatagory"] != DBNull.Value)
                        oOutlet.OutletSubCatagory = (int)reader["OutletSubCatagory"];
                    else oOutlet.OutletSubCatagory = 2;
                    oOutlet.Balance = Convert.ToDouble(reader["Balance"].ToString());
                    oOutlet.IsActive = (int) reader ["IsActive"];

                    InnerList.Add(oOutlet);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshBy(int nOuletCode,string sOutletName,int nUserID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DMSOutlet where DistributorID='" + nUserID + "' and RouteID is not null ";

            if (nOuletCode != -1)
                sSql = sSql + "and OutletCode='" + nOuletCode + "'";

            if (sOutletName != "")
            {
                sOutletName = "%" + sOutletName + "%";
                sSql = sSql + "and OutletName like'" + sOutletName + "'";
            }          

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Outlet oOutlet = new Outlet();

                    oOutlet.OutletID = (int)reader["OutletID"];
                    oOutlet.OutletCode = (int)reader["OutletCode"];
                    oOutlet.OutletName = (string)reader["OutletName"];
                    oOutlet.Address = (string)reader["Address"];
                    oOutlet.Owner = (string)reader["Owner"];
                    oOutlet.ContactNo = (string)reader["ContactNo"];
                    oOutlet.MarketID = (int)reader["MarketID"];
                    if (reader["RouteID"] != DBNull.Value)
                        oOutlet.RouteID = (int)reader["RouteID"];
                    else oOutlet.RouteID = -1;
                    oOutlet.OutletCatagory = (int)reader["OutletCatagory"];
                    if (reader["OutletSubCatagory"] != DBNull.Value)
                        oOutlet.OutletSubCatagory = (int)reader["OutletSubCatagory"];
                    else oOutlet.OutletSubCatagory = 2;
                    oOutlet.Balance = Convert.ToDouble(reader["Balance"].ToString());
                    oOutlet.IsActive = (int) reader ["IsActive"];

                    InnerList.Add(oOutlet);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetOutlet(int nUserID,int nRouteID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DMSOutlet where DistributorID=? and RouteID is null";
            cmd.Parameters.AddWithValue("DistributorID", nUserID);            
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Outlet oOutlet = new Outlet();

                    oOutlet.OutletID = (int)reader["OutletID"];
                    oOutlet.OutletCode = (int)reader["OutletCode"];
                    oOutlet.OutletName = (string)reader["OutletName"];
                    oOutlet.Address = (string)reader["Address"];
                    oOutlet.Owner = (string)reader["Owner"];
                    oOutlet.ContactNo = (string)reader["ContactNo"];
                    oOutlet.MarketID = (int)reader["MarketID"];
                    if (reader["RouteID"] != DBNull.Value)
                        oOutlet.RouteID = (int)reader["RouteID"];
                    else oOutlet.RouteID = -1;
                    oOutlet.OutletCatagory = (int)reader["OutletCatagory"];
                    if (reader["OutletSubCatagory"] != DBNull.Value)
                        oOutlet.OutletSubCatagory = (int)reader["OutletSubCatagory"];
                    else oOutlet.OutletSubCatagory = 2;
                    oOutlet.Balance = Convert.ToDouble(reader["Balance"].ToString());
                    oOutlet.IsActive = (int) reader["IsActive"];

                    InnerList.Add(oOutlet);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetOutletForSales(int nOuletCode, string sOutletName, int nUserID )
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DMSOutlet where DistributorID='" + nUserID + "' and RouteID is not null and IsActive=1";
           // + " in(select distinct routeid from t_dmsjourneyplan where dayno = '" + nDayNo + "' and DistributorID='" + nUserID + "') ";

            if (nOuletCode != -1)
                sSql = sSql + "and OutletCode='" + nOuletCode + "'";

            if (sOutletName != "")
            {
                sOutletName = "%" + sOutletName + "%";
                sSql = sSql + "and OutletName like'" + sOutletName + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Outlet oOutlet = new Outlet();

                    oOutlet.OutletID = (int)reader["OutletID"];
                    oOutlet.OutletCode = (int)reader["OutletCode"];
                    oOutlet.OutletName = (string)reader["OutletName"];
                    oOutlet.Address = (string)reader["Address"];
                    oOutlet.Owner = (string)reader["Owner"];
                    oOutlet.ContactNo = (string)reader["ContactNo"];
                    oOutlet.MarketID = (int)reader["MarketID"];
                    if (reader["RouteID"] != DBNull.Value)
                        oOutlet.RouteID = (int)reader["RouteID"];
                    else oOutlet.RouteID = -1;
                    oOutlet.OutletCatagory = (int)reader["OutletCatagory"];
                    if (reader["OutletSubCatagory"] != DBNull.Value)
                        oOutlet.OutletSubCatagory = (int)reader["OutletSubCatagory"];
                    else oOutlet.OutletSubCatagory = 2;
                    oOutlet.Balance = Convert.ToDouble(reader["Balance"].ToString());
                    oOutlet.IsActive = (int) reader ["IsActive"];

                    InnerList.Add(oOutlet);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void MRefresh(int nDSRID,string WebLinkType)
        {
            Outlet oOutlet;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            if (WebLinkType == "DSR")
            {
                int nDayNo = 0;
                string sDay = DateTime.Today.Date.ToLongDateString();
                char[] splitchar = { ',' };
                string[] sDayArr = sDay.Split(splitchar);

                if (sDayArr[0] == "Saturday")
                {
                    nDayNo = 1;
                }
                if (sDayArr[0] == "Sunday")
                {
                    nDayNo = 2;
                }
                if (sDayArr[0] == "Monday")
                {
                    nDayNo = 3;
                }
                if (sDayArr[0] == "Tuesday")
                {
                    nDayNo = 4;
                }
                if (sDayArr[0] == "Wednesday")
                {
                    nDayNo = 5;
                }
                if (sDayArr[0] == "Thursday")
                {
                    nDayNo = 6;
                }
                if (sDayArr[0] == "Friday")
                {
                    nDayNo = 7;
                }            
           

                 sSql = "select dsrid,a.routeid,dayno,outletid,outletcode,outletname from t_dmsjourneyplan a "
                              + " inner join t_dmsoutlet b "
                              + " on a.distributorid=b.distributorid and a.routeid=b.routeid "
                              + " where dsrid= ? and dayno= ? "
                              + " order by dsrid,a.routeid,dayno,outletid,outletcode,outletname ";

                cmd.Parameters.AddWithValue("dsrid", nDSRID);
                cmd.Parameters.AddWithValue("dayno", nDayNo);
            }
            else
            {              
              

                 sSql = "select a.outletid,outletcode,outletname from t_dmsoutlet a "
                              + " inner join t_DMSMBSOutlet b "
                              + " on a.outletid=b.outletid  "
                              + " where dsrid= ?  ";                          

                cmd.Parameters.AddWithValue("dsrid", nDSRID);
              
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oOutlet = new Outlet();

                    oOutlet.OutletID = (int)reader["OutletID"];                 
                    oOutlet.OutletCode = (int)reader["OutletCode"];
                    oOutlet.OutletName = (string)reader["OutletName"];                   

                    InnerList.Add(oOutlet);
                }
                reader.Close();

                oOutlet = new Outlet();
                oOutlet.OutletID = -1;             
                oOutlet.OutletName = "Select Outlet";
                InnerList.Add(oOutlet);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        /// <summary>
        /// DMS Mobile Version
        /// </summary>
        /// <param name="nMarketId"></param>
        /// <param name="dtTranDate"></param>

        public void MGetOutletWiseSales(int nMarketID, DateTime dtTranDate)
        {

            Outlet oOutlet;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select b.outletcode,b.outletname,sum (qty) as TotalSales "+
                            " from t_dmsmproducttran a inner join t_dmsoutlet b " +
                            " on a.outletid=b.outletid and a.marketid=b.marketid "+
                            " inner join t_dmsmprotrandetail e on e.tranid=a.tranid "+
                            " where trandate=? and a.MarketID = ? "+
                            " group by b.outletcode,b.outletname "; 

            cmd.Parameters.AddWithValue("trandate",dtTranDate);
            cmd.Parameters.AddWithValue("MarketID", nMarketID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oOutlet = new Outlet();
                           
                    oOutlet.OutletCode = (int)reader["OutletCode"];
                    oOutlet.OutletName = (string)reader["OutletName"];                   
                    oOutlet.Qty=(int)reader["TotalSales"];

                    InnerList.Add(oOutlet);
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
