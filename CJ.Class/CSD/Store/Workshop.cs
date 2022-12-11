// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Sep 20, 2012
// Time :  40:00 PM
// Description: Class for Workshop & Workshop Location.
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
    public class Workshop
    {
        private int _nWorkshopTypeID;
        private string _sName;
        private int _nIsActive;
        private int _nCreateUserID; 
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;

        /// <summary>
        /// Get set property for WorkshopTypeID
        /// </summary>
        public int WorkshopTypeID
        {
            get { return _nWorkshopTypeID; }
            set { _nWorkshopTypeID = value; }
        }
        /// <summary>
        /// Get set property for Name
        /// </summary>
        public string Name
        {
            get { return _sName; }
            set { _sName = value; }
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

        public void Add()
        {
            int nMaxWorkshopTypeID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([WorkshopTypeID]) FROM t_CSDWorkshopType";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxWorkshopTypeID = 1;
                }
                else
                {
                    nMaxWorkshopTypeID = Convert.ToInt32(maxID) + 1;
                }
                _nWorkshopTypeID = nMaxWorkshopTypeID;


                sSql = "INSERT INTO t_CSDWorkshopType(WorkshopTypeID,Name,IsActive,CreateUserID,CreateDate) VALUES(?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WorkshopTypeID", _nWorkshopTypeID);
                cmd.Parameters.AddWithValue("Name", _sName);
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

                cmd.CommandText = "UPDATE t_CSDWorkshopType SET Name=?,IsActive=?,UpdateUserID=?,UpdateDate=? Where WorkshopTypeID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                cmd.Parameters.AddWithValue("WorkshopTypeID", _nWorkshopTypeID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckWorkshop()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDWorkshopType where Name=? AND IsActive=?";
            cmd.Parameters.AddWithValue("Name", _sName);
            cmd.Parameters.AddWithValue("IsActive", _nIsActive);

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
                return true;
            else return false;
        }
        public void RefreshByID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * from t_CSDWorkshopType Where WorkshopTypeID=? ";
                cmd.Parameters.AddWithValue("WorkshopTypeID",_nWorkshopTypeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nWorkshopTypeID = (int)reader["WorkshopTypeID"];
                    _sName = (string)reader["Name"];

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
    public class Workshops : CollectionBase
    {
        public Workshop this[int i]
        {
            get { return (Workshop)InnerList[i]; }
            set { InnerList[i] = value; }
        }


        public void Add(Workshop oWorkshop)
        {
            InnerList.Add(oWorkshop);
        }
        public int GetIndex(int nWorkshopTypeID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].WorkshopTypeID == nWorkshopTypeID)
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

            string sSql = "Select * from t_CSDWorkshopType Where WorkshopTypeID <>0 ";

          
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Workshop oWorkshop = new Workshop();

                    oWorkshop.WorkshopTypeID = (int)reader["WorkshopTypeID"];
                    oWorkshop.Name=(string)reader["Name"];
                    oWorkshop.IsActive = (int)reader["IsActive"];
                    oWorkshop.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oWorkshop.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());


                    InnerList.Add(oWorkshop);
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
            Workshop _oWorkshop;
            string sSql = "Select * from t_CSDWorkshopType";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _oWorkshop = new Workshop();

                    _oWorkshop.WorkshopTypeID = (int)reader["WorkshopTypeID"];
                    _oWorkshop.Name = (string)reader["Name"];

                    InnerList.Add(_oWorkshop);
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

    public class WorkshopLocation
    {

        private int _nWorkshopLocationID;
        private string _sName;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;

        /// <summary>
        /// Get set property for WorkshopLocationID
        /// </summary>
        public int WorkshopLocationID
        {
            get { return _nWorkshopLocationID; }
            set { _nWorkshopLocationID = value; }
        }
        /// <summary>
        /// Get set property for Name
        /// </summary>
        public string Name
        {
            get { return _sName; }
            set { _sName = value; }
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
       

        public void Add()
        {
            int nMaxWorkshopLocationID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([WorkshopLocationID]) FROM t_CSDWorkshopLocation";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxWorkshopLocationID = 1;
                }
                else
                {
                    nMaxWorkshopLocationID = Convert.ToInt32(maxID) + 1;
                }
                _nWorkshopLocationID = nMaxWorkshopLocationID;


                sSql = "INSERT INTO t_CSDWorkshopLocation(WorkshopLocationID,Name,CreateUserID,CreateDate) VALUES(?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WorkshopLocationID", _nWorkshopLocationID);
                cmd.Parameters.AddWithValue("Name", _sName);
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

                cmd.CommandText = "UPDATE t_CSDWorkshopLocation SET Name=?, UpdateUserID=?, UpdateDate=? Where WorkshopLocationID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                cmd.Parameters.AddWithValue("WorkshopLocationID", _nWorkshopLocationID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByWSLocationID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_CSDWorkshopLocation Where WorkshopLocationID=?";
                cmd.Parameters.AddWithValue("WorkshopLocationID", _nWorkshopLocationID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nWorkshopLocationID = (int)reader["WorkshopLocationID"];
                  _sName = (string)reader["Name"];

                  nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
       
        public bool CheckWSLocationName()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDWorkshopLocation where Name=? ";
            cmd.Parameters.AddWithValue("Name", _sName);

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
                return true;
            else return false;
        }
    }
    public class WorkshopLocations : CollectionBase
    {
        public WorkshopLocation this[int i]
        {
            get { return (WorkshopLocation)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public int GetIndex(int nWSLocationID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].WorkshopLocationID == nWSLocationID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Add(WorkshopLocation oWorkshopLocation)
        {
            InnerList.Add(oWorkshopLocation);
        }
        public void Refresh()
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_CSDWorkshopLocation Where WorkshopLocationID <>0 ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    WorkshopLocation oWorkshopLocation = new WorkshopLocation();

                    oWorkshopLocation.WorkshopLocationID = (int)reader["WorkshopLocationID"];
                    oWorkshopLocation.Name = (string)reader["Name"];
                    oWorkshopLocation.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oWorkshopLocation.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());


                    InnerList.Add(oWorkshopLocation);
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
            WorkshopLocation _oWorkshopLocation;
            string sSql = "Select * from t_CSDWorkshopLocation";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _oWorkshopLocation = new WorkshopLocation();

                    _oWorkshopLocation.WorkshopLocationID = (int)reader["WorkshopLocationID"];
                    _oWorkshopLocation.Name = (string)reader["Name"];

                    InnerList.Add(_oWorkshopLocation);
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


