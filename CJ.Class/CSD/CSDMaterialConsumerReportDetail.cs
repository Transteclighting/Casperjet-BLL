using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.CSD
{
public class CSDMaterialConsumerReportDetail
{
private int _nConsumerID;
private int _nCategoryID;
//private string _sCategory; 
private int _nMonth; 
private int _nYear; 
private double _Amount;
private double _PrevMonthAmt;
private double _CurrMonthAmt;

 
// <summary>
// Get set property for ConsumerID
// </summary>
public int ConsumerID
 { 
       get { return  _nConsumerID; }
       set { _nConsumerID = value; }
 }
    public int CategoryID
    {
        get { return _nCategoryID; }
        set { _nCategoryID = value; }
    } 

// <summary>
// Get set property for Category
// </summary>
//public string Category
// { 
//       get { return  _sCategory; }
//       set { _sCategory = value.Trim(); }
// } 

// <summary>
// Get set property for Month
// </summary>
public int Month
 { 
       get { return  _nMonth; }
       set { _nMonth = value; }
 } 

// <summary>
// Get set property for Year
// </summary>
public int Year
 { 
       get { return  _nYear; }
       set { _nYear = value; }
 } 

// <summary>
// Get set property for Amount
// </summary>
public double Amount
 { 
       get { return  _Amount; }
       set { _Amount = value; }
 }
    public double PrevMonthAmt
    {
        get { return _PrevMonthAmt; }
        set { _PrevMonthAmt = value; }
    }
    public double CurrMonthAmt
    {
        get { return _CurrMonthAmt; }
        set { _CurrMonthAmt = value; }
    }

public void Add()
 {
     int nMaxConsumerID = 0;
     OleDbCommand cmd = DBController.Instance.GetCommand();
     string sSql = "";
     try
     {
         sSql = "SELECT MAX([ConsumerID]) FROM t_CSDMaterialConsumerReportDetail";
         cmd.CommandText = sSql;
         object maxID = cmd.ExecuteScalar();
         if (maxID == DBNull.Value)
         {
             nMaxConsumerID = 1;
         }
         else
         {
             nMaxConsumerID = Convert.ToInt32(maxID) + 1;
         }
         _nConsumerID = nMaxConsumerID;
         sSql = "INSERT INTO t_CSDMaterialConsumerReportDetail (ConsumerID, CategoryID, Month, Year, Amount) VALUES(?,?,?,?,?)";
         cmd.CommandText = sSql;
         cmd.CommandType = CommandType.Text;

        cmd.Parameters.AddWithValue("ConsumerID",  _nConsumerID);
        cmd.Parameters.AddWithValue("CategoryID", _nCategoryID);
         cmd.Parameters.AddWithValue("Month",  _nMonth);
         cmd.Parameters.AddWithValue("Year",  _nYear);
         cmd.Parameters.AddWithValue("Amount",  _Amount);
 
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
         sSql = "UPDATE t_CSDMaterialConsumerReportDetail SET CategoryID = ?, Month = ?, Year = ?, Amount = ? WHERE ConsumerID = ?";
         cmd.CommandText = sSql;
         cmd.CommandType = CommandType.Text;

         cmd.Parameters.AddWithValue("CategoryID", _nCategoryID);
         cmd.Parameters.AddWithValue("Month",  _nMonth);
         cmd.Parameters.AddWithValue("Year",  _nYear);
         cmd.Parameters.AddWithValue("Amount",  _Amount);
        
         cmd.Parameters.AddWithValue("ConsumerID",  _nConsumerID);
 
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
         sSql = "DELETE FROM t_CSDMaterialConsumerReportDetail WHERE [ConsumerID]=?";
         cmd.CommandText = sSql;
         cmd.CommandType = CommandType.Text;
         cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
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
         cmd.CommandText = "SELECT * FROM t_CSDMaterialConsumerReportDetail where ConsumerID =?";
         cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
         cmd.CommandType = CommandType.Text;
         IDataReader reader = cmd.ExecuteReader();
         if (reader.Read())
         {
             _nConsumerID = (int)reader["ConsumerID"];
             _nCategoryID = (int)reader["CategoryID"];
             _nMonth = (int)reader["Month"];
             _nYear = (int)reader["Year"];
             _Amount = Convert.ToDouble(reader["Amount"].ToString());
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
public class CSDMaterialConsumerReportDetails : CollectionBase
{
public CSDMaterialConsumerReportDetail this[int i]
{
    get { return (CSDMaterialConsumerReportDetail)InnerList[i]; }
    set { InnerList[i] = value; }
}
public void Add(CSDMaterialConsumerReportDetail oCSDMaterialConsumerReportDetail)
{
    InnerList.Add(oCSDMaterialConsumerReportDetail);
}
public int GetIndex(int nConsumerID)
{
    int i;
    for (i = 0; i < this.Count; i++)
    {
        if (this[i].ConsumerID == nConsumerID)
        {
            return i;
        }
    }
    return -1;
}
public void Refresh()
{
    DateTime CurrentDate = DateTime.Today.Date;

    int nMonth = CurrentDate.Month;
    int nYear = CurrentDate.Year;
    int nLastMonth = nMonth - 1;
    
    InnerList.Clear();
    OleDbCommand cmd = DBController.Instance.GetCommand();
    string sSql = "SELECT * FROM t_CSDMaterialConsumerReportDetail";
    try
    {
        cmd.CommandText = sSql;
        cmd.CommandType = CommandType.Text;
        IDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            CSDMaterialConsumerReportDetail oCSDMaterialConsumerReportDetail = new CSDMaterialConsumerReportDetail();
            oCSDMaterialConsumerReportDetail.ConsumerID = (int)reader["ConsumerID"];
             //oCSDMaterialConsumerReportDetail.Category = (string)reader["Category"];
             oCSDMaterialConsumerReportDetail.Month = (int)reader["Month"];
             oCSDMaterialConsumerReportDetail.Year = (int)reader["Year"];
             oCSDMaterialConsumerReportDetail.Amount = Convert.ToDouble(reader["Amount"].ToString());
             InnerList.Add(oCSDMaterialConsumerReportDetail);
        }
        reader.Close();
        InnerList.TrimToSize();
    }
    catch (Exception ex)
    {
        throw (ex);
    }
}

    public void RefreshByAmount(DateTime _dDate)
    {
            int nCMonth = 0;
            int nPMonth = 0;
            int nYear = 0;
            nCMonth = _dDate.Month;
            nYear = _dDate.Year;
            nPMonth = nCMonth - 1;
            //if (nCMonth==1)
            //{
            //    nPMonth = 12;
            //}
            //else
            //{
            //    nPMonth = nCMonth - 1;
            //}
        
        //int nPMonth = DateTime.Now.AddMonths(-1).Month;

        InnerList.Clear();
        OleDbCommand cmd = DBController.Instance.GetCommand(); 
        string sSql = "Select CategoryID, sum(PrevMonthAmt) as PrevMonthAmt, sum(CurrMonthAmt) as CurrMonthAmt from " +
                        "( " +
                        "Select CategoryID, 0 as PrevMonthAmt, Sum(Amount) as CurrMonthAmt from t_CSDMaterialConsumerReportDetail " +
                        "Where Month = " + nCMonth + " and Year = " + nYear + " group by CategoryID " +
                        "Union All " +
                        "Select CategoryID, Sum(Amount) as PrevMonthAmt, 0 as CurrMonthAmt from t_CSDMaterialConsumerReportDetail " +
                        "Where Month = " + nPMonth + " and Month < " + nCMonth + " and Year = " + nYear + " group by CategoryID " +
                        ") a Group by CategoryID";
        try
        {
            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            IDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CSDMaterialConsumerReportDetail oCSDMaterialConsumerReportDetail = new CSDMaterialConsumerReportDetail();
                oCSDMaterialConsumerReportDetail.CategoryID = (int)reader["CategoryID"];
                oCSDMaterialConsumerReportDetail.PrevMonthAmt = Convert.ToDouble(reader["PrevMonthAmt"].ToString());
                oCSDMaterialConsumerReportDetail.CurrMonthAmt = Convert.ToDouble(reader["CurrMonthAmt"].ToString());
                InnerList.Add(oCSDMaterialConsumerReportDetail);
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


