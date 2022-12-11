// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak Kumar Chakraborty
// Date: July 07, 2011
// Time :  10.50 AM
// Description: Class ASM Activity tracking and Secondary Sales Collection
// Modify Person And Date:
// </summary>



using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Distribution
{
   public class LightingActivityTracking
    {
       private int _nSMSMessageID;
       private int _nZSICode;
       private string _sDistributorCode;
       private DateTime _dTranDate;
       private string _sRouteName;
       private string _svisitedArea;
       private int _nJsaCode;
       private int _nTotalOutlet;
       private int _nCashMemo;
       private double _nTGTTO;
       private double _nSalesTO;
       private int _nCFLTGTQty;
       private int _nCFLSalesQty;


       public int SMSMessageID
       {
           get { return _nSMSMessageID; }
           set { _nSMSMessageID= value; }       
       }

       public int ZSICode
       {
           get { return _nZSICode; }
           set { _nZSICode = value; }
       }

       public string DistributorCode
       {
           get { return _sDistributorCode; }
           set { _sDistributorCode = value; }       
       }

       public DateTime TranDate
       {
           get { return _dTranDate; }
           set { _dTranDate = value; }
       }

       public string RouteName
       {
           get { return _sRouteName; }
           set { value = _sRouteName; }       
       }

       public string VisitedArea
       {
           get { return _svisitedArea; }
           set { _svisitedArea = value; }
       
       }

       public int JSACode
       {
           get { return _nJsaCode; }
           set { _nJsaCode= value; }
       }

       public int TotalOutlet
       {
           get { return _nTotalOutlet; }
           set { _nTotalOutlet = value; }
       }

       public int CashMemo
       {
           get { return _nCashMemo; }
           set { _nCashMemo = value; }
       }

       public double TGTTO
       {
           get { return _nTGTTO; }
           set { _nTGTTO = value; }
       }

       public double SalesTO
       {
           get { return _nSalesTO; }
           set { _nSalesTO = value; }
       }

       public int CFLTGTQty
       {
           get { return _nCFLTGTQty; }
           set { _nCFLTGTQty = value; }
       }
       public int CFLSalesTO
       {
           get { return _nCFLSalesQty; }
           set { _nCFLSalesQty = value; }
       }

       public void Add()
       {     
           int nMaxSMSMessageID = 0;
           OleDbCommand cmd = DBController.Instance.GetCommand();
           string sSql = "";

           try
           {
               sSql = " SELECT MAX([SMSmessageID])FROM  TELAddDB.dbo.t_SecondarySalesZSI ";
               cmd.CommandText = sSql;
               object maxID = cmd.ExecuteScalar();
               if (maxID == DBNull.Value)
               {
                   nMaxSMSMessageID = 1;
               }
               else
               {
                   nMaxSMSMessageID = Convert.ToInt32(maxID) + 1;
               }
               _nSMSMessageID = nMaxSMSMessageID;

               sSql = "INSERT INTO TELAddDB.dbo.t_SecondarySalesZSI VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
               cmd.CommandText = sSql;
               cmd.CommandType = CommandType.Text;       

               cmd.Parameters.AddWithValue("SMSMessageID", _nSMSMessageID);  
               cmd.Parameters.AddWithValue("ZSICode", _nZSICode);     
               cmd.Parameters.AddWithValue("DistributorCode",_sDistributorCode);       
               cmd.Parameters.AddWithValue("TranDate", _dTranDate);   
               cmd.Parameters.AddWithValue("RouteName", _svisitedArea); 
               cmd.Parameters.AddWithValue("JSACode", _nJsaCode); 
               cmd.Parameters.AddWithValue("TotalOutlet",_nTotalOutlet); 
               cmd.Parameters.AddWithValue("CashMemo", _nCashMemo); 
               cmd.Parameters.AddWithValue("TgtTO", _nTGTTO); 
               cmd.Parameters.AddWithValue("SalesTO", _nSalesTO); 
               cmd.Parameters.AddWithValue("CFLTGTQty", _nCFLTGTQty); 
               cmd.Parameters.AddWithValue("CFLSalesQty", _nCFLSalesQty); 
               
               cmd.ExecuteNonQuery();
               cmd.Dispose();
           }
           catch (Exception ex)
           {
               throw (ex);
           }
       }


    }
}
