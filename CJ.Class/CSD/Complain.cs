// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Feb 22, 2012
// Time :  4:55 PM
// Description: Class for Complain Data.
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
    public class Complain
    {
        private int _nComplainID;
        private string _sComplainer;
        private string _sContactNo;
        private int _nComplainerTypeID;
        private int _nSourceID;
        private int _nComplainAgainstID;
        private Object _sComplainAgainstWhom;
        private string _sComplainDetails;
        private Object _sReferanceJobNo;
        private Object _dDateOccurred;
        private int _nComplainCatID;
        private Object _sActionDetails;
        private Object _dActionDate;
        private int _nStatusID;
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
        private Object _sHappyCallUserName;
        private Object _sStatusName;
        private int _nQuality;
        private int _nCommitment;
        private int _nDealings;
        private int _nPerformance;
        private int _nSkill;
        private int _nPrice;
        private int _nBill;
        private int _nHomeCall;
        private int _nWalkIn;
        private int _nInstallation;
        private int _nOthers;
        private int _nDealing;
        private int _nHomeDelivery;
        private int _nDemoInstall;
        private int _nProduct;
        //private string _sActionStatusName;
                
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
        public Object ComplainAgainstWhom
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
        public Object ReferanceJobNo
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
        public int StatusID
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
        /// <summary>
        /// Get set property for HappyCallUserName
        /// </summary>
        public Object HappyCallUserName
        {
            get { return _sHappyCallUserName; }
            set { _sHappyCallUserName = value; }
        }
        /// <summary>
        /// Get set property for StatusName
        /// </summary>
        public Object StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value; }
        }
        /// <summary>
        /// Get set property for Quality
        /// </summary>
        public int Quality
        {
            get { return _nQuality; }
            set { _nQuality = value; }
        }
        /// <summary>
        /// Get set property for Commitment
        /// </summary>
        public int Commitment
        {
            get { return _nCommitment; }
            set { _nCommitment = value; }
        }
        /// <summary>
        /// Get set property for Dealings
        /// </summary>
        public int Dealings
        {
            get { return _nDealings; }
            set { _nDealings = value; }
        }
        /// <summary>
        /// Get set property for Performance
        /// </summary>
        public int Performance
        {
            get { return _nPerformance; }
            set { _nPerformance = value; }
        }
        /// <summary>
        /// Get set property for Skill
        /// </summary>
        public int Skill
        {
            get { return _nSkill; }
            set { _nSkill = value; }
        }
        /// <summary>
        /// Get set property for Price
        /// </summary>
        public int Price
        {
            get { return _nPrice; }
            set { _nPrice = value; }
        }
        /// <summary>
        /// Get set property for Bill
        /// </summary>
        public int Bill
        {
            get { return _nBill; }
            set { _nBill = value; }
        }
        /// <summary>
        /// Get set property for HomeCall
        /// </summary>
        public int HomeCall
        {
            get { return _nHomeCall; }
            set { _nHomeCall = value; }
        }
        /// <summary>
        /// Get set property for WalkIn
        /// </summary>
        public int WalkIn
        {
            get { return _nWalkIn; }
            set { _nWalkIn = value; }
        }
        /// <summary>
        /// Get set property for Installation
        /// </summary>
        public int Installation
        {
            get { return _nInstallation; }
            set { _nInstallation = value; }
        }
        /// <summary>
        /// Get set property for Others
        /// </summary>
        public int Others
        {
            get { return _nOthers; }
            set { _nOthers = value; }
        }
        /// <summary>
        /// Get set property for Dealing
        /// </summary>
        public int Dealing
        {
            get { return _nDealing; }
            set { _nDealing = value; }
        }
        /// <summary>
        /// Get set property for HomeDelivery
        /// </summary>
        public int HomeDelivery
        {
            get { return _nHomeDelivery; }
            set { _nHomeDelivery = value; }
        }
        /// <summary>
        /// Get set property for DemoInstall
        /// </summary>
        public int DemoInstall
        {
            get { return _nDemoInstall; }
            set { _nDemoInstall = value; }
        }
        /// <summary>
        /// Get set property for Product
        /// </summary>
        public int Product
        {
            get { return _nProduct; }
            set { _nProduct = value; }
        }


        public void Add()
            {
                int nMaxComplainID = 0;
                OleDbCommand cmd = DBController.Instance.GetCommand();
                string sSql = "";

                try
                {
                    sSql = "SELECT MAX([ComplainID]) FROM t_CSDComplain";
                    cmd.CommandText = sSql;
                    object maxID = cmd.ExecuteScalar();
                    if (maxID == DBNull.Value)
                    {
                        nMaxComplainID = 1;
                    }
                    else
                    {
                        nMaxComplainID = Convert.ToInt32(maxID) + 1;
                    }
                    _nComplainID = nMaxComplainID;


                    sSql = "INSERT INTO t_CSDComplain(ComplainID,Complainer,ContactNo,"
                        + " ComplainerTypeID,SourceID,ComplainAgainstID,ComplainAgainstWhom,ComplainDetails,"
                        + " ReferanceJobNo,DateOccurred,ComplainCatID,CreateUserID,CreateDate,ComplainStatus,FurtherActionReqID,AssignEmployeeID,HappyCallStatusID"
                        + " ) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("ComplainID", _nComplainID);
                    cmd.Parameters.AddWithValue("Complainer", _sComplainer);
                    cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                    cmd.Parameters.AddWithValue("ComplainerTypeID", _nComplainerTypeID);
                    cmd.Parameters.AddWithValue("SourceID", _nSourceID);
                    cmd.Parameters.AddWithValue("ComplainAgainstID", _nComplainAgainstID);
                    cmd.Parameters.AddWithValue("ComplainAgainstWhom", _sComplainAgainstWhom);
                    cmd.Parameters.AddWithValue("ComplainDetails", _sComplainDetails);
                    cmd.Parameters.AddWithValue("ReferanceJobNo", _sReferanceJobNo);
                    cmd.Parameters.AddWithValue("DateOccurred", _dDateOccurred);
                    cmd.Parameters.AddWithValue("ComplainCatID", _nComplainCatID);
                    cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                    cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("ComplainStatus", _nComplainStatus);
                    cmd.Parameters.AddWithValue("FurtherActionReqID", (short)Dictionary.ComplainFurtherActionRequired.False);
                    cmd.Parameters.AddWithValue("AssignEmployeeID",_nAssignEmployeeID);
                    cmd.Parameters.AddWithValue("HappyCallStatusID", -1);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }

        public void EditComplain()
            {

                OleDbCommand cmd = DBController.Instance.GetCommand();

                try
                {

                    cmd.CommandText = "UPDATE t_CSDComplain SET Complainer=?,ContactNo=?,ComplainerTypeID=?,"
                        + " SourceID=?,ComplainAgainstID=?,ComplainAgainstWhom=?,ComplainDetails=?,"
                        + " ReferanceJobNo=?,DateOccurred=?,ComplainCatID=? WHERE ComplainID=?";

                    cmd.CommandType = CommandType.Text;


                    cmd.Parameters.AddWithValue("Complainer", _sComplainer);
                    cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                    cmd.Parameters.AddWithValue("ComplainerTypeID", _nComplainerTypeID);
                    cmd.Parameters.AddWithValue("SourceID", _nSourceID);
                    cmd.Parameters.AddWithValue("ComplainAgainstID", _nComplainAgainstID);
                    cmd.Parameters.AddWithValue("ComplainAgainstWhom", _sComplainAgainstWhom);
                    cmd.Parameters.AddWithValue("ComplainDetails", _sComplainDetails);
                    cmd.Parameters.AddWithValue("ReferanceJobNo", _sReferanceJobNo);
                    cmd.Parameters.AddWithValue("DateOccurred", _dDateOccurred);
                    cmd.Parameters.AddWithValue("ComplainCatID", _nComplainCatID);

                    cmd.Parameters.AddWithValue("ComplainID", _nComplainID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }

        public void UpdateAction()
            {

                OleDbCommand cmd = DBController.Instance.GetCommand();
                string sSql = "";
                try
                {

                    cmd.CommandText = "UPDATE t_CSDComplain SET ActionDetails=?,StatusID=?,ActionDate=?,UpdateUserID=?,UpdateDate=?,ComplainStatus=? WHERE ComplainID=?";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("ActionDetails", _sActionDetails);
                    cmd.Parameters.AddWithValue("StatusID", _nStatusID);
                    cmd.Parameters.AddWithValue("ActionDate", _dActionDate);
                    cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                    cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("ComplainStatus", _nComplainStatus);

                    cmd.Parameters.AddWithValue("ComplainID", _nComplainID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }

        public void UpdateActionEdit()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDComplain SET ActionDetails=?,StatusID=?,ActionDate=?,ComplainStatus=? WHERE ComplainID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ActionDetails", _sActionDetails);
                cmd.Parameters.AddWithValue("StatusID", _nStatusID);
                cmd.Parameters.AddWithValue("ActionDate", _dActionDate);
                cmd.Parameters.AddWithValue("ComplainStatus", _nComplainStatus);


                cmd.Parameters.AddWithValue("ComplainID", _nComplainID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateHappyCall()
            {

                OleDbCommand cmd = DBController.Instance.GetCommand();
                string sSql = "";
                try
                {

                    cmd.CommandText = "UPDATE t_CSDComplain SET HappyCallStatusID=?,HappyCallDetails=?,HappyCallDate=?, HappyCallUserID=?, ComplainStatus=?,FurtherActionReqID=? WHERE ComplainID=?";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("HappyCallStatusID", _nHappyCallStatusID);
                    cmd.Parameters.AddWithValue("HappyCallDetails", _sHappyCallDetails);
                    cmd.Parameters.AddWithValue("HappyCallDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("HappyCallUserID", Utility.UserId);
                    cmd.Parameters.AddWithValue("ComplainStatus", _nComplainStatus);
                    cmd.Parameters.AddWithValue("FurtherActionReqID",_nFurtherActionReqID);

                    cmd.Parameters.AddWithValue("ComplainID", _nComplainID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }

        public void UpdateHappyCallEdit()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDComplain SET HappyCallStatusID=?,HappyCallDetails=?,ComplainStatus=?,FurtherActionReqID=? WHERE ComplainID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("HappyCallStatusID", _nHappyCallStatusID);
                cmd.Parameters.AddWithValue("HappyCallDetails", _sHappyCallDetails);
                cmd.Parameters.AddWithValue("ComplainStatus", _nComplainStatus);
                cmd.Parameters.AddWithValue("FurtherActionReqID", _nFurtherActionReqID);

                cmd.Parameters.AddWithValue("ComplainID", _nComplainID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateAssignment()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDComplain SET AssignEmployeeID=?,AssignDate=?,ComplainStatus=? WHERE ComplainID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("AssignEmployeeID", _nAssignEmployeeID);
                cmd.Parameters.AddWithValue("AssignDate", DateTime.Now);
                cmd.Parameters.AddWithValue("ComplainStatus", (int)Dictionary.ComplainStatus.Assign);
                
                cmd.Parameters.AddWithValue("ComplainID", _nComplainID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateAssignmentEdit()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDComplain SET AssignEmployeeID=? WHERE ComplainID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("AssignEmployeeID", _nAssignEmployeeID);

                cmd.Parameters.AddWithValue("ComplainID", _nComplainID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void CancelComplain()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDComplain SET ComplainStatus=4 WHERE ComplainID=?";
                cmd.CommandType = CommandType.Text;

               cmd.Parameters.AddWithValue("ComplainID", _nComplainID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool CheckStatus()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDComplain where ComplainStatus=?";
            cmd.Parameters.AddWithValue("ComplainStatus", _nComplainStatus);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //_nComplainID = (int)reader["ComplainID"];
                    //_dStatusDate = Convert.ToDateTime(reader["StatusDate"].ToString());
                    //_nStatus = int.Parse(reader["Status"].ToString());
                    //_sRemarks = (string)reader["Remarks"];
                    //_nUserID = (int)reader["UserID"];
                    //_dDates = (Object)reader["Dates"].ToString();
                    //_dTimeFrom = (Object)reader["TimeFrom"].ToString();
                    //_dTimeTo = (Object)reader["TimeTo"].ToString();
                    _sActionDetails = (string)reader["ActionDetails"].ToString();
                    _nStatusID=int.Parse(reader["StatusID"].ToString());
                    _dActionDate = (Object)reader["ActionDate"].ToString();

                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
                return false;
            else return true;
        }

        public void Delete()
            {
                OleDbCommand cmd = DBController.Instance.GetCommand();

                try
                {
                    Complain oItem = new Complain();

                    cmd.CommandText = "DELETE FROM t_CSDComplainCategory WHERE [ComplainID]=?";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("ComplainID", _nComplainID);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "DELETE FROM t_CSDComplainType WHERE [ComplainID]=?";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("ComplainID", _nComplainID);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "DELETE FROM t_CSDComplain WHERE [ComplainID]=?";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("ComplainID", _nComplainID);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {

                    throw (ex);
                }
            }

        public void RefreshUser()
        {
            User.UserId = _nCreateUserID;
            User.RefreshByUserID();
        }
        }

        public class Complains : CollectionBase
        {
            public Complain this[int i]
            {
                get { return (Complain)InnerList[i]; }
                set { InnerList[i] = value; }
            }

            public void Add(Complain oComplain)
            {
                InnerList.Add(oComplain);
            }

            public void Refresh(DateTime dtFromDate, DateTime dtToDate, String txtComplainerName, String txtContactNo, String txtComplainNo, int nComplainStatus, String txtAssignto,String txtRefJob, String txtReceiveBy, int nComplainSource)//
            {
                dtToDate = dtToDate.Date.AddDays(1);
                
                InnerList.Clear();
                OleDbCommand cmd = DBController.Instance.GetCommand();

              string sSql = "SELECT C.ComplainID, Complainer, ContactNo, ComplainerTypeID, SourceID, ComplainAgainstID, ComplainAgainstWhom, "+
                            "ComplainDetails, IsNull(ReferanceJobNo,'Null')ReferanceJobNo, DateOccurred, ComplainCatID, ActionDetails, "+
                            "IsNull(ActionDate,Getdate())ActionDate, StatusID, CreateUserID, UU.UserName ReceiveBy,CreateDate, UpdateUserID, UpdateDate, AssignEmployeeID, AssignDate, HappyCallStatusID, " +
                            "HappyCallDetails,HappyCallDate,ComplainStatus, FurtherActionReqID, IsNull(E.EmployeeName,'NotAssign')AssignTo,IsNull(U.userFullName,'') HCallEmpl, "+
                            "IsNull(StatusID,-1)StatusID, ActionStatusName=Case When StatusID=0 THEN 'Solved' When StatusID=1 THEN 'Under Process' When StatusID=2 THEN 'Mgt. Action/Decision Req.' "+
                            "Else 'Action Not Taken' end,IsNull(Quality,0)Quality, IsNull(Commitment,0)Commitment, IsNull(Dealings,0)Dealings, "+
                            "IsNull(Performance,0)Performance, IsNull(Skill,0)Skill, IsNull(Price,0)Price, IsNull(Bill,0)Bill, "+
                            "IsNull(Dealing,0)Dealing,IsNull(HomeDelivery,0)HomeDelivery,IsNull(DemoInstall,0)DemoInstall,IsNull(Product,0)Product, "+
                            "IsNull(HomeCall,0)HomeCall,IsNull(WalkIn,0)WalkIn,IsNull(Installation,0)Installation,IsNull(Others,0)Others "+
                            "FROM t_CSDComplain C Left Outer JOIN t_Employee E ON C.AssignEmployeeID=E.EmployeeID " +
                            "INNER JOIN t_user UU ON C.CreateUserID=UU.UserID "+
                            "Left Outer JOIN t_user U ON C.HappyCallUserID=U.UserID "+
                            "Left Outer Join "+
                            "( "+
                            "Select * from "+
                            "( "+
                            "Select ComplainID, "+
                            "Sum(case ComplainCate when 'Quality' then 1  else 0 end) as Quality, "+
                            "Sum(case ComplainCate when 'Commitment' then 1  else 0 end) as Commitment, "+
                            "Sum(case ComplainCate when 'Dealings' then 1  else 0 end) as Dealings, "+
                            "Sum(case ComplainCate when 'Performance' then 1  else 0 end) as Performance, "+
                            "Sum(case ComplainCate when 'Skill' then 1  else 0 end) as Skill, "+
                            "Sum(case ComplainCate when 'Price' then 1  else 0 end) as Price, " +
                            "Sum(case ComplainCate when 'Bill' then 1  else 0 end) as Bill " +
                            "From "+
                            "( "+
                            "Select CT.ComplainID,ComplainCate=Case "+
                            "When ComplainTypeID=0 Then 'Quality' "+
                            "When ComplainTypeID=1 Then 'Commitment' "+
                            "When ComplainTypeID=2 Then 'Dealings' "+
                            "When ComplainTypeID=3 Then 'Performance' "+
                            "When ComplainTypeID=4 Then 'Skill' "+
                            "When ComplainTypeID=5 Then 'Price' "+
                            "When ComplainTypeID=6 Then 'Bill' "+
                            "End "+
                            "From t_CSDComplainType CT "+
                            "Inner Join t_CSDComplain C "+
                            "ON C.ComplainID=CT.ComplainID "+
                            ")A "+
                            "Group by ComplainID "+
                            ")B "+
                            ")H "+
                            "ON H.ComplainID=C.ComplainID "+
                            "Left Outer Join "+
                            "( "+
                            "Select * from "+
                            "( "+
                            "Select ComplainID,  "+
                            "Sum(case ComplainCate when 'Dealing' then 1  else 0 end) as Dealing, "+
                            "Sum(case ComplainCate when 'HomeDelivery' then 1  else 0 end) as HomeDelivery, "+
                            "Sum(case ComplainCate when 'Demo_Install' then 1  else 0 end) as DemoInstall, "+
                            "Sum(case ComplainCate when 'Product' then 1  else 0 end) as Product "+
                            "From "+
                            "( "+
                            "Select CC.ComplainID,ComplainCate=Case "+
                            "When ComplainSubCatID=0 Then 'Dealing' "+
                            "When ComplainSubCatID=1 Then 'HomeDelivery' "+
                            "When ComplainSubCatID=2 Then 'Demo_Install' "+
                            "When ComplainSubCatID=3 Then 'Product' "+
                            "End "+
                            "From t_CSDComplainCategory CC "+
                            "Inner Join t_CSDComplain C "+
                            "ON C.ComplainID=CC.ComplainID "+
                            "Where C.ComplainCatID=1 "+
                            ")A "+
                            "Group by ComplainID "+
                            ")B "+
                            ")F "+
                            "ON C.ComplainID=F.ComplainID "+
                            "Left Outer Join "+
                            "( "+
                            "Select * from "+
                            "( "+
                            "Select ComplainID, "+
                            "Sum(case ComplainCate when 'HomeCall' then 1  else 0 end) as HomeCall, "+
                            "Sum(case ComplainCate when 'WalkIn' then 1  else 0 end) as WalkIn, "+
                            "Sum(case ComplainCate when 'Installation' then 1  else 0 end) as Installation, "+
                            "Sum(case ComplainCate when 'Others' then 1  else 0 end) as Others "+
                            "From "+
                            "( "+
                            "Select CC.ComplainID,ComplainCate=Case "+
                            "When ComplainSubCatID=0 Then 'HomeCall' "+
                            "When ComplainSubCatID=1 Then 'WalkIn' "+
                            "When ComplainSubCatID=2 Then 'Installation' "+
                            "When ComplainSubCatID=3 Then 'Others' "+
                            "End "+
                            "From t_CSDComplainCategory CC "+
                            "Inner Join t_CSDComplain C "+
                            "ON C.ComplainID=CC.ComplainID "+
                            "Where C.ComplainCatID=2 "+
                            ")A "+
                            "Group by ComplainID "+
                            ")B "+
                            ")G "+
                            "ON C.ComplainID=G.ComplainID "+

                            "Where CreateDate BETWEEN'" + dtFromDate + "'AND '" + dtToDate + "' AND CreateDate < '" + dtToDate + "'";

                if (txtComplainNo != "")
                {
                    //txtComplainNo = "%" + txtComplainNo + "%";
                    sSql = sSql + " AND C.ComplainID ='" + txtComplainNo + "'";
                }
                if (nComplainStatus > -1)
                {
                    sSql = sSql + "AND ComplainStatus ='" + nComplainStatus + "'";
                }
                if (txtComplainerName != "")
                {
                    txtComplainerName = "%" + txtComplainerName + "%";
                    sSql = sSql + " AND Complainer LIKE '" + txtComplainerName + "'";
                }
                if (txtContactNo != "")
                {
                    txtContactNo = "%" + txtContactNo + "%";
                    sSql = sSql + " AND ContactNo LIKE '" + txtContactNo + "'";
                }
                if (txtAssignto != "")
                {
                    txtAssignto = "%" + txtAssignto + "%";
                    sSql = sSql + " AND EmployeeName LIKE '" + txtAssignto + "'";
                }
                if (txtRefJob != "")
                {
                    txtRefJob = "%" + txtRefJob + "%";
                    sSql = sSql + " AND ReferanceJobNo LIKE '" + txtRefJob + "'";
                }
                if (txtReceiveBy != "")
                {
                    txtReceiveBy = "%" + txtReceiveBy + "%";
                    sSql = sSql + " AND UU.UserName LIKE '" + txtReceiveBy + "'";
                }
                if (nComplainSource > -1)
                {
                    sSql = sSql + "AND ComplainerTypeID ='" + nComplainSource + "'";
                }
                sSql = sSql + " order by C.ComplainID ";
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
                        oComplain.ComplainAgainstWhom = (Object)reader["ComplainAgainstWhom"];
                        oComplain.ComplainDetails = (string)reader["ComplainDetails"];
                        oComplain.ReferanceJobNo = (Object)reader["ReferanceJobNo"];
                        oComplain.DateOccurred = Convert.ToDateTime(reader["DateOccurred"].ToString());
                        oComplain.ComplainCatID = (int)reader["ComplainCatID"];
                        oComplain.ActionDetails = (Object)reader["ActionDetails"];
                        oComplain.ActionDate = (Object)reader["ActionDate"].ToString();
                        //oComplain.ActionDate = Convert.ToDateTime(reader["ActionDate"].ToString());
                        //oComplain.StatusID = int.Parse(reader["StatusID"].ToString());
                        //oComplain.StatusID = (Object)reader["StatusID"];
                        oComplain.StatusName = (Object)reader["ActionStatusName"].ToString();
                        oComplain.CreateUserID = (int)reader["CreateUserID"];
                        oComplain.User.Username = (string)reader["ReceiveBy"];
                        oComplain.CreateDate = Convert.ToString(reader["CreateDate"]);
                        //oComplain.UpdateUserID = (int)reader["UpdateUserID"];
                        oComplain.UpdateDate = Convert.ToString(reader["UpdateDate"]);
                        oComplain.AssignEmployeeID = (int)reader["AssignEmployeeID"];
                        oComplain.AssignDate = Convert.ToString(reader["AssignDate"].ToString());
                        //oComplain.HappyCallStatusID = (int)reader["HappyCallStatusID"];
                        oComplain.HappyCallStatusID = int.Parse(reader["HappyCallStatusID"].ToString());
                        oComplain.HappyCallDetails = (Object)reader["HappyCallDetails"];
                        oComplain.HappyCallDate = Convert.ToString(reader["HappyCallDate"]);
                        oComplain.HappyCallUserName = (Object)reader["HCallEmpl"];
                        //oComplain.HappyCallUserID = (int)reader["HappyCallUserID"];
                        oComplain.ComplainStatus = int.Parse(reader["ComplainStatus"].ToString());
                        oComplain.FurtherActionReqID = int.Parse(reader["FurtherActionReqID"].ToString());
                        oComplain.Quality = (int)reader["Quality"];
                        oComplain.Commitment = (int)reader["Commitment"];
                        oComplain.Dealings = (int)reader["Dealings"];
                        oComplain.Performance = (int)reader["Performance"];
                        oComplain.Skill = (int)reader["Skill"];
                        oComplain.Price = (int)reader["Price"];
                        oComplain.Bill = (int)reader["Bill"];

                        oComplain.HomeCall = (int)reader["HomeCall"];
                        oComplain.WalkIn = (int)reader["WalkIn"];
                        oComplain.Installation = (int)reader["Installation"];
                        oComplain.Others = (int)reader["Others"];

                        oComplain.Dealing = (int)reader["Dealing"];
                        oComplain.HomeDelivery = (int)reader["HomeDelivery"];
                        oComplain.DemoInstall = (int)reader["DemoInstall"];
                        oComplain.Product = (int)reader["Product"];

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

            public void RefreshAll(String txtComplainerName, String txtContactNo, String txtComplainNo, int nComplainStatus, String txtAssignto, String txtRefJob, String txtReceiveBy, int nComplainSource)//
            {
                //dtToDate = dtToDate.Date.AddDays(1);

                InnerList.Clear();
                OleDbCommand cmd = DBController.Instance.GetCommand();


              string sSql = "SELECT C.ComplainID, Complainer, ContactNo, ComplainerTypeID, SourceID, ComplainAgainstID, ComplainAgainstWhom, " +
                            "ComplainDetails, IsNull(ReferanceJobNo,'Null')ReferanceJobNo, DateOccurred, ComplainCatID, ActionDetails, " +
                            "IsNull(ActionDate,getdate())ActionDate, StatusID, CreateUserID, UU.UserName ReceiveBy,CreateDate, UpdateUserID, UpdateDate, AssignEmployeeID, AssignDate, HappyCallStatusID, " +
                            "HappyCallDetails,HappyCallDate,ComplainStatus, FurtherActionReqID, IsNull(E.EmployeeName,'NotAssign')AssignTo,IsNull(U.userFullName,'') HCallEmpl, " +
                            "IsNull(StatusID,-1)StatusID, ActionStatusName=Case When StatusID=0 THEN 'Solved' When StatusID=1 THEN 'Under Process' When StatusID=2 THEN 'Mgt. Action/Decision Req.' " +
                            "Else 'Action Not Taken' end,IsNull(Quality,0)Quality, IsNull(Commitment,0)Commitment, IsNull(Dealings,0)Dealings, " +
                            "IsNull(Performance,0)Performance, IsNull(Skill,0)Skill, IsNull(Price,0)Price, IsNull(Bill,0)Bill, " +
                            "IsNull(Dealing,0)Dealing,IsNull(HomeDelivery,0)HomeDelivery,IsNull(DemoInstall,0)DemoInstall,IsNull(Product,0)Product, " +
                            "IsNull(HomeCall,0)HomeCall,IsNull(WalkIn,0)WalkIn,IsNull(Installation,0)Installation,IsNull(Others,0)Others " +
                            "FROM t_CSDComplain C Left Outer JOIN t_Employee E ON C.AssignEmployeeID=E.EmployeeID " +
                            "INNER JOIN t_user UU ON C.CreateUserID=UU.UserID " +
                            "Left Outer JOIN t_user U ON C.HappyCallUserID=U.UserID " +
                            "Left Outer Join " +
                            "( " +
                            "Select * from " +
                            "( " +
                            "Select ComplainID, " +
                            "Sum(case ComplainCate when 'Quality' then 1  else 0 end) as Quality, " +
                            "Sum(case ComplainCate when 'Commitment' then 1  else 0 end) as Commitment, " +
                            "Sum(case ComplainCate when 'Dealings' then 1  else 0 end) as Dealings, " +
                            "Sum(case ComplainCate when 'Performance' then 1  else 0 end) as Performance, " +
                            "Sum(case ComplainCate when 'Skill' then 1  else 0 end) as Skill, " +
                            "Sum(case ComplainCate when 'Price' then 1  else 0 end) as Price, " +
                            "Sum(case ComplainCate when 'Bill' then 1  else 0 end) as Bill " +
                            "From " +
                            "( " +
                            "Select CT.ComplainID,ComplainCate=Case " +
                            "When ComplainTypeID=0 Then 'Quality' " +
                            "When ComplainTypeID=1 Then 'Commitment' " +
                            "When ComplainTypeID=2 Then 'Dealings' " +
                            "When ComplainTypeID=3 Then 'Performance' " +
                            "When ComplainTypeID=4 Then 'Skill' " +
                            "When ComplainTypeID=5 Then 'Price' " +
                            "When ComplainTypeID=6 Then 'Bill' " +
                            "End " +
                            "From t_CSDComplainType CT " +
                            "Inner Join t_CSDComplain C " +
                            "ON C.ComplainID=CT.ComplainID " +
                            ")A " +
                            "Group by ComplainID " +
                            ")B " +
                            ")H " +
                            "ON H.ComplainID=C.ComplainID " +
                            "Left Outer Join " +
                            "( " +
                            "Select * from " +
                            "( " +
                            "Select ComplainID,  " +
                            "Sum(case ComplainCate when 'Dealing' then 1  else 0 end) as Dealing, " +
                            "Sum(case ComplainCate when 'HomeDelivery' then 1  else 0 end) as HomeDelivery, " +
                            "Sum(case ComplainCate when 'Demo_Install' then 1  else 0 end) as DemoInstall, " +
                            "Sum(case ComplainCate when 'Product' then 1  else 0 end) as Product " +
                            "From " +
                            "( " +
                            "Select CC.ComplainID,ComplainCate=Case " +
                            "When ComplainSubCatID=0 Then 'Dealing' " +
                            "When ComplainSubCatID=1 Then 'HomeDelivery' " +
                            "When ComplainSubCatID=2 Then 'Demo_Install' " +
                            "When ComplainSubCatID=3 Then 'Product' " +
                            "End " +
                            "From t_CSDComplainCategory CC " +
                            "Inner Join t_CSDComplain C " +
                            "ON C.ComplainID=CC.ComplainID " +
                            "Where C.ComplainCatID=1 " +
                            ")A " +
                            "Group by ComplainID " +
                            ")B " +
                            ")F " +
                            "ON C.ComplainID=F.ComplainID " +
                            "Left Outer Join " +
                            "( " +
                            "Select * from " +
                            "( " +
                            "Select ComplainID, " +
                            "Sum(case ComplainCate when 'HomeCall' then 1  else 0 end) as HomeCall, " +
                            "Sum(case ComplainCate when 'WalkIn' then 1  else 0 end) as WalkIn, " +
                            "Sum(case ComplainCate when 'Installation' then 1  else 0 end) as Installation, " +
                            "Sum(case ComplainCate when 'Others' then 1  else 0 end) as Others " +
                            "From " +
                            "( " +
                            "Select CC.ComplainID,ComplainCate=Case " +
                            "When ComplainSubCatID=0 Then 'HomeCall' " +
                            "When ComplainSubCatID=1 Then 'WalkIn' " +
                            "When ComplainSubCatID=2 Then 'Installation' " +
                            "When ComplainSubCatID=3 Then 'Others' " +
                            "End " +
                            "From t_CSDComplainCategory CC " +
                            "Inner Join t_CSDComplain C " +
                            "ON C.ComplainID=CC.ComplainID " +
                            "Where C.ComplainCatID=2 " +
                            ")A " +
                            "Group by ComplainID " +
                            ")B " +
                            ")G " +
                            "ON C.ComplainID=G.ComplainID " +

                            "Where C.ComplainID <>-1";

              if (txtComplainNo != "")
              {
                  //txtComplainNo = "%" + txtComplainNo + "%";
                  sSql = sSql + " AND C.ComplainID ='" + txtComplainNo + "'";
              }
              if (nComplainStatus > -1)
              {
                  sSql = sSql + "AND ComplainStatus ='" + nComplainStatus + "'";
              }
              if (txtComplainerName != "")
              {
                  txtComplainerName = "%" + txtComplainerName + "%";
                  sSql = sSql + " AND Complainer LIKE '" + txtComplainerName + "'";
              }
              if (txtContactNo != "")
              {
                  txtContactNo = "%" + txtContactNo + "%";
                  sSql = sSql + " AND ContactNo LIKE '" + txtContactNo + "'";
              }
              if (txtAssignto != "")
              {
                  txtAssignto = "%" + txtAssignto + "%";
                  sSql = sSql + " AND EmployeeName LIKE '" + txtAssignto + "'";
              }
              if (txtRefJob != "")
              {
                  txtRefJob = "%" + txtRefJob + "%";
                  sSql = sSql + " AND ReferanceJobNo LIKE '" + txtRefJob + "'";
              }
              if (txtReceiveBy != "")
              {
                  txtReceiveBy = "%" + txtReceiveBy + "%";
                  sSql = sSql + " AND UU.UserName LIKE '" + txtReceiveBy + "'";
              }
              if (nComplainSource > -1)
              {
                  sSql = sSql + "AND ComplainerTypeID ='" + nComplainSource + "'";
              }
              sSql = sSql + " order by C.ComplainID ";
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
                      oComplain.ComplainAgainstWhom = (Object)reader["ComplainAgainstWhom"];
                      oComplain.ComplainDetails = (string)reader["ComplainDetails"];
                      oComplain.ReferanceJobNo = (Object)reader["ReferanceJobNo"];
                      oComplain.DateOccurred = Convert.ToDateTime(reader["DateOccurred"].ToString());
                      oComplain.ComplainCatID = (int)reader["ComplainCatID"];
                      oComplain.ActionDetails = (Object)reader["ActionDetails"];
                      oComplain.ActionDate = (Object)reader["ActionDate"];
                      //oComplain.ActionDate = Convert.ToDateTime(reader["ActionDate"].ToString());
                      //oComplain.StatusID = int.Parse(reader["StatusID"].ToString());
                      //oComplain.StatusID = (Object)reader["StatusID"];
                      oComplain.StatusName = (Object)reader["ActionStatusName"].ToString();
                      oComplain.CreateUserID = (int)reader["CreateUserID"];
                      oComplain.User.Username = (string)reader["ReceiveBy"];
                      oComplain.CreateDate = Convert.ToString(reader["CreateDate"]);
                      //oComplain.UpdateUserID = (int)reader["UpdateUserID"];
                      oComplain.UpdateDate = Convert.ToString(reader["UpdateDate"]);
                      oComplain.AssignEmployeeID = (int)reader["AssignEmployeeID"];
                      oComplain.AssignDate = Convert.ToString(reader["AssignDate"].ToString());
                      //oComplain.HappyCallStatusID = (int)reader["HappyCallStatusID"];
                      oComplain.HappyCallStatusID = int.Parse(reader["HappyCallStatusID"].ToString());
                      oComplain.HappyCallDetails = (Object)reader["HappyCallDetails"];
                      oComplain.HappyCallDate = Convert.ToString(reader["HappyCallDate"]);
                      oComplain.HappyCallUserName = (Object)reader["HCallEmpl"];
                      //oComplain.HappyCallUserID = (int)reader["HappyCallUserID"];
                      oComplain.ComplainStatus = int.Parse(reader["ComplainStatus"].ToString());
                      oComplain.FurtherActionReqID = int.Parse(reader["FurtherActionReqID"].ToString());
                      oComplain.Quality = (int)reader["Quality"];
                      oComplain.Commitment = (int)reader["Commitment"];
                      oComplain.Dealings = (int)reader["Dealings"];
                      oComplain.Performance = (int)reader["Performance"];
                      oComplain.Skill = (int)reader["Skill"];
                      oComplain.Price = (int)reader["Price"];
                      oComplain.Bill = (int)reader["Bill"];

                      oComplain.HomeCall = (int)reader["HomeCall"];
                      oComplain.WalkIn = (int)reader["WalkIn"];
                      oComplain.Installation = (int)reader["Installation"];
                      oComplain.Others = (int)reader["Others"];

                      oComplain.Dealing = (int)reader["Dealing"];
                      oComplain.HomeDelivery = (int)reader["HomeDelivery"];
                      oComplain.DemoInstall = (int)reader["DemoInstall"];
                      oComplain.Product = (int)reader["Product"];

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

            public void RefreshProactive()//
            {
                //dtToDate = dtToDate.Date.AddDays(1);

                InnerList.Clear();
                OleDbCommand cmd = DBController.Instance.GetCommand();

                //string sSql = "SELECT ComplainID FROM t_CSDComplain Where convert(int,getdate()-AssignDate)>0";
                //

                string sSql = "Select final.ComplainID, final.AssignEmployeeID, Final.A From" +
                "(" +
                    //Before 1 Day
                "Select * from (Select ComplainID, AssignEmployeeID,(ActionDate-1)A  from t_CSDComplain Where StatusID IN (1,2))D " +
                "Where D.A Not IN (Select Holiday From t_HRHoliday)" +

                "UNION ALL" +
                    //If Holiday = 1 Day
                " Select F.ComplainID, AssignEmployeeID,(F.B-1)H from " +
                "(" +
                "Select * from (Select ComplainID, AssignEmployeeID,(ActionDate-1)B  from t_CSDComplain Where StatusID IN (1,2))D " +
                "Where D.B IN (Select Holiday From t_HRHoliday)" +
                ")F Where (F.B-1) Not IN (Select Holiday From t_HRHoliday)" +

                "UNION ALL" +
                    //If Holiday = 2 Days Continuously 
                " Select G.ComplainID, AssignEmployeeID,(G.H-1)H from" +
                "(" +
                "Select F.ComplainID, AssignEmployeeID,(F.B-1)H from " +
                "(" +
                "Select * from (Select ComplainID,AssignEmployeeID,(ActionDate-1)B  from t_CSDComplain Where StatusID IN (1,2))D " +
                "Where D.B IN (Select Holiday From t_HRHoliday)" +
                ")F Where (F.B-1) IN (Select Holiday From t_HRHoliday)" +
                ")G Where (G.H-1) Not IN (Select Holiday From t_HRHoliday)" +

                "UNION ALL" +
                    //If Holiday = 3 Days Continuously 
                " Select I.ComplainID, AssignEmployeeID,(I.I-1)J from" +
                "(" +
                "Select G.ComplainID, AssignEmployeeID,(G.H-1)I from" +
                "(" +
                "Select F.ComplainID, AssignEmployeeID,(F.B-1)H from " +
                "(" +
                "Select * from (Select ComplainID,AssignEmployeeID,(ActionDate-1)B  from t_CSDComplain Where StatusID IN (1,2))D " +
                "Where D.B IN (Select Holiday From t_HRHoliday)" +
                ")F Where (F.B-1) IN (Select Holiday From t_HRHoliday)" +
                ")G Where (G.H-1) IN (Select Holiday From t_HRHoliday)" +
                ")I Where (I.I-1) Not IN (Select Holiday From t_HRHoliday)" +

                "UNION ALL" +
                    //If Holiday = 4 Days Continuously 
                " Select J.ComplainID,AssignEmployeeID,(J.J-1)K from" +
                "(" +
                "Select I.ComplainID,AssignEmployeeID,(I.I-1)J from" +
                "(" +
                "Select G.ComplainID,AssignEmployeeID,(G.H-1)I from" +
                "(" +
                "Select F.ComplainID,AssignEmployeeID,(F.B-1)H from " +
                "(" +
                "Select * from (Select ComplainID,AssignEmployeeID,(ActionDate-1)B  from t_CSDComplain Where StatusID IN (1,2))D " +
                "Where D.B IN (Select Holiday From t_HRHoliday)" +
                ")F Where (F.B-1) IN (Select Holiday From t_HRHoliday)" +
                ")G Where (G.H-1) IN (Select Holiday From t_HRHoliday)" +
                ")I Where (I.I-1) IN (Select Holiday From t_HRHoliday)" +
                ")J Where (J.J-1) Not IN (Select Holiday From t_HRHoliday)" +

                "UNION ALL" +
                    //If Holiday = 5 Days Continuously 
                " Select K.ComplainID,AssignEmployeeID,(K.K-1)L from" +
                "(" +
                "Select J.ComplainID,AssignEmployeeID,(J.J-1)K from" +
                "(" +
                "Select I.ComplainID,AssignEmployeeID,(I.I-1)J from" +
                "(" +
                "Select G.ComplainID,AssignEmployeeID,(G.H-1)I from" +
                "(" +
                "Select F.ComplainID,AssignEmployeeID,(F.B-1)H from " +
                "(" +
                "Select * from (Select ComplainID, AssignEmployeeID,(ActionDate-1)B  from t_CSDComplain Where StatusID IN (1,2))D " +
                "Where D.B IN (Select Holiday From t_HRHoliday)" +
                ")F Where (F.B-1) IN (Select Holiday From t_HRHoliday)" +
                ")G Where (G.H-1) IN (Select Holiday From t_HRHoliday)" +
                ")I Where (I.I-1) IN (Select Holiday From t_HRHoliday)" +
                ")J Where (J.J-1) IN (Select Holiday From t_HRHoliday)" +
                ")K Where (K.K-1) Not IN (Select Holiday From t_HRHoliday)" +
                ")Final " +
                "Where CONVERT(DateTime, CONVERT(Char, GETDATE(),103),103)-A=0" +
                "Order by ComplainID";
                //

                try
                {
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Complain oComplain = new Complain();
                        oComplain.ComplainID = (int)reader["ComplainID"];
                        //oComplain.Complainer = (string)reader["Complainer"];
                        //oComplain.ContactNo = (string)reader["ContactNo"];
                        //oComplain.ComplainerTypeID = (int)reader["ComplainerTypeID"];
                        //oComplain.SourceID = (int)reader["SourceID"];
                        //oComplain.ComplainAgainstID = (int)reader["ComplainAgainstID"];
                        //oComplain.ComplainAgainstWhom = (string)reader["ComplainAgainstWhom"];
                        //oComplain.ComplainDetails = (string)reader["ComplainDetails"];
                        //oComplain.ReferanceJobNo = (string)reader["ReferanceJobNo"];
                        //oComplain.DateOccurred = Convert.ToDateTime(reader["DateOccurred"].ToString());
                        //oComplain.ComplainCatID = (int)reader["ComplainCatID"];
                        //oComplain.ActionDetails = (string)reader["ActionDetails"];
                        //oComplain.StatusID = (int)reader["StatusID"];
                        //oComplain.CreateUserID = (int)reader["CreateUserID"];
                        //oComplain.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                        //oComplain.UpdateUserID = (int)reader["UpdateUserID"];
                        //oComplain.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                        oComplain.AssignEmployeeID = (int)reader["AssignEmployeeID"];
                        //oComplain.AssignDate = Convert.ToDateTime(reader["AssignDate"].ToString());
                        //oComplain.HappyCallStatusID = (int)reader["HappyCallStatusID"];
                        //oComplain.HappyCallDetails = (string)reader["HappyCallDetails"];
                        //oComplain.HappyCallDate = Convert.ToDateTime(reader["HappyCallDate"].ToString());
                        //oComplain.HappyCallUserID = (int)reader["HappyCallUserID"];
                        //oComplain.ComplainStatus = int.Parse(reader["ComplainStatus"].ToString());
                        //oComplain.FurtherActionReqID = int.Parse(reader["FurtherActionReqID"].ToString());

                        //oComplain.RefreshUser();
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