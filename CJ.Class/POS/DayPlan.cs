// <summary>
// Compamy: Transcom Electronics Limited
// Author: Khandakar Ali Ifran
// Date: Jan 14, 2020
// Time : 05:07 PM
// Description: Class for DayPlan.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;
using CJ.Class.POS;

namespace CJ.Class.POS
{
    public class DayPlanDetails
    {
        private int _nID;
        private DateTime _dPlanDate;
        private DateTime _dTimeFrom;
        private DateTime _dTimeTo;
        private int _nPlanTo;
        private int _nPurposeId;
        private int _nActionStatusId;
        private string _sAddress;
        private int _nCustomerId;
        private string _sRemarks;
        private int _nVisitTypeID;
        private string _sActionStatus;
        private string _sCustomerName;
        private string _sPlanType;
        private string _sPlanPurpose;

        private int _nDayPlanID;
        public int DayPlanID
        {
            get { return _nDayPlanID; }
            set { _nDayPlanID = value; }
        }

        public string ActionStatus
        {
            get { return _sActionStatus; }
            set { _sActionStatus = value; }
        }
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
        public string PlanType
        {
            get { return _sPlanType; }
            set { _sPlanType = value; }
        }
        public string PlanPurpose
        {
            get { return _sPlanPurpose; }
            set { _sPlanPurpose = value; }
        }
        public int VisitTypeID
        {
            get { return _nVisitTypeID; }
            set { _nVisitTypeID = value; }
        }

        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }
        
        // <summary>
        // Get set property for QuotationID
        // </summary>
        public DateTime PlanDate
        {
            get { return _dPlanDate; }
            set { _dPlanDate = value; }
        }

        // <summary>
        // Get set property for BrandID
        // </summary>
        public DateTime TimeFrom
        {
            get { return _dTimeFrom; }
            set { _dTimeFrom = value; }
        }

        // <summary>
        // Get set property for MAGName
        // </summary>
        public DateTime TimeTo
        {
            get { return _dTimeTo; }
            set { _dTimeTo = value; }
        }


        public int PlanTo
        {
            get { return _nPlanTo; }
            set { _nPlanTo = value; }
        }

        // <summary>
        // Get set property for Model
        // </summary>
        public int PurposeId
        {
            get { return _nPurposeId; }
            set { _nPurposeId = value; }
        }

        // <summary>
        // Get set property for Qty
        // </summary>
        public int ActionStatusId
        {
            get { return _nActionStatusId; }
            set { _nActionStatusId = value; }
        }

        // <summary>
        // Get set property for Ton
        // </summary>
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value; }
        }
        // <summary>
        // Get set property for Qty
        // </summary>
        public int CustomerId
        {
            get { return _nCustomerId; }
            set { _nCustomerId = value; }
        }

        // <summary>
        // Get set property for Ton
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }

        public void Add(int _nPlanId)
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_DayPlanDetails";
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
                sSql = "INSERT INTO t_DayPlanDetails (ID, PlanId, PlanDate, TimeFrom, TimeTo, PlanTo, PurposeId,	ActionStatus, Address, CustomerId, Remarks) VALUES(?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("PlanId", _nPlanId);
                cmd.Parameters.AddWithValue("PlanDate", _dPlanDate);
                cmd.Parameters.AddWithValue("TimeFrom", _dTimeFrom);
                cmd.Parameters.AddWithValue("TimeTo", _dTimeTo);
                cmd.Parameters.AddWithValue("PlanTo", _nPlanTo);
                cmd.Parameters.AddWithValue("PurposeId", _nPurposeId);
                cmd.Parameters.AddWithValue("ActionStatus", _nActionStatusId);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("CustomerId", _nCustomerId);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Delete(int nPlanId)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from  t_DayPlanDetails Where PlanId=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PlanId", nPlanId);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

    }

    public class DayPlan : CollectionBase
    {

        public DayPlanDetails this[int i]
        {
            get { return (DayPlanDetails)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DayPlanDetails oDayPlanDetails)
        {
            InnerList.Add(oDayPlanDetails);
        }
        
        private int _nPlanId;
        private string _sPlanNo;
        private int _nEmployeeId;
        private int _nLocationId;
        private int _nStatus;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserId;
        private DateTime? _dUpdateDate;
        private string _sEmployeeName;
        private string _sLocationName;
        SystemInfo _oSystemInfo;
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value.Trim(); }
        }
        public string LocationName
        {
            get { return _sLocationName; }
            set { _sLocationName = value.Trim(); }
        }



        // <summary>
        // Get set property for PlanId
        // </summary>
        public int PlanId
        {
            get { return _nPlanId; }
            set { _nPlanId = value; }
        }

        // <summary>
        // Get set property for BarcodeSL
        // </summary>
        public string PlanNo
        {
            get { return _sPlanNo; }
            set { _sPlanNo = value.Trim(); }
        }

        public int EmployeeId
        {
            get { return _nEmployeeId; }
            set { _nEmployeeId = value; }
        }

        public int LocationId
        {
            get { return _nLocationId; }
            set { _nLocationId = value; }
        }

        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

                
        public int CreateUserId
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }
        

        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        public int UpdateUserId
        {
            get { return _nUpdateUserId; }
            set { _nUpdateUserId = value; }
        }


        public DateTime? UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }


        private int _nVisitPlanId;
        public int VisitPlanId
        {
            get { return _nVisitPlanId; }
            set { _nVisitPlanId = value; }
        }

        private string _sPlanDescription;
        public string PlanDescription
        {
            get { return _sPlanDescription; }
            set { _sPlanDescription = value.Trim(); }
        }

       


        public void Add()
        {
            _oSystemInfo = new SystemInfo();
            _oSystemInfo.Refresh();

            int nMaxPlanID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([PlanId]) FROM t_DayPlan";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxPlanID = 1;
                }
                else
                {
                    nMaxPlanID = Convert.ToInt32(maxID) + 1;
                }
                _nPlanId = nMaxPlanID;
                _sPlanNo = "P-" + DateTime.Today.ToString("yy") + DateTime.Today.ToString("MM") + "-" + _oSystemInfo.Shortcode +"-"+ _nPlanId.ToString("000");

                sSql = "INSERT INTO t_DayPlan (PlanId,	PlanNo,	EmployeeId,	LocationId,	Status,	CreateUserId,	CreateDate,	UpdateUserId,	UpdateDate, SentFrom) VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PlanId", _nPlanId);
                cmd.Parameters.AddWithValue("PlanNo", _sPlanNo);
                cmd.Parameters.AddWithValue("EmployeeId", _nEmployeeId);
                cmd.Parameters.AddWithValue("LocationId", _nLocationId);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserId", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserId", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("SentFrom", (int)Dictionary.SentFrom.Desktop);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (DayPlanDetails oDayPlanDetails in this)
                {
                    oDayPlanDetails.Add(_nPlanId);
                }

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
                sSql = "UPDATE t_DayPlan SET EmployeeId = ?, LocationId = ?, Status = ?,UpdateUserId = ?, UpdateDate = ? WHERE PlanId = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                
                cmd.Parameters.AddWithValue("EmployeeId", _nEmployeeId);
                cmd.Parameters.AddWithValue("LocationId", _nLocationId);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("UpdateUserId", _nUpdateUserId);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("PlanId", _nPlanId);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                
                DayPlanDetails oDPD = new DayPlanDetails();
                oDPD.Delete(_nPlanId);
                

                foreach (DayPlanDetails oDayPlanDetails in this)
                {
                    oDayPlanDetails.Add(_nPlanId);
                }
                                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void RefreshDetails(int nPlanId)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT ID,PlanDate,TimeFrom,TimeTo,PlanTo,a.PurposeId,ActionStatus ActionStatusId,Address,a.CustomerId,Remarks,PlanDescription [PlanType], Description [PlanPurpose], case when ActionStatus=1 then 'Create' else 'Des' end as Status, d.CustomerCode,d.CustomerName FROM t_DayPlanDetails a left join t_VisitPlanType b on a.PlanTo=b.PlanId left join t_DayPlanPurpose c on a.PurposeId=c.PurposeID left join v_CustomerDetails d on d.CustomerID=a.CustomerId where a.PlanId=" + nPlanId + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DayPlanDetails oDPD = new DayPlanDetails();
                    oDPD.ID = (int)reader["ID"];
                    oDPD.PlanDate = (DateTime)reader["PlanDate"];
                    oDPD.TimeFrom = (DateTime)reader["TimeFrom"];
                    oDPD.TimeTo = (DateTime)reader["TimeTo"];
                    oDPD.PlanTo = (int)reader["PlanTo"];
                    oDPD.PurposeId = (int)reader["PurposeId"];
                    oDPD.Remarks = reader["Remarks"].ToString();
                    if(reader["ActionStatusId"]!=null)
                    oDPD.ActionStatusId= (int)reader["ActionStatusId"];
                    oDPD.Address = reader["Address"].ToString();
                    oDPD.CustomerId = (int)reader["CustomerId"];
                    oDPD.PlanType = reader["PlanType"].ToString();
                    oDPD.PlanPurpose = reader["PlanPurpose"].ToString();
                    oDPD.CustomerName = reader["CustomerName"].ToString();
                    oDPD.ActionStatus = reader["Status"].ToString();

                    InnerList.Add(oDPD);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshDetailsRT(int nPlanId)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT ID,PlanDate,TimeFrom,TimeTo,PlanTo,a.PurposeId,ActionStatus ActionStatusId,Address,  "+
                          "a.CustomerId,Remarks,PlanDescription [PlanType], Description [PlanPurpose], "+
                          "case when ActionStatus=1 then 'Create' else 'Des' end as Status, d.CustomerCode,d.CustomerName "+
                          "FROM (Select b.* From t_DayPlan a,t_DayPlanDetails b " +
                          "where a.PlanId = b.PlanId and a.LocationId = " + Utility.LocationID + ") a "+
                          "left join t_VisitPlanType b on a.PlanTo=b.PlanId left join t_DayPlanPurpose c "+
                          "on a.PurposeId=c.PurposeID left join v_CustomerDetails d on d.CustomerID=a.CustomerId "+
                          "where a.PlanId=" + nPlanId + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DayPlanDetails oDPD = new DayPlanDetails();
                    oDPD.ID = (int)reader["ID"];
                    oDPD.PlanDate = (DateTime)reader["PlanDate"];
                    oDPD.TimeFrom = (DateTime)reader["TimeFrom"];
                    oDPD.TimeTo = (DateTime)reader["TimeTo"];
                    oDPD.PlanTo = (int)reader["PlanTo"];
                    oDPD.PurposeId = (int)reader["PurposeId"];
                    oDPD.Remarks = reader["Remarks"].ToString();
                    if (reader["ActionStatusId"] != null)
                        oDPD.ActionStatusId = (int)reader["ActionStatusId"];
                    oDPD.Address = reader["Address"].ToString();
                    oDPD.CustomerId = (int)reader["CustomerId"];
                    oDPD.PlanType = reader["PlanType"].ToString();
                    oDPD.PlanPurpose = reader["PlanPurpose"].ToString();
                    oDPD.CustomerName = reader["CustomerName"].ToString();
                    oDPD.ActionStatus = reader["Status"].ToString();

                    InnerList.Add(oDPD);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddForWeb()
        {
            //OleDbCommand cmd = DBController.Instance.GetCommand();
            //string sSql = "";
            //try
            //{
            int nMaxPlanID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([PlanId]) FROM t_DayPlan";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxPlanID = 1;
                }
                else
                {
                    nMaxPlanID = Convert.ToInt32(maxID) + 1;
                }
                _nPlanId = nMaxPlanID;


                sSql = "INSERT INTO t_DayPlan (PlanId,	PlanNo,	EmployeeId,	LocationId,	Status,	CreateUserId,	CreateDate,	UpdateUserId,	UpdateDate, SentFrom) VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PlanId", _nPlanId);
                cmd.Parameters.AddWithValue("PlanNo", _sPlanNo);
                cmd.Parameters.AddWithValue("EmployeeId", _nEmployeeId);
                cmd.Parameters.AddWithValue("LocationId", _nLocationId);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserId);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("SentFrom", (int)Dictionary.SentFrom.Desktop);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (DayPlanDetails oItem in this)
                {
                    oItem.Add(_nPlanId);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshDayPlanDetailForDataSending()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_DayPlanDetails where PlanId=? ";
                cmd.Parameters.AddWithValue("PlanId", _nPlanId);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DayPlanDetails oDayPlanDetails = new DayPlanDetails();

                    oDayPlanDetails.ID = int.Parse(reader["ID"].ToString()); ;
                    oDayPlanDetails.DayPlanID = int.Parse(reader["PlanId"].ToString()); ;
                    oDayPlanDetails.PlanDate = DateTime.Parse(reader["PlanDate"].ToString());
                    oDayPlanDetails.TimeFrom = DateTime.Parse(reader["TimeFrom"].ToString());
                    oDayPlanDetails.TimeTo = DateTime.Parse(reader["TimeTo"].ToString());
                    oDayPlanDetails.PlanTo = (int)reader["PlanTo"];
                    oDayPlanDetails.PurposeId = (int)reader["PurposeId"];
                    oDayPlanDetails.ActionStatusId = int.Parse(reader["ActionStatus"].ToString()); ;
                    oDayPlanDetails.Address = reader["Address"].ToString();
                    oDayPlanDetails.CustomerId = (int)reader["CustomerId"];
                    oDayPlanDetails.Remarks = (string)reader["Remarks"];



                    InnerList.Add(oDayPlanDetails);
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
    public class DayPlans : CollectionBase
    {
        public DayPlan this[int i]
        {
            get { return (DayPlan)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DayPlan oDayPlan)
        {
            InnerList.Add(oDayPlan);
        }
        public int GetIndex(int nPlanId)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].PlanId == nPlanId)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(string sDayPlanNo, int nEmployeeId, DateTime? dFromDate, DateTime? dToDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select distinct P.PlanId,PlanNo,P.EmployeeId,P.LocationId,P.Status,CreateUserId,CreateDate,EmployeeName,LocationName from t_DayPlan P left join t_DayPlanDetails Q on P.PlanId=Q.PlanId left join t_Employee R on P.EmployeeId=R.EmployeeID WHERE 1=1";
            if(sDayPlanNo!="")
            {
                sSql = sSql + " and PlanNo='"+ sDayPlanNo + "' ";
            }
            if (nEmployeeId>0)
            {
                sSql = sSql + " and P.EmployeeId=" + nEmployeeId + " ";
            }
            if(dFromDate!=null&& dToDate!=null)
            {
                sSql = sSql + " and Q.PlanDate between '"+ dFromDate+"' and '"+dToDate+"'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DayPlan oDayPlan = new DayPlan();
                    oDayPlan.PlanId = (int)reader["PlanId"];
                    oDayPlan.PlanNo = (string)reader["PlanNo"];
                    oDayPlan.EmployeeId = (int)reader["EmployeeId"];
                    oDayPlan.LocationId = (int)reader["LocationId"];
                    oDayPlan.Status = (int)reader["Status"];
                    oDayPlan.CreateUserId = (int)reader["CreateUserId"];
                    oDayPlan.CreateDate = (DateTime)reader["CreateDate"];
                    oDayPlan.EmployeeName = (string)reader["EmployeeName"];
                    oDayPlan.LocationName = (string)reader["LocationName"];

                    InnerList.Add(oDayPlan);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshRT(string sDayPlanNo, int nEmployeeId, DateTime? dFromDate, DateTime? dToDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select distinct P.PlanId,PlanNo,P.EmployeeId,P.LocationId,P.Status,CreateUserId,CreateDate,EmployeeName,JobLocationName as LocationName from t_DayPlan P left join t_DayPlanDetails Q on P.PlanId=Q.PlanId left join v_EmployeeDetails R on P.EmployeeId=R.EmployeeID WHERE P.LocationId=" + Utility.LocationID + "";
            if (sDayPlanNo != "")
            {
                sSql = sSql + " and PlanNo='" + sDayPlanNo + "' ";
            }
            if (nEmployeeId > 0)
            {
                sSql = sSql + " and P.EmployeeId=" + nEmployeeId + " ";
            }
            if (dFromDate != null && dToDate != null)
            {
                sSql = sSql + " and Q.PlanDate between '" + dFromDate + "' and '" + dToDate + "'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DayPlan oDayPlan = new DayPlan();
                    oDayPlan.PlanId = (int)reader["PlanId"];
                    oDayPlan.PlanNo = (string)reader["PlanNo"];
                    oDayPlan.EmployeeId = (int)reader["EmployeeId"];
                    oDayPlan.LocationId = (int)reader["LocationId"];
                    oDayPlan.Status = (int)reader["Status"];
                    oDayPlan.CreateUserId = (int)reader["CreateUserId"];
                    oDayPlan.CreateDate = (DateTime)reader["CreateDate"];
                    oDayPlan.EmployeeName = (string)reader["EmployeeName"];
                    oDayPlan.LocationName = (string)reader["LocationName"];

                    InnerList.Add(oDayPlan);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetVisitPlanType()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_VisitPlanType";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DayPlan oDayPlan = new DayPlan();
                    oDayPlan.VisitPlanId = (int)reader["PlanId"];
                    oDayPlan.PlanDescription = (string)reader["PlanDescription"];

                    InnerList.Add(oDayPlan);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetDayPlanPurpose()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DayPlanPurpose where IsActive=1";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DayPlan oDayPlan = new DayPlan();
                    oDayPlan.VisitPlanId = (int)reader["PurposeID"];
                    oDayPlan.PlanDescription = (string)reader["Description"]; 

                    InnerList.Add(oDayPlan);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshForDataSendingDayPlan(int nWarehouseID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DayPlan a inner join t_DataTransfer b on b.DataID=a.PlanId "
                          + " where b.TableName=? and "
                          + " b.IsDownload= ? and b.WarehouseID= ? ";

            cmd.Parameters.AddWithValue("TableName", "t_DayPlan");
            cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DayPlan oDayPlan = new DayPlan();

                    oDayPlan.PlanId = Convert.ToInt32(reader["PlanId"]);
                    oDayPlan.PlanNo = reader["PlanNo"].ToString();
                    oDayPlan.EmployeeId = (int)reader["EmployeeId"];
                    oDayPlan.LocationId = (int)reader["LocationId"];
                    oDayPlan.Status = (int)(reader["Status"]);
                    oDayPlan.CreateUserId = Convert.ToInt32(reader["CreateUserId"]);
                    oDayPlan.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                    if (reader["UpdateUserId"] != DBNull.Value)
                        oDayPlan.UpdateUserId = Convert.ToInt32(reader["UpdateUserId"]);
                    if (reader["UpdateDate"] != DBNull.Value)
                        oDayPlan.UpdateDate = Convert.ToDateTime(reader["UpdateDate"]);
                    else
                        oDayPlan.UpdateDate = null;


                    oDayPlan.RefreshDayPlanDetailForDataSending();

                    InnerList.Add(oDayPlan);

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
