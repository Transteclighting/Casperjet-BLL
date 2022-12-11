// <summary>
// Compamy: Transcom Electronics Limited
// Author: MD. Abdul Hakim
// Date: Feb 16, 2015
// Time : 12:30 PM
// Description: Class for DataMonitoring.
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
    public class DataMonitoring
    {
        private int _nWarehouseID;
        private string _sTableName;
        private int _nDataID;
        private string _sInstruction;
        private DateTime _dCreateDate;
        private string _sField1;
        private string _sField2;
        private string _sField3;


        // <summary>
        // Get set property for WarehouseID
        // </summary>
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }

        // <summary>
        // Get set property for TableName
        // </summary>
        public string TableName
        {
            get { return _sTableName; }
            set { _sTableName = value.Trim(); }
        }

        // <summary>
        // Get set property for DataID
        // </summary>
        public int DataID
        {
            get { return _nDataID; }
            set { _nDataID = value; }
        }

        // <summary>
        // Get set property for Instruction
        // </summary>
        public string Instruction
        {
            get { return _sInstruction; }
            set { _sInstruction = value.Trim(); }
        }

        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        // <summary>
        // Get set property for Field1
        // </summary>
        public string Field1
        {
            get { return _sField1; }
            set { _sField1 = value.Trim(); }
        }

        // <summary>
        // Get set property for Field2
        // </summary>
        public string Field2
        {
            get { return _sField2; }
            set { _sField2 = value.Trim(); }
        }

        // <summary>
        // Get set property for Field3
        // </summary>
        public string Field3
        {
            get { return _sField3; }
            set { _sField3 = value.Trim(); }
        }

        public void Add()
        {
            int nMaxWarehouseID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_DataMonitoring (WarehouseID, TableName, DataID, Instruction, CreateDate, Field1, Field2, Field3) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("TableName", _sTableName);
                cmd.Parameters.AddWithValue("DataID", _nDataID);
                cmd.Parameters.AddWithValue("Instruction", _sInstruction);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Field1", _sField1);
                cmd.Parameters.AddWithValue("Field2", _sField2);
                cmd.Parameters.AddWithValue("Field3", _sField3);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddStockSerialTD()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_ProductStockSerialOutlet (WarehouseID, ProductID, LastUpdateDate, ProductSerialNo) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nDataID);
                cmd.Parameters.AddWithValue("LastUpdateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("ProductSerialNo", _sField1);


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
                sSql = "UPDATE t_DataMonitoring SET TableName = ?, DataID = ?, Instruction = ?, CreateDate = ?, Field1 = ?, Field2 = ?, Field3 = ? WHERE WarehouseID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TableName", _sTableName);
                cmd.Parameters.AddWithValue("DataID", _nDataID);
                cmd.Parameters.AddWithValue("Instruction", _sInstruction);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Field1", _sField1);
                cmd.Parameters.AddWithValue("Field2", _sField2);
                cmd.Parameters.AddWithValue("Field3", _sField3);

                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

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
                sSql = "DELETE FROM t_DataMonitoring WHERE [WarehouseID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DeleteStockSerialTD()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_ProductStockSerialOutlet WHERE [WarehouseID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
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
                cmd.CommandText = "SELECT * FROM t_DataMonitoring where WarehouseID =?";
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _sTableName = (string)reader["TableName"];
                    _nDataID = (int)reader["DataID"];
                    _sInstruction = (string)reader["Instruction"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _sField1 = (string)reader["Field1"];
                    _sField2 = (string)reader["Field2"];
                    _sField3 = (string)reader["Field3"];
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
    public class DataMonitorings : CollectionBase
    {
        public DataMonitoring this[int i]
        {
            get { return (DataMonitoring)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DataMonitoring oDataMonitoring)
        {
            InnerList.Add(oDataMonitoring);
        }
        public int GetIndex(int nWarehouseID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].WarehouseID == nWarehouseID)
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
            string sSql = "SELECT * FROM t_DataMonitoring";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DataMonitoring oDataMonitoring = new DataMonitoring();
                    oDataMonitoring.WarehouseID = (int)reader["WarehouseID"];
                    oDataMonitoring.TableName = (string)reader["TableName"];
                    oDataMonitoring.DataID = (int)reader["DataID"];
                    oDataMonitoring.Instruction = (string)reader["Instruction"];
                    oDataMonitoring.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oDataMonitoring.Field1 = (string)reader["Field1"];
                    oDataMonitoring.Field2 = (string)reader["Field2"];
                    oDataMonitoring.Field3 = (string)reader["Field3"];
                    InnerList.Add(oDataMonitoring);
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


