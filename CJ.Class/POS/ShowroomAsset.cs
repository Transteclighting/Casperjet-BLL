// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul  Hakim
// Date: April 21, 2014
// Time :  06:58 PM
// Description: Class for ShowroomAsset.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.POS
{
    public class ShowroomAsset
    {
        private int _nAssetID;
        private string _sAssetCode;
        private string _sAssetName;
        private int _nAssetType;
        private int _nOutletID;
        private int _nIsActive;


        /// <summary>
        /// Get set property for AssetID
        /// </summary>
        public int AssetID
        {
            get { return _nAssetID; }
            set { _nAssetID = value; }
        }

        /// <summary>
        /// Get set property for AssetCode
        /// </summary>
        public string AssetCode
        {
            get { return _sAssetCode; }
            set { _sAssetCode = value.Trim(); }
        }

        /// <summary>
        /// Get set property for AssetName
        /// </summary>
        public string AssetName
        {
            get { return _sAssetName; }
            set { _sAssetName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for AssetType
        /// </summary>
        public int AssetType
        {
            get { return _nAssetType; }
            set { _nAssetType = value; }
        }

        /// <summary>
        /// Get set property for OutletID
        /// </summary>
        public int OutletID
        {
            get { return _nOutletID; }
            set { _nOutletID = value; }
        }

        /// <summary>
        /// Get set property for IsActive
        /// </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }

    }
    public class ShowroomAssets : CollectionBase
    {
        public ShowroomAsset this[int i]
        {
            get { return (ShowroomAsset)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public int GetIndex(int nAssetID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].AssetID == nAssetID)
                {
                    return i;
                }
            }
            return -1;
        }


        public void Add(ShowroomAsset oShowroomAsset)
        {
            InnerList.Add(oShowroomAsset);
        }

        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_Bank Where IsActive = ? ";
            cmd.Parameters.AddWithValue("IsActive", (int)Dictionary.YesOrNoStatus.YES);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ShowroomAsset oShowroomAsset = new ShowroomAsset();

                    oShowroomAsset.AssetID = (int)reader["AssetID"];
                    oShowroomAsset.AssetCode = (string)reader["AssetCode"];
                    oShowroomAsset.AssetName = (string)reader["AssetName"];
                    oShowroomAsset.AssetType = (int)reader["AssetType"];
                    oShowroomAsset.OutletID = (int)reader["OutletID"];
                    oShowroomAsset.IsActive = (int)reader["IsActive"];

                    InnerList.Add(oShowroomAsset);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(Dictionary.ShowroomAssetType nAssetType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_ShowroomAsset Where IsActive = ? and AssetType=? ";
            cmd.Parameters.AddWithValue("IsActive", (int)Dictionary.YesOrNoStatus.YES);
            cmd.Parameters.AddWithValue("AssetType", nAssetType);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ShowroomAsset oShowroomAsset = new ShowroomAsset();

                    oShowroomAsset.AssetID = (int)reader["AssetID"];
                    oShowroomAsset.AssetCode = (string)reader["AssetCode"];
                    oShowroomAsset.AssetName = (string)reader["AssetName"];
                    oShowroomAsset.AssetType = (int)reader["AssetType"];
                    oShowroomAsset.OutletID = (int)reader["OutletID"];
                    oShowroomAsset.IsActive = (int)reader["IsActive"];

                    InnerList.Add(oShowroomAsset);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}


