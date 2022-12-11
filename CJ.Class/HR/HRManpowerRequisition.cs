// <summary>
// Company: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Nov 20, 2017
// Time : 04:39 PM
// Description: Class for HRManpowerRequisition.
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
    public class HRManpowerRequisition
    {
        private int _nMRID;
        private string _sMRNo;
        private DateTime _dRequisitionDate;
        private int _nVacancyType;
        private string _sReplacementDetail;
        private int _nDepartmentID;
        private int _nDesignationID;
        private int _nNoOfVacancy;
        private int _nGrade;
        private int _nTypeOfEmployment;
        private int _nContractPeriod;
        private int _nEmployeeStatus;
        private string _sEducationalQualification;
        private string _sEducationMajor;
        private string _sAge;
        private string _sExperience;
        private double _SalaryRange;
        private int _nReportto;
        private int _nWithinBudget;
        private int _nAdditionBudget;
        private string _sOthers;
        private string _sResponsibility;
        private int _nCreateUserID;
        private DateTime _dCreateDate;


        private string _sDepartmentName;
        public string DepartmentName
        {
            get { return _sDepartmentName; }
            set { _sDepartmentName = value.Trim(); }
        }
        private string _sDesignationName;
        public string DesignationName
        {
            get { return _sDesignationName; }
            set { _sDesignationName = value.Trim(); }
        }
        private string _sJobGradeName;
        public string JobGradeName
        {
            get { return _sJobGradeName; }
            set { _sJobGradeName = value.Trim(); }
        }
        private string _sPositionName;
        public string PositionName
        {
            get { return _sPositionName; }
            set { _sPositionName = value.Trim(); }
        }

        // <summary>
        // Get set property for MRID
        // </summary>
        public int MRID
        {
            get { return _nMRID; }
            set { _nMRID = value; }
        }

        // <summary>
        // Get set property for MRNo
        // </summary>
        public string MRNo
        {
            get { return _sMRNo; }
            set { _sMRNo = value.Trim(); }
        }

        // <summary>
        // Get set property for RequisitionDate
        // </summary>
        public DateTime RequisitionDate
        {
            get { return _dRequisitionDate; }
            set { _dRequisitionDate = value; }
        }

        // <summary>
        // Get set property for VacancyType
        // </summary>
        public int VacancyType
        {
            get { return _nVacancyType; }
            set { _nVacancyType = value; }
        }

        // <summary>
        // Get set property for ReplacementDetail
        // </summary>
        public string ReplacementDetail
        {
            get { return _sReplacementDetail; }
            set { _sReplacementDetail = value.Trim(); }
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
        // Get set property for DesignationID
        // </summary>
        public int DesignationID
        {
            get { return _nDesignationID; }
            set { _nDesignationID = value; }
        }

        // <summary>
        // Get set property for NoOfVacancy
        // </summary>
        public int NoOfVacancy
        {
            get { return _nNoOfVacancy; }
            set { _nNoOfVacancy = value; }
        }

        // <summary>
        // Get set property for Grade
        // </summary>
        public int Grade
        {
            get { return _nGrade; }
            set { _nGrade = value; }
        }

        // <summary>
        // Get set property for TypeOfEmployment
        // </summary>
        public int TypeOfEmployment
        {
            get { return _nTypeOfEmployment; }
            set { _nTypeOfEmployment = value; }
        }

        // <summary>
        // Get set property for ContractPeriod
        // </summary>
        public int ContractPeriod
        {
            get { return _nContractPeriod; }
            set { _nContractPeriod = value; }
        }

        // <summary>
        // Get set property for EmployeeStatus
        // </summary>
        public int EmployeeStatus
        {
            get { return _nEmployeeStatus; }
            set { _nEmployeeStatus = value; }
        }

        // <summary>
        // Get set property for EducationalQualification
        // </summary>
        public string EducationalQualification
        {
            get { return _sEducationalQualification; }
            set { _sEducationalQualification = value.Trim(); }
        }

        // <summary>
        // Get set property for EducationMajor
        // </summary>
        public string EducationMajor
        {
            get { return _sEducationMajor; }
            set { _sEducationMajor = value.Trim(); }
        }

        // <summary>
        // Get set property for Age
        // </summary>
        public string Age
        {
            get { return _sAge; }
            set { _sAge = value.Trim(); }
        }

        // <summary>
        // Get set property for Experience
        // </summary>
        public string Experience
        {
            get { return _sExperience; }
            set { _sExperience = value.Trim(); }
        }

        // <summary>
        // Get set property for SalaryRange
        // </summary>
        public double SalaryRange
        {
            get { return _SalaryRange; }
            set { _SalaryRange = value; }
        }

        // <summary>
        // Get set property for Reportto
        // </summary>
        public int Reportto
        {
            get { return _nReportto; }
            set { _nReportto = value; }
        }

        // <summary>
        // Get set property for WithinBudget
        // </summary>
        public int WithinBudget
        {
            get { return _nWithinBudget; }
            set { _nWithinBudget = value; }
        }

        // <summary>
        // Get set property for AdditionBudget
        // </summary>
        public int AdditionBudget
        {
            get { return _nAdditionBudget; }
            set { _nAdditionBudget = value; }
        }

        // <summary>
        // Get set property for Others
        // </summary>
        public string Others
        {
            get { return _sOthers; }
            set { _sOthers = value.Trim(); }
        }

        // <summary>
        // Get set property for Responsibility
        // </summary>
        public string Responsibility
        {
            get { return _sResponsibility; }
            set { _sResponsibility = value.Trim(); }
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

        public void Add()
        {
            int nMaxMRID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([MRID]) FROM t_HRManpowerRequisition";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxMRID = 1;
                }
                else
                {
                    nMaxMRID = Convert.ToInt32(maxID) + 1;
                }
                _nMRID = nMaxMRID;
                _sMRNo = "MR" + "-" + DateTime.Now.Year.ToString() + "-" + nMaxMRID.ToString("0000");

                sSql = "INSERT INTO t_HRManpowerRequisition (MRID, MRNo, RequisitionDate, VacancyType, ReplacementDetail, DepartmentID, DesignationID, NoOfVacancy, Grade, TypeOfEmployment, ContractPeriod, EmployeeStatus, EducationalQualification, EducationMajor, Age, Experience, SalaryRange, Reportto, WithinBudget, AdditionBudget, Others, Responsibility, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("MRID", _nMRID);
                cmd.Parameters.AddWithValue("MRNo", _sMRNo);
                cmd.Parameters.AddWithValue("RequisitionDate", _dRequisitionDate);
                cmd.Parameters.AddWithValue("VacancyType", _nVacancyType);
                cmd.Parameters.AddWithValue("ReplacementDetail", _sReplacementDetail);
                cmd.Parameters.AddWithValue("DepartmentID", _nDepartmentID);
                cmd.Parameters.AddWithValue("DesignationID", _nDesignationID);
                cmd.Parameters.AddWithValue("NoOfVacancy", _nNoOfVacancy);
                cmd.Parameters.AddWithValue("Grade", _nGrade);
                cmd.Parameters.AddWithValue("TypeOfEmployment", _nTypeOfEmployment);
                cmd.Parameters.AddWithValue("ContractPeriod", _nContractPeriod);
                cmd.Parameters.AddWithValue("EmployeeStatus", _nEmployeeStatus);
                cmd.Parameters.AddWithValue("EducationalQualification", _sEducationalQualification);
                cmd.Parameters.AddWithValue("EducationMajor", _sEducationMajor);
                cmd.Parameters.AddWithValue("Age", _sAge);
                cmd.Parameters.AddWithValue("Experience", _sExperience);
                cmd.Parameters.AddWithValue("SalaryRange", _SalaryRange);
                cmd.Parameters.AddWithValue("Reportto", _nReportto);
                cmd.Parameters.AddWithValue("WithinBudget", _nWithinBudget);
                cmd.Parameters.AddWithValue("AdditionBudget", _nAdditionBudget);
                cmd.Parameters.AddWithValue("Others", _sOthers);
                cmd.Parameters.AddWithValue("Responsibility", _sResponsibility);
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
                sSql = "UPDATE t_HRManpowerRequisition SET MRNo = ?, RequisitionDate = ?, VacancyType = ?, ReplacementDetail = ?, DepartmentID = ?, DesignationID = ?, NoOfVacancy = ?, Grade = ?, TypeOfEmployment = ?, ContractPeriod = ?, EmployeeStatus = ?, EducationalQualification = ?, EducationMajor = ?, Age = ?, Experience = ?, SalaryRange = ?, Reportto = ?, WithinBudget = ?, AdditionBudget = ?, Others = ?, Responsibility = ?, CreateUserID = ?, CreateDate = ? WHERE MRID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("MRNo", _sMRNo);
                cmd.Parameters.AddWithValue("RequisitionDate", _dRequisitionDate);
                cmd.Parameters.AddWithValue("VacancyType", _nVacancyType);
                cmd.Parameters.AddWithValue("ReplacementDetail", _sReplacementDetail);
                cmd.Parameters.AddWithValue("DepartmentID", _nDepartmentID);
                cmd.Parameters.AddWithValue("DesignationID", _nDesignationID);
                cmd.Parameters.AddWithValue("NoOfVacancy", _nNoOfVacancy);
                cmd.Parameters.AddWithValue("Grade", _nGrade);
                cmd.Parameters.AddWithValue("TypeOfEmployment", _nTypeOfEmployment);
                cmd.Parameters.AddWithValue("ContractPeriod", _nContractPeriod);
                cmd.Parameters.AddWithValue("EmployeeStatus", _nEmployeeStatus);
                cmd.Parameters.AddWithValue("EducationalQualification", _sEducationalQualification);
                cmd.Parameters.AddWithValue("EducationMajor", _sEducationMajor);
                cmd.Parameters.AddWithValue("Age", _sAge);
                cmd.Parameters.AddWithValue("Experience", _sExperience);
                cmd.Parameters.AddWithValue("SalaryRange", _SalaryRange);
                cmd.Parameters.AddWithValue("Reportto", _nReportto);
                cmd.Parameters.AddWithValue("WithinBudget", _nWithinBudget);
                cmd.Parameters.AddWithValue("AdditionBudget", _nAdditionBudget);
                cmd.Parameters.AddWithValue("Others", _sOthers);
                cmd.Parameters.AddWithValue("Responsibility", _sResponsibility);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.Parameters.AddWithValue("MRID", _nMRID);

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
                sSql = "DELETE FROM t_HRManpowerRequisition WHERE [MRID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("MRID", _nMRID);
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
                cmd.CommandText = "SELECT * FROM t_HRManpowerRequisition where MRID =?";
                cmd.Parameters.AddWithValue("MRID", _nMRID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nMRID = (int)reader["MRID"];
                    _sMRNo = (string)reader["MRNo"];
                    _dRequisitionDate = Convert.ToDateTime(reader["RequisitionDate"].ToString());
                    _nVacancyType = (int)reader["VacancyType"];
                    _sReplacementDetail = (string)reader["ReplacementDetail"];
                    _nDepartmentID = (int)reader["DepartmentID"];
                    _nDesignationID = (int)reader["DesignationID"];
                    _nNoOfVacancy = (int)reader["NoOfVacancy"];
                    _nGrade = (int)reader["Grade"];
                    _nTypeOfEmployment = (int)reader["TypeOfEmployment"];
                    _nContractPeriod = (int)reader["ContractPeriod"];
                    _nEmployeeStatus = (int)reader["EmployeeStatus"];
                    _sEducationalQualification = (string)reader["EducationalQualification"];
                    _sEducationMajor = (string)reader["EducationMajor"];
                    _sAge = (string)reader["Age"];
                    _sExperience = (string)reader["Experience"];
                    _SalaryRange = Convert.ToDouble(reader["SalaryRange"].ToString());
                    _nReportto = (int)reader["Reportto"];
                    _nWithinBudget = (int)reader["WithinBudget"];
                    _nAdditionBudget = (int)reader["AdditionBudget"];
                    _sOthers = (string)reader["Others"];
                    _sResponsibility = (string)reader["Responsibility"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
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
    public class HRManpowerRequisitions : CollectionBase
    {
        public HRManpowerRequisition this[int i]
        {
            get { return (HRManpowerRequisition)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HRManpowerRequisition oHRManpowerRequisition)
        {
            InnerList.Add(oHRManpowerRequisition);
        }
        public int GetIndex(int nMRID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].MRID == nMRID)
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
            string sSql = "SELECT * FROM t_HRManpowerRequisition";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRManpowerRequisition oHRManpowerRequisition = new HRManpowerRequisition();
                    oHRManpowerRequisition.MRID = (int)reader["MRID"];
                    oHRManpowerRequisition.MRNo = (string)reader["MRNo"];
                    oHRManpowerRequisition.RequisitionDate = Convert.ToDateTime(reader["RequisitionDate"].ToString());
                    oHRManpowerRequisition.VacancyType = (int)reader["VacancyType"];
                    oHRManpowerRequisition.ReplacementDetail = (string)reader["ReplacementDetail"];
                    oHRManpowerRequisition.DepartmentID = (int)reader["DepartmentID"];
                    oHRManpowerRequisition.DesignationID = (int)reader["DesignationID"];
                    oHRManpowerRequisition.NoOfVacancy = (int)reader["NoOfVacancy"];
                    oHRManpowerRequisition.Grade = (int)reader["Grade"];
                    oHRManpowerRequisition.TypeOfEmployment = (int)reader["TypeOfEmployment"];
                    oHRManpowerRequisition.ContractPeriod = (int)reader["ContractPeriod"];
                    oHRManpowerRequisition.EmployeeStatus = (int)reader["EmployeeStatus"];
                    oHRManpowerRequisition.EducationalQualification = (string)reader["EducationalQualification"];
                    oHRManpowerRequisition.EducationMajor = (string)reader["EducationMajor"];
                    oHRManpowerRequisition.Age = (string)reader["Age"];
                    oHRManpowerRequisition.Experience = (string)reader["Experience"];
                    oHRManpowerRequisition.SalaryRange = Convert.ToDouble(reader["SalaryRange"].ToString());
                    oHRManpowerRequisition.Reportto = (int)reader["Reportto"];
                    oHRManpowerRequisition.WithinBudget = (int)reader["WithinBudget"];
                    oHRManpowerRequisition.AdditionBudget = (int)reader["AdditionBudget"];
                    oHRManpowerRequisition.Others = (string)reader["Others"];
                    oHRManpowerRequisition.Responsibility = (string)reader["Responsibility"];
                    oHRManpowerRequisition.CreateUserID = (int)reader["CreateUserID"];
                    oHRManpowerRequisition.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oHRManpowerRequisition);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh(DateTime dFromDate, DateTime dToDate, string sMRNo, int nDepartment, bool IsCheck)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            {
                sSql = "Select MRID,MRNo,RequisitionDate,VacancyType,isnull(ReplacementDetail,'') ReplacementDetail,a.DepartmentID, " +
                            "a.DesignationID,NoOfVacancy,Grade,TypeOfEmployment,ContractPeriod,EmployeeStatus,EducationalQualification, " +
                            "EducationMajor,Age,Experience,SalaryRange,Reportto,WithinBudget,AdditionBudget,isnull(Others,'') as Others, " +
                            "Responsibility,a.CreateUserID,a.CreateDate,DepartmentName,DesignationName,JobGradeName,PositionName+' '+'['+PositionCode+']' as  PositionName " +
                            "From t_HRManpowerRequisition a,t_Department b,t_Designation c,t_JobGrade d,t_HRPosition e " +
                            "where a.DepartmentID=b.DepartmentID and a.DesignationID=c.DesignationID and a.Grade=d.JobGradeID " +
                            "and a.Reportto=e.PositionID";
            }
            if (IsCheck == false)
            {
                sSql = sSql + " and RequisitionDate between '" + dFromDate + "' and '" + dToDate + "' and VisitDate<'" + dToDate + "' ";
            }

            if (nDepartment != -1)
            {
                sSql = sSql + " AND a.DepartmentID=" + nDepartment + "";
            }

            if (sMRNo != "")
            {
                sSql = sSql + " AND MRNo like '%" + sMRNo + "%'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRManpowerRequisition oHRManpowerRequisition = new HRManpowerRequisition();
                    oHRManpowerRequisition.MRID = (int)reader["MRID"];
                    oHRManpowerRequisition.MRNo = (string)reader["MRNo"];
                    oHRManpowerRequisition.RequisitionDate = Convert.ToDateTime(reader["RequisitionDate"].ToString());
                    oHRManpowerRequisition.VacancyType = (int)reader["VacancyType"];
                    oHRManpowerRequisition.ReplacementDetail = (string)reader["ReplacementDetail"];
                    oHRManpowerRequisition.DepartmentID = (int)reader["DepartmentID"];
                    oHRManpowerRequisition.DesignationID = (int)reader["DesignationID"];
                    oHRManpowerRequisition.NoOfVacancy = (int)reader["NoOfVacancy"];
                    oHRManpowerRequisition.Grade = (int)reader["Grade"];
                    oHRManpowerRequisition.TypeOfEmployment = (int)reader["TypeOfEmployment"];
                    oHRManpowerRequisition.ContractPeriod = (int)reader["ContractPeriod"];
                    oHRManpowerRequisition.EmployeeStatus = (int)reader["EmployeeStatus"];
                    oHRManpowerRequisition.EducationalQualification = (string)reader["EducationalQualification"];
                    oHRManpowerRequisition.EducationMajor = (string)reader["EducationMajor"];
                    oHRManpowerRequisition.Age = (string)reader["Age"];
                    oHRManpowerRequisition.Experience = (string)reader["Experience"];
                    oHRManpowerRequisition.SalaryRange = Convert.ToDouble(reader["SalaryRange"].ToString());
                    oHRManpowerRequisition.Reportto = (int)reader["Reportto"];
                    oHRManpowerRequisition.WithinBudget = (int)reader["WithinBudget"];
                    oHRManpowerRequisition.AdditionBudget = (int)reader["AdditionBudget"];
                    oHRManpowerRequisition.Others = (string)reader["Others"];
                    oHRManpowerRequisition.Responsibility = (string)reader["Responsibility"];
                    oHRManpowerRequisition.CreateUserID = (int)reader["CreateUserID"];
                    oHRManpowerRequisition.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oHRManpowerRequisition.DepartmentName = (string)reader["DepartmentName"];
                    oHRManpowerRequisition.DesignationName = (string)reader["DesignationName"];
                    oHRManpowerRequisition.JobGradeName = (string)reader["JobGradeName"];
                    oHRManpowerRequisition.PositionName = (string)reader["PositionName"];

                    InnerList.Add(oHRManpowerRequisition);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetHOPotentialCustomer(DateTime dFromDate, DateTime dToDate, string sCustomerName, string sMobile, int nMAGID, int nSource, bool IsCheck)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);
            string sSql = "";
            {
                sSql = "Select ID,Name,VisitDate,isnull(CompanyName,'') CompanyName,isnull(Designation,'') Designation, " +
                    "isnull(MobileNo,'') MobileNo,isnull(TelephoneNo,'') TelephoneNo,isnull(Address,'') Address,  " +
                    "isnull(Email,'') Email,isnull(Remarks,'') Remarks,CreateDate,CreateUserID,Status,MAGID, " +
                    "PdtGroupName as MAGName,CustType as Source From t_PotentialCustomerList a,t_ProductGroup b " +
                    "where a.MAGID=b.PdtGroupID and Outlet=-1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " and VisitDate between '" + dFromDate + "' and '" + dToDate + "' and VisitDate<'" + dToDate + "' ";
            }

            if (nMAGID != -1)
            {
                sSql = sSql + " AND MAGID=" + nMAGID + "";
            }
            if (nSource != -1)
            {
                sSql = sSql + " AND CustType=" + nSource + "";
            }

            if (sCustomerName != "")
            {
                sSql = sSql + " AND Name like '%" + sCustomerName + "%'";
            }

            if (sMobile != "")
            {
                sSql = sSql + " AND MobileNo like '%" + sMobile + "%'";
            }

            sSql = sSql + " Order by VisitDate Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PotentialCustomer oPotentialCustomer = new PotentialCustomer();

                    oPotentialCustomer.ID = (int)reader["ID"];
                    oPotentialCustomer.Name = (string)reader["Name"];
                    oPotentialCustomer.Address = (string)reader["Address"];
                    oPotentialCustomer.MobileNo = (string)reader["MobileNo"];
                    oPotentialCustomer.Email = (string)reader["Email"];
                    oPotentialCustomer.CreateUserID = (int)reader["CreateUserID"];
                    oPotentialCustomer.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oPotentialCustomer.VisitDate = Convert.ToDateTime(reader["VisitDate"].ToString());
                    oPotentialCustomer.Source = Convert.ToInt32(reader["Source"].ToString());
                    oPotentialCustomer.MAGID = Convert.ToInt32(reader["MAGID"].ToString());
                    oPotentialCustomer.Status = Convert.ToInt32(reader["Status"].ToString());
                    oPotentialCustomer.MAGName = (string)reader["MAGName"];
                    oPotentialCustomer.CompanyName = (string)reader["CompanyName"];
                    oPotentialCustomer.Designation = (string)reader["Designation"];
                    oPotentialCustomer.TelephoneNo = (string)reader["TelephoneNo"];
                    oPotentialCustomer.Remarks = (string)reader["Remarks"];

                    InnerList.Add(oPotentialCustomer);
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

