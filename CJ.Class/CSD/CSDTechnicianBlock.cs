using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.CSD
{
public class CSDTechnicianBlock
{
private int _nID; 
private int _nTechnicianID; 
private DateTime _dFromDate; 
private DateTime _dToDate;
private object _dFromTime;
private object _dToTime; 
private int _nIsFullTime;
private int _nStatus; 
private int _nCreateUserID;
private int _nApprovedUserID;
private DateTime _dCreateDate;
private DateTime _dApprovedDate;
private int _nUpdateUserID; 
private DateTime _dUpdateDate;
private string _sCode;
private string _sName;
private string _sUserName;
private string _sRemarks;
private string _sApprovedBy;

private CSDTechnician _oCSDTechnician;

    public CSDTechnician CSDTechnician
    {
        get
        {
            if (_oCSDTechnician == null)
            {
                _oCSDTechnician = new CSDTechnician();
                _oCSDTechnician.TechnicianID = _nTechnicianID;
                _oCSDTechnician.Refresh();
            }

            return _oCSDTechnician;
        }
    }

 
// <summary>
// Get set property for ID
// </summary>
public int ID
 { 
       get { return  _nID; }
       set { _nID = value; }
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
// Get set property for FromDate
// </summary>
public DateTime FromDate
 { 
       get { return  _dFromDate; }
       set { _dFromDate = value; }
 } 

// <summary>
// Get set property for ToDate
// </summary>
public DateTime ToDate
 { 
       get { return  _dToDate; }
       set { _dToDate = value; }
 } 

// <summary>
// Get set property for FromTime
// </summary>
    public object FromTime
 { 
       get { return  _dFromTime; }
       set { _dFromTime = value; }
 } 

// <summary>
// Get set property for ToTime
// </summary>
    public object ToTime
 { 
       get { return  _dToTime; }
       set { _dToTime = value; }
 } 

// <summary>
// Get set property for IsFullTime
// </summary>
public int IsFullTime
 { 
       get { return  _nIsFullTime; }
       set { _nIsFullTime = value; }
 }
    public int Status
{
    get { return _nStatus; }
    set { _nStatus = value; }
} 

// <summary>
// Get set property for CreateUserID
// </summary>
public int CreateUserID
 { 
       get { return  _nCreateUserID; }
       set { _nCreateUserID = value; }
 }
    public int ApprovedUserID
{
    get { return _nApprovedUserID; }
    set { _nApprovedUserID = value; }
} 
// <summary>
// Get set property for CreateDate
// </summary>
public DateTime CreateDate
 { 
       get { return  _dCreateDate; }
       set { _dCreateDate = value; }
 }
    public DateTime ApprovedDate
{
    get { return _dApprovedDate; }
    set { _dApprovedDate = value; }
} 
// <summary>
// Get set property for UpdateUserID
// </summary>
public int UpdateUserID
 { 
       get { return  _nUpdateUserID; }
       set { _nUpdateUserID = value; }
 } 

// <summary>
// Get set property for UpdateDate
// </summary>
public DateTime UpdateDate
 { 
       get { return  _dUpdateDate; }
       set { _dUpdateDate = value; }
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

public string UserName
{
    get { return _sUserName; }
    set { _sUserName = value.Trim(); }
}
public string ApprovedBy
{
    get { return _sApprovedBy; }
    set { _sApprovedBy = value.Trim(); }
}
    public string Remarks
    {
        get { return _sRemarks; }
        set { _sRemarks = value.Trim(); }
    }
public void Add()
 {
     int nMaxID = 0;
     OleDbCommand cmd = DBController.Instance.GetCommand();
     string sSql = "";
     try
     {
         sSql = "SELECT MAX([ID]) FROM t_CSDTechnicianBlock";
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
         sSql = "INSERT INTO t_CSDTechnicianBlock (ID, TechnicianID, FromDate, ToDate, FromTime, ToTime, IsFullTime,Status, CreateUserID, CreateDate,Remarks) VALUES(?,?,?,?,?,?,?,?,?,?,?)";
         cmd.CommandText = sSql;
         cmd.CommandType = CommandType.Text;

        cmd.Parameters.AddWithValue("ID",  _nID);
         cmd.Parameters.AddWithValue("TechnicianID",  _nTechnicianID);
         cmd.Parameters.AddWithValue("FromDate",  _dFromDate);
         cmd.Parameters.AddWithValue("ToDate",  _dToDate);
         if (_dFromTime != null)
         {
             cmd.Parameters.AddWithValue("FromTime", _dFromTime);
         }
         else
         {
             cmd.Parameters.AddWithValue("FromTime", null);
         }
         if (_dToTime != null)
         {
             cmd.Parameters.AddWithValue("ToTime", _dToTime);
         }
         else
         {
             cmd.Parameters.AddWithValue("ToTime", null);
         } 
         cmd.Parameters.AddWithValue("IsFullTime",  _nIsFullTime);
         cmd.Parameters.AddWithValue("Status", _nStatus);
         cmd.Parameters.AddWithValue("CreateUserID",  _nCreateUserID);
         cmd.Parameters.AddWithValue("CreateDate",  _dCreateDate);
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
         sSql = "UPDATE t_CSDTechnicianBlock SET TechnicianID = ?, FromDate = ?, ToDate = ?, FromTime = ?, ToTime = ?, IsFullTime = ?,Status=?, UpdateUserID = ?, UpdateDate = ?,Remarks=? WHERE ID = ?";
         cmd.CommandText = sSql;
         cmd.CommandType = CommandType.Text;
 
         cmd.Parameters.AddWithValue("TechnicianID",  _nTechnicianID);
         cmd.Parameters.AddWithValue("FromDate",  _dFromDate);
         cmd.Parameters.AddWithValue("ToDate",  _dToDate);
         if (_dFromTime != null)
         {
             cmd.Parameters.AddWithValue("FromTime", _dFromTime);
         }
         else
         {
             cmd.Parameters.AddWithValue("FromTime", null);
         }
         if (_dToTime != null)
         {
             cmd.Parameters.AddWithValue("ToTime", _dToTime);
         }
         else
         {
             cmd.Parameters.AddWithValue("ToTime", null);
         }
         cmd.Parameters.AddWithValue("IsFullTime",  _nIsFullTime);
         cmd.Parameters.AddWithValue("Status", _nStatus);
         cmd.Parameters.AddWithValue("UpdateUserID",  _nUpdateUserID);
         cmd.Parameters.AddWithValue("UpdateDate",  _dUpdateDate);
         cmd.Parameters.AddWithValue("Remarks", _sRemarks);
         cmd.Parameters.AddWithValue("ID",  _nID);
 
        cmd.ExecuteNonQuery();
         cmd.Dispose();
     }
     catch (Exception ex)
     {
         throw (ex);
     }
 }
public void ApprovedBlockTechnician()
{
    OleDbCommand cmd = DBController.Instance.GetCommand();
    string sSql = "";
    try
    {
        sSql = "UPDATE t_CSDTechnicianBlock SET Status=?, ApprovedUserID = ?,ApprovedDate = ? WHERE ID = ?";
        cmd.CommandText = sSql;
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("Status", _nStatus);
        cmd.Parameters.AddWithValue("ApprovedUserID", _nApprovedUserID);
        cmd.Parameters.AddWithValue("ApprovedDate", _dApprovedDate);

        cmd.Parameters.AddWithValue("ID", _nID);

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
     sSql = "DELETE FROM t_CSDTechnicianBlock WHERE [ID]=?";
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
public void UpdateTech()
{
    OleDbCommand cmd = DBController.Instance.GetCommand();
    int nApprovedUserID = Utility.UserId;
    DateTime dApprovedDate = DateTime.Now;
    string sSql = "";
    try
    {
        sSql = "Update t_CSDTechnicianBlock set status=1, ApprovedUserID=" + nApprovedUserID + ",ApprovedDate= '" + dApprovedDate + "' WHERE [ID]=?";
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
         cmd.CommandText = "SELECT * FROM t_CSDTechnicianBlock where ID =?";
         cmd.Parameters.AddWithValue("ID", _nID);
         cmd.CommandType = CommandType.Text;
         IDataReader reader = cmd.ExecuteReader();
         if (reader.Read())
         {
             _nID = (int)reader["ID"];
             _nTechnicianID = (int)reader["TechnicianID"];
             _dFromDate = Convert.ToDateTime(reader["FromDate"].ToString());
             _dToDate = Convert.ToDateTime(reader["ToDate"].ToString());
             _dFromTime = Convert.ToDateTime(reader["FromTime"].ToString());
             _dToTime = Convert.ToDateTime(reader["ToTime"].ToString());
             _nIsFullTime = (int)reader["IsFullTime"];
             _nCreateUserID = (int)reader["CreateUserID"];
             _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
             _nUpdateUserID = (int)reader["UpdateUserID"];
             _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
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
public class CSDTechnicianBlocks : CollectionBase
{
public CSDTechnicianBlock this[int i]
{
    get { return (CSDTechnicianBlock)InnerList[i]; }
    set { InnerList[i] = value; }
}
public void Add(CSDTechnicianBlock oCSDTechnicianBlock)
{
    InnerList.Add(oCSDTechnicianBlock);
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
    string sSql = "SELECT * FROM t_CSDTechnicianBlock";
    try
    {
        cmd.CommandText = sSql;
        cmd.CommandType = CommandType.Text;
        IDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            CSDTechnicianBlock oCSDTechnicianBlock = new CSDTechnicianBlock();
            oCSDTechnicianBlock.ID = (int)reader["ID"];
             oCSDTechnicianBlock.TechnicianID = (int)reader["TechnicianID"];
             oCSDTechnicianBlock.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
             oCSDTechnicianBlock.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
             oCSDTechnicianBlock.FromTime = Convert.ToDateTime(reader["FromTime"].ToString());
             oCSDTechnicianBlock.ToTime = Convert.ToDateTime(reader["ToTime"].ToString());
             oCSDTechnicianBlock.IsFullTime = (int)reader["IsFullTime"];
             oCSDTechnicianBlock.CreateUserID = (int)reader["CreateUserID"];
             oCSDTechnicianBlock.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
             oCSDTechnicianBlock.UpdateUserID = (int)reader["UpdateUserID"];
             oCSDTechnicianBlock.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
             InnerList.Add(oCSDTechnicianBlock);
        }
        reader.Close();
        InnerList.TrimToSize();
    }
    catch (Exception ex)
    {
        throw (ex);
    }
}

    public void RefreshByTechnicianBlock(DateTime dFromDate, string sName)
    {
        InnerList.Clear();
        //dToDate = dToDate.AddDays(1);
        OleDbCommand cmd = DBController.Instance.GetCommand();
        string sSql = "Select ID,Code,Name,FromDate,Todate,FromTime,ToTime,IsFullTime, " +
                      "CreateDate,q.UserName,ApprovedDate,p.Username as ApprovedBy,Status,Remarks " +
                      "from " +
                        "(Select ID,Code,Name,FromDate,Todate,FromTime,ToTime,IsFullTime, " +
                        "a.CreateDate,UserName,ApprovedDate,ApprovedUserID, Status,Remarks from t_csdTechnicianBlock a,t_csdTechnician b ,t_User c " +
                        "where a.TechnicianID=b.TechnicianID and a.CreateUserID=c.UserId and '" + dFromDate.Date + "' between Convert(datetime,replace(convert(varchar, FromDate,6),'','-'),1) and Convert(datetime,replace(convert(varchar, ToDate,6),'','-'),1) )q  " +
                        "left outer join " +
                        "t_User p on p.UserID=q.ApprovedUserID ";

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
                CSDTechnicianBlock oCSDTechnicianBlock = new CSDTechnicianBlock();

                oCSDTechnicianBlock.ID = (int)reader["ID"];
                oCSDTechnicianBlock.Code = (string)reader["Code"]; 
                oCSDTechnicianBlock.Name = (string)reader["Name"];
                oCSDTechnicianBlock.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                oCSDTechnicianBlock.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                if (reader["FromTime"] != DBNull.Value)
                {
                    oCSDTechnicianBlock.FromTime = Convert.ToDateTime(reader["FromTime"].ToString());
                }
                if (reader["ToTime"] != DBNull.Value)
                {
                    oCSDTechnicianBlock.ToTime = Convert.ToDateTime(reader["ToTime"].ToString());
                }
                oCSDTechnicianBlock.IsFullTime = (int)reader["IsFullTime"];
                oCSDTechnicianBlock.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                oCSDTechnicianBlock.UserName = (string)reader["UserName"];
                if (reader["ApprovedDate"] != DBNull.Value)
                {
                    oCSDTechnicianBlock.ApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
                }
                if (reader["ApprovedBy"] != DBNull.Value)
                oCSDTechnicianBlock.ApprovedBy = (string)reader["ApprovedBy"];
                oCSDTechnicianBlock.Status = (int)reader["Status"];
                oCSDTechnicianBlock.Remarks = (string)reader["Remarks"];
                
                InnerList.Add(oCSDTechnicianBlock);
            }
            reader.Close();
            InnerList.TrimToSize();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

    public void RefreshByTechnicianBlockJobInHand(int nTechnicianID, DateTime dFromDate)
    {
        InnerList.Clear();
        DateTime _dDate = DateTime.Today.Date;
        OleDbCommand cmd = DBController.Instance.GetCommand();
        //string sSql = "Select ID,a.Technicianid,Code,Name,FromDate,Todate,FromTime,ToTime,IsFullTime,a.CreateDate,UserName,a.ApprovedDate,UserName as ApprovedBy from t_csdTechnicianBlock a,t_csdTechnician b,t_User c " +
        //               "where a.TechnicianID=b.TechnicianID and a.CreateUserID=c.UserId and a.ApprovedUserID=c.UserId and Fromdate >= DATEADD(day, DATEDIFF(day, 1, GETDATE()), 1) and a.TechnicianID=" + nTechnicianID + " and Status=1 ";   '" + _dDate + "' between FromDate and ToDate

        //string sSql = "Select * from " +
        //            "( " +
        //            "Select  ID,a.TechnicianID,Code,Name,FromDate,Todate,FromTime,ToTime,IsFullTime, " +
        //            "a.CreateDate,c.UserName,ApprovedDate,d.Username as ApprovedBy,a.status  From " +
        //            "(Select * From t_csdTechnicianBlock where " +
        //            "fromdate between REPLACE(CONVERT(VARCHAR(11),getdate(),106), ' ','-')  " +
        //            "and REPLACE(CONVERT(VARCHAR(11),getdate()+1,106), ' ','-') or " +
        //            "todate between REPLACE(CONVERT(VARCHAR(11),getdate(),106), ' ','-') " +
        //            "and REPLACE(CONVERT(VARCHAR(11),getdate()+1,106), ' ','-') or " +
        //            "fromdate<=REPLACE(CONVERT(VARCHAR(11),getdate(),106), ' ','-') " +
        //            "and todate>=REPLACE(CONVERT(VARCHAR(11),getdate(),106), ' ','-') ) a " +
        //            "left outer join " +
        //            "(Select * from t_csdTechnician) b " +
        //            "on a.TechnicianID=b.TechnicianID " +
        //            "left outer join " +
        //            "(Select * from t_User) c " +
        //            "on a.CreateUserID=c.UserID " +
        //            "left outer join " +
        //            "(Select * from t_User) d " +
        //            "on a.ApprovedUserID=d.UserID " +
        //            ") a where TechnicianID=" + nTechnicianID + " and status=1";

        string sSql = "Select ID,Technicianid,Code,Name,FromDate,Todate,FromTime,ToTime,IsFullTime, " +
              "CreateDate,q.UserName,ApprovedDate,p.Username as ApprovedBy,Status " +
              "from " +
            "(Select ID,b.Technicianid,Code,Name,FromDate,Todate,FromTime,ToTime,IsFullTime, " +
            "a.CreateDate,UserName,ApprovedDate,ApprovedUserID, Status from t_csdTechnicianBlock a,t_csdTechnician b ,t_User c " +
            "where a.TechnicianID=b.TechnicianID and a.CreateUserID=c.UserId and b.TechnicianID = " + nTechnicianID + " " +
            " and '" + dFromDate.Date + "' between Convert(datetime,replace(convert(varchar, FromDate,6),'','-'),1) "+
        " and Convert(datetime,replace(convert(varchar, ToDate,6),'','-'),1) )q  " +
                "left outer join " +
                "t_User p on p.UserID=q.ApprovedUserID ";

        try
        {
            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            IDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CSDTechnicianBlock oCSDTechnicianBlock = new CSDTechnicianBlock();

                oCSDTechnicianBlock.ID = (int)reader["ID"];
                oCSDTechnicianBlock.TechnicianID = (int)reader["TechnicianID"];
                oCSDTechnicianBlock.Code = (string)reader["Code"];
                oCSDTechnicianBlock.Name = (string)reader["Name"];
                oCSDTechnicianBlock.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                oCSDTechnicianBlock.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                if (reader["FromTime"] != DBNull.Value)
                {
                    oCSDTechnicianBlock.FromTime = Convert.ToDateTime(reader["FromTime"].ToString());
                }
                
                if (reader["ToTime"] != DBNull.Value)
                {
                    oCSDTechnicianBlock.ToTime = Convert.ToDateTime(reader["ToTime"].ToString());
                }
                
                oCSDTechnicianBlock.IsFullTime = (int)reader["IsFullTime"];
                oCSDTechnicianBlock.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                oCSDTechnicianBlock.UserName = (string)reader["UserName"];
                //oCSDTechnicianBlock.ApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
                //oCSDTechnicianBlock.ApprovedBy = (string)reader["ApprovedBy"];
                if (reader["ApprovedDate"] != DBNull.Value)
                {
                    oCSDTechnicianBlock.ApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
                }
                if (reader["ApprovedBy"] != DBNull.Value)
                    oCSDTechnicianBlock.ApprovedBy = (string)reader["ApprovedBy"];
                oCSDTechnicianBlock.Status = (int)reader["Status"];

                InnerList.Add(oCSDTechnicianBlock);
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

