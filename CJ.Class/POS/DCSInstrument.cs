// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Aug 28, 2014
// Time :  05:15 PM
// Description: Class for DCS Instrument
// Modify Person And Date:
// </summary>


using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.POS
{
    public class DCSInstrument
    {

        private int _nInstrumentID;
        private string _sInstrumentName;
        private int _nIsActive;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;

        public int InstrumentID
        {
            get { return _nInstrumentID; }
            set { _nInstrumentID = value; }
        }
        public string InstrumentName
        {
            get { return _sInstrumentName; }
            set { _sInstrumentName = value; }
        }
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nMaxInstrumentID = 0;

            try
            {
                sSql = "SELECT MAX([InstrumentID]) FROM t_DCSInstrument";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxInstrumentID = 1;
                }
                else
                {
                    nMaxInstrumentID = Convert.ToInt32(maxID) + 1;
                }
                if (_nInstrumentID == 0)
                {
                    _nInstrumentID = nMaxInstrumentID;
                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "insert into t_DCSInstrument (InstrumentID,InstrumentName,IsActive,CreateUserID,CreateDate)  VALUES(?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("InstrumentID", _nInstrumentID);
                cmd.Parameters.AddWithValue("InstrumentName", _sInstrumentName);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void Update()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_DCSInstrument Set InstrumentName=?,IsActive=?,UpdateUserID=?,UpdateDate=? Where InstrumentID=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InstrumentName", _sInstrumentName);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("InstrumentID", _nInstrumentID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class DCSInstruments : CollectionBase
    {
        public DCSInstrument this[int i]
        {
            get { return (DCSInstrument)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(DCSInstrument oDCSInstrument)
        {
            InnerList.Add(oDCSInstrument);
        }
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DCSInstrument ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    DCSInstrument oDCSInstrument = new DCSInstrument();

                    oDCSInstrument.InstrumentID = (int)reader["InstrumentID"];
                    oDCSInstrument.InstrumentName = (string)reader["InstrumentName"];
                    oDCSInstrument.IsActive = (int)reader["IsActive"];

                    InnerList.Add(oDCSInstrument);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetActiveInstrument()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DCSInstrument Where IsActive = 1";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    DCSInstrument oDCSInstrument = new DCSInstrument();

                    oDCSInstrument.InstrumentID = (int)reader["InstrumentID"];
                    oDCSInstrument.InstrumentName = (string)reader["InstrumentName"];
                    oDCSInstrument.IsActive = (int)reader["IsActive"];

                    InnerList.Add(oDCSInstrument);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
