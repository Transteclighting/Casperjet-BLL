// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak Kumar Chakraborty
// Date: Nov 14, 2011
// Time :  4:00 PM
// Description: Class for Vehicle Fuel Type.
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
    public class VehicleFuelType
    {
        private int _nFuelTypeID;
        private string _sFuelTypeName;
        private double _nUnitPrice;
        private string _sUnitName;

        public int FuelTypeID
        {
            get { return _nFuelTypeID; }
            set { _nFuelTypeID = value; }

        }
        public string FuelTypeName
        {
            get { return _sFuelTypeName; }
            set { _sFuelTypeName = value; }

        }
        public double UnitPrice
        {
            get { return _nUnitPrice; }
            set { _nUnitPrice = value; }

        }
        public string UnitName
        {
            get { return _sUnitName; }
            set { _sUnitName = value; }

        }

        public void Add()
        {
            int nMaxFuelTypeID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = " SELECT MAX([FuelTypeID]) FROM t_VehicleFuelType";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxFuelTypeID = 1;
                }
                else
                {
                    nMaxFuelTypeID = Convert.ToInt32(maxID) + 1;
                }
                _nFuelTypeID = nMaxFuelTypeID;

                sSql = "INSERT INTO t_VehicleFuelType VALUES(?,?,?,?) ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("FuelTypeID", _nFuelTypeID);
                cmd.Parameters.AddWithValue("FuelTypeName", _sFuelTypeName);
                cmd.Parameters.AddWithValue("UnitPrice", _nUnitPrice);
                cmd.Parameters.AddWithValue("UnitName", _sUnitName);
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

                sSql = "UPDATE t_VehicleFuelType SET FuelTypeName=?,UnitName=?, UnitPrice=? "
                    + " WHERE FuelTypeID= ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
               
                cmd.Parameters.AddWithValue("FuelTypeName", _sFuelTypeName);
                cmd.Parameters.AddWithValue("UnitName", _sUnitName);
                cmd.Parameters.AddWithValue("UnitPrice", _nUnitPrice);
                cmd.Parameters.AddWithValue("FuelTypeID", _nFuelTypeID);
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
                sSql = "DELETE FROM t_VehicleFuelType WHERE [FuelTypeID]= ? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("FuelTypeID", _nFuelTypeID);
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
                cmd.CommandText = "SELECT * FROM t_VehicleFuelType where FuelTypeID =?";
                cmd.Parameters.AddWithValue("FuelTypeID", _nFuelTypeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nFuelTypeID = (int)reader["FuelTypeID"];
                    _sFuelTypeName = (string)reader["FuelTypeName"];
                    _nUnitPrice = (double)reader["UnitPrice"];
                    _sUnitName = (string)reader["UnitName"];
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshbyFuelName()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_VehicleFuelType where FuelTypeName =?";
                cmd.Parameters.AddWithValue("FuelTypeName", _sFuelTypeName);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nFuelTypeID = (int)reader["FuelTypeID"];
                    _sFuelTypeName = (string)reader["FuelTypeName"];
                    _nUnitPrice = (double)reader["UnitPrice"];
                    _sUnitName = (string)reader["UnitName"];
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
    public class VehicleFuelTypes : CollectionBase
    {
        public VehicleFuelType this[int i]
        {
            get { return (VehicleFuelType)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(VehicleFuelType oVehicleFuelType)
        {
            InnerList.Add(oVehicleFuelType);
        }
        public int GetIndex(int nFuelTypeID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].FuelTypeID == nFuelTypeID)
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

            string sSql = "SELECT * FROM t_VehicleFuelType ORDER BY FuelTypeID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VehicleFuelType oVehicleFuelType = new VehicleFuelType();

                    oVehicleFuelType.FuelTypeID = (int)reader["FuelTypeID"];
                    oVehicleFuelType.FuelTypeName = (string)reader["FuelTypeName"];
                    oVehicleFuelType.UnitPrice = (double)reader["UnitPrice"];
                    oVehicleFuelType.UnitName = (string) reader["UnitName"];
                    InnerList.Add(oVehicleFuelType);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetFuelTypeName()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " SELECT * FROM t_VehiclefuelType ";
          
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VehicleFuelType oVehicleFuelType = new VehicleFuelType();

                    oVehicleFuelType.FuelTypeID = int.Parse(reader["FuelTypeID"].ToString());
                    oVehicleFuelType.FuelTypeName = (string)reader["FuelTypeName"].ToString();                    
                    oVehicleFuelType.UnitPrice =Convert.ToDouble( reader["UnitPrice"].ToString());
                    oVehicleFuelType.UnitName =  (string) reader["UnitName"].ToString();                    
                    InnerList.Add(oVehicleFuelType);
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
