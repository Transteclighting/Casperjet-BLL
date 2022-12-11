// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Aug 20, 2016
// Time : 11:30 AM
// Description: Class for MobileDatapac.
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
    public class MobileDatapac
    {
        private int _nDatapacID;
        private string _sPackageName;
        private double _PackageAmount;


        // <summary>
        // Get set property for DatapacID
        // </summary>
        public int DatapacID
        {
            get { return _nDatapacID; }
            set { _nDatapacID = value; }
        }

        // <summary>
        // Get set property for PackageName
        // </summary>
        public string PackageName
        {
            get { return _sPackageName; }
            set { _sPackageName = value.Trim(); }
        }

        // <summary>
        // Get set property for PackageAmount
        // </summary>
        public double PackageAmount
        {
            get { return _PackageAmount; }
            set { _PackageAmount = value; }
        }

        public void Add()
        {
            int nMaxDatapacID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([DatapacID]) FROM t_MobileDatapac";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxDatapacID = 1;
                }
                else
                {
                    nMaxDatapacID = Convert.ToInt32(maxID) + 1;
                }
                _nDatapacID = nMaxDatapacID;
                sSql = "INSERT INTO t_MobileDatapac (DatapacID, PackageName, PackageAmount) VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DatapacID", _nDatapacID);
                cmd.Parameters.AddWithValue("PackageName", _sPackageName);
                cmd.Parameters.AddWithValue("PackageAmount", _PackageAmount);

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
                sSql = "UPDATE t_MobileDatapac SET PackageName = ?, PackageAmount = ? WHERE DatapacID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PackageName", _sPackageName);
                cmd.Parameters.AddWithValue("PackageAmount", _PackageAmount);

                cmd.Parameters.AddWithValue("DatapacID", _nDatapacID);

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
                sSql = "DELETE FROM t_MobileDatapac WHERE [DatapacID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DatapacID", _nDatapacID);
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
                cmd.CommandText = "SELECT * FROM t_MobileDatapac where DatapacID =?";
                cmd.Parameters.AddWithValue("DatapacID", _nDatapacID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nDatapacID = (int)reader["DatapacID"];
                    _sPackageName = (string)reader["PackageName"];
                    _PackageAmount = Convert.ToDouble(reader["PackageAmount"].ToString());
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
    public class MobileDatapacs : CollectionBase
    {
        public MobileDatapac this[int i]
        {
            get { return (MobileDatapac)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(MobileDatapac oMobileDatapac)
        {
            InnerList.Add(oMobileDatapac);
        }
        public int GetIndex(int nDatapacID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].DatapacID == nDatapacID)
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
            string sSql = "SELECT * FROM t_MobileDatapac";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MobileDatapac oMobileDatapac = new MobileDatapac();
                    oMobileDatapac.DatapacID = (int)reader["DatapacID"];
                    oMobileDatapac.PackageName = (string)reader["PackageName"];
                    oMobileDatapac.PackageAmount = Convert.ToDouble(reader["PackageAmount"].ToString());
                    InnerList.Add(oMobileDatapac);
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

