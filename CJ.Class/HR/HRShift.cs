// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: June 11, 2011
// Time :  2:00 PM
// Description: Class for Shift.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.HR;

namespace CJ.Class
{
    public class Shift
    {
        private int _nShiftID;
        private string _sShiftName;
        private DateTime _dLoginTime;
        private DateTime _dLogoutTime;
        private int _nCompanyID;

        private Company _oCompany;

        private bool _bReadDB;

        /// <summary>
        /// Get set property for ShiftID
        /// </summary>
        public int ShiftID
        {
            get { return _nShiftID; }
            set { _nShiftID = value; }
        }

        /// <summary>
        /// Get set property for ShiftName
        /// </summary>
        public string ShiftName
        {
            get { return _sShiftName; }
            set { _sShiftName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for LoginTime
        /// </summary>
        public DateTime LoginTime
        {
            get { return _dLoginTime; }
            set { _dLoginTime = value; }
        }

        /// <summary>
        /// Get set property for LogoutTime
        /// </summary>
        public DateTime LogoutTime
        {
            get { return _dLogoutTime; }
            set { _dLogoutTime = value; }
        }

        /// <summary>
        /// Get set property for CompanyID
        /// </summary>
        public int CompanyID
        {
            get { return _nCompanyID; }
            set { _nCompanyID = value; }
        }

        public Company Company
        {
            get
            {
                if (_oCompany == null)
                {
                    _oCompany = new Company();
                    _oCompany.CompanyID = _nCompanyID;
                    if (_bReadDB) _oCompany.Refresh();
                }

                return _oCompany;
            }
        }

        /// <summary>
        /// Get set property for ?
        /// </summary>
        public bool ReadDB
        {
            get { return _bReadDB; }
            set { _bReadDB = value; }
        }

        public void Add()
        {
            int nMaxShiftID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ShiftID]) FROM t_HRShift";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxShiftID = 1;
                }
                else
                {
                    nMaxShiftID = Convert.ToInt32(maxID) + 1;
                }
                _nShiftID = nMaxShiftID;

                sSql = "INSERT INTO t_HRShift(ShiftID,ShiftName,LoginTime,"
                    + " LogoutTime,CompanyID) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ShiftID", _nShiftID);
                cmd.Parameters.AddWithValue("ShiftName", _sShiftName);
                cmd.Parameters.AddWithValue("LoginTime", _dLoginTime);
                cmd.Parameters.AddWithValue("LogoutTime", _dLogoutTime);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);

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

                sSql = "UPDATE t_HRShift SET ShiftName=?, LoginTime=?, LogoutTime=?,CompanyID=?"
                    + " WHERE ShiftID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ShiftName", _sShiftName);
                cmd.Parameters.AddWithValue("LoginTime", _dLoginTime);
                cmd.Parameters.AddWithValue("LogoutTime", _dLogoutTime);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("ShiftID", _nShiftID);

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
                sSql = "DELETE FROM t_HRShift WHERE [ShiftID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ShiftID", _nShiftID);
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
                cmd.CommandText = "SELECT * FROM t_HRShift where ShiftID =?";
                cmd.Parameters.AddWithValue("ShiftID", _nShiftID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nShiftID = (int)reader["ShiftID"];
                    _nCompanyID = (int)reader["CompanyID"];
                    _sShiftName = (string)reader["ShiftName"];
                    _dLoginTime = (DateTime)reader["LoginTime"];
                    _dLogoutTime = (DateTime)reader["LogoutTime"];

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
    public class Shifts : CollectionBase
    {

        public Shift this[int i]
        {
            get { return (Shift)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Shift oShift)
        {
            InnerList.Add(oShift);
        }

        public int GetIndex(int nShiftID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ShiftID == nShiftID)
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

            string sSql = "SELECT * FROM t_HRShift";
            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            GetData(cmd);
        }

        public DSAttendance GetShiftData(DSAttendance oDSShift, int nCompanyID)
        {
            
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_HRShift Where 1=1 ";

            if (nCompanyID == 0)
            {
                sSql = sSql + " and CompanyID IN (Select DataID from dbo.t_UserPermissionData Where DataType='Company' and UserID=" + Utility.UserId + ") ";
            }
            else
            {
                sSql = sSql + " and CompanyID = " + nCompanyID + " ";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   
                    DSAttendance.HolydayRow oOutstationRow = oDSShift.Holyday.NewHolydayRow();

                    oOutstationRow.ShiftID = (int)reader["ShiftID"];
                    oOutstationRow.FromDate = (DateTime)reader["LoginTime"];
                    oOutstationRow.ToDate = (DateTime)reader["LogoutTime"];
                    oOutstationRow.CompanyID = (int)reader["CompanyID"];

                    oDSShift.Holyday.AddHolydayRow(oOutstationRow);
                    oDSShift.AcceptChanges();

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return oDSShift;
        }

        public void Refresh(int nCompanyID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_HRShift WHERE CompanyID=?";
            cmd.Parameters.AddWithValue("CompanyID", nCompanyID);
            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;

            GetData(cmd);
        }

        private void GetData(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Shift oShift = new Shift();

                    oShift.ShiftID = (int)reader["ShiftID"];
                    oShift.CompanyID = (int)reader["CompanyID"];
                    oShift.ShiftName = (string)reader["ShiftName"];
                    oShift.LoginTime = (DateTime)reader["LoginTime"];
                    oShift.LogoutTime = (DateTime)reader["LogoutTime"];

                    InnerList.Add(oShift);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetShift(int nCompanyID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            Shift oShift;
            if (nCompanyID != 0)
            {
                sSql = "SELECT * FROM t_HRShift WHERE CompanyID=?";
                cmd.Parameters.AddWithValue("CompanyID", nCompanyID);
            }
            else sSql = "SELECT * FROM t_HRShift ";

            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;

            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oShift = new Shift();
                    oShift.ShiftID = (int)reader["ShiftID"];
                    oShift.ShiftName = (string)reader["ShiftName"];
                    oShift.LoginTime = (DateTime)reader["LoginTime"];
                    oShift.LogoutTime = (DateTime)reader["LogoutTime"];

                    InnerList.Add(oShift);
                }
                reader.Close();

                oShift = new Shift();
                oShift.ShiftID = -1;
                oShift.ShiftName = "<All>";
                oShift.LoginTime = DateTime.Now;
                oShift.LogoutTime = DateTime.Now;

                InnerList.Add(oShift);

                InnerList.TrimToSize();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}

