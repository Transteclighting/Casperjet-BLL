// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif khan
// Date: May 28, 2011
// Time :  12:00 PM
// Description: Class for JobGrade.
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

    public class JobGrade
    {

        private int _nJobGradeID;
        private string _sJobGradeCode;
        private string _sJobGradeName;
        private double _nMinBasicSalary;
        private double _nMaxBasicSalary;
        private double _nMedicalLimit; //17-Jun-2013 Arif Khan: Added for Medical Claim Module.
        private double _nGradePOS;
        private bool _bIsActive;

        public int JobGradeID
        {
            get { return _nJobGradeID; }
            set { _nJobGradeID = value; }

        }

        public string JobGradeCode
        {
            get { return _sJobGradeCode; }
            set { _sJobGradeCode = value; }

        }

        public string JobGradeName
        {
            get { return _sJobGradeName; }
            set { _sJobGradeName = value; }
        }

        public double MinBasicSalary
        {
            get { return _nMinBasicSalary; }
            set { _nMinBasicSalary = value; }
        }

        public double MaxBasicSalary
        {
            get { return _nMaxBasicSalary; }
            set { _nMaxBasicSalary = value; }
        }

        public double MedicalLimit
        {
            get { return _nMedicalLimit; }
            set { _nMedicalLimit = value; }
        }

        public double GradePOS
        {
            get { return _nGradePOS; }
            set { _nGradePOS = value; }
        }

        public bool IsActive
        {
            get { return _bIsActive; }
            set { _bIsActive = value; }

        }

        private int _nGradeType;
        
        public int GradeType
        {
            get { return _nGradeType; }
            set { _nGradeType = value; }

        }
        
        public void Add()
        {
            int nMaxJobGradeID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([JobGradeID]) FROM t_JobGrade";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxJobGradeID = 1;
                }
                else
                {
                    nMaxJobGradeID = Convert.ToInt32(maxID) + 1;
                }
                _nJobGradeID = nMaxJobGradeID;

                sSql = "INSERT INTO t_JobGrade(JobGradeID,JobGradeCode,JobGradeName,MinBasicSalary,MaxBasicSalary,MedicalLimit,GradePOS,IsActive, GradeType)"
                    + " VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("JobGradeID", _nJobGradeID);
                cmd.Parameters.AddWithValue("JobGradeCode", _sJobGradeCode);
                cmd.Parameters.AddWithValue("JobGradeName", _sJobGradeName);
                cmd.Parameters.AddWithValue("MinBasicSalary", _nMinBasicSalary);
                cmd.Parameters.AddWithValue("MaxBasicSalary", _nMaxBasicSalary);
                cmd.Parameters.AddWithValue("MedicalLimit", _nMedicalLimit);
                cmd.Parameters.AddWithValue("GradePOS", _nGradePOS);
                cmd.Parameters.AddWithValue("IsActive", _bIsActive);
                cmd.Parameters.AddWithValue("GradeType", _nGradeType);

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

                sSql = "UPDATE t_JobGrade SET JobGradeCode=?, JobGradeName=?, MinBasicSalary=?, MaxBasicSalary=?,MedicalLimit=?,GradePOS=?, IsActive=?, GradeType = ? "
                    + " WHERE JobGradeID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("JobGradeCode", _sJobGradeCode);
                cmd.Parameters.AddWithValue("JobGradeName", _sJobGradeName);
                cmd.Parameters.AddWithValue("MinBasicSalary", _nMinBasicSalary);
                cmd.Parameters.AddWithValue("MaxBasicSalary", _nMaxBasicSalary);
                cmd.Parameters.AddWithValue("MedicalLimit", _nMedicalLimit);
                cmd.Parameters.AddWithValue("GradePOS", _nGradePOS);
                cmd.Parameters.AddWithValue("IsActive", _bIsActive);
                cmd.Parameters.AddWithValue("GradeType", _nGradeType);

                cmd.Parameters.AddWithValue("JobGradeID", _nJobGradeID);

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
                sSql = "DELETE FROM t_JobGrade WHERE [JobGradeID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("JobGradeID", _nJobGradeID);
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
                cmd.CommandText = "SELECT * FROM t_JobGrade where JobGradeID =?";
                cmd.Parameters.AddWithValue("JobGradeID", _nJobGradeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nJobGradeID = (int)reader["JobGradeID"];
                    _sJobGradeCode = (string)reader["JobGradeCode"];
                    _sJobGradeName = (string)reader["JobGradeName"];
                    _nMinBasicSalary = Convert.ToDouble(reader["MinBasicSalary"].ToString());
                    _nMaxBasicSalary = Convert.ToDouble(reader["MaxBasicSalary"].ToString());
                    _nMedicalLimit = Convert.ToDouble(reader["MedicalLimit"].ToString());
                    _nGradePOS = Convert.ToDouble(reader["GradePOS"].ToString());
                    _bIsActive = Convert.ToBoolean(reader["IsActive"]);
                    _nGradeType = (int)reader["GradeType"];

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


    public class JobGrades : CollectionBase
    {

        public JobGrade this[int i]
        {
            get { return (JobGrade)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(JobGrade oJobGrade)
        {
            InnerList.Add(oJobGrade);
        }

        public int GetIndex(int nJobGradeID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].JobGradeID == nJobGradeID)
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

            string sSql = "SELECT * FROM t_JobGrade order by JobGradeName ";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    JobGrade oJobGrade = new JobGrade();

                    oJobGrade.JobGradeID = (int)reader["JobGradeID"];
                    oJobGrade.JobGradeCode = (string)reader["JobGradeCode"];
                    oJobGrade.JobGradeName = (string)reader["JobGradeName"];
                    oJobGrade.MinBasicSalary = Convert.ToDouble(reader["MinBasicSalary"]);
                    oJobGrade.MaxBasicSalary = Convert.ToDouble(reader["MaxBasicSalary"]);
                    oJobGrade.MedicalLimit = Convert.ToDouble(reader["MedicalLimit"]);
                    oJobGrade.GradePOS = Convert.ToDouble(reader["GradePOS"]);
                    oJobGrade.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    oJobGrade.GradeType = (int)reader["GradeType"];

                    InnerList.Add(oJobGrade);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetGrade(int nGradeType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_JobGrade Where 1=1 ";

            if (nGradeType > 0)
            {
                sSql = sSql + " and GradeType = " + nGradeType + " ";

            }
            sSql = sSql + " order by JobGradeName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    JobGrade oJobGrade = new JobGrade();

                    oJobGrade.JobGradeID = (int)reader["JobGradeID"];
                    oJobGrade.JobGradeCode = (string)reader["JobGradeCode"];
                    oJobGrade.JobGradeName = (string)reader["JobGradeName"];
                    oJobGrade.MinBasicSalary = Convert.ToDouble(reader["MinBasicSalary"]);
                    oJobGrade.MaxBasicSalary = Convert.ToDouble(reader["MaxBasicSalary"]);
                    oJobGrade.MedicalLimit = Convert.ToDouble(reader["MedicalLimit"]);
                    oJobGrade.GradePOS = Convert.ToDouble(reader["GradePOS"]);
                    oJobGrade.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    oJobGrade.GradeType = (int)reader["GradeType"];

                    InnerList.Add(oJobGrade);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh(int nADID, int nEditADID, int nGradeID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " SELECT * FROM t_JobGrade where JobGradeID not in  " +
                          " (Select GradeID From dbo.t_HRAllowanceDeductionMapping where ADID = " + nADID + ")   " +
                          " Union All  " +
                          " SELECT * FROM t_JobGrade where JobGradeID in (Select GradeID From dbo.t_HRAllowanceDeductionMapping where ADID = " + nEditADID + " and GradeID=" + nGradeID + ") ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    JobGrade oJobGrade = new JobGrade();

                    oJobGrade.JobGradeID = (int)reader["JobGradeID"];
                    oJobGrade.JobGradeCode = (string)reader["JobGradeCode"];
                    oJobGrade.JobGradeName = (string)reader["JobGradeName"];
                    oJobGrade.MinBasicSalary = Convert.ToDouble(reader["MinBasicSalary"]);
                    oJobGrade.MaxBasicSalary = Convert.ToDouble(reader["MaxBasicSalary"]);
                    oJobGrade.MedicalLimit = Convert.ToDouble(reader["MedicalLimit"]);
                    oJobGrade.GradePOS = Convert.ToDouble(reader["GradePOS"]);
                    oJobGrade.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    oJobGrade.GradeType = (int)reader["GradeType"];

                    InnerList.Add(oJobGrade);
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
