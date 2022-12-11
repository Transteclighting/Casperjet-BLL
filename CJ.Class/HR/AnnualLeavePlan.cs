// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Mar 22, 2016
// Time : 11:49 AM
// Description: Class for HRAnnualLeavePlan.
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
    public class HRAnnualLeavePlan
    {
        private int _nLeavePlanID;
        private int _nEmployeeID;
        private DateTime _dFromDate;
        private DateTime _dToDate;
        private int _nLeaveTotal;
        private int _nPersonInChargeID;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private string _sEmployeeName;
        private string _sInChargeName;
        private string _sDepartmentName;



        // <summary>
        // Get set property for EmployeeName
        // </summary>
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value; }
        }
        // <summary>
        // Get set property for InChargeName
        // </summary>
        public string InChargeName
        {
            get { return _sInChargeName; }
            set { _sInChargeName = value; }
        }
        // <summary>
        // Get set property for DepartmentName
        // </summary>
        public string DepartmentName
        {
            get { return _sDepartmentName; }
            set { _sDepartmentName = value; }
        }



        // <summary>
        // Get set property for LeavePlanID
        // </summary>
        public int LeavePlanID
        {
            get { return _nLeavePlanID; }
            set { _nLeavePlanID = value; }
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
        public DateTime ToDate
        {
            get { return _dToDate; }
            set { _dToDate = value; }
        }

        // <summary>
        // Get set property for LeaveTotal
        // </summary>
        public int LeaveTotal
        {
            get { return _nLeaveTotal; }
            set { _nLeaveTotal = value; }
        }

        // <summary>
        // Get set property for PersonInChargeID
        // </summary>
        public int PersonInChargeID
        {
            get { return _nPersonInChargeID; }
            set { _nPersonInChargeID = value; }
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

        public void Add()
        {
            int nMaxLeavePlanID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([LeavePlanID]) FROM t_HRAnnualLeavePlan";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxLeavePlanID = 1;
                }
                else
                {
                    nMaxLeavePlanID = Convert.ToInt32(maxID) + 1;
                }
                _nLeavePlanID = nMaxLeavePlanID;
                sSql = "INSERT INTO t_HRAnnualLeavePlan (LeavePlanID, EmployeeID, FromDate, ToDate, LeaveTotal, PersonInChargeID, CreateUserID, CreateDate, UpdateUserID, UpdateDate) VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LeavePlanID", _nLeavePlanID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("LeaveTotal", _nLeaveTotal);
                cmd.Parameters.AddWithValue("PersonInChargeID", _nPersonInChargeID);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);

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
                sSql = "UPDATE t_HRAnnualLeavePlan SET EmployeeID = ?, FromDate = ?, ToDate = ?, LeaveTotal = ?, PersonInChargeID = ?, UpdateUserID = ?, UpdateDate = ? WHERE LeavePlanID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("LeaveTotal", _nLeaveTotal);
                cmd.Parameters.AddWithValue("PersonInChargeID", _nPersonInChargeID);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                cmd.Parameters.AddWithValue("LeavePlanID", _nLeavePlanID);

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
                sSql = "DELETE FROM t_HRAnnualLeavePlan WHERE [LeavePlanID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("LeavePlanID", _nLeavePlanID);
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
                cmd.CommandText = "SELECT * FROM t_HRAnnualLeavePlan where LeavePlanID =?";
                cmd.Parameters.AddWithValue("LeavePlanID", _nLeavePlanID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nLeavePlanID = (int)reader["LeavePlanID"];
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _dFromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    _dToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    _nLeaveTotal = (int)reader["LeaveTotal"];
                    _nPersonInChargeID = (int)reader["PersonInChargeID"];
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
    }
    public class HRAnnualLeavePlans : CollectionBase
    {
        public HRAnnualLeavePlan this[int i]
        {
            get { return (HRAnnualLeavePlan)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HRAnnualLeavePlan oHRAnnualLeavePlan)
        {
            InnerList.Add(oHRAnnualLeavePlan);
        }
        public int GetIndex(int nLeavePlanID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].LeavePlanID == nLeavePlanID)
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
            string sSql = "SELECT * FROM t_HRAnnualLeavePlan";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRAnnualLeavePlan oHRAnnualLeavePlan = new HRAnnualLeavePlan();
                    oHRAnnualLeavePlan.LeavePlanID = (int)reader["LeavePlanID"];
                    oHRAnnualLeavePlan.EmployeeID = (int)reader["EmployeeID"];
                    oHRAnnualLeavePlan.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oHRAnnualLeavePlan.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    oHRAnnualLeavePlan.LeaveTotal = (int)reader["LeaveTotal"];
                    oHRAnnualLeavePlan.PersonInChargeID = (int)reader["PersonInChargeID"];
                    oHRAnnualLeavePlan.CreateUserID = (int)reader["CreateUserID"];
                    oHRAnnualLeavePlan.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oHRAnnualLeavePlan.UpdateUserID = (int)reader["UpdateUserID"];
                    oHRAnnualLeavePlan.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    InnerList.Add(oHRAnnualLeavePlan);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshData(DateTime dFromDate, DateTime dToDate, string sEmployeeName, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = " Select * From (Select LeavePlanID,a.EmployeeID,+'['+b.EmployeeCode +']'+ b.EmployeeName as EmployeeName, " +
                       " FromDate,ToDate,PersonInChargeID,+'['+c.EmployeeCode +']'+ c.EmployeeName as InChargeName,b.DepartmentName, " +
                       " LeaveTotal,CreateDate,CreateUserID from t_HRAnnualLeavePlan a,v_EmployeeDetails b,v_EmployeeDetails c " +
                       " where a.EmployeeID=b.EmployeeID and c.EmployeeID=a.PersonInChargeID) x where 1=1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate<'" + dToDate + "' ";
            }

            if (sEmployeeName != "")
            {
                sSql = sSql + " AND EmployeeName like '%" + sEmployeeName + "%'";
            }
            sSql = sSql + " Order by LeavePlanID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRAnnualLeavePlan oHRAnnualLeavePlan = new HRAnnualLeavePlan();
                    oHRAnnualLeavePlan.LeavePlanID = (int)reader["LeavePlanID"];
                    oHRAnnualLeavePlan.EmployeeID = (int)reader["EmployeeID"];
                    oHRAnnualLeavePlan.EmployeeName = (string)reader["EmployeeName"];
                    oHRAnnualLeavePlan.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oHRAnnualLeavePlan.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    oHRAnnualLeavePlan.PersonInChargeID = (int)reader["PersonInChargeID"];
                    oHRAnnualLeavePlan.InChargeName = (string)reader["InChargeName"];
                    oHRAnnualLeavePlan.DepartmentName = (string)reader["DepartmentName"];
                    oHRAnnualLeavePlan.LeaveTotal = (int)reader["LeaveTotal"];
                    oHRAnnualLeavePlan.CreateUserID = (int)reader["CreateUserID"];
                    oHRAnnualLeavePlan.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oHRAnnualLeavePlan);
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

