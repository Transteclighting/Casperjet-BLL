// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: April 12, 2011
// Time :  10:00 AM
// Description: Class for District.
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
    public class District
    {
        private int _nGeoLocationID;
        private string _sGeoLocationName;


        /// <summary>
        /// Get set property for GeoLocationID
        /// </summary>
        public int GeoLocationID
        {
            get { return _nGeoLocationID; }
            set { _nGeoLocationID = value; }
        }

        /// <summary>
        /// Get set property for GeoLocationName
        /// </summary>
        public string GeoLocationName
        {
            get { return _sGeoLocationName; }
            set { _sGeoLocationName = value;}
            //set { _sGeoLocationName = value.Trim(); }
        }

        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_GeoLocation where GeoLocationType =1";
                //cmd.Parameters.AddWithValue("GeoLocationID", _nGeoLocationID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nGeoLocationID = (int)reader["GeoLocationID"];
                    _sGeoLocationName = (string)reader["GeoLocationName"];

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
    public class Districts : CollectionBase
    {

        public District this[int i]
        {
            get { return (District)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(District oDistrict)
        {
            InnerList.Add(oDistrict);
        }
        public int GetIndex(int nGeoLocationID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].GeoLocationID == nGeoLocationID)
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

            string sSql = "SELECT * FROM t_GeoLocation where GeoLocationType =1";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    District oDistrict = new District();

                    oDistrict.GeoLocationID = (int)reader["GeoLocationID"];
                    oDistrict.GeoLocationName = (string)reader["GeoLocationName"];

                    InnerList.Add(oDistrict);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void Refresh(int nType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " SELECT * FROM t_GeoLocation where GeoLocationType =?";
            cmd.Parameters.AddWithValue("GeoLocationName", nType);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    District oDistrict = new District();
                    oDistrict.GeoLocationID = int.Parse(reader["GeoLocationID"].ToString());
                    oDistrict.GeoLocationName = (string)reader["GeoLocationName"].ToString();

                    InnerList.Add(oDistrict);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetThanaName(int nParentID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " SELECT * FROM t_GeoLocation where GeoLocationType = 2 and ParentID=" + nParentID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    District oDistrict = new District();
                    oDistrict.GeoLocationID = int.Parse(reader["GeoLocationID"].ToString());
                    oDistrict.GeoLocationName = (string)reader["GeoLocationName"].ToString();

                    InnerList.Add(oDistrict);
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
