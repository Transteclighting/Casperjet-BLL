using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.HR
{
    public class HRAssessment
    {
        private int _nID;
        private int _nEmployeeID;
        private int _nDesignationID;
        private int _nDepartmentID;
        private int _nCompanyID;
        private int _nAssessmentType;
        private int _nAssessmentYear;
        private DateTime _dFromDate;
        private DateTime _dToDate;
        private double _BasicSalary;
        private double _GrossSalary;
        private double _IncrementAmount;
        private int? _nYearofLastPromotion;
        private string _sAcademicQualification;
        private int _nLineManagerID;
        private double _SalesTarget;
        private double _Achievement;
        private DateTime _dTargetForm;
        private DateTime _dTargetTo;
        private int _nIsActive;
        private int _nStatus;
        private int _nAssessmentID;
        private string _nEmployeeCode;
        private string _nEmployeeName;
        private string _nDesignationName;
        private string _nDepartmentName;
        private string _nCompanyName;
        private string _nLineManagerCode;
        private string _nLineManagerName;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
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
        // Get set property for DesignationID
        // </summary>
        public int DesignationID
        {
            get { return _nDesignationID; }
            set { _nDesignationID = value; }
        }

        // <summary>
        // Get set property for DepartmentID
        // </summary>
        public int DepartmentID
        {
            get { return _nDepartmentID; }
            set { _nDepartmentID = value; }
        }

        // <summary>
        // Get set property for CompanyID
        // </summary>
        public int CompanyID
        {
            get { return _nCompanyID; }
            set { _nCompanyID = value; }
        }

        // <summary>
        // Get set property for AssessmentType
        // </summary>
        public int AssessmentType
        {
            get { return _nAssessmentType; }
            set { _nAssessmentType = value; }
        }

        // <summary>
        // Get set property for AssessmentYear
        // </summary>
        public int AssessmentYear
        {
            get { return _nAssessmentYear; }
            set { _nAssessmentYear = value; }
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
        // Get set property for BasicSalary
        // </summary>
        public double BasicSalary
        {
            get { return _BasicSalary; }
            set { _BasicSalary = value; }
        }

        // <summary>
        // Get set property for GrossSalary
        // </summary>
        public double GrossSalary
        {
            get { return _GrossSalary; }
            set { _GrossSalary = value; }
        }

        // <summary>
        // Get set property for IncrementAmount
        // </summary>
        public double IncrementAmount
        {
            get { return _IncrementAmount; }
            set { _IncrementAmount = value; }
        }

        // <summary>
        // Get set property for YearofLastPromotion
        // </summary>
        public int? YearofLastPromotion
        {
            get { return _nYearofLastPromotion; }
            set { _nYearofLastPromotion = value; }
        }

        // <summary>
        // Get set property for AcademicQualification
        // </summary>
        public string AcademicQualification
        {
            get { return _sAcademicQualification; }
            set { _sAcademicQualification = value.Trim(); }
        }

        // <summary>
        // Get set property for LineManagerID
        // </summary>
        public int LineManagerID
        {
            get { return _nLineManagerID; }
            set { _nLineManagerID = value; }
        }

        // <summary>
        // Get set property for SalesTarget
        // </summary>
        public double SalesTarget
        {
            get { return _SalesTarget; }
            set { _SalesTarget = value; }
        }

        // <summary>
        // Get set property for Achievement
        // </summary>
        public double Achievement
        {
            get { return _Achievement; }
            set { _Achievement = value; }
        }

        // <summary>
        // Get set property for TargetForm
        // </summary>
        public DateTime TargetForm
        {
            get { return _dTargetForm; }
            set { _dTargetForm = value; }
        }

        // <summary>
        // Get set property for TargetTo
        // </summary>
        public DateTime TargetTo
        {
            get { return _dTargetTo; }
            set { _dTargetTo = value; }
        }

        // <summary>
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
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
        // Get set property for AssessmentID
        // </summary>
        public int AssessmentID
        {
            get { return _nAssessmentID; }
            set { _nAssessmentID = value; }
        }

        public string EmployeeCode
        {
            get { return _nEmployeeCode; }
            set { _nEmployeeCode = value.Trim(); }
        }
        public string EmployeeName
        {
            get { return _nEmployeeName; }
            set { _nEmployeeName = value.Trim(); }
        }
        public string DesignationName
        {
            get { return _nDesignationName; }
            set { _nDesignationName = value.Trim(); }
        }
        public string DepartmentName
        {
            get { return _nDepartmentName; }
            set { _nDepartmentName = value.Trim(); }
        }
        public string CompanyName
        {
            get { return _nCompanyName; }
            set { _nCompanyName = value.Trim(); }
        }
        public string LineManagerCode
        {
            get { return _nLineManagerCode; }
            set { _nLineManagerCode = value.Trim(); }
        }
        public string LineManagerName
        {
            get { return _nLineManagerName; }
            set { _nLineManagerName = value.Trim(); }
        }


        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_HRAssessment";
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
                sSql = "INSERT INTO t_HRAssessment (ID, EmployeeID, DesignationID, DepartmentID, CompanyID, AssessmentType, AssessmentYear, FromDate, ToDate, BasicSalary, GrossSalary, IncrementAmount, YearofLastPromotion, AcademicQualification, LineManagerID, SalesTarget, Achievement, TargetForm, TargetTo, IsActive, Status, AssessmentID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("DesignationID", _nDesignationID);
                cmd.Parameters.AddWithValue("DepartmentID", _nDepartmentID);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("AssessmentType", _nAssessmentType);
                cmd.Parameters.AddWithValue("AssessmentYear", _nAssessmentYear);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("BasicSalary", _BasicSalary);
                cmd.Parameters.AddWithValue("GrossSalary", _GrossSalary);
                cmd.Parameters.AddWithValue("IncrementAmount", _IncrementAmount);

                if (_nYearofLastPromotion != -1)
                {
                    cmd.Parameters.AddWithValue("YearofLastPromotion", _nYearofLastPromotion);
                }
                else
                {
                    cmd.Parameters.AddWithValue("YearofLastPromotion", null);
                }

                cmd.Parameters.AddWithValue("AcademicQualification", _sAcademicQualification);
                cmd.Parameters.AddWithValue("LineManagerID", _nLineManagerID);

                if (_SalesTarget != -1)
                {
                    cmd.Parameters.AddWithValue("SalesTarget", _SalesTarget);
                }
                else
                {
                    cmd.Parameters.AddWithValue("SalesTarget", null);
                }


                if (_Achievement != -1)
                {
                    cmd.Parameters.AddWithValue("Achievement", _Achievement);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Achievement", null);
                }

                if (_dTargetForm != null)
                {
                    cmd.Parameters.AddWithValue("TargetForm", _dTargetForm);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ApproveDate", null);
                }

                if (_dTargetTo != null)
                {

                    cmd.Parameters.AddWithValue("TargetTo", _dTargetTo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ApproveDate", null);
                }

                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("AssessmentID", null);

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
                sSql = "UPDATE t_HRAssessment SET AssessmentType = ?, Status = ?, AssessmentYear = ?,  BasicSalary = ?, GrossSalary = ?, IncrementAmount = ?, YearofLastPromotion = ?,  IsActive = ?, AssessmentID = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("AssessmentType", _nAssessmentType);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("AssessmentYear", _nAssessmentYear);
                cmd.Parameters.AddWithValue("BasicSalary", _BasicSalary);
                cmd.Parameters.AddWithValue("GrossSalary", _GrossSalary);
                cmd.Parameters.AddWithValue("IncrementAmount", _IncrementAmount);
                cmd.Parameters.AddWithValue("YearofLastPromotion", _nYearofLastPromotion);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("AssessmentID", _nAssessmentID);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void StatusUpdate()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_HRAssessment SET Status = ? WHERE ID = ? and AssessmentID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("AssessmentID", _nAssessmentID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void StatusUpdateAssessmentEmployee()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_HRAssessmentEmployee SET Status = ? WHERE AssessmentID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("AssessmentID", _nAssessmentID);

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
                sSql = "UPDATE t_HRAssessment SET EmployeeID = ?, DesignationID = ?, DepartmentID = ?," +
                       " CompanyID = ?, AssessmentType = ?, AssessmentYear = ?, FromDate = ?, ToDate = ?, " +
                       " BasicSalary = ?, GrossSalary = ?, IncrementAmount = ?, YearofLastPromotion = ?," +
                       " AcademicQualification = ?, LineManagerID = ?, SalesTarget = ?, Achievement = ?, " +
                       " TargetForm = ?, TargetTo = ?, IsActive = ? WHERE ID = ?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("DesignationID", _nDesignationID);
                cmd.Parameters.AddWithValue("DepartmentID", _nDepartmentID);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("AssessmentType", _nAssessmentType);
                cmd.Parameters.AddWithValue("AssessmentYear", _nAssessmentYear);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("BasicSalary", _BasicSalary);
                cmd.Parameters.AddWithValue("GrossSalary", _GrossSalary);
                cmd.Parameters.AddWithValue("IncrementAmount", _IncrementAmount);

                if (_nYearofLastPromotion != -1)
                {
                    cmd.Parameters.AddWithValue("YearofLastPromotion", _nYearofLastPromotion);
                }
                else
                {
                    cmd.Parameters.AddWithValue("YearofLastPromotion", null);
                }

                cmd.Parameters.AddWithValue("AcademicQualification", _sAcademicQualification);
                cmd.Parameters.AddWithValue("LineManagerID", _nLineManagerID);

                if (_SalesTarget != -1)
                {
                    cmd.Parameters.AddWithValue("SalesTarget", _SalesTarget);
                }
                else
                {
                    cmd.Parameters.AddWithValue("SalesTarget", null);
                }


                if (_Achievement != -1)
                {
                    cmd.Parameters.AddWithValue("Achievement", _Achievement);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Achievement", null);
                }

                if (_dTargetForm != null)
                {
                    cmd.Parameters.AddWithValue("TargetForm", _dTargetForm);
                }
                else
                {
                    cmd.Parameters.AddWithValue("TargetForm", null);
                }

                if (_dTargetTo != null)
                {

                    cmd.Parameters.AddWithValue("TargetTo", _dTargetTo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("TargetTo", null);
                }
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                //cmd.Parameters.AddWithValue("Status", _nStatus);

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
                sSql = "DELETE FROM t_HRAssessment WHERE [ID]=?";
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

        public void FindEmployeeDetails(int empId)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = @"Select EmployeeCode From t_EmployeeLineManager a,t_Employee b
                                    where a.LineManagerId=b.EmployeeID and LineManagerType=2 
                                    and a.EmployeeId =?
                                    and Priority=0";


                cmd.Parameters.AddWithValue("EmployeeId", empId);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nEmployeeCode = (string)reader["EmployeeCode"];

                    nCount++;
                }
                reader.Close();
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
                cmd.CommandText = "SELECT * FROM t_HRAssessment where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _nDesignationID = (int)reader["DesignationID"];
                    _nDepartmentID = (int)reader["DepartmentID"];
                    _nCompanyID = (int)reader["CompanyID"];
                    _nAssessmentType = (int)reader["AssessmentType"];
                    _nAssessmentYear = (int)reader["AssessmentYear"];
                    _dFromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    _dToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    _BasicSalary = Convert.ToDouble(reader["BasicSalary"].ToString());
                    _GrossSalary = Convert.ToDouble(reader["GrossSalary"].ToString());
                    _IncrementAmount = Convert.ToDouble(reader["IncrementAmount"].ToString());
                    _nYearofLastPromotion = (int)reader["YearofLastPromotion"];
                    _sAcademicQualification = (string)reader["AcademicQualification"];
                    _nLineManagerID = (int)reader["LineManagerID"];
                    _SalesTarget = Convert.ToDouble(reader["SalesTarget"].ToString());
                    _Achievement = Convert.ToDouble(reader["Achievement"].ToString());
                    _dTargetForm = Convert.ToDateTime(reader["TargetForm"].ToString());
                    _dTargetTo = Convert.ToDateTime(reader["TargetTo"].ToString());
                    _nIsActive = (int)reader["IsActive"];
                    _nStatus = (int)reader["Status"];
                    _nAssessmentID = (int)reader["AssessmentID"];
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
    public class HRAssessments : CollectionBase
    {
        public HRAssessment this[int i]
        {
            get { return (HRAssessment)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HRAssessment oHRAssessment)
        {
            InnerList.Add(oHRAssessment);
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
        public void Refresh(string empCode, int assessmentType, int designationId, int departmentId, int companyId, string lineManager, string assessmentYear)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = @"select a.*, b.EmployeeCode, b.EmployeeName, c.DesignationName, d.DepartmentName, 
                        e.CompanyName,f.Employeecode as LineManagerCode, f.EmployeeName as LineManagerName
                        from t_HRAssessment a, t_Employee b, t_Designation c, t_Department d, t_Company e,t_Employee f
                        where a.EmployeeID = b.EmployeeID and a.DesignationID = c.DesignationID and
                        a.DepartmentID = d.DepartmentID and a.CompanyID = e.CompanyID and a.LineManagerID = f.EmployeeID";


            if (empCode != "")
            {
                sSql = sSql + " AND b.EmployeeCode like '%" + empCode + "%'";
            }

            if (assessmentType != -1)
            {
                sSql = sSql + " AND a.AssessmentType=" + assessmentType + "";
            }

            if (designationId != -1)
            {
                sSql = sSql + " AND a.DesignationID=" + designationId + "";
            }

            if (departmentId != -1)
            {
                sSql = sSql + " AND a.DepartmentID=" + departmentId + "";
            }

            if (companyId != -1)
            {
                sSql = sSql + " AND a.CompanyID=" + companyId + "";
            }

            if (lineManager != "")
            {
                sSql = sSql + " AND f.EmployeeName like '%" + lineManager + "%'";
            }

            if (assessmentYear != "")
            {
                sSql = sSql + " AND a.AssessmentYear like '%" + assessmentYear + "%'";
            }


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRAssessment oHRAssessment = new HRAssessment();
                    oHRAssessment.ID = (int)reader["ID"];
                    oHRAssessment.EmployeeID = (int)reader["EmployeeID"];
                    oHRAssessment.DesignationID = (int)reader["DesignationID"];
                    oHRAssessment.DepartmentID = (int)reader["DepartmentID"];
                    oHRAssessment.CompanyID = (int)reader["CompanyID"];

                    if (reader["AssessmentType"] != DBNull.Value)
                        oHRAssessment.AssessmentType = (int)reader["AssessmentType"];
                    else oHRAssessment.AssessmentType = 0;

                    oHRAssessment.AssessmentYear = (int)reader["AssessmentYear"];
                    oHRAssessment.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oHRAssessment.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    oHRAssessment.BasicSalary = Convert.ToDouble(reader["BasicSalary"].ToString());
                    oHRAssessment.GrossSalary = Convert.ToDouble(reader["GrossSalary"].ToString());
                    oHRAssessment.IncrementAmount = Convert.ToDouble(reader["IncrementAmount"].ToString());

                    if (reader["YearofLastPromotion"] != DBNull.Value)
                        oHRAssessment.YearofLastPromotion = (int)reader["YearofLastPromotion"];
                    else oHRAssessment.YearofLastPromotion = 0;

                    if (reader["AcademicQualification"] != DBNull.Value)
                        oHRAssessment.AcademicQualification = (string)reader["AcademicQualification"];
                    else oHRAssessment.AcademicQualification = "null";

                    if (reader["LineManagerID"] != DBNull.Value)
                        oHRAssessment.LineManagerID = (int)reader["LineManagerID"];
                    else oHRAssessment.LineManagerID = 0;

                    if (reader["SalesTarget"] != DBNull.Value)
                        oHRAssessment.SalesTarget = Convert.ToDouble(reader["SalesTarget"].ToString());
                    else oHRAssessment.SalesTarget = 0;

                    if (reader["Achievement"] != DBNull.Value)
                        oHRAssessment.Achievement = Convert.ToDouble(reader["Achievement"].ToString());
                    else oHRAssessment.Achievement = 0;

                    if (reader["TargetForm"] != DBNull.Value)
                        oHRAssessment.TargetForm = Convert.ToDateTime(reader["TargetForm"].ToString());
                    if (reader["TargetTo"] != DBNull.Value)
                        oHRAssessment.TargetTo = Convert.ToDateTime(reader["TargetTo"].ToString());
                    oHRAssessment.IsActive = (int)reader["IsActive"];
                    oHRAssessment.Status = (int)reader["Status"];

                    if (reader["AssessmentID"] != DBNull.Value)
                        oHRAssessment.AssessmentID = (int)reader["AssessmentID"];
                    else oHRAssessment.AssessmentID = 0;

                    oHRAssessment.EmployeeCode = (string)reader["EmployeeCode"];
                    oHRAssessment.EmployeeName = (string)reader["EmployeeName"];
                    oHRAssessment.DesignationName = (string)reader["DesignationName"];
                    oHRAssessment.DepartmentName = (string)reader["DepartmentName"];
                    oHRAssessment.CompanyName = (string)reader["CompanyName"];
                    oHRAssessment.LineManagerCode = (string)reader["LineManagerCode"];
                    oHRAssessment.LineManagerName = (string)reader["LineManagerName"];

                    InnerList.Add(oHRAssessment);
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


