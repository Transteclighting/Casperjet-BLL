// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Nov 03, 2012
// Time :  03:00 PM
// Description: Class for Spare Parts Tran Type.
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
    public class SPTranType
    {
        private int _nSPTranTypeID;
        private string _sName;
        private int _nTranSide;
        private int _nIsSystem;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;


        private User _oUser;

        /// <summary>
        /// Get set property for SPTranTypeID
        /// </summary>
        public int SPTranTypeID
        {
            get { return _nSPTranTypeID; }
            set { _nSPTranTypeID = value; }
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
        /// Get set property for TranSide
        /// </summary>
        public int TranSide
        {
            get { return _nTranSide; }
            set { _nTranSide = value; }
        }
        /// <summary>
        /// Get set property for IsSystem
        /// </summary>
        public int IsSystem
        {
            get { return _nIsSystem; }
            set { _nIsSystem = value; }
        }
        /// <summary>
        /// Get set property for CreateUserID
        /// </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
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

        public User User
        {
            get
            {
                if (_oUser == null)
                {
                    _oUser = new User();
                    User.UserId =_nCreateUserID;
                    User.RefreshByUserID();
                }
                return _oUser;
            }
        }
        public void Add()
        {
            int nMaxSPTranTypeID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([SPTranTypeID]) FROM t_CSDSPTranType";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSPTranTypeID = 1;
                }
                else
                {
                    nMaxSPTranTypeID = Convert.ToInt32(maxID) + 1;
                }
                _nSPTranTypeID = nMaxSPTranTypeID;


                sSql = "INSERT INTO t_CSDSPTranType(SPTranTypeID, Name, TranSide, IsSystem, CreateUserID,CreateDate) VALUES(?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SPTranTypeID", _nSPTranTypeID);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("TranSide", _nTranSide);
                cmd.Parameters.AddWithValue("IsSystem", _nIsSystem);
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

                cmd.CommandText = "UPDATE t_CSDSPTranType SET Name=?, TranSide=?, IsSystem=?, UpdateUserID=?,UpdateDate=? Where SPTranTypeID=? ";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("TranSide", _nTranSide);
                cmd.Parameters.AddWithValue("IsSystem", _nIsSystem);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                cmd.Parameters.AddWithValue("SPTranTypeID", _nSPTranTypeID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckTypeName()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_CSDSPTranType where Name=? ";
            cmd.Parameters.AddWithValue("Name", _sName);

            try
            {
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
    public class SPTranTypes : CollectionBase
    {

        public SPTranType this[int i]
        {
            get { return (SPTranType)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SPTranType oSPTranType)
        {
            InnerList.Add(oSPTranType);
        }
        public int GetIndex(int nSPTranTypeID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].SPTranTypeID == nSPTranTypeID)
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

            string sSql = " Select * from t_CSDSPTranType ";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SPTranType oSPTranType = new SPTranType();

                    oSPTranType.SPTranTypeID = (int)reader["SPTranTypeID"];
                    oSPTranType.Name = (string)reader["Name"];
                    oSPTranType.TranSide = (int)reader["TranSide"];
                    oSPTranType.IsSystem = (int)reader["IsSystem"];
                    oSPTranType.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oSPTranType.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    InnerList.Add(oSPTranType);
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




