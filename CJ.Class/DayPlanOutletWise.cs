// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Apr 07, 2020
// Time : 11:37 AM
// Description: Class for DayPlanOutletWise.
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
    public class DayPlanOutletWise
    {
        private int _nPlanId;
        private string _sPlanNo;
        private int _nEmployeeId;
        private int _nLocationId;
        private int _nStatus;
        private int _nCreateUserId;
        private DateTime _dCreateDate;
        private int _nUpdateUserId;
        private DateTime _dUpdateDate;
        private int _nSentFrom;
        private int _nApproveUserId;
        private DateTime _dApproveDate;
        private DateTime _dPlanDate;
        private string _sEmployeeCode;
        private string _sEmployeename;
        private string _sEmployeeType;
        private string _sShowroomCode;
        private string _sTerritoryName;
        private string _sAreaName;
        private int _PlanQty;
        private int _checkinQty;
        private int _LeadQty;
        private double _LeadValue;
        private object _TimeForm;
        private object _TimeTo;
        private string _sPlanDescription;
        private string _sCustomerName;
        private string _sCustomeraddress;
        private string _sRemarks;



        // <summary>
        // Get set property for PlanId
        // </summary>
        public int PlanId
        {
            get { return _nPlanId; }
            set { _nPlanId = value; }
        }

        // <summary>
        // Get set property for PlanNo
        // </summary>
        public string PlanNo
        {
            get { return _sPlanNo; }
            set { _sPlanNo = value.Trim(); }
        }
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value.Trim(); }
        }
        public string Employeename
        {
            get { return _sEmployeename; }
            set { _sEmployeename = value.Trim(); }
        }
        public string EmployeeType
        {
            get { return _sEmployeeType; }
            set { _sEmployeeType = value.Trim(); }
        }
        public string ShowroomCode
        {
            get { return _sShowroomCode; }
            set { _sShowroomCode = value.Trim(); }
        }
        public string TerritoryName
        {
            get { return _sTerritoryName; }
            set { _sTerritoryName = value.Trim(); }
        }
        public string AreaName
        {
            get { return _sAreaName; }
            set { _sAreaName = value.Trim(); }
        }
        // <summary>
        // Get set property for EmployeeId
        // </summary>
        public int EmployeeId
        {
            get { return _nEmployeeId; }
            set { _nEmployeeId = value; }
        }
        public int PlanQty
        {
            get { return _PlanQty; }
            set { _PlanQty = value; }
        }
        public int checkinQty
        {
            get { return _checkinQty; }
            set { _checkinQty = value; }
        }
        public int LeadQty
        {
            get { return _LeadQty; }
            set { _LeadQty = value; }
        }
        public double LeadValue
        {
            get { return _LeadValue; }
            set { _LeadValue = value; }
        }
        // <summary>
        // Get set property for LocationId
        // </summary>
        public int LocationId
        {
            get { return _nLocationId; }
            set { _nLocationId = value; }
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
        // Get set property for CreateUserId
        // </summary>
        public int CreateUserId
        {
            get { return _nCreateUserId; }
            set { _nCreateUserId = value; }
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
        // Get set property for UpdateUserId
        // </summary>
        public int UpdateUserId
        {
            get { return _nUpdateUserId; }
            set { _nUpdateUserId = value; }
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
        // Get set property for SentFrom
        // </summary>
        public int SentFrom
        {
            get { return _nSentFrom; }
            set { _nSentFrom = value; }
        }

        // <summary>
        // Get set property for ApproveUserId
        // </summary>
        public int ApproveUserId
        {
            get { return _nApproveUserId; }
            set { _nApproveUserId = value; }
        }

        // <summary>
        // Get set property for ApproveDate
        // </summary>
        public DateTime ApproveDate
        {
            get { return _dApproveDate; }
            set { _dApproveDate = value; }
        }
        public DateTime PlanDate
        {
            get { return _dPlanDate; }
            set { _dPlanDate = value; }
        }
        public object TimeForm
        {
            get { return _TimeForm; }
            set { _TimeForm = value; }
        }
        public object TimeTo
        {
            get { return _TimeTo; }
            set { _TimeTo = value; }
        }
        public string PlanDescription
        {
            get { return _sPlanDescription; }
            set { _sPlanDescription = value.Trim(); }
        }
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }
        public string Customeraddress
        {
            get { return _sCustomeraddress; }
            set { _sCustomeraddress = value.Trim(); }
        }
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }
        public void Add()
        {
            int nMaxPlanId = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([PlanId]) FROM t_DayPlanOutletWise";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxPlanId = 1;
                }
                else
                {
                    nMaxPlanId = Convert.ToInt32(maxID) + 1;
                }
                _nPlanId = nMaxPlanId;
                sSql = "INSERT INTO t_DayPlanOutletWise (PlanId, PlanNo, EmployeeId, LocationId, Status, CreateUserId, CreateDate, UpdateUserId, UpdateDate, SentFrom, ApproveUserId, ApproveDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PlanId", _nPlanId);
                cmd.Parameters.AddWithValue("PlanNo", _sPlanNo);
                cmd.Parameters.AddWithValue("EmployeeId", _nEmployeeId);
                cmd.Parameters.AddWithValue("LocationId", _nLocationId);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserId", _nCreateUserId);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserId", _nUpdateUserId);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("SentFrom", _nSentFrom);
                cmd.Parameters.AddWithValue("ApproveUserId", _nApproveUserId);
                cmd.Parameters.AddWithValue("ApproveDate", _dApproveDate);

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
                sSql = "UPDATE t_DayPlanOutletWise SET PlanNo = ?, EmployeeId = ?, LocationId = ?, Status = ?, CreateUserId = ?, CreateDate = ?, UpdateUserId = ?, UpdateDate = ?, SentFrom = ?, ApproveUserId = ?, ApproveDate = ? WHERE PlanId = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PlanNo", _sPlanNo);
                cmd.Parameters.AddWithValue("EmployeeId", _nEmployeeId);
                cmd.Parameters.AddWithValue("LocationId", _nLocationId);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserId", _nCreateUserId);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserId", _nUpdateUserId);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("SentFrom", _nSentFrom);
                cmd.Parameters.AddWithValue("ApproveUserId", _nApproveUserId);
                cmd.Parameters.AddWithValue("ApproveDate", _dApproveDate);

                cmd.Parameters.AddWithValue("PlanId", _nPlanId);

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
                sSql = "DELETE FROM t_DayPlanOutletWise WHERE [PlanId]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PlanId", _nPlanId);
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
                cmd.CommandText = "SELECT * FROM t_DayPlanOutletWise where PlanId =?";
                cmd.Parameters.AddWithValue("PlanId", _nPlanId);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPlanId = (int)reader["PlanId"];
                    _sPlanNo = (string)reader["PlanNo"];
                    _nEmployeeId = (int)reader["EmployeeId"];
                    _nLocationId = (int)reader["LocationId"];
                    _nStatus = (int)reader["Status"];
                    _nCreateUserId = (int)reader["CreateUserId"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nUpdateUserId = (int)reader["UpdateUserId"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    _nSentFrom = (int)reader["SentFrom"];
                    _nApproveUserId = (int)reader["ApproveUserId"];
                    _dApproveDate = Convert.ToDateTime(reader["ApproveDate"].ToString());
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
    public class DayPlanOutletWises : CollectionBase
    {
        public DayPlanOutletWise this[int i]
        {
            get { return (DayPlanOutletWise)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DayPlanOutletWise oDayPlanOutletWise)
        {
            InnerList.Add(oDayPlanOutletWise);
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
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DayPlanOutletWise";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DayPlanOutletWise oDayPlanOutletWise = new DayPlanOutletWise();
                    oDayPlanOutletWise.PlanId = (int)reader["PlanId"];
                    oDayPlanOutletWise.PlanNo = (string)reader["PlanNo"];
                    oDayPlanOutletWise.EmployeeId = (int)reader["EmployeeId"];
                    oDayPlanOutletWise.LocationId = (int)reader["LocationId"];
                    oDayPlanOutletWise.Status = (int)reader["Status"];
                    oDayPlanOutletWise.CreateUserId = (int)reader["CreateUserId"];
                    oDayPlanOutletWise.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oDayPlanOutletWise.UpdateUserId = (int)reader["UpdateUserId"];
                    oDayPlanOutletWise.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    oDayPlanOutletWise.SentFrom = (int)reader["SentFrom"];
                    oDayPlanOutletWise.ApproveUserId = (int)reader["ApproveUserId"];
                    oDayPlanOutletWise.ApproveDate = Convert.ToDateTime(reader["ApproveDate"].ToString());
                    InnerList.Add(oDayPlanOutletWise);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByDayPlanOutletWise(DateTime dFromDate, DateTime dToDate,string sArea,string sTerritory,string sShowroomCode,string sEmployeeType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);
            string sSql = "Select Date PlanDate,EmployeeCode,EmployeeName,EmployeeType, " +
                            "ShowroomCode,TerritoryName,AreaName, " +
                            "isnull(PlanQty,0) PlanQty,isnull(CheckinQty,0) CheckinQty,isnull(LeadQty,0) LeadQty,isnull(LeadValue,0) LeadValue From  " +
                            "( " +
                            "Select dt as Date,OutletEmployeeID,EmployeeType From  " +
                            "( " +
                            "Select * From dbo.ExplodeDates('01-Jan-2020','01-Apr-2020') " +
                            "Union All " +
                            "Select * From dbo.ExplodeDates('02-Apr-2020','01-Jul-2020') " +
                            "Union All " +
                            "Select * From dbo.ExplodeDates('02-Jul-2020','01-Oct-2020') " +
                            "Union All " +
                            "Select * From dbo.ExplodeDates('02-Oct-2020','31-Dec-2020') " +
                            ") a,(Select distinct OutletEmployeeID,case when OutletEmployeeType=1 then 'Manager' " +
                            "when OutletEmployeeType=2 then 'Executive' " +
                            "when OutletEmployeeType=1 then 'ShopAssistant ' " +
                            "when OutletEmployeeType=1 then 'SPC' " +
                            "when OutletEmployeeType=1 then 'HPC' " +
                            "else 'Other' end  EmployeeType From t_OutletEmployee where IsActive=1) b " +

                            ") Dt " +
                            "inner join " +
                            "( " +
                            "Select EmployeeID,EmployeeCode,EmployeeName,ShowroomName,ShowroomCode,c.TerritoryName,c.AreaName  " +
                            "From t_Employee a,t_Showroom b, " +
                            "(Select CustomerID,b.MarketGroupDesc as TerritoryName,c.MarketGroupDesc as AreaName " +
                            "From t_Customer a,t_MarketGroup b,t_MarketGroup c " +
                            "where a.MarketGroupID=b.MarketGroupID and b.ParentID=c.MarketGroupID " +
                            ") c " +
                            "where a.LocationID=b.LocationID and b.CustomerID=c.CustomerID and a.EMPStatus in(1,2) " +
                            ") emp " +
                            "on dt.OutletEmployeeID=emp.EmployeeID " +
                            "Left Outer Join " +
                            "( " +

                            "Select EmployeeId,PlanDate,sum(PlanQty) PlanQty, " +
                            "sum(CheckinQty) CheckinQty,sum(LeadQty) LeadQty,sum(LeadValue) LeadValue " +
                            "From " +
                            "( " +
                            "select EmployeeId,b.PlanDate,count(b.ID) PlanQty, 0 CheckinQty,0 LeadQty,0 LeadValue " +
                            "From t_DayPlan A,t_DayPlanDetails B where A.PlanID=B.PlanID " +
                            "group by EmployeeId,b.PlanDate " +
                            "Union All " +
                            "SELECT EmployeeId,PlanDate,0 PlanQty,count(TrackId) CheckinQty,0 LeadQty,0 LeadValue  " +
                            "FROM t_DayTracker a,t_DayPlanDetails b " +
                            "WHERE  Type = 3 and b.ID = a.InstrumentId " +
                            "group by EmployeeId,PlanDate " +
                            "Union All " +
                            "Select SalesPersonID,b.PlanDate,0 PlanQty,0 CheckinQty,count(c.LeadID) LeadQty,sum(LeadAmount) as LeadValue " +  
                            "From t_DayPlanWiseLead a,t_DayPlanDetails b,t_SalesLeadManagement C " +
                            "where A.PlanDetailId=B.ID and a.LeadId=c.LeadID group by SalesPersonID,b.PlanDate " +
                            ") x group by EmployeeId,PlanDate " +
                            ") main " +
                            "on dt.OutletEmployeeID=main.EmployeeId and dt.Date=main.PlanDate " +
                            "where dt.Date<=cast(getdate() as Date) and 1=1";
            //"where dt.Date<=cast(getdate() as Date) and PlanDate='" + dDate + "' and AreaName='" + sArea + "' and TerritoryName='" + sTerritory + "' and ShowroomCode='" + sShowroomCode + "' and EmployeeType='" + sEmployeeType + "'";

            //sSql = sSql + " and PlanDate='" + dDate + "' ";
            sSql = sSql + "  AND PlanDate between '" + dFromDate + "' and '" + dToDate + "' and PlanDate<'" + dToDate + "' ";

            if (sArea != "<All>")
            {
                sSql = sSql + " AND AreaName = '" + sArea + "'";
            }
            if (sTerritory != "<All>")
            {
                sSql = sSql + " AND TerritoryName = '" + sTerritory + "'";
            }
            if (sShowroomCode != "<All>")
            {
                sSql = sSql + " AND ShowroomCode = '" + sShowroomCode + "'";
            }
            if (sEmployeeType != "<All>")
            {
                sSql = sSql + " AND EmployeeType = '" + sEmployeeType + "'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DayPlanOutletWise oDayPlanOutletWise = new DayPlanOutletWise();
                    oDayPlanOutletWise.PlanDate = Convert.ToDateTime(reader["PlanDate"].ToString());
                    oDayPlanOutletWise.EmployeeCode = (string)reader["EmployeeCode"];
                    oDayPlanOutletWise.Employeename = (string)reader["Employeename"];
                    oDayPlanOutletWise.EmployeeType = (string)reader["EmployeeType"];
                    oDayPlanOutletWise.ShowroomCode = (string)reader["ShowroomCode"];
                    oDayPlanOutletWise.TerritoryName = (string)reader["TerritoryName"];
                    oDayPlanOutletWise.AreaName = (string)reader["AreaName"];
                    oDayPlanOutletWise.PlanQty = (int)reader["PlanQty"];
                    oDayPlanOutletWise.checkinQty = (int)reader["CheckinQty"];
                    oDayPlanOutletWise.LeadQty = (int)reader["LeadQty"];
                    oDayPlanOutletWise.LeadValue = (double)reader["LeadValue"];

                    InnerList.Add(oDayPlanOutletWise);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByDayPlanDetails(DateTime dDate,string sEmployeeCode, string sCustomerType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            //dToDate = dToDate.AddDays(1);
            string sSql = "Select PlanNo,PlanDate,CONVERT(varchar(15),CAST( TimeFrom AS TIME),100) TimeFrom, " +
                            "CONVERT(varchar(15), CAST(TimeTo AS TIME), 100)TimeTo,J.AreaName,J.TerritoryName,I.ShowroomCode,EmployeeCode, " +
                            "Employeecode + '-' + EmployeeName as EmployeeName,E.Description VisitPurpose, H.PlanDescription CustomerType, D.CustomerName, " +
                            "B.Address,B.Remarks,Case when ActionStatus = 1 then 'Create' else 'Approved' end as DP_ActionStatus " +
                            "from t_DayPlan A " +
                            "left join t_DayPlanDetails B on A.PlanID = B.PlanID " +
                            "left join v_EmployeeDetails C on A.EmployeeId = C.EmployeeID " +
                            "left join v_CustomerDetails D on B.CustomerId = D.CustomerID " +
                            "left join t_DayPlanPurpose E on B.PurposeId = E.PurposeID " +
                            "left join " +
                            "(SELECT * FROM t_DayTracker WHERE  Type = 3) F " +
                            "on B.ID = F.InstrumentId " +
                            "left join " +
                            "(SELECT * FROM t_DayTracker WHERE  Type = 4) G " +
                            "on B.ID = G.InstrumentId " +
                            "left join t_VisitPlanType H " +
                            "on H.PlanId = B.PlanTo " +
                            "left JOIN t_Showroom I " +
                            "ON I.LocationID = C.LocationID " +
                            "LEFT JOIN v_CustomerDetails J " +
                            "ON j.CustomerID = I.CustomerID " +
                            "WHERE c.DepartmentName != 'MIS & IT' and 1=1";

                            sSql = sSql + " and PlanDate='" + dDate + "' ";
            if (sEmployeeCode != "<All>")
            {
                sSql = sSql + " AND EmployeeCode = '" + sEmployeeCode + "'";
            }
            if (sCustomerType != "<All>")
            {
                sSql = sSql + " AND H.PlanDescription = '" + sCustomerType + "'";
            }

            sSql = sSql + "ORDER BY c.EmployeeCode ASC, J.AreaSort,j.TerritorySort,B.PlanDate DESC";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DayPlanOutletWise oDayPlanOutletWise = new DayPlanOutletWise();
                    oDayPlanOutletWise.PlanDate = Convert.ToDateTime(reader["PlanDate"].ToString());
                    oDayPlanOutletWise.EmployeeCode = (string)reader["EmployeeCode"];
                    oDayPlanOutletWise.Employeename = (string)reader["Employeename"];
                    if (reader["TimeFrom"] is DBNull)
                    {
                        oDayPlanOutletWise.TimeForm = "";
                    }
                    else
                    {
                        oDayPlanOutletWise.TimeForm = reader["TimeForm"];
                    }
                    if (reader["TimeTo"] is DBNull)
                    {
                        oDayPlanOutletWise.TimeTo = "";
                    }
                    else
                    {
                        oDayPlanOutletWise.TimeTo = reader["TimeTo"];
                    }
                    //oDayPlanOutletWise.TimeForm = reader["TimeFrom"];
                    //oDayPlanOutletWise.TimeTo = reader["TimeTo"];
                    oDayPlanOutletWise.PlanDescription = (string)reader["CustomerType"];
                    if (reader["CustomerName"] != DBNull.Value)
                        oDayPlanOutletWise.CustomerName = (string)reader["CustomerName"];
                    if (reader["Address"] != DBNull.Value)
                        oDayPlanOutletWise.Customeraddress = (string)reader["Address"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oDayPlanOutletWise.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oDayPlanOutletWise.Remarks = "";
                    }
                    InnerList.Add(oDayPlanOutletWise);
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


