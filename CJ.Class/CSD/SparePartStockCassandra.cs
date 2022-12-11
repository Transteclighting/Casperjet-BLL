// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Aug 04, 2012
// Time :  11:07 AM
// Description: Class for Spare Parts Stock From Cassandra.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;
using CJ.Class.CSD;
using CJ.Class;

namespace CJ.Class
{
    public class SparePartStockCassandra
    { 

        private int _nID;
        private int _nSparePartID;
        private long _nSoundQty;
        private long _nTotalQty;
        private DateTime _dLastTranDate;

        private SpareParts _oSpareParts;
        private bool _bFlag;

        /// <summary>
        /// Get set property for ID
        /// </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }
        /// <summary>
        /// Get set property for SparePartID
        /// </summary>
        public int SparePartID
        {
            get { return _nSparePartID; }
            set { _nSparePartID = value; }
        }
        /// <summary>
        /// Get set property for SoundQty
        /// </summary>
        public long SoundQty
        {
            get { return _nSoundQty; }
            set { _nSoundQty = value; }
        }
        /// <summary>
        /// Get set property for TotalQty
        /// </summary>
        public long TotalQty
        {
            get { return _nTotalQty; }
            set { _nTotalQty = value; }
        }
        /// <summary>
        /// Get set property for LastTranDate
        /// </summary>
        public DateTime LastTranDate
        {
            get { return _dLastTranDate; }
            set { _dLastTranDate = value; }
        }

        public SpareParts SpareParts
        {
            get
            {
                if (_oSpareParts == null)
                {
                    _oSpareParts = new SpareParts();

                }
                return _oSpareParts;
            }
        }

        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }
        public void UpdateSprePartsStock()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE TELServiceDB.dbo.SparePartStock SET SoundQty=SoundQty-?,TotalQty=TotalQty-?,LastTranDate=? WHERE SparePartID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SoundQty", _nSoundQty);
                cmd.Parameters.AddWithValue("TotalQty", _nTotalQty);
                cmd.Parameters.AddWithValue("LastTranDate", DateTime.Now.Date);

                cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshSpareID()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM TELServiceDB.dbo.SparePartStock where SparePartID=?";
            cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    try
                    {
                        _nSoundQty = Convert.ToInt64(reader["SoundQty"].ToString().Trim());
                        _nTotalQty = Convert.ToInt64(reader["TotalQty"].ToString().Trim());
                    }
                    catch (Exception ex)
                    {
                        _nSoundQty = Convert.ToInt64(0);
                        _nTotalQty = Convert.ToInt64(0);
                    }

                    //_nSoundQty = Convert.ToInt64(reader["SoundQty"].ToString());
                    //_nTotalQty = Convert.ToInt64(reader["TotalQty"].ToString());

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
    public class SparePartStockCassandras : CollectionBase
    {
        public SparePartStockCassandra this[int i]
        {
            get { return (SparePartStockCassandra)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SparePartStockCassandra oSparePartStockCassandra)
        {
            InnerList.Add(oSparePartStockCassandra);
        }


        public void Refresh()
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from TELServiceDB.dbo.SparePartStok";

            
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SparePartStockCassandra oSparePartStockCassandra = new SparePartStockCassandra();

                    oSparePartStockCassandra.ID = (int)reader["ID"];
                    oSparePartStockCassandra.SparePartID = (int)reader["SparePartID"];
                    oSparePartStockCassandra.SoundQty = Convert.ToInt64(reader["SpareName"].ToString());
                    oSparePartStockCassandra.TotalQty = Convert.ToInt64(reader["ModelNo"].ToString());
                    oSparePartStockCassandra.LastTranDate = (DateTime)reader["LastTranDate"];


                    InnerList.Add(oSparePartStockCassandra);
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



