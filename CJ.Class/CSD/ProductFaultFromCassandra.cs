

// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: June 14, 2012
// Time :  03:30 PM
// Description: Class for Product Fault from Cassandra.
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
    public class ProductFaultFromCassandra
    {
        private int _nDescriptionID;
        private string _sDescription;


        /// <summary>
        /// Get set property for DescriptionID
        /// </summary>
        public int DescriptionID
        {
            get { return _nDescriptionID; }
            set { _nDescriptionID = value; }
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

        public void RefreshByFaultID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select DescriptionID, Description From TELServiceDB.dbo.basicDescription Where DescriptionID=?";
                cmd.Parameters.AddWithValue("DescriptionID", _nDescriptionID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nDescriptionID = (int)reader["DescriptionID"];
                    _sDescription = (string)reader["Description"];

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
    public class ProductFaultFromCassandras : CollectionBase
    {

        public ProductFaultFromCassandra this[int i]
        {
            get { return (ProductFaultFromCassandra)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ProductFaultFromCassandra oProductFaultFromCassandra)
        {
            InnerList.Add(oProductFaultFromCassandra);
        }
        public int GetIndex(int nDescriptionID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].DescriptionID == nDescriptionID)
                {
                    return i;
                }
            }
            return -1;
        }

        //public int GetIndexByID(int nDescriptionID)
        //{
        //    int i = 0;
        //    foreach (ProductFaultFromCassandra oProductFaultFromCassandra in this)
        //    {
        //        if (oProductFaultFromCassandra.DescriptionID == nDescriptionID)
        //            return i;
        //        i++;
        //    }
        //    return -1;
        //}


        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select DescriptionID, Description From TELServiceDB.dbo.basicDescription Where Type <>2 Order by Description";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductFaultFromCassandra oProductFaultFromCassandra = new ProductFaultFromCassandra();

                    oProductFaultFromCassandra.DescriptionID = (int)reader["DescriptionID"];
                    oProductFaultFromCassandra.Description = (string)reader["Description"];

                    InnerList.Add(oProductFaultFromCassandra);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetFaultName(int nType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select DescriptionID, Description From TELServiceDB.dbo.basicDescription Where Type <>2 Order by Description";
            cmd.Parameters.AddWithValue("Description", nType);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductFaultFromCassandra oProductFaultFromCassandra = new ProductFaultFromCassandra();

                    oProductFaultFromCassandra.DescriptionID = (int)reader["DescriptionID"];
                    oProductFaultFromCassandra.Description = (string)reader["Description"];

                    InnerList.Add(oProductFaultFromCassandra);
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

