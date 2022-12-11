// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Sep 27, 2016
// Time : 06:09 PM
// Description: Class for HRProductionMachineMap.
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
    public class HRProductionMachineMap
    {
        private int _nID;
        private int _nMachineID;
        private string _sMachineCode;
        private string _sMachineName;
        private string _sMachineType;
        private int _nShiftID;
        private string _sShiftName;
        private int _nCreateUserID;
        private string _sCreatedBy;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _sUpdateDate;



        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for CreatedBy
        // </summary>
        public string CreatedBy
        {
            get { return _sCreatedBy; }
            set { _sCreatedBy = value; }
        }
        // <summary>
        // Get set property for MachineID
        // </summary>
        public int MachineID
        {
            get { return _nMachineID; }
            set { _nMachineID = value; }
        }

        // <summary>
        // Get set property for MachineCode
        // </summary>
        public string MachineCode
        {
            get { return _sMachineCode; }
            set { _sMachineCode = value; }
        }

        // <summary>
        // Get set property for MachineName
        // </summary>
        public string MachineName
        {
            get { return _sMachineName; }
            set { _sMachineName = value; }
        }

        // <summary>
        // Get set property for MachineType
        // </summary>
        public string MachineType
        {
            get { return _sMachineType; }
            set { _sMachineType = value; }
        }

        // <summary>
        // Get set property for ShiftID
        // </summary>
        public int ShiftID
        {
            get { return _nShiftID; }
            set { _nShiftID = value; }
        }

        // <summary>
        // Get set property for ShiftName
        // </summary>
        public string ShiftName
        {
            get { return _sShiftName; }
            set { _sShiftName = value; }
        }

        // <summary>
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
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
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public DateTime UpdateDate
        {
            get { return _sUpdateDate; }
            set { _sUpdateDate = value; }
        }
        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_HRProductionMachineMap";
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
                sSql = "INSERT INTO t_HRProductionMachineMap (ID, MachineID, ShiftID, CreateUserID, CreateDate) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("MachineID", _nMachineID);
                cmd.Parameters.AddWithValue("ShiftID", _nShiftID);
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
        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_HRProductionMachineMap SET MachineID = ?, ShiftID = ?,UpdateUserID = ?, UpdateDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("MachineID", _nMachineID);
                cmd.Parameters.AddWithValue("ShiftID", _nShiftID);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _sUpdateDate);
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
                sSql = "DELETE FROM t_HRProductionMachineMap WHERE [ID]=?";
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
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_HRProductionMachineMap where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nMachineID = (int)reader["MachineID"];
                    _nShiftID = (int)reader["ShiftID"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _sUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
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
    public class HRProductionMachineMaps : CollectionBase
    {
        public HRProductionMachineMap this[int i]
        {
            get { return (HRProductionMachineMap)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HRProductionMachineMap oHRProductionMachineMap)
        {
            InnerList.Add(oHRProductionMachineMap);
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
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from dbo.t_HRProductionMachineMap a "
                         +" INNER JOIN dbo.t_HRProductionMachine b on a.MachineID = b.MachineID "
                         +" INNER JOIN t_HRShift c on c.ShiftID = a.ShiftID "
                         +" INNER JOIN t_User d on d.UserID = a.CreateUserID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRProductionMachineMap oHRProductionMachineMap = new HRProductionMachineMap();
                    oHRProductionMachineMap.ID = (int)reader["ID"];
                    oHRProductionMachineMap.MachineID = (int)reader["MachineID"];
                    oHRProductionMachineMap.MachineCode = (string)reader["MachineCode"];
                    oHRProductionMachineMap.MachineName = (string)reader["Name"];
                    oHRProductionMachineMap.MachineType = (string)reader["MachineType"];
                    oHRProductionMachineMap.ShiftID = (int)reader["ShiftID"];
                    oHRProductionMachineMap.ShiftName = (string)reader["ShiftName"];                    
                    oHRProductionMachineMap.CreatedBy = (string)reader["UserFullName"];                                        
                    InnerList.Add(oHRProductionMachineMap);
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

