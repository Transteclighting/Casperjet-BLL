// <summary>
// Company: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Dec 19, 2017
// Time : 04:34 PM
// Description: Class for Project.
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
    public class Project
    {
        private int _nProjectID;
        private string _sProjectCode;
        private string _sProjectName;
        private int _nProjectManager;
        private DateTime _dCreateDate;
        private int _nCreateUserID;

        private int _sTaskID;
        public string _sDepartmentName;
        private string _sTask;
        private string _sTaskCreateBy;
        private DateTime _sTaskCreateDate;
        private string _sAssignPerson;
        private DateTime _sStartDate;
        private DateTime _sEndDate;
        private string _nStatus;
        private int _sWorkPercent;
        private string _sRemarks;



        public int TaskID
        {
            get { return _sTaskID; }
            set { _sTaskID = value; }
        }

        public string DepartmentName
        {
            get { return _sDepartmentName; }
            set { _sDepartmentName = value.Trim(); }
        }
        public string Task
        {
            get { return _sTask; }
            set { _sTask = value.Trim(); }
        }

        public string TaskCreateBy
        {
            get { return _sTaskCreateBy; }
            set { _sTaskCreateBy = value.Trim(); }
        }

        public DateTime TaskCreateDate
        {
            get { return _sTaskCreateDate; }
            set { _sTaskCreateDate = value; }
        }

        public string AssignPerson
        {
            get { return _sAssignPerson; }
            set { _sAssignPerson = value.Trim(); }
        }

        public DateTime StartDate
        {
            get { return _sStartDate; }
            set { _sStartDate = value; }
        }
        public DateTime EndDate
        {
            get { return _sEndDate; }
            set { _sEndDate = value; }
        }

        public string Status
        {
            get { return _nStatus; }
            set { _nStatus = value.Trim(); }
        }


        public int WorkPercent
        {
            get { return _sWorkPercent; }
            set { _sWorkPercent = value; }
        }


        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }








        private string _sProjectManagerName;
        public string ProjectManagerName
        {
            get { return _sProjectManagerName; }
            set { _sProjectManagerName = value.Trim(); }
        }
        private int _nDepartment;
        public int Department
        {
            get { return _nDepartment; }
            set { _nDepartment = value; }
        }



        // <summary>
        // Get set property for ProjectID
        // </summary>
        public int ProjectID
        {
            get { return _nProjectID; }
            set { _nProjectID = value; }
        }

        // <summary>
        // Get set property for ProjectCode
        // </summary>
        public string ProjectCode
        {
            get { return _sProjectCode; }
            set { _sProjectCode = value.Trim(); }
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
        // Get set property for ProjectManager
        // </summary>
        public int ProjectManager
        {
            get { return _nProjectManager; }
            set { _nProjectManager = value; }
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
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        // <summary>
        // Get set property for Status
        // </summary>

        // <summary>
        // Get set property for Remarks
        // </summary>


        /// <summary>
        /// 
        /// </summary>
        //public void RefreshTaskDetailRpt()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    int nCount = 0;
        //    try
        //    {
        //        cmd.CommandText = @"
        //            Select h.TaskID,BusinessUnit=Case 
        //            when BusinessUnit=1 then 'Production'
        //            when BusinessUnit=2 then 'TD'
        //            when BusinessUnit=3 then 'Project CAC'
        //            when BusinessUnit=4 then 'Project Lighting'
        //            when BusinessUnit=5 then 'CSD'
        //            when BusinessUnit=6 then 'Common'
        //            else 'Other' end,
        //            ProjectCode,ProjectName,c.EmployeeName as ProjectManager,
        //            d.DepartmentName as ProjectDepartment,SubProjectName,
        //            ProjectType=Case when ProjectType=0 then 'Android' 
        //            when ProjectType=1 then 'Desktop' 
        //            when ProjectType=2 then 'WEB' 
        //            else 'Other' end,Priority,e.DepartmentName as ConcernDepartment,
        //            ProjectSize=Case when ProjectSize=0 then 'Small' 
        //            when ProjectSize=1 then 'Medium' 
        //            when ProjectSize=2 then 'Big' 
        //            else 'Other' end,f.EmployeeName as KeyPerson,
        //            ResourceType=Case when ResourceType=0 then 'Own' 
        //            when ResourceType=1 then 'Third_Party' 
        //            else 'Other' end,CompanyName,h.Description as Task,i.EmployeeName as AssignPerson,
        //            StartDate,EndDate,h.Remarks,Status=Case when h.Status=0 then 'Create' 
        //            when h.Status=1 then 'Planned' 
        //            when h.Status=2 then 'Working' 
        //            when h.Status=3 then 'Done' 
        //            when h.Status=4 then 'Pending' 
        //            when h.Status=5 then 'Cancelled' 
        //            else 'Other' end,WorkPercent,j.TaskCreateBy,j.TaskCreateDate
        //            From t_Project a,
        //            t_ProjectDetail b,
        //            t_Employee c,
        //            t_Department d,
        //            t_Department e,
        //            t_Employee f,
        //            t_company g,t_ProjectDetailTask h,t_Employee i,
        //            (

        //            Select a.TaskID,TaskCreateDate,c.UserFullName as TaskCreateBy 
        //            From 
        //            (
        //            Select TaskID,min(CreateDate) TaskCreateDate,min(HistoryID) HistoryID
        //            From t_ProjectHistory group by TaskID
        //            ) a
        //            join t_ProjectHistory b on a.HistoryID=b.HistoryID
        //            join t_User c on b.CreateUserID=c.UserID
        //            ) j 
        //            where h.TaskID=j.TaskID and a.ProjectID=b.ProjectID and a.ProjectManager=c.EmployeeID
        //            and a.Department=d.DepartmentID and b.ConcernDepartment=e.DepartmentID
        //            and b.KeyPerson=f.EmployeeID and g.companyid=b.company
        //            and b.ProjectID=h.ProjectID and a.ProjectID=h.ProjectID 
        //            and b.SubProjectID=h.SubProjectID and h.AssignPerson=i.EmployeeID
        //            and h.Status not in (3,5)
        //            Order By TaskCreateDate";


        //        cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            //_nProjectID = (int)reader["ProjectID"];
        //            _sTaskID = (int)reader["TaskID"];
        //            _sDepartmentName = (string)reader["ProjectDepartment"];
        //            _sTask = (string)reader["Task"];
        //            _sTaskCreateBy = (string)reader["TaskCreateBy"];
        //            _sTaskCreateDate = Convert.ToDateTime(reader["TaskCreateDate"].ToString());
        //            _sAssignPerson = (string)reader["AssignPerson"];
        //            _sStartDate = Convert.ToDateTime(reader["StartDate"].ToString());
        //            _sEndDate = Convert.ToDateTime(reader["EndDate"].ToString());
        //            _nStatus = (int)reader["Status"];
        //            _sWorkPercent = (int)reader["WorkPercent"];
        //            _sRemarks = (string)reader["Remarks"];
        //            nCount++;
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        public void Add()
        {
            int nMaxProjectID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ProjectID]) FROM t_Project";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxProjectID = 1;
                }
                else
                {
                    nMaxProjectID = Convert.ToInt32(maxID) + 1;
                }
                _nProjectID = nMaxProjectID;
                sSql = "INSERT INTO t_Project (ProjectID, ProjectCode, ProjectName, ProjectManager, CreateDate, CreateUserID, UpdateDate, UpdateUserID , Department, Remarks) VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("ProjectCode", _sProjectCode);
                cmd.Parameters.AddWithValue("ProjectName", _sProjectName);
                cmd.Parameters.AddWithValue("ProjectManager", _nProjectManager);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("Department", _nDepartment);
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
                sSql = "UPDATE t_Project SET ProjectCode = ?, ProjectName = ?, ProjectManager = ?, UpdateDate = ?, UpdateUserID = ?, Department = ?, Remarks = ? WHERE ProjectID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProjectCode", _sProjectCode);
                cmd.Parameters.AddWithValue("ProjectName", _sProjectName);
                cmd.Parameters.AddWithValue("ProjectManager", _nProjectManager);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("Department", _nDepartment);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);

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
                sSql = "DELETE FROM t_Project WHERE [ProjectID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
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
                cmd.CommandText = "SELECT * FROM t_Project where ProjectID =?";
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nProjectID = (int)reader["ProjectID"];
                    _sProjectCode = (string)reader["ProjectCode"];
                    _sProjectName = (string)reader["ProjectName"];
                    _nProjectManager = (int)reader["ProjectManager"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _nStatus = (string)reader["Status"];
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

        public void GetMaxProjectNo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT 'P0000'+ CONVERT(varchar(50), isnull(Max(ProjectID),0)+1) ProjectCode FROM t_Project";
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sProjectCode = (string)reader["ProjectCode"];

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
    public class ProjectDetail : CollectionBase
    {
        public Project this[int i]
        {
            get { return (Project)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(Project oProject)
        {
            InnerList.Add(oProject);
        }

        public int GetIndex(int nProjectID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ProjectID == nProjectID)
                {
                    return i;
                }
            }
            return -1;
        }

        private int _nProjectID;
        private int _nSubProjectID;
        private string _sSubProjectName;
        private int _nProjectType;
        private string _sPriority;
        private int _nConcernDepartment;
        private int _nProjectSize;
        private object _dStartDate;
        private object _dEndDate;
        private int _nKeyPerson;
        private int _nResourceType;
        private int _nCompany;
        private string _sRemarks;
        private double _WorkPercent;
        private int _nStatus;
        private double _ProgressPercent;
        private int _nHistoryID;
        private int _nBusinessunit;
        public int Businessunit
        {
            get { return _nBusinessunit; }
            set { _nBusinessunit = value; }
        } 
        public int HistoryID
        {
            get { return _nHistoryID; }
            set { _nHistoryID = value; }
        } 

        public double ProgressPercent
        {
            get { return _ProgressPercent; }
            set { _ProgressPercent = value; }
        } 

        private int _nTaskID;
        public int TaskID
        {
            get { return _nTaskID; }
            set { _nTaskID = value; }
        }
        private string _sDescription;
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value.Trim(); }
        }
        private int _nAssignPerson;
        public int AssignPerson
        {
            get { return _nAssignPerson; }
            set { _nAssignPerson = value; }
        }
        private string _sAssignPersonName;
        public string AssignPersonName
        {
            get { return _sAssignPersonName; }
            set { _sAssignPersonName = value.Trim(); }
        }

        private string _sProjectCode;
        public string ProjectCode
        {
            get { return _sProjectCode; }
            set { _sProjectCode = value.Trim(); }
        }
        private string _sProjectName;
        public string ProjectName
        {
            get { return _sProjectName; }
            set { _sProjectName = value.Trim(); }
        }
        private int _ProjectManager;
        public int ProjectManager
        {
            get { return _ProjectManager; }
            set { _ProjectManager = value; }
        }
        private string _sProjectManagerName;
        public string ProjectManagerName
        {
            get { return _sProjectManagerName; }
            set { _sProjectManagerName = value.Trim(); }
        }
        private string _sConcernDepartmentName;
        public string ConcernDepartmentName
        {
            get { return _sConcernDepartmentName; }
            set { _sConcernDepartmentName = value.Trim(); }
        }
        private string _sKeyPersonName;
        public string KeyPersonName
        {
            get { return _sKeyPersonName; }
            set { _sKeyPersonName = value.Trim(); }
        }

        private string _sCompanyName;
        public string CompanyName
        {
            get { return _sCompanyName; }
            set { _sCompanyName = value.Trim(); }
        }



        // <summary>
        // Get set property for ProjectID
        // </summary>
        public int ProjectID
        {
            get { return _nProjectID; }
            set { _nProjectID = value; }
        }

        // <summary>
        // Get set property for SubProjectID
        // </summary>
        public int SubProjectID
        {
            get { return _nSubProjectID; }
            set { _nSubProjectID = value; }
        }

        // <summary>
        // Get set property for SubProjectName
        // </summary>
        public string SubProjectName
        {
            get { return _sSubProjectName; }
            set { _sSubProjectName = value.Trim(); }
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
        // Get set property for Priority
        // </summary>
        public string Priority
        {
            get { return _sPriority; }
            set { _sPriority = value.Trim(); }
        }

        // <summary>
        // Get set property for ConcernDepartment
        // </summary>
        public int ConcernDepartment
        {
            get { return _nConcernDepartment; }
            set { _nConcernDepartment = value; }
        }

        // <summary>
        // Get set property for ProjectSize
        // </summary>
        public int ProjectSize
        {
            get { return _nProjectSize; }
            set { _nProjectSize = value; }
        }

        // <summary>
        // Get set property for StartDate
        // </summary>
        public object StartDate
        {
            get { return _dStartDate; }
            set { _dStartDate = value; }
        }

        // <summary>
        // Get set property for EndDate
        // </summary>
        public object EndDate
        {
            get { return _dEndDate; }
            set { _dEndDate = value; }
        }

        // <summary>
        // Get set property for KeyPerson
        // </summary>
        public int KeyPerson
        {
            get { return _nKeyPerson; }
            set { _nKeyPerson = value; }
        }

        // <summary>
        // Get set property for ResourceType
        // </summary>
        public int ResourceType
        {
            get { return _nResourceType; }
            set { _nResourceType = value; }
        }

        // <summary>
        // Get set property for Company
        // </summary>
        public int Company
        {
            get { return _nCompany; }
            set { _nCompany = value; }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        // <summary>
        // Get set property for WorkPercent
        // </summary>
        public double WorkPercent
        {
            get { return _WorkPercent; }
            set { _WorkPercent = value; }
        }

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        public void AddHistory()
        {
            int nMaxHistoryID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([HistoryID]) FROM t_ProjectHistory";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxHistoryID = 1;
                }
                else
                {
                    nMaxHistoryID = Convert.ToInt32(maxID) + 1;
                }
                _nHistoryID = nMaxHistoryID;
                sSql = "INSERT INTO t_ProjectHistory (HistoryID, ProjectID, SubProjectID, TaskID, StartDate, EndDate, WorkPercent, ProgressPercent, Status, Remarks, CreateDate, CreateUserID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("HistoryID", _nHistoryID);
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("SubProjectID", _nSubProjectID);
                cmd.Parameters.AddWithValue("TaskID", _nTaskID);
                cmd.Parameters.AddWithValue("StartDate", _dStartDate);
                cmd.Parameters.AddWithValue("EndDate", _dEndDate);
                cmd.Parameters.AddWithValue("WorkPercent", _WorkPercent);
                cmd.Parameters.AddWithValue("ProgressPercent", _ProgressPercent);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void Add()
        {
            int nMaxSubProjectID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([SubProjectID]) FROM t_ProjectDetail";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSubProjectID = 1;
                }
                else
                {
                    nMaxSubProjectID = Convert.ToInt32(maxID) + 1;
                }
                _nSubProjectID = nMaxSubProjectID;
                sSql = "INSERT INTO t_ProjectDetail (ProjectID, SubProjectID, SubProjectName, ProjectType, Priority, ConcernDepartment, ProjectSize, KeyPerson, ResourceType, Company, Remarks, CreateDate, CreateUserID,Businessunit) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("SubProjectID", _nSubProjectID);
                cmd.Parameters.AddWithValue("SubProjectName", _sSubProjectName);
                cmd.Parameters.AddWithValue("ProjectType", _nProjectType);
                cmd.Parameters.AddWithValue("Priority", _sPriority);
                cmd.Parameters.AddWithValue("ConcernDepartment", _nConcernDepartment);
                cmd.Parameters.AddWithValue("ProjectSize", _nProjectSize);
                cmd.Parameters.AddWithValue("KeyPerson", _nKeyPerson);
                cmd.Parameters.AddWithValue("ResourceType", _nResourceType);
                cmd.Parameters.AddWithValue("Company", _nCompany);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("Businessunit", _nBusinessunit);

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
                sSql = "UPDATE t_ProjectDetail SET SubProjectName = ?, ProjectType = ?, Priority = ?, ConcernDepartment = ?, ProjectSize = ?, KeyPerson = ?, ResourceType = ?, Company = ?, Remarks = ?,UpdateDate = ?, UpdateUserID=?, Businessunit=?, ProjectID = ? WHERE SubProjectID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("SubProjectName", _sSubProjectName);
                cmd.Parameters.AddWithValue("ProjectType", _nProjectType);
                cmd.Parameters.AddWithValue("Priority", _sPriority);
                cmd.Parameters.AddWithValue("ConcernDepartment", _nConcernDepartment);
                cmd.Parameters.AddWithValue("ProjectSize", _nProjectSize);
                cmd.Parameters.AddWithValue("KeyPerson", _nKeyPerson);
                cmd.Parameters.AddWithValue("ResourceType", _nResourceType);
                cmd.Parameters.AddWithValue("Company", _nCompany);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("Businessunit", _nBusinessunit);
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("SubProjectID", _nSubProjectID);


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
                sSql = "DELETE FROM t_ProjectDetail WHERE [ProjectID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
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
                cmd.CommandText = "SELECT * FROM t_ProjectDetail where ProjectID =?";
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nProjectID = (int)reader["ProjectID"];
                    _nSubProjectID = (int)reader["SubProjectID"];
                    _sSubProjectName = (string)reader["SubProjectName"];
                    _nProjectType = (int)reader["ProjectType"];
                    _sPriority = (string)reader["Priority"];
                    _nConcernDepartment = (int)reader["ConcernDepartment"];
                    _nProjectSize = (int)reader["ProjectSize"];
                    _dStartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                    _dEndDate = Convert.ToDateTime(reader["EndDate"].ToString());
                    _nKeyPerson = (int)reader["KeyPerson"];
                    _nResourceType = (int)reader["ResourceType"];
                    _nCompany = (int)reader["Company"];
                    _sRemarks = (string)reader["Remarks"];
                    _WorkPercent = Convert.ToDouble(reader["WorkPercent"].ToString());
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
        public void GetAllProject()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";
            {
                sSql = "Select * From t_Project Order by ProjectID";

            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Project oProject = new Project();
                    oProject.ProjectID = (int)reader["ProjectID"];
                    oProject.ProjectCode = (string)reader["ProjectCode"];
                    oProject.ProjectName = (string)reader["ProjectName"];
                    InnerList.Add(oProject);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateSubProject()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_ProjectDetail SET StartDate = ?, EndDate = ?, Remarks = ?, WorkPercent = ?, Status = ? WHERE ProjectID = ? and SubProjectID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("StartDate", _dStartDate);
                cmd.Parameters.AddWithValue("EndDate", _dEndDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("WorkPercent", _WorkPercent);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("SubProjectID", _nSubProjectID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddTask()
        {
            int nMaxTaskID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([TaskID]) FROM t_ProjectDetailTask";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxTaskID = 1;
                }
                else
                {
                    nMaxTaskID = Convert.ToInt32(maxID) + 1;
                }
                _nTaskID = nMaxTaskID;
                sSql = "INSERT INTO t_ProjectDetailTask (ProjectID, SubProjectID, TaskID, Description, AssignPerson, StartDate, EndDate, Remarks, Status, WorkPercent) VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("SubProjectID", _nSubProjectID);
                cmd.Parameters.AddWithValue("TaskID", _nTaskID);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("AssignPerson", _nAssignPerson);
                cmd.Parameters.AddWithValue("StartDate", _dStartDate);
                cmd.Parameters.AddWithValue("EndDate", _dEndDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("WorkPercent", _WorkPercent);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditTask(int nTaskID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_ProjectDetailTask SET ProjectID = ?, SubProjectID = ?, Description = ?, AssignPerson = ?,StartDate = ?, EndDate = ?, Remarks = ?, Status = ?, WorkPercent = ? WHERE TaskID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("SubProjectID", _nSubProjectID);             
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("AssignPerson", _nAssignPerson);
                cmd.Parameters.AddWithValue("StartDate", _dStartDate);
                cmd.Parameters.AddWithValue("EndDate", _dEndDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("WorkPercent", _WorkPercent);
                cmd.Parameters.AddWithValue("TaskID", nTaskID);
                

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshTaskDetailRpt()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";
            {
                sSql = @"
                    Select h.TaskID,BusinessUnit=Case 
                    when BusinessUnit=1 then 'Production'
                    when BusinessUnit=2 then 'TD'
                    when BusinessUnit=3 then 'Project CAC'
                    when BusinessUnit=4 then 'Project Lighting'
                    when BusinessUnit=5 then 'CSD'
                    when BusinessUnit=6 then 'Common'
                    else 'Other' end,
                    ProjectCode,ProjectName,c.EmployeeName as ProjectManager,
                    d.DepartmentName as ProjectDepartment,SubProjectName,
                    ProjectType=Case when ProjectType=0 then 'Android' 
                    when ProjectType=1 then 'Desktop' 
                    when ProjectType=2 then 'WEB' 
                    else 'Other' end,Priority,e.DepartmentName as ConcernDepartment,
                    ProjectSize=Case when ProjectSize=0 then 'Small' 
                    when ProjectSize=1 then 'Medium' 
                    when ProjectSize=2 then 'Big' 
                    else 'Other' end,f.EmployeeName as KeyPerson,
                    ResourceType=Case when ResourceType=0 then 'Own' 
                    when ResourceType=1 then 'Third_Party' 
                    else 'Other' end,CompanyName,h.Description as Task,i.EmployeeName as AssignPerson,
                    StartDate,EndDate,h.Remarks,Status=Case when h.Status=0 then 'Create' 
                    when h.Status=1 then 'Planned' 
                    when h.Status=2 then 'Working' 
                    when h.Status=3 then 'Done' 
                    when h.Status=4 then 'Pending' 
                    when h.Status=5 then 'Cancelled' 
                    else 'Other' end,WorkPercent,j.TaskCreateBy,j.TaskCreateDate
                    From t_Project a,
                    t_ProjectDetail b,
                    t_Employee c,
                    t_Department d,
                    t_Department e,
                    t_Employee f,
                    t_company g,t_ProjectDetailTask h,t_Employee i,
                    (

                    Select a.TaskID,TaskCreateDate,c.UserFullName as TaskCreateBy 
                    From 
                    (
                    Select TaskID,min(CreateDate) TaskCreateDate,min(HistoryID) HistoryID
                    From t_ProjectHistory group by TaskID
                    ) a
                    join t_ProjectHistory b on a.HistoryID=b.HistoryID
                    join t_User c on b.CreateUserID=c.UserID
                    ) j 
                    where h.TaskID=j.TaskID and a.ProjectID=b.ProjectID and a.ProjectManager=c.EmployeeID
                    and a.Department=d.DepartmentID and b.ConcernDepartment=e.DepartmentID
                    and b.KeyPerson=f.EmployeeID and g.companyid=b.company
                    and b.ProjectID=h.ProjectID and a.ProjectID=h.ProjectID 
                    and b.SubProjectID=h.SubProjectID and h.AssignPerson=i.EmployeeID
                    and h.Status not in (3,5)
                    Order By TaskCreateDate";

            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Project oProject = new Project();

                    oProject.TaskID = (int)reader["TaskID"];
                    oProject.DepartmentName = (string)reader["ProjectDepartment"];
                    oProject.Task = (string)reader["Task"];
                    oProject.TaskCreateBy = (string)reader["TaskCreateBy"];
                    oProject.TaskCreateDate = Convert.ToDateTime(reader["TaskCreateDate"].ToString());
                    oProject.AssignPerson = (string)reader["AssignPerson"];
                    oProject.StartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                    oProject.EndDate = Convert.ToDateTime(reader["EndDate"].ToString());
                    oProject.Status = (string)reader["Status"];
                    oProject.WorkPercent = (int)reader["WorkPercent"];
                    oProject.Remarks = (string)reader["Remarks"];

                    InnerList.Add(oProject);
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
    public class ProjectDetails : CollectionBase
    {
        public ProjectDetail this[int i]
        {
            get { return (ProjectDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ProjectDetail oProjectDetail)
        {
            InnerList.Add(oProjectDetail);
        }
        public int GetIndex(int nProjectID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ProjectID == nProjectID)
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
            string sSql = "SELECT * FROM t_ProjectDetail";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProjectDetail oProjectDetail = new ProjectDetail();
                    oProjectDetail.ProjectID = (int)reader["ProjectID"];
                    oProjectDetail.SubProjectID = (int)reader["SubProjectID"];
                    oProjectDetail.SubProjectName = (string)reader["SubProjectName"];
                    oProjectDetail.ProjectType = (int)reader["ProjectType"];
                    oProjectDetail.Priority = (string)reader["Priority"];
                    oProjectDetail.ConcernDepartment = (int)reader["ConcernDepartment"];
                    oProjectDetail.ProjectSize = (int)reader["ProjectSize"];
                    oProjectDetail.StartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                    oProjectDetail.EndDate = Convert.ToDateTime(reader["EndDate"].ToString());
                    oProjectDetail.KeyPerson = (int)reader["KeyPerson"];
                    oProjectDetail.ResourceType = (int)reader["ResourceType"];
                    oProjectDetail.Company = (int)reader["Company"];
                    oProjectDetail.Remarks = (string)reader["Remarks"];
                    oProjectDetail.WorkPercent = Convert.ToDouble(reader["WorkPercent"].ToString());
                    oProjectDetail.Status = (int)reader["Status"];
                    InnerList.Add(oProjectDetail);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetProjectList(int nDepartment, string sProjectNo, string sProjectName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";
            {
                sSql = "Select * From t_Project a,t_Employee b,t_Department c " +
                       "where a.ProjectManager=b.EmployeeID and a.Department=c.DepartmentID";

            }
            if (nDepartment != -1)
            {
                sSql = sSql + " AND Department=" + nDepartment + "";
            }
            if (sProjectNo != "")
            {
                sSql = sSql + " AND ProjectCode like '%" + sProjectNo + "%'";
            }
            if (sProjectName != "")
            {
                sSql = sSql + " AND ProjectName like '%" + sProjectName + "%'";
            }
            sSql = sSql + " Order by ProjectID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Project oProject = new Project();
                    oProject.ProjectID = (int)reader["ProjectID"];
                    oProject.ProjectCode = (string)reader["ProjectCode"];
                    oProject.ProjectName = (string)reader["ProjectName"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oProject.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oProject.Remarks = "";
                    }
                    oProject.ProjectManager = (int)reader["ProjectManager"];
                    oProject.ProjectManagerName = (string)reader["EmployeeName"];
                    oProject.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oProject.CreateUserID = (int)reader["CreateUserID"];
                    //oProject.Department = (int)reader["Department"];
                    oProject.DepartmentName = (string)reader["DepartmentName"];
                    InnerList.Add(oProject);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetSubProjectList(int nDepartment, string sProjectNo, string sProjectName, string sSubProjectName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";
            {
                //sSql = "Select * From (Select a.ProjectID,ProjectCode,ProjectName,ProjectManager, " +
                //    "c.EmployeeName as ProjectManagerName,SubProjectID,SubProjectName, " +
                //    "ProjectType,Priority,ConcernDepartment,DepartmentName as ConcernDepartmentName, " +
                //    "ProjectSize,StartDate,EndDate,KeyPerson,d.EmployeeName as KeyPersonName, " +
                //    "ResourceType,Company,CompanyName,isnull(b.Remarks,'') Remarks,WorkPercent,b.Status " +
                //    "From t_Project a,t_ProjectDetail b,t_Employee c,t_Employee d,t_Department e,t_Company f " +
                //    "where a.ProjectID=b.ProjectID and a.ProjectManager=c.EmployeeID and b.KeyPerson=d.EmployeeID  " +
                //    "and b.ConcernDepartment=e.DepartmentID and b.Company=f.CompanyID) Main where 1=1";

                sSql = "Select * From  " +
                    "(  " +
                    "Select a.*,b.StartDate,b.EndDate,isnull(ProjectComplet,0) ProjectComplet From   " +
                    "(  " +
                    "Select a.ProjectID,ProjectCode,ProjectName,ProjectManager,f.EmployeeName as ProjectManagerName,   " +
                    "SubProjectID,SubProjectName,ProjectType,Priority,ConcernDepartment,DepartmentName as ConcernDepartmentName,  " +
                    "ProjectSize,KeyPerson,d.EmployeeName as KeyPersonName,ResourceType,BusinessUnit,Company,CompanyName,isnull(a.Remarks,'') Remarks  " +
                    "From t_ProjectDetail a,t_Project b,t_Department c,t_Employee d,t_Company e,t_Employee f  " +
                    "where a.ProjectID=b.ProjectID and a.ConcernDepartment=c.DepartmentID  " +
                    "and a.KeyPerson=d.EmployeeID and a.Company=e.CompanyID and b.ProjectManager=f.EmployeeID  " +
                    ") a  " +
                    "Left Outer Join   " +
                    "(  " +
                    "Select ProjectID,SubProjectID,min(StartDate) StartDate,max(EndDate) EndDate  " +
                    "From t_ProjectHistory group by ProjectID,SubProjectID  " +
                    ") b  " +
                    "on a.ProjectID=b.ProjectID and a.SubProjectID=b.SubProjectID  " +
                    "Left Outer Join   " +
                    "(  " +
                    "Select ProjectID,SubProjectID,sum(ProjectComplet) ProjectComplet  From   " +
                    "(  " +
                    "Select a.ProjectID,a.SubProjectID,TaskID,Day,Totalday,WorkPercent,  " +
                    "isnull(Day/NULLIF(cast(Totalday as float), 0)*100,0) Weight,  " +
                    "WorkPercent*isnull(Day/NULLIF(cast(Totalday as float), 0)*100,0)/100 as ProjectComplet  " +
                    "From   " +
                    "(  " +
                    "Select ProjectID,SubProjectID,TaskID,DATEDIFF(Day,StartDate,EndDate)+1 as Day,WorkPercent  " +
                    "From t_ProjectDetailTask  " +
                    ") a  " +
                    "Left Outer Join   " +
                    "(  " +
                    "Select ProjectID,SubProjectID,sum(DATEDIFF(Day,StartDate,EndDate)+1) as TotalDay  " +
                    "From t_ProjectDetailTask group by ProjectID,SubProjectID  " +
                    ") b on a.ProjectID=b.ProjectID and a.SubProjectID=b.SubProjectID  " +
                    ") a group by ProjectID,SubProjectID  " +
                    ") c  " +
                    "on a.ProjectID=c.ProjectID and a.SubProjectID=c.SubProjectID  " +
                    ") Main where 1=1";

            }
            if (nDepartment != -1)
            {
                sSql = sSql + " AND ConcernDepartment=" + nDepartment + "";
            }
            if (sProjectNo != "")
            {
                sSql = sSql + " AND ProjectCode like '%" + sProjectNo + "%'";
            }
            if (sProjectName != "")
            {
                sSql = sSql + " AND ProjectName like '%" + sProjectName + "%'";
            }
            if (sSubProjectName != "")
            {
                sSql = sSql + " AND SubProjectName like '%" + sSubProjectName + "%'";
            }
            sSql = sSql + " Order by ProjectID";

            try
            {

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProjectDetail oProjectDetail = new ProjectDetail();
                    oProjectDetail.ProjectID = (int)reader["ProjectID"];
                    oProjectDetail.ProjectCode = (string)reader["ProjectCode"];
                    oProjectDetail.ProjectName = (string)reader["ProjectName"];
                    oProjectDetail.ProjectManager = (int)reader["ProjectManager"];
                    oProjectDetail.ProjectManagerName = (string)reader["ProjectManagerName"];
                    oProjectDetail.SubProjectID = (int)reader["SubProjectID"];
                    oProjectDetail.SubProjectName = (string)reader["SubProjectName"];
                    oProjectDetail.ProjectType = (int)reader["ProjectType"];
                    oProjectDetail.Priority = (string)reader["Priority"];
                    oProjectDetail.ConcernDepartment = (int)reader["ConcernDepartment"];
                    oProjectDetail.ConcernDepartmentName = (string)reader["ConcernDepartmentName"];
                    oProjectDetail.ProjectSize = (int)reader["ProjectSize"];
                    oProjectDetail.KeyPerson = (int)reader["KeyPerson"];
                    oProjectDetail.KeyPersonName = (string)reader["KeyPersonName"];
                    oProjectDetail.ResourceType = (int)reader["ResourceType"];
                    oProjectDetail.Businessunit = (int)reader["Businessunit"];
                    oProjectDetail.Company = (int)reader["Company"];
                    oProjectDetail.CompanyName = (string)reader["CompanyName"];
                    oProjectDetail.Remarks = (string)reader["Remarks"];
                    if (reader["StartDate"] != DBNull.Value)
                    {
                        oProjectDetail.StartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                    }
                    else
                    {
                        oProjectDetail.StartDate = "";
                    }
                    if (reader["EndDate"] != DBNull.Value)
                    {
                        oProjectDetail.EndDate = Convert.ToDateTime(reader["EndDate"].ToString());
                    }
                    else
                    {
                        oProjectDetail.EndDate = "";
                    }
                    oProjectDetail.WorkPercent = Convert.ToDouble(reader["ProjectComplet"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oProjectDetail.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oProjectDetail.Remarks = "";
                    }

                    InnerList.Add(oProjectDetail);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetProjectTask(int nProjectID,int nSubProjectID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";
            {
                sSql = "Select a.ProjectID,'['+ProjectCode+']'+' '+ProjectName ProjectName, "+
                    "a.SubProjectID,SubProjectName,TaskID,Description,AssignPerson, a.StartDate, a.EndDate,EmployeeCode,EmployeeName, " +
                    "a.Remarks,a.Status,a.WorkPercent From t_ProjectDetailTask a,t_ProjectDetail b,t_Project c,t_Employee d " +
                    "where a.SubProjectID=b.SubProjectID and a.ProjectID=c.ProjectID  " +
                    "and b.ProjectID=c.ProjectID and a.AssignPerson=d.EmployeeID and  " +
                    "a.ProjectID=" + nProjectID + " and a.SubProjectID=" + nSubProjectID + "  Order by TaskID";

            }

            try
            {

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProjectDetail oProjectDetail = new ProjectDetail();
                    oProjectDetail.ProjectID = Convert.ToInt32(reader["ProjectID"].ToString());
                    oProjectDetail.ProjectName = (string)reader["ProjectName"];
                    oProjectDetail.SubProjectID = Convert.ToInt32(reader["SubProjectID"].ToString());
                    oProjectDetail.SubProjectName = (string)reader["SubProjectName"];
                    oProjectDetail.TaskID = Convert.ToInt32(reader["TaskID"].ToString());
                    oProjectDetail.Description = (string)reader["Description"];
                    oProjectDetail.AssignPerson = Convert.ToInt32(reader["AssignPerson"].ToString());
                    oProjectDetail.AssignPersonName = (string)reader["EmployeeName"];
                    oProjectDetail.StartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                    oProjectDetail.EndDate = Convert.ToDateTime(reader["EndDate"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oProjectDetail.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oProjectDetail.Remarks = "";
                    }
                    oProjectDetail.WorkPercent = Convert.ToDouble(reader["WorkPercent"].ToString());
                    oProjectDetail.Status = Convert.ToInt32(reader["Status"].ToString());

                    InnerList.Add(oProjectDetail);
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
