// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: June 25, 2011
// Time :  12:00 PM
// Description: Class for Country.
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

    public class Country
    {

        private string _sCountryCode;
        private string _sCountryName;
        private string _sDescription;

        public string CountryCode
        {
            get { return _sCountryCode; }
            set { _sCountryCode = value; }

        }

        public string CountryName
        {
            get { return _sCountryName; }
            set { _sCountryName = value; }
        }

        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value; }
        }

        //public void Add()
        //{
        //    int nMaxCountryID = 0;
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "";

        //    try
        //    {
        //        sSql = "SELECT MAX([CountryID]) FROM t_Country";
        //        cmd.CommandText = sSql;
        //        object maxID = cmd.ExecuteScalar();
        //        if (maxID == DBNull.Value)
        //        {
        //            nMaxCountryID = 1;
        //        }
        //        else
        //        {
        //            nMaxCountryID = Convert.ToInt32(maxID) + 1;
        //        }
        //        _nCountryID = nMaxCountryID;

        //        sSql = "INSERT INTO t_Country VALUES(?,?,?,?)";
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        cmd.Parameters.AddWithValue("CountryID", _nCountryID);
        //        cmd.Parameters.AddWithValue("CountryCode", _sCountryCode);
        //        cmd.Parameters.AddWithValue("CountryName", _sCountryName);
        //        cmd.Parameters.AddWithValue("IsActive", _bIsActive);

        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        //public void Edit()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "";

        //    try
        //    {

        //        sSql = "UPDATE t_Country SET CountryCode=?, CountryName=?, IsActive=?"
        //            + " WHERE CountryID=?";
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        cmd.Parameters.AddWithValue("CountryCode", _sCountryCode);
        //        cmd.Parameters.AddWithValue("CountryName", _sCountryName);
        //        cmd.Parameters.AddWithValue("IsActive", _bIsActive);
        //        cmd.Parameters.AddWithValue("CountryID", _nCountryID);

        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        //public void Delete()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "";

        //    try
        //    {
        //        sSql = "DELETE FROM t_Country WHERE [CountryID]=?";

        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        cmd.Parameters.AddWithValue("CountryID", _nCountryID);
        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw (ex);
        //    }
        //}

        //public void Refresh()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    int nCount = 0;
        //    try
        //    {
        //        cmd.CommandText = "SELECT * FROM t_Country where CountryID =?";
        //        cmd.Parameters.AddWithValue("CountryID", _nCountryID);
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            _nCountryID = (int)reader["CountryID"];
        //            _sCountryCode = (string)reader["CountryCode"];
        //            _sCountryName = (string)reader["CountryName"];
        //            _bIsActive = Convert.ToBoolean(reader["IsActive"]);
        //            nCount++;
        //        }

        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

    }


    public class Countrys : CollectionBase
    {

        public Country this[int i]
        {
            get { return (Country)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Country oCountry)
        {
            InnerList.Add(oCountry);
        }

        public int GetIndex(string sCode)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].CountryCode == sCode)
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

            string sSql = "SELECT * FROM t_Country ORDER BY CountryName";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Country oCountry = new Country();
                    oCountry.CountryCode = (string)reader["CountryCode"];
                    oCountry.CountryName = (string)reader["CountryName"];
                    //oCountry.Description = (string)reader["Description"];
                    InnerList.Add(oCountry);
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
