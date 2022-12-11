
// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: May 20, 2012
// Time :  3:00 PM
// Description: Class for Complain Detail Report.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;
using CJ.Class.CSD;

namespace CJ.Class
{
    public class ComplainRpt
    {
        private int _nComplainID;
        private string _sComplainer;
        private string _sContactNo;
        private int _nComplainerTypeID;
        private int _nSourceID;
        private int _nComplainAgainstID;
        private string _sComplainAgainstWhom;
        private string _sComplainDetails;
        private string _sReferanceJobNo;
        private Object _dDateOccurred;
        private int _nComplainCatID;
        private Object _sActionDetails;
        private Object _dActionDate;
        private Object _nStatusID;
        private int _nCreateUserID;
        private Object _dCreateDate;
        private int _nUpdateUserID;
        private Object _dUpdateDate;
        private int _nAssignEmployeeID;
        private Object _dAssignDate;
        private int _nHappyCallStatusID;
        private Object _sHappyCallDetails;
        private Object _dHappyCallDate;
        private int _nHappyCallUserID;
        private int _nComplainStatus;
        private int _nFurtherActionReqID;
                
        private Employee _oEmployee;
        private User _oUser;
      
        /// <summary>
        /// Get set property for ComplainID
        /// </summary>
        public int ComplainID
        {
            get { return _nComplainID; }
            set { _nComplainID = value; }
        }

        /// <summary>
        /// Get set property for Complainer
        /// </summary>
        public string Complainer
        {
            get { return _sComplainer; }
            set { _sComplainer = value; }
        }

        /// <summary>
        /// Get set property for ContactNo
        /// </summary>
        public string ContactNo
        {
            get { return _sContactNo; }
            set { _sContactNo = value; }
        }

        /// <summary>
        /// Get set property for ComplainerTypeID
        /// </summary>
        public int ComplainerTypeID
        {
            get { return _nComplainerTypeID; }
            set { _nComplainerTypeID = value; }
        }

        /// <summary>
        /// Get set property for Contact SourceID
        /// </summary>
        public int SourceID
        {
            get { return _nSourceID; }
            set { _nSourceID = value; }
        }

        /// <summary>
        /// Get set property for ComplainAgainstID
        /// </summary>
        public int ComplainAgainstID
        {
            get { return _nComplainAgainstID; }
            set { _nComplainAgainstID = value; }
        }

        /// <summary>
        /// Get set property for ComplainAgainstWhom
        /// </summary>
        public string ComplainAgainstWhom
        {
            get { return _sComplainAgainstWhom; }
            set { _sComplainAgainstWhom = value; }
        }

        /// <summary>
        /// Get set property for ComplainDetails
        /// </summary>
        public string ComplainDetails
        {
            get { return _sComplainDetails; }
            set { _sComplainDetails = value; }
        }

        /// <summary>
        /// Get set property for ReferanceJobNo
        /// </summary>
        public string ReferanceJobNo
        {
            get { return _sReferanceJobNo; }
            set { _sReferanceJobNo = value; }
        }

        /// <summary>
        /// Get set property for DateOccurred
        /// </summary>
        public Object DateOccurred
        {
            get { return _dDateOccurred; }
            set { _dDateOccurred = value; }
        }

        /// <summary>
        /// Get set property for ComplainCatID
        /// </summary>
        public int ComplainCatID
        {
            get { return _nComplainCatID; }
            set { _nComplainCatID = value; }
        }

        /// <summary>
        /// Get set property for ActionDetails
        /// </summary>
        public Object ActionDetails
        {
            get { return _sActionDetails; }
            set { _sActionDetails = value; }
        }

        /// <summary>
        /// Get set property for Action Date
        /// </summary>
        public Object ActionDate
        {
            get { return _dActionDate; }
            set { _dActionDate = value; }
        }

        /// <summary>
        /// Get set property for StatusID
        /// </summary>
        public Object StatusID
        {
            get { return _nStatusID; }
            set { _nStatusID = value; }
        }

        /// <summary>
        /// Get set property for CreateUserID
        /// </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        /// <summary>
        /// Get set property for CreateDate
        /// </summary>
        public Object CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        /// <summary>
        /// Get set property for UpdateUserID
        /// </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        /// <summary>
        /// Get set property for UpdateDate
        /// </summary>
        public Object UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        /// <summary>
        /// Get set property for AssignEmployeeID
        /// </summary>
        public int AssignEmployeeID
        {
            get { return _nAssignEmployeeID; }
            set { _nAssignEmployeeID = value; }
        }

        public Employee Employee
        {
            get
            {
                if (_oEmployee == null)
                {
                    _oEmployee = new Employee();
                    _oEmployee.EmployeeID = _nAssignEmployeeID;
                    _oEmployee.Refresh();
                }

                return _oEmployee;
            }
        }

        public User User
        {
            get
            {
                if (_oUser == null)
                {
                    _oUser = new User();
                }
                return _oUser;
            }
        }
      
        /// <summary>
        /// Get set property for AssignDate
        /// </summary>
        public Object AssignDate
        {
            get { return _dAssignDate; }
            set { _dAssignDate = value; }
        }

        /// <summary>
        /// Get set property for HappyCallStatusID
        /// </summary>
        public int HappyCallStatusID
        {
            get { return _nHappyCallStatusID; }
            set { _nHappyCallStatusID = value; }
        }

        /// <summary>
        /// Get set property for HappyCallDetails
        /// </summary>
        public Object HappyCallDetails
        {
            get { return _sHappyCallDetails; }
            set { _sHappyCallDetails = value; }
        }

        /// <summary>
        /// Get set property for HappyCallDate
        /// </summary>
        public Object HappyCallDate
        {
            get { return _dHappyCallDate; }
            set { _dHappyCallDate = value; }
        }

        /// <summary>
        /// Get set property for HappyCallUserID
        /// </summary>
        public int HappyCallUserID
        {
            get { return _nHappyCallUserID; }
            set { _nHappyCallUserID = value; }
        }

        /// <summary>
        /// Get set property for ComplainStauts
        /// </summary>
        public int ComplainStatus
        {
            get { return _nComplainStatus; }
            set { _nComplainStatus = value; }
        }

        /// <summary>
        /// Get set property for FurtherActionReqID
        /// </summary>
        public int FurtherActionReqID
        {
            get { return _nFurtherActionReqID; }
            set { _nFurtherActionReqID = value; }
        }

        public void RefreshUser()
        {
            User.UserId = _nCreateUserID;
            User.RefreshByUserID();
        }
        }

        public class ComplainRpts : CollectionBase
        {
            public ComplainRpt this[int i]
            {
                get { return (ComplainRpt)InnerList[i]; }
                set { InnerList[i] = value; }
            }

            public void Add(ComplainRpt oComplainRpt)
            {
                InnerList.Add(oComplainRpt);
            }

            //public void RefreshUser()
            //{
            //    User.UserId = _nCreateUserID;
            //    User.RefreshByUserID();
            //}

            public void Refresh()
            {
                //dtToDate = dtToDate.Date.AddDays(1);
                
                InnerList.Clear();
                OleDbCommand cmd = DBController.Instance.GetCommand();

                string sSql = "Select F.* from " +
                              "( " +
                              "SELECT c.ComplainID, C.ComplainerTypeID, C.SourceID, C.ComplainAgainstID, C.CreateUserID,C.Complainer, C.ContactNo, C.ComplainAgainstWhom, C.ComplainDetails, " +
                              "C.ReferanceJobNo, C.DateOccurred, C.CreateDate, C.AssignDate, C.HappyCallDetails, C.HappyCallDate, " +
                              "U.UserFullName CreateUser, U1.UserFullName HappyCallUser, U2.UserFullName ActionUser,  C.ActionDetails,C.ActionDate, " +
                              "C.UpdateDate ActionEntryDate, E.EmployeeName, " +
                              "ComplainStatus=Case When ComplainStatus=0 Then 'Receive' When ComplainStatus=1 Then 'Assign' " +
                              "When ComplainStatus=2 Then 'Action' When ComplainStatus=3 Then 'HappyCall' " +
                              "When ComplainStatus=4 Then 'Cancel' When ComplainStatus=5 Then 'Solved' " +
                              "When ComplainStatus=6 Then 'UnderProcess' When ComplainStatus=7 Then 'Mgt.ActionReq' " +
                              "End, ComplainerType=Case When ComplainerTypeID=0 Then 'Customer' When ComplainerTypeID=1 Then 'Dealer' " +
                              "When ComplainerTypeID=2 Then 'TranscomDigital' When ComplainerTypeID=3 Then 'CustomerReference' " +
                              "End, Source=Case When SourceID=0 Then 'Proactively' When SourceID=1 Then 'DuringJobUpdate' " +
                              "When SourceID=2 Then 'DuringHappyCall' End, ComplainAgainst=Case When ComplainAgainstID=0 Then 'Technician' " +
                              "When ComplainAgainstID=1 Then 'Sales_Personnel' When ComplainAgainstID=2 Then 'CallCenterAgent' " +
                              "When ComplainAgainstID=3 Then 'FrontDeskAgent' When ComplainAgainstID=4 Then 'ServiceExecutive_TD' " +
                              "When ComplainAgainstID=5 Then 'InterService' When ComplainAgainstID=6 Then 'ZonalSupervisor' " +
                              "When ComplainAgainstID=7 Then 'Management' End, ComplainCategory=Case When ComplainCatID=1 Then 'BeforeSale' " +
                              "When ComplainCatID=2 Then 'AfterSale' End, HappyCallStatus=Case When HappyCallStatusID=0 Then 'Satisfy' " +
                              "When HappyCallStatusID=1 Then 'Moderate' When HappyCallStatusID=2 Then 'Dissatisfy' End, FurtherActionReq=Case " +
                              "When FurtherActionReqID=0 Then 'False' When FurtherActionReqID=1 Then 'True' End FROM t_CSDComplain C " +
                              "Left Outer JOIN t_Employee E ON C.AssignEmployeeID=E.EmployeeID Left Outer JOIN t_User U ON U.UserId=C.CreateUserID " +
                              "Left Outer JOIN t_User U1 ON U1.UserId=C.HappyCallUserID Left Outer JOIN t_User U2 ON U2.UserId=C.UpdateUserID " +
                              "Where E.EmployeeName IS NOT NULL " +

                              "UNION ALL " +

                              "SELECT c.ComplainID, C.ComplainerTypeID, C.SourceID, C.ComplainAgainstID, C.CreateUserID,C.Complainer, C.ContactNo, C.ComplainAgainstWhom, C.ComplainDetails, " +
                              "C.ReferanceJobNo, C.DateOccurred, C.CreateDate, C.AssignDate, C.HappyCallDetails, C.HappyCallDate, " +
                              "U.UserFullName CreateUser, U1.UserFullName HappyCallUser, U2.UserFullName ActionUser,  C.ActionDetails,C.ActionDate, " +
                              "C.UpdateDate ActionEntryDate, 'Not Assign', " +
                              "ComplainStatus=Case When ComplainStatus=0 Then 'Receive' When ComplainStatus=1 Then 'Assign' " +
                              "When ComplainStatus=2 Then 'Action' When ComplainStatus=3 Then 'HappyCall' " +
                              "When ComplainStatus=4 Then 'Cancel' When ComplainStatus=5 Then 'Solved' " +
                              "When ComplainStatus=6 Then 'UnderProcess' When ComplainStatus=7 Then 'Mgt.ActionReq' " +
                              "End, ComplainerType=Case When ComplainerTypeID=0 Then 'Customer' When ComplainerTypeID=1 Then 'Dealer' " +
                              "When ComplainerTypeID=2 Then 'TranscomDigital' When ComplainerTypeID=3 Then 'CustomerReference' " +
                              "End, Source=Case When SourceID=0 Then 'Proactively' When SourceID=1 Then 'DuringJobUpdate' " +
                              "When SourceID=2 Then 'DuringHappyCall' End, ComplainAgainst=Case When ComplainAgainstID=0 Then 'Technician' " +
                              "When ComplainAgainstID=1 Then 'Sales_Personnel' When ComplainAgainstID=2 Then 'CallCenterAgent' " +
                              "When ComplainAgainstID=3 Then 'FrontDeskAgent' When ComplainAgainstID=4 Then 'ServiceExecutive_TD' " +
                              "When ComplainAgainstID=5 Then 'InterService' When ComplainAgainstID=6 Then 'ZonalSupervisor' " +
                              "When ComplainAgainstID=7 Then 'Management' End, ComplainCategory=Case When ComplainCatID=1 Then 'BeforeSale' " +
                              "When ComplainCatID=2 Then 'AfterSale' End, HappyCallStatus=Case When HappyCallStatusID=0 Then 'Satisfy' " +
                              "When HappyCallStatusID=1 Then 'Moderate' When HappyCallStatusID=2 Then 'Dissatisfy' End, FurtherActionReq=Case " +
                              "When FurtherActionReqID=0 Then 'False' When FurtherActionReqID=1 Then 'True' End FROM t_CSDComplain C " +
                              "Left Outer JOIN t_Employee E ON C.AssignEmployeeID=E.EmployeeID Left Outer JOIN t_User U ON U.UserId=C.CreateUserID " +
                              "Left Outer JOIN t_User U1 ON U1.UserId=C.HappyCallUserID Left Outer JOIN t_User U2 ON U2.UserId=C.UpdateUserID " +
                              "Where E.EmployeeName IS NULL " +
                              ")F Where F.CreateDate BETWEEN '01-Jan-2012' AND GetDate() ";
          
                try
                {
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Complain oComplain = new Complain();
                        oComplain.ComplainID = (int)reader["ComplainID"];
                        oComplain.Complainer = (string)reader["Complainer"];
                        oComplain.ContactNo = (string)reader["ContactNo"];
                        oComplain.ComplainerTypeID = (int)reader["ComplainerTypeID"];
                        oComplain.SourceID = (int)reader["SourceID"];
                        oComplain.ComplainAgainstID = (int)reader["ComplainAgainstID"];
                        oComplain.ComplainAgainstWhom = (string)reader["ComplainAgainstWhom"];
                        oComplain.ComplainDetails = (string)reader["ComplainDetails"];
                        oComplain.ReferanceJobNo = (string)reader["ReferanceJobNo"];
                        oComplain.DateOccurred = Convert.ToDateTime(reader["DateOccurred"].ToString());
                        //oComplain.ComplainCatID = (int)reader["ComplainCatID"];
                        oComplain.ActionDetails = (Object)reader["ActionDetails"];
                        oComplain.ActionDate = (Object)reader["ActionDate"];
                        //oComplain.ActionDate = Convert.ToDateTime(reader["ActionDate"].ToString());
                        //oComplain.StatusID = (Object)reader["StatusID"];
                        oComplain.CreateUserID = (int)reader["CreateUserID"];
                        oComplain.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                        //oComplain.UpdateUserID = (int)reader["UpdateUserID"];
                        //oComplain.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                        //oComplain.AssignEmployeeID = (int)reader["AssignEmployeeID"];
                        //oComplain.AssignDate = Convert.ToDateTime(reader["AssignDate"].ToString());
                        //oComplain.HappyCallStatusID = (int)reader["HappyCallStatusID"];
                        oComplain.HappyCallDetails = (Object)reader["HappyCallDetails"];
                        //oComplain.HappyCallDate = Convert.ToDateTime(reader["HappyCallDate"].ToString());
                        //oComplain.HappyCallUserID = (int)reader["HappyCallUserID"];
                        oComplain.ComplainStatus = int.Parse(reader["ComplainStatus"].ToString());
                        oComplain.FurtherActionReqID = int.Parse(reader["FurtherActionReqID"].ToString());

                        oComplain.RefreshUser();
                        InnerList.Add(oComplain);
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