using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;


namespace CJ.Class.CSD
{
public class CSDFeedbackDateHistory
{
private int _nID; 
private int _nJobID; 
private int _nTechnicianID; 
private int _nStatusID; 
private DateTime _dFeedbackDate; 
private DateTime _dVisitingTimeFrom; 
private DateTime _dVisitingTimeTo; 
private int _nCreateUserID; 
private DateTime _dCreateDate; 
private string _sRemarks;
private string _sCode;
private string _sName;
private int _nJobCount;
private string _sTechnicianType;
private string _sThirdPartyName;
private string _sWorkshopName;

 
// <summary>
// Get set property for ID
// </summary>
public int ID
 { 
       get { return  _nID; }
       set { _nID = value; }
 } 

// <summary>
// Get set property for JobID
// </summary>
public int JobID
 { 
       get { return  _nJobID; }
       set { _nJobID = value; }
 }
public int JobCount
{
    get { return _nJobCount; }
    set { _nJobCount = value; }
}

// <summary>
// Get set property for TechnicianID
// </summary>
public int TechnicianID
 { 
       get { return  _nTechnicianID; }
       set { _nTechnicianID = value; }
 } 

// <summary>
// Get set property for StatusID
// </summary>
public int StatusID
 { 
       get { return  _nStatusID; }
       set { _nStatusID = value; }
 } 

// <summary>
// Get set property for FeedbackDate
// </summary>
public DateTime FeedbackDate
 { 
       get { return  _dFeedbackDate; }
       set { _dFeedbackDate = value; }
 } 

// <summary>
// Get set property for VisitingTimeFrom
// </summary>
public DateTime VisitingTimeFrom
 { 
       get { return  _dVisitingTimeFrom; }
       set { _dVisitingTimeFrom = value; }
 } 

// <summary>
// Get set property for VisitingTimeTo
// </summary>
public DateTime VisitingTimeTo
 { 
       get { return  _dVisitingTimeTo; }
       set { _dVisitingTimeTo = value; }
 } 

// <summary>
// Get set property for CreateUserID
// </summary>
public int CreateUserID
 { 
       get { return  _nCreateUserID; }
       set { _nCreateUserID = value; }
 } 

// <summary>
// Get set property for CreateDate
// </summary>
public DateTime CreateDate
 { 
       get { return  _dCreateDate; }
       set { _dCreateDate = value; }
 } 

// <summary>
// Get set property for Remarks
// </summary>
public string Remarks
 { 
       get { return  _sRemarks; }
       set { _sRemarks = value.Trim(); }
 }
public string WorkshopName
{
    get { return _sWorkshopName; }
    set { _sWorkshopName = value.Trim(); }
}
public string TechnicianType
{
    get { return _sTechnicianType; }
    set { _sTechnicianType = value.Trim(); }
}
public string ThirdPartyName
{
    get { return _sThirdPartyName; }
    set { _sThirdPartyName = value.Trim(); }
}
public string Code
{
    get { return _sCode; }
    set { _sCode = value.Trim(); }
}
public string Name
{
    get { return _sName; }
    set { _sName = value.Trim(); }
}

public void Add()
 {
     int nMaxID = 0;
     OleDbCommand cmd = DBController.Instance.GetCommand();
     string sSql = "";
     try
     {
         sSql = "SELECT MAX([ID]) FROM t_CSDFeedbackDateHistory";
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
         sSql = "INSERT INTO t_CSDFeedbackDateHistory (ID, JobID, TechnicianID, StatusID, FeedbackDate, VisitingTimeFrom, VisitingTimeTo, CreateUserID, CreateDate, Remarks) VALUES(?,?,?,?,?,?,?,?,?,?)";
         cmd.CommandText = sSql;
         cmd.CommandType = CommandType.Text;

        cmd.Parameters.AddWithValue("ID",  _nID);
         cmd.Parameters.AddWithValue("JobID",  _nJobID);
         cmd.Parameters.AddWithValue("TechnicianID",  _nTechnicianID);
         cmd.Parameters.AddWithValue("StatusID",  _nStatusID);
         cmd.Parameters.AddWithValue("FeedbackDate",  _dFeedbackDate);
         cmd.Parameters.AddWithValue("VisitingTimeFrom",  _dVisitingTimeFrom);
         cmd.Parameters.AddWithValue("VisitingTimeTo",  _dVisitingTimeTo);
         cmd.Parameters.AddWithValue("CreateUserID",  _nCreateUserID);
         cmd.Parameters.AddWithValue("CreateDate",  _dCreateDate);
         cmd.Parameters.AddWithValue("Remarks",  _sRemarks);
 
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
         sSql = "UPDATE t_CSDFeedbackDateHistory SET JobID = ?, TechnicianID = ?, StatusID = ?, FeedbackDate = ?, VisitingTimeFrom = ?, VisitingTimeTo = ?, CreateUserID = ?, CreateDate = ?, Remarks = ? WHERE ID = ?";
         cmd.CommandText = sSql;
         cmd.CommandType = CommandType.Text;
 
         cmd.Parameters.AddWithValue("JobID",  _nJobID);
         cmd.Parameters.AddWithValue("TechnicianID",  _nTechnicianID);
         cmd.Parameters.AddWithValue("StatusID",  _nStatusID);
         cmd.Parameters.AddWithValue("FeedbackDate",  _dFeedbackDate);
         cmd.Parameters.AddWithValue("VisitingTimeFrom",  _dVisitingTimeFrom);
         cmd.Parameters.AddWithValue("VisitingTimeTo",  _dVisitingTimeTo);
         cmd.Parameters.AddWithValue("CreateUserID",  _nCreateUserID);
         cmd.Parameters.AddWithValue("CreateDate",  _dCreateDate);
         cmd.Parameters.AddWithValue("Remarks",  _sRemarks);
        
         cmd.Parameters.AddWithValue("ID",  _nID);
 
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
         sSql = "DELETE FROM t_CSDFeedbackDateHistory WHERE [ID]=?";
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
         cmd.CommandText = "SELECT * FROM t_CSDFeedbackDateHistory where ID =?";
         cmd.Parameters.AddWithValue("ID", _nID);
         cmd.CommandType = CommandType.Text;
         IDataReader reader = cmd.ExecuteReader();
         if (reader.Read())
         {
             _nID = (int)reader["ID"];
             _nJobID = (int)reader["JobID"];
             _nTechnicianID = (int)reader["TechnicianID"];
             _nStatusID = (int)reader["StatusID"];
             _dFeedbackDate = Convert.ToDateTime(reader["FeedbackDate"].ToString());
             _dVisitingTimeFrom = Convert.ToDateTime(reader["VisitingTimeFrom"].ToString());
             _dVisitingTimeTo = Convert.ToDateTime(reader["VisitingTimeTo"].ToString());
             _nCreateUserID = (int)reader["CreateUserID"];
             _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
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
public class CSDFeedbackDateHistorys : CollectionBase
{
public CSDFeedbackDateHistory this[int i]
{
    get { return (CSDFeedbackDateHistory)InnerList[i]; }
    set { InnerList[i] = value; }
}
public void Add(CSDFeedbackDateHistory oCSDFeedbackDateHistory)
{
    InnerList.Add(oCSDFeedbackDateHistory);
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
    string sSql = "SELECT * FROM t_CSDFeedbackDateHistory";
    try
    {
        cmd.CommandText = sSql;
        cmd.CommandType = CommandType.Text;
        IDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            CSDFeedbackDateHistory oCSDFeedbackDateHistory = new CSDFeedbackDateHistory();
            oCSDFeedbackDateHistory.ID = (int)reader["ID"];
             oCSDFeedbackDateHistory.JobID = (int)reader["JobID"];
             oCSDFeedbackDateHistory.TechnicianID = (int)reader["TechnicianID"];
             oCSDFeedbackDateHistory.StatusID = (int)reader["StatusID"];
             oCSDFeedbackDateHistory.FeedbackDate = Convert.ToDateTime(reader["FeedbackDate"].ToString());
             oCSDFeedbackDateHistory.VisitingTimeFrom = Convert.ToDateTime(reader["VisitingTimeFrom"].ToString());
             oCSDFeedbackDateHistory.VisitingTimeTo = Convert.ToDateTime(reader["VisitingTimeTo"].ToString());
             oCSDFeedbackDateHistory.CreateUserID = (int)reader["CreateUserID"];
             oCSDFeedbackDateHistory.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
             oCSDFeedbackDateHistory.Remarks = (string)reader["Remarks"];
             InnerList.Add(oCSDFeedbackDateHistory);
        }
        reader.Close();
        InnerList.TrimToSize();
    }
    catch (Exception ex)
    {
        throw (ex);
    }
}
    public void RefreshByFeedBackDate(DateTime dFromDate, DateTime dToDate, string sName)
    {
        dToDate = dToDate.AddDays(1);
        //dFromDate = dFromDate.AddMonths(-1);
        InnerList.Clear();
        OleDbCommand cmd = DBController.Instance.GetCommand();
        string sSql = "Select a.TechnicianID,Code,Name,JobCount from " +
                     "(Select TechnicianID, Count(JobID) as JobCount from t_CSDFeedbackDateHistory " +
                     "Where CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate < '" + dToDate + "' " + 
                     "Group by TechnicianID having Count(JobID) > 1)as a " +
                     "left outer join " +
                     "(Select TechnicianID,Code,Name from t_CSDTechnician)as b on a.TechnicianID=b.TechnicianID where a.TechnicianID !=0";
        if (sName != "")
        {
            sName = "%" + sName + "%";
            sSql = sSql + " AND Name LIKE '" + sName + "'";
        }
        try
        {
            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            IDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CSDFeedbackDateHistory oCSDFeedbackDateHistory = new CSDFeedbackDateHistory();
                oCSDFeedbackDateHistory.TechnicianID = (int)reader["TechnicianID"];
                if (reader["Code"] != DBNull.Value)
                oCSDFeedbackDateHistory.Code = (string)reader["Code"];
                if (reader["Name"] != DBNull.Value)
                oCSDFeedbackDateHistory.Name = (string)reader["Name"];
                //oCSDFeedbackDateHistory.FeedbackDate = Convert.ToDateTime(reader["FeedbackDate"].ToString());
                oCSDFeedbackDateHistory.JobCount = (int)reader["JobCount"];

                InnerList.Add(oCSDFeedbackDateHistory); 
            }
            reader.Close();
            InnerList.TrimToSize();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }
    public void PrintByFeedBackDate(DateTime dFromDate, DateTime dToDate, int nTechnicianID)
    {
        dToDate = dToDate.AddDays(1);
        //dFromDate = dFromDate.AddMonths(-1);
       
        InnerList.Clear();
        OleDbCommand cmd = DBController.Instance.GetCommand();
        //string sSql = "Select a.TechnicianID,Code,Name,FeedbackDate,JobCount,case type when 1 then 'Own'else 'Third Party' end as TechnicianType,ThirdPartyName from " +
        //            "(Select TechnicianID, FeedbackDate, Count(JobID) as JobCount from t_CSDFeedbackDateHistory " +
        //            "Where CreateDate between '" + dFromDate + "' and '  " + dToDate + "  ' and CreateDate < '  " + dToDate + "   ' " +
        //            "Group by TechnicianID, FeedbackDate having Count(JobID) > 1)as a " +
        //            "Inner join  " +
        //            "(Select TechnicianID,ThirdpartyID,Code,Name,type from t_CSDTechnician)as b on a.TechnicianID=b.TechnicianID " +
        //            "left outer join " +
        //            "(Select InterServiceID,Name as ThirdPartyName from t_CSDInterService)as c on b.ThirdpartyID=c.InterServiceID where a.TechnicianID !=0 and a.TechnicianID=" + nTechnicianID + "";

        string sSql = "Select a.TechnicianID,Code,Name,JobCount,case type when 1 then 'Own'else 'Third Party' end as TechnicianType,WorkshopName,ThirdPartyName = CASE WHEN ThirdPartyName IS NULL THEN 'NA' ELSE ThirdPartyName end from " +
                    "(Select TechnicianID,Count(JobID) as JobCount from t_CSDFeedbackDateHistory " +
                    "Where CreateDate between '" + dFromDate + "' and '  " + dToDate + "  ' and CreateDate < '  " + dToDate + "   ' " +
                    "Group by TechnicianID having Count(JobID) > 1)as a " +
                    "Inner join  " +
                    "(Select TechnicianID,WorkshopTypeID,ThirdpartyID,Code,Name,type from t_CSDTechnician)as b on a.TechnicianID=b.TechnicianID " +
                    "left outer join " +
                    "(Select InterServiceID,Name as ThirdPartyName from t_CSDInterService)as c on b.ThirdpartyID=c.InterServiceID " +
                    "left outer join  (Select WorkshopTypeID,Name as WorkshopName  from t_CSDWorkshopType)as d on d.WorkshopTypeID=b.WorkshopTypeID where a.TechnicianID !=0 and a.TechnicianID=" + nTechnicianID + "";

        
        try
        {
            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            IDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CSDFeedbackDateHistory oCSDFeedbackDateHistory = new CSDFeedbackDateHistory();
                oCSDFeedbackDateHistory.TechnicianID = (int)reader["TechnicianID"];
                if (reader["Code"] != DBNull.Value)
                    oCSDFeedbackDateHistory.Code = (string)reader["Code"];
                if (reader["Name"] != DBNull.Value)
                    oCSDFeedbackDateHistory.Name = (string)reader["Name"];
                //oCSDFeedbackDateHistory.FeedbackDate = Convert.ToDateTime(reader["FeedbackDate"].ToString());
                oCSDFeedbackDateHistory.JobCount = (int)reader["JobCount"];
                oCSDFeedbackDateHistory.TechnicianType = (string)reader["TechnicianType"];
                if (reader["ThirdPartyName"] != DBNull.Value)
                oCSDFeedbackDateHistory.ThirdPartyName = (string)reader["ThirdPartyName"];
            //if (reader["WorkshopName"] != DBNull.Value)
                oCSDFeedbackDateHistory.WorkshopName = (string)reader["WorkshopName"];

                InnerList.Add(oCSDFeedbackDateHistory);
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


