
// <summary>
// Company: Transcom Electronics Limited
// Author: Abdul Hakim
// Date: Nov 07, 2016
// Time : 03:12 PM
// Description: Class for HRPositionAssignHistory.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.HR
{
    public class HRPositionAssignHistory
    {
        private int _nID;
        private int _nPositionID;
        private int _nEmployeeID;
        private DateTime _dFromDate;
        private object _dToDate;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private string _sRemarks;
        private string _sEmployeeCode;
        private string _sEmployeeName;
        private string _sDesignationName;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for PositionID
        // </summary>
        public int PositionID
        {
            get { return _nPositionID; }
            set { _nPositionID = value; }
        }

        // <summary>
        // Get set property for EmployeeID
        // </summary>
        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }

        // <summary>
        // Get set property for FromDate
        // </summary>
        public DateTime FromDate
        {
            get { return _dFromDate; }
            set { _dFromDate = value; }
        }

        // <summary>
        // Get set property for ToDate
        // </summary>
        public object ToDate
        {
            get { return _dToDate; }
            set { _dToDate = value; }
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
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }

        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value; }
        }

        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value; }
        }


        public string DesignationName
        {
            get { return _sDesignationName; }
            set { _sDesignationName = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_HRPositionAssignHistory";
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
                sSql = "INSERT INTO t_HRPositionAssignHistory (ID, PositionID, EmployeeID, FromDate, CreateUserID, CreateDate, Remarks) VALUES (?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("PositionID", _nPositionID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

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
                sSql = "UPDATE t_HRPositionAssignHistory SET PositionID = ?, EmployeeID = ?, FromDate = ?, ToDate = ?, CreateUserID = ?, CreateDate = ?, UpdateUserID = ?, UpdateDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PositionID", _nPositionID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Update()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_HRPositionAssignHistory SET EmployeeID = ?, FromDate = ?, Remarks = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateToDate()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_HRPositionAssignHistory SET ToDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ToDate", _dFromDate);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateToDateWithRemarks()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_HRPositionAssignHistory SET ToDate = ?, Remarks = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

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
                sSql = "DELETE FROM t_HRPositionAssignHistory WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_HRPositionAssignHistory where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nPositionID = (int)reader["PositionID"];
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _dFromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    _dToDate = (object)reader["ToDate"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetAssignData(int nPositionID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = " Select a.ID, PositionID, FromDate, ToDate, Remarks, EmployeeID, EmployeeCode  from  " +
                                  " (Select Max(ID) as ID from dbo.t_HRPositionAssignHistory Where PositionID = " + nPositionID + ") a, " +
                                  " (Select ID, PositionID, FromDate, ToDate, Remarks, a.EmployeeID, EmployeeCode from dbo.t_HRPositionAssignHistory a, t_Employee b " +
                                  " Where a.EmployeeID = b.EmployeeID )b Where a.ID = b.ID ";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nPositionID = (int)reader["PositionID"];
                    _dFromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    _dToDate = (object)reader["ToDate"];
                    _sRemarks = (string)reader["Remarks"];
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _sEmployeeCode = (string)reader["EmployeeCode"];

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
    public class HRPositionAssignHistorys : CollectionBase
    {
        public HRPositionAssignHistory this[int i]
        {
            get { return (HRPositionAssignHistory)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HRPositionAssignHistory oHRPositionAssignHistory)
        {
            InnerList.Add(oHRPositionAssignHistory);
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
        public void Refresh(int nPositionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select ID, PositionID, FromDate, ToDate, CreateUserID, CreateDate, Remarks, a.EmployeeID, EmployeeCode, " +
                          " EmployeeName, DesignationName from dbo.t_HRPositionAssignHistory a, v_EmployeeDetails b Where a.EmployeeID = b.EmployeeID and PositionID = " + nPositionID + " Order by ID Desc ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRPositionAssignHistory oHRPositionAssignHistory = new HRPositionAssignHistory();

                    oHRPositionAssignHistory.ID = (int)reader["ID"];
                    oHRPositionAssignHistory.PositionID = (int)reader["PositionID"];
                    oHRPositionAssignHistory.EmployeeID = (int)reader["EmployeeID"];
                    oHRPositionAssignHistory.EmployeeCode = (string)reader["EmployeeCode"];
                    oHRPositionAssignHistory.EmployeeName = (string)reader["EmployeeName"];
                    oHRPositionAssignHistory.DesignationName = (string)reader["DesignationName"];
                    oHRPositionAssignHistory.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    if (reader["ToDate"] != DBNull.Value)
                        oHRPositionAssignHistory.ToDate = (object)reader["ToDate"];
                    else
                        oHRPositionAssignHistory.ToDate = "Till now";
                    oHRPositionAssignHistory.CreateUserID = (int)reader["CreateUserID"];
                    oHRPositionAssignHistory.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    oHRPositionAssignHistory.Remarks = (string)reader["Remarks"];
                    
                    InnerList.Add(oHRPositionAssignHistory);
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


