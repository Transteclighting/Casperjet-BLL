// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Sep 27, 2016
// Time : 10:50 AM
// Description: Class for HRProductionMachine.
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
    public class HRProductionMachine
    {
        private int _nMachineID;
        private string _sMachineCode;
        private string _sName;
        private string _sMachineType;
        private int _nStatus;
        private int _nCreateUserID;
        private DateTime _dtCreateDate;
        private int _nUpdateUserID;
        private DateTime _dtUpdateDate;
        private string _sRemarks;
        


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
            set { _sMachineCode = value.Trim(); }
        }

        // <summary>
        // Get set property for Name
        // </summary>
        public string Name
        {
            get { return _sName; }
            set { _sName = value.Trim(); }
        }

        // <summary>
        // Get set property for MachineType
        // </summary>
        public string MachineType
        {
            get { return _sMachineType; }
            set { _sMachineType = value.Trim(); }
        }

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }


        // <summary>
        // Get set property for CreateUserID;
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        // <summary>
        // Get set property for CreateDate;
        // </summary>
        public DateTime CreateDate
        {
            get { return _dtCreateDate; }
            set { _dtCreateDate = value; }
        }

        // <summary>
        // Get set property for UpdateUserID;
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        // <summary>
        // Get set property for UpdateDate;
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dtUpdateDate; }
            set { _dtUpdateDate = value; }
        }
        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        public void Add()
        {
            int nMaxMachineID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([MachineID]) FROM t_HRProductionMachine";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxMachineID = 1;
                }
                else
                {
                    nMaxMachineID = Convert.ToInt32(maxID) + 1;
                }
                _nMachineID = nMaxMachineID;
                sSql = "INSERT INTO t_HRProductionMachine (MachineID, MachineCode, Name, MachineType,Remarks,CreateUserID,CreateDate) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("MachineID", _nMachineID);
                cmd.Parameters.AddWithValue("MachineCode", _sMachineCode);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("MachineType", _sMachineType);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dtCreateDate);
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
                sSql = "UPDATE t_HRProductionMachine SET MachineCode = ?, Name = ?, MachineType = ?, Remarks = ?,UpdateUserID=?,UpdateDate=? WHERE MachineID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("MachineCode", _sMachineCode);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("MachineType", _sMachineType);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("MachineID", _nMachineID);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dtUpdateDate);

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
                sSql = "DELETE FROM t_HRProductionMachine WHERE [MachineID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("MachineID", _nMachineID);
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
                cmd.CommandText = "SELECT * FROM t_HRProductionMachine where MachineID =?";
                cmd.Parameters.AddWithValue("MachineID", _nMachineID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nMachineID = (int)reader["MachineID"];
                    _sMachineCode = (string)reader["MachineCode"];
                    _sName = (string)reader["Name"];
                    _sMachineType = (string)reader["MachineType"];
                    _nStatus = (int)reader["Status"];
                    _sRemarks = (string)reader["Remarks"];
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
    public class HRProductionMachines : CollectionBase
    {
        public HRProductionMachine this[int i]
        {
            get { return (HRProductionMachine)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HRProductionMachine oHRProductionMachine)
        {
            InnerList.Add(oHRProductionMachine);
        }
        public int GetIndex(int nMachineID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].MachineID == nMachineID)
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
            string sSql = "SELECT * FROM t_HRProductionMachine";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRProductionMachine oHRProductionMachine = new HRProductionMachine();
                    oHRProductionMachine.MachineID = (int)reader["MachineID"];
                    oHRProductionMachine.MachineCode = (string)reader["MachineCode"];
                    oHRProductionMachine.Name = (string)reader["Name"];
                    oHRProductionMachine.MachineType = (string)reader["MachineType"];
                    if (reader["Remarks"] != DBNull.Value)
                    oHRProductionMachine.Remarks = (string)reader["Remarks"];
                    InnerList.Add(oHRProductionMachine);
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

