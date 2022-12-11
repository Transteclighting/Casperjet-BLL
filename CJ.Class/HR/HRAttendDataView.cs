using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.HR
{
    public class HRAttendInfo
    {
        private int _nEmployeeID;
        private DateTime _dPunchDate;
        private DateTime _dTimeIn;
        private DateTime _dTimeOut;
        private DateTime _dLate;
        private int _nPunchCount;
        private int _nStatus;
        private int _nA;
        private int _nP;
        private int _nLA;
        private int _nH;
        private int _nL;
        private int _nO;
        private string _sRemarks;
        private string _sEmployeeCode;
        private string _sEmployeeName;
        private string _sCompanyName;
        private string _sDepartmentName;
        private string _sStatusName;
        private string _D1;
        private string _D2;
        private string _D3;
        private string _D4;
        private string _D5;
        private string _D6;
        private string _D7;
        private string _D8;
        private string _D9;
        private string _D10;
        private string _D11;
        private string _D12;
        private string _D13;
        private string _D14;
        private string _D15;
        private string _D16;
        private string _D17;
        private string _D18;
        private string _D19;
        private string _D20;
        private string _D21;
        private string _D22;
        private string _D23;
        private string _D24;
        private string _D25;
        private string _D26;
        private string _D27;
        private string _D28;
        private string _D29;
        private string _D30;
        private string _D31;


        // <summary>
        // Get set property for EmployeeID
        // </summary>
        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }
        public int A
        {
            get { return _nA; }
            set { _nA = value; }
        }
        public int P
        {
            get { return _nP; }
            set { _nP = value; }
        }
        public int L
        {
            get { return _nL; }
            set { _nL = value; }
        }
        public int LA
        {
            get { return _nLA; }
            set { _nLA = value; }
        }
        public int H
        {
            get { return _nH; }
            set { _nH = value; }
        }
        public int O
        {
            get { return _nO; }
            set { _nO = value; }
        }
        // <summary>
        // Get set property for PunchDate
        // </summary>
        public DateTime PunchDate
        {
            get { return _dPunchDate; }
            set { _dPunchDate = value; }
        }

        // <summary>
        // Get set property for TimeIn
        // </summary>
        public DateTime TimeIn
        {
            get { return _dTimeIn; }
            set { _dTimeIn = value; }
        }

        // <summary>
        // Get set property for TimeOut
        // </summary>
        public DateTime TimeOut
        {
            get { return _dTimeOut; }
            set { _dTimeOut = value; }
        }

        // <summary>
        // Get set property for Late
        // </summary>
        public DateTime Late
        {
            get { return _dLate; }
            set { _dLate = value; }
        }

        // <summary>
        // Get set property for PunchCount
        // </summary>
        public int PunchCount
        {
            get { return _nPunchCount; }
            set { _nPunchCount = value; }
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
        public string D1
        {
            get { return _D1; }
            set { _D1 = value.Trim(); }
        }

        public string D2
        {
            get { return _D2; }
            set { _D2 = value.Trim(); }
        }
        public string D3
        {
            get { return _D3; }
            set { _D3 = value.Trim(); }
        }
        public string D4
        {
            get { return _D4; }
            set { _D4 = value.Trim(); }
        }
        public string D5
        {
            get { return _D5; }
            set { _D5 = value.Trim(); }
        }
        public string D6
        {
            get { return _D6; }
            set { _D6 = value.Trim(); }
        }
        public string D7
        {
            get { return _D7; }
            set { _D7 = value.Trim(); }
        }
        public string D8
        {
            get { return _D8; }
            set { _D8 = value.Trim(); }
        }
        public string D9
        {
            get { return _D9; }
            set { _D9 = value.Trim(); }
        }
        public string D10
        {
            get { return _D10; }
            set { _D10 = value.Trim(); }
        }
        public string D11
        {
            get { return _D11; }
            set { _D11 = value.Trim(); }
        }
        public string D12
        {
            get { return _D12; }
            set { _D12 = value.Trim(); }
        }
        public string D13
        {
            get { return _D13; }
            set { _D13 = value.Trim(); }
        }
        public string D14
        {
            get { return _D14; }
            set { _D14 = value.Trim(); }
        }
        public string D15
        {
            get { return _D15; }
            set { _D15 = value.Trim(); }
        }
        public string D16
        {
            get { return _D16; }
            set { _D16 = value.Trim(); }
        }
        public string D17
        {
            get { return _D17; }
            set { _D17 = value.Trim(); }
        }
        public string D18
        {
            get { return _D18; }
            set { _D18 = value.Trim(); }
        }
        public string D19
        {
            get { return _D19; }
            set { _D19 = value.Trim(); }
        }
        public string D20
        {
            get { return _D20; }
            set { _D20 = value.Trim(); }
        }
        public string D21
        {
            get { return _D21; }
            set { _D21 = value.Trim(); }
        }
        public string D22
        {
            get { return _D22; }
            set { _D22 = value.Trim(); }
        }
        public string D23
        {
            get { return _D23; }
            set { _D23 = value.Trim(); }
        }
        public string D24
        {
            get { return _D24; }
            set { _D24 = value.Trim(); }
        }
        public string D25
        {
            get { return _D25; }
            set { _D25 = value.Trim(); }
        }
        public string D26
        {
            get { return _D26; }
            set { _D26 = value.Trim(); }
        }
        public string D27
        {
            get { return _D27; }
            set { _D27 = value.Trim(); }
        }
        public string D28
        {
            get { return _D28; }
            set { _D28 = value.Trim(); }
        }
        public string D29
        {
            get { return _D29; }
            set { _D29 = value.Trim(); }
        }
        public string D30
        {
            get { return _D30; }
            set { _D30 = value.Trim(); }
        }
        public string D31
        {
            get { return _D31; }
            set { _D31 = value.Trim(); }
        }
        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value.Trim(); }
        }
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value.Trim(); }
        }
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value.Trim(); }
        }
        public string CompanyName
        {
            get { return _sCompanyName; }
            set { _sCompanyName = value.Trim(); }
        }
        public string DepartmentName
        {
            get { return _sDepartmentName; }
            set { _sDepartmentName = value.Trim(); }
        }
        public void Add()
        {
            int nMaxEmployeeID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([EmployeeID]) FROM t_HRAttendInfo";
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
                sSql = "INSERT INTO t_HRAttendInfo (EmployeeID, PunchDate, TimeIn, TimeOut, Late, PunchCount, Status, Remarks) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("PunchDate", _dPunchDate);
                cmd.Parameters.AddWithValue("TimeIn", _dTimeIn);
                cmd.Parameters.AddWithValue("TimeOut", _dTimeOut);
                cmd.Parameters.AddWithValue("Late", _dLate);
                cmd.Parameters.AddWithValue("PunchCount", _nPunchCount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
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
                sSql = "UPDATE t_HRAttendInfo SET PunchDate = ?, TimeIn = ?, TimeOut = ?, Late = ?, PunchCount = ?, Status = ?, Remarks = ? WHERE EmployeeID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PunchDate", _dPunchDate);
                cmd.Parameters.AddWithValue("TimeIn", _dTimeIn);
                cmd.Parameters.AddWithValue("TimeOut", _dTimeOut);
                cmd.Parameters.AddWithValue("Late", _dLate);
                cmd.Parameters.AddWithValue("PunchCount", _nPunchCount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);

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
                sSql = "DELETE FROM t_HRAttendInfo WHERE [EmployeeID]=?";
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
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_HRAttendInfo where EmployeeID =?";
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _dPunchDate = Convert.ToDateTime(reader["PunchDate"].ToString());
                    _dTimeIn = Convert.ToDateTime(reader["TimeIn"].ToString());
                    _dTimeOut = Convert.ToDateTime(reader["TimeOut"].ToString());
                    _dLate = Convert.ToDateTime(reader["Late"].ToString());
                    _nPunchCount = (int)reader["PunchCount"];
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

        public int GetNoOfAbsent(string sFromDate,string sTodate,string sEmployeeList)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select count(EmployeeID) as AbsentCount From (  " +
                                  "Select distinct EmployeeID From t_HRAttendInfo where Status = 0 and " +
                                  "PunchDate between '"+ sFromDate + "' and '"+ sTodate + "' and EmployeeID in ("+ sEmployeeList + ")) x";
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount= (int)reader["AbsentCount"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nCount;
        }

        public string GetAttendanceStatus(int nStatus)
        {
            string _sStatus = "";
            if (nStatus == 0)
            {
                _sStatus = "A";
            }
            else if (nStatus == 1)
            {
                _sStatus = "P";
            }
            else if(nStatus == 2)
            {
                _sStatus = "P";
            }
            else if(nStatus == 3)
            {
                _sStatus = "H";
            }
            else if(nStatus == 4)
            {
                _sStatus = "L";
            }
            else 
            {
                _sStatus = "O";
            }

            return _sStatus;
        }
    }
    public class HRAttendInfos : CollectionBase
    {
        public HRAttendInfo this[int i]
        {
            get { return (HRAttendInfo)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HRAttendInfo oHRAttendInfo)
        {
            InnerList.Add(oHRAttendInfo);
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
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_HRAttendInfo";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRAttendInfo oHRAttendInfo = new HRAttendInfo();
                    oHRAttendInfo.EmployeeID = (int)reader["EmployeeID"];
                    oHRAttendInfo.PunchDate = Convert.ToDateTime(reader["PunchDate"].ToString());
                    oHRAttendInfo.TimeIn = Convert.ToDateTime(reader["TimeIn"].ToString());
                    oHRAttendInfo.TimeOut = Convert.ToDateTime(reader["TimeOut"].ToString());
                    oHRAttendInfo.Late = Convert.ToDateTime(reader["Late"].ToString());
                    oHRAttendInfo.PunchCount = (int)reader["PunchCount"];
                    oHRAttendInfo.Status = (int)reader["Status"];
                    oHRAttendInfo.Remarks = (string)reader["Remarks"];
                    InnerList.Add(oHRAttendInfo);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetHRAttendInfoReportRevised(DSAttendance oDSAttendance, DateTime _dtFromDate, DateTime _dtTodate, int nCompanyID, int nDepartmentID, int nEmployeeID,bool isFactoryEmployee)
        {
            DSAttendance _oDSAttendance;
            _dtTodate = _dtTodate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                string _sSql = " SELECT a.EmployeeID, EmployeeCode, EmployeeName, sum(CASE When Status = 0 then 1 else 0 end) as 'A', "+
                               " sum(CASE When Status IN(1, 2) then 1 else 0 end) as 'P', sum(CASE When Status = 3 then 1 else 0 end) as 'H', "+
                               " sum(CASE When Status = 4 then 1 else 0 end) as 'L', sum(CASE When Status = 5 then 1 else 0 end) as 'O' " +
                               " FROM t_HRAttendInfo a, t_Employee b Where a.EmployeeID = b.EmployeeID and PunchDate " +
                               " between '" + _dtFromDate + "' and '" + _dtTodate + "' and PunchDate < '" + _dtTodate + "' and b.CompanyID = " + nCompanyID + " and EMPStatus Not In(0,3,4,5,6,7) ";

                if (nDepartmentID != -1)
                {
                    _sSql +=  " and DepartmentID = " + nDepartmentID + " ";
                }
                if (nEmployeeID != -1)
                {
                    _sSql += " and a.EmployeeID = " + nEmployeeID + " ";
                }
                if (isFactoryEmployee)
                {
                    _sSql += " AND IsFactoryEmployee=" + (int)Dictionary.YesNAStatus.Yes;
                }
                _sSql +=  " Group by a.EmployeeID, EmployeeCode, EmployeeName  Order by EmployeeCode";

                cmd.CommandText = _sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRAttendInfo oHRAttendInfo = new HRAttendInfo();

                    oHRAttendInfo.EmployeeID = (int)reader["EmployeeID"];
                    oHRAttendInfo.EmployeeCode = (string)reader["EmployeeCode"];
                    oHRAttendInfo.EmployeeName = (string)reader["EmployeeName"];

                    _oDSAttendance = new DSAttendance();
                    DataRow[] oDR = oDSAttendance.AttendanceRawData.Select(" EmployeeID= '" + oHRAttendInfo.EmployeeID + "' ");
                    _oDSAttendance.Merge(oDR);
                    _oDSAttendance.AcceptChanges();

                    for (int i = 1; i <= 31; i++)
                    {
                        oHRAttendInfo.GetType().GetProperty("D" + i).SetValue(oHRAttendInfo, "--", null);
                    }
                    int nCount = 0;
                    if (oDR.Length != 0)
                    {
                        foreach (DSAttendance.AttendanceRawDataRow oRow in _oDSAttendance.AttendanceRawData)
                        {
                            nCount++;
                            oHRAttendInfo.GetType().GetProperty("D" + nCount).SetValue(oHRAttendInfo, oRow.Status, null);
                        }
                    }
                  

                    oHRAttendInfo.A = (int)reader["A"];
                    oHRAttendInfo.P = (int)reader["P"]; 
                    oHRAttendInfo.H = (int)reader["H"];
                    oHRAttendInfo.L = (int)reader["L"];
                    oHRAttendInfo.O = (int)reader["O"];

                    InnerList.Add(oHRAttendInfo);
                }
            }
            catch
            {
            }
        }

        public DSAttendance GetHRAttendInfoRawData(DateTime _dtFromDate, DateTime _dtTodate, int nCompanyID, int nDepartmentID, int nEmployeeID,bool isFactoryEmployee)
        {
            DSAttendance _oDSAttendance = new DSAttendance();
            HRAttendInfo _oHRAttendInfo = new HRAttendInfo();
            _dtTodate = _dtTodate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                string _sSql = " SELECT a.EmployeeID, PunchDate, day(PunchDate) as PurchDay, Status  " +
                               " FROM t_HRAttendInfo a, t_Employee b Where a.EmployeeID = b.EmployeeID and PunchDate " +
                               " between '" + _dtFromDate + "' and '" + _dtTodate + "' and PunchDate < '" + _dtTodate + "' and b.CompanyID = " + nCompanyID + " and EMPStatus Not In(0,3,4,5,6,7) ";

                if (nDepartmentID != -1)
                {
                    _sSql +=  " and DepartmentID = " + nDepartmentID + " ";
                }
                if (nEmployeeID != -1)
                {
                    _sSql += " and a.EmployeeID = " + nEmployeeID + " ";
                }
                if (isFactoryEmployee)
                {
                    _sSql += " AND IsFactoryEmployee=" +(int) Dictionary.YesNAStatus.Yes;
                }
                _sSql +=  " Order by a.EmployeeID, PunchDate";

                cmd.CommandText = _sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSAttendance.AttendanceRawDataRow oRow = _oDSAttendance.AttendanceRawData.NewAttendanceRawDataRow();
                    oRow.EmployeeID = (int)reader["EmployeeID"];
                    oRow.PunchDate = Convert.ToDateTime(reader["PunchDate"]);
                    oRow.PurchDay = (int)reader["PurchDay"];
                    oRow.Status = _oHRAttendInfo.GetAttendanceStatus((int)reader["Status"]);
                    _oDSAttendance.AttendanceRawData.AddAttendanceRawDataRow(oRow);
                    _oDSAttendance.AcceptChanges();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return _oDSAttendance;
        } 
    }
}

