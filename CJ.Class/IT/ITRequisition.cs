// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arifur Rahman Khan
// Date: May 26, 2011
// Time :  5:15 PM
// Description: Class for ITRequisition.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class
{
    public class ITRequisition
    {
        private int _ITReqID;
        private string _TicketNo;
        private DateTime _TicketDate;
        private int _EmployeeID;
        private int _TicketType;
        private int _DepartmentID;
        private int _CompanyID;
        private string _ITComponent;
        private string _RequirementDesc;
        private string _Justification;
        private int _Status;
        private DateTime _CompleteDate;
        private int _Priority;
        private int _UserID;
        private string _Remarks;

        private Employee _oEmployee;
        private Company _oCompany;
        private Department _oDepartment;
        private User _oUser;

        /// <summary>
        /// Get set property for ITReqID
        /// </summary>
        public int ITReqID
        {
            get { return _ITReqID; }
            set { _ITReqID = value; }
        }

        /// <summary>
        /// Get set property for TicketNo
        /// </summary>
        public string TicketNo
        {
            get { return _TicketNo; }
            set { _TicketNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for TicketDate
        /// </summary>
        public DateTime TicketDate
        {
            get { return _TicketDate; }
            set { _TicketDate = value; }
        }

        /// <summary>
        /// Get set property for EmployeeID
        /// </summary>
        public int EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }

        public Employee Employee
        {
            get
            {
                if (_oEmployee == null)
                {
                    _oEmployee = new Employee();
                    _oEmployee.EmployeeID = _EmployeeID;
                    _oEmployee.Refresh();
                }

                return _oEmployee;
            }
        }

        /// <summary>
        /// Get set property for TicketType
        /// </summary>
        public int TicketType
        {
            get { return _TicketType; }
            set { _TicketType = value; }
        }

        /// <summary>
        /// Get set property for DepartmentID
        /// </summary>
        public int DepartmentID
        {
            get { return _DepartmentID; }
            set { _DepartmentID = value; }
        }

        public Department Department
        {
            get
            {
                if (_oDepartment == null)
                {
                    _oDepartment = new Department();
                    _oDepartment.DepartmentID = _DepartmentID;
                    _oDepartment.Refresh();
                }

                return _oDepartment;
            }
        }

        /// <summary>
        /// Get set property for CompanyID
        /// </summary>
        public int CompanyID
        {
            get { return _CompanyID; }
            set { _CompanyID = value; }
        }

        public Company Company
        {
            get
            {
                if (_oCompany == null)
                {
                    _oCompany = new Company();
                    _oCompany.CompanyID = _CompanyID;
                    _oCompany.Refresh();
                }

                return _oCompany;
            }
        }

        /// <summary>
        /// Get set property for ITComponent
        /// </summary>
        public string ITComponent
        {
            get { return _ITComponent; }
            set { _ITComponent = value.Trim(); }
        }

        /// <summary>
        /// Get set property for RequirementDesc
        /// </summary>
        public string RequirementDesc
        {
            get { return _RequirementDesc; }
            set { _RequirementDesc = value.Trim(); }
        }

        /// <summary>
        /// Get set property for Justification
        /// </summary>
        public string Justification
        {
            get { return _Justification; }
            set { _Justification = value.Trim(); }
        }

        /// <summary>
        /// Get set property for Status
        /// </summary>
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        /// <summary>
        /// Get set property for CompleteDate
        /// </summary>
        public DateTime CompleteDate
        {
            get { return _CompleteDate; }
            set { _CompleteDate = value; }
        }

        /// <summary>
        /// Get set property for Priority
        /// </summary>
        public int Priority
        {
            get { return _Priority; }
            set { _Priority = value; }
        }

        /// <summary>
        /// Get set property for UserID
        /// </summary>
        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        public User User
        {
            get
            {
                if (_oUser == null)
                {
                    _oUser = new User();
                    _oUser.UserId = _UserID;
                    _oUser.RefreshByUserID();
                }

                return _oUser;
            }
        }
        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value.Trim(); }
        }



        public void Add()
        {
            int nMaxITRequisitionID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ITReqID]) FROM t_ITRequisition";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxITRequisitionID = 1;
                }
                else
                {
                    nMaxITRequisitionID = Convert.ToInt32(maxID) + 1;
                }
                _ITReqID = nMaxITRequisitionID;
                _TicketNo = DateTime.Today.Year.ToString() + "-" + nMaxITRequisitionID.ToString("000");
                sSql = "INSERT INTO t_ITRequisition(ITReqID,TicketNo,TicketDate,EmployeeID,"
                    + " TicketType,DepartmentID,CompanyID,ITComponent,RequirementDesc,"
                    + " Justification,Status,CompleteDate,Priority,UserID,Remarks"
                    + " ) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ITReqID", _ITReqID);
                cmd.Parameters.AddWithValue("TicketNo", _TicketNo);
                cmd.Parameters.AddWithValue("TicketDate", _TicketDate);

                cmd.Parameters.AddWithValue("EmployeeID", _EmployeeID);
                cmd.Parameters.AddWithValue("TicketType", _TicketType);
                cmd.Parameters.AddWithValue("DepartmentID", _DepartmentID);

                cmd.Parameters.AddWithValue("CompanyID", _CompanyID);
                cmd.Parameters.AddWithValue("ITComponent", _ITComponent);
                cmd.Parameters.AddWithValue("RequirementDesc", _RequirementDesc);

                cmd.Parameters.AddWithValue("Justification", _Justification);
                cmd.Parameters.AddWithValue("Status", _Status);
                cmd.Parameters.AddWithValue("CompleteDate", _CompleteDate);

                cmd.Parameters.AddWithValue("Priority", _Priority);
                cmd.Parameters.AddWithValue("UserID", _UserID);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);

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

                sSql = "UPDATE t_ITRequisition SET TicketNo=?,TicketDate=?,EmployeeID=?,"
                    + " TicketType=?,DepartmentID=?,CompanyID=?,ITComponent=?,RequirementDesc=?,"
                    + " Justification=?,Status=?,CompleteDate=?,Priority=?,UserID=?,Remarks=?"
                    + " WHERE ITReqID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TicketNo", _TicketNo);
                cmd.Parameters.AddWithValue("TicketDate", _TicketDate);

                cmd.Parameters.AddWithValue("EmployeeID", _EmployeeID);
                cmd.Parameters.AddWithValue("TicketType", _TicketType);
                cmd.Parameters.AddWithValue("DepartmentID", _DepartmentID);

                cmd.Parameters.AddWithValue("CompanyID", _CompanyID);
                cmd.Parameters.AddWithValue("ITComponent", _ITComponent);
                cmd.Parameters.AddWithValue("RequirementDesc", _RequirementDesc);

                cmd.Parameters.AddWithValue("Justification", _Justification);
                cmd.Parameters.AddWithValue("Status", _Status);
                cmd.Parameters.AddWithValue("CompleteDate", _CompleteDate);

                cmd.Parameters.AddWithValue("Priority", _Priority);
                cmd.Parameters.AddWithValue("UserID", _UserID);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);

                cmd.Parameters.AddWithValue("ITReqID", _ITReqID);

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
                sSql = "DELETE FROM t_ITRequisition WHERE [ITReqID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ITReqID", _ITReqID);
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
                cmd.CommandText = "SELECT * FROM t_ITRequisition where ITReqID =?";
                cmd.Parameters.AddWithValue("ITReqID", _ITReqID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _ITReqID = (int)reader["ITReqID"];
                    _TicketNo = (string)reader["TicketNo"];
                    _TicketDate = (DateTime)reader["TicketDate"];
                    _EmployeeID = (int)reader["EmployeeID"];

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
    public class ITRequisitions : CollectionBase
    {
        public ITRequisition this[int i]
        {
            get { return (ITRequisition)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public int GetIndex(int nITRequisitionID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ITReqID == nITRequisitionID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Add(ITRequisition oITRequisition)
        {
            InnerList.Add(oITRequisition);
        }

        public void Refresh()
        {

            string sSql = "SELECT * FROM t_ITRequisition";
            GetData(sSql);
        }

        public void Refresh(DateTime dFromDate, DateTime dToDate,int nStatus)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                string sSql = "SELECT * FROM t_ITRequisition where (TicketDate between ? and ?)";

                cmd.Parameters.AddWithValue("TicketDate", dFromDate);
                cmd.Parameters.AddWithValue("TicketDate", dToDate);

                if (nStatus >= 0)
                {
                    sSql = sSql + " and Status=?";
                    cmd.Parameters.AddWithValue("Status", nStatus);
                }
 
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ITRequisition oITRequisition = new ITRequisition();

                    oITRequisition.ITReqID = (int)reader["ITReqID"];
                    oITRequisition.TicketNo = (string)reader["TicketNo"];
                    oITRequisition.TicketDate = (DateTime)reader["TicketDate"];

                    oITRequisition.EmployeeID = (int)reader["EmployeeID"];
                    oITRequisition.TicketType = (int)reader["TicketType"];
                    oITRequisition.DepartmentID = (int)reader["DepartmentID"];

                    oITRequisition.CompanyID = (int)reader["CompanyID"];
                    oITRequisition.ITComponent = (string)reader["ITComponent"];
                    oITRequisition.RequirementDesc = (string)reader["RequirementDesc"];

                    oITRequisition.Justification = (string)reader["Justification"];
                    oITRequisition.Status = (int)reader["Status"];
                    oITRequisition.CompleteDate = (DateTime)reader["CompleteDate"];

                    oITRequisition.Priority = (int)reader["Priority"];
                    oITRequisition.UserID = (int)reader["UserID"];
                    oITRequisition.Remarks = (string)reader["Remarks"];

                    InnerList.Add(oITRequisition);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        private void GetData(string sSql)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ITRequisition oITRequisition = new ITRequisition();

                    oITRequisition.ITReqID = (int)reader["ITReqID"];
                    oITRequisition.TicketNo = (string)reader["TicketNo"];
                    oITRequisition.TicketDate = (DateTime)reader["TicketDate"];

                    oITRequisition.EmployeeID = (int)reader["EmployeeID"];
                    oITRequisition.TicketType = (int)reader["TicketType"];
                    oITRequisition.DepartmentID = (int)reader["DepartmentID"];

                    oITRequisition.CompanyID = (int)reader["CompanyID"];
                    oITRequisition.ITComponent = (string)reader["ITComponent"];
                    oITRequisition.RequirementDesc = (string)reader["RequirementDesc"];

                    oITRequisition.Justification = (string)reader["Justification"];
                    oITRequisition.Status = (int)reader["Status"];
                    oITRequisition.CompleteDate = (DateTime)reader["CompleteDate"];

                    oITRequisition.Priority = (int)reader["Priority"];
                    oITRequisition.UserID = (int)reader["UserID"];
                    oITRequisition.Remarks = (string)reader["Remarks"];

                    InnerList.Add(oITRequisition);
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

