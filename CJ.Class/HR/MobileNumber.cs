// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Jul 17, 2016
// Time : 05:26 PM
// Description: Class for MobileNumber.
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
    public class MobileNumber
    {
        private int _nID;
        private string _sMobileNumber;
        private int _nStatus;
        private int _nDatapacID;
        private int _nSpecialUserCategory;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for MobileNumber
        // </summary>
        public string MobileNo
        {
            get { return _sMobileNumber; }
            set { _sMobileNumber = value.Trim(); }
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
        // Get set property for DatapacID
        // </summary>
        public int DatapacID
        {
            get { return _nDatapacID; }
            set { _nDatapacID = value; }
        }

        // <summary>
        // Get set property for SpecialUserCategory
        // </summary>
        public int SpecialUserCategory
        {
            get { return _nSpecialUserCategory; }
            set { _nSpecialUserCategory = value; }
        }


        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_MobileNumber";
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
                sSql = "INSERT INTO t_MobileNumber (ID, MobileNumber, Status) VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("MobileNumber", _sMobileNumber);
                cmd.Parameters.AddWithValue("Status", _nStatus);

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
                sSql = "UPDATE t_MobileNumber SET MobileNumber = ?, Status = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("MobileNumber", _sMobileNumber);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void ClearMobileNumber()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_MobileNumber SET DatapacID = NULL,SpecialUserCategory = NULL WHERE ID = ?";
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

        public void ClearDatapac()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_MobileNumber SET DatapacID = NULL WHERE ID = ?";
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

        public void AddDatapac()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_MobileNumber SET DatapacID = " + _nDatapacID + " WHERE ID =  " + _nID + " ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddSpecialUserCategory()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_MobileNumber SET SpecialUserCategory = " + _nSpecialUserCategory + " WHERE ID =  " + _nID + " ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
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
                sSql = "DELETE FROM t_MobileNumber WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_MobileNumber where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _sMobileNumber = (string)reader["MobileNumber"];
                    _nStatus = (int)reader["Status"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetMobileDetails()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_MobileNumber where MobileNumber = '" + _sMobileNumber + "' ";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nStatus = (int)reader["Status"];
                    if (reader["DatapacID"] != DBNull.Value)
                    {
                        _nDatapacID = (int)reader["DatapacID"];
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
    public class MobileNumbers : CollectionBase
    {
        public MobileNumber this[int i]
        {
            get { return (MobileNumber)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(MobileNumber oMobileNumber)
        {
            InnerList.Add(oMobileNumber);
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
            string sSql = "SELECT * FROM t_MobileNumber";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MobileNumber oMobileNumber = new MobileNumber();
                    oMobileNumber.ID = (int)reader["ID"];
                    oMobileNumber.MobileNo = (string)reader["MobileNumber"];
                    oMobileNumber.Status = (int)reader["Status"];
                    InnerList.Add(oMobileNumber);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<string> GetWarehouseWiseMobileNo(int warehouseId)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = @"Select MobileNumber From 
                            (
                            Select a.* From t_MarketGroup a,t_MarketGroup b
                            where a.MarketGroupType=2 and a.ParentID=b.MarketGroupID
                            and a.MarketGroupID=(Select MarketGroupID From t_Customer a,t_Showroom b 
                            where a.CustomerID = b.CustomerID and IsPOSActive = 1 
                            and WarehouseID={0})
                            Union All
                            Select a.* From t_MarketGroup a,t_MarketGroup b
                            where a.MarketGroupType=1 and a.MarketGroupID=b.ParentID
                            and b.MarketGroupID=(Select MarketGroupID From t_Customer a,t_Showroom b 
                            where a.CustomerID = b.CustomerID and IsPOSActive = 1 
                            and WarehouseID={1})
                            ) a,
                            (
                            Select EmployeeID,MobileNumber From t_MobileNumber a,t_MobileNumberAssign b
                            where a.ID=b.MobileID and AssignFor=1 and EmployeeID is not null
                            ) b
                            where a.EmployeeID=b.EmployeeID
                            Union All
                            Select MobileNo From t_Showroom where WarehouseID={2} ";
            sSql = string.Format(sSql, warehouseId, warehouseId, warehouseId);
            List<string> mobileNoList = new List<string>();

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader != null && reader.Read())
                {
                    mobileNoList.Add((string)reader["MobileNumber"]);
                }
                reader?.Close();
            }
            catch (Exception ex)
            {
                throw;
            }

            return mobileNoList;
        }
    }
}

