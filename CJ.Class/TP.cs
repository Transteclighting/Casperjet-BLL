 // <summary>
// Compamy: Transcom Electronics Limited
// Author: Rifat Farhana
// Date: July 13, 2014
// Time :  10:00 AM
// Description: Class for TP Information.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class
{
    public class TP
    {
        private int _nOutletID;
        private int _nOutletCode;
        private int _nDistributorID;
        private int _nRouteID;
        private string _sOutletName;
        private string _sAdress;
        private string _sContact;
        private string _sTargetSlab;
        private int _nOutletTypeID;
        private int _nIsActive;
        private DateTime _dLastUpdate;

        private int _nUserID;

        /// <summary>
        /// Get set property for OutletID
        /// </summary>
        public int OutletID
        {
        get { return _nOutletID; }
        set { _nOutletID = value; }
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
        /// Get set property for DistributorID
        /// </summary>
        public int DistributorID
        {
        get { return _nDistributorID; }
        set { _nDistributorID = value; }
        }
        /// <summary>
        /// Get set property for RouteID
        /// </summary>
        public int RouteID
        {
        get { return _nRouteID; }
        set { _nRouteID = value; }
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
        /// Get set property for Adress
        /// </summary>
        public string Adress
        {
        get { return _sAdress; }
        set { _sAdress = value.Trim(); }
        }
        public string Contact
        {
        get { return _sContact; }
        set { _sContact = value.Trim(); }
        }
        public string TargetSlab
        {
        get { return _sTargetSlab; }
        set { _sTargetSlab = value.Trim(); }
        }
        public int OutletTypeID
        {
            get { return _nOutletTypeID; }
            set { _nOutletTypeID = value; }
        }
        public int IsActive
        {
        get { return _nIsActive; }
        set { _nIsActive = value; }
        }

        public DateTime LastUpdate
        {
        get { return _dLastUpdate; }
        set { _dLastUpdate = value; }

        }
        public int UserID
        {
        get { return _nUserID; }
        set { _nUserID = value; }
        }
        public void Add()
        {
            int nMaxOutletID = 0;
            int nMaxOutletCode = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([OutletID]) FROM [TELAddDB].[dbo].[t_CampaignOutlet]";
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

        sSql = "SELECT MAX([OutletCode]) FROM [TELAddDB].[dbo].[t_CampaignOutlet]";
        cmd.CommandText = sSql;
        object maxCode = cmd.ExecuteScalar();
        if (maxCode == DBNull.Value)
        {
            nMaxOutletCode = 400001;
        }
        else
        {
            nMaxOutletCode = (Convert.ToInt32(maxCode) + 1);
        }
        _nOutletCode = nMaxOutletCode;
        cmd.Dispose();
        cmd = DBController.Instance.GetCommand();


        sSql = "INSERT INTO [TELAddDB].[dbo].[t_CampaignOutlet] VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
        cmd.CommandText = sSql;
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("OutletID", _nOutletID);
        cmd.Parameters.AddWithValue("OutletCode", _nOutletCode);
        cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
        cmd.Parameters.AddWithValue("RouteID", _nRouteID);
        cmd.Parameters.AddWithValue("OutletName", _sOutletName);
        cmd.Parameters.AddWithValue("Address", _sAdress);
        cmd.Parameters.AddWithValue("Contact", _sContact);
        cmd.Parameters.AddWithValue("TargetSlab", _sTargetSlab);
        cmd.Parameters.AddWithValue("OutletTypeID", _nOutletTypeID);
        cmd.Parameters.AddWithValue("IsActive", _nIsActive);
        cmd.Parameters.AddWithValue("LastUpdate", _dLastUpdate);
        cmd.Parameters.AddWithValue("UserID", _nUserID);





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

                sSql = "Update [TELAddDB].[dbo].[t_CampaignOutlet] Set DistributorID=?,RouteID=?,OutletName=?,Address=?,Contact=?,TargetSlab=?,CampaignID=?,IsActive=?,LastUpdate=?,UserID=? "
                               + " Where OutletID =? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.Parameters.AddWithValue("RouteID", _nRouteID);
                cmd.Parameters.AddWithValue("OutletName", _sOutletName);
                cmd.Parameters.AddWithValue("Address", _sAdress);
                cmd.Parameters.AddWithValue("Contact", _sContact);
                cmd.Parameters.AddWithValue("TargetSlab", _sTargetSlab);
                cmd.Parameters.AddWithValue("OutletTypeID", _nOutletTypeID);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("LastUpdate", _dLastUpdate);
                cmd.Parameters.AddWithValue("UserID", _nUserID);

                cmd.Parameters.AddWithValue("OutletID", _nOutletID);
              
                

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

         
        }

}
    public class TPS : CollectionBase
    {

        public TP this[int i]
        {
            get { return (TP)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public int GetIndexByID(int nOutletID)
        {
            int i = 0;
            foreach (TP oTP in this)
            {
                if (oTP.OutletID == nOutletID)
                    return i;
                i++;
            }
            return -1;
        }
        public void Add(TP oTP)
        {
            InnerList.Add(oTP);
        }
        public bool  GetContact(string sContact)
        {
            TP oTP;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select COUNT(Contact) from [TELAddDB].[dbo].[t_CampaignOutlet] where Contact= ? ";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Contact", sContact);
                string getValue = cmd.ExecuteScalar().ToString();
                if (getValue != "0")
                {
                    return true;
                }
                else
                {
                    return false;
                }

                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
