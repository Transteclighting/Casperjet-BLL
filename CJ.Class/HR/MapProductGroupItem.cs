//// <summary>
//// Compamy: Transcom Electronics Limited
//// Author: Shavagata Saha
//// Date: Oct 04, 2015
//// Time : 04:27 PM
//// Description: Class for MapProductGroupItem.
//// Modify Person And Date:
//// </summary>

//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Collections;
//using System.Data;
//using System.Data.OleDb;
//using CJ.Class;

//namespace CJ.Class
//{
//    public class MapProductGroupItem
//    {
//        private int _nID;
//        private int _nDataID;


//        // <summary>
//        // Get set property for ID
//        // </summary>
//        public int ID
//        {
//            get { return _nID; }
//            set { _nID = value; }
//        }

//        // <summary>
//        // Get set property for DataID
//        // </summary>
//        public int DataID
//        {
//            get { return _nDataID; }
//            set { _nDataID = value; }
//        }

//        public void Add()
//        {
//            OleDbCommand cmd = DBController.Instance.GetCommand();
//            string sSql = "";

//            try
//            {
//                sSql = "INSERT INTO t_MapProductGroupItem (ID, DataID) VALUES(?,?)";
//                cmd.CommandText = sSql;
//                cmd.CommandType = CommandType.Text;
//                cmd.Parameters.AddWithValue("ID", _nID);
//                cmd.Parameters.AddWithValue("DataID", _nDataID);

//                cmd.ExecuteNonQuery();
//                cmd.Dispose();
//            }
//            catch (Exception ex)
//            {
//                throw (ex);
//            }
//        }
//        public void Edit()
//        {
//            OleDbCommand cmd = DBController.Instance.GetCommand();
//            string sSql = "";
//            try
//            {
//                sSql = "UPDATE t_MapProductGroupItem SET DataID = ? WHERE ID = ?";
//                cmd.CommandText = sSql;
//                cmd.CommandType = CommandType.Text;

//                cmd.Parameters.AddWithValue("DataID", _nDataID);

//                cmd.Parameters.AddWithValue("ID", _nID);

//                cmd.ExecuteNonQuery();
//                cmd.Dispose();
//            }
//            catch (Exception ex)
//            {
//                throw (ex);
//            }
//        }
//        public void Delete()
//        {
//            OleDbCommand cmd = DBController.Instance.GetCommand();
//            string sSql = "";
//            try
//            {
//                sSql = "DELETE FROM t_MapProductGroupItem WHERE [ID]=?";
//                cmd.CommandText = sSql;
//                cmd.CommandType = CommandType.Text;
//                cmd.Parameters.AddWithValue("ID", _nID);
//                cmd.ExecuteNonQuery();
//                cmd.Dispose();
//            }
//            catch (Exception ex)
//            {
//                throw (ex);
//            }
//        }
//        public void Refresh()
//        {
//            OleDbCommand cmd = DBController.Instance.GetCommand();
//            int nCount = 0;
//            try
//            {
//                cmd.CommandText = "SELECT * FROM t_MapProductGroupItem where ID =?";
//                cmd.Parameters.AddWithValue("ID", _nID);
//                cmd.CommandType = CommandType.Text;
//                IDataReader reader = cmd.ExecuteReader();
//                if (reader.Read())
//                {
//                    _nID = (int)reader["ID"];
//                    _nDataID = (int)reader["DataID"];
//                    nCount++;
//                }
//                reader.Close();
//            }
//            catch (Exception ex)
//            {
//                throw (ex);
//            }
//        }
//    }
//    public class MapProductGroupItems : CollectionBase
//    {
//        public MapProductGroupItem this[int i]
//        {
//            get { return (MapProductGroupItem)InnerList[i]; }
//            set { InnerList[i] = value; }
//        }
//        public void Add(MapProductGroupItem oMapProductGroupItem)
//        {
//            InnerList.Add(oMapProductGroupItem);
//        }
//        public int GetIndex(int nID)
//        {
//            int i;
//            for (i = 0; i < this.Count; i++)
//            {
//                if (this[i].ID == nID)
//                {
//                    return i;
//                }
//            }
//            return -1;
//        }
//        public void Refresh()
//        {
//            InnerList.Clear();
//            OleDbCommand cmd = DBController.Instance.GetCommand();
//            string sSql = "SELECT * FROM t_MapProductGroupItem";
//            try
//            {
//                cmd.CommandText = sSql;
//                cmd.CommandType = CommandType.Text;
//                IDataReader reader = cmd.ExecuteReader();
//                while (reader.Read())
//                {
//                    MapProductGroupItem oMapProductGroupItem = new MapProductGroupItem();
//                    oMapProductGroupItem.ID = (int)reader["ID"];
//                    oMapProductGroupItem.DataID = (int)reader["DataID"];
//                    InnerList.Add(oMapProductGroupItem);
//                }
//                reader.Close();
//                InnerList.TrimToSize();
//            }
//            catch (Exception ex)
//            {
//                throw (ex);
//            }
//        }
//        public void RefreshData()
//        {
//            InnerList.Clear();
//            OleDbCommand cmd = DBController.Instance.GetCommand();
//            string sSql = "SELECT * FROM t_MapProductGroupItem where ID = ?";
//            try
//            {
//                cmd.CommandText = sSql;
//                cmd.CommandType = CommandType.Text;
//                IDataReader reader = cmd.ExecuteReader();
//                while (reader.Read())
//                {
//                    MapProductGroupItem oMapProductGroupItem = new MapProductGroupItem();
//                    oMapProductGroupItem.ID = (int)reader["ID"];
//                    oMapProductGroupItem.DataID = (int)reader["DataID"];
//                    InnerList.Add(oMapProductGroupItem);
//                }
//                reader.Close();
//                InnerList.TrimToSize();
//            }
//            catch (Exception ex)
//            {
//                throw (ex);
//            }
//        }
//    }
//}

