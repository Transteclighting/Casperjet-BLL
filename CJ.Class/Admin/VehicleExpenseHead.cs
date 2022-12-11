// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak Kumar Chakraborty
// Date: Nov 14, 2011
// Time :  4:00 PM
// Description: Class for Vehicle expense Head.
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
    public class VehicleExpenseHead
    {
        private int _nExpenseHeadID;
        private string _sExpenseHeadCode;
        private string _sExpenseHeadName;
        private int _nExpenseHeadType;
        private double _UnitPrice;
        private string _unitName;
        
        public int ExpenseHeadID
        {
            get { return _nExpenseHeadID; }
            set { _nExpenseHeadID = value; }

        }
        public string ExpenseHeadCode
        {
            get { return _sExpenseHeadCode; }
            set { _sExpenseHeadCode = value; }

        }
        public string ExpenseHeadName
        {
            get { return _sExpenseHeadName; }
            set { _sExpenseHeadName = value; }

        }

        public int ExpenseHeadType
        {
            get { return _nExpenseHeadType; }
            set { _nExpenseHeadType = value; }
        }
        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }
        public string UnitName
        {
            get { return _unitName; }
            set { _unitName = value; }
        }

        public void RefreshExpenseHeadName()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_VehicleExpenseHead where ExpenseheadName =?";
                cmd.Parameters.AddWithValue("Expenseheadname", _sExpenseHeadName);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nExpenseHeadID = (int)reader["ExpenseheadID"];
                    _sExpenseHeadCode = (string)reader["ExpenseHeadCode"];
                    _sExpenseHeadName = (string)reader["ExpenseHeadName"];
                    _nExpenseHeadType = (int)reader["ExpenseheadType"];
                    _UnitPrice = Convert.ToDouble(reader["UnitPrice"]);
                    _unitName = (string)reader["UnitName"];
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void Add()
        {
            int nMaxExpenseHeadID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ExpenseHeadID]) FROM t_VehicleExpenseHead";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxExpenseHeadID = 1;
                }
                else
                {
                    nMaxExpenseHeadID = Convert.ToInt32(maxID) + 1;
                }
                _nExpenseHeadID = nMaxExpenseHeadID;

                sSql = "INSERT INTO t_VehicleExpenseHead VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ExpenseHeadID", _nExpenseHeadID);
                cmd.Parameters.AddWithValue("ExpenseHeadCode", _sExpenseHeadCode);
                cmd.Parameters.AddWithValue("ExpenseHeadName", _sExpenseHeadName);
                cmd.Parameters.AddWithValue("ExpenseHeadType", _nExpenseHeadType);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                cmd.Parameters.AddWithValue("UnitName", _unitName);
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

                sSql = "UPDATE t_VehicleExpenseHead SET ExpenseHeadCode=?, ExpenseHeadName=?,ExpenseHeadType=?,UnitPrice=?,UnitName=?  "
                    + " WHERE ExpenseHeadID= ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ExpenseHeadID", _nExpenseHeadID);
                cmd.Parameters.AddWithValue("ExpenseHeadCode", _sExpenseHeadCode);
                cmd.Parameters.AddWithValue("ExpenseHeadName", _sExpenseHeadName);
                cmd.Parameters.AddWithValue("ExpenseHeadType", _nExpenseHeadType);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                cmd.Parameters.AddWithValue("UnitName", _unitName);

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
                sSql = "DELETE FROM t_VehicleExpenseHead WHERE [ExpenseHeadID]= ? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ExpenseHeadID", _nExpenseHeadID);
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
                cmd.CommandText = "SELECT * FROM t_VehicleExpenseHead where ExpenseHeadID =?";
                cmd.Parameters.AddWithValue("ExpenseHeadID", _nExpenseHeadID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nExpenseHeadID = (int)reader["ExpenseheadID"];
                    _sExpenseHeadCode = (string)reader["ExpenseHeadCode"];
                    _sExpenseHeadName = (string)reader["ExpenseHeadName"];
                    _nExpenseHeadType = (int)reader["ExpenseheadType"];
                    _UnitPrice = Convert.ToDouble(reader["UnitPrice"]);
                    _unitName = (string)reader["UnitName"];
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

    public class VehicleExpenseHeads : CollectionBaseCustom
    {

        public VehicleExpenseHead this[int i]
        {
            get { return (VehicleExpenseHead)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(VehicleExpenseHead oVehicleExpenseHead)
        {
            InnerList.Add(oVehicleExpenseHead);
        }

        public int GetIndex(int nExpenseHeadID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ExpenseHeadID == nExpenseHeadID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Refresh()
        {
            VehicleExpenseHead oVehicleExpenseHead; 
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " SELECT * FROM t_VehicleExpenseHead ORDER BY ExpenseHeadID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oVehicleExpenseHead = new VehicleExpenseHead();
                    oVehicleExpenseHead.ExpenseHeadID = (int)reader["ExpenseHeadID"];
                    oVehicleExpenseHead.ExpenseHeadCode = (string)reader["ExpenseHeadCode"];
                    oVehicleExpenseHead.ExpenseHeadName = (string)reader["ExpenseHeadName"];
                    oVehicleExpenseHead.ExpenseHeadType = (int)reader["ExpenseHeadType"];
                    oVehicleExpenseHead.UnitPrice =Convert.ToDouble (reader["UnitPrice"]);
                    oVehicleExpenseHead.UnitName = (string)reader["UnitName"];
                    InnerList.Add(oVehicleExpenseHead);
                }
                reader.Close();
                
                oVehicleExpenseHead = new VehicleExpenseHead();
                oVehicleExpenseHead.ExpenseHeadID = -1;
                oVehicleExpenseHead.ExpenseHeadName = "ALL";
                InnerList.Add(oVehicleExpenseHead);
                InnerList.TrimToSize();
                cmd.ExecuteNonQuery();
                cmd.Dispose();  
            

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetExpanseHeadName()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " SELECT * FROM t_VehicleExpenseHead order by ExpenseheadID desc ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VehicleExpenseHead oVehicleExpenseHead = new VehicleExpenseHead();
                    oVehicleExpenseHead.ExpenseHeadID = int.Parse(reader["ExpenseHeadID"].ToString());
                    oVehicleExpenseHead.ExpenseHeadCode = (string)reader["ExpenseHeadCode"].ToString();
                    oVehicleExpenseHead.ExpenseHeadName = (string)reader["ExpenseHeadName"].ToString();
                    oVehicleExpenseHead.ExpenseHeadType = int.Parse(reader["ExpenseHeadType"].ToString());
                    oVehicleExpenseHead.UnitPrice =Convert.ToDouble(reader["UnitPrice"].ToString());
                    oVehicleExpenseHead.UnitName = (string)reader["UnitName"].ToString();
                    InnerList.Add(oVehicleExpenseHead);
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
