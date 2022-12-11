// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak Kumar Chakraborty
// Date: Nov 14, 2011
// Time :  4:00 PM
// Description: Class for Vehicle Driver.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;


namespace CJ.Class.Admin
{
    public class VehicleDriver
    {
        private int _nVehicleDriverID;
        private string _sVehicleDriverCode;
        private string _sVehicleDriverName;
        private string _sMobileNo;


        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value; }

        }
        public int VehicleDriverID
        {
        get { return _nVehicleDriverID; }
        set { _nVehicleDriverID = value; }
          
        }
        public string VehicleDriverName
        {
        get { return _sVehicleDriverName; }
        set { _sVehicleDriverName = value; }

        }
        public string VehicleDriverCode
        {
            get { return _sVehicleDriverCode; }
            set { _sVehicleDriverCode = value; }

        }

        public void Add()
        {
            int nMaxVehicleDriverID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([vehicleDriverID]) FROM t_vehicleDriver";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxVehicleDriverID = 1;
                }
                else
                {
                    nMaxVehicleDriverID = Convert.ToInt32(maxID) + 1;
                }
                _nVehicleDriverID = nMaxVehicleDriverID;

                sSql = "INSERT INTO t_vehicleDriver VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("VehicleDriverID", _nVehicleDriverID);
                cmd.Parameters.AddWithValue("VehicleDriverCode", _sVehicleDriverCode);
                cmd.Parameters.AddWithValue("VehicleDriverName", _sVehicleDriverName);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
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

                sSql = "UPDATE t_vehicleDriver SET VehicleDriverCode=?, VehicleDriverName=?,MobileNo=? "
                    + " WHERE VehicleDriverID= ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                
                cmd.Parameters.AddWithValue("VehicleDriverCode", _sVehicleDriverCode);
                cmd.Parameters.AddWithValue("VehicleDriverName", _sVehicleDriverName);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("VehicleDriverID", _nVehicleDriverID);

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
                sSql = "DELETE FROM t_vehicleDriver WHERE [VehicleDriverID]= ? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("VehicleDriverID", _nVehicleDriverID);
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
                cmd.CommandText = "SELECT * FROM t_VehicleDriver where VehicleDriverID =?";
                cmd.Parameters.AddWithValue("VehicleDriverID", _nVehicleDriverID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nVehicleDriverID = (int)reader["VehicleDriverID"];
                    _sVehicleDriverName = (string)reader["VehicleDriverName"];
                    if (reader["MobileNo"] != DBNull.Value)
                    {
                        _sMobileNo = (string)reader["MobileNo"];
                    }
                    
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
    public class VehicleDrivers : CollectionBaseCustom
    {

        public VehicleDriver this[int i]
        {
            get { return (VehicleDriver)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(VehicleDriver oVehicleDriver)
        {
            InnerList.Add(oVehicleDriver);
        }

        public int GetIndex(int nVehicleDriverID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].VehicleDriverID == nVehicleDriverID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Refresh(string code,string name,string mobile)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_VehicleDriver Where 1=1 ";


            if (!string.IsNullOrEmpty(code))
            {
                sSql += " AND  VehicleDriverCode = '"+ code + "' ";
            }
            if (!string.IsNullOrEmpty(name))
            {
                sSql += " AND  VehicleDriverName LIKE '%" + name + "%' ";
            }
            if (!string.IsNullOrEmpty(mobile))
            {
                sSql += " AND  MobileNo LIKE '%" + mobile + "%' ";
            }

            sSql += " ORDER BY VehicleDriverID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VehicleDriver oVehicleDriver = new VehicleDriver();
                    oVehicleDriver.VehicleDriverID = (int)reader["VehicleDriverID"];
                    oVehicleDriver.VehicleDriverCode = (string)reader["VehicleDriverCode"];
                    oVehicleDriver.VehicleDriverName = (string)reader["VehicleDriverName"];
                    if (reader["MobileNo"] != DBNull.Value)
                    {
                        oVehicleDriver.MobileNo = (string)reader["MobileNo"];
                    }
                    InnerList.Add(oVehicleDriver);
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
