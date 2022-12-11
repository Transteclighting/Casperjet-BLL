// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak Kumar Chakraborty
// Date: Nov 04, 2013
// Time  :  10:30 PM
// Description: Attendance Report for HR
// Modify Person And Date:
// </summary>


using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Report
{
    public class RptAttendanceReport
    {
        private int _nEmployeeCode;
        private string _sEmployeeName;
        private string _sDesignationName;
        private int _nDepartmentID;
        private string _nDepartmentName;
        private int _nCompanyID;
        private string _sCompanyName;
        private int _nD1;
        private int _nD2;
        private int _nD3;
        private int _nD4;
        private int _nD5;
        private int _nD6;
        private int _nD7;
        private int _nD8;
        private int _nD9;
        private int _nD10;
        private int _nD11;
        private int _nD12;
        private int _nD13;
        private int _nD14;
        private int _nD15;
        private int _nD16;
        private int _nD17;
        private int _nD18;
        private int _nD19;
        private int _nD20;
        private int _nD21;
        private int _nD22;
        private int _nD23;
        private int _nD24;
        private int _nD25;
        private int _nD26;
        private int _nD27;
        private int _nD28;
        private int _nD29;
        private int _nD30;
        private int _nD31;    
        private int _nHD;
        private int _nLA;
        private int _nPR;
        private int _nLV;
        private int _nOS;
        private int _nAB;
        private int _nTL;

        

        public int EmployeeCode
        {
            get { return _nEmployeeCode; }
            set { _nEmployeeCode = value; }
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

        public int DepartmentID
        {
            get { return _nDepartmentID; }
            set { _nDepartmentID = value; }
        }


        public string DepartmentName
        {
            get { return _nDepartmentName; }
            set { _nDepartmentName = value; }
        }

        public int CompanyID
        {
            get { return _nCompanyID; }
            set { _nCompanyID = value; }
        }

        public string CompanyName
        {
            get { return _sCompanyName; }
            set { _sCompanyName = value; }
        }

        public int D1
        {
            get { return _nD1; }
            set { _nD1 = value; }
        }

        public int D2
        {
            get { return _nD2; }
            set { _nD2 = value; }
        }

        public int D3
        {
            get { return _nD3; }
            set { _nD3 = value; }
        }
        public int D4
        {
            get { return _nD4; }
            set { _nD4 = value; }
        }
        public int D5
        {
            get { return _nD5; }
            set { _nD5 = value; }
        }

        public int D6
        {
            get { return _nD6; }
            set { _nD6 = value; }
        }
        public int D7
        {
            get { return _nD7; }
            set { _nD7 = value; }
        }
        public int D8
        {
            get { return _nD8; }
            set { _nD8 = value; }
        }
        public int D9
        {
            get { return _nD9; }
            set { _nD9 = value; }
        }
        public int D10
        {
            get { return _nD10; }
            set { _nD10 = value; }
        }
        public int D11
        {
            get { return _nD11; }
            set { _nD11 = value; }
        }
        public int D12
        {
            get { return _nD12; }
            set { _nD12 = value; }
        }
        public int D13
        {
            get { return _nD13; }
            set { _nD13 = value; }
        }

        public int D14
        {
            get { return _nD14; }
            set { _nD14 = value; }
        }
        public int D15
        {
            get { return _nD15; }
            set { _nD15 = value; }
        }
        public int D16
        {
            get { return _nD16; }
            set { _nD16 = value; }
        }

        public int D17
        {
            get { return _nD17; }
            set { _nD17 = value; }
        }
        public int D18
        {
            get { return _nD18; }
            set { _nD18 = value; }
        }
        public int D19
        {
            get { return _nD19; }
            set { _nD19 = value; }
        }
        public int D20
        {
            get { return _nD20; }
            set { _nD20 = value; }
        }
        public int D21
        {
            get { return _nD21; }
            set { _nD21 = value; }
        }
        public int D22
        {
            get { return _nD22; }
            set { _nD22 = value; }
        }
        public int D23
        {
            get { return _nD23; }
            set { _nD23 = value; }
        }
        public int D24
        {
            get { return _nD24; }
            set { _nD24 = value; }
        }

        public int D25
        {
            get { return _nD25; }
            set { _nD25 = value; }
        }
        public int D26
        {
            get { return _nD26; }
            set { _nD26 = value; }
        }
        public int D27
        {
            get { return _nD27; }
            set { _nD27 = value; }
        }

        public int D28
        {
            get { return _nD28; }
            set { _nD28 = value; }
        }

        public int D29
        {
            get { return _nD29; }
            set { _nD29 = value; }
        }

        public int D30
        {
            get { return _nD30; }
            set { _nD30 = value; }
        }
        public int D31
        {
            get { return _nD31; }
            set { _nD31 = value; }
        }        

        public int HD
        {
            get { return _nHD; }
            set { _nHD = value; }    
        }

        public int LA
        {
            get { return _nLA; }
            set { _nLA = value; }        
        }

        public int PR
        {
            get { return _nPR; }
            set { _nPR = value; }
        
        }

        public int LV
        {
            get { return _nLV; }
            set { _nLV = value; }     
        }

        public int OS
        {
            get { return _nOS; }
            set { _nOS = value; }         
        
        }

        public int AB
        {
            get { return _nAB; }
            set { _nAB = value; }   
        }

        public int TL
        {
            get { return _nTL; }
            set { _nTL = value; }   
        }

    }

    public class RptAttendanceReports : CollectionBaseCustom
    {
        public void Add(RptAttendanceReport oRptAttendanceReport)
        {
            this.List.Add(oRptAttendanceReport);
        }
        public RptAttendanceReport this[Int32 Index]
        {
            get
            {
                return (RptAttendanceReport)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(RptAttendanceReport))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }


        public void AttendanceReport(DateTime dYFromDate, DateTime dYToDate)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();


            sQueryStringMaster.Append(" select q1.EmployeeCode,EmployeeName,DesignationName,DepartmentID,DepartmentName, CompanyID,CompanyName,D1,D2,D3,D4,D5,D6,D7,D8,D9, ");
            sQueryStringMaster.Append(" D10,D11,D12,D13,D14,D15,D16,D17,D18,D19,D20,D21,D22,D23,D24,D25,D26,D27,D28,D29,D30,D31,HD,LA,PR,LV,OS,AB,TL ");
            sQueryStringMaster.Append(" from ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append("  select EmployeeCode,EmployeeName,DesignationName,DepartmentID,DepartmentName, CompanyID,CompanyName, ");
            sQueryStringMaster.Append("  sum(case Day(PunchDate) when 1 then StatusWithGrace else 0 end ) as D1, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 2 then StatusWithGrace else 0 end )as D2, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 3 then StatusWithGrace else 0 end )as D3, ");
            sQueryStringMaster.Append("  sum(case Day(PunchDate) when 4 then StatusWithGrace else 0 end ) as D4, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 5 then StatusWithGrace else 0 end )as D5, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 6 then StatusWithGrace else 0 end )as D6, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 7 then StatusWithGrace else 0 end )as D7, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 8 then StatusWithGrace else 0 end )as D8, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 9 then StatusWithGrace else 0 end )as D9, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 10 then StatusWithGrace else 0 end )as D10, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 11 then StatusWithGrace else 0 end )as D11, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 12 then StatusWithGrace else 0 end )as D12, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 13 then StatusWithGrace else 0 end )as D13, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 14 then StatusWithGrace else 0 end )as D14, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 15 then StatusWithGrace else 0 end )as D15, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 16 then StatusWithGrace else 0 end )as D16, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 17 then StatusWithGrace else 0 end )as D17, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 18 then StatusWithGrace else 0 end )as D18, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 19 then StatusWithGrace else 0 end )as D19, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 20 then StatusWithGrace else 0 end )as D20, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 21 then StatusWithGrace else 0 end )as D21, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 22 then StatusWithGrace else 0 end )as D22, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 23 then StatusWithGrace else 0 end )as D23, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 24 then StatusWithGrace else 0 end )as D24, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 25 then StatusWithGrace else 0 end )as D25, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 26 then StatusWithGrace else 0 end )as D26, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 27 then StatusWithGrace else 0 end )as D27, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 28 then StatusWithGrace else 0 end )as D28, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 29 then StatusWithGrace else 0 end )as D29, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 30 then StatusWithGrace else 0 end )as D30, ");
            sQueryStringMaster.Append("  sum(case Day (PunchDate) when 31 then StatusWithGrace else 0 end )as D31  ");

            sQueryStringMaster.Append("  from ");
            sQueryStringMaster.Append("  ( ");
            sQueryStringMaster.Append("  select EmployeeCode,EmployeeName,DesignationName,DepartmentID,DepartmentName, CompanyID,CompanyName, CONVERT(CHAR(4), PunchDate, 120)AS Year,  ");
            sQueryStringMaster.Append("  CONVERT(CHAR(3), PunchDate, 109) AS Month, PunchDate,TimeIn,TimeOut,Late,Status,StatusWithGrace ");
            sQueryStringMaster.Append("  from ");
            sQueryStringMaster.Append("  ( ");
            sQueryStringMaster.Append("  Select EmployeeCode,EmployeeName,DesignationName,DepartmentID,DepartmentName,CompanyID,CompanyName, ");
            sQueryStringMaster.Append("  CONVERT(CHAR(4), PunchDate, 120)AS Year,  ");
            sQueryStringMaster.Append("  CONVERT(CHAR(3), PunchDate, 109) AS Month, ");
            sQueryStringMaster.Append("  PunchDate,TimeIn,TimeOut, ");
            sQueryStringMaster.Append("  Late=CASE When TimeIn > LoginTime then Late else null end, ");
            sQueryStringMaster.Append("  Status=CASE  ");
            sQueryStringMaster.Append("  When PunchDate = Holiday then 1 ");
            sQueryStringMaster.Append("  When Status = 4 then 4 ");
            sQueryStringMaster.Append("  When Status = 5 then 5 ");
            sQueryStringMaster.Append("  When TimeIn > LoginTime then 2 ");
            sQueryStringMaster.Append("  When TimeIn <= LoginTime then 3 ");
            sQueryStringMaster.Append("  else 6 end, ");
            sQueryStringMaster.Append("  StatusWithGrace=CASE  ");
            sQueryStringMaster.Append("  When PunchDate = Holiday then 1 ");
            sQueryStringMaster.Append("  When Status = 4 then 4 ");
            sQueryStringMaster.Append("  When Status = 5 then 5 ");
            sQueryStringMaster.Append("  When TimeIn >= ExtGraceTime then 7 ");
            sQueryStringMaster.Append("  When TimeIn > GraceTime then 2 ");
            sQueryStringMaster.Append("  When TimeIn <= GraceTime then 3 ");
            sQueryStringMaster.Append(" else 6 end ");
            sQueryStringMaster.Append("  from ");
            sQueryStringMaster.Append("  ( ");
            sQueryStringMaster.Append("  Select AI.EmployeeID,E.EmployeeCode,E.EmployeeName, PunchDate, ");
            sQueryStringMaster.Append("  cast(convert(nvarchar(14),TimeIn,108)as Datetime)TimeIn, ");
            sQueryStringMaster.Append("  TimeOut, PunchCount, Status,Holiday, ");
            sQueryStringMaster.Append("  SRS.LoginTime, DATEADD(MINUTE,15,SRS.LoginTime)GraceTime, DATEADD(MINUTE,60,SRS.LoginTime)ExtGraceTime, ");
            sQueryStringMaster.Append("  (cast(convert(nvarchar(14),TimeIn,108)as Datetime)-SRS.LoginTime)Late, ");
            sQueryStringMaster.Append("  E.CompanyID,CompanyName, DesignationName, E.DepartmentID,DepartmentName ");
            sQueryStringMaster.Append("  from (Select * From t_HRAttendInfo Where PunchDate between ? and ? and PunchDate < ? )AI  ");
            sQueryStringMaster.Append("  INNER JOIN  (select * from t_Employee  where ShowAttendanceRpt=1) E ");
            sQueryStringMaster.Append("  ON E.EmployeeID=AI.EmployeeID ");
            sQueryStringMaster.Append("  INNER JOIN (Select ShiftID,cast(convert(nvarchar(5),LoginTime,108)as Datetime)LoginTime from t_HRShift )SRS ");
            sQueryStringMaster.Append("  ON SRS.ShiftID=E.ShiftID ");
            sQueryStringMaster.Append("  Left Outer JOIN t_HRHoliday H ");
            sQueryStringMaster.Append("  ON H.CompanyID=E.CompanyID and H.Holiday=AI.PunchDate ");
            sQueryStringMaster.Append("  INNER JOIN t_Company C ");
            sQueryStringMaster.Append("  ON C.CompanyID=E.CompanyID ");
            sQueryStringMaster.Append("  INNER JOIN t_Designation D ");
            sQueryStringMaster.Append("  ON D.DesignationID=E.DesignationID ");
            sQueryStringMaster.Append("  INNER JOIN t_Department Dep ");
            sQueryStringMaster.Append("  ON Dep.DepartmentID=E.DepartmentID ");
            sQueryStringMaster.Append("  )A ");            
            sQueryStringMaster.Append("  ) as Final ");
            sQueryStringMaster.Append(" )as TTL ");
            sQueryStringMaster.Append("  group by EmployeeCode,EmployeeName,DesignationName,DepartmentID,DepartmentName, CompanyID,CompanyName ");
            sQueryStringMaster.Append("  ) as q1 ");

            sQueryStringMaster.Append(" left outer join ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" select EmployeeCode, ");
            sQueryStringMaster.Append(" sum(case(StatusWithGrace) when 1 then  TotalStatus else 0 end ) as 'HD', ");
            sQueryStringMaster.Append(" sum(case(StatusWithGrace) when 2 then  TotalStatus else 0 end ) as 'LA', ");
            sQueryStringMaster.Append(" sum(case(StatusWithGrace) when 3 then  TotalStatus else 0 end ) as 'PR', ");
            sQueryStringMaster.Append(" sum(case(StatusWithGrace) when 4 then  TotalStatus else 0 end ) as 'LV', ");
            sQueryStringMaster.Append(" sum(case(StatusWithGrace) when 5 then  TotalStatus else 0 end ) as 'OS', ");
            sQueryStringMaster.Append(" sum(case(StatusWithGrace) when 6 then  TotalStatus else 0 end ) as 'AB', ");
            sQueryStringMaster.Append(" sum(case(StatusWithGrace) when 7 then  TotalStatus else 0 end ) as 'TL' ");
            sQueryStringMaster.Append(" from ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" select EmployeeCode,EmployeeName,DesignationName,DepartmentID,DepartmentName, CompanyID,CompanyName, StatusWithGrace, ");
            sQueryStringMaster.Append(" count(StatusWithGrace)as TotalStatus     ");
            sQueryStringMaster.Append(" from  ");
            sQueryStringMaster.Append(" (  ");
            sQueryStringMaster.Append(" select EmployeeCode,EmployeeName,DesignationName,DepartmentID,DepartmentName, CompanyID,CompanyName, CONVERT(CHAR(4), PunchDate, 120)AS Year,   ");
            sQueryStringMaster.Append(" CONVERT(CHAR(3), PunchDate, 109) AS Month, PunchDate,TimeIn,TimeOut,Late,StatusWithGrace  ");
            sQueryStringMaster.Append(" from  ");
            sQueryStringMaster.Append(" (  ");
            sQueryStringMaster.Append(" Select EmployeeCode,EmployeeName,DesignationName,DepartmentID,DepartmentName,CompanyID,CompanyName,  ");
            sQueryStringMaster.Append(" CONVERT(CHAR(4), PunchDate, 120)AS Year,   ");
            sQueryStringMaster.Append(" CONVERT(CHAR(3), PunchDate, 109) AS Month,  ");
            sQueryStringMaster.Append(" PunchDate,TimeIn,TimeOut,  ");
            sQueryStringMaster.Append(" Late=CASE When TimeIn > LoginTime then Late else null end,     ");
            sQueryStringMaster.Append(" StatusWithGrace=CASE   ");
            sQueryStringMaster.Append(" When PunchDate = Holiday then 1  ");
            sQueryStringMaster.Append(" When Status = 4 then 4  ");
            sQueryStringMaster.Append(" When Status = 5 then 5  ");
            sQueryStringMaster.Append(" When TimeIn >= ExtGraceTime then 7  ");
            sQueryStringMaster.Append(" When TimeIn > GraceTime then 2  ");
            sQueryStringMaster.Append(" When TimeIn <= GraceTime then 3 ");
            sQueryStringMaster.Append(" else 6 end  ");
            sQueryStringMaster.Append(" from  ");
            sQueryStringMaster.Append(" (  ");
            sQueryStringMaster.Append(" Select AI.EmployeeID,E.EmployeeCode,E.EmployeeName, PunchDate,  ");
            sQueryStringMaster.Append(" cast(convert(nvarchar(14),TimeIn,108)as Datetime)TimeIn,  ");
            sQueryStringMaster.Append("  TimeOut, PunchCount, Status,Holiday,  ");
            sQueryStringMaster.Append(" SRS.LoginTime, DATEADD(MINUTE,15,SRS.LoginTime)GraceTime,  ");
            sQueryStringMaster.Append("  DATEADD(MINUTE,60,SRS.LoginTime)ExtGraceTime,  ");
            sQueryStringMaster.Append(" (cast(convert(nvarchar(14),TimeIn,108)as Datetime)-SRS.LoginTime)Late,  ");
            sQueryStringMaster.Append(" E.CompanyID,CompanyName, DesignationName, E.DepartmentID,DepartmentName  ");
            sQueryStringMaster.Append(" from (Select * From t_HRAttendInfo Where PunchDate between ? and ? and PunchDate < ? )AI   ");
            sQueryStringMaster.Append(" INNER JOIN  (select * from t_Employee  where ShowAttendanceRpt=1) E  ");
            sQueryStringMaster.Append(" ON E.EmployeeID=AI.EmployeeID  ");
            sQueryStringMaster.Append(" INNER JOIN (Select ShiftID,cast(convert(nvarchar(5),LoginTime,108)as Datetime)LoginTime from t_HRShift )SRS  ");
            sQueryStringMaster.Append(" ON SRS.ShiftID=E.ShiftID  ");
            sQueryStringMaster.Append(" Left Outer JOIN t_HRHoliday H "); 
            sQueryStringMaster.Append(" ON H.CompanyID=E.CompanyID and H.Holiday=AI.PunchDate  ");
            sQueryStringMaster.Append(" INNER JOIN t_Company C  ");
            sQueryStringMaster.Append(" ON C.CompanyID=E.CompanyID  ");
            sQueryStringMaster.Append(" INNER JOIN t_Designation D  ");
            sQueryStringMaster.Append(" ON D.DesignationID=E.DesignationID  ");
            sQueryStringMaster.Append(" INNER JOIN t_Department Dep  ");
            sQueryStringMaster.Append(" ON Dep.DepartmentID=E.DepartmentID  ");
            sQueryStringMaster.Append(" )A    ");
            sQueryStringMaster.Append(" ) as Final  ");
            sQueryStringMaster.Append(" )as TTL  ");
            sQueryStringMaster.Append(" group by EmployeeCode,EmployeeName,DesignationName,DepartmentID,DepartmentName, CompanyID,CompanyName,StatusWithGrace  ");
            sQueryStringMaster.Append(" )TTLCount  ");
            sQueryStringMaster.Append(" group by EmployeeCode  ");
            sQueryStringMaster.Append(" ) as q2 on q1.EmployeeCode=q2.EmployeeCode ");
            

            OleDbCommand oCmd = DBController.Instance.GetCommand();
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();

            oCmd.Parameters.AddWithValue("Date", dYFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.AddDays(1));


            oCmd.Parameters.AddWithValue("Date", dYFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.AddDays(1));

            GetAttendanceReport(oCmd);

        }

        public void GetAttendanceReport(OleDbCommand cmd)
        {
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RptAttendanceReport oItem = new RptAttendanceReport();
                    

                    if (reader["EmployeeCode"] != DBNull.Value)
                        oItem.EmployeeCode = Convert.ToInt32(reader["EmployeeCode"]);
                    else oItem.EmployeeCode = 0;

                    if (reader["EmployeeName"] != DBNull.Value)
                        oItem.EmployeeName = (string)reader["EmployeeName"];
                    else oItem.EmployeeName = "";

                    if (reader["DesignationName"] != DBNull.Value)
                        oItem.DesignationName = (string)reader["DesignationName"];
                    else oItem.DesignationName = "";

                    if (reader["DepartmentID"] != DBNull.Value)
                        oItem.DepartmentID = (int)reader["DepartmentID"];
                    else oItem.DepartmentID = 0;

                    if (reader["DepartmentName"] != DBNull.Value)
                        oItem.DepartmentName = (string)reader["DepartmentName"];
                    else oItem.DepartmentName = "";

                    if (reader["CompanyID"] != DBNull.Value)
                        oItem.CompanyID = (int)reader["CompanyID"];
                    else oItem.CompanyID = 0;

                    if (reader["CompanyName"] != DBNull.Value)
                        oItem.CompanyName = (string)reader["CompanyName"];
                    else oItem.CompanyName = "";

                    if (reader["D1"] != DBNull.Value)
                        oItem.D1 = (int)reader["D1"];
                    else oItem.D1 = 0;

                    if (reader["D2"] != DBNull.Value)
                        oItem.D2 = (int)reader["D2"];
                    else oItem.D2 = 0;

                    if (reader["D3"] != DBNull.Value)
                        oItem.D3 = (int)reader["D3"];
                    else oItem.D3 = 0;

                    if (reader["D4"] != DBNull.Value)
                        oItem.D4 = (int)reader["D4"];
                    else oItem.D4 = 0;

                    if (reader["D5"] != DBNull.Value)
                        oItem.D5 = (int)reader["D5"];
                    else oItem.D5 = 0;

                    if (reader["D6"] != DBNull.Value)
                        oItem.D6 = (int)reader["D6"];
                    else oItem.D6 = 0;

                    if (reader["D7"] != DBNull.Value)
                        oItem.D7 = (int)reader["D7"];
                    else oItem.D7 = 0;

                    if (reader["D8"] != DBNull.Value)
                        oItem.D8 = (int)reader["D8"];
                    else oItem.D8 = 0;

                    if (reader["D9"] != DBNull.Value)
                        oItem.D9 = (int)reader["D9"];
                    else oItem.D9 = 0;

                    if (reader["D10"] != DBNull.Value)
                        oItem.D10 = (int)reader["D10"];
                    else oItem.D10 = 0;

                    if (reader["D11"] != DBNull.Value)
                        oItem.D11 = (int)reader["D11"];
                    else oItem.D11 = 0;

                    if (reader["D12"] != DBNull.Value)
                        oItem.D12 = (int)reader["D12"];
                    else oItem.D12 = 0;

                    if (reader["D13"] != DBNull.Value)
                        oItem.D13 = (int)reader["D13"];
                    else oItem.D13 = 0;

                    if (reader["D14"] != DBNull.Value)
                        oItem.D14 = (int)reader["D14"];
                    else oItem.D14 = 0;

                    if (reader["D15"] != DBNull.Value)
                        oItem.D15 = (int)reader["D15"];
                    else oItem.D15 = 0;

                    if (reader["D16"] != DBNull.Value)
                        oItem.D16 = (int)reader["D16"];
                    else oItem.D16 = 0;

                    if (reader["D17"] != DBNull.Value)
                        oItem.D17 = (int)reader["D17"];
                    else oItem.D17 = 0;

                    if (reader["D18"] != DBNull.Value)
                        oItem.D18 = (int)reader["D18"];
                    else oItem.D18 = 0;

                    if (reader["D19"] != DBNull.Value)
                        oItem.D19 = (int)reader["D19"];
                    else oItem.D19 = 0;

                    if (reader["D20"] != DBNull.Value)
                        oItem.D20 = (int)reader["D20"];
                    else oItem.D20 = 0;

                    if (reader["D21"] != DBNull.Value)
                        oItem.D21 = (int)reader["D21"];
                    else oItem.D21 = 0;

                    if (reader["D22"] != DBNull.Value)
                        oItem.D22 = (int)reader["D22"];
                    else oItem.D22 = 0;

                    if (reader["D23"] != DBNull.Value)
                        oItem.D23 = (int)reader["D23"];
                    else oItem.D23 = 0;

                    if (reader["D24"] != DBNull.Value)
                        oItem.D24 = (int)reader["D24"];
                    else oItem.D24 = 0;

                    if (reader["D25"] != DBNull.Value)
                        oItem.D25 = (int)reader["D25"];
                    else oItem.D25 = 0;

                    if (reader["D26"] != DBNull.Value)
                        oItem.D26 = (int)reader["D26"];
                    else oItem.D26 = 0;

                    if (reader["D27"] != DBNull.Value)
                        oItem.D27 = (int)reader["D27"];
                    else oItem.D27 = 0;

                    if (reader["D28"] != DBNull.Value)
                        oItem.D28 = (int)reader["D28"];
                    else oItem.D28 = 0;

                    if (reader["D29"] != DBNull.Value)
                        oItem.D29 = (int)reader["D29"];
                    else oItem.D29 = 0;


                    if (reader["D30"] != DBNull.Value)
                        oItem.D30 = (int)reader["D30"];
                    else oItem.D30 = 0;

                    if (reader["D31"] != DBNull.Value)
                        oItem.D31 = (int)reader["D31"];
                    else oItem.D31 = 0;

                    if (reader["HD"] != DBNull.Value)
                        oItem.HD = (int)reader["HD"];
                    else oItem.HD = 0;

                    if (reader["LA"] != DBNull.Value)
                        oItem.LA = (int)reader["LA"];
                    else oItem.LA = 0;

                    if (reader["PR"] != DBNull.Value)
                        oItem.PR = (int)reader["PR"];
                    else oItem.PR = 0;

                    if (reader["LV"] != DBNull.Value)
                        oItem.LV = (int)reader["LV"];
                    else oItem.PR = 0;

                    if (reader["OS"] != DBNull.Value)
                        oItem.OS = (int)reader["OS"];
                    else oItem.OS = 0;

                    if (reader["AB"] != DBNull.Value)
                        oItem.AB = (int)reader["AB"];
                    else oItem.AB = 0;

                    if (reader["TL"] != DBNull.Value)
                        oItem.TL = (int)reader["TL"];
                    else oItem.TL = 0;
                    
                    
                    InnerList.Add(oItem);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void FromDataSetAttendanceReport(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    RptAttendanceReport oRptAttendanceReport = new RptAttendanceReport();

                    oRptAttendanceReport.EmployeeCode = Convert.ToInt32(oRow["EmployeeCode"]);
                    oRptAttendanceReport.EmployeeName = (string)oRow["EmployeeName"];
                    oRptAttendanceReport.DesignationName = (string)oRow["DesignationName"];
                    oRptAttendanceReport.DepartmentID = Convert.ToInt32(oRow["DepartmentID"]);
                    oRptAttendanceReport.DepartmentName = (string)oRow["DepartmentName"];
                    oRptAttendanceReport.CompanyID = Convert.ToInt32(oRow["CompanyID"]);
                    oRptAttendanceReport.CompanyName = (string)oRow["CompanyName"];
                    oRptAttendanceReport.D1 = Convert.ToInt32(oRow["D1"]);
                    oRptAttendanceReport.D2 = Convert.ToInt32(oRow["D2"]);
                    oRptAttendanceReport.D3 = Convert.ToInt32(oRow["D3"]);
                    oRptAttendanceReport.D4 = Convert.ToInt32(oRow["D4"]);
                    oRptAttendanceReport.D5 = Convert.ToInt32(oRow["D5"]);
                    oRptAttendanceReport.D6 = Convert.ToInt32(oRow["D6"]);
                    oRptAttendanceReport.D7 = Convert.ToInt32(oRow["D7"]);
                    oRptAttendanceReport.D8 = Convert.ToInt32(oRow["D8"]);
                    oRptAttendanceReport.D9 = Convert.ToInt32(oRow["D9"]);
                    oRptAttendanceReport.D10 = Convert.ToInt32(oRow["D10"]);
                    oRptAttendanceReport.D11 = Convert.ToInt32(oRow["D11"]);
                    oRptAttendanceReport.D12 = Convert.ToInt32(oRow["D12"]);
                    oRptAttendanceReport.D13 = Convert.ToInt32(oRow["D13"]);
                    oRptAttendanceReport.D14 = Convert.ToInt32(oRow["D14"]);
                    oRptAttendanceReport.D15 = Convert.ToInt32(oRow["D15"]);
                    oRptAttendanceReport.D16 = Convert.ToInt32(oRow["D16"]);
                    oRptAttendanceReport.D17 = Convert.ToInt32(oRow["D17"]);
                    oRptAttendanceReport.D18 = Convert.ToInt32(oRow["D18"]);
                    oRptAttendanceReport.D19 = Convert.ToInt32(oRow["D19"]);
                    oRptAttendanceReport.D20 = Convert.ToInt32(oRow["D20"]);
                    oRptAttendanceReport.D21 = Convert.ToInt32(oRow["D21"]);
                    oRptAttendanceReport.D22 = Convert.ToInt32(oRow["D22"]);
                    oRptAttendanceReport.D23 = Convert.ToInt32(oRow["D23"]);
                    oRptAttendanceReport.D24 = Convert.ToInt32(oRow["D24"]);
                    oRptAttendanceReport.D25 = Convert.ToInt32(oRow["D25"]);
                    oRptAttendanceReport.D26 = Convert.ToInt32(oRow["D26"]);
                    oRptAttendanceReport.D27 = Convert.ToInt32(oRow["D27"]);
                    oRptAttendanceReport.D28 = Convert.ToInt32(oRow["D28"]);
                    oRptAttendanceReport.D29 = Convert.ToInt32(oRow["D29"]);
                    oRptAttendanceReport.D30 = Convert.ToInt32(oRow["D30"]);
                    oRptAttendanceReport.D31 = Convert.ToInt32(oRow["D31"]);
                    oRptAttendanceReport.HD = Convert.ToInt32(oRow["HD"]);
                    oRptAttendanceReport.LA = Convert.ToInt32(oRow["LA"]);
                    oRptAttendanceReport.PR = Convert.ToInt32(oRow["PR"]);
                    oRptAttendanceReport.LV = Convert.ToInt32(oRow["LV"]);
                    oRptAttendanceReport.OS = Convert.ToInt32(oRow["OS"]);
                    oRptAttendanceReport.AB = Convert.ToInt32(oRow["AB"]);
                    oRptAttendanceReport.TL = Convert.ToInt32(oRow["TL"]);

                    InnerList.Add(oRptAttendanceReport);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }


}