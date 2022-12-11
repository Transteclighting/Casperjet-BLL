// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Apr 11, 2016
// Time : 12:21 PM
// Description: Class for HROverTimeDetail.
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
    public class HROverTimeDetail
    {
        private int _nOverTimeDetailID;
        private int _nOverTimeID;
        private string _sDescription;
        private DateTime _dDate;
        private DateTime _dFromTime;
        private DateTime _dToTime;
        private int _LessMinutes;
        //private DateTime _TotalHour;
        private int _TotalMinutes;
        private int _nStatus;
        private string _sDay;
        private double _LessHoure;
        private double _TotalHoure;
        private string _sSection;
        public string Section
        {
            get { return _sSection; }
            set { _sSection = value; }
        }

        // <summary>
        // Get set property for LessHoure
        // </summary>
        public double LessHoure
        {
            get { return _LessHoure; }
            set { _LessHoure = value; }
        }
        // <summary>
        // Get set property for TotalHoure
        // </summary>
        public double TotalHoure
        {
            get { return _TotalHoure; }
            set { _TotalHoure = value; }
        }

        // <summary>
        // Get set property for _sDay
        // </summary>
        public string Day
        {
            get { return _sDay; }
            set { _sDay = value.Trim(); }
        }

        // <summary>
        // Get set property for Date
        // </summary>
        public DateTime Date
        {
            get { return _dDate; }
            set { _dDate = value; }
        }

        // <summary>
        // Get set property for OverTimeDetailID
        // </summary>
        public int OverTimeDetailID
        {
            get { return _nOverTimeDetailID; }
            set { _nOverTimeDetailID = value; }
        }

        // <summary>
        // Get set property for OverTimeID
        // </summary>
        public int OverTimeID
        {
            get { return _nOverTimeID; }
            set { _nOverTimeID = value; }
        }

        // <summary>
        // Get set property for Description
        // </summary>
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value.Trim(); }
        }

        // <summary>
        // Get set property for FromTime
        // </summary>
        public DateTime FromTime
        {
            get { return _dFromTime; }
            set { _dFromTime = value; }
        }

        // <summary>
        // Get set property for ToTime
        // </summary>
        public DateTime ToTime
        {
            get { return _dToTime; }
            set { _dToTime = value; }
        }

        // <summary>
        // Get set property for LessHour
        // </summary>
        public int LessMinutes
        {
            get { return _LessMinutes; }
            set { _LessMinutes = value; }
        }

        //// <summary>
        //// Get set property for TotalHour
        //// </summary>
        //public DateTime TotalHour
        //{
        //    get { return _TotalHour; }
        //    set { _TotalHour = value; }
        //}

        // <summary>
        // Get set property for Status
        // </summary>


        // <summary>
        // Get set property for TotalHour
        // </summary>
        public int TotalMinutes
        {
            get { return _TotalMinutes; }
            set { _TotalMinutes = value; }
        }
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        public void Add()
        {
            int nMaxOverTimeDetailID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([OverTimeDetailID]) FROM t_HROverTimeDetail";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxOverTimeDetailID = 1;
                }
                else
                {
                    nMaxOverTimeDetailID = Convert.ToInt32(maxID) + 1;
                }
                _nOverTimeDetailID = nMaxOverTimeDetailID;
                sSql = "INSERT INTO t_HROverTimeDetail (OverTimeDetailID, OverTimeID, Description, Date, FromTime, ToTime, LessMinutes, TotalMinutes, Status, Section) VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OverTimeDetailID", _nOverTimeDetailID);
                cmd.Parameters.AddWithValue("OverTimeID", _nOverTimeID);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("Date", _dDate);
                cmd.Parameters.AddWithValue("FromTime", _dFromTime);
                cmd.Parameters.AddWithValue("ToTime", _dToTime);
                cmd.Parameters.AddWithValue("LessMinutes", _LessMinutes);
                cmd.Parameters.AddWithValue("TotalMinutes", _TotalMinutes);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Section", _sSection);

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
                sSql = "UPDATE t_HROverTimeDetail SET OverTimeID = ?, Description = ?, FromTime = ?, ToTime = ?, LessMinutes = ?, TotalMinutes = ?, Status = ? WHERE OverTimeDetailID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OverTimeID", _nOverTimeID);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("FromTime", _dFromTime);
                cmd.Parameters.AddWithValue("ToTime", _dToTime);
                cmd.Parameters.AddWithValue("LessMinutes", _LessMinutes);
                cmd.Parameters.AddWithValue("TotalMinutes", _TotalMinutes);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("OverTimeDetailID", _nOverTimeDetailID);

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
                sSql = "UPDATE t_HROverTimeDetail SET Status = ? WHERE OverTimeID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;



                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("OverTimeID", _nOverTimeID);

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
                sSql = "DELETE FROM t_HROverTimeDetail WHERE [OverTimeID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OverTimeID", _nOverTimeID);
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
                cmd.CommandText = "SELECT * FROM t_HROverTimeDetail where OverTimeDetailID =?";
                cmd.Parameters.AddWithValue("OverTimeDetailID", _nOverTimeDetailID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nOverTimeDetailID = (int)reader["OverTimeDetailID"];
                    _nOverTimeID = (int)reader["OverTimeID"];
                    _sDescription = (string)reader["Description"];
                    _dDate = Convert.ToDateTime(reader["Date"].ToString());
                    _dFromTime = Convert.ToDateTime(reader["FromTime"].ToString());
                    _dToTime = Convert.ToDateTime(reader["ToTime"].ToString());
                    //_LessHour = Convert.ToDateTime(reader["LessHour"].ToString());
                    //_TotalHour = Convert.ToDateTime(reader["TotalHour"].ToString());
                    _LessMinutes = (int)reader["LessMinutes"];
                    _TotalMinutes = (int)reader["TotalMinutes"];
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
    }
    public class HROverTime : CollectionBase
    {
        public HROverTimeDetail this[int i]
        {
            get { return (HROverTimeDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HROverTimeDetail oHROverTimeDetail)
        {
            InnerList.Add(oHROverTimeDetail);
        }
        private int _nOverTimeID;
        private int _nBillID;
        private string _sCode;
        private int _nEmployeeID;
        private int _nMonth;
        private int _nYear;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private DateTime _dDate;
        private string _sDay;
        private string _sEmployeeName;
        private string _sMonthName;
        private string _sLessHour;

        private string _sTotalHour;

        private int _nStatus;
        private string _sStatusName;
        private string _sDepartmentName;

        private double _GTotalLessHour;
        private double _GTotalHour;

        private string _sCompanyName;
        private double _Amount;
        private int _nDepartmentID;
        private int _nCompanyID;
        private double _NetHour;

        private double _sHour;
        // <summary>
        // Get set property for _sHour
        // </summary>
        public double Hour
        {
            get { return _sHour; }
            set { _sHour = value; }
        }
        private double _sGNetHour;
        // <summary>
        // Get set property for GNetHour
        // </summary>
        public double GNetHour
        {
            get { return _sGNetHour; }
            set { _sGNetHour = value; }
        }
        private double _sGLessHour;
        // <summary>
        // Get set property for GLessHour
        // </summary>
        public double GLessHour
        {
            get { return _sGLessHour; }
            set { _sGLessHour = value; }
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
        // Get set property for Amount
        // </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }


        // <summary>
        // Get set property for CompanyName
        // </summary>
        public string CompanyName
        {
            get { return _sCompanyName; }
            set { _sCompanyName = value.Trim(); }
        }
        private string _sCompnayCode;
        public string CompanyCode
        {
            get { return _sCompnayCode; }
            set { _sCompnayCode = value; }
        }

        // <summary>
        // Get set property for GTotalLessHour
        // </summary>
        public double GTotalLessHour
        {
            get { return _GTotalLessHour; }
            set { _GTotalLessHour = value; }
        }
        // <summary>
        // Get set property for GTotalHour
        // </summary>
        public double GTotalHour
        {
            get { return _GTotalHour; }
            set { _GTotalHour = value; }
        }


        // <summary>
        // Get set property for BillID
        // </summary>
        public int BillID
        {
            get { return _nBillID; }
            set { _nBillID = value; }
        }



        // <summary>
        // Get set property for DepartmentName
        // </summary>
        public string DepartmentName
        {
            get { return _sDepartmentName; }
            set { _sDepartmentName = value.Trim(); }
        }

        // <summary>
        // Get set property for StatusName
        // </summary>
        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value.Trim(); }
        }


        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        //// <summary>
        //// Get set property for LessHour
        //// </summary>
        public string LessHour
        {
            get { return _sLessHour; }
            set { _sLessHour = value.Trim(); }
        }

        //// <summary>
        //// Get set property for TotalHour
        //// </summary>
        public string TotalHour
        {
            get { return _sTotalHour; }
            set { _sTotalHour = value.Trim(); }
        }


        // <summary>
        // Get set property for NetHour
        // </summary>
        public double NetHour
        {
            get { return _NetHour; }
            set { _NetHour = value; }
        }


        // <summary>
        // Get set property for EmployeeName
        // </summary>
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value.Trim(); }
        }

        // <summary>
        // Get set property for MonthName
        // </summary>
        public string MonthName
        {
            get { return _sMonthName; }
            set { _sMonthName = value.Trim(); }
        }


        // <summary>
        // Get set property for OverTimeID
        // </summary>
        public int OverTimeID
        {
            get { return _nOverTimeID; }
            set { _nOverTimeID = value; }
        }

        // <summary>
        // Get set property for Code
        // </summary>
        public string Code
        {
            get { return _sCode; }
            set { _sCode = value.Trim(); }
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
        // Get set property for Month
        // </summary>
        public int Month
        {
            get { return _nMonth; }
            set { _nMonth = value; }
        }

        // <summary>
        // Get set property for Year
        // </summary>
        public int Year
        {
            get { return _nYear; }
            set { _nYear = value; }
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

        // <summary>
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
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
        // Get set property for Date
        // </summary>
        public DateTime Date
        {
            get { return _dDate; }
            set { _dDate = value; }
        }
        // <summary>
        // Get set property for Code
        // </summary>
        public string Day
        {
            get { return _sDay; }
            set { _sDay = value.Trim(); }
        }


        public void Add()
        {
            int nMaxOverTimeID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([OverTimeID]) FROM t_HROverTime";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxOverTimeID = 1;
                }
                else
                {
                    nMaxOverTimeID = Convert.ToInt32(maxID) + 1;
                }
                _nOverTimeID = nMaxOverTimeID;


                string sCode = "";
                DateTime dToday = DateTime.Today;
                sCode = "OT" + "-" + dToday.ToString("yy") + _nOverTimeID.ToString("000");
                _sCode = sCode;



                sSql = "INSERT INTO t_HROverTime (OverTimeID, Code, EmployeeID, Month, Year, Amount, CreateUserID, CreateDate, UpdateUserID, UpdateDate, Status, CompanyID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OverTimeID", _nOverTimeID);
                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("Month", _nMonth);
                cmd.Parameters.AddWithValue("Year", _nYear);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                foreach (HROverTimeDetail oItem in this)
                {
                    oItem.OverTimeID = _nOverTimeID;
                    oItem.Add();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Edit(int nID,int nType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_HROverTime SET Amount = ?, Status = ?, UpdateUserID = ?, UpdateDate = ?, ApprovedBy = ?,ApprovedDate = ? WHERE OverTimeID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                //cmd.Parameters.AddWithValue("Code", _sCode);
                //cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                //cmd.Parameters.AddWithValue("Month", _nMonth);
                //cmd.Parameters.AddWithValue("Year", _nYear);
                //cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                if (nType == (int)Dictionary.HROverTimeStatus.Create)
                {
                    cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                    cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("ApprovedBy", null);
                    cmd.Parameters.AddWithValue("ApprovedDate", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("UpdateUserID", null);
                    cmd.Parameters.AddWithValue("UpdateDate", null);
                    cmd.Parameters.AddWithValue("ApprovedBy", Utility.UserId);
                    cmd.Parameters.AddWithValue("ApprovedDate", DateTime.Now.Date);
                }

                cmd.Parameters.AddWithValue("OverTimeID", nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                HROverTimeDetail oItems = new HROverTimeDetail();
                oItems.OverTimeID = nID;
                oItems.Delete();

                foreach (HROverTimeDetail oItem in this)
                {
                    oItem.OverTimeID = nID;
                    oItem.Add();
                }


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateStatus(int nID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_HROverTime SET Status = ?, ApprovedBy = ?, ApprovedDate = ? WHERE OverTimeID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApprovedBy", Utility.UserId);
                cmd.Parameters.AddWithValue("ApprovedDate", DateTime.Now.Date);

                cmd.Parameters.AddWithValue("OverTimeID", nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                HROverTimeDetail oItems = new HROverTimeDetail();
                oItems.OverTimeID = nID;
                oItems.Status = _nStatus;

                oItems.UpdateStatus();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddBilling()
        {
            int nMaxBillID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([BillID]) FROM t_HROverTimeBilling";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxBillID = 1;
                }
                else
                {
                    nMaxBillID = Convert.ToInt32(maxID) + 1;
                }
                _nBillID = nMaxBillID;
                sSql = "INSERT INTO t_HROverTimeBilling (BillID, OverTimeID, CreateDate, CreateUserID, Status, PayMonth) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BillID", _nBillID);
                cmd.Parameters.AddWithValue("OverTimeID", _nOverTimeID);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.HROverTimeStatus.Approved);
                cmd.Parameters.AddWithValue("PayMonth", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void Delete(int nID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                HROverTimeDetail oItems = new HROverTimeDetail();
                oItems.OverTimeID = nID;
                oItems.Delete();

                cmd = DBController.Instance.GetCommand();
                sSql = "DELETE FROM t_HROverTime WHERE [OverTimeID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OverTimeID", nID);
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
                cmd.CommandText = "SELECT * FROM t_HROverTime where OverTimeID =?";
                cmd.Parameters.AddWithValue("OverTimeID", _nOverTimeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nOverTimeID = (int)reader["OverTimeID"];
                    _sCode = (string)reader["Code"];
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _nMonth = (int)reader["Month"];
                    _nYear = (int)reader["Year"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
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

        public void GetGTotal(int nOverTimeID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select  CONVERT(NUMERIC(18, 2), LessMinutes / 60 + (LessMinutes % 60) / 100.0) as GLessHour, " +
                                " CONVERT(NUMERIC(18, 2), TotalMinutes / 60 + (TotalMinutes % 60) / 100.0) as GTotalHour from  " +
                                " (Select sum(LessMinutes) LessMinutes,sum(TotalMinutes) TotalMinutes " +
                                " from t_HROvertimeDetail where OverTimeID = ?) x";

                cmd.Parameters.AddWithValue("OverTimeID", nOverTimeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _GTotalLessHour = Convert.ToDouble(reader["GLessHour"].ToString());
                    _GTotalHour = Convert.ToDouble(reader["GTotalHour"].ToString());

                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetTotalForReport(int nMonth, int nYear, int nStatus, int nDepartmentID, int nCompanyID, int nEmployeeID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                string sSql = "";
                {
                    sSql = " Select  " +
                           " isnull(CONVERT(NUMERIC(18, 2), sum(TotalMinutes) / 60 + (sum(TotalMinutes) % 60) / 100.0),0) as TotalHour,  " +
                           " isnull(CONVERT(NUMERIC(18, 2), sum(LessMinutes) / 60 + (sum(LessMinutes) % 60) / 100.0),0) as LessHour,  " +
                           " isnull(CONVERT(NUMERIC(18, 2), sum(NetMinutes) / 60 + (sum(NetMinutes) % 60) / 100.0),0) as NetHour " +
                           " From   " +
                           " (Select a.EmployeeID,'['+EmployeeCode +']' + EmployeeName as EmployeeName,   " +
                           " DepartmentID,DepartmentName,c.CompanyID,CompanyName,Month,Year,a.Status,  " +
                           " (TotalMinutes+LessMinutes) as TotalMinutes,LessMinutes,TotalMinutes as NetMinutes,  " +
                           " isnull(Amount,0) Amount     " +
                           " From t_HROverTime a,t_HROverTimeDetail b,v_EmployeeDetails c  " +
                           " where a.OverTimeID=b.OverTimeID and a.EmployeeID=c.EmployeeID) x  " +
                           " where Year=" + nYear + " and Month=" + nMonth + "";

                }

                if (nStatus != -1)
                {
                    sSql = sSql + " AND Status=" + nStatus + "";
                }
                if (nDepartmentID != 0)
                {
                    sSql = sSql + " AND DepartmentID=" + nDepartmentID + "";
                }
                else 
                {
                    sSql = sSql + " AND DepartmentID in (Select DataID From t_UserPermissionData where DataType='Department' and userID=" + Utility.UserId + ")";
                }
                if (nCompanyID != 0)
                {
                    sSql = sSql + " AND CompanyID=" + nCompanyID + "";
                }
                //if (sEmployeeName != "")
                //{
                //    sSql = sSql + " AND EmployeeName like '%" + sEmployeeName + "%'";
                //}
                if (nEmployeeID != -1)
                {
                    sSql = sSql + " AND EmployeeID=" + nEmployeeID + "";
                }

                cmd.CommandText = sSql;
                
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sHour = Convert.ToDouble(reader["TotalHour"].ToString());
                    _sGLessHour = Convert.ToDouble(reader["LessHour"].ToString());
                    _sGNetHour = Convert.ToDouble(reader["NetHour"].ToString());

                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public double GetHour(int nMin)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double _Hour = 0;

            try
            {
                cmd.CommandText = " Select CONVERT(NUMERIC(18, 2), " + nMin + " / 60 + (" + nMin + " % 60) / 100.0) as Hour ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _Hour = Convert.ToDouble(reader["Hour"].ToString());

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Hour;
        }

        public double GetOverTimeAmount(int nEmployeeID, int nMonth, int nYear)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double _Amount = 0;

            try
            {
                cmd.CommandText = " Select Sum(Amount) as Amount from dbo.t_HROverTime Where EmployeeID=" + nEmployeeID + " and Month = " + nMonth + " and Year=" + nYear + " and Status = " + (int)Dictionary.HROverTimeStatus.Approved + " ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Amount"] != DBNull.Value)
                    {
                        _Amount = Convert.ToDouble(reader["Amount"]);
                    }

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Amount;
        }

        public double GetOverTimeMonthlyHour(int nCompanyID, int IsFactory, int nEmployeeStatus)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double _result = 0;

            try
            {
                cmd.CommandText = "Select MonthlyOTHour from dbo.t_HROverTimeMonthlyHour Where CompanyID = " + nCompanyID + " and IsFactory = " + IsFactory + " and EmployeeStatus = " + nEmployeeStatus + " ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["MonthlyOTHour"] != DBNull.Value)
                    {
                        _result = Convert.ToDouble(reader["MonthlyOTHour"]);
                    }

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _result;
        }


        public void RefreshOverTime(int nOverTimeID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {


                cmd.CommandText = " Select OverTimeID,Code,a.EmployeeID,'['+EmployeeCode +']' + EmployeeName as EmployeeName,  " +
                                  " DepartmentName,Month,Year,isnull(Amount,0) Amount,CreateUserID,CreateDate,Status,  " +
                                  " StatusName=CASE When Status=1 then 'Create' When Status=2 then 'Approved'     " +
                                  " else 'Others' end From t_HROverTime a,v_EmployeeDetails b where a.EmployeeID=b.EmployeeID  " +
                                  " and OverTimeID = ? ";


                cmd.Parameters.AddWithValue("OverTimeID", nOverTimeID);


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nOverTimeID = (int)reader["OverTimeID"];
                    _sCode = (string)reader["Code"];
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _sEmployeeName = (string)reader["EmployeeName"];
                    _sDepartmentName = (string)reader["DepartmentName"];
                    _sStatusName = (string)reader["StatusName"];
                    _nMonth = (int)reader["Month"];
                    _nYear = (int)reader["Year"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nStatus = (int)reader["Status"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _sStatusName = (string)reader["StatusName"];

                }

                GetOverTimeItem(_nOverTimeID);


                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetOverTimeItem(int nOverTimeID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {

                cmd.CommandText = "Select *, DATENAME(dw,Date) as Day,  " +
                                " CONVERT(NUMERIC(18, 2), LessMinutes / 60 + (LessMinutes % 60) / 100.0) as LessHoure,  " +
                                " CONVERT(NUMERIC(18, 2), TotalMinutes / 60 + (TotalMinutes % 60) / 100.0) as TotalHoure,isnull(Section,'Common') Section   " +
                                " from t_HROvertimeDetail where OverTimeID = ?";

                cmd.Parameters.AddWithValue("OverTimeID", nOverTimeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HROverTimeDetail oItem = new HROverTimeDetail();

                    oItem.OverTimeDetailID = int.Parse(reader["OverTimeDetailID"].ToString());
                    oItem.OverTimeID = int.Parse(reader["OverTimeID"].ToString());
                    oItem.Description = (reader["Description"].ToString());
                    oItem.Date = Convert.ToDateTime(reader["Date"].ToString());
                    oItem.FromTime = Convert.ToDateTime(reader["FromTime"].ToString());
                    oItem.ToTime = Convert.ToDateTime(reader["ToTime"].ToString());
                    oItem.LessMinutes = int.Parse(reader["LessMinutes"].ToString());
                    oItem.TotalMinutes = int.Parse(reader["TotalMinutes"].ToString());
                    oItem.LessHoure = Convert.ToDouble(reader["LessHoure"].ToString());
                    oItem.TotalHoure = Convert.ToDouble(reader["TotalHoure"].ToString());
                    oItem.Day = (reader["Day"].ToString());
                    oItem.Section = (reader["Section"].ToString());
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

        public int GetOverTime(int nMonth, int nYear, int nEmployeeID)
        {
            int nTotalMinuts = 0;
           
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {

                cmd.CommandText = " SELECT Sum(b.TotalMinutes) as TotalMinuts " +
                                  " FROM TELSysDB.dbo.t_HROverTime a, TELSysDB.dbo.t_HROverTimeDetail b  " +
                                  " WHERE a.OverTimeID = b.OverTimeID AND a.status=" + (int)Dictionary.HROverTimeStatus.Approved + " " +
                                  " AND Month=" + nMonth + " and Year=" + nYear + " and a.EmployeeID=" + nEmployeeID + " ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["TotalMinuts"] != DBNull.Value)
                    {
                        nTotalMinuts = Convert.ToInt32(reader["TotalMinuts"].ToString());
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nTotalMinuts;
        }
    }
    public class HROverTimes : CollectionBase
    {
        public HROverTime this[int i]
        {
            get { return (HROverTime)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HROverTime oHROverTime)
        {
            InnerList.Add(oHROverTime);
        }
        public int GetIndex(int nOverTimeID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].OverTimeID == nOverTimeID)
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
            string sSql = "SELECT * FROM t_HROverTime";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HROverTime oHROverTime = new HROverTime();
                    oHROverTime.OverTimeID = (int)reader["OverTimeID"];
                    oHROverTime.Code = (string)reader["Code"];
                    oHROverTime.EmployeeID = (int)reader["EmployeeID"];
                    oHROverTime.Month = (int)reader["Month"];
                    oHROverTime.Year = (int)reader["Year"];
                    oHROverTime.CreateUserID = (int)reader["CreateUserID"];
                    oHROverTime.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oHROverTime.UpdateUserID = (int)reader["UpdateUserID"];
                    oHROverTime.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    InnerList.Add(oHROverTime);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetDate(DateTime dtCDate, int nEmployeeID)
        {

            DateTime LastMonth = dtCDate.AddMonths(-1);

            DateTime dtFromDate;
            DateTime dtToDate;

            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
            string sMonthName = mfi.GetMonthName(dtCDate.Month).ToString();
            string sLastMonth = mfi.GetMonthName(LastMonth.Month).ToString();

            string sFromDate = "16-" + sLastMonth + "-" + LastMonth.Year + "";
            //dtFromDate = Convert.ToDateTime(sFromDate).Date;
            string sToDate = "15-" + sMonthName + "-" + dtCDate.Year + "";
            //dtToDate = Convert.ToDateTime(sToDate).Date;

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " Select Date,datename(dw,Date) as Day From (SELECT [Date] = DATEADD(Day,Number,'" + sFromDate + "')  " +
                          " FROM  master..spt_values WHERE Type='P'  " +
                          " AND DATEADD(day,Number,'" + sFromDate + "') <= '" + sToDate + "') Main " +
                          " where Date not in (Select Date From t_HROverTimeDetail a,t_HROverTime b " +
                          " where a.OverTimeID=b.OverTimeID and Month=" + dtCDate.Month + " and Year=" + dtCDate.Year + " and EmployeeID=" + nEmployeeID + ")  order by Date";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HROverTime oHROverTime = new HROverTime();
                    oHROverTime.Date = Convert.ToDateTime(reader["Date"].ToString());
                    oHROverTime.Day = Convert.ToString(reader["Day"]);
                    InnerList.Add(oHROverTime);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh(int nMonth, int nYear, int nEmployeeID, string sCode, int nStatus,int nCompanyID, int nDepartmentID,bool isFactoryEmployee)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";
            {
                //sSql = "Select * From  " +
                //       " (Select OverTimeID,Code,EmployeeID,EmployeeName,CompanyID,CompanyCode,CompanyName,DepartmentID,DepartmentName,IsFactoryEmployee,  " +
                //       " Month,MonthName,Year,  cast(LessMinutes/60 as varchar(5)) + ':' + RIGHT('0' + cast(LessMinutes%60 as varchar(2)), 2) as LessHour,    " +
                //       " cast(TotalMinutes/60 as varchar(5)) + ':' + RIGHT('0' + cast(TotalMinutes%60 as varchar(2)), 2) as TotalHour,    " +
                //       " Status,CreateDate,Amount From (Select a.OverTimeID,Code,  " +
                //       " a.EmployeeID,'[' + EmployeeCode +']'+ EmployeeName as EmployeeName,      " +
                //       " c.CompanyID,CompanyCode,CompanyName,DepartmentID,DepartmentName,IsFactoryEmployee,Month,DateName( month , DateAdd( month , Month , -1 )) as MonthName,  " +
                //       " Year,a.Status,sum(LessMinutes) as LessMinutes,sum(TotalMinutes) as TotalMinutes,a.CreateDate,   " +
                //       " isnull(Amount,0) as Amount    " +
                //       " from t_HROvertime a,t_HROvertimeDetail b,v_EmployeeDetails c     " +
                //       " where a.OverTimeID=b.OverTimeID and a.EmployeeID=c.EmployeeID     " +
                //       " group by a.OverTimeID,Code,a.EmployeeID,EmployeeCode,EmployeeName,c.CompanyID,CompanyCode,CompanyName,DepartmentID,DepartmentName,IsFactoryEmployee,     " +
                //       " a.Status,Month,Year,CreateDate,Amount) b   " +
                //       " inner join t_UserPermissionData c on c.DataID=b.DepartmentID and c.UserID= " + Utility.UserId + "  " +
                //       " and c.DataType='Department'  " +
                //       " inner join t_UserPermissionData d on d.DataID=b.CompanyID and d.UserID= " + Utility.UserId + "  and d.DataType='Company' ) Main where 1=1"; 


                sSql = @"Select * From  
                        (Select OverTimeID,Code,EmployeeID,EmployeeName,CompanyID,CompanyCode,CompanyName,DepartmentID,DepartmentName,IsFactoryEmployee,  
                        Month,MonthName,Year,  cast(LessMinutes/60 as varchar(5)) + ':' + RIGHT('0' + cast(LessMinutes%60 as varchar(2)), 2) as LessHour,    
                        cast(TotalMinutes/60 as varchar(5)) + ':' + RIGHT('0' + cast(TotalMinutes%60 as varchar(2)), 2) as TotalHour,    
                        Status,CreateDate,Amount From (Select a.OverTimeID,Code,  
                        a.EmployeeID,'[' + EmployeeCode +']'+ EmployeeName as EmployeeName,      
                        c.CompanyID,CompanyCode,CompanyName,DepartmentID,DepartmentName,IsFactoryEmployee,Month,DateName( month , DateAdd( month , Month , -1 )) as MonthName,  
                        Year,a.Status,sum(LessMinutes) as LessMinutes,sum(TotalMinutes) as TotalMinutes,a.CreateDate,   
                        isnull(Amount,0) as Amount    
                        from t_HROvertime a,t_HROvertimeDetail b,(Select EmployeeID,EmployeeCode,EmployeeName,a.CompanyID,CompanyCode,CompanyName,
                        a.DepartmentID,DepartmentName,
                        IsFactoryEmployee From  t_Employee a,t_Department b,t_Company c
                        where a.DepartmentID=b.DepartmentID and a.CompanyID=c.CompanyID) c     
                        where a.OverTimeID=b.OverTimeID and a.EmployeeID=c.EmployeeID     
                        group by a.OverTimeID,Code,a.EmployeeID,EmployeeCode,EmployeeName,c.CompanyID,CompanyCode,CompanyName,DepartmentID,DepartmentName,IsFactoryEmployee,     
                        a.Status,Month,Year,CreateDate,Amount) b   
                        inner join t_UserPermissionData c on c.DataID=b.DepartmentID and c.UserID=  " + Utility.UserId + @" 
                        and c.DataType='Department'  
                        inner join t_UserPermissionData d on d.DataID=b.CompanyID and d.UserID=  " + Utility.UserId + @"   and d.DataType='Company' ) Main where 1=1";

            }

            if (nMonth != -1)
            {
                sSql += " AND Month=" + nMonth + "";
            }
            if (nYear != -1)
            {
                sSql += " AND Year=" + nYear + "";
            }

            if (nEmployeeID != -1)
            {
                sSql += " AND EmployeeID=" + nEmployeeID + "";
            }

            if (sCode != "")
            {
                sSql += " AND Code like '%" + sCode + "%'";
            }
            if (nStatus != -1)
            {
                sSql += " AND Status=" + nStatus + "";
            }
            if (nDepartmentID != 0)
            {
                sSql += " AND DepartmentID=" + nDepartmentID + "";
            }
            //else
            //{
            //    sSql += " AND DepartmentID in (Select DataID From t_UserPermissionData where DataType='Department' and userID=" + Utility.UserId + ")";
            //}
            if (nCompanyID != 0)
            {
                sSql += " AND CompanyID=" + nCompanyID + "";
            }
            //else
            //{
            //    sSql += " AND CompanyID in (Select DataID From t_UserPermissionData where DataType='Company' and userID=" + Utility.UserId + ")";
            //}
            if (isFactoryEmployee)
            {
                sSql += " AND IsFactoryEmployee ="+(int) Dictionary.YesNAStatus.Yes;
            }
            sSql +=  " Order by OverTimeID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HROverTime oHROverTime = new HROverTime();
                    oHROverTime.OverTimeID = (int)reader["OverTimeID"];
                    oHROverTime.Code = (string)reader["Code"];
                    oHROverTime.EmployeeID = (int)reader["EmployeeID"];
                    oHROverTime.EmployeeName = (string)reader["EmployeeName"];
                    oHROverTime.Month = (int)reader["Month"];
                    oHROverTime.MonthName = (string)reader["MonthName"];
                    oHROverTime.CompanyID = (int)reader["CompanyID"];
                    oHROverTime.CompanyCode = (string)reader["CompanyCode"];
                    oHROverTime.CompanyName = (string)reader["CompanyName"];
                    oHROverTime.DepartmentID = (int)reader["DepartmentID"];
                    oHROverTime.DepartmentName = (string)reader["DepartmentName"];
                    oHROverTime.Year = (int)reader["Year"];
                    oHROverTime.LessHour = (string)reader["LessHour"];
                    oHROverTime.TotalHour = (string)reader["TotalHour"];
                    //oHROverTime.GLessHour = Convert.ToDouble(reader["LessHour"].ToString());
                    //oHROverTime.GTotalHour = Convert.ToDouble(reader["TotalHour"].ToString());

                    oHROverTime.Status = (int)reader["Status"];
                    oHROverTime.Amount = (double)reader["Amount"];
                    oHROverTime.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oHROverTime);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetSummary(int nMonth, int nYear, int nStatus, int nDepartmentID, int nCompanyID, int nEmployeeID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";
            {
                sSql = " Select * From  " +
                       " (Select x.EmployeeID,EmployeeName,DepartmentID,DepartmentName,CompanyID,CompanyName, " +
                       " x.Month,x.Year,Status,TotalHour,LessHour,NetHour,Amount From  " +
                       " (Select EmployeeID,EmployeeName,DepartmentID,DepartmentName,CompanyID,CompanyName, " +
                       "  Month,Year,Status, " +
                       "  CONVERT(NUMERIC(18, 2), sum(TotalMinutes) / 60 + (sum(TotalMinutes) % 60) / 100.0) as TotalHour, " +
                       "  CONVERT(NUMERIC(18, 2), sum(LessMinutes) / 60 + (sum(LessMinutes) % 60) / 100.0) as LessHour, " +
                       "  CONVERT(NUMERIC(18, 2), sum(NetMinutes) / 60 + (sum(NetMinutes) % 60) / 100.0) as NetHour " +
                       "  From  " +
                       "  (Select a.EmployeeID,'['+EmployeeCode +']' + EmployeeName as EmployeeName,  " +
                       "  DepartmentID,DepartmentName,c.CompanyID,CompanyName,Month,Year,a.Status, " +
                       "  (TotalMinutes+LessMinutes) as TotalMinutes,LessMinutes,TotalMinutes as NetMinutes  " +
                       "  From t_HROverTime a,t_HROverTimeDetail b,v_EmployeeDetails c " +
                       "  where a.OverTimeID=b.OverTimeID and a.EmployeeID=c.EmployeeID) as x " +
                       "  group by EmployeeID,EmployeeName,DepartmentID,DepartmentName,CompanyID,CompanyName, " +
                       "  Month,Year,Status ) x " +
                       "  Left Outer Join  " +
                       "  (Select EmployeeID,Year,Month,isnull(sum(Amount),0) Amount from t_HROverTime  " +
                       " group by EmployeeID,Year,Month) y " +
                       " on x.EmployeeID=y.EmployeeID and x.Year=y.Year and x.Month=y.Month " +
                       " ) Main where 1=1 and Month=" + nMonth + " and year=" + nYear + " ";

            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (nDepartmentID != 0)
            {
                sSql = sSql + " AND DepartmentID=" + nDepartmentID + "";
            }
            else
            {
                sSql = sSql + " AND DepartmentID in (Select DataID From t_UserPermissionData where DataType='Department' and userID=" + Utility.UserId + ")";
            }
            if (nCompanyID != 0)
            {
                sSql = sSql + " AND CompanyID=" + nCompanyID + "";
            }
            //if (sEmployeeName != "")
            //{
            //    sSql = sSql + " AND EmployeeName like '%" + sEmployeeName + "%'";
            //}
            if (nEmployeeID != -1)
            {
                sSql = sSql + " AND EmployeeID=" + nEmployeeID + "";
            }
            sSql = sSql + " Order by EmployeeName";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HROverTime oHROverTime = new HROverTime();
                    oHROverTime.EmployeeID = (int)reader["EmployeeID"];
                    oHROverTime.EmployeeName = (string)reader["EmployeeName"];
                    oHROverTime.EmployeeID = (int)reader["EmployeeID"];
                    oHROverTime.DepartmentID = (int)reader["DepartmentID"];
                    oHROverTime.DepartmentName = (string)reader["DepartmentName"];
                    oHROverTime.CompanyID = (int)reader["CompanyID"];
                    oHROverTime.CompanyName = (string)reader["CompanyName"];
                    oHROverTime.Month = (int)reader["Month"];
                    oHROverTime.Year = (int)reader["Year"];
                    oHROverTime.Status = (int)reader["Status"];
                    oHROverTime.GTotalHour = Convert.ToDouble(reader["TotalHour"].ToString());
                    oHROverTime.GTotalLessHour = Convert.ToDouble(reader["LessHour"].ToString());
                    oHROverTime.NetHour = Convert.ToDouble(reader["NetHour"].ToString());
                    oHROverTime.Amount = (double)reader["Amount"];
                    InnerList.Add(oHROverTime);
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