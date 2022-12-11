// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: Nov 2, 2011
// Time :  12:00 PM
// Description: Class for Vehicle User.
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

    public class VehicleUser
    {

        private int _nVehicleUserID;
        private string _sVehicleUserName;
        private DateTime _dJoiningDate;
        private string _sDesignation;
        private double _nMaxFuelLimit;
        private double _nMaxMaintenanceLimit;


        public int VehicleUserID
        {
            get { return _nVehicleUserID; }
            set { _nVehicleUserID = value; }

        }
        public string VehicleUserName
        {
            get { return _sVehicleUserName; }
            set { _sVehicleUserName = value; }
        }

        public DateTime JoiningDate
        {
            get { return _dJoiningDate; }
            set { _dJoiningDate = value; }
        }

        public string Designation
        {
            get { return _sDesignation; }
            set { _sDesignation = value; }

        }

        public double MaxFuelLimit
        {
            get { return _nMaxFuelLimit; }
            set { _nMaxFuelLimit = value; }
        }

        public double MaxMaintenanceLimit
        {
            get { return _nMaxMaintenanceLimit; }
            set { _nMaxMaintenanceLimit = value; }
        }




       
        public void Add()
        {
            int nMaxVehicleUserID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([VehicleUserID]) FROM t_VehicleUser";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxVehicleUserID = 1;
                }
                else
                {
                    nMaxVehicleUserID = Convert.ToInt32(maxID) + 1;
                }
                _nVehicleUserID = nMaxVehicleUserID;

                sSql = "INSERT INTO t_VehicleUser VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("VehicleUserID", _nVehicleUserID);                
                cmd.Parameters.AddWithValue("VehicleUserName", _sVehicleUserName);
                cmd.Parameters.AddWithValue("JoiningDate", _dJoiningDate);
                cmd.Parameters.AddWithValue("Designation", _sDesignation);
                cmd.Parameters.AddWithValue("MaxFuelLimit", _nMaxFuelLimit);
                cmd.Parameters.AddWithValue("MaxMaintenanceLimit", _nMaxMaintenanceLimit);
                

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

                sSql = "UPDATE t_VehicleUser SET VehicleUsername=?,JoiningDate=?,  Designation=?, MaxFuelLimit=?, MaxMaintenanceLimit=?"
                    + " WHERE VehicleUserID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("VehicleUsername", _sVehicleUserName);
                cmd.Parameters.AddWithValue("JoiningDate", _dJoiningDate);
                cmd.Parameters.AddWithValue("Designation", _sDesignation);
                cmd.Parameters.AddWithValue("MaxFuelLimit", _nMaxFuelLimit);
                cmd.Parameters.AddWithValue("MaxMaintenanceLimit", _nMaxMaintenanceLimit);
                
                cmd.Parameters.AddWithValue("VehicleUserID", _nVehicleUserID);

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
                sSql = "DELETE FROM t_VehicleUser WHERE [VehicleUserID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("VehicleUserID", _nVehicleUserID);
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
                cmd.CommandText = "SELECT * FROM t_VehicleUser where VehicleUserID =?";
                cmd.Parameters.AddWithValue("VehicleUserID", _nVehicleUserID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nVehicleUserID = (int)reader["VehicleUserID"];
                    _sVehicleUserName = (string)reader["VehicleUsername"];
                    _dJoiningDate =Convert.ToDateTime(reader["JoiningDate"]);
                    _sDesignation = (string)reader["Designation"];
                    _nMaxFuelLimit =Convert.ToDouble( reader["MaxFuelLimit"]);
                    _nMaxMaintenanceLimit = Convert.ToDouble(reader["MaxMaintenanceLimit"]);
                    
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


    public class VehicleUsers : CollectionBaseCustom
    {

        public VehicleUser this[int i]
        {
            get { return (VehicleUser)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(VehicleUser oVehicleUser)
        {
            InnerList.Add(oVehicleUser);
        }

        public int GetIndex(int nVehicleUserID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].VehicleUserID == nVehicleUserID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void FromDataSet(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    VehicleUser oVehicleUser = new VehicleUser();

                    oVehicleUser.VehicleUserID = (int)oRow["VehicleUserID"];
                    oVehicleUser.VehicleUserName = (string)oRow["VehicleUserName"];
                    oVehicleUser.JoiningDate = (DateTime)(oRow["JoiningDate"]);
                    oVehicleUser.Designation = (string)oRow["Designation"];
                    oVehicleUser.MaxFuelLimit = Convert.ToDouble(oRow["MaxFuelLimit"]);
                    oVehicleUser.MaxMaintenanceLimit = Convert.ToDouble(oRow["MaxMaintenanceLimit"]);
                    
                    
                    InnerList.Add(oVehicleUser);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_VehicleUser";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VehicleUser oVehicleUser = new VehicleUser();

                    oVehicleUser.VehicleUserID = (int)reader["VehicleUserID"];
                    oVehicleUser.VehicleUserName = (string)reader["VehicleUserName"];
                    oVehicleUser.JoiningDate = (DateTime)(reader["JoiningDate"]);
                    oVehicleUser.Designation = (string)reader["Designation"];
                    oVehicleUser.MaxFuelLimit = Convert.ToDouble(reader["MaxFuelLimit"]);
                    oVehicleUser.MaxMaintenanceLimit = Convert.ToDouble(reader["MaxMaintenanceLimit"]);

                    InnerList.Add(oVehicleUser);
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
