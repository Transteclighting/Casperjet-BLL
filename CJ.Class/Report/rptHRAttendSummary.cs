// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: June 13, 2011
// Time :  03:10 PM
// Description: Class for Attendance Data.
// Modify Person And Date:
// </summary>

using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Report
{
    public class rptHRAttendSummary
    {
        public int EmployeeID;
        public string EmployeeCode;
        public string EmployeeName;
        public string Company;
        public string Department;
        public string Designation;
        public DateTime PunchDate;
        public object TimeIn;
        public object Timeout;
        public int Present;
        public int Late;
        public int Absent;
        public int Leave;
        public int Holiday;
        public double Absentper;
        public string LocationName;

        public double One;
        public double Two;
        public double Three;
        public double Four;
        public double Five;
        public double Six;
        public double Seven;
        public double Eight;
        public double Nine;
        public double Ten;
        public double Eleven;
        public double Twelve;
        public double Thirteen;
        public double Forteen;
        public double Fifteen;
        public double Sixteen;
        public double Seventeen;
        public double Eighteen;
        public double Nineteen;
        public double Twenty;
        public double TwentyOne;
        public double TwentyTwo;
        public double TwentyThree;
        public double TwentyFour;
        public double TwentyFive;
        public double TwentySix;
        public double TwentySeven;
        public double TwentyEight;
        public double TwentyNine;
        public double Thirty;
        public double ThirtyOne;

        public double TotalHour;
        public double OverTime;
        public double OverTimeHourly;
        public double OverTimeAmount;
    }

    public class rptHRAttendSummarys : CollectionBase
    {
        public rptHRAttendSummary this[int i]
        {
            get { return (rptHRAttendSummary)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(rptHRAttendSummary oAttendSummary)
        {
            InnerList.Add(oAttendSummary);
        }


        public void RefreshEmployeeWise(DateTime dFromDate, DateTime dToDate, int nCompanyID, int nDepartmentID, int nLocationID,bool isAttendanceEmployee,bool AllEmployee,bool Isfactory,bool Nonfactory)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            
            string sSql = "select AAA.EmployeeID,EmployeeCode,EmployeeName,CompanyName,"
                + " DepartmentName,DesignationName,Present,Late,Absent,Leave,Holiday"
                + " from"
                + " (select EmployeeID,sum(case Status when 0 then Cnt else 0 end) as Absent,"
                + " sum(case Status when 1 then Cnt else 0 end) as Present,"
                + " sum(case Status when 2 then Cnt else 0 end) as Late,"
                + " sum(case Status when 3 then Cnt else 0 end) as Holiday,"
                + " sum(case Status when 4 then Cnt else 0 end) as Leave"
                + " from"
                + " (select EmployeeID,Status, Count(*) as Cnt"
                + " from t_HRAttendInfo A"
                + " where PunchDate between '"+ dFromDate + "' and '" + dToDate + "'"
                + " group by EmployeeID,Status) AA"
                + " group by EmployeeID) AAA"
                + " inner join v_EmployeeDetails B"
                + " on AAA.EmployeeID=B.EmployeeID WHERE 1=1 ";
            
            //cmd.Parameters.AddWithValue("FromDate", dFromDate);
            //cmd.Parameters.AddWithValue("ToDate", dToDate);

            if (nCompanyID > 0)
            {
                sSql += " AND CompanyID=" + nCompanyID;
            }

            if (nDepartmentID > 0)
            {
                sSql += " AND DepartmentID=" + nDepartmentID;
            }
            if (nLocationID > 0)
            {
                sSql += " AND LocationID=" + nLocationID;
            }
            if (isAttendanceEmployee)
            {
                sSql += " AND ShowAttendanceRpt = " + (int) Dictionary.YesOrNoStatus.YES;
            }
            else
            {
                sSql += " AND ShowAttendanceRpt = " + (int)Dictionary.YesOrNoStatus.NO;
            }
            if (AllEmployee)
            {
                sSql += " AND 1=1";
            }
            if (Isfactory)
            {
                sSql += " AND IsFactoryEmployee = " + (int)Dictionary.YesOrNoStatus.YES;
            }
            if (Nonfactory)
            {
                sSql += " AND IsFactoryEmployee = " + (int)Dictionary.YesOrNoStatus.NO;
            }
            sSql += " ORDER BY CompanyName, DepartmentName, AAA.EmployeeID";

            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            GetData(cmd);

        }
        
        private void GetData(OleDbCommand cmd)
        {
            try
            {
                double nAbsentper = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptHRAttendSummary oItem = new rptHRAttendSummary();

                    oItem.EmployeeID = (int)reader["EmployeeID"];
                    oItem.EmployeeCode = (string)reader["EmployeeCode"];
                    oItem.EmployeeName = (string)reader["EmployeeName"];
                    oItem.Department = (string)reader["DepartmentName"];
                    oItem.Designation = (string)reader["DesignationName"];
                    oItem.Company = (string)reader["CompanyName"];
                    //oItem.PunchDate = (DateTime)reader["PunchDate"];

                    //if (reader["Present"] != DBNull.Value)
                    //{
                    //    oItem.Present = int.Parse(reader["SalesPersonID"].ToString());
                    //}
                    //else oItem.Present = -1;
                    oItem.Present = (int)reader["Present"];
                    oItem.Absent = (int)reader["Absent"];
                    oItem.Late = (int)reader["Late"];
                    oItem.Present = oItem.Present + oItem.Late;
                    oItem.Leave = (int)reader["Leave"];
                    oItem.Holiday = (int)reader["Holiday"];
                    //nAbsentper = (oItem.Absent * 100)/(oItem.Present + oItem.Absent + oItem.Leave + oItem.Holiday);
                    oItem.Absentper = nAbsentper;
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

        public void RefreshDepartmentWise(DateTime dFromDate, DateTime dToDate, int nCompanyID, int nDepartmentID,int nLocationID,bool isAttendanceEmployee,bool AllEmployee, bool Isfactory, bool Nonfactory)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from (select CompanyID,CompanyName,DepartmentID,DepartmentName,Sum(Present) as Present,sum(Late) as Late,"
                    + " sum(Absent) as Absent,sum(Leave) as Leave,sum(Holiday) as Holiday,IsFactoryEmployee,ShowAttendanceRpt,LocationID,JobLocationName"
                    + " from"
                    + " (select CompanyID,CompanyName,DepartmentID,DepartmentName,Present,Late,Absent,Leave,Holiday,IsFactoryEmployee,ShowAttendanceRpt,LocationID,JobLocationName"
                    + " from"
                    + " (select EmployeeID,sum(case Status when 0 then Cnt else 0 end) as Absent,"
                    + " sum(case Status when 1 then Cnt else 0 end) as Present,"
                    + " sum(case Status when 2 then Cnt else 0 end) as Late,"
                    + " sum(case Status when 3 then Cnt else 0 end) as Holiday,"
                    + " sum(case Status when 4 then Cnt else 0 end) as Leave"
                    + " from"
                    + " (select EmployeeID,Status, Count(*) as Cnt"
                    + " from t_HRAttendInfo A"
                    + " where PunchDate between '" + dFromDate + "' and '" + dToDate + "'"
                    + " group by EmployeeID,Status) AA"
                    + " group by EmployeeID) AAA"
                    + " inner join v_EmployeeDetails B"
                    + " on AAA.EmployeeID=B.EmployeeID) C"
                    + " Group by CompanyID,CompanyName,DepartmentID,DepartmentName,IsFactoryEmployee,ShowAttendanceRpt,LocationID,JobLocationName) D WHERE 1=1 ";


            //cmd.Parameters.AddWithValue("FromDate", dFromDate);
            //cmd.Parameters.AddWithValue("ToDate", dToDate);



            if (nCompanyID > 0)
            {
                sSql += " AND CompanyID=" + nCompanyID;
                //sClause = " WHERE CompanyID=?";
                //cmd.Parameters.AddWithValue("CompanyID", nCompanyID);
            }

            if (nDepartmentID > 0)
            {
                sSql += " AND DepartmentID=" + nDepartmentID;

                //if (sClause == "") sClause = " WHERE DepartmentID=?";
                //else sClause = sClause + " AND DepartmentID=?";
                //cmd.Parameters.AddWithValue("DepartmentID", nDepartmentID);
            }
            if (nLocationID > 0)
            {
                sSql += " AND LocationID=" + nLocationID;
            }
            if (isAttendanceEmployee)
            {
                sSql += " AND ShowAttendanceRpt = " + (int)Dictionary.YesOrNoStatus.YES;
            }
            else
            {
                sSql += " AND ShowAttendanceRpt = " + (int)Dictionary.YesOrNoStatus.NO;
            }
            if (AllEmployee)
            {
                sSql += " AND 1=1";
            }
            if (Isfactory)
            {
                sSql += " AND IsFactoryEmployee = " + (int)Dictionary.YesOrNoStatus.YES;
            }
            if (Nonfactory)
            {
                sSql += " AND IsFactoryEmployee = " + (int)Dictionary.YesOrNoStatus.NO;
            }
            sSql += " ORDER BY CompanyName, DepartmentName";

            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;

            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptHRAttendSummary oItem = new rptHRAttendSummary();

                    //oItem.EmployeeID = (int)reader["EmployeeID"];
                    //oItem.EmployeeCode = (string)reader["EmployeeCode"];
                    //oItem.EmployeeName = (string)reader["EmployeeName"];
                    oItem.Department = (string)reader["DepartmentName"];
                    oItem.LocationName = (string)reader["JobLocationName"];
                    oItem.Company = (string)reader["CompanyName"];
                    //oItem.PunchDate = (DateTime)reader["PunchDate"];
                    oItem.Present = (int)reader["Present"];
                    oItem.Absent = (int)reader["Absent"];
                    oItem.Late = (int)reader["Late"];
                    oItem.Present = oItem.Present + oItem.Late;
                    oItem.Leave = (int)reader["Leave"];
                    oItem.Holiday = (int)reader["Holiday"];
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

        public void RefreshDayWise(DateTime dFromDate, DateTime dToDate, int nCompanyID, int nDepartmentID,int nLocationID,bool isAttendanceEmployee, bool AllEmployee, bool Isfactory, bool Nonfactory)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from (select CompanyID,CompanyName,DepartmentID,DepartmentName,PunchDate,Sum(Present) as Present,sum(Late) as Late,"
                + " sum(Absent) as Absent,sum(Leave) as Leave,sum(Holiday) as Holiday,IsFactoryEmployee,ShowAttendanceRpt,LocationID"
                + " from"
                + " ("
                + " select CompanyID,CompanyName,DepartmentID,DepartmentName,PunchDate,Present,Late,Absent,Leave,Holiday,IsFactoryEmployee,ShowAttendanceRpt,LocationID"
                + " from"
                + " (select EmployeeID,PunchDate,sum(case Status when 0 then Cnt else 0 end) as Absent,"
                + " sum(case Status when 1 then Cnt else 0 end) as Present,"
                + " sum(case Status when 2 then Cnt else 0 end) as Late,"
                + " sum(case Status when 3 then Cnt else 0 end) as Holiday,"
                + " sum(case Status when 4 then Cnt else 0 end) as Leave"
                + " from"
                + " (select EmployeeID,PunchDate,Status, Count(*) as Cnt"
                + " from t_HRAttendInfo A"
                + " where PunchDate between '" + dFromDate + "' and '" + dToDate + "'"
                + " group by EmployeeID,PunchDate,Status) AA"
                + " group by EmployeeID,PunchDate) AAA"
                + " inner join v_EmployeeDetails B"
                + " on AAA.EmployeeID=B.EmployeeID"
                + " ) C"
                + " Group by CompanyID,CompanyName,DepartmentID,DepartmentName,PunchDate,IsFactoryEmployee,ShowAttendanceRpt,LocationID) D WHERE 1=1 ";

            //cmd.Parameters.AddWithValue("FromDate", dFromDate);
            //cmd.Parameters.AddWithValue("ToDate", dToDate);

            if (nCompanyID > 0)
            {
                sSql += " AND CompanyID=" + nCompanyID;
                //sClause = " WHERE CompanyID=?";
                //cmd.Parameters.AddWithValue("CompanyID", nCompanyID);
            }

            if (nDepartmentID > 0)
            {
                sSql += " AND DepartmentID=" + nDepartmentID;

                //if (sClause == "") sClause = " WHERE DepartmentID=?";
                //else sClause = sClause + " AND DepartmentID=?";
                //cmd.Parameters.AddWithValue("DepartmentID", nDepartmentID);
            }
            if (nLocationID > 0)
            {
                sSql += " AND LocationID=" + nLocationID;
            }
            if (isAttendanceEmployee)
            {
                sSql += " AND ShowAttendanceRpt = " + (int)Dictionary.YesOrNoStatus.YES;
            }
            else
            {
                sSql += " AND ShowAttendanceRpt = " + (int)Dictionary.YesOrNoStatus.NO;
            }
            if (AllEmployee)
            {
                sSql += " AND 1=1";
            }
            if (Isfactory)
            {
                sSql += " AND IsFactoryEmployee = " + (int)Dictionary.YesOrNoStatus.YES;
            }
            if (Nonfactory)
            {
                sSql += " AND IsFactoryEmployee = " + (int)Dictionary.YesOrNoStatus.NO;
            }
            sSql += " ORDER BY CompanyName, DepartmentName";

            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;

            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptHRAttendSummary oItem = new rptHRAttendSummary();

                    //oItem.EmployeeID = (int)reader["EmployeeID"];
                    //oItem.EmployeeCode = (string)reader["EmployeeCode"];
                    //oItem.EmployeeName = (string)reader["EmployeeName"];
                    oItem.Department = (string)reader["DepartmentName"];
                    //oItem.Designation = (string)reader["DesignationName"];
                    oItem.Company = (string)reader["CompanyName"];
                    oItem.PunchDate = (DateTime)reader["PunchDate"];
                    oItem.Present = (int)reader["Present"];
                    oItem.Absent = (int)reader["Absent"];
                    oItem.Late = (int)reader["Late"];
                    oItem.Present = oItem.Present + oItem.Late;
                    oItem.Leave = (int)reader["Leave"];
                    oItem.Holiday = (int)reader["Holiday"];
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

        public void RefreshByWFH(DateTime dDate, int nCompanyID, int nDepartmentID, bool All, bool IsChecking, bool IsNotChecking)
        {
            InnerList.Clear();
           
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select EmployeeName,CompanyID,DepartmentID,CompanyName,DepartmentName,DesignationName, " +
                          "CONVERT(varchar(15),CAST( TimeIn AS TIME),100)TimeIn,CONVERT(varchar(15),CAST( TimeOut AS TIME),100)TimeOut from " +
                          "(Select * from v_EmployeeDetails where WFH = 'Yes')A " +
                          "Left Outer Join " +
                          "(Select * from t_HRAttendInfo where punchdate='" + dDate + "')B on A.EmployeeID = B.EmployeeID where 1=1";

            //sSql = sSql + " and punchdate='" + dDate + "' ";

            if (nCompanyID > 0)
            {
                sSql += " AND CompanyID=" + nCompanyID;
            }

            if (nDepartmentID > 0)
            {
                sSql += " AND DepartmentID=" + nDepartmentID;
            }
            if (All)
            {
                sSql += " AND 1=1";
            }
            if (IsChecking)
            {
                sSql += " AND TimeIn Is Not Null";
            }
            if (IsNotChecking)
            {
                sSql += " AND TimeIn Is Null";
            }
            //sSql += " ORDER BY CompanyName, DepartmentName";

            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;

            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptHRAttendSummary oItem = new rptHRAttendSummary();
                    oItem.EmployeeName = (string)reader["EmployeeName"];
                    oItem.Department = (string)reader["DepartmentName"];
                    oItem.Company = (string)reader["CompanyName"];
                    oItem.Designation = (string)reader["DesignationName"];
                    //oItem.PunchDate = (DateTime)reader["PunchDate"];
                    if (reader["TimeIn"] is DBNull)
                    {
                        oItem.TimeIn = null;
                    }
                    else
                    {
                        oItem.TimeIn = (string)reader["TimeIn"];
                    }
                    if (reader["Timeout"] is DBNull)
                    {
                        oItem.Timeout = null;
                    }
                    else
                    {
                        oItem.Timeout = (string)reader["Timeout"];
                    }
                    //oItem.TimeIn = (string)reader["TimeIn"];
                    //oItem.Timeout = (string)reader["Timeout"];
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

        public void RefreshFactoryFormate(int tMonth, int tYear, int nCompanyID, int nDepartmentID, int nEmployeeID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = String.Format(@"select
                                EmployeeID,CompanyID,DepartmentID,EmployeeCode,EmployeeName,DesignationName, 
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(One), 0))/60 + (ISNULL(sum(One), 0)% 60) / 100.0) as One,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(Two), 0))/60 + (ISNULL(sum(Two), 0)% 60) / 100.0) as Two,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(Three), 0))/60 + (ISNULL(sum(Three), 0)% 60) / 100.0) as Three,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(Four), 0))/60 + (ISNULL(sum(Four), 0)% 60) / 100.0) as Four,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(Five), 0))/60 + (ISNULL(sum(Five), 0)% 60) / 100.0) as Five,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(Six), 0))/60 + (ISNULL(sum(Six), 0)% 60) / 100.0) as Six,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(Seven), 0))/60 + (ISNULL(sum(Seven), 0)% 60) / 100.0) as Seven,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(Eight), 0))/60 + (ISNULL(sum(Eight), 0)% 60) / 100.0) as Eight,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(Nine), 0))/60 + (ISNULL(sum(Nine), 0)% 60) / 100.0) as Nine,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(Ten), 0))/60 + (ISNULL(sum(Ten), 0)% 60) / 100.0) as Ten,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(Eleven), 0))/60 + (ISNULL(sum(Eleven), 0)% 60) / 100.0) as Eleven,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(Twelve), 0))/60 + (ISNULL(sum(Twelve), 0)% 60) / 100.0) as Twelve,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(Thirteen), 0))/60 + (ISNULL(sum(Thirteen), 0)% 60) / 100.0) as Thirteen,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(Forteen), 0))/60 + (ISNULL(sum(Forteen), 0)% 60) / 100.0) as Forteen,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(Fifteen), 0))/60 + (ISNULL(sum(Fifteen), 0)% 60) / 100.0) as Fifteen,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(Sixteen), 0))/60 + (ISNULL(sum(Sixteen), 0)% 60) / 100.0) as Sixteen,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(Seventeen), 0))/60 + (ISNULL(sum(Seventeen), 0)% 60) / 100.0) as Seventeen,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(Eighteen), 0))/60 + (ISNULL(sum(Eighteen), 0)% 60) / 100.0) as Eighteen,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(Nineteen), 0))/60 + (ISNULL(sum(Nineteen), 0)% 60) / 100.0) as Nineteen,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(Twenty), 0))/60 + (ISNULL(sum(Twenty), 0)% 60) / 100.0) as Twenty,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(TwentyOne), 0))/60 + (ISNULL(sum(TwentyOne), 0)% 60) / 100.0) as TwentyOne,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(TwentyTwo), 0))/60 + (ISNULL(sum(TwentyTwo), 0)% 60) / 100.0) as TwentyTwo,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(TwentyThree), 0))/60 + (ISNULL(sum(TwentyThree), 0)% 60) / 100.0) as TwentyThree,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(TwentyFour), 0))/60 + (ISNULL(sum(TwentyFour), 0)% 60) / 100.0) as TwentyFour,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(TwentyFive), 0))/60 + (ISNULL(sum(TwentyFive), 0)% 60) / 100.0) as TwentyFive,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(TwentySix), 0))/60 + (ISNULL(sum(TwentySix), 0)% 60) / 100.0) as TwentySix,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(TwentySeven), 0))/60 + (ISNULL(sum(TwentySeven), 0)% 60) / 100.0) as TwentySeven,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(TwentyEight), 0))/60 + (ISNULL(sum(TwentyEight), 0)% 60) / 100.0) as TwentyEight,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(TwentyNine), 0))/60 + (ISNULL(sum(TwentyNine), 0)% 60) / 100.0) as TwentyNine,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(Thirty), 0))/60 + (ISNULL(sum(Thirty), 0)% 60) / 100.0) as Thirty,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(ThirtyOne), 0))/60 + (ISNULL(sum(Thirty), 0)% 60) / 100.0) as ThirtyOne,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(One), 0) + ISNULL(sum(Two), 0) + ISNULL(sum(Three), 0) + ISNULL(sum(Four), 0) 
                                + ISNULL(sum(Five), 0) + ISNULL(sum(Six), 0) + ISNULL(sum(Seven), 0)+ ISNULL(sum(Eight), 0)+ ISNULL(sum(Nine), 0)
                                + ISNULL(sum(Ten), 0) + ISNULL(sum(Eleven), 0) + ISNULL(sum(Twelve), 0)+ ISNULL(sum(Thirteen), 0)+ ISNULL(sum(Forteen), 0)
                                + ISNULL(sum(Fifteen), 0) + ISNULL(sum(Sixteen), 0) + ISNULL(sum(Seventeen), 0)+ ISNULL(sum(Eighteen), 0)+ ISNULL(sum(Nineteen), 0)
                                + ISNULL(sum(Twenty), 0) + ISNULL(sum(TwentyOne), 0) + ISNULL(sum(TwentyTwo), 0)+ ISNULL(sum(TwentyThree), 0)+ ISNULL(sum(TwentyFour), 0)
                                + ISNULL(sum(TwentyFive), 0) + ISNULL(sum(TwentySix), 0) + ISNULL(sum(TwentySeven), 0)+ ISNULL(sum(TwentyEight), 0)+ ISNULL(sum(TwentyNine), 0)
                                + ISNULL(sum(Thirty), 0) + ISNULL(sum(ThirtyOne), 0)
                                ) / 60 
                                + (ISNULL(sum(One), 0) + ISNULL(sum(Two), 0) + ISNULL(sum(Three), 0) + ISNULL(sum(Four), 0) 
                                + ISNULL(sum(Five), 0) + ISNULL(sum(Six), 0) + ISNULL(sum(Seven), 0)+ ISNULL(sum(Eight), 0)+ ISNULL(sum(Nine), 0)
                                + ISNULL(sum(Ten), 0) + ISNULL(sum(Eleven), 0) + ISNULL(sum(Twelve), 0)+ ISNULL(sum(Thirteen), 0)+ ISNULL(sum(Forteen), 0)
                                + ISNULL(sum(Fifteen), 0) + ISNULL(sum(Sixteen), 0) + ISNULL(sum(Seventeen), 0)+ ISNULL(sum(Eighteen), 0)+ ISNULL(sum(Nineteen), 0)
                                + ISNULL(sum(Twenty), 0) + ISNULL(sum(TwentyOne), 0) + ISNULL(sum(TwentyTwo), 0)+ ISNULL(sum(TwentyThree), 0)+ ISNULL(sum(TwentyFour), 0)
                                + ISNULL(sum(TwentyFive), 0) + ISNULL(sum(TwentySix), 0) + ISNULL(sum(TwentySeven), 0)+ ISNULL(sum(TwentyEight), 0)+ ISNULL(sum(TwentyNine), 0)
                                + ISNULL(sum(Thirty), 0) + ISNULL(sum(ThirtyOne), 0) % 60) / 100.0) TotalHour,
                                CONVERT(NUMERIC(18, 2), (ISNULL(sum(OverTimeOne), 0) + ISNULL(sum(OverTimeTwo), 0) + ISNULL(sum(OverTimeThree), 0) + ISNULL(sum(OverTimeFour), 0) 
                                + ISNULL(sum(OverTimeFive), 0) + ISNULL(sum(OverTimeSix), 0) + ISNULL(sum(OverTimeSeven), 0)+ ISNULL(sum(OverTimeEight), 0)+ ISNULL(sum(OverTimeNine), 0)
                                + ISNULL(sum(OverTimeTen), 0) + ISNULL(sum(Eleven), 0) + ISNULL(sum(Twelve), 0)+ ISNULL(sum(Thirteen), 0)+ ISNULL(sum(Forteen), 0)
                                + ISNULL(sum(OverTimeFifteen), 0) + ISNULL(sum(OverTimeSixteen), 0) + ISNULL(sum(OverTimeSeventeen), 0)+ ISNULL(sum(OverTimeEighteen), 0)+ ISNULL(sum(OverTimeNineteen), 0)
                                + ISNULL(sum(OverTimeTwenty), 0) + ISNULL(sum(OverTimeTwentyOne), 0) + ISNULL(sum(OverTimeTwentyTwo), 0)+ ISNULL(sum(OverTimeTwentyThree), 0)+ ISNULL(sum(OverTimeTwentyFour), 0)
                                + ISNULL(sum(OverTimeTwentyFive), 0) + ISNULL(sum(OverTimeTwentySix), 0) + ISNULL(sum(OverTimeTwentySeven), 0)+ ISNULL(sum(OverTimeTwentyEight), 0)+ ISNULL(sum(OverTimeTwentyNine), 0)
                                + ISNULL(sum(OverTimeThirty), 0) + ISNULL(sum(OverTimeThirtyOne), 0)
                                ) / 60 
                                + (ISNULL(sum(OverTimeOne), 0) + ISNULL(sum(OverTimeTwo), 0) + ISNULL(sum(OverTimeThree), 0) + ISNULL(sum(OverTimeFour), 0) 
                                + ISNULL(sum(OverTimeFive), 0) + ISNULL(sum(OverTimeSix), 0) + ISNULL(sum(OverTimeSeven), 0)+ ISNULL(sum(OverTimeEight), 0)+ ISNULL(sum(OverTimeNine), 0)
                                + ISNULL(sum(OverTimeTen), 0) + ISNULL(sum(OverTimeEleven), 0) + ISNULL(sum(OverTimeTwelve), 0)+ ISNULL(sum(OverTimeThirteen), 0)+ ISNULL(sum(OverTimeForteen), 0)
                                + ISNULL(sum(OverTimeFifteen), 0) + ISNULL(sum(OverTimeSixteen), 0) + ISNULL(sum(OverTimeSeventeen), 0)+ ISNULL(sum(OverTimeEighteen), 0)+ ISNULL(sum(OverTimeNineteen), 0)
                                + ISNULL(sum(OverTimeTwenty), 0) + ISNULL(sum(OverTimeTwentyOne), 0) + ISNULL(sum(OverTimeTwentyTwo), 0)+ ISNULL(sum(OverTimeTwentyThree), 0)+ ISNULL(sum(OverTimeTwentyFour), 0)
                                + ISNULL(sum(OverTimeTwentyFive), 0) + ISNULL(sum(OverTimeTwentySix), 0) + ISNULL(sum(OverTimeTwentySeven), 0)+ ISNULL(sum(OverTimeTwentyEight), 0)+ ISNULL(sum(OverTimeTwentyNine), 0)
                                + ISNULL(sum(OverTimeThirty), 0) + ISNULL(sum(OverTimeThirtyOne), 0) % 60) / 100.0) OverTime,
                                (Amount / MonthlyOTHour * 2 / 60) * 60 as OverTimeHourly, 
                                ((Amount / MonthlyOTHour * 2 / 60) * 
                                (ISNULL(sum(OverTimeOne), 0) + ISNULL(sum(OverTimeTwo), 0) + ISNULL(sum(OverTimeThree), 0) + ISNULL(sum(OverTimeFour), 0)
                                +ISNULL(sum(OverTimeFive), 0) + ISNULL(sum(OverTimeSix), 0) + ISNULL(sum(OverTimeSeven), 0)
                                +ISNULL(sum(OverTimeEight), 0) + ISNULL(sum(OverTimeNine), 0) + ISNULL(sum(OverTimeTen), 0)
                                +ISNULL(sum(OverTimeEleven), 0) + ISNULL(sum(OverTimeTwelve), 0) + ISNULL(sum(OverTimeThirteen), 0)
                                +ISNULL(sum(OverTimeForteen), 0) + ISNULL(sum(OverTimeFifteen), 0) + ISNULL(sum(OverTimeSixteen), 0)
                                +ISNULL(sum(OverTimeSeventeen), 0) + ISNULL(sum(OverTimeEighteen), 0) + ISNULL(sum(OverTimeNineteen), 0)
                                +ISNULL(sum(OverTimeTwenty), 0) + ISNULL(sum(OverTimeTwentyOne), 0) + ISNULL(sum(OverTimeTwentyTwo), 0)
                                +ISNULL(sum(OverTimeTwentyThree), 0) + ISNULL(sum(OverTimeTwentyFour), 0) + ISNULL(sum(OverTimeTwentyFive), 0)
                                +ISNULL(sum(OverTimeTwentySix), 0) + ISNULL(sum(OverTimeTwentySeven), 0) + ISNULL(sum(OverTimeTwentyEight), 0)
                                +ISNULL(sum(OverTimeTwentyNine), 0) + ISNULL(sum(OverTimeThirty), 0) + ISNULL(sum(OverTimeThirtyOne), 0)
                                )
                                ) as OverTimeAmount
                                from
                                (
                                Select DayNumber, Emp.EmployeeCode, Emp.EmployeeName, Emp.DesignationName, D.Amount, E.MonthlyOTHour,
                                A.EmployeeID, A.CompanyID, A.DepartmentID,ISNULL(TotalMinutes,0) TotalMinutes, ISNULL(Extraminuite,0) Extraminuite
                                ,(Amount / MonthlyOTHour * 2 / 60) * 60 as OverTimeHourly,
                                (Case when DayNumber=1 then  isnull(TotalMinutes, 0) end) as One,
                                (Case when DayNumber=1 then  ISNULL(Extraminuite,0) end) as OverTimeOne,
                                (Case when DayNumber=2 then  isnull(TotalMinutes, 0) end) as Two,
                                (Case when DayNumber=2 then  ISNULL(Extraminuite,0) end) as OverTimeTwo,
                                (Case when DayNumber=3 then  isnull(TotalMinutes, 0) end) as Three,
                                (Case when DayNumber=3 then  ISNULL(Extraminuite,0) end) as OverTimeThree,
                                (Case when DayNumber=4 then  isnull(TotalMinutes, 0) end) as Four,
                                (Case when DayNumber=4 then  ISNULL(Extraminuite,0) end) as OverTimeFour,
                                (Case when DayNumber=5 then  isnull(TotalMinutes, 0) end) as Five,
                                (Case when DayNumber=5 then  ISNULL(Extraminuite,0) end) as OverTimeFive,
                                (Case when DayNumber=6 then  isnull(TotalMinutes, 0) end) as Six,
                                (Case when DayNumber=6 then  ISNULL(Extraminuite,0) end) as OverTimeSix,
                                (Case when DayNumber=7 then  isnull(TotalMinutes, 0) end) as Seven,
                                (Case when DayNumber=7 then  ISNULL(Extraminuite,0) end) as OverTimeSeven,
                                (Case when DayNumber=8 then  isnull(TotalMinutes, 0) end) as Eight,
                                (Case when DayNumber=8 then  ISNULL(Extraminuite,0) end) as OverTimeEight,
                                (Case when DayNumber=9 then  isnull(TotalMinutes, 0) end) as Nine,
                                (Case when DayNumber=9 then  ISNULL(Extraminuite,0) end) as OverTimeNine,
                                (Case when DayNumber=10 then  isnull(TotalMinutes, 0) end) as Ten,
                                (Case when DayNumber=10 then  ISNULL(Extraminuite,0) end) as OverTimeTen,
                                (Case when DayNumber=11 then  isnull(TotalMinutes, 0) end) as Eleven,
                                (Case when DayNumber=11 then  ISNULL(Extraminuite,0) end) as OverTimeEleven,
                                (Case when DayNumber=12 then  isnull(TotalMinutes, 0) end) as Twelve,
                                (Case when DayNumber=12 then  ISNULL(Extraminuite,0) end) as OverTimeTwelve,
                                (Case when DayNumber=13 then  isnull(TotalMinutes, 0) end) as Thirteen,
                                (Case when DayNumber=13 then  ISNULL(Extraminuite,0) end) as OverTimeThirteen,
                                (Case when DayNumber=14 then  isnull(TotalMinutes, 0) end) as Forteen,
                                (Case when DayNumber=14 then  ISNULL(Extraminuite,0) end) as OverTimeForteen,
                                (Case when DayNumber=15 then  isnull(TotalMinutes, 0) end) as Fifteen,
                                (Case when DayNumber=15 then  ISNULL(Extraminuite,0) end) as OverTimeFifteen,
                                (Case when DayNumber=16 then  isnull(TotalMinutes, 0) end) as Sixteen,
                                (Case when DayNumber=16 then  ISNULL(Extraminuite,0) end) as OverTimeSixteen,
                                (Case when DayNumber=17 then  isnull(TotalMinutes, 0) end) as Seventeen,
                                (Case when DayNumber=17 then  ISNULL(Extraminuite,0) end) as OverTimeSeventeen,
                                (Case when DayNumber=18 then  isnull(TotalMinutes, 0) end) as Eighteen,
                                (Case when DayNumber=18 then  ISNULL(Extraminuite,0) end) as OverTimeEighteen,
                                (Case when DayNumber=19 then  isnull(TotalMinutes, 0) end) as Nineteen,
                                (Case when DayNumber=19 then  ISNULL(Extraminuite,0) end) as OverTimeNineteen,
                                (Case when DayNumber=20 then  isnull(TotalMinutes, 0) end) as Twenty,
                                (Case when DayNumber=20 then  ISNULL(Extraminuite,0) end) as OverTimeTwenty,
                                (Case when DayNumber=21 then  isnull(TotalMinutes, 0) end) as TwentyOne,
                                (Case when DayNumber=21 then  ISNULL(Extraminuite,0) end) as OverTimeTwentyOne,
                                (Case when DayNumber=22 then  isnull(TotalMinutes, 0) end) as TwentyTwo,
                                (Case when DayNumber=22 then  ISNULL(Extraminuite,0) end) as OverTimeTwentyTwo,
                                (Case when DayNumber=23 then  isnull(TotalMinutes, 0) end) as TwentyThree,
                                (Case when DayNumber=23 then  ISNULL(Extraminuite,0) end) as OverTimeTwentyThree,
                                (Case when DayNumber=24 then  isnull(TotalMinutes, 0) end) as TwentyFour,
                                (Case when DayNumber=24 then  ISNULL(Extraminuite,0) end) as OverTimeTwentyFour,
                                (Case when DayNumber=25 then  isnull(TotalMinutes, 0) end) as TwentyFive,
                                (Case when DayNumber=25 then  ISNULL(Extraminuite,0) end) as OverTimeTwentyFive,
                                (Case when DayNumber=26 then  isnull(TotalMinutes, 0) end) as TwentySix,
                                (Case when DayNumber=26 then  ISNULL(Extraminuite,0) end) as OverTimeTwentySix,
                                (Case when DayNumber=27 then  isnull(TotalMinutes, 0) end) as TwentySeven,
                                (Case when DayNumber=27 then  ISNULL(Extraminuite,0) end) as OverTimeTwentySeven,
                                (Case when DayNumber=28 then  isnull(TotalMinutes, 0) end) as TwentyEight,
                                (Case when DayNumber=28 then  ISNULL(Extraminuite,0) end) as OverTimeTwentyEight,
                                (Case when DayNumber=29 then  isnull(TotalMinutes, 0) end) as TwentyNine,
                                (Case when DayNumber=29 then  ISNULL(Extraminuite,0) end) as OverTimeTwentyNine,
                                (Case when DayNumber=30 then  isnull(TotalMinutes, 0) end) as Thirty,
                                (Case when DayNumber=30 then  ISNULL(Extraminuite,0) end) as OverTimeThirty,
                                (Case when DayNumber=31 then  isnull(TotalMinutes, 0) end) as ThirtyOne,
                                (Case when DayNumber=31 then  ISNULL(Extraminuite,0) end) as OverTimeThirtyOne

                                from
                                (SELECT a.EmployeeID, CompanyID, DepartmentID, Day(PunchDate) as DayNumber, TimeIn, TimeOut, PunchCount, Status, Late,
                                SUM(DATEDIFF(minute, TimeIn, TimeOut)) as TotalMinutes,
                                CASE when FORMAT(PunchDate, 'dddd') = 'Saturday' then (case when SUM(DATEDIFF(minute, TimeIn, TimeOut)) - 240 < 0 then 0  else SUM(DATEDIFF(minute, TimeIn, TimeOut)) - 240 end) 
                                when FORMAT(PunchDate, 'dddd') = 'Friday' then SUM(DATEDIFF(minute, TimeIn, TimeOut)) 
                                else (case when SUM(DATEDIFF(minute, TimeIn, TimeOut)) - 480 < 0 then 0  else SUM(DATEDIFF(minute, TimeIn, TimeOut)) - 480 end)  end as Extraminuite,
                                FORMAT(PunchDate, 'dddd') AS Date FROM t_HRAttendInfo A INNER JOIN
                                v_EmployeeDetails B ON A.EmployeeID = B.EmployeeID 
                                WHERE MONTH(PunchDate)={0} and YEAR(PunchDate)={1}
                                Group By a.EmployeeID, CompanyID, DepartmentID, PunchDate, TimeIn, TimeOut, PunchCount, Status, Late
                                ) A
                                inner join
                                dbo.t_HRPayrollEmployeeAllowance D on A.CompanyID = D.CompanyID and A.EmployeeID = D.EmployeeID and AllowanceID = 8 and EffectiveYear = YEAR('03-Dec-2021 12:00:00 AM')
                                inner join
                                t_HROverTimeMonthlyHour E on E.CompanyID = A.CompanyID and IsFactory = 1 and EmployeeStatus = 2
                                inner join
                                v_EmployeeDetails Emp on Emp.EmployeeID = A.EmployeeID and IsFactoryEmployee=1
                                )
                                as Att
                    ", tMonth, tYear);

            sSql = sSql + " Where 1=1 ";

            if (nCompanyID > 0)
            {
                sSql += " AND CompanyID=" + nCompanyID;
            }

            if (nDepartmentID > 0)
            {
                sSql += " AND DepartmentID=" + nDepartmentID;
            }
            if (nEmployeeID > 0)
            {
                sSql += " AND EmployeeID=" + nEmployeeID;
            }

            
            sSql += " Group By EmployeeID, CompanyID, DepartmentID,Amount,MonthlyOTHour,EmployeeCode,EmployeeName,DesignationName";
            
            //if (IsChecking)
            //{
            //    sSql += " AND TimeIn Is Not Null";
            //}
            //if (IsNotChecking)
            //{
            //    sSql += " AND TimeIn Is Null";
            //}

            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;

            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptHRAttendSummary oItem = new rptHRAttendSummary();
                    oItem.EmployeeCode = (string)reader["EmployeeCode"];
                    oItem.EmployeeName = (string)reader["EmployeeName"];
                    oItem.Designation = (string)reader["DesignationName"];
                    //oItem.Company = (string)reader["CompanyName"];
                    oItem.One = Convert.ToDouble(reader["One"]);
                    oItem.Two = Convert.ToDouble(reader["Two"]);
                    oItem.Three = Convert.ToDouble(reader["Three"]);
                    oItem.Four = Convert.ToDouble(reader["Four"]);
                    oItem.Five = Convert.ToDouble(reader["Five"]);
                    oItem.Six = Convert.ToDouble(reader["Six"]);
                    oItem.Seven = Convert.ToDouble(reader["Seven"]);
                    oItem.Eight = Convert.ToDouble(reader["Eight"]);
                    oItem.Nine = Convert.ToDouble(reader["Nine"]);
                    oItem.Ten = Convert.ToDouble(reader["Ten"]);
                    oItem.Eleven = Convert.ToDouble(reader["Eleven"]);
                    oItem.Twelve = Convert.ToDouble(reader["Twelve"]);
                    oItem.Thirteen = Convert.ToDouble(reader["Thirteen"]);
                    oItem.Forteen = Convert.ToDouble(reader["Forteen"]);
                    oItem.Fifteen = Convert.ToDouble(reader["Fifteen"]);
                    oItem.Sixteen = Convert.ToDouble(reader["Sixteen"]);
                    oItem.Seventeen = Convert.ToDouble(reader["Seventeen"]);
                    oItem.Eighteen = Convert.ToDouble(reader["Eighteen"]);
                    oItem.Nineteen = Convert.ToDouble(reader["Nineteen"]);
                    oItem.Twenty = Convert.ToDouble(reader["Twenty"]);
                    oItem.TwentyOne = Convert.ToDouble(reader["TwentyOne"]);
                    oItem.TwentyTwo = Convert.ToDouble(reader["TwentyTwo"]);
                    oItem.TwentyThree = Convert.ToDouble(reader["TwentyThree"]);
                    oItem.TwentyFour = Convert.ToDouble(reader["TwentyFour"]);
                    oItem.TwentyFive = Convert.ToDouble(reader["TwentyFive"]);
                    oItem.TwentySix = Convert.ToDouble(reader["TwentySix"]);
                    oItem.TwentySeven = Convert.ToDouble(reader["TwentySeven"]);
                    oItem.TwentyEight = Convert.ToDouble(reader["TwentyEight"]);
                    oItem.TwentyNine = Convert.ToDouble(reader["TwentyNine"]);
                    oItem.Thirty = Convert.ToDouble(reader["Thirty"]);
                    oItem.ThirtyOne = Convert.ToDouble(reader["ThirtyOne"]);

                    oItem.TotalHour = Convert.ToDouble(reader["TotalHour"]);
                    oItem.OverTime = Convert.ToDouble(reader["OverTime"]);
                    oItem.OverTimeHourly = Convert.ToDouble(reader["OverTimeHourly"]);
                    oItem.OverTimeAmount = Convert.ToDouble(reader["OverTimeAmount"]);
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
    }
}
