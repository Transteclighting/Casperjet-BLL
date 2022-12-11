// <summary>
// Compamy: Transcom Electronics Limited
// Author: MD. Abdul Hakim
// Date: Apr 20, 2015
// Time : 05:11 PM
// Description: Class for PlanBudgetTargetVersion.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Plan
{
    public class PlanBudgetTargetVersion
    {
        private int _nVersionNo;
        private string _sVersionName;
        private DateTime _dVersionDate;
        private int _nType;
        private int _nStatus;
        private string _sRemarks;

        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;

        // <summary>
        // Get set property for VersionNo
        // </summary>
        public int VersionNo
        {
            get { return _nVersionNo; }
            set { _nVersionNo = value; }
        }

        // <summary>
        // Get set property for VersionName
        // </summary>
        public string VersionName
        {
            get { return _sVersionName; }
            set { _sVersionName = value.Trim(); }
        }

        // <summary>
        // Get set property for VersionDate
        // </summary>
        public DateTime VersionDate
        {
            get { return _dVersionDate; }
            set { _dVersionDate = value; }
        }

        // <summary>
        // Get set property for Type
        // </summary>
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
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
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        public void Add()
        {
            int nMaxVersionNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([VersionNo]) FROM t_PlanBudgetTargetVersion";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxVersionNo = 1;
                }
                else
                {
                    nMaxVersionNo = Convert.ToInt32(maxID) + 1;
                }
                _nVersionNo = nMaxVersionNo;
                sSql = "INSERT INTO t_PlanBudgetTargetVersion (VersionNo, VersionName, VersionDate, Type, Status, Remarks,CreateUserID,CreateDate) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("VersionNo", _nVersionNo);
                cmd.Parameters.AddWithValue("VersionName", _sVersionName);
                cmd.Parameters.AddWithValue("VersionDate", _dVersionDate);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
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
                sSql = "UPDATE t_PlanBudgetTargetVersion SET VersionName = ?, VersionDate = ?, Type = ?, Status = ?, Remarks = ?, UpdateUserID=?, UpdateDate=? WHERE VersionNo = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("VersionName", _sVersionName);
                cmd.Parameters.AddWithValue("VersionDate", _dVersionDate);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("VersionNo", _nVersionNo);

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
                sSql = "DELETE FROM t_PlanBudgetTargetVersion WHERE [VersionNo]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("VersionNo", _nVersionNo);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DeleteDetail(string sDeleteTableName)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM " + sDeleteTableName + " WHERE [VersionNo]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("VersionNo", _nVersionNo);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteByDealerMAGTarget(int _nVersionNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_PlanBudgetTargetVersion WHERE VersionNo="+ _nVersionNo + "";
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
        public void UpdateStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Update t_PlanBudgetTargetVersion SET Status=? WHERE [VersionNo]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("VersionNo", _nVersionNo);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateStatusByDealerMAGTarget(int nVersionNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Update t_PlanBudgetTargetVersion SET Status=2 WHERE VersionNo="+ nVersionNo + "";
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
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_PlanBudgetTargetVersion where VersionNo =?";
                cmd.Parameters.AddWithValue("VersionNo", _nVersionNo);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nVersionNo = (int)reader["VersionNo"];
                    _sVersionName = (string)reader["VersionName"];
                    _dVersionDate = Convert.ToDateTime(reader["VersionDate"].ToString());
                    _nType = (int)reader["Type"];
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
    public class PlanBudgetTargetVersions : CollectionBase
    {
        public PlanBudgetTargetVersion this[int i]
        {
            get { return (PlanBudgetTargetVersion)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(PlanBudgetTargetVersion oPlanBudgetTargetVersion)
        {
            InnerList.Add(oPlanBudgetTargetVersion);
        }
        public int GetIndex(int nVersionNo)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].VersionNo == nVersionNo)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(DateTime dFromDate, DateTime dToDate, bool IsCheck)
        {
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_PlanBudgetTargetVersion where Type<>4 and 1=1 ";
            if (IsCheck == false)
            {
                sSql = sSql + " and VersionDate between '" + dFromDate + "' and '" + dToDate + "' and VersionDate < '" + dToDate + "' ";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PlanBudgetTargetVersion oPlanBudgetTargetVersion = new PlanBudgetTargetVersion();
                    oPlanBudgetTargetVersion.VersionNo = (int)reader["VersionNo"];
                    oPlanBudgetTargetVersion.VersionName = (string)reader["VersionName"];
                    oPlanBudgetTargetVersion.VersionDate = Convert.ToDateTime(reader["VersionDate"].ToString());
                    if (reader["Type"] != DBNull.Value)
                    {
                        oPlanBudgetTargetVersion.Type = (int)reader["Type"];
                    }
                    else
                    {
                        oPlanBudgetTargetVersion.Type = (int)Dictionary.PlanVersionType.ExecutiveWeekTarget;
                    }
                    if (reader["Status"] != DBNull.Value)
                    {
                        oPlanBudgetTargetVersion.Status = (int)reader["Status"];
                    }
                    else
                    {
                        oPlanBudgetTargetVersion.Status = (int)Dictionary.PlanVersionStatus.Submit;
                    }
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oPlanBudgetTargetVersion.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oPlanBudgetTargetVersion.Remarks = "";
                    }
                    InnerList.Add(oPlanBudgetTargetVersion);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshCustomerTarget(DateTime dFromDate, DateTime dToDate, bool IsCheck)
        {
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_PlanBudgetTargetVersion where Type=4 and 1=1 ";
            if (IsCheck == false)
            {
                sSql = sSql + " and VersionDate between '" + dFromDate + "' and '" + dToDate + "' and VersionDate < '" + dToDate + "' ";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PlanBudgetTargetVersion oPlanBudgetTargetVersion = new PlanBudgetTargetVersion();
                    oPlanBudgetTargetVersion.VersionNo = (int)reader["VersionNo"];
                    oPlanBudgetTargetVersion.VersionName = (string)reader["VersionName"];
                    oPlanBudgetTargetVersion.VersionDate = Convert.ToDateTime(reader["VersionDate"].ToString());
                    if (reader["Type"] != DBNull.Value)
                    {
                        oPlanBudgetTargetVersion.Type = (int)reader["Type"];
                    }
                    else
                    {
                        oPlanBudgetTargetVersion.Type = (int)Dictionary.PlanVersionType.ExecutiveWeekTarget;
                    }
                    if (reader["Status"] != DBNull.Value)
                    {
                        oPlanBudgetTargetVersion.Status = (int)reader["Status"];
                    }
                    else
                    {
                        oPlanBudgetTargetVersion.Status = (int)Dictionary.PlanVersionStatus.Submit;
                    }
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oPlanBudgetTargetVersion.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oPlanBudgetTargetVersion.Remarks = "";
                    }
                    InnerList.Add(oPlanBudgetTargetVersion);
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


