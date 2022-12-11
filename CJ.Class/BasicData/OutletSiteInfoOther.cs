// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Nov 24, 2019
// Time : 12:43 PM
// Description: Class for OutletSiteInfoOther.
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
    public class OutletSiteInfoOther
    {
        private int _nID;
        private int _nSiteID;
        private int _nSignageType;
        private string _sSize;
        private string _sverticalSize;
        private string _sCommercialPermission;


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
        // Get set property for SignageType
        // </summary>
        public int SignageType
        {
            get { return _nSignageType; }
            set { _nSignageType = value; }
        }

        // <summary>
        // Get set property for Size
        // </summary>
        public string Size
        {
            get { return _sSize; }
            set { _sSize = value.Trim(); }
        }
        public string CommercialPermission
        {
            get { return _sCommercialPermission; }
            set { _sCommercialPermission = value.Trim(); }
        }

        // <summary>
        // Get set property for verticalSize
        // </summary>
        public string verticalSize
        {
            get { return _sverticalSize; }
            set { _sverticalSize = value.Trim(); }
        }

        public void Add(int _nSiteID)
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_OutletSiteInfoOther";
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
                sSql = "INSERT INTO t_OutletSiteInfoOther (ID, SiteID, SignageType, Size, verticalSize,CommercialPermission) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("SiteID", _nSiteID);
                cmd.Parameters.AddWithValue("SignageType", _nSignageType);
                cmd.Parameters.AddWithValue("Size", _sSize);
                cmd.Parameters.AddWithValue("verticalSize", _sverticalSize);
                cmd.Parameters.AddWithValue("CommercialPermission", _sCommercialPermission);

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
                sSql = "UPDATE t_OutletSiteInfoOther SET SiteID = ?, SignageType = ?, Size = ?, verticalSize = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SiteID", _nSiteID);
                cmd.Parameters.AddWithValue("SignageType", _nSignageType);
                cmd.Parameters.AddWithValue("Size", _sSize);
                cmd.Parameters.AddWithValue("verticalSize", _sverticalSize);

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
                sSql = "DELETE FROM t_OutletSiteInfoOther WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_OutletSiteInfoOther where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nSiteID = (int)reader["SiteID"];
                    _nSignageType = (int)reader["SignageType"];
                    _sSize = (string)reader["Size"];
                    _sverticalSize = (string)reader["verticalSize"];
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
    public class OutletSiteInfoOthers : CollectionBase
    {
        public OutletSiteInfoOther this[int i]
        {
            get { return (OutletSiteInfoOther)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(OutletSiteInfoOther oOutletSiteInfoOther)
        {
            InnerList.Add(oOutletSiteInfoOther);
        }
        public int GetIndex(int nID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ID == nID)
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
            string sSql = "SELECT * FROM t_OutletSiteInfoOther";
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
                    oOutletSiteInfoOther.Size = (string)reader["Size"];
                    oOutletSiteInfoOther.verticalSize = (string)reader["verticalSize"];
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

