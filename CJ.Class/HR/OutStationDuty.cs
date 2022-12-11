// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Jan 15, 2012
// Time :  11:00 AM
// Description: Class for Employee Out Station Duty.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;


namespace CJ.Class.HR
{
    public class OutStationDuty
    {
        private int _nDutyID;
        private int _nEmployeeID;
        private string _sAdderss;
        private DateTime _dStartDate;
        private DateTime _dEndDate;
        private string _sRemarks;
        private int _nStatus;


        private Employee _oEmployee;


        /// <summary>
        /// Get set property for Status
        /// </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        /// <summary>
        /// Get set property for DutyID
        /// </summary>
        public int DutyID
        {
            get { return _nDutyID; }
            set { _nDutyID = value; }
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
        /// Get set property for Adderss
        /// </summary>
        public string Adderss
        {
            get { return _sAdderss; }
            set { _sAdderss = value.Trim(); }
        }

        /// <summary>
        /// Get set property for StartDate
        /// </summary>
        public DateTime StartDate
        {
            get { return _dStartDate; }
            set { _dStartDate = value; }
        }

        /// <summary>
        /// Get set property for EndDate
        /// </summary>
        public DateTime EndDate
        {
            get { return _dEndDate; }
            set { _dEndDate = value; }
        }

        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }
        public Employee Employee
        {
            get
            {
                if (_oEmployee == null)
                {
                    _oEmployee = new Employee();
                    _oEmployee.EmployeeID = _nEmployeeID;
                    _oEmployee.Refresh();
                }

                return _oEmployee;
            }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([DutyID]) FROM t_HROutStationDuty";
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
                _nDutyID = nMaxID;

                sSql = "INSERT INTO t_HROutStationDuty (DutyID,EmployeeID,Adderss,StartDate,EndDate,Remarks,Status,CreateDate,CreateUserID,UpdateDate,UpdateUserID,ApprovedUserID,ApprovedDate,System) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DutyID", _nDutyID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("Adderss", _sAdderss);
                cmd.Parameters.AddWithValue("StartDate", _dStartDate);
                cmd.Parameters.AddWithValue("EndDate", _dEndDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("ApprovedUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("ApprovedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("System", "CJ");


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

                sSql = "UPDATE t_HROutStationDuty SET EmployeeID=?,Adderss=?,"
                    + " StartDate=?,EndDate=?,Remarks=?,UpdateDate=?,UpdateUserID=?"
                    + " WHERE DutyID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("Adderss", _sAdderss);
                cmd.Parameters.AddWithValue("StartDate", _dStartDate);
                cmd.Parameters.AddWithValue("EndDate", _dEndDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);


                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);



                cmd.Parameters.AddWithValue("DutyID", _nDutyID);

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
                sSql = "DELETE FROM t_HROutStationDuty WHERE [DutyID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DutyID", _nDutyID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }   

        public bool IsOutStationDuty(DateTime dDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_HROutStationDuty"
                    + " WHERE EmployeeID =? AND StartDate<=? AND EndDate>=?";
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("StartDate", dDate);
                cmd.Parameters.AddWithValue("EndDate", dDate);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sAdderss = (string)reader["Adderss"];

                    nCount++;
                }
                reader.Close();
                return nCount > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class OutStationDuties : CollectionBase
    {
        public OutStationDuty this[int i]
        {
            get { return (OutStationDuty)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(OutStationDuty oOutStationDuty)
        {
            InnerList.Add(oOutStationDuty);
        }

        public int GetIndex(int nDutyID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].DutyID == nDutyID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Refresh(int nEmployeeID, int nCompanyID, int nDepartmentID, string dtStartDateFrom,string dtStartDateTo,string dtEndDateFrom,string dtEndDateTo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_HROutStationDuty a INNER JOIN t_Employee b on a.EmployeeID = b.EmployeeID where 1=1";
           
            if (nEmployeeID != -1)
            {
                sSql += " AND a.EmployeeID = " + nEmployeeID + " ";
            }
            if (nCompanyID != -1)
            {
                sSql += " AND CompanyID = "+nCompanyID+" ";
            }
            if (nDepartmentID != -1)
            {
                sSql += " AND DepartmentID = " + nDepartmentID + " ";
            }
            if (dtStartDateFrom != String.Empty)
            {
                sSql += " AND StartDate >= '" + dtStartDateFrom + "' ";
            }
            if (dtStartDateTo != string.Empty)
            {
                sSql += " AND StartDate <= '" + dtStartDateTo + "' ";
            }


            if (dtEndDateFrom != String.Empty)
            {
                sSql += " AND EndDate >= '" + dtEndDateFrom + "' ";
            }
            if (dtEndDateTo != string.Empty)
            {
                sSql += " AND EndDate <= '" + dtEndDateTo + "' ";
            }



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutStationDuty oOutStationDuty = new OutStationDuty();

                    oOutStationDuty.DutyID = (int)reader["DutyID"];
                    oOutStationDuty.EmployeeID = (int)reader["EmployeeID"];
                    oOutStationDuty.Adderss = (string)reader["Adderss"];
                    oOutStationDuty.StartDate = (DateTime)reader["StartDate"];
                    oOutStationDuty.EndDate = (DateTime)reader["EndDate"];
                    oOutStationDuty.Remarks = reader["Remarks"].ToString();

                    InnerList.Add(oOutStationDuty);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public DSAttendance GetOutstationData(DSAttendance oDSOutstation, DateTime dFromDate, DateTime dToDate)
        {
          
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from (SELECT DutyID, EmployeeID, Convert(datetime,replace(convert(varchar, StartDate,6),'','-'),1)StartDate, " +
                          " Convert(datetime, replace(convert(varchar, EndDate, 6), '', '-'), 1)EndDate " +
                          " FROM t_HROutStationDuty ) a Where StartDate between '"+ dFromDate + "' and '"+ dToDate + "' or EndDate between '" + dFromDate + "' and '" + dToDate + "' ";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSAttendance.HolydayRow oOutstationRow = oDSOutstation.Holyday.NewHolydayRow();

                    oOutstationRow.EmployeeID = (int)reader["EmployeeID"];
                    oOutstationRow.FromDate = (DateTime)reader["StartDate"];
                    oOutstationRow.ToDate = (DateTime)reader["EndDate"];

                    oDSOutstation.Holyday.AddHolydayRow(oOutstationRow);
                    oDSOutstation.AcceptChanges();
                }
                reader.Close();
                
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return oDSOutstation;
        }
    }
}
