using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.ERP
{
    public class MapERPWareHouse
    {
        private int _nID;
        private int _nWareHouseId;
        private string _sWareHouseERPCode;
        private string _sWareHouseDescription;
        private string _sWareHouseCode;
        private string _nWareHouseCode;
        private string _nWareHouseName;

        private string duplicateVale;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for WareHouseERPCode
        // </summary>
        public string WareHouseERPCode
        {
            get { return _sWareHouseERPCode; }
            set { _sWareHouseERPCode = value.Trim(); }
        }

        // <summary>
        // Get set property for WareHouseDescription
        // </summary>
        public string WareHouseDescription
        {
            get { return _sWareHouseDescription; }
            set { _sWareHouseDescription = value.Trim(); }
        }

        // <summary>
        // Get set property for WareHouseCode
        // </summary>
        public string WareHouseCode
        {
            get { return _sWareHouseCode; }
            set { _sWareHouseCode = value.Trim(); }
        }

        public string WareHouseCodeMain
        {
            get { return _nWareHouseCode; }
            set { _nWareHouseCode = value.Trim(); }
        }

        public string WareHouseName
        {
            get { return _nWareHouseName; }
            set { _nWareHouseName = value.Trim(); }
        }

        public int WareHouseId
        {
            get { return _nWareHouseId; }
            set { _nWareHouseId = value; }
        }
        

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_MapERPWareHouse";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = Convert.ToInt32(maxID) + 1;
                }
                _nID = nMaxID;
                sSql = "INSERT INTO t_MapERPWareHouse (ID, WareHouseERPCode, WareHouseDescription, WareHouseCode) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("WareHouseERPCode", _sWareHouseERPCode);
                cmd.Parameters.AddWithValue("WareHouseDescription", _sWareHouseDescription);
                cmd.Parameters.AddWithValue("WareHouseCode", _sWareHouseCode);

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
                sSql = "UPDATE t_MapERPWareHouse SET WareHouseERPCode = ?, WareHouseDescription = ?, WareHouseCode = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("WareHouseERPCode", _sWareHouseERPCode);
                cmd.Parameters.AddWithValue("WareHouseDescription", _sWareHouseDescription);
                cmd.Parameters.AddWithValue("WareHouseCode", _sWareHouseCode);

                cmd.Parameters.AddWithValue("ID", _nID);

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
                sSql = "DELETE FROM t_MapERPWareHouse WHERE [ID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public string CheckDuplicateData()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            duplicateVale = "No";
            try
            {
                cmd.CommandText = "SELECT * FROM t_MapERPWareHouse where WareHouseERPCode =? and WareHouseCode =?";
                cmd.Parameters.AddWithValue("WareHouseERPCode", _sWareHouseERPCode);
                cmd.Parameters.AddWithValue("WareHouseCode", _sWareHouseCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    duplicateVale = "Yes";
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return duplicateVale;
        }


        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_MapERPWareHouse where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _sWareHouseERPCode = (string)reader["WareHouseERPCode"];
                    _sWareHouseDescription = (string)reader["WareHouseDescription"];
                    _sWareHouseCode = (string)reader["WareHouseCode"];
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
    public class MapERPWareHouses : CollectionBase
    {
        public MapERPWareHouse this[int i]
        {
            get { return (MapERPWareHouse)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(MapERPWareHouse oMapERPWareHouse)
        {
            InnerList.Add(oMapERPWareHouse);
        }
        public int GetIndex(int nID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ID == nID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Refresh(string nWHCode, string nWHERPCode, string nWHDesc)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_MapERPWareHouse where 1=1";

            if (!string.IsNullOrEmpty(nWHCode))
            {
                sSql = sSql + " and WareHouseCode = " + nWHCode + " ";
            }

            if (!string.IsNullOrEmpty(nWHERPCode))
            {
                sSql = sSql + " and WareHouseERPCode = " + nWHERPCode + " ";
            }

            if (!string.IsNullOrEmpty(nWHDesc))
            {
                sSql = sSql + " and WareHouseDescription like '%" + nWHDesc + "%'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MapERPWareHouse oMapERPWareHouse = new MapERPWareHouse();
                    oMapERPWareHouse.ID = (int)reader["ID"];
                    oMapERPWareHouse.WareHouseERPCode = (string)reader["WareHouseERPCode"];
                    oMapERPWareHouse.WareHouseDescription = (string)reader["WareHouseDescription"];
                    oMapERPWareHouse.WareHouseCode = (string)reader["WareHouseCode"];
                    InnerList.Add(oMapERPWareHouse);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetAllWarehouse()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_Warehouse where IsActive=1 order by WarehouseCode";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    MapERPWareHouse oMapERPWareHouse = new MapERPWareHouse();                    
                    oMapERPWareHouse.WareHouseId = (int)reader["WarehouseID"];
                    oMapERPWareHouse.WareHouseCodeMain = (string)reader["WarehouseCode"];
                    oMapERPWareHouse.WareHouseName = (string)reader["WarehouseName"];

                    InnerList.Add(oMapERPWareHouse);
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


        public int GetIndexByWareHouseCode(string whCode)
        {
            int i = 0;
            foreach (MapERPWareHouse oMapERPWareHouse in this)
            {
                if (oMapERPWareHouse.WareHouseCodeMain == whCode)
                    return i;
                i++;
            }
            return -1;
        }


    }
}


