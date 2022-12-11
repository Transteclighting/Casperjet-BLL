// <summary>
// Compamy: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Apr 21, 2016
// Time : 12:22 PM
// Description: Class for ProjectApproval.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.IT
{
    public class ProjectApproval
    {
        private int _nProjectApprovalID;
        private string _sProjectName;
        private int _nProjectType;
        private string _sProjectOwner;
        private int _nSystem;
        private string _sObjective;
        private DateTime _dStartDate;
        private DateTime _dEndDate;
        private string _sManDay;
        private string _sCost;
        private string _sResources;
        private string _sProjectFeatures;
        private string _sWeakness;
        private string _sRemarks;


        // <summary>
        // Get set property for ProjectApprovalID
        // </summary>
        public int ProjectApprovalID
        {
            get { return _nProjectApprovalID; }
            set { _nProjectApprovalID = value; }
        }

        // <summary>
        // Get set property for ProjectName
        // </summary>
        public string ProjectName
        {
            get { return _sProjectName; }
            set { _sProjectName = value.Trim(); }
        }

        // <summary>
        // Get set property for ProjectType
        // </summary>
        public int ProjectType
        {
            get { return _nProjectType; }
            set { _nProjectType = value; }
        }

        // <summary>
        // Get set property for ProjectOwner
        // </summary>
        public string ProjectOwner
        {
            get { return _sProjectOwner; }
            set { _sProjectOwner = value.Trim(); }
        }

        // <summary>
        // Get set property for System
        // </summary>
        public int System
        {
            get { return _nSystem; }
            set { _nSystem = value; }
        }

        // <summary>
        // Get set property for Objective
        // </summary>
        public string Objective
        {
            get { return _sObjective; }
            set { _sObjective = value.Trim(); }
        }

        // <summary>
        // Get set property for StartDate
        // </summary>
        public DateTime StartDate
        {
            get { return _dStartDate; }
            set { _dStartDate = value; }
        }

        // <summary>
        // Get set property for EndDate
        // </summary>
        public DateTime EndDate
        {
            get { return _dEndDate; }
            set { _dEndDate = value; }
        }

        // <summary>
        // Get set property for ManDay
        // </summary>
        public string ManDay
        {
            get { return _sManDay; }
            set { _sManDay = value.Trim(); }
        }

        // <summary>
        // Get set property for Cost
        // </summary>
        public string Cost
        {
            get { return _sCost; }
            set { _sCost = value.Trim(); }
        }

        // <summary>
        // Get set property for Resources
        // </summary>
        public string Resources
        {
            get { return _sResources; }
            set { _sResources = value.Trim(); }
        }

        // <summary>
        // Get set property for ProjectFeatures
        // </summary>
        public string ProjectFeatures
        {
            get { return _sProjectFeatures; }
            set { _sProjectFeatures = value.Trim(); }
        }

        // <summary>
        // Get set property for Weakness
        // </summary>
        public string Weakness
        {
            get { return _sWeakness; }
            set { _sWeakness = value.Trim(); }
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
            int nMaxProjectApprovalID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ProjectApprovalID]) FROM t_ProjectApproval";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxProjectApprovalID = 1;
                }
                else
                {
                    nMaxProjectApprovalID = Convert.ToInt32(maxID) + 1;
                }
                _nProjectApprovalID = nMaxProjectApprovalID;
                sSql = "INSERT INTO t_ProjectApproval (ProjectApprovalID, ProjectName, ProjectType, ProjectOwner, System, Objective, StartDate, EndDate, ManDay, Cost, Resources, ProjectFeatures, Weakness, Remarks) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProjectApprovalID", _nProjectApprovalID);
                cmd.Parameters.AddWithValue("ProjectName", _sProjectName);
                cmd.Parameters.AddWithValue("ProjectType", _nProjectType);
                cmd.Parameters.AddWithValue("ProjectOwner", _sProjectOwner);
                cmd.Parameters.AddWithValue("System", _nSystem);
                cmd.Parameters.AddWithValue("Objective", _sObjective);
                cmd.Parameters.AddWithValue("StartDate", _dStartDate);
                cmd.Parameters.AddWithValue("EndDate", _dEndDate);
                cmd.Parameters.AddWithValue("ManDay", _sManDay);
                cmd.Parameters.AddWithValue("Cost", _sCost);
                cmd.Parameters.AddWithValue("Resources", _sResources);
                cmd.Parameters.AddWithValue("ProjectFeatures", _sProjectFeatures);
                cmd.Parameters.AddWithValue("Weakness", _sWeakness);
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
                sSql = "UPDATE t_ProjectApproval SET ProjectName = ?, ProjectType = ?, ProjectOwner = ?, System = ?, Objective = ?, StartDate = ?, EndDate = ?, ManDay = ?, Cost = ?, Resources = ?, ProjectFeatures = ?, Weakness = ?, Remarks = ? WHERE ProjectApprovalID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProjectName", _sProjectName);
                cmd.Parameters.AddWithValue("ProjectType", _nProjectType);
                cmd.Parameters.AddWithValue("ProjectOwner", _sProjectOwner);
                cmd.Parameters.AddWithValue("System", _nSystem);
                cmd.Parameters.AddWithValue("Objective", _sObjective);
                cmd.Parameters.AddWithValue("StartDate", _dStartDate);
                cmd.Parameters.AddWithValue("EndDate", _dEndDate);
                cmd.Parameters.AddWithValue("ManDay", _sManDay);
                cmd.Parameters.AddWithValue("Cost", _sCost);
                cmd.Parameters.AddWithValue("Resources", _sResources);
                cmd.Parameters.AddWithValue("ProjectFeatures", _sProjectFeatures);
                cmd.Parameters.AddWithValue("Weakness", _sWeakness);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("ProjectApprovalID", _nProjectApprovalID);

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
                sSql = "DELETE FROM t_ProjectApproval WHERE [ProjectApprovalID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProjectApprovalID", _nProjectApprovalID);
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
                cmd.CommandText = "SELECT * FROM t_ProjectApproval where ProjectApprovalID =?";
                cmd.Parameters.AddWithValue("ProjectApprovalID", _nProjectApprovalID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nProjectApprovalID = (int)reader["ProjectApprovalID"];
                    _sProjectName = (string)reader["ProjectName"];
                    _nProjectType = (int)reader["ProjectType"];
                    _sProjectOwner = (string)reader["ProjectOwner"];
                    _nSystem = (int)reader["System"];
                    _sObjective = (string)reader["Objective"];
                    _dStartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                    _dEndDate = Convert.ToDateTime(reader["EndDate"].ToString());
                    _sManDay = (string)reader["ManDay"];
                    _sCost = (string)reader["Cost"];
                    _sResources = (string)reader["Resources"];
                    _sProjectFeatures = (string)reader["ProjectFeatures"];
                    _sWeakness = (string)reader["Weakness"];
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
    public class ProjectApprovals : CollectionBase
    {
        public ProjectApproval this[int i]
        {
            get { return (ProjectApproval)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ProjectApproval oProjectApproval)
        {
            InnerList.Add(oProjectApproval);
        }
        public int GetIndex(int nProjectApprovalID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ProjectApprovalID == nProjectApprovalID)
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
            string sSql = "SELECT * FROM t_ProjectApproval";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProjectApproval oProjectApproval = new ProjectApproval();
                    oProjectApproval.ProjectApprovalID = (int)reader["ProjectApprovalID"];
                    oProjectApproval.ProjectName = (string)reader["ProjectName"];
                    oProjectApproval.ProjectType = (int)reader["ProjectType"];
                    oProjectApproval.ProjectOwner = (string)reader["ProjectOwner"];
                    oProjectApproval.System = (int)reader["System"];
                    oProjectApproval.Objective = (string)reader["Objective"];
                    oProjectApproval.StartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                    oProjectApproval.EndDate = Convert.ToDateTime(reader["EndDate"].ToString());
                    oProjectApproval.ManDay = (string)reader["ManDay"];
                    oProjectApproval.Cost = (string)reader["Cost"];
                    oProjectApproval.Resources = (string)reader["Resources"];
                    oProjectApproval.ProjectFeatures = (string)reader["ProjectFeatures"];
                    oProjectApproval.Weakness = (string)reader["Weakness"];
                    oProjectApproval.Remarks = (string)reader["Remarks"];
                    InnerList.Add(oProjectApproval);
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


