// <summary>
// Company: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Oct 16, 2016
// Time : 04:31 PM
// Description: Class for OutletAttendanceInfoDetail.
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
    public class OutletAttendanceInfoDetail
    {
        private int _nID;
        private int _nEmployeeID;
        private object _dTimeIn;
        private object _dTimeOut;
        private string _sRemarks;
        private int _nStatus;
        private string _sEmployeeName;
        private string _sEmployeeCode;
        private DateTime dtAttenDate;
        private string _sStatusName;
        private string _sDesignationName;


        public string DesignationName
        {
            get { return _sDesignationName; }
            set { _sDesignationName = value.Trim(); }
        }

        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value.Trim(); }
        }


        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime AttenDate
        {
            get { return dtAttenDate; }
            set { dtAttenDate = value; }
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


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
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
        // Get set property for EmployeeID
        // </summary>
        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }


        /// <summary>
        /// Get set property for TimeIn
        /// </summary>
        public object TimeIn
        {
            get { return _dTimeIn; }
            set { _dTimeIn = value; }
        }

        /// <summary>
        /// Get set property for TimeOut
        /// </summary>
        public object TimeOut
        {
            get { return _dTimeOut; }
            set { _dTimeOut = value; }
        }


        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        public void Add(DateTime dtDate,int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            string sTime = "" + dtDate.Year + "-" + dtDate.Month + "-" + dtDate.Day + " 09:30:00.000";
            DateTime Time = Convert.ToDateTime(sTime);
            
            try
            {

                sSql = "INSERT INTO t_OutletAttendanceInfoDetail (ID, EmployeeID, TimeIn, TimeOut, Status, Remarks, WarehouseID) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                if (_nStatus == (int)Dictionary.HRAttendanceStatusForOutlet.Present)
                {
                    cmd.Parameters.AddWithValue("TimeIn", _dTimeIn);
                    if (_dTimeOut != DBNull.Value)
                    {
                        cmd.Parameters.AddWithValue("TimeOut", _dTimeOut);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("TimeOut", null);
                    }
                }
                else if (_nStatus == (int)Dictionary.HRAttendanceStatusForOutlet.OutStation)
                {
                    cmd.Parameters.AddWithValue("TimeIn", Time);
                    if (_dTimeOut != DBNull.Value)
                    {
                        cmd.Parameters.AddWithValue("TimeOut", _dTimeOut);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("TimeOut", null);
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("TimeIn", null);
                    cmd.Parameters.AddWithValue("TimeOut", null);
                }
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void CheckOut()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_OutletAttendanceInfoDetail SET TimeOut = ? WHERE ID = ? and EmployeeID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TimeOut", _dTimeOut);

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void CheckOutRT(int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_OutletAttendanceInfoDetail SET TimeOut = ? WHERE ID = ? and EmployeeID = ? and WarehouseID=" + nWarehouseID + "";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TimeOut", _dTimeOut);

                cmd.Parameters.AddWithValue("ID", _nID);
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
                sSql = "DELETE FROM t_OutletAttendanceInfoDetail WHERE [ID]=?";
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
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_OutletAttendanceInfoDetail where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _dTimeIn = Convert.ToDateTime(reader["TimeIn"].ToString());
                    _dTimeOut = Convert.ToDateTime(reader["TimeOut"].ToString());
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
    }
    public class OutletAttendanceInfo : CollectionBase
    {

        public OutletAttendanceInfoDetail this[int i]
        {
            get { return (OutletAttendanceInfoDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(OutletAttendanceInfoDetail oOutletAttendanceInfoDetail)
        {
            InnerList.Add(oOutletAttendanceInfoDetail);
        }

        private int _nID;
        private int _nEmployeeID;
        private int _nWarehouseID;
        private DateTime _dDate;
        private string _sRemarks;
        private int _nStatus;
        private object _dTimeIn;
        private object _dTimeOut;
        private string _sEmployeeCode;
        private string _sEmployeeName;

        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private object _dUpdateDate;
        private int _nUpdateUserID;
        private int _nNoOfEMP;
        private string _sShowroomCode;
        private bool _bFlag;

        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }

        // <summary>
        // Get set property for ShowroomCode
        // </summary>
        public string ShowroomCode
        {
            get { return _sShowroomCode; }
            set { _sShowroomCode = value.Trim(); }
        }

        // <summary>
        // Get set property for NoOfEMP
        // </summary>
        public int NoOfEMP
        {
            get { return _nNoOfEMP; }
            set { _nNoOfEMP = value; }
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
        public object UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }




        // <summary>
        // Get set property for EmployeeCode
        // </summary>
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value.Trim(); }
        }
        // <summary>
        // Get set property for EmployeeName
        // </summary>
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value.Trim(); }
        }



        /// <summary>
        /// Get set property for TimeIn
        /// </summary>
        public object TimeIn
        {
            get { return _dTimeIn; }
            set { _dTimeIn = value; }
        }

        /// <summary>
        /// Get set property for TimeOut
        /// </summary>
        public object TimeOut
        {
            get { return _dTimeOut; }
            set { _dTimeOut = value; }
        }

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
        // Get set property for WarehouseID
        // </summary>
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
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
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_OutletAttendanceInfo where WarehouseID=" + _nWarehouseID + "";
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
                sSql = "INSERT INTO t_OutletAttendanceInfo (ID, WarehouseID, Date, CreateDate, CreateUserID, UpdateDate, UpdateUserID, Status) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Date", _dDate);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);

                cmd.Parameters.AddWithValue("Status", _nStatus);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Insert()
        {
            
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_OutletAttendanceInfo (ID, WarehouseID, Date, CreateDate, CreateUserID, UpdateDate, UpdateUserID, Status) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Date", _dDate);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);

                if (_dUpdateDate != DBNull.Value)
                {
                    cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("UpdateDate", null);
                }
                if (_nUpdateUserID != -1)
                {
                    cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("UpdateUserID", null);
                }

                cmd.Parameters.AddWithValue("Status", _nStatus);


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
                sSql = "UPDATE t_OutletAttendanceInfo SET  UpdateDate = ?, UpdateUserID= ?, Status = ? WHERE ID = ? and WarehouseID= ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

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
                sSql = "DELETE FROM t_OutletAttendanceInfo WHERE [ID]=?";
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

        public void DeleteDetail()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_OutletAttendanceInfoDetail WHERE [ID]=? and [WarehouseID]=? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
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
                cmd.CommandText = "SELECT * FROM t_OutletAttendanceInfo where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                     _nWarehouseID = (int)reader["WarehouseID"];
                    _dDate = Convert.ToDateTime(reader["Date"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetAddendanceItem(int nID,DateTime dtDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {

                cmd.CommandText = " Select ID,a.EmployeeID,  " +
                                  " '[' +EmployeeCode + ']' + ' '+ EmployeeName as EmployeeName,   " +
                                  " isnull(TimeIn,'" + dtDate + "') TimeIn,isnull(TimeOut,getdate()) TimeOut,a.Status,Remarks   " +
                                  " From t_OutletAttendanceInfoDetail a,t_Employee b  " +
                                  " where a.EmployeeID=b.EmployeeID and ID = ? and a.Status in (" + (int)Dictionary.HRAttendanceStatusForOutlet.Present + "," + (int)Dictionary.HRAttendanceStatusForOutlet.OutStation + ")";

                cmd.Parameters.AddWithValue("ID", nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletAttendanceInfoDetail oItem = new OutletAttendanceInfoDetail();

                    oItem.ID = int.Parse(reader["ID"].ToString());
                    oItem.EmployeeID = int.Parse(reader["EmployeeID"].ToString());
                    oItem.EmployeeName = (reader["EmployeeName"].ToString());
                    oItem.TimeIn = Convert.ToDateTime(reader["TimeIn"].ToString());
                    oItem.TimeOut = Convert.ToDateTime(reader["TimeOut"].ToString());
                    oItem.Status = int.Parse(reader["Status"].ToString());
                    oItem.Remarks = (reader["Remarks"].ToString());
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

        public void GetAddendanceItemRT(int nID, DateTime dtDate, int nWarehouseID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {

                cmd.CommandText = " Select ID,a.EmployeeID,  " +
                                  " '[' +EmployeeCode + ']' + ' '+ EmployeeName as EmployeeName,   " +
                                  " isnull(TimeIn,'" + dtDate + "') TimeIn,isnull(TimeOut,getdate()) TimeOut,a.Status,Remarks   " +
                                  " From t_OutletAttendanceInfoDetail a,t_Employee b  " +
                                  " where a.EmployeeID=b.EmployeeID and ID = ?  and a.WarehouseID=? and a.Status in (" + (int)Dictionary.HRAttendanceStatusForOutlet.Present + "," + (int)Dictionary.HRAttendanceStatusForOutlet.OutStation + ")";
                                  

                cmd.Parameters.AddWithValue("ID", nID);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletAttendanceInfoDetail oItem = new OutletAttendanceInfoDetail();

                    oItem.ID = int.Parse(reader["ID"].ToString());
                    oItem.EmployeeID = int.Parse(reader["EmployeeID"].ToString());
                    oItem.EmployeeName = (reader["EmployeeName"].ToString());
                    oItem.TimeIn = Convert.ToDateTime(reader["TimeIn"].ToString());
                    oItem.TimeOut = Convert.ToDateTime(reader["TimeOut"].ToString());
                    oItem.Status = int.Parse(reader["Status"].ToString());
                    oItem.Remarks = (reader["Remarks"].ToString());
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

        public void GetItem(int nID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {

                cmd.CommandText = "Select * From t_OutletAttendanceInfoDetail where ID = ? ";

                cmd.Parameters.AddWithValue("ID", nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletAttendanceInfoDetail oItem = new OutletAttendanceInfoDetail();

                    oItem.ID = int.Parse(reader["ID"].ToString());
                    oItem.EmployeeID = int.Parse(reader["EmployeeID"].ToString());

                    if (reader["TimeIn"] is DBNull)
                    {
                        oItem.TimeIn = null;
                    }
                    else
                    {
                        oItem.TimeIn = Convert.ToDateTime(reader["TimeIn"].ToString());
                    }
                    if (reader["TimeOut"] is DBNull)
                    {
                        oItem.TimeOut = null;
                    }
                    else
                    {
                        oItem.TimeOut = Convert.ToDateTime(reader["TimeOut"].ToString());
                    }

                    oItem.Status = int.Parse(reader["Status"].ToString());
                    if (reader["Remarks"] is DBNull)
                    {
                        oItem.Remarks = "";
                    }
                    else
                    {
                        oItem.Remarks = (reader["Remarks"].ToString());
                    }

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

        public void CheckOutlettAddendanceByID(int nID, int nWHID)
        {


            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nCount = 0;
            try
            {
                sSql = "SELECT * FROM t_OutletAttendanceInfo where ID=" + nID + " and WarehouseID=" + nWHID + " ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount++;
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                _bFlag = true;
            else _bFlag = false;

        }
    }
    public class OutletAttendanceInfos : CollectionBase
    {
        public OutletAttendanceInfo this[int i]
        {
            get { return (OutletAttendanceInfo)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(OutletAttendanceInfo oOutletAttendanceInfo)
        {
            InnerList.Add(oOutletAttendanceInfo);
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
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_OutletAttendanceInfo";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletAttendanceInfo oOutletAttendanceInfo = new OutletAttendanceInfo();
                    oOutletAttendanceInfo.ID = (int)reader["ID"];
                    oOutletAttendanceInfo.EmployeeID = (int)reader["EmployeeID"];
                    oOutletAttendanceInfo.WarehouseID = (int)reader["WarehouseID"];
                    oOutletAttendanceInfo.Date = Convert.ToDateTime(reader["Date"].ToString());
                    oOutletAttendanceInfo.Remarks = (string)reader["Remarks"];
                    oOutletAttendanceInfo.Status = (int)reader["Status"];
                    InnerList.Add(oOutletAttendanceInfo);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetDate(DateTime dtCDate, int nType)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (nType == (int)Dictionary.HRCheckStatusForOutlet.CheckIn)
            {
                sSql = "Select * From  " +
                           " (Select EmployeeID,'" + dtCDate + "' as Date,  " +
                           " '[' + EmployeeCode + ']' + ' ' + EmployeeName as EmployeeName  " +
                           " From t_Employee where Status in (1,2)) Main where Main.date not in (  " +
                           " Select Date From t_OutletAttendanceInfo)";
            }
            else if (nType == 3)
            {
                sSql = "Select a.EmployeeID,'" + dtCDate + "' as Date, " +
                    " '[' + EmployeeCode + ']' + ' ' + EmployeeName as EmployeeName   " +
                    "  From " +
                    " (Select EmployeeID From  " +
                    " (Select a.EmployeeID,isnull(b.EmployeeID,0) EEmployeeID From  " +
                    " (Select * From  " +
                    " (Select a.ID,EmployeeID,Date as ADate,b.Status, " +
                    " Remarks From t_OutletAttendanceInfo a,t_OutletAttendanceInfoDetail b " +
                    " where a.ID=b.ID and b.Status=" + (int)Dictionary.HRAttendanceStatusForOutlet.OutStation + ") a " +
                    " where ADate='" + dtCDate + "') a " +
                    " Left Outer Join  " +
                    " (Select * From  " +
                    " (Select a.ID,EmployeeID,Date as ADate,b.Status, " +
                    " Remarks From t_OutletAttendanceInfo a,t_OutletAttendanceInfoDetail b " +
                    " where a.ID=b.ID and b.Status<>" + (int)Dictionary.HRAttendanceStatusForOutlet.OutStation + ") a " +
                    " where ADate='" + dtCDate + "') b " +
                    " on a.EmployeeID=b.EmployeeID " +
                    " ) Main where EmployeeID<>EEmployeeID) A,t_Employee B " +
                    " where A.EmployeeID=B.EmployeeID";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletAttendanceInfo oAttendInfo = new OutletAttendanceInfo();

                    oAttendInfo.EmployeeID = Convert.ToInt32(reader["EmployeeID"].ToString());
                    oAttendInfo.EmployeeName = (string)reader["EmployeeName"];
                    oAttendInfo.Date = Convert.ToDateTime(reader["Date"].ToString());

                    InnerList.Add(oAttendInfo);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetDateRT(DateTime dtCDate, int nType)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (nType == (int)Dictionary.HRCheckStatusForOutlet.CheckIn)
            {
                sSql = "Select * From  " +
                           " (Select EmployeeID,'" + dtCDate + "' as Date,  " +
                           " '[' + EmployeeCode + ']' + ' ' + EmployeeName as EmployeeName  " +
                           " From t_Employee where EmpStatus in (1,2) and LocationID=" + Utility.LocationID + ") Main where Main.date not in (  " +
                           " Select Date From t_OutletAttendanceInfo)";
            }
            else if (nType == 3)
            {
                sSql = "Select a.EmployeeID,'" + dtCDate + "' as Date, " +
                    " '[' + EmployeeCode + ']' + ' ' + EmployeeName as EmployeeName   " +
                    "  From " +
                    " (Select EmployeeID From  " +
                    " (Select a.EmployeeID,isnull(b.EmployeeID,0) EEmployeeID From  " +
                    " (Select * From  " +
                    " (Select a.ID,EmployeeID,Date as ADate,b.Status, " +
                    " Remarks From t_OutletAttendanceInfo a,t_OutletAttendanceInfoDetail b " +
                    " where a.ID=b.ID and b.Status=" + (int)Dictionary.HRAttendanceStatusForOutlet.OutStation + ") a " +
                    " where ADate='" + dtCDate + "') a " +
                    " Left Outer Join  " +
                    " (Select * From  " +
                    " (Select a.ID,EmployeeID,Date as ADate,b.Status, " +
                    " Remarks From t_OutletAttendanceInfo a,t_OutletAttendanceInfoDetail b " +
                    " where a.ID=b.ID and b.Status<>" + (int)Dictionary.HRAttendanceStatusForOutlet.OutStation + ") a " +
                    " where ADate='" + dtCDate + "') b " +
                    " on a.EmployeeID=b.EmployeeID " +
                    " ) Main where EmployeeID<>EEmployeeID) A,t_Employee B " +
                    " where A.EmployeeID=B.EmployeeID";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletAttendanceInfo oAttendInfo = new OutletAttendanceInfo();

                    oAttendInfo.EmployeeID = Convert.ToInt32(reader["EmployeeID"].ToString());
                    oAttendInfo.EmployeeName = (string)reader["EmployeeName"];
                    oAttendInfo.Date = Convert.ToDateTime(reader["Date"].ToString());

                    InnerList.Add(oAttendInfo);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshDataForPOS(DateTime dFromDate, DateTime dToDate, string sEmpCode, string sEmpName, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = " Select a.EmployeeID,EmployeeCode,EmployeeName,Date,TimeIn,TimeOut,isnull(Remarks,'') as Remarks,a.Status  "+
                       " From t_OutletAttendanceInfo a,t_OutletAttendanceInfoDetail b,t_Employee c  " +
                       " where a.ID=b.ID and a.EmployeeID=c.EmployeeID ";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND Date between '" + dFromDate + "' and '" + dToDate + "' and Date<'" + dToDate + "' ";
            }

            if (sEmpCode != "")
            {
                sSql = sSql + " AND EmployeeCode like '%" + sEmpCode + "%'";
            }
            if (sEmpName != "")
            {
                sSql = sSql + " AND EmployeeName like '%" + sEmpName + "%'";
            }
            sSql = sSql + " Order by Date Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletAttendanceInfo oOutletAttendanceInfo = new OutletAttendanceInfo();

                    oOutletAttendanceInfo.ID = (int)reader["ID"];
                    oOutletAttendanceInfo.EmployeeID = (int)reader["EmployeeID"];
                    oOutletAttendanceInfo.EmployeeCode = (string)reader["EmployeeCode"];
                    oOutletAttendanceInfo.EmployeeName = (string)reader["EmployeeName"];
                    oOutletAttendanceInfo.Date = (DateTime)reader["Date"];
                    if (reader["TimeIn"] is DBNull)
                    {
                        oOutletAttendanceInfo.TimeIn = null;
                    }
                    else
                    {
                        oOutletAttendanceInfo.TimeIn = (DateTime)reader["TimeIn"];
                    }

                    if (reader["TimeOut"] is DBNull)
                    {
                        oOutletAttendanceInfo.TimeOut = null;
                    }
                    else
                    {
                        oOutletAttendanceInfo.TimeOut = (DateTime)reader["TimeOut"];
                    }
                    oOutletAttendanceInfo.Status = (int)reader["Status"];
                    oOutletAttendanceInfo.Remarks = (string)reader["Remarks"];

                    InnerList.Add(oOutletAttendanceInfo);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshData(DateTime dFromDate, DateTime dToDate, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = " Select * From  "+
                       " (Select a.ID,a.WarehouseID,ShowroomCode,Date,  "+
                       " CreateDate,CreateUserID,a.Status,count(EmployeeID) as NoOfEMP  "+
                       " From dbo.t_OutletAttendanceInfo a,  "+
                       " t_Showroom b,t_OutletAttendanceInfoDetail c  "+
                       " where a.WarehouseID=b.WarehouseID and a.ID=c.ID  "+
                       " group by a.ID,a.WarehouseID,ShowroomCode,Date,CreateDate,CreateUserID,a.Status) Main   " +
                       " where 1=1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND Date between '" + dFromDate + "' and '" + dToDate + "' and Date<'" + dToDate + "' ";
            }

            sSql = sSql + " Order by Date Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletAttendanceInfo oOutletAttendanceInfo = new OutletAttendanceInfo();

                    oOutletAttendanceInfo.ID = (int)reader["ID"];
                    oOutletAttendanceInfo.WarehouseID = (int)reader["WarehouseID"];
                    oOutletAttendanceInfo.ShowroomCode = (string)reader["ShowroomCode"];
                    oOutletAttendanceInfo.Date = (DateTime)reader["Date"];
                    oOutletAttendanceInfo.Status = (int)reader["Status"];
                    oOutletAttendanceInfo.CreateDate = (DateTime)reader["CreateDate"];
                    oOutletAttendanceInfo.CreateUserID = (int)reader["CreateUserID"];
                    oOutletAttendanceInfo.Status = (int)reader["Status"];
                    oOutletAttendanceInfo.NoOfEMP = (int)reader["NoOfEMP"];

                    InnerList.Add(oOutletAttendanceInfo);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshDataRT(DateTime dFromDate, DateTime dToDate, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = " Select * From  " +
                       " (Select a.ID,a.WarehouseID,ShowroomCode,Date,  " +
                       " CreateDate,CreateUserID,a.Status,count(EmployeeID) as NoOfEMP  " +
                       " From dbo.t_OutletAttendanceInfo a,  " +
                       " t_Showroom b,t_OutletAttendanceInfoDetail c  " +
                       " where a.WarehouseID=b.WarehouseID and a.ID=c.ID  and a.WarehouseID=c.WarehouseID   " +
                       " group by a.ID,a.WarehouseID,ShowroomCode,Date,CreateDate,CreateUserID,a.Status) Main   " +
                       " where WarehouseID=" + Utility.WarehouseID + "";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND Date between '" + dFromDate + "' and '" + dToDate + "' and Date<'" + dToDate + "' ";
            }

            sSql = sSql + " Order by Date Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletAttendanceInfo oOutletAttendanceInfo = new OutletAttendanceInfo();

                    oOutletAttendanceInfo.ID = (int)reader["ID"];
                    oOutletAttendanceInfo.WarehouseID = (int)reader["WarehouseID"];
                    oOutletAttendanceInfo.ShowroomCode = (string)reader["ShowroomCode"];
                    oOutletAttendanceInfo.Date = (DateTime)reader["Date"];
                    oOutletAttendanceInfo.Status = (int)reader["Status"];
                    oOutletAttendanceInfo.CreateDate = (DateTime)reader["CreateDate"];
                    oOutletAttendanceInfo.CreateUserID = (int)reader["CreateUserID"];
                    oOutletAttendanceInfo.Status = (int)reader["Status"];
                    oOutletAttendanceInfo.NoOfEMP = (int)reader["NoOfEMP"];

                    InnerList.Add(oOutletAttendanceInfo);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshDataReport(string sEmpCode,string sEmpName,DateTime dFromDate, DateTime dToDate)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select Date,b.EmployeeID, "+
                       "EmployeeCode,EmployeeName,DesignationName,TimeIn,TimeOut, " +
                       "b.Status,StatusName=Case when b.Status=1 then 'Present' "+
                       "when b.Status=2 then 'Roster' "+
                       "when b.Status=3 then 'Leave' "+
                       "when b.Status=4 then 'OutStation' "+
                       "else 'Other' end, Remarks "+
                       "From t_OutletAttendanceInfo a,t_OutletAttendanceInfoDetail b,t_Employee c " +
                       "where a.ID=b.ID and b.EmployeeID=c.EmployeeID  "+
                       "AND Date between '" + dFromDate + "' and '" + dToDate + "' and Date<'" + dToDate + "' ";

            }

            if (sEmpCode != "")
            {
                sSql = sSql + " AND EmployeeCode ='" + sEmpCode + "'";
            }
            if (sEmpName != "")
            {
                sSql = sSql + " AND EmployeeName like '%" + sEmpName + "%'";
            }

            sSql = sSql + " Order by Date,b.EmployeeID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletAttendanceInfoDetail oOutletAttendanceInfoDetail = new OutletAttendanceInfoDetail();

                    oOutletAttendanceInfoDetail.AttenDate = (DateTime)reader["Date"];
                    oOutletAttendanceInfoDetail.EmployeeID = (int)reader["EmployeeID"];
                    oOutletAttendanceInfoDetail.EmployeeCode = (string)reader["EmployeeCode"];
                    oOutletAttendanceInfoDetail.EmployeeName = (string)reader["EmployeeName"];
                    oOutletAttendanceInfoDetail.DesignationName = (string)reader["DesignationName"];
                    if (reader["TimeIn"] is DBNull)
                    {
                        oOutletAttendanceInfoDetail.TimeIn = null;
                    }
                    else
                    {
                        oOutletAttendanceInfoDetail.TimeIn = (DateTime)reader["TimeIn"];
                    }

                    if (reader["TimeOut"] is DBNull)
                    {
                        oOutletAttendanceInfoDetail.TimeOut = null;
                    }
                    else
                    {
                        oOutletAttendanceInfoDetail.TimeOut = (DateTime)reader["TimeOut"];
                    }
                    oOutletAttendanceInfoDetail.Status = (int)reader["Status"];
                    oOutletAttendanceInfoDetail.StatusName = (string)reader["StatusName"];
                    if (reader["Remarks"] is DBNull)
                    {
                        oOutletAttendanceInfoDetail.Remarks = "";
                    }
                    else
                    {
                        oOutletAttendanceInfoDetail.Remarks = (string)reader["Remarks"];
                    }
                   
                    InnerList.Add(oOutletAttendanceInfoDetail);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshDataReportRT(string sEmpCode, string sEmpName, DateTime dFromDate, DateTime dToDate,int nWarehouseID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select Date,b.EmployeeID, " +
                       "EmployeeCode,EmployeeName,DesignationName,TimeIn,TimeOut, " +
                       "b.Status,StatusName=Case when b.Status=1 then 'Present' " +
                       "when b.Status=2 then 'Roster' " +
                       "when b.Status=3 then 'Leave' " +
                       "when b.Status=4 then 'OutStation' " +
                       "else 'Other' end, Remarks " +
                       "From t_OutletAttendanceInfo a,t_OutletAttendanceInfoDetail b,v_EmployeeDetails c " +
                       "where a.ID=b.ID and b.EmployeeID=c.EmployeeID and a.WarehouseID=b.WarehouseID   " +
                       "AND Date between '" + dFromDate + "' and '" + dToDate + "' and Date<'" + dToDate + "' and a.WarehouseID="+ nWarehouseID + "";

            }

            if (sEmpCode != "")
            {
                sSql = sSql + " AND EmployeeCode ='" + sEmpCode + "'";
            }
            if (sEmpName != "")
            {
                sSql = sSql + " AND EmployeeName like '%" + sEmpName + "%'";
            }

            sSql = sSql + " Order by Date,b.EmployeeID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletAttendanceInfoDetail oOutletAttendanceInfoDetail = new OutletAttendanceInfoDetail();

                    oOutletAttendanceInfoDetail.AttenDate = (DateTime)reader["Date"];
                    oOutletAttendanceInfoDetail.EmployeeID = (int)reader["EmployeeID"];
                    oOutletAttendanceInfoDetail.EmployeeCode = (string)reader["EmployeeCode"];
                    oOutletAttendanceInfoDetail.EmployeeName = (string)reader["EmployeeName"];
                    oOutletAttendanceInfoDetail.DesignationName = (string)reader["DesignationName"];
                    if (reader["TimeIn"] is DBNull)
                    {
                        oOutletAttendanceInfoDetail.TimeIn = null;
                    }
                    else
                    {
                        oOutletAttendanceInfoDetail.TimeIn = (DateTime)reader["TimeIn"];
                    }

                    if (reader["TimeOut"] is DBNull)
                    {
                        oOutletAttendanceInfoDetail.TimeOut = null;
                    }
                    else
                    {
                        oOutletAttendanceInfoDetail.TimeOut = (DateTime)reader["TimeOut"];
                    }
                    oOutletAttendanceInfoDetail.Status = (int)reader["Status"];
                    oOutletAttendanceInfoDetail.StatusName = (string)reader["StatusName"];
                    if (reader["Remarks"] is DBNull)
                    {
                        oOutletAttendanceInfoDetail.Remarks = "";
                    }
                    else
                    {
                        oOutletAttendanceInfoDetail.Remarks = (string)reader["Remarks"];
                    }

                    InnerList.Add(oOutletAttendanceInfoDetail);
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





