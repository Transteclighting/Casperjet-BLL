// <summary>
// Company: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Apr 12, 2017
// Time : 11:11 AM
// Description: Class for HRCV.
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
    public class HRAgency
    {
        private int _nAgencyID;
        private string _sContactPerson;
        private string _sContactNo;
        private int _nAgencyType;
        private DateTime _dCreateDate;
        private int _nCreateUserID;


        // <summary>
        // Get set property for AgencyID
        // </summary>
        public int AgencyID
        {
            get { return _nAgencyID; }
            set { _nAgencyID = value; }
        }

        // <summary>
        // Get set property for ContactPerson
        // </summary>
        public string ContactPerson
        {
            get { return _sContactPerson; }
            set { _sContactPerson = value.Trim(); }
        }

        // <summary>
        // Get set property for ContactNo
        // </summary>
        public string ContactNo
        {
            get { return _sContactNo; }
            set { _sContactNo = value.Trim(); }
        }

        // <summary>
        // Get set property for AgencyType
        // </summary>
        public int AgencyType
        {
            get { return _nAgencyType; }
            set { _nAgencyType = value; }
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

        public void Add()
        {
            int nMaxAgencyID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([AgencyID]) FROM t_HRAgency";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxAgencyID = 1;
                }
                else
                {
                    nMaxAgencyID = Convert.ToInt32(maxID) + 1;
                }
                _nAgencyID = nMaxAgencyID;
                sSql = "INSERT INTO t_HRAgency (AgencyID, ContactPerson, ContactNo, AgencyType, CreateDate, CreateUserID) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("AgencyID", _nAgencyID);
                cmd.Parameters.AddWithValue("ContactPerson", _sContactPerson);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("AgencyType", _nAgencyType);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);

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
                sSql = "UPDATE t_HRAgency SET ContactPerson = ?, ContactNo = ?, AgencyType = ?, CreateDate = ?, CreateUserID = ? WHERE AgencyID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ContactPerson", _sContactPerson);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("AgencyType", _nAgencyType);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);

                cmd.Parameters.AddWithValue("AgencyID", _nAgencyID);

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
                sSql = "DELETE FROM t_HRAgency WHERE [AgencyID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("AgencyID", _nAgencyID);
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
                cmd.CommandText = "SELECT * FROM t_HRAgency where AgencyID =?";
                cmd.Parameters.AddWithValue("AgencyID", _nAgencyID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nAgencyID = (int)reader["AgencyID"];
                    _sContactPerson = (string)reader["ContactPerson"];
                    _sContactNo = (string)reader["ContactNo"];
                    _nAgencyType = (int)reader["AgencyType"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
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

    public class HRAgencys : CollectionBase
    {
        public HRAgency this[int i]
        {
            get { return (HRAgency)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HRAgency oHRAgency)
        {
            InnerList.Add(oHRAgency);
        }
        public int GetIndex(int nAgencyID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].AgencyID == nAgencyID)
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
            string sSql = "SELECT * FROM t_HRAgency";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRAgency oHRAgency = new HRAgency();
                    oHRAgency.AgencyID = (int)reader["AgencyID"];
                    oHRAgency.ContactPerson = (string)reader["ContactPerson"];
                    oHRAgency.ContactNo = (string)reader["ContactNo"];
                    oHRAgency.AgencyType = (int)reader["AgencyType"];
                    oHRAgency.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oHRAgency.CreateUserID = (int)reader["CreateUserID"];
                    InnerList.Add(oHRAgency);
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

    public class HRCV
    {
        private int _nCVID;
        private string _sCVNo;
        private string _sCandidateName;
        private DateTime _dDateOfBirth;
        private string _sContactNo;
        private string _sEmail;
        private int _nCurrentCompanyID;
        private string _sCurrentDesignation;
        private string _sCurrentDepartment;
        private string _sEducation;
        private int _nJobLengthYear;
        private int _nJobLengthMonth;
        private string _sJobHistory;
        private double _CurrentSalary;
        private double _ExpectedSalary;
        private int _nNoticePeriod;
        private int _nForPosition;
        private int _nSource;
        private int _nStatus;
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private DateTime _dUpdateDate;
        private int _nUpdateUserID;
        private string _sUploadedCVPath;
        private string _sPositionName;
        private string _sSourceName;

        // <summary>
        // Get set property for SourceName
        // </summary>
        public string SourceName
        {
            get { return _sSourceName; }
            set { _sSourceName = value.Trim(); }
        }

        // <summary>
        // Get set property for PositionName
        // </summary>
        public string PositionName
        {
            get { return _sPositionName; }
            set { _sPositionName = value.Trim(); }
        }


        // <summary>
        // Get set property for CVID
        // </summary>
        public int CVID
        {
            get { return _nCVID; }
            set { _nCVID = value; }
        }

        // <summary>
        // Get set property for CVNo
        // </summary>
        public string CVNo
        {
            get { return _sCVNo; }
            set { _sCVNo = value.Trim(); }
        }

        // <summary>
        // Get set property for CandidateName
        // </summary>
        public string CandidateName
        {
            get { return _sCandidateName; }
            set { _sCandidateName = value.Trim(); }
        }

        // <summary>
        // Get set property for DateOfBirth
        // </summary>
        public DateTime DateOfBirth
        {
            get { return _dDateOfBirth; }
            set { _dDateOfBirth = value; }
        }

        // <summary>
        // Get set property for ContactNo
        // </summary>
        public string ContactNo
        {
            get { return _sContactNo; }
            set { _sContactNo = value.Trim(); }
        }

        // <summary>
        // Get set property for Email
        // </summary>
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value.Trim(); }
        }

        // <summary>
        // Get set property for CurrentCompanyID
        // </summary>
        public int CurrentCompanyID
        {
            get { return _nCurrentCompanyID; }
            set { _nCurrentCompanyID = value; }
        }

        // <summary>
        // Get set property for CurrentDesignation
        // </summary>
        public string CurrentDesignation
        {
            get { return _sCurrentDesignation; }
            set { _sCurrentDesignation = value.Trim(); }
        }

        // <summary>
        // Get set property for CurrentDepartment
        // </summary>
        public string CurrentDepartment
        {
            get { return _sCurrentDepartment; }
            set { _sCurrentDepartment = value.Trim(); }
        }

        // <summary>
        // Get set property for Education
        // </summary>
        public string Education
        {
            get { return _sEducation; }
            set { _sEducation = value.Trim(); }
        }

        // <summary>
        // Get set property for JobLengthYear
        // </summary>
        public int JobLengthYear
        {
            get { return _nJobLengthYear; }
            set { _nJobLengthYear = value; }
        }

        // <summary>
        // Get set property for JobLengthMonth
        // </summary>
        public int JobLengthMonth
        {
            get { return _nJobLengthMonth; }
            set { _nJobLengthMonth = value; }
        }

        // <summary>
        // Get set property for JobHistory
        // </summary>
        public string JobHistory
        {
            get { return _sJobHistory; }
            set { _sJobHistory = value.Trim(); }
        }

        // <summary>
        // Get set property for CurrentSalary
        // </summary>
        public double CurrentSalary
        {
            get { return _CurrentSalary; }
            set { _CurrentSalary = value; }
        }

        // <summary>
        // Get set property for ExpectedSalary
        // </summary>
        public double ExpectedSalary
        {
            get { return _ExpectedSalary; }
            set { _ExpectedSalary = value; }
        }

        // <summary>
        // Get set property for NoticePeriod
        // </summary>
        public int NoticePeriod
        {
            get { return _nNoticePeriod; }
            set { _nNoticePeriod = value; }
        }

        // <summary>
        // Get set property for ForPosition
        // </summary>
        public int ForPosition
        {
            get { return _nForPosition; }
            set { _nForPosition = value; }
        }

        // <summary>
        // Get set property for Source
        // </summary>
        public int Source
        {
            get { return _nSource; }
            set { _nSource = value; }
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
        // Get set property for UpdateDate
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
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
        // Get set property for UploadedCVPath
        // </summary>
        public string UploadedCVPath
        {
            get { return _sUploadedCVPath; }
            set { _sUploadedCVPath = value.Trim(); }
        }

        public void Add()
        {
            int nMaxCVID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([CVID]) FROM t_HRCV";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxCVID = 1;
                }
                else
                {
                    nMaxCVID = Convert.ToInt32(maxID) + 1;
                }
                _nCVID = nMaxCVID;
                string sCVNo = "CV-" + DateTime.Now.Year + _nCVID.ToString("00000");
                _sCVNo = sCVNo;

                sSql = "INSERT INTO t_HRCV (CVID, CVNo, CandidateName, DateOfBirth, ContactNo, Email, CurrentCompanyID, CurrentDesignation, CurrentDepartment, Education, JobLengthYear, JobLengthMonth, JobHistory, CurrentSalary, ExpectedSalary, NoticePeriod, ForPosition, Source, Status, CreateDate, CreateUserID, UpdateDate, UpdateUserID, UploadedCVPath) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CVID", _nCVID);
                cmd.Parameters.AddWithValue("CVNo", _sCVNo);
                cmd.Parameters.AddWithValue("CandidateName", _sCandidateName);
                cmd.Parameters.AddWithValue("DateOfBirth", _dDateOfBirth);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("CurrentCompanyID", _nCurrentCompanyID);
                cmd.Parameters.AddWithValue("CurrentDesignation", _sCurrentDesignation);
                cmd.Parameters.AddWithValue("CurrentDepartment", _sCurrentDepartment);
                cmd.Parameters.AddWithValue("Education", _sEducation);
                cmd.Parameters.AddWithValue("JobLengthYear", _nJobLengthYear);
                cmd.Parameters.AddWithValue("JobLengthMonth", _nJobLengthMonth);
                cmd.Parameters.AddWithValue("JobHistory", _sJobHistory);
                cmd.Parameters.AddWithValue("CurrentSalary", _CurrentSalary);
                cmd.Parameters.AddWithValue("ExpectedSalary", _ExpectedSalary);
                cmd.Parameters.AddWithValue("NoticePeriod", _nNoticePeriod);
                cmd.Parameters.AddWithValue("ForPosition", _nForPosition);
                cmd.Parameters.AddWithValue("Source", _nSource);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UploadedCVPath", _sUploadedCVPath);

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
                sSql = "UPDATE t_HRCV SET CVNo = ?, CandidateName = ?, DateOfBirth = ?, ContactNo = ?, Email = ?, CurrentCompanyID = ?, CurrentDesignation = ?, CurrentDepartment = ?, Education = ?, JobLengthYear = ?, JobLengthMonth = ?, JobHistory = ?, CurrentSalary = ?, ExpectedSalary = ?, NoticePeriod = ?, ForPosition = ?, Source = ?, Status = ?, CreateDate = ?, CreateUserID = ?, UpdateDate = ?, UpdateUserID = ?, UploadedCVPath = ? WHERE CVID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CVNo", _sCVNo);
                cmd.Parameters.AddWithValue("CandidateName", _sCandidateName);
                cmd.Parameters.AddWithValue("DateOfBirth", _dDateOfBirth);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("CurrentCompanyID", _nCurrentCompanyID);
                cmd.Parameters.AddWithValue("CurrentDesignation", _sCurrentDesignation);
                cmd.Parameters.AddWithValue("CurrentDepartment", _sCurrentDepartment);
                cmd.Parameters.AddWithValue("Education", _sEducation);
                cmd.Parameters.AddWithValue("JobLengthYear", _nJobLengthYear);
                cmd.Parameters.AddWithValue("JobLengthMonth", _nJobLengthMonth);
                cmd.Parameters.AddWithValue("JobHistory", _sJobHistory);
                cmd.Parameters.AddWithValue("CurrentSalary", _CurrentSalary);
                cmd.Parameters.AddWithValue("ExpectedSalary", _ExpectedSalary);
                cmd.Parameters.AddWithValue("NoticePeriod", _nNoticePeriod);
                cmd.Parameters.AddWithValue("ForPosition", _nForPosition);
                cmd.Parameters.AddWithValue("Source", _nSource);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UploadedCVPath", _sUploadedCVPath);

                cmd.Parameters.AddWithValue("CVID", _nCVID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateCVPath()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_HRCV SET UploadedCVPath = ? WHERE CVID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("UploadedCVPath", _sUploadedCVPath);
                cmd.Parameters.AddWithValue("CVID", _nCVID);

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
                sSql = "DELETE FROM t_HRCV WHERE [CVID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CVID", _nCVID);
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
                cmd.CommandText = "SELECT * FROM t_HRCV where CVID =?";
                cmd.Parameters.AddWithValue("CVID", _nCVID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCVID = (int)reader["CVID"];
                    _sCVNo = (string)reader["CVNo"];
                    _sCandidateName = (string)reader["CandidateName"];
                    _dDateOfBirth = Convert.ToDateTime(reader["DateOfBirth"].ToString());
                    _sContactNo = (string)reader["ContactNo"];
                    _sEmail = (string)reader["Email"];
                    _nCurrentCompanyID = (int)reader["CurrentCompanyID"];
                    _sCurrentDesignation = (string)reader["CurrentDesignation"];
                    _sCurrentDepartment = (string)reader["CurrentDepartment"];
                    _sEducation = (string)reader["Education"];
                    _nJobLengthYear = (int)reader["JobLengthYear"];
                    _nJobLengthMonth = (int)reader["JobLengthMonth"];
                    _sJobHistory = (string)reader["JobHistory"];
                    _CurrentSalary = Convert.ToDouble(reader["CurrentSalary"].ToString());
                    _ExpectedSalary = Convert.ToDouble(reader["ExpectedSalary"].ToString());
                    _nNoticePeriod = (int)reader["NoticePeriod"];
                    _nForPosition = (int)reader["ForPosition"];
                    _nSource = (int)reader["Source"];
                    _nStatus = (int)reader["Status"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _sUploadedCVPath = (string)reader["UploadedCVPath"];
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

    public class HRCVs : CollectionBase
    {
        public HRCV this[int i]
        {
            get { return (HRCV)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HRCV oHRCV)
        {
            InnerList.Add(oHRCV);
        }
        public int GetIndex(int nCVID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].CVID == nCVID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(string sCVNO, string sName, string sContactNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";

            {

                sSql = "SELECT CVID,CVNo,CandidateName,DateOfBirth,a.ContactNo, " +
                            "isnull(Email,'') Email,CurrentCompanyID,b.CompanyName as CurrentCompanyName, " +
                            "isnull(CurrentDesignation,'') CurrentDesignation,isnull(CurrentDepartment,'') CurrentDepartment, "+
                            "Education,JobLengthYear, " +
                            "JobLengthMonth,JobHistory,CurrentSalary, " +
                            "ExpectedSalary,NoticePeriod,ForPosition, " +
                            "'['+PositionCode+']'+' '+PositionName as PositionName, " +
                            "Source,ContactPerson as SourceName,Status,a.CreateDate, " +
                            "a.CreateUserID,UploadedCVPath " +
                            "FROM t_HRCV a,t_HRCompany b,t_HRPosition c,t_HRAgency d " +
                            "where a.CurrentCompanyID=b.CompanyID and a.Forposition=c.PositionID " +
                            "and a.Source=d.AgencyID";
            }


            if (sCVNO != "")
            {
                sSql = sSql + " AND CVNo like '%" + sCVNO + "%'";
            }

            if (sName != "")
            {
                sSql = sSql + " AND CandidateName like '%" + sName + "%'";
            }

            if (sContactNo != "")
            {
                sSql = sSql + " AND a.ContactNo like '%" + sContactNo + "%'";
            }
            sSql = sSql + " Order by CVID";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRCV oHRCV = new HRCV();
                    oHRCV.CVID = (int)reader["CVID"];
                    oHRCV.CVNo = (string)reader["CVNo"];
                    oHRCV.CandidateName = (string)reader["CandidateName"];
                    oHRCV.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"].ToString());
                    oHRCV.ContactNo = (string)reader["ContactNo"];
                    oHRCV.Email = (string)reader["Email"];
                    oHRCV.CurrentCompanyID = (int)reader["CurrentCompanyID"];
                    oHRCV.CurrentDesignation = (string)reader["CurrentDesignation"];
                    oHRCV.CurrentDepartment = (string)reader["CurrentDepartment"];
                    oHRCV.Education = (string)reader["Education"];
                    oHRCV.JobLengthYear = (int)reader["JobLengthYear"];
                    oHRCV.JobLengthMonth = (int)reader["JobLengthMonth"];
                    oHRCV.JobHistory = (string)reader["JobHistory"];
                    oHRCV.CurrentSalary = Convert.ToDouble(reader["CurrentSalary"].ToString());
                    oHRCV.ExpectedSalary = Convert.ToDouble(reader["ExpectedSalary"].ToString());
                    oHRCV.NoticePeriod = (int)reader["NoticePeriod"];
                    oHRCV.ForPosition = (int)reader["ForPosition"];
                    oHRCV.PositionName = (string)reader["PositionName"];
                    oHRCV.Source = (int)reader["Source"];
                    oHRCV.SourceName = (string)reader["SourceName"];
                    oHRCV.Status = (int)reader["Status"];
                    oHRCV.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oHRCV.CreateUserID = (int)reader["CreateUserID"];
                    oHRCV.UploadedCVPath = (string)reader["UploadedCVPath"];
                    InnerList.Add(oHRCV);
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

