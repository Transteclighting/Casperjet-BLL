// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Oct 03, 2012
// Time :  04:24 PM
// Description: Class for Spare Parts Location.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

using CJ.Class.CSD;
using CJ.Class;

namespace CJ.Class
{
    public class SparePartLocation
    {
        private int _nSPLocationID;
        private string _sLocationName;
        private string _sDescription;
        private int _nIsActive;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;

        private User _oUser;
        public User User
        {
            get
            {
                if (_oUser == null)
                {
                    _oUser = new User();
                    User.UserId = _nCreateUserID;
                    User.RefreshByUserID();
                }
                return _oUser;
            }
        }
       

        /// <summary>
        /// Get set property for SPLocationID
        /// </summary>
        public int SPLocationID
        {
            get { return _nSPLocationID; }
            set { _nSPLocationID = value; }
        }
        /// <summary>
        /// Get set property for LocationName
        /// </summary>
        public string LocationName
        {
            get { return _sLocationName; }
            set { _sLocationName = value; }
            //set { _sGeoLocationName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for Description
        /// </summary>
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value; }
            //set { _sGeoLocationName = value.Trim(); }
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
        /// Get set property for CreateUserID
        /// </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
            //set { _sGeoLocationName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for CreateDate
        /// </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }

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
        /// Get set property for UpdateDate
        /// </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }

        }

        public void Add()
        {
            int nMaxSPLocationID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([SPLocationID]) FROM t_CSDSPLocation";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSPLocationID = 1;
                }
                else
                {
                    nMaxSPLocationID = Convert.ToInt32(maxID) + 1;
                }
                _nSPLocationID = nMaxSPLocationID;


                sSql = "INSERT INTO t_CSDSPLocation(SPLocationID,LocationName, Description, IsActive, CreateUserID,CreateDate) VALUES(?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SPLocationID", _nSPLocationID);
                cmd.Parameters.AddWithValue("LocationName", _sLocationName);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);


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

                cmd.CommandText = "UPDATE t_CSDSPLocation SET LocationName=?,Description=?, IsActive=?, UpdateUserID=?,UpdateDate=? Where SPLocationID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LocationName", _sLocationName);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                cmd.Parameters.AddWithValue("SPLocationID", _nSPLocationID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckLocationName()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDSPLocation where LocationName=? ";
            cmd.Parameters.AddWithValue("LocationName", _sLocationName);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //_dStatusDate = Convert.ToDateTime(reader["StatusDate"].ToString());
                    //_nStatus = int.Parse(reader["Status"].ToString());
                    //_sRemarks = (string)reader["Remarks"];
                    //_nUserID = (int)reader["UserID"];
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

        public void RefreshBySPLocationID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "SELECT * FROM t_CSDSPLocation Where SPLocationID=?";
                cmd.Parameters.AddWithValue("SPLocationID", _nSPLocationID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sLocationName = (string)reader["LocationName"];

                }

                reader.Close();
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
                cmd.CommandText = "SELECT * FROM t_CSDSPLocation Where SPLocationID=?";
                cmd.Parameters.AddWithValue("SPLocationID", _nSPLocationID); ;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nSPLocationID = (int)reader["SPLocationID"];
                    _sLocationName = (string)reader["LocationName"];

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
    public class SparePartLocations : CollectionBase
    {

        public SparePartLocation this[int i]
        {
            get { return (SparePartLocation)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SparePartLocation oSparePartLocation)
        {
            InnerList.Add(oSparePartLocation);
        }
        public int GetIndex(int nSPLocationID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].SPLocationID == nSPLocationID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Refresh(String txtLocationName, String txtDescription)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_CSDSPLocation Where SPLocationID <>0";

            if (txtLocationName != "")
            {
                txtLocationName = "%" + txtLocationName + "%";
                sSql = sSql + " and LocationName LIKE '" + txtLocationName + "'";
            }
            if (txtDescription != "")
            {
                txtDescription = "%" + txtDescription + "%";
                sSql = sSql + " and Description LIKE '" + txtDescription + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SparePartLocation oSparePartLocation = new SparePartLocation();

                    oSparePartLocation.SPLocationID = (int)reader["SPLocationID"];
                    oSparePartLocation.LocationName = (string)reader["LocationName"];
                    oSparePartLocation.Description = (string)reader["Description"];
                    oSparePartLocation.IsActive = int.Parse(reader["IsActive"].ToString());
                    oSparePartLocation.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oSparePartLocation.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    InnerList.Add(oSparePartLocation);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshForCombo()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            SparePartLocation _oSparePartLocation;
            string sSql = "Select * from t_CSDSPLocation";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _oSparePartLocation = new SparePartLocation();

                    _oSparePartLocation.SPLocationID = (int)reader["SPLocationID"];
                    _oSparePartLocation.LocationName = (string)reader["LocationName"];

                    InnerList.Add(_oSparePartLocation);
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
