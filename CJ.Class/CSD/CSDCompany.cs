
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Collections;
    using System.Data;
    using System.Data.OleDb;
    using CJ.Class;

    namespace CJ.Class.CSD
    {
    public class CSDCompany
    {
    private int _nID; 
    private string _sName; 
    private int _nIsActive; 

     
    // <summary>
    // Get set property for ID
    // </summary>
    public int ID
     { 
           get { return  _nID; }
           set { _nID = value; }
     } 

    // <summary>
    // Get set property for Name
    // </summary>
    public string Name
     { 
           get { return  _sName; }
           set { _sName = value.Trim(); }
     } 

    // <summary>
    // Get set property for IsActive
    // </summary>
    public int IsActive
     { 
           get { return  _nIsActive; }
           set { _nIsActive = value; }
     } 

    public void Add()
     {
         int nMaxID = 0;
         OleDbCommand cmd = DBController.Instance.GetCommand();
         string sSql = "";
         try
         {
             sSql = "SELECT MAX([ID]) FROM t_CSDCompany";
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
             sSql = "INSERT INTO t_CSDCompany (ID, Name, IsActive) VALUES(?,?,?)";
             cmd.CommandText = sSql;
             cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("ID",  _nID);
             cmd.Parameters.AddWithValue("Name",  _sName);
             cmd.Parameters.AddWithValue("IsActive",  _nIsActive);
     
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
             sSql = "UPDATE t_CSDCompany SET Name = ?, IsActive = ? WHERE ID = ?";
             cmd.CommandText = sSql;
             cmd.CommandType = CommandType.Text;
     
             cmd.Parameters.AddWithValue("Name",  _sName);
             cmd.Parameters.AddWithValue("IsActive",  _nIsActive);
            
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
             sSql = "DELETE FROM t_CSDCompany WHERE [ID]=?";
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
             cmd.CommandText = "SELECT * FROM t_CSDCompany where ID =?";
             cmd.Parameters.AddWithValue("ID", _nID);
             cmd.CommandType = CommandType.Text;
             IDataReader reader = cmd.ExecuteReader();
             if (reader.Read())
             {
                 _nID = (int)reader["ID"];
                 _sName = (string)reader["Name"];
                 _nIsActive = (int)reader["IsActive"];
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
    public class CSDCompanys : CollectionBase
    {
    public CSDCompany this[int i]
    {
        get { return (CSDCompany)InnerList[i]; }
        set { InnerList[i] = value; }
    }
    public void Add(CSDCompany oCSDCompany)
    {
        InnerList.Add(oCSDCompany);
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
        string sSql = "SELECT * FROM t_CSDCompany";
        try
        {
            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            IDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CSDCompany oCSDCompany = new CSDCompany();
                oCSDCompany.ID = (int)reader["ID"];
                 oCSDCompany.Name = (string)reader["Name"];
                 oCSDCompany.IsActive = (int)reader["IsActive"];
                 InnerList.Add(oCSDCompany);
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

