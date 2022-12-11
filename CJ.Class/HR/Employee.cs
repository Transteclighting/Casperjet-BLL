// <summary>
// Compamy: Transcom Electronics Limited
// Author: Mazharul Haque
// Date: April 25, 2011
// Time :  04:16 PM
// Description: Class for Employee.
// Modify Person And Date: Md. Abdul Hakim 12-Nov-2012/ Employee Floor related 
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Data.SqlClient;
using CJ.Class.HR;

namespace CJ.Class
{
    public class Employee
    {
    
        private int _nEmpHistoryStatus;
        public int EmpHistoryStatus
        {
            get { return _nEmpHistoryStatus; }
            set { _nEmpHistoryStatus = value; }
        }

        private DateTime _dEffectiveDate;

        public DateTime EffectiveDate
        {
            get { return _dEffectiveDate; }
            set { _dEffectiveDate = value; }
        }
        private int _nType;
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
        }
        private int _nHistoryID;
        public int HistoryID
        {
            get { return _nHistoryID; }
            set { _nHistoryID = value; }
        }
        private int _nFrom;
        public int From
        {
            get { return _nFrom; }
            set { _nFrom = value; }
        }
        private int _nTo;
        public int To
        {
            get { return _nTo; }
            set { _nTo = value; }
        }
        private string _sRemarks;
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }
        private int _nEmployeeID; 
        private string _sEmployeeCode;
        private string _sEmployeeName; 
        private string _sCardNo; 
        private string _sPhotograph; 
        private string _sGender; 
        private DateTime _dDateOfBirth; 
        private DateTime _dJoiningDate;
        private object _dConfirmDate; 
        private string _sPresentAddress; 
        private string _sPermanantAddress; 
        private string _sTelephone; 
        private string _sMobile;
        private int _nMobileID;
        private string _sEmail;
        private string _sFax; 
        private string _sNationality; 
        private string _sPlaceofBirth; 
        private string _sReligion; 
        private string _sMaritialStatus; 
        private string _sBloodGroup; 
        private string _sPassportNo; 
        private string _sTINNo;
        private string _sNationalID; 
        private string _sFatherName; 
        private string _sFatherOccupation; 
        private string _sMotherName; 
        private string _sMotherOccupation; 
        private DateTime _dMarriageDate; 
        private string _sSpouseName; 
        private string _sSpouseOccupation;
        private int _nCompanyID;
        private int _nDepartmentID;
        private int _nGradeID; 
        private int _nDesignationID;
        private int _nLocationID;
        private int _nShiftID;
        private int _nEmployeeType;
        private string _sEmployeeCategory;
        private int _nEmpStatus; 
        private int _nBranchID; 
        private string _sBankAccountNo; 
        private int _nPaymentMode; 
        private double _nBasicSalary;
        private string _sJoblocationName;
        private object _Late;
        private object _TimeIn;
        private DateTime _dPunchDate;
        public string JoblocationName
        {
            get { return _sJoblocationName; }
            set { _sJoblocationName = value.Trim(); }
        }
        private string _sDesignationName; 

        private Company _oCompany;
        private Department _oDepartment;
        private Designation _oDesignation;
        private JobGrade _oJobGrade;
        private JobLocation _oJobLocation;
        private Shift _oShift;

        private int _nFloor;
        private string _sRoom;
        private int _nShowAttendanceRpt;

        private bool _bReadDB;
        private int _nSectionID;
        private string _sSectionName;
        private string _sComapanyName;
        private string _sDepartmentName;

        private int _nUserID;
        private string _sUserName;
        private int _nEBankID;
        private object _dSeparationDate;
        private int _nIsPayrollEmployee;
        private string _sCategory;
        private int _nIsWFH;

        public string Category
        {
            get { return _sCategory; }
            set { _sCategory = value.Trim(); }
        }

        public int IsPayrollEmployee
        {
            get { return _nIsPayrollEmployee; }
            set { _nIsPayrollEmployee = value; }
        }

        public object SeparationDate
        {
            get { return _dSeparationDate; }
            set { _dSeparationDate = value; }
        }

        /// <summary>
        /// Get set property for BankID
        /// </summary>
        public int EBankID
        {
            get { return _nEBankID; }
            set { _nEBankID = value; }
        }
        private byte _EmployeePhoto;
        public byte EmployeePhoto
        {
            get { return _EmployeePhoto; }
            set { _EmployeePhoto = value; }
        }
        private int _nIsFactory;
        public int IsFactory
        {
            get { return _nIsFactory; }
            set { _nIsFactory = value; }
        }

        /// <summary>
        /// Get set property for UserID
        /// </summary>
        public int UserID
        {
            get { return _nUserID; }
            set { _nUserID = value; }
        }

        /// <summary>
        /// Get set property for UserName
        /// </summary>
        public string UserName
        {
            get { return _sUserName; }
            set { _sUserName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for SectionID
        /// </summary>
        public int SectionID
        {
            get { return _nSectionID; }
            set { _nSectionID = value; }
        }

        /// <summary>
        /// Get set property for SectionName
        /// </summary>
        public string SectionName
        {
            get { return _sSectionName; }
            set { _sSectionName = value.Trim(); }
        }

        private int _nDivisionID;
        public int DivisionID
        {
            get { return _nDivisionID; }
            set { _nDivisionID = value; }
        }


        private string _sDivisionName;
        public string DivisionName
        {
            get { return _sDivisionName; }
            set { _sDivisionName = value.Trim(); }
        }


        private int _nSBUID;
        public int SBUID
        {
            get { return _nSBUID; }
            set { _nSBUID = value; }
        }


        private string _sSBUName;
        public string SBUName
        {
            get { return _sSBUName; }
            set { _sSBUName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for ComapanyName
        /// </summary>
        public string ComapanyName
        {
            get { return _sComapanyName; }
            set { _sComapanyName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for DepartmentName
        /// </summary>
        public string DepartmentName
        {
            get { return _sDepartmentName; }
            set { _sDepartmentName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for EmployeeID
        /// </summary>
        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }
        /// <summary>
        /// Get set property for EmployeeCode
        /// </summary>
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value.Trim(); }
        }
        /// <summary>
        /// Get set property for CardNo
        /// </summary>
        public string CardNo
        {
            get { return _sCardNo; }
            set { _sCardNo = value.Trim(); }
        }
        /// <summary>
        /// Get set property for EmployeeName
        /// </summary>
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for Photograph
        /// </summary>
        public string Photograph
        {
            get { return _sPhotograph; }
            set { _sPhotograph = value.Trim(); }
        }
        /// <summary>
        /// Get set property for Gender
        /// </summary>
        public string Gender
        {
            get { return _sGender; }
            set { _sGender = value.Trim(); }
        }
        /// <summary>
        /// Get set property for DateOfBirth
        /// </summary>
        public DateTime DateOfBirth
        {
            get { return _dDateOfBirth; }
            set { _dDateOfBirth = value; }
        }
        /// <summary>
        /// Get set property for JoiningDate
        /// </summary>
        public DateTime JoiningDate
        {
            get { return _dJoiningDate; }
            set { _dJoiningDate = value; }
        }
        public DateTime PunchDate
        {
            get { return _dPunchDate; }
            set { _dPunchDate = value; }
        }
        //
        /// <summary>
        /// Get set property for PresentAddress
        /// </summary>
        public string PresentAddress
        {
            get { return _sPresentAddress; }
            set { _sPresentAddress = value.Trim(); }
        }
        /// <summary>
        /// Get set property for PermanantAddress
        /// </summary>
        public string PermanantAddress
        {
            get { return _sPermanantAddress; }
            set { _sPermanantAddress = value.Trim(); }
        }
        /// <summary>
        /// Get set property for Telephone
        /// </summary>
        public string Telephone
        {
            get { return _sTelephone; }
            set { _sTelephone = value.Trim(); }
        }
        /// <summary>
        /// Get set property for Mobile
        /// </summary>
        public string Mobile
        {
            get { return _sMobile; }
            set { _sMobile = value.Trim(); }
        }
        /// <summary>
        /// Get set property for Fax
        /// </summary>
        public string Fax
        {
            get { return _sFax; }
            set { _sFax = value.Trim(); }
        }
        /// <summary>
        /// Get set property for Nationality
        /// </summary>
        public string Nationality
        {
            get { return _sNationality; }
            set { _sNationality = value.Trim(); }
        }
        /// <summary>
        /// Get set property for PlaceofBirth
        /// </summary>
        public string PlaceofBirth
        {
            get { return _sPlaceofBirth; }
            set { _sPlaceofBirth = value.Trim(); }
        }
        /// <summary>
        /// Get set property for Religion
        /// </summary>
        public string Religion
        {
            get { return _sReligion; }
            set { _sReligion = value.Trim(); }
        }
        /// <summary>
        /// Get set property for MaritialStatus
        /// </summary>
        public string MaritialStatus
        {
            get { return _sMaritialStatus; }
            set { _sMaritialStatus = value.Trim(); }
        }
        /// <summary>
        /// Get set property for BloodGroup
        /// </summary>
        public string BloodGroup
        {
            get { return _sBloodGroup; }
            set { _sBloodGroup = value.Trim(); }
        }
        /// <summary>
        /// Get set property for PassportNo
        /// </summary>
        public string PassportNo
        {
            get { return _sPassportNo; }
            set { _sPassportNo = value.Trim(); }
        }
        /// <summary>
        /// Get set property for TINNo
        /// </summary>
        public string TINNo
        {
            get { return _sTINNo; }
            set { _sTINNo = value.Trim(); }
        }
        /// <summary>
        /// Get set property for FatherName
        /// </summary>
        public string FatherName
        {
            get { return _sFatherName; }
            set { _sFatherName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for FatherOccupation
        /// </summary>
        public string FatherOccupation
        {
            get { return _sFatherOccupation; }
            set { _sFatherOccupation = value.Trim(); }
        }
        /// <summary>
        /// Get set property for MotherName
        /// </summary>
        public string MotherName
        {
            get { return _sMotherName; }
            set { _sMotherName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for MotherOccupation
        /// </summary>
        public string MotherOccupation
        {
            get { return _sMotherOccupation; }
            set { _sMotherOccupation = value.Trim(); }
        }
        /// <summary>
        /// Get set property for MarriageDate
        /// </summary>
        public DateTime MarriageDate
        {
            get { return _dMarriageDate; }
            set { _dMarriageDate = value; }
        }
        /// <summary>
        /// Get set property for SpouseName
        /// </summary>
        public string SpouseName
        {
            get { return _sSpouseName; }
            set { _sSpouseName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for SpouseOccupation
        /// </summary>
        public string SpouseOccupation
        {
            get { return _sSpouseOccupation; }
            set { _sSpouseOccupation = value.Trim(); }
        }
        /// <summary>
        /// Get set property for EmpStatus
        /// </summary>
        public int EmpStatus
        {
            get { return _nEmpStatus; }
            set { _nEmpStatus = value; }
        }
        /// <summary>
        /// Get set property for ConfirmDate
        /// </summary>
        public object ConfirmDate
        {
            get { return _dConfirmDate; }
            set { _dConfirmDate = value; }
        }
        /// <summary>
        /// Get set property for BranchID
        /// </summary>
        public int BranchID
        {
            get { return _nBranchID; }
            set { _nBranchID = value; }
        }
        /// <summary>
        /// Get set property for BankAccountNo
        /// </summary>
        public string BankAccountNo
        {
            get { return _sBankAccountNo; }
            set { _sBankAccountNo = value.Trim(); }
        }
        /// <summary>
        /// Get set property for DepartmentID
        /// </summary>
        public int DepartmentID
        {
            get { return _nDepartmentID; }
            set { _nDepartmentID = value; }
        }
        /// <summary>
        /// Get set property for DesignationID
        /// </summary>
        public int DesignationID
        {
            get { return _nDesignationID; }
            set { _nDesignationID = value; }
        }
        /// <summary>
        /// Get set property for GradeID
        /// </summary>
        public int GradeID
        {
            get { return _nGradeID; }
            set { _nGradeID = value; }
        }
        private string _sEmergencyContact;
        public string EmergencyContact
        {
            get { return _sEmergencyContact; }
            set { _sEmergencyContact = value.Trim(); }
        }
        private string _sEmergencyContactRelationship;
        public string EmergencyContactRelationship
        {
            get { return _sEmergencyContactRelationship; }
            set { _sEmergencyContactRelationship = value.Trim(); }
        }
        private int _nEquivalentGradeID;
        public int EquivalentGradeID
        {
            get { return _nEquivalentGradeID; }
            set { _nEquivalentGradeID = value; }
        }
        /// <summary>
        /// Get set property for PaymentMode
        /// </summary>
        public int PaymentMode
        {
            get { return _nPaymentMode; }
            set { _nPaymentMode = value; }
        }
        /// <summary>
        /// Get set property for ShiftID
        /// </summary>
        public int ShiftID
        {
            get { return _nShiftID; }
            set { _nShiftID = value; }
        }
        /// <summary>
        /// Get set property for NationalID
        /// </summary>
        public string NationalID
        {
            get { return _sNationalID; }
            set { _sNationalID = value.Trim(); }
        }
        /// <summary>
        /// Get set property for CompanyID
        /// </summary>
        public int CompanyID
        {
            get { return _nCompanyID; }
            set { _nCompanyID = value; }
        }

        /// <summary>
        /// Get set property for EmployeeType
        /// </summary>
        public int EmployeeType
        {
            get { return _nEmployeeType; }
            set { _nEmployeeType = value; }
        }

        /// <summary>
        /// Get set property for EmployeeCategory
        /// </summary>
        public string EmployeeCategory
        {
            get { return _sEmployeeCategory; }
            set { _sEmployeeCategory = value.Trim(); }
        }

        /// <summary>
        /// Get set property for BasicSalary
        /// </summary>
        public double BasicSalary
        {
            get { return _nBasicSalary; }
            set { _nBasicSalary = value; }
        }


        /// <summary>
        /// Get set property for LocationID
        /// </summary>
        public int LocationID
        {
            get { return _nLocationID; }
            set { _nLocationID = value; }
        }

        /// <summary>
        /// Get set property for Email
        /// </summary>
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value.Trim(); }
        }

        /// <summary>
        /// Get set property for MobileID
        /// </summary>
        public int MobileID
        {
            get { return _nMobileID; }
            set { _nMobileID = value; }
        }

        public string DesignationName
        {
            get { return _sDesignationName; }
            set { _sDesignationName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for Floor
        /// </summary>
        public int Floor
        {
            get { return _nFloor; }
            set { _nFloor = value; }
        }

        /// <summary>
        /// Get set property for Room
        /// </summary>
        public string Room
        {
            get { return _sRoom; }
            set { _sRoom = value; }
        }

        /// <summary>
        /// Get set property for ShowAttendanceRpt
        /// </summary>
        public int ShowAttendanceRpt
        {
            get { return _nShowAttendanceRpt; }
            set { _nShowAttendanceRpt = value; }
        }
        public object Late
        {
            get { return _Late; }
            set { _Late = value; }
        }
        public object TimeIn
        {
            get { return _TimeIn; }
            set { _TimeIn = value; }
        }
        public Department Department
        {
            get
            {
                if (_oDepartment == null)
                {
                    _oDepartment = new Department();
                    _oDepartment.DepartmentID = _nDepartmentID;
                    if (_bReadDB)  _oDepartment.Refresh();
                }

                return _oDepartment;
            }
        }

        public Designation Designation
        {
            get
            {
                if (_oDesignation == null)
                {
                    _oDesignation = new Designation();
                    _oDesignation.DesignationID = _nDesignationID;
                    if (_bReadDB) _oDesignation.Refresh();
                }

                return _oDesignation;
            }
        }

        public Company Company
        {
            get
            {
                if (_oCompany == null)
                {
                    _oCompany = new Company();
                    _oCompany.CompanyID = _nCompanyID;
                    if (_bReadDB) _oCompany.Refresh();
                }

                return _oCompany;
            }
        }

        public JobGrade JobGrade
        {
            get
            {
                if (_oJobGrade == null)
                {
                    _oJobGrade = new JobGrade();
                    _oJobGrade.JobGradeID = _nGradeID;
                    if (_bReadDB) _oJobGrade.Refresh();
                }

                return _oJobGrade;
            }
        }

        public JobLocation JobLocation
        {
            get
            {
                if (_oJobLocation == null)
                {
                    _oJobLocation = new JobLocation();
                    _oJobLocation.JobLocationID = _nLocationID;
                    if (_bReadDB) _oJobLocation.Refresh();
                }

                return _oJobLocation;
            }
        }

        public Shift Shift
        {
            get
            {
                if (_oShift == null)
                {
                    _oShift = new Shift();
                    _oShift.ShiftID = _nShiftID;
                    if (_bReadDB) _oShift.Refresh();
                }

                return _oShift;
            }
        }

        /// <summary>
        /// Get set property for ?
        /// </summary>
        public bool ReadDB
        {
            get { return _bReadDB; }
            set { _bReadDB = value; }
        }
        private int _nOutletEmployeeType;
        public int OutletEmployeeType
        {
            get { return _nOutletEmployeeType; }
            set { _nOutletEmployeeType = value; }
        }
        private int _nProductCategoryID;
        public int ProductCategoryID
        {
            get { return _nProductCategoryID; }
            set { _nProductCategoryID = value; }
        }
        private int _nIsActive;
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }

        public int IsWFH
        {
            get { return _nIsWFH; }
            set { _nIsWFH = value; }
        }

        private int _nIsEligibleForLateSMS;
        public int IsEligibleForLateSMS
        {
            get { return _nIsEligibleForLateSMS; }
            set { _nIsEligibleForLateSMS = value; }
        }

        public void AddSection()
        {
            int nSectionID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([SectionID]) FROM t_HRSection";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nSectionID = 1;
                }
                else
                {
                    nSectionID = Convert.ToInt32(maxID) + 1;
                }
                _nSectionID = nSectionID;
                sSql = "INSERT INTO t_HRSection (SectionID, SectionName, CreateDate, CreateUserID, DepartmentID, IsActive) VALUES(?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SectionID", _nSectionID);
                cmd.Parameters.AddWithValue("SectionName", _sSectionName);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("DepartmentID", _nDepartmentID);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void EditSection()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "UPDATE t_HRSection SET SectionName=?,UpdateDate = ?,UpdateUserID= ?,DepartmentID=? , IsActive = ? WHERE SectionID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                
                cmd.Parameters.AddWithValue("SectionName", _sSectionName);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("DepartmentID", _nDepartmentID);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("SectionID", _nSectionID);
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
            int nMaxEmployeeID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([EmployeeID]) FROM t_Employee";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxEmployeeID = 1;
                }
                else
                {
                    nMaxEmployeeID = Convert.ToInt32(maxID) + 1;
                }
                _nEmployeeID = nMaxEmployeeID;



                sSql = "INSERT INTO t_Employee"
                    + "(EmployeeID,EmployeeCode,EmployeeName,CardNo,DateOfBirth,JoiningDate,EmpStatus,"
                    + "DepartmentID,DesignationID,GradeID,PaymentMode,ShiftID,CompanyID,EmployeeType,"
                    + "EmployeeCategory,BasicSalary,LocationID,Floor,Room,ShowAttendanceRpt,MobileNo,"
                    + " BankID,BankAccountNo,ConfirmDate,SeparationDate, IsPayrollEmployee,Gender, " 
                    + " IsFactoryEmployee, EquivalentGradeID,SectionID,EmergencyContact,EmergencyContactRelationship,SBUID,PermanantAddress,PresentAddress,NationalID,TINNo,BloodGroup,IsWFH, IsEligibleForLateSMS)"
                    + " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("EmployeeCode", _sEmployeeCode);
                cmd.Parameters.AddWithValue("EmployeeName", _sEmployeeName);
                cmd.Parameters.AddWithValue("CardNo", _sCardNo);
                cmd.Parameters.AddWithValue("DateOfBirth", _dDateOfBirth);
                cmd.Parameters.AddWithValue("JoiningDate", _dJoiningDate);
                cmd.Parameters.AddWithValue("EmpStatus", _nEmpStatus);
                cmd.Parameters.AddWithValue("DepartmentID", _nDepartmentID);
                cmd.Parameters.AddWithValue("DesignationID", _nDesignationID);
                cmd.Parameters.AddWithValue("GradeID", _nGradeID);
                cmd.Parameters.AddWithValue("PaymentMode", _nPaymentMode);
                cmd.Parameters.AddWithValue("ShiftID", _nShiftID);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("EmployeeType", 0);
                cmd.Parameters.AddWithValue("EmployeeCategory", "A");
                cmd.Parameters.AddWithValue("BasicSalary", _nBasicSalary);
                cmd.Parameters.AddWithValue("LocationID", _nLocationID);
                cmd.Parameters.AddWithValue("Floor", _nFloor);
                cmd.Parameters.AddWithValue("Room", _sRoom);
                cmd.Parameters.AddWithValue("ShowAttendanceRpt", _nShowAttendanceRpt);
                if (_sMobile != null)
                {
                    cmd.Parameters.AddWithValue("MobileNo", _sMobile);
                }
                else
                {
                    cmd.Parameters.AddWithValue("MobileNo", "");
                }

                
                if (_nEBankID != null)
                {
                    cmd.Parameters.AddWithValue("BankID", _nEBankID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("BankID", 0);
                }
                if (_sBankAccountNo != null)
                {
                    cmd.Parameters.AddWithValue("BankAccountNo", _sBankAccountNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("BankAccountNo", "");
                }


                if (_nEmpStatus == (int)Dictionary.HREmployeeStatus.Confirmed)
                {
                    cmd.Parameters.AddWithValue("ConfirmDate", _dConfirmDate);
                    cmd.Parameters.AddWithValue("SeparationDate", null);

                }
                else if (_nEmpStatus == (int)Dictionary.HREmployeeStatus.Contractual || _nEmpStatus == (int)Dictionary.HREmployeeStatus.NotEmployed)
                {
                    cmd.Parameters.AddWithValue("ConfirmDate", null);
                    cmd.Parameters.AddWithValue("SeparationDate", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ConfirmDate", null);
                    cmd.Parameters.AddWithValue("SeparationDate", _dSeparationDate);
                }
                cmd.Parameters.AddWithValue("IsPayrollEmployee", _nIsPayrollEmployee);
                cmd.Parameters.AddWithValue("Gender", _sGender);
                cmd.Parameters.AddWithValue("IsFactoryEmployee", _nIsFactory);
                cmd.Parameters.AddWithValue("EquivalentGradeID", _nEquivalentGradeID);
                cmd.Parameters.AddWithValue("SectionID", _nSectionID);
                cmd.Parameters.AddWithValue("EmergencyContact", _sEmergencyContact);
                cmd.Parameters.AddWithValue("EmergencyContactRelationship", _sEmergencyContactRelationship);
                cmd.Parameters.AddWithValue("SBUID", _nSBUID);

                cmd.Parameters.AddWithValue("PermanantAddress", _sPermanantAddress);
                cmd.Parameters.AddWithValue("PresentAddress", _sPresentAddress);
                cmd.Parameters.AddWithValue("NationalID", _sNationalID);
                cmd.Parameters.AddWithValue("TINNo", _sTINNo);
                cmd.Parameters.AddWithValue("BloodGroup", _sBloodGroup);
                cmd.Parameters.AddWithValue("IsWFH", _nIsWFH);
                cmd.Parameters.AddWithValue("IsEligibleForLateSMS", _nIsEligibleForLateSMS);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddOutletEmployee()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "INSERT INTO t_OutletEmployee (OutletEmployeeID, OutletEmployeeType, ProductCategoryID, IsActive, CreateDate, CreateUserID) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OutletEmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("OutletEmployeeType", _nOutletEmployeeType);
                cmd.Parameters.AddWithValue("ProductCategoryID", _nProductCategoryID);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CreateDate", _dEffectiveDate);//DateTime.Now.Date);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);

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

                sSql = "UPDATE t_Employee SET EmployeeCode=?,EmployeeName=?,CardNo=?,DateOfBirth=?,JoiningDate=?,EmpStatus=?,"
                    + "DepartmentID=?,DesignationID=?,GradeID=?,PaymentMode=?,ShiftID=?,CompanyID=?,"
                    + "EmployeeType=?,EmployeeCategory=?,BasicSalary=?,LocationID=?,Floor=?,Room=?,ShowAttendanceRpt=?, MobileNo = ?, BankID = ?, BankAccountNo = ?, "
                    + "ConfirmDate = ?, SeparationDate = ?, IsPayrollEmployee = ?, Gender = ?, IsFactoryEmployee = ?, EquivalentGradeID = ?, SectionID = ?,EmergencyContact = ?,EmergencyContactRelationship = ?,SBUID = ?,PermanantAddress = ?,PresentAddress = ?,NationalID = ?,TINNo = ?,BloodGroup = ?,IsWFH=?, IsEligibleForLateSMS=? WHERE EmployeeID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("EmployeeCode", _sEmployeeCode);
                cmd.Parameters.AddWithValue("EmployeeName", _sEmployeeName);
                cmd.Parameters.AddWithValue("CardNo", _sCardNo);
                cmd.Parameters.AddWithValue("DateOfBirth", _dDateOfBirth);
                cmd.Parameters.AddWithValue("JoiningDate", _dJoiningDate);
                cmd.Parameters.AddWithValue("EmpStatus", _nEmpStatus);
                cmd.Parameters.AddWithValue("DepartmentID", _nDepartmentID);
                cmd.Parameters.AddWithValue("DesignationID", _nDesignationID);
                cmd.Parameters.AddWithValue("GradeID", _nGradeID);
                cmd.Parameters.AddWithValue("PaymentMode", _nPaymentMode);
                cmd.Parameters.AddWithValue("ShiftID", _nShiftID);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("EmployeeType", 0);
                cmd.Parameters.AddWithValue("EmployeeCategory", "A");
                cmd.Parameters.AddWithValue("BasicSalary", _nBasicSalary);
                cmd.Parameters.AddWithValue("LocationID", _nLocationID);
                cmd.Parameters.AddWithValue("Floor", _nFloor);
                cmd.Parameters.AddWithValue("Room", _sRoom);
                cmd.Parameters.AddWithValue("ShowAttendanceRpt", _nShowAttendanceRpt);
                if (_sMobile != null)
                {
                    cmd.Parameters.AddWithValue("MobileNo", _sMobile);
                }
                else
                {
                    cmd.Parameters.AddWithValue("MobileNo", "");
                }
                if (_nEBankID != null)
                {
                    cmd.Parameters.AddWithValue("BankID", _nEBankID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("BankID", 0);
                }
                if (_sBankAccountNo != null)
                {
                    cmd.Parameters.AddWithValue("BankAccountNo", _sBankAccountNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("BankAccountNo", "");
                }

                if (_nEmpStatus == (int)Dictionary.HREmployeeStatus.Confirmed)
                {
                    cmd.Parameters.AddWithValue("ConfirmDate", _dConfirmDate);
                    cmd.Parameters.AddWithValue("SeparationDate", null);

                }
                else if (_nEmpStatus == (int)Dictionary.HREmployeeStatus.Contractual || _nEmpStatus == (int)Dictionary.HREmployeeStatus.NotEmployed)
                {
                    cmd.Parameters.AddWithValue("ConfirmDate", null);
                    cmd.Parameters.AddWithValue("SeparationDate", null);
                }
                else
                {
                    if (_dConfirmDate != null)
                    {
                        cmd.Parameters.AddWithValue("ConfirmDate", _dConfirmDate);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("ConfirmDate", null);
                    }
                    if (_dSeparationDate != null)
                    {
                        cmd.Parameters.AddWithValue("SeparationDate", _dSeparationDate);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("SeparationDate", null);
                    }
                    
                }
                cmd.Parameters.AddWithValue("IsPayrollEmployee", _nIsPayrollEmployee);
                cmd.Parameters.AddWithValue("Gender", _sGender);
                cmd.Parameters.AddWithValue("IsFactoryEmployee", _nIsFactory);
                cmd.Parameters.AddWithValue("EquivalentGradeID", _nEquivalentGradeID);
                cmd.Parameters.AddWithValue("SectionID", _nSectionID);
                cmd.Parameters.AddWithValue("EmergencyContact", _sEmergencyContact);
                cmd.Parameters.AddWithValue("EmergencyContactRelationship", _sEmergencyContactRelationship);
                cmd.Parameters.AddWithValue("SBUID", _nSBUID);

                cmd.Parameters.AddWithValue("PermanantAddress", _sPermanantAddress);
                cmd.Parameters.AddWithValue("PresentAddress", _sPresentAddress);
                cmd.Parameters.AddWithValue("NationalID", _sNationalID);
                cmd.Parameters.AddWithValue("TINNo", _sTINNo);
                cmd.Parameters.AddWithValue("BloodGroup", _sBloodGroup);
                cmd.Parameters.AddWithValue("IsWFH", _nIsWFH);
                cmd.Parameters.AddWithValue("IsEligibleForLateSMS", _nIsEligibleForLateSMS);

                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateImage(Image pictureBox,int nEmployeeID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                if (pictureBox != null)
                {
                    MemoryStream ms = new MemoryStream();
                    pictureBox.Save(ms, ImageFormat.Jpeg);
                    byte[] photo_aray = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(photo_aray, 0, photo_aray.Length);


                    sSql = "update t_Employee set EmployeePhoto=? where EmployeeID=" + nEmployeeID + "";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("EmployeePhoto", photo_aray);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
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
                sSql = "DELETE FROM t_Employee WHERE [EmployeeID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public void AddEmployeeHistory()
        {
            int nMaxHistoryID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([HistoryID]) FROM t_EmployeeHistory";
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



                sSql = "INSERT INTO t_EmployeeHistory (EmployeeID, Type, FromSide, ToSide, EffectiveDate, Remarks) VALUES(?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("FromSide", _nFrom);
                cmd.Parameters.AddWithValue("ToSide", _nTo);
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DeleteOutletEmployee(int nEmployeeID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_OutletEmployee WHERE [OutletEmployeeID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OutletEmployeeID", nEmployeeID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }



        public int GetOutletEmployee(int nEmployeeID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_OutletEmployee where OutletEmployeeID =?";

                cmd.Parameters.AddWithValue("OutletEmployeeID", nEmployeeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nEmployeeID = (int)reader["OutletEmployeeID"];
                    _nOutletEmployeeType = (int)reader["OutletEmployeeType"];
                    _nProductCategoryID = (int)reader["ProductCategoryID"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nCount;
        }

        public int GetEmployeebyID(int nEmployeeID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_Employee where GradeID in(83082,83083,83084,83085,83086,83087,83088,83090,83091,83092,83102) and EmployeeID =?";

                cmd.Parameters.AddWithValue("EmployeeID", nEmployeeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nGradeID = (int)reader["GradeID"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nCount;
        }

        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_Employee where EmployeeID =?";

                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {                    
                    _sEmployeeCode = (string)reader["EmployeeCode"];
                    _sEmployeeName = (string)reader["EmployeeName"];
                    _nDepartmentID = (int)reader["DepartmentID"];
                    _nDesignationID = (int)reader["DesignationID"];
                    _nCompanyID = (int)reader["CompanyID"];
                    _nGradeID = (int)reader["GradeID"];
                    _nLocationID = (int)reader["LocationID"];
                    _nEmpStatus = (int)reader["EMPStatus"];
                    if (reader["JoiningDate"] != DBNull.Value)
                        _dJoiningDate = (DateTime)reader["JoiningDate"];
                   // _dJoiningDate = (DateTime)reader["JoiningDate"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void EmployeeStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT isnull(ConfirmDate,getdate()) ConfirmDate,isnull(SeparationDate,Getdate()) SeparationDate FROM t_Employee where EmployeeID =?";

                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _dConfirmDate = (DateTime)reader["ConfirmDate"];
                    _dSeparationDate = (DateTime)reader["SeparationDate"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshDetail()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT EmployeeID, EmployeeCode, EmployeeName, DepartmentName, DesignationName,CompanyName FROM v_EmployeeDetails where EmployeeID =?";

                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _sEmployeeCode = (string)reader["EmployeeCode"];
                    _sEmployeeName = (string)reader["EmployeeName"];
                    _sDepartmentName = (string)reader["DepartmentName"];
                    _sDesignationName = (string)reader["DesignationName"];
                    _sComapanyName = (string)reader["CompanyName"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public void RefreshJoblocation()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select JoblocationID From t_Joblocation where JoblocationID in (Select LocationID From t_Showroom)";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nLocationID = (int)reader["JoblocationID"];
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshForPOS()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_Employee where EmployeeID =?";
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _sEmployeeCode = (string)reader["EmployeeCode"];
                    _sEmployeeName = (string)reader["EmployeeName"];                               
                    _nLocationID = (int)reader["LocationID"];
                  

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public void RefreshByCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_Employee where EmployeeCode =?";
                cmd.Parameters.AddWithValue("EmployeeCode", _sEmployeeCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nEmployeeID  = (int)reader["EmployeeID"];
                    _sEmployeeCode = (string)reader["EmployeeCode"];
                    _sEmployeeName = (string)reader["EmployeeName"];
                    _sCardNo = (string)reader["CardNo"];
                    //_nPhotograph = (int)reader["Photograph"];
                    //_nGender = (int)reader["Gender"];
                    if (reader["DateOfBirth"] != DBNull.Value)
                        _dDateOfBirth = (DateTime)reader["DateOfBirth"];
                    //else _dDateOfBirth = "";
                    //_dDateOfBirth = (DateTime)reader["DateOfBirth"];
                    if (reader["JoiningDate"] != DBNull.Value)
                        _dJoiningDate = (DateTime)reader["JoiningDate"];

                    //_dJoiningDate = (DateTime)reader["JoiningDate"];
                    //_nPresentAddress = (int)reader["PresentAddress"];
                    //_nPermanantAddress = (int)reader["PermanantAddress"];
                    //_nTelephone = (int)reader["Telephone"];
                    //_nMobile = (int)reader["Mobile"];
                    //_nFax = (int)reader["Fax"];
                    //_nNationality = (int)reader["Nationality"];
                    //_nPlaceofBirth = (int)reader["PlaceofBirth"];
                    //_nReligion = (int)reader["Religion"];
                    //_nMaritialStatus = (int)reader["MaritialStatus"];
                    //_nBloodGroup = (int)reader["BloodGroup"];
                    //_nPassportNo = (int)reader["PassportNo"];
                    //_nTINNO = (int)reader["TINNO"];
                    //_nFatherName = (int)reader["FatherName"];
                    //_nFatherOccupation = (int)reader["FatherOccupation"];
                    //_nMotherName = (int)reader["MotherName"];
                    //_nMotherOccupation = (int)reader["MotherOccupation"];
                    //_nMarriageDate = (int)reader["MarriageDate"];
                    //_nSpouseName = (int)reader["SpouseName"];
                    //_nSpouseOccupation = (int)reader["SpouseOccupation"];
                    _nEmpStatus = (int)reader["EmpStatus"];
                    //_nConfirmDate = (int)reader["ConfirmDate"];
                    //_nBranchID = (int)reader["BranchID"];
                    //_nBankAccountNo = (int)reader["BankAccountNo"];
                    _nDepartmentID = (int)reader["DepartmentID"];
                    _nDesignationID = (int)reader["DesignationID"];
                    _nGradeID = (int)reader["GradeID"];
                    _nPaymentMode = (int)reader["PaymentMode"];
                    //_nShiftID = (int)reader["ShiftID"];
                    //_nNationalID = (int)reader["NationalID"];
                    _nCompanyID = (int)reader["CompanyID"];
                    _nEmployeeType = (int)reader["EmployeeType"];
                    _sEmployeeCategory = (string)reader["EmployeeCategory"];
                    _nBasicSalary = Convert.ToDouble(reader["BasicSalary"]);
                    //_nPFMEMBDATE = (int)reader["PFMEMBDATE"];
                    //_nNOTIONALBASIC = (int)reader["NOTIONALBASIC"];
                    _nLocationID = (int)reader["LocationID"];
                    //_nEmail = (int)reader["Email"];
                    //_nMobileID = (int)reader["MobileID"];
                    if (reader["IsFactoryEmployee"] != DBNull.Value)
                    {
                        _nIsFactory = (int)reader["IsFactoryEmployee"];
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




        public void GetPicture()
        {

            //OleDbCommand cmds = DBController.Instance.GetCommand();
            //{
            //    //conn.Open();
            //    cmds.CommandText = "SELECT * FROM t_Employee where EmployeeID =?";
            //    cmds.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
            //    cmds.CommandType = CommandType.Text;
            //    IDataReader reader = cmds.ExecuteReader();
            //    if (reader.Read())

            //    {
            //        SqlDataAdapter adpt = new SqlDataAdapter(cmds);
            //        DataSet dataSet = new DataSet();
            //        adpt.Fill(dataSet, "Image");
                    
            //        DataRow Row;
            //        Row = dataSet.Tables["Image"].Rows[0];
            //        byte[] MyImg = (byte[])Row[0];
            //        MemoryStream ms = new MemoryStream(MyImg);
            //        ms.Position = 0;

            //        Image img = Image.FromStream(ms); //error 

            //        //pictureBox1.Image = img;

            //    }
            //    conn.Close();
            //}
            /////////////////

            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_Employee where EmployeeID =?";
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["EmployeePhoto"] != DBNull.Value)
                    {
                        _EmployeePhoto = (byte)reader["EmployeePhoto"];
                    }


                    // SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    // DataSet dataSet = new DataSet();
                    // adpt.Fill(dataSet, "Image");
                    // DataRow Row;
                    // Row = dataSet.Tables["Image"].Rows[0];
                    // byte[] MyImg = (byte[])Row[0];
                    // MemoryStream ms = new MemoryStream(MyImg);
                    // ms.Position = 0;

                    // Image img = Image.FromStream(ms); //error 

                    //// pictureBox1.Image = img;

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetPermission(int nUserID,int nCompanyID, int nDepartmentID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select a.UserID,UserName,isnull(CompanyID,0) CompanyID, "+
                                " isnull(DepartmentID,0) DepartmentID From  "+
                                " (Select UserID,UserName from t_User where UserID=" + nUserID + ") a " +
                                " Left Outer Join  "+
                                " (Select UserID,CompanyID from t_Company a,t_UserPermissionData b  "+
                                " where b.DataID=a.CompanyID and b.UserID= " + nUserID + " and DataType='Company' " +
                                " and CompanyID=" + nCompanyID + ") b " +
                                " on a.UserID=b.UserID "+
                                " Left Outer Join  "+
                                " (Select UserID,DepartmentID from t_Department a,t_UserPermissionData b  "+
                                " where b.DataID=a.DepartmentID and b.UserID= " + nUserID + " and DataType='Department' " +
                                " and DepartmentID=" + nDepartmentID + ") c " +
                                " on a.UserID=c.UserID";


                
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nUserID = (int)reader["UserID"];
                    _sUserName = (string)reader["UserName"];
                    _nCompanyID = (int)reader["CompanyID"];
                    _nDepartmentID = (int)reader["DepartmentID"];                    

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetBasicSalary()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT isnull(BasicSalary,0) BasicSalary,isnull(IsPayrollEmployee,0) IsPayrollEmployee,isnull(EmergencyContact,'') EmergencyContact,isnull(EmergencyContactRelationship,'') EmergencyContactRelationship,isnull(ConfirmDate,getdate()) ConfirmDate,isnull(SeparationDate,Getdate()) SeparationDate FROM t_Employee where EmployeeID =?";
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nBasicSalary = (double)reader["BasicSalary"];
                    _nIsPayrollEmployee = (int)reader["IsPayrollEmployee"];
                    _sEmergencyContact = (string)reader["EmergencyContact"];
                    _sEmergencyContactRelationship = (string)reader["EmergencyContactRelationship"];
                    _dConfirmDate = (DateTime)reader["ConfirmDate"];
                    _dSeparationDate = (DateTime)reader["SeparationDate"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetEmpJoblocation(int nEmployeeID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select JobLocation From  " +
                                "(  " +
                                "Select EmployeeID,  " +
                                "JobLocation=Case when b.LocationID is null then JobLocationName else ShowroomCode end From   " +
                                "(Select EmployeeID,LocationID,JobLocationName From v_EmployeeDetails) a  " +
                                "Left Outer Join   " +
                                "(Select LocationID,ShowroomCode From t_Showroom) b  " +
                                "on a.LocationID=b.LocationID  " +
                                ") Main where EmployeeID=" + nEmployeeID + "";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _sJoblocationName = (string)reader["JobLocation"];

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
    public class Employees : CollectionBase
    {

        public Employee this[int i]
        {
            get { return (Employee)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Employee oEmployee)
        {
            InnerList.Add(oEmployee);
        }

        public int GetIndex(int nEmployeeID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].EmployeeID == nEmployeeID)
                {
                    return i;
                }
            }
            return -1;
        }


        public int GetSectionIndex(int nSectionID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].SectionID == nSectionID)
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

            string sSql = "SELECT * FROM t_Employee ";
            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            GetData(cmd);

        }

        public int GetOutletEmployeeNew(int nEmployeeID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_OutletEmployee where OutletEmployeeID =? order by ProductCategoryID";

                cmd.Parameters.AddWithValue("OutletEmployeeID", nEmployeeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee oEmployee = new Employee();
                    oEmployee.EmployeeID = (int)reader["OutletEmployeeID"];
                    oEmployee.OutletEmployeeType = (int)reader["OutletEmployeeType"];
                    oEmployee.ProductCategoryID = (int)reader["ProductCategoryID"];
                    oEmployee.EffectiveDate = (DateTime)reader["CreateDate"];

                    nCount++;
                    InnerList.Add(oEmployee);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nCount;
        }


        public void RefreshRoom()
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT Room FROM t_Employee Where Room Is Not Null Group By Room";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee oEmployee = new Employee();

                    oEmployee.Room = (string)reader["Room"];

                    InnerList.Add(oEmployee);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetPOSSalesPerson()
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select EmployeeID, EmployeeCode, EmployeeName, DesignationName from [dbo].[t_Employee] a, "+
                         " (Select distinct SalesPersonID from t_SalesInvoice Where SalesPersonID IN(Select EmployeeID from[dbo].[t_Employee]))b "+
                         " Where a.EmployeeID = b.SalesPersonID Order by Status, EmployeeName";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee oEmployee = new Employee();

                    oEmployee.EmployeeID = (int)reader["EmployeeID"];
                    oEmployee.EmployeeCode = (string)reader["EmployeeCode"];
                    oEmployee.EmployeeName = (string)reader["EmployeeName"];
                    oEmployee.DesignationName = (string)reader["DesignationName"];

                    InnerList.Add(oEmployee);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void Refresh(int nCompanyID, int nDepartmentID, int nJobGradeID, string sCode,string sName, int nLocationId)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_Employee";
            string sClause = "";

            if (nCompanyID != 0)
            {
                sClause= " WHERE CompanyID=?";
                cmd.Parameters.AddWithValue("CompanyID", nCompanyID);
            }

            if (nDepartmentID != 0)
            {
                if (sClause=="") sClause = " WHERE DepartmentID=?";
                else sClause = sClause + " AND DepartmentID=?";
                cmd.Parameters.AddWithValue("DepartmentID", nDepartmentID);
            }

            if (nJobGradeID != 0)
            {
                if (sClause == "") sClause = " WHERE GradeID=?";
                else sClause = sClause + " AND GradeID=?";
                cmd.Parameters.AddWithValue("JobGradeID", nJobGradeID);
            }

            if (sCode != "")
            {
                if (sClause == "") sClause = " WHERE EmployeeCode LIKE ?";
                else sClause = sClause + " AND EmployeeCode LIKE ?";
                cmd.Parameters.AddWithValue("EmployeeCode", "%" + sCode + "%");
            }

            if (sName != "")
            {
                if (sClause == "") sClause = " WHERE EmployeeName LIKE ?";
                else sClause = sClause + " AND EmployeeName LIKE ?";
                cmd.Parameters.AddWithValue("EmployeeName", "%" + sName + "%");
            }
            if (nLocationId != 0)
            {
                if (sClause == "") sClause = " WHERE LocationId=?";
                else sClause = sClause + " AND LocationId=?";
                cmd.Parameters.AddWithValue("LocationId", nLocationId);
            }
            

            cmd.CommandText = sSql + sClause;
            cmd.CommandType = CommandType.Text;
            GetData(cmd);

        }

        private void GetData(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee oEmployee = new Employee();

                    oEmployee.EmployeeID = (int)reader["EmployeeID"];
                    oEmployee.EmployeeCode = (string)reader["EmployeeCode"];
                    oEmployee.EmployeeName = (string)reader["EmployeeName"];
                    oEmployee.CardNo = (string)reader["CardNo"];
                    //oEmployee.Photograph = (int)reader["Photograph"];
                    //oEmployee.Gender = (int)reader["Gender"];
                    oEmployee.DateOfBirth = (DateTime)reader["DateOfBirth"];
                    oEmployee.JoiningDate = (DateTime)reader["JoiningDate"];
                    //oEmployee.PresentAddress = (int)reader["PresentAddress"];
                    //oEmployee.PermanantAddress = (int)reader["PermanantAddress"];
                    //oEmployee.Telephone = (int)reader["Telephone"];
                    //oEmployee.Mobile = (int)reader["Mobile"];
                    //oEmployee.Fax = (int)reader["Fax"];
                    //oEmployee.Nationality = (int)reader["Nationality"];
                    //oEmployee.PlaceofBirth = (int)reader["PlaceofBirth"];
                    //oEmployee.Religion = (int)reader["Religion"];
                    //oEmployee.MaritialStatus = (int)reader["MaritialStatus"];
                    //oEmployee.BloodGroup = (int)reader["BloodGroup"];
                    //oEmployee.PassportNo = (int)reader["PassportNo"];
                    //oEmployee.TINNO = (int)reader["TINNO"];
                    //oEmployee.FatherName = (int)reader["FatherName"];
                    //oEmployee.FatherOccupation = (int)reader["FatherOccupation"];
                    //oEmployee.MotherName = (int)reader["MotherName"];
                    //oEmployee.MotherOccupation = (int)reader["MotherOccupation"];
                    //oEmployee.MarriageDate = (int)reader["MarriageDate"];
                    //oEmployee.SpouseName = (int)reader["SpouseName"];
                    //oEmployee.SpouseOccupation = (int)reader["SpouseOccupation"];
                    oEmployee.EmpStatus = (int)reader["EmpStatus"];
                    //oEmployee.ConfirmDate = (int)reader["ConfirmDate"];
                    //oEmployee.BranchID = (int)reader["BranchID"];
                    //oEmployee.BankAccountNo = (int)reader["BankAccountNo"];
                    oEmployee.DepartmentID = (int)reader["DepartmentID"];
                    oEmployee.DesignationID = (int)reader["DesignationID"];
                    oEmployee.GradeID = (int)reader["GradeID"];
                    oEmployee.PaymentMode = (int)reader["PaymentMode"];
                    //oEmployee.ShiftID = (int)reader["ShiftID"];
                    //oEmployee.NationalID = (int)reader["NationalID"];
                    oEmployee.CompanyID = (int)reader["CompanyID"];
                    oEmployee.EmployeeType = (int)reader["EmployeeType"];
                    oEmployee.EmployeeCategory = (string)reader["EmployeeCategory"];
                    oEmployee.BasicSalary = Convert.ToDouble( reader["BasicSalary"]);
                    oEmployee.LocationID = (int)reader["LocationID"];
                    //oEmployee.Email = (int)reader["Email"];
                    //oEmployee.MobileID = (int)reader["MobileID"];
                    oEmployee.Mobile = (string)reader["MobileNo"];
                    oEmployee.Floor = (int)reader["Floor"];
                    oEmployee.Room = (string)reader["Room"];
                    oEmployee.ShowAttendanceRpt = (int)reader["ShowAttendanceRpt"];


                    InnerList.Add(oEmployee);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshDetail(int nCompanyID, int nDepartmentID, int nJobGradeID, string sCode, string sName,Dictionary.GeneralStatus nGStatus,bool isFactoryEmployee)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM v_EmployeeDetails Where 1=1 ";
            if (nCompanyID == 0)
            {
                sSql = sSql + " and CompanyID IN (Select DataID from dbo.t_UserPermissionData Where DataType='Company' and UserID=" + Utility.UserId + ") ";
            }
            else
            {
                sSql = sSql + " and CompanyID = " + nCompanyID + " ";
            }
            if (nDepartmentID != 0)
            {
                sSql = sSql + " AND DepartmentID=" + nDepartmentID + " ";
            }

            if (nJobGradeID != 0)
            {
                sSql = sSql + " AND GradeID=" + nJobGradeID + " ";
            }

            //if (nDivisionID != 0)
            //{
            //    sSql = sSql + " AND DivisionID=" + nDivisionID + " ";
            //}

            //if (nSBUID != 0)
            //{
            //    sSql = sSql + " AND SBUID=" + nSBUID + " ";
            //}

            if (sCode != "")
            {
                sSql = sSql + " AND EmployeeCode LIKE '%" + sCode + "%' ";
            }

            if (sName != "")
            {
                sSql = sSql + " AND EmployeeName LIKE '%" + sName + "%' ";
            }

            if (nGStatus==Dictionary.GeneralStatus.Active)
            {
                sSql = sSql + " AND EmpStatus in (" + (int)Dictionary.HREmployeeStatus.Contractual + "," + (int)Dictionary.HREmployeeStatus.Confirmed + ") ";
            }
            else if (nGStatus == Dictionary.GeneralStatus.Inactive)
            {
                sSql = sSql + " AND EmpStatus not in (" + (int)Dictionary.HREmployeeStatus.Contractual + "," + (int)Dictionary.HREmployeeStatus.Confirmed + ")";
            }
            if (isFactoryEmployee)
            {
                sSql += " AND IsFactoryEmployee ="+(int) Dictionary.YesNAStatus.Yes;
            }

            sSql = sSql + " ORDER BY GradeID";
            cmd.CommandText = sSql ;
            cmd.CommandType = CommandType.Text;
            GetDataDetail(cmd);

        }

        public void RefreshDetails(int nCompanyID, int nDepartmentID, int nJobGradeID, string sCode, string sName, Dictionary.GeneralStatus nGStatus, bool isFactoryEmployee, int nDivisionID, int nSBUID,int nSectionID,int nLocationID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM v_EmployeeDetails Where 1=1 ";
            if (nCompanyID == 0)
            {
                sSql = sSql + " and CompanyID IN (Select DataID from dbo.t_UserPermissionData Where DataType='Company' and UserID=" + Utility.UserId + ") ";
            }
            else
            {
                sSql = sSql + " and CompanyID = " + nCompanyID + " ";
            }
            if (nDepartmentID != 0)
            {
                sSql = sSql + " AND DepartmentID=" + nDepartmentID + " ";
            }

            if (nJobGradeID != 0)
            {
                sSql = sSql + " AND GradeID=" + nJobGradeID + " ";
            }

            if (nDivisionID != 0)
            {
                sSql = sSql + " AND DivisionID=" + nDivisionID + " ";
            }

            if (nSBUID != 0)
            {
                sSql = sSql + " AND SBUID=" + nSBUID + " ";
            }

            if (nSectionID != 0)
            {
                sSql = sSql + " AND SectionID=" + nSectionID + " ";
            }
            if (nLocationID != 0)
            {
                sSql = sSql + " AND LocationID=" + nLocationID + " ";
            }

            if (sCode != "")
            {
                sSql = sSql + " AND EmployeeCode LIKE '%" + sCode + "%' ";
            }

            if (sName != "")
            {
                sSql = sSql + " AND EmployeeName LIKE '%" + sName + "%' ";
            }

            if (nGStatus == Dictionary.GeneralStatus.Active)
            {
                sSql = sSql + " AND EmpStatus in (" + (int)Dictionary.HREmployeeStatus.Contractual + "," + (int)Dictionary.HREmployeeStatus.Confirmed + ") ";
            }
            else if (nGStatus == Dictionary.GeneralStatus.Inactive)
            {
                sSql = sSql + " AND EmpStatus not in (" + (int)Dictionary.HREmployeeStatus.Contractual + "," + (int)Dictionary.HREmployeeStatus.Confirmed + ")";
            }
            if (isFactoryEmployee)
            {
                sSql += " AND IsFactoryEmployee =" + (int)Dictionary.YesNAStatus.Yes;
            }

            sSql = sSql + " ORDER BY GradeID";
            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            GetDataDetail(cmd);

        }

        public void GetEmployeeAttendanceProcess(int nCompanyID, int nDepartmentID, int nEmployeeID, DateTime dFromDate, DateTime dToDate, bool _IsOnlyFactory)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);
            //string sSql = " SELECT EmployeeID, EmployeeCode, a.CardNo, CompanyID, ShiftID FROM t_HRAttendData a, t_Employee b " +
            //              " WHERE a.CardNo = b.CardNo AND PunchDate between '" + dFromDate + "' and '" + dToDate + "' and PunchDate < '" + dToDate + "' ";
            string sSql = " SELECT EmployeeID, EmployeeCode, CardNo, CompanyID, ShiftID FROM t_Employee Where EMPStatus IN ("+(int)Dictionary.HREmployeeStatus.Contractual+ "," + (int)Dictionary.HREmployeeStatus.Confirmed + ") ";
            if (_IsOnlyFactory)
            {
                sSql = sSql + " and IsFactoryEmployee = " + (int)Dictionary.YesOrNoStatus.YES + "";
            }
            if (nCompanyID == 0)
            {
                sSql = sSql + " and CompanyID IN (Select DataID from dbo.t_UserPermissionData Where DataType='Company' and UserID=" + Utility.UserId + ") ";
            }
            else
            {
                sSql = sSql + " and CompanyID = " + nCompanyID + " ";
            }
            if (nDepartmentID != 0)
            {
                sSql = sSql + " AND DepartmentID=" + nDepartmentID + " ";
            }
            if (nEmployeeID != 0)
            {
                sSql = sSql + " AND EmployeeID=" + nEmployeeID + " ";
            }
            //sSql = sSql + " Group BY EmployeeID, EmployeeCode, a.CardNo, CompanyID, ShiftID ORDER BY CompanyID, EmployeeID, ShiftID ";
            sSql = sSql + " ORDER BY CompanyID, EmployeeID, ShiftID ";

            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            GetEmplAttendaceDataDetail(cmd);

        }

        public void GetEmployee(int nCompanyID, string sDepartmentID, int nEmployeeID, int nGradeType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM v_EmployeeDetails Where IsPayrollEmployee = " + (int)Dictionary.YesOrNoStatus.YES + " and EMPStatus IN (" + (int)Dictionary.HREmployeeStatus.Contractual + "," + (int)Dictionary.HREmployeeStatus.Confirmed + ") ";


            if (nGradeType != 0)
            {
                sSql = sSql + " AND GradeType=" + nGradeType + " ";
            }

            if (nCompanyID != 0)
            {
                sSql = sSql + " AND CompanyID=" + nCompanyID + " ";
            }

            if (sDepartmentID != "")
            {
                sSql = sSql + " AND DepartmentID IN (" + sDepartmentID + ") ";
            }

            if (nEmployeeID != 0)
            {
                sSql = sSql + " AND EmployeeID=" + nEmployeeID + " ";
            }


            sSql = sSql + " ORDER BY GradeID ";
            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            GetDataDetail(cmd);

        }

        public void GetEmployees(int nCompanyID, string sDepartmentID, string sDesignationID, int nEmployeeID, int nGradeType, int nIsFactoryEmployee)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM v_EmployeeDetails Where IsPayrollEmployee = " + (int)Dictionary.YesOrNoStatus.YES + " and EMPStatus IN (" + (int)Dictionary.HREmployeeStatus.Contractual + "," + (int)Dictionary.HREmployeeStatus.Confirmed + ") ";


            if (nGradeType != 0)
            {
                sSql = sSql + " AND GradeType=" + nGradeType + " ";
            }

            if (nCompanyID != 0)
            {
                sSql = sSql + " AND CompanyID=" + nCompanyID + " ";
            }

            if (sDepartmentID != "")
            {
                sSql = sSql + " AND DepartmentID IN (" + sDepartmentID + ") ";
            }

            if (sDesignationID != "")
            {
                sSql = sSql + " AND DesignationID IN (" + sDesignationID + ") ";
            }

            if (nEmployeeID != 0)
            {
                sSql = sSql + " AND EmployeeID=" + nEmployeeID + " ";
            }

            if (nIsFactoryEmployee != -1)
            {
                sSql = sSql + " AND IsFactoryEmployee=" + nIsFactoryEmployee + " ";
            }

            sSql = sSql + " ORDER BY GradeID ";
            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            GetDataDetail(cmd);

        }
        
        private void GetDataDetail(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee oEmployee = new Employee();
                    oEmployee.ReadDB = false;
                    oEmployee.EmployeeID = (int)reader["EmployeeID"];
                    oEmployee.EmployeeCode = (string)reader["EmployeeCode"];
                    oEmployee.EmployeeName = (string)reader["EmployeeName"];
                    oEmployee.CardNo = (string)reader["CardNo"];
                    oEmployee.DateOfBirth = (DateTime)reader["DateOfBirth"];
                    oEmployee.JoiningDate = (DateTime)reader["JoiningDate"];
                    oEmployee.EmpStatus = (int)reader["EmpStatus"];
                    oEmployee.CompanyID = (int)reader["CompanyID"];
                    oEmployee.Company.CompanyCode = (string)reader["CompanyCode"];
                    oEmployee.Company.CompanyName = (string)reader["CompanyName"];
                    oEmployee.DepartmentID = (int)reader["DepartmentID"];
                    oEmployee.Department.DepartmentCode = (string)reader["DepartmentCode"];
                    oEmployee.Department.DepartmentName = (string)reader["DepartmentName"];
                    oEmployee.DesignationID = (int)reader["DesignationID"];
                    oEmployee.Designation.DesignationCode = (string)reader["DesignationCode"];
                    oEmployee.Designation.DesignationName= (string)reader["DesignationName"];
                    oEmployee.GradeID = (int)reader["GradeID"];
                    oEmployee.JobGrade.JobGradeCode = (string)reader["JobGradeCode"];
                    oEmployee.JobGrade.JobGradeName= (string)reader["JobGradeName"];
                    oEmployee.LocationID = (int)reader["LocationID"];
                    oEmployee.JobLocation.JobLocationCode = (string)reader["JobLocationCode"];
                    oEmployee.JobLocation.JobLocationName= (string)reader["JobLocationName"];
                    oEmployee.ShiftID = (int)reader["ShiftID"];
                    oEmployee.Shift.ShiftName = (string)reader["ShiftName"];
                    oEmployee.Shift.LoginTime = (DateTime)reader["LoginTime"];
                    oEmployee.Shift.LogoutTime = (DateTime)reader["LogoutTime"];
                    oEmployee.EmpStatus = (int)reader["EmpStatus"];
                    oEmployee.Floor = (int)reader["Floor"];
                    oEmployee.Room = (string)reader["Room"];
                    oEmployee.ShowAttendanceRpt = (int)reader["ShowAttendanceRpt"];
                    if (reader["MobileNo"] != DBNull.Value)
                        oEmployee.Mobile = (string)reader["MobileNo"];
                    else oEmployee.Mobile = "";
                    //if (reader["BasicSalary"] != DBNull.Value)
                    //    oEmployee.BasicSalary = (double)reader["BasicSalary"];
                    //else oEmployee.BasicSalary = 0;

                    if (reader["BankID"] != DBNull.Value)
                        oEmployee.EBankID = (int)reader["BankID"];
                    else oEmployee.EBankID = 0;

                    if (reader["BankAccountNo"] != DBNull.Value)
                        oEmployee.BankAccountNo = (string)reader["BankAccountNo"];
                    else oEmployee.BankAccountNo = "";
                    if (reader["Gender"] != DBNull.Value)
                        oEmployee.Gender = (string)reader["Gender"];
                    else oEmployee.Gender = "";
                    if (reader["IsFactoryEmployee"] != DBNull.Value)
                        oEmployee.IsFactory = (int)reader["IsFactoryEmployee"];
                    else oEmployee.IsFactory = 0;
                    oEmployee.EquivalentGradeID = (int)reader["EquivalentGradeID"];

                    if (reader["SectionID"] != DBNull.Value)
                        oEmployee.SectionID = (int)reader["SectionID"];
                    else oEmployee.SectionID = 1;


                    if (reader["SectionName"] != DBNull.Value)
                        oEmployee.SectionName = (string)reader["SectionName"];
                    else oEmployee.SectionName = "";


                    if (reader["SBUID"] != DBNull.Value)
                        oEmployee.SBUID = (int)reader["SBUID"];
                    else oEmployee.SBUID = 4;


                    if (reader["SBUName"] != DBNull.Value)
                        oEmployee.SBUName = (string)reader["SBUName"];
                    else oEmployee.SBUName = "Common";


                    if (reader["DivisionID"] != DBNull.Value)
                        oEmployee.DivisionID = (int)reader["DivisionID"];
                    //else oEmployee.DivisionID = 4;


                    if (reader["DivisionName"] != DBNull.Value)
                        oEmployee.DivisionName = (string)reader["DivisionName"];
                    else oEmployee.DivisionName = "";


                    oEmployee.PermanantAddress = (string)reader["PermanantAddress"];
                    oEmployee.PresentAddress = (string)reader["PresentAddress"];
                    oEmployee.NationalID = (string)reader["NationalID"];
                    oEmployee.TINNo = (string)reader["TINNo"];
                    oEmployee.BloodGroup = (string)reader["BloodGroup"];
                    if (reader["WFH"].ToString() == "Yes")
                        oEmployee.IsWFH = 1;
                    else oEmployee.IsWFH = 0;

                    if (reader["IsEligibleForLateSMS"] != DBNull.Value)
                        oEmployee.IsEligibleForLateSMS = (int)reader["IsEligibleForLateSMS"];
                    else oEmployee.IsEligibleForLateSMS = 0;

                    InnerList.Add(oEmployee);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void GetEmplAttendaceDataDetail(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee oEmployee = new Employee();

                    oEmployee.EmployeeID = (int)reader["EmployeeID"];
                    oEmployee.EmployeeCode = (string)reader["EmployeeCode"];
                    oEmployee.CardNo = (string)reader["CardNo"];
                    oEmployee.CompanyID = (int)reader["CompanyID"];
                    oEmployee.ShiftID = (int)reader["ShiftID"];

                    InnerList.Add(oEmployee);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetSalesPerson()
        {
            InnerList.Clear();
            Employee _oEmployee;
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();           
            try
            {
                cmd.CommandText = " select EmployeeName as SalesPersonName, q1.EmployeeID as SalesPersonID, q2.EmployeeCode as SalesPersonCode, q1.IsActive from t_EmployeeJobType q1, t_Employee q2  " +
                             " where q1.EmployeeID = q2.EmployeeID  and JobTypeID = ? ";

                cmd.Parameters.AddWithValue("JobTypeID", Dictionary.JobType.SALES_PERSONS);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (nCount == 0)
                    {
                        _oEmployee = new Employee();
                        _oEmployee.EmployeeID = 0;
                        _oEmployee.EmployeeName = "NA";
                        InnerList.Add(_oEmployee);
                    }

                    _oEmployee = new Employee();
                    _oEmployee.EmployeeID = (int)reader["SalesPersonID"];
                    _oEmployee.EmployeeName = (string)reader["SalesPersonName"];
                    InnerList.Add(_oEmployee);
                    nCount++;
                }

                reader.Close();                
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
           
        }

        public void GetShowroomSalesPerson()
        {
            InnerList.Clear();
            Employee _oEmployee;          
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " select * from  t_Employee Where Status IN (1,2)";                          
                             
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                 
                    _oEmployee = new Employee();
                    _oEmployee.EmployeeID = (int)reader["EmployeeID"]; ;
                    _oEmployee.EmployeeName = reader["EmployeeName"].ToString();
                    _oEmployee.EmployeeCode = reader["EmployeeCode"].ToString();
                    _oEmployee.DesignationName = reader["DesignationName"].ToString();
                    _oEmployee.LocationID = (int)reader["LocationID"];

                    InnerList.Add(_oEmployee);
                   
                }

                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetShowroomSalesPersonRT()
        {
            InnerList.Clear();
            Employee _oEmployee;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " select * from  v_EmployeeDetails Where EmpStatus IN (1,2) and LocationID=" + Utility.LocationID + "";
                

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _oEmployee = new Employee();
                    _oEmployee.EmployeeID = (int)reader["EmployeeID"]; ;
                    _oEmployee.EmployeeName = reader["EmployeeName"].ToString();
                    _oEmployee.EmployeeCode = reader["EmployeeCode"].ToString();
                    _oEmployee.DesignationName = reader["DesignationName"].ToString();
                    _oEmployee.LocationID = (int)reader["LocationID"];

                    InnerList.Add(_oEmployee);

                }

                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetShowroomSalesPersonAll()
        {
            InnerList.Clear();
            Employee _oEmployee;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " select * from  t_Employee";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _oEmployee = new Employee();
                    _oEmployee.EmployeeID = (int)reader["EmployeeID"]; ;
                    _oEmployee.EmployeeName = reader["EmployeeName"].ToString();
                    _oEmployee.EmployeeCode = reader["EmployeeCode"].ToString();
                    _oEmployee.DesignationName = reader["DesignationName"].ToString();

                    InnerList.Add(_oEmployee);

                }

                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetSalesPersonJobLocationWise(string sShowroomCode)
        {
            InnerList.Clear();
            Employee _oEmployee;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select EmployeeID,EmployeeCode,EmployeeName " +
                                "From t_Joblocation a,t_Showroom b,t_Employee c   " +
                                "where a.JoblocationID=b.LocationID and a.JoblocationID=c.LocationID  " +
                                "and ShowroomCode = '" + sShowroomCode + "' and EMPStatus in (1,2)";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _oEmployee = new Employee();
                    _oEmployee.EmployeeID = (int)reader["EmployeeID"]; ;
                    _oEmployee.EmployeeName = reader["EmployeeName"].ToString();
                    _oEmployee.EmployeeCode = reader["EmployeeCode"].ToString();

                    InnerList.Add(_oEmployee);

                }

                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetSalesPersonJobLocationWiseHO(string sShowroomCode)
        {
            InnerList.Clear();
            Employee _oEmployee;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select EmployeeID,EmployeeCode,EmployeeName, " +
                                "ProductCategory= Case when ProductCategoryID=1 then 'Electronics' " +
                                "When ProductCategoryID=2 then 'Appliance' " +
                                "else 'Other' end " +
                                "From t_Joblocation a,t_Showroom b,TELSysDB.DBO.t_Employee c,t_OutletEmployee d   " +
                                "where a.JoblocationID=b.LocationID and a.JoblocationID=c.LocationID  " +
                                "and d.OutletEmployeeID=c.EmployeeID   " +
                                "and ShowroomCode = '" + sShowroomCode + "' and EMPStatus in (1,2)";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _oEmployee = new Employee();
                    _oEmployee.EmployeeID = (int)reader["EmployeeID"]; ;
                    _oEmployee.EmployeeName = reader["EmployeeName"].ToString();
                    _oEmployee.EmployeeCode = reader["EmployeeCode"].ToString();
                    _oEmployee.Category = reader["ProductCategory"].ToString();

                    InnerList.Add(_oEmployee);

                }

                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        /// <summary>
        /// Shuvo
        /// Date-22-Mar-2016
        /// </summary>
        public void GetPersonInCharge(string sEmployeeCode)
        {
            InnerList.Clear();
            Employee _oEmployee;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select EmployeeID,+'['+EmployeeCode +']'+ EmployeeName as EmployeeName From dbo.v_EmployeeDetails  "+
                                  "where DepartmentID=(Select DepartmentID From dbo.v_EmployeeDetails where EmployeeCode='" + sEmployeeCode + "')   " +
                                  "and EmpStatus in (1,2) and EmployeeCode<>'" + sEmployeeCode + "'";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _oEmployee = new Employee();
                    _oEmployee.EmployeeID = (int)reader["EmployeeID"]; ;
                    _oEmployee.EmployeeName = reader["EmployeeName"].ToString();
                    InnerList.Add(_oEmployee);

                }

                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        /// <summary>
        /// Shuvo
        /// Date-06-Jun-2016
        /// for BLL Over Time Module Purpose
        /// </summary>
        public void GetEmployeeList(int nCompanyID, int nDepartmentID, string sEmployeeName, int nSection)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";

            {
                sSql = " Select * From (Select a.EmployeeID,EmployeeCode,'['+EmployeeCode+']'+EmployeeName as EmployeeName,  " +
                       " a.SectionID,b.SectionName,a.CompanyID,CompanyName,DepartmentID,   "+
                       " DepartmentName,DesignationName From  t_HRSectionMapping a,v_EmployeeDetails b,t_HRSection c  " +
                       " where a.EmployeeID=b.EmployeeID and a.SectionID=c.SectionID) x where 1=1";
            }

            if (nCompanyID != 0)
            {
                sSql = sSql + " AND CompanyID=" + nCompanyID + "";
            }
            if (nDepartmentID != 0)
            {
                sSql = sSql + " AND DepartmentID=" + nDepartmentID + "";
            }

            if (sEmployeeName != "")
            {
                sSql = sSql + " AND EmployeeName like '%" + sEmployeeName + "%'";
            }
            if (nSection != 0)
            {
                sSql = sSql + " AND SectionID=" + nSection + "";
            }

            sSql = sSql + " Order by SectionID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee oEmployee = new Employee();

                    oEmployee.EmployeeID = (int)reader["EmployeeID"];
                    oEmployee.EmployeeCode = (string)reader["EmployeeCode"];
                    oEmployee.EmployeeName = (string)reader["EmployeeName"];
                    oEmployee.SectionID = (int)reader["SectionID"];
                    oEmployee.SectionName = (string)reader["SectionName"];
                    oEmployee.CompanyID = (int)reader["CompanyID"];
                    oEmployee.ComapanyName = (string)reader["CompanyName"];
                    oEmployee.DepartmentID = (int)reader["DepartmentID"];
                    oEmployee.DepartmentName = (string)reader["DepartmentName"];
                    oEmployee.DesignationName = (string)reader["DesignationName"];

                    InnerList.Add(oEmployee);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetHRLateAttendanceEmployeewise()
        {
            InnerList.Clear();
            string _dDate = DateTime.Now.Date.ToString("dd-MMM-yyyy");
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.EmployeeID,EmployeeCode,EmployeeName, isnull(MobileNumber,a.MobileNo)as MobileNo,PunchDate,FORMAT(TimeIn,'hh:mm')TimeIn, " +
                            "CONVERT(VARCHAR(8), Late, 108)+' Hours' as Late " +
                            "from(Select A.*, Late, PunchDate,TimeIn from t_Employee a, t_HRAttendInfo b where a.EmployeeID = b.EmployeeID and b.Status = 2)a " +
                            "left outer join " +
                            "(Select EmployeeID, MobileNumber from t_MobileNumberAssign a, t_MobileNumber b " +
                            "where a.MobileID= b.ID and AssignFor = 1) b on a.EmployeeID = b.EmployeeID " +
                            //"where PunchDate >= '"+ _dDate + "'";
                            "where PunchDate >= '16-Jun-2019' and a.EmployeeID In(85979,86107)";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee oEmployee = new Employee();

                    oEmployee.EmployeeID = (int)reader["EmployeeID"];
                    oEmployee.EmployeeCode = (string)reader["EmployeeCode"];
                    oEmployee.EmployeeName = (string)reader["EmployeeName"];
                    oEmployee.Mobile = (string)reader["MobileNo"];
                    oEmployee.Late = (string)reader["Late"];
                    oEmployee.TimeIn = (string)reader["TimeIn"];
                    oEmployee.PunchDate = (DateTime)reader["PunchDate"];

                    InnerList.Add(oEmployee);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckAttendData(int nEmployeeID,string _dDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "Select * from t_HRAttendInfo where EmployeeID=" + nEmployeeID + " and PunchDate >= '"+_dDate+"' and Flag=1 ";
            nCount = 0;
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                return true;
            else return false;
        }
        public void GetSection()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_HRSection";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee oSection = new Employee();
                    oSection.SectionID = (int)reader["SectionID"];
                    oSection.SectionName = (string)reader["SectionName"];

                    InnerList.Add(oSection);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetIncharge(int nEmployeeID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From (Select EmployeeID,  EmployeeCode, EmployeeName " +
                          " from v_EmployeeDetails Where DepartmentID in   " +
                          " ((select DepartmentID from t_Employee Where EmployeeID=" + nEmployeeID + "))  " +
                          " and EMPStatus IN (1,2) and EmployeeID not in (" + nEmployeeID + ")  " +
                          " Union All " +
                          " Select EmployeeID, EmployeeCode, EmployeeName  " +
                          " from v_EmployeeDetails Where DepartmentID in   " +
                          " (SELECT DepartmentID     " +
                          " FROM t_EmployeeLineManager a,v_EmployeeDetails b where a.EmployeeID=b.EmployeeID  " +
                          " and LineManagerID=" + nEmployeeID + " and DepartmentID not in (select DepartmentID from t_Employee Where EmployeeID=" + nEmployeeID + ")  " +
                          " group by DepartmentID)  " +
                          " and EMPStatus IN (1,2) and EmployeeID not in (" + nEmployeeID + ")) x order by EmployeeID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee oEmployee = new Employee();
                    oEmployee.EmployeeID = (int)reader["EmployeeID"];
                    oEmployee.EmployeeCode = (string)reader["EmployeeCode"];
                    oEmployee.EmployeeName = (string)reader["EmployeeName"];
                    //oEmployee.LineManagerID = (int)reader["LineManagerID"];

                    InnerList.Add(oEmployee);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetSectionData(string sName,int nIsActive,int nDepartmentID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.*,DepartmentName From t_HRSection a,t_Department b where a.DepartmentID = b.DepartmentID";

            if (nDepartmentID != -1)
            {
                sSql = sSql + " AND a.DepartmentID=" + nDepartmentID + "";
            }
            if (nIsActive != -1)
            {
                sSql = sSql + " AND a.IsActive=" + nIsActive + "";
            }

            if (sName != "")
            {
                sSql = sSql + " AND SectionName like '%" + sName + "%'";
            }
            sSql = sSql + " order By SectionName";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee oSection = new Employee();
                    oSection.SectionID = (int)reader["SectionID"];
                    oSection.SectionName = (string)reader["SectionName"];
                    oSection.DepartmentID= (int)reader["DepartmentID"];
                    oSection.DepartmentName = (string)reader["DepartmentName"];
                    oSection.IsActive = (int)reader["IsActive"];
                    InnerList.Add(oSection);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public int GetEmployee(int nEmployeeID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM v_EmployeeDetails where EmployeeID =?";

                cmd.Parameters.AddWithValue("EmployeeID", nEmployeeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee oEmployee = new Employee();
                    oEmployee.EmployeeID = (int)reader["EmployeeID"];
                    oEmployee.EmployeeCode = (string)reader["EmployeeCode"];
                    oEmployee.EmployeeName = (string)reader["EmployeeName"];
                    oEmployee.ComapanyName = (string)reader["CompanyName"];
                    try
                    {
                        oEmployee.FatherName = (string)reader["FatherName"];
                    }
                    catch
                    {
                        oEmployee.FatherName = "";
                    }
                    
                    try
                    {
                        oEmployee.MotherName = (string)reader["MotherName"];
                    }
                    catch
                    {
                        oEmployee.MotherName = "";
                    }
                    
                    try
                    {
                        oEmployee.SpouseName = (string)reader["SpouseName"];
                    }
                    catch
                    {
                        oEmployee.SpouseName = "";
                    }
                    oEmployee.PresentAddress = (string)reader["PresentAddress"];
                    oEmployee.PermanantAddress = (string)reader["PermanantAddress"];
                    oEmployee.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);

                    nCount++;
                    InnerList.Add(oEmployee);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nCount;
        }
    }

}
