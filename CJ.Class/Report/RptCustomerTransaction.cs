// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak k. Chakraborty
// Date: July 13, 2011
// Time" :  04:09 PM
// Description: Customer Transaction [805]
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Report
{
    [Serializable]
   public class RptCustomerTransaction
    {

       private int _nTranID;
       private string _sTranNo;

       private int _nCustomerID;
       private string _sCustomerCode;
       private string _sCustomerName;

       private DateTime _dTranDate;
       private int _nTranTypeID;
       private double _Amount;
       private double _Debit;
       private double _Credit;
       private string _sInstrumentNo;
       private DateTime _dInstrumentDate;
       private int _nInstrumentType;
       private int _nInstrumentStatus;
       private int _nBranchID;
       private string _sBranchCode;
       private string _sBranchName;
       private int _nEntryUserID;
       private DateTime _dEntryDate;
       private int _nUpdateUserID;
       private DateTime _dUpdatedate;
       private string _sRemarks;
       private string _sTranTypeName;
       private int _nTranSide;
       private int _nIsSystem;
       private int _nSBUID;
       private string _sSBUCode;
       private string _sSBUName;
       private int _nChannelID;
       private string _sChannelCode;
       private string _sChannelDescription;
       private int _nAreaID;
       private string _sAreaCode;
       private string _sAreaName;
       private int _nTerritoryID;
       private string _sTerritoryCode;
       private string _sTerritoryName;
       private string _sUserName;
       private string _sUserFullName;
       private int _nBankID;
       private string _sBankCode;
       private string _sBankName;


       public int TranID
       {
           get { return _nTranID; }
           set { _nTranID = value; }
       }
       public string TranNo
       {
           get { return _sTranNo; }
           set { _sTranNo = value; }
       }
       public int CustomerID
       {
           get { return _nCustomerID; }
           set { _nCustomerID = value; }
       }
       public string CustomerName
       {
           get { return _sCustomerName; }
           set { _sCustomerName = value; }
       }
       public string CustomerCode
       {
           get { return _sCustomerCode; }
           set { _sCustomerCode = value; }

       }
       public DateTime TranDate
       {
           get { return _dTranDate; }
           set { _dTranDate = value; }
       }
       public int TranTypeID
       {
           get { return _nTranTypeID; }
           set { _nTranTypeID = value; }
       }
       public double Amount
       {
           get { return _Amount; }
           set { _Amount = value; }
       }
       public double Debit
       {
           get { return _Debit; }
           set { _Debit = value; }
       }
       public double Credit
       {
           get { return _Credit; }
           set { _Credit = value; }
       }
       public string InstrumentNo
       {
           get { return _sInstrumentNo; }
           set { _sInstrumentNo = value; }
       }
       public DateTime InstrumentDate
       {
           get { return _dInstrumentDate; }
           set { _dInstrumentDate = value; }
       }
       public int InstrumentType
       {
           get { return _nInstrumentType; }
           set { _nInstrumentType = value; }
       }
       public int InstrumentStatus
       {
           get { return _nInstrumentStatus; }
           set { _nInstrumentStatus = value; }
       }
       public int BranchID
       {
           get { return _nBranchID; }
           set { _nBranchID = value; }
       }
       public string BranchCode
       {
           get { return _sBranchCode; }
           set { _sBranchCode = value; }
       }
       public string BranchName
       {
           get { return _sBranchName; }
           set { _sBranchName = value; }
       }
       public int EntryUserID
       {
           get { return _nEntryUserID; }
           set { _nEntryUserID = value; }
       }
       public DateTime EntryDate
       {
           get { return _dEntryDate; }
           set { _dEntryDate = value; }
       }
       public int UpdateUserID
       {
           get { return _nUpdateUserID; }
           set { _nUpdateUserID = value; }
       }
       public DateTime Updatedate
       {
           get { return _dUpdatedate; }
           set { _dUpdatedate = value; }
       }
       public string Remarks
       {
           get { return _sRemarks; }
           set { _sRemarks = value; }
       }
       public string TranTypeName
       {
           get { return _sTranTypeName; }
           set { _sTranTypeName = value; }
       }
       public int TranSide
       {
           get { return _nTranSide; }
           set { _nTranSide = value; }
       }
       public int IsSystem
       {
           get { return _nIsSystem; }
           set { _nIsSystem = value; }
       }
       public int SBUID
       {
           get { return _nSBUID; }
           set { _nSBUID = value; }
       }
       public string SBUCode
       {
           get { return _sSBUCode; }
           set { _sSBUCode = value; }
       }
       public string SBUName
       {
           get { return _sSBUName; }
           set { _sSBUName = value; }
       }
       public int ChannelID
       {
           get { return _nChannelID; }
           set { _nChannelID = value; }
       }
       public string ChannelCode
       {
           get { return _sChannelCode; }
           set { _sChannelCode = value; }
       }
       public string ChannelDescription
       {
           get { return _sChannelDescription; }
           set { _sChannelDescription = value; }
       }
       public int AreaID
       {
           get { return _nAreaID; }
           set { _nAreaID = value; }
       }
       public string AreaCode
       {
           get { return _sAreaCode; }
           set { _sAreaCode = value; }
       }
       public string AreaName
       {
           get { return _sAreaName; }
           set { _sAreaName = value; }
       }
       public int TerritoryID
       {
           get { return _nTerritoryID; }
           set { _nTerritoryID = value; }
       }
       public string TerritoryCode
       {
           get { return _sTerritoryCode; }
           set { _sTerritoryCode = value; }
       }
       public string TerritoryName
       {
           get { return _sTerritoryName; }
           set { _sTerritoryName = value; }
       }
       public string UserName
       {
           get { return _sUserName; }
           set { _sUserName = value; }
       }
       public string UserFullName
       {
           get { return _sUserFullName; }
           set { _sUserFullName = value; }
       }
       public int BankID
       {
           get { return _nBankID; }
           set { _nBankID = value; }
       }
       public string BankCode
       {
           get { return _sBankCode; }
           set { _sBankCode = value; }
       }
       public string BankName
       {
           get { return _sBankName; }
           set { _sBankName = value; }
       }


    }

    public class RptCustomerTransactionDetails : CollectionBaseCustom
    {

        public void Add(RptCustomerTransaction oRptCustomerTransaction)
        {
            this.List.Add(oRptCustomerTransaction);
        }

        public RptCustomerTransaction this[Int32 Index]
        {
            get
            {
                return (RptCustomerTransaction)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(RptCustomerTransaction))))
                {
                    throw new Exception(" Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        public void CustomerTransaction(DateTime dYFromDate, DateTime dYToDate ,string sExpr)
        {            
            // InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            //StringBuilder sQueryStringMaster;
            //sQueryStringMaster = new StringBuilder();
            dYToDate = dYToDate.AddDays(1);
            string sSsq = "";
            sSsq = "Select * From  " +
                   "(  " +
                   "select q1.TranID,q1.TranNo,q1.CustomerID,q1.TranDate,q1.TranTypeID,q1.Amount,(Case q2.TranSide When 1 then q1.Amount else 0  END) as Credit,(Case q2.TranSide When 2 then q1.Amount else 0  END) as Debit     " +
                   ",q1.InstrumentNo,q1.InstrumentDate,q1.InstrumentType,q1.InstrumentStatus,q1.BranchID,q1.BranchName,q1.EntryUserID,q1.EntryDate,q1.UpdateUserID,q1.UpdateDate,q1.Remarks     " +
                   ",q2.TranTypeName,q2.TranSide,q2.IsSystem,q3.CustomerCode,q3.CustomerName,q3.SBUID,q3.SBUCode,q3.SBUName,q3.ChannelID,q3.ChannelCode,q3.ChannelDescription,q3.AreaID,q3.AreaCode,q3.AreaName ,q3.TerritoryID,q3.TerritoryCode,q3.TerritoryName  ,q4.UserName,q4.UserFullName,q5.Code as BranchCode,q6.BankID as BankID, q6.Code as  BankCode,q6.Name as  BankName from     " +
                   "(select * from t_CustomerTran where TranDate Between '" + dYFromDate + "' and '" + dYToDate +
                   "' and TranDate < '" + dYToDate + "' ) as q1  " +
                   "inner Join       " +
                   "(select * from t_CustomerTranType) as q2  on q2.TranTypeID=q1.TranTypeID     " +
                   "inner Join      " +
                   "(select * from v_CustomerDetails) as q3 on q3.CustomerID=q1.CustomerID     " +
                   "inner Join       " +
                   "(select * from t_User) as q4 on q4.UserID=q1.EntryUserID     " +
                   "left outer join     " +
                   "(Select BankID,BranchID,Code,Name  from t_BankBranch) as q5 on q5.BranchID=q1.BranchID     " +
                   "Left Outer Join     " +
                   "(select BankID,Code,Name from t_Bank) as q6 on q6.BankID=q5.BankID    " +
                   ") Main where 1=1 ";
            if (sExpr != "")
            {
                sSsq = sSsq + " " + sExpr + "";

            }
            sSsq = sSsq + " Order By TranDate";

            //sQueryStringMaster.Append(" Select * From (select q1.TranID,q1.TranNo,q1.CustomerID,q1.TranDate,q1.TranTypeID,q1.Amount,(Case q2.TranSide When 1 then q1.Amount else 0  END) as Credit,(Case q2.TranSide When 2 then q1.Amount else 0  END) as Debit   ");
            //sQueryStringMaster.Append(" ,q1.InstrumentNo,q1.InstrumentDate,q1.InstrumentType,q1.InstrumentStatus,q1.BranchID,q1.BranchName,q1.EntryUserID,q1.EntryDate,q1.UpdateUserID,q1.UpdateDate,q1.Remarks  "); 
            //sQueryStringMaster.Append(" ,q2.TranTypeName,q2.TranSide,q2.IsSystem,q3.CustomerCode,q3.CustomerName,q3.SBUID,q3.SBUCode,q3.SBUName,q3.ChannelID,q3.ChannelCode,q3.ChannelDescription,q3.AreaID,q3.AreaCode,q3.AreaName ,q3.TerritoryID,q3.TerritoryCode,q3.TerritoryName  ,q4.UserName,q4.UserFullName,q5.Code as BranchCode,q6.BankID as BankID, q6.Code as  BankCode,q6.Name as  BankName from   ");
            //sQueryStringMaster.Append(" (select * from t_CustomerTran where TranDate Between ? and ? and TranDate < ? ) as q1  "); 
            //sQueryStringMaster.Append(" inner Join  ");   
            //sQueryStringMaster.Append(" (select * from t_CustomerTranType) as q2  on q2.TranTypeID=q1.TranTypeID ");  
            //sQueryStringMaster.Append(" inner Join    ");
            //sQueryStringMaster.Append(" (select * from v_CustomerDetails) as q3 on q3.CustomerID=q1.CustomerID   ");
            //sQueryStringMaster.Append(" inner Join     ");
            //sQueryStringMaster.Append(" (select * from t_User) as q4 on q4.UserID=q1.EntryUserID  "); 
            //sQueryStringMaster.Append(" left outer join   ");
            //sQueryStringMaster.Append(" (Select BankID,BranchID,Code,Name  from t_BankBranch) as q5 on q5.BranchID=q1.BranchID ");  
            //sQueryStringMaster.Append(" Left Outer Join  "); 
            //sQueryStringMaster.Append(" (select BankID,Code,Name from t_Bank) as q6 on q6.BankID=q5.BankID)  Main where 1=1  ");


            OleDbCommand oCmd = DBController.Instance.GetCommand();
        //Command time out
        oCmd.CommandTimeout = 0;
            oCmd.CommandText = sSsq;


            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate);
        oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate.AddDays(1));
        oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate.AddDays(1));
        GetDataCustomerTransaction(oCmd);

        }


        private void GetDataCustomerTransaction(OleDbCommand cmd)
        {
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RptCustomerTransaction oItem = new RptCustomerTransaction();


                    if (reader["TranID"] != DBNull.Value)
                        oItem.TranID = (int)reader["TranID"];
                    else oItem.TranID = -1;

                    if (reader["TranNo"] != DBNull.Value)
                        oItem.TranNo = (string)reader["TranNo"];
                    else oItem.TranNo = "";

                    if (reader["CustomerID"] != DBNull.Value)
                        oItem.CustomerID = (int)reader["CustomerID"];
                    else oItem.CustomerID = -1;

                    if (reader["CustomerCode"] != DBNull.Value)
                        oItem.CustomerCode = (string)reader["CustomerCode"];
                    else oItem.CustomerCode = "";

                    if (reader["CustomerName"] != DBNull.Value)
                        oItem.CustomerName = (string)reader["CustomerName"];
                    else oItem.CustomerName = "";


                    if (reader["Trandate"] != DBNull.Value)
                        oItem.TranDate = (DateTime)reader["Trandate"];
                    else oItem.TranDate = Convert.ToDateTime("01-Jan-1980");

                    if (reader["TranTypeID"] != DBNull.Value)
                        oItem.TranTypeID =Convert.ToInt16(reader["TranTypeID"]);
                    else oItem.TranTypeID = 0;

                    if (reader["Amount"] != DBNull.Value)
                        oItem.Amount =Convert.ToDouble (reader["Amount"]);
                    else oItem.Amount = -1;

                    if (reader["Debit"] != DBNull.Value)
                        oItem.Debit = Convert.ToDouble(reader["Debit"].ToString());
                    else oItem.Debit = 0;

                    if (reader["Credit"] != DBNull.Value)
                        oItem.Credit = Convert.ToDouble(reader["Credit"].ToString());
                    else oItem.Credit = 0;

                    if (reader["InstrumentNo"] != DBNull.Value)
                        oItem.InstrumentNo = (string)reader["InstrumentNo"];
                    else oItem.InstrumentNo = "";

                    if (reader["InstrumentDate"] != DBNull.Value)
                        oItem.InstrumentDate = (DateTime)reader["InstrumentDate"];
                    else oItem.InstrumentDate = Convert.ToDateTime("01-Jan-1980");

                    if (reader["InstrumentType"] != DBNull.Value)
                        oItem.InstrumentType = (int)reader["InstrumentType"];
                    else oItem.InstrumentType = 0;

                    if (reader["Remarks"] != DBNull.Value)
                        oItem.Remarks = (string)reader["Remarks"];
                    else oItem.Remarks = "";                  
                    

                    if (reader["InstrumentStatus"] != DBNull.Value)
                        oItem.InstrumentStatus = (int)reader["InstrumentStatus"];
                    else oItem.InstrumentStatus = 0;


                    if (reader["BranchID"] != DBNull.Value)
                        oItem.BranchID = (int)reader["BranchID"];
                    else oItem.BranchID = -1;

                    if (reader["BranchCode"] != DBNull.Value)
                        oItem.BranchCode = (string)reader["BranchCode"];
                    else oItem.BranchCode = "";

                    if (reader["BranchName"] != DBNull.Value)
                        oItem.BranchName = (string)reader["BranchName"];
                    else oItem.BranchName = "";

                    if (reader["EntryUserID"] != DBNull.Value)
                        oItem.EntryUserID = (int)reader["EntryUserID"];
                    else oItem.EntryUserID = -1;

                    if (reader["EntryDate"] != DBNull.Value)
                        oItem.EntryDate = (DateTime)reader["EntryDate"];
                    else oItem.EntryDate = Convert.ToDateTime("01-Jan-1980");

                    if (reader["UpdateUserID"] != DBNull.Value)
                        oItem.UpdateUserID = (int)reader["UpdateUserID"];
                    else oItem.UpdateUserID = -1;

                    if (reader["UpdateDate"] != DBNull.Value)
                        oItem.Updatedate = (DateTime)reader["UpdateDate"];
                    else oItem.Updatedate = Convert.ToDateTime("01-Jan-1980");
                    
                    if (reader["Remarks"] != DBNull.Value)
                        oItem.Remarks = (string)reader["Remarks"];
                    else oItem.Remarks = "";

                    if (reader["TranTypeName"] != DBNull.Value)
                        oItem.TranTypeName = (string)reader["TranTypeName"];
                    else oItem.TranTypeName = "";

                    if (reader["TranSide"] != DBNull.Value)
                        oItem.TranSide = (int)reader["TranSide"];
                    else oItem.TranSide = -1;

                    if (reader["IsSystem"] != DBNull.Value)
                        oItem.IsSystem = (int)reader["IsSystem"];
                    else oItem.IsSystem = 0;                                                   
                    
                    if (reader["SBUID"] != DBNull.Value)
                        oItem.SBUID = Convert.ToInt32(reader["SBUID"]);
                    else oItem.SBUID = 0;

                    if (reader["SBUCode"] != DBNull.Value)
                        oItem.SBUCode = (string)reader["SBUCode"];
                    else oItem.SBUCode = "";

                    if (reader["SBUName"] != DBNull.Value)
                        oItem.SBUName = (string)reader["SBUName"];
                    else oItem.SBUName = "";

                    if (reader["ChannelID"] != DBNull.Value)
                        oItem.ChannelID = (int)reader["ChannelID"];
                    else oItem.ChannelID = 0;

                    if (reader["ChannelCode"] != DBNull.Value)
                        oItem.ChannelCode = (string)reader["ChannelCode"];
                    else oItem.ChannelCode = "";

                    if (reader["ChannelDescription"] != DBNull.Value)
                        oItem.ChannelDescription = (string)reader["ChannelDescription"];
                    else oItem.ChannelDescription = "";
                    
                    if (reader["AreaID"] != DBNull.Value)
                        oItem.AreaID = (int)reader["AreaID"];
                    else oItem.AreaID = 0;

                    if (reader["AreaCode"] != DBNull.Value)
                        oItem.AreaCode = (string)reader["AreaCode"];
                    else oItem.AreaCode = "";

                    if (reader["AreaName"] != DBNull.Value)
                        oItem.AreaName = (string)reader["AreaName"];
                    else oItem.AreaName = "";

                    if (reader["TerritoryID"] != DBNull.Value)
                        oItem.TerritoryID = (int)reader["TerritoryID"];
                    else oItem.TerritoryID = 0;

                    if (reader["TerritoryCode"] != DBNull.Value)
                        oItem.TerritoryCode = (string)reader["TerritoryCode"];
                    else oItem.TerritoryCode = "";

                    if (reader["TerritoryName"] != DBNull.Value)
                        oItem.TerritoryName = (string)reader["TerritoryName"];
                    else oItem.TerritoryName = "";

                    if (reader["UserName"] != DBNull.Value)
                        oItem.UserName = (string)reader["UserName"];
                    else oItem.UserName = "";

                    if (reader["UserFullName"] != DBNull.Value)
                        oItem.UserFullName = (string)reader["UserFullName"];
                    else oItem.UserFullName = "";

                    if (reader["BankID"] != DBNull.Value)
                        oItem.BankID = (int)reader["BankID"];
                    else oItem.BankID = 0;

                    if (reader["BankCode"] != DBNull.Value)
                        oItem.BankCode = (string)reader["BankCode"];
                    else oItem.BankCode = "";

                    if (reader["BankName"] != DBNull.Value)
                        oItem.BankName = (string)reader["BankName"];
                    else oItem.BankName = "";
                    
                    Add(oItem);

                    //InnerList.Add(oItem);
                }
                reader.Close();
                //InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void FromDataSetCustomerTransaction(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    RptCustomerTransaction oRptCustomerTransaction = new RptCustomerTransaction();

                    oRptCustomerTransaction.TranID = Convert.ToInt32(oRow["TranID"]);
                    oRptCustomerTransaction.TranNo = (string)oRow["TranNo"];

                    oRptCustomerTransaction.CustomerID = Convert.ToInt32(oRow["CustomerID"]);
                    oRptCustomerTransaction.CustomerCode = (string)oRow["CustomerCode"];
                    oRptCustomerTransaction.CustomerName = (string)oRow["CustomerName"];

                    oRptCustomerTransaction.TranDate = Convert.ToDateTime(oRow["TranDate"]);
                    oRptCustomerTransaction.TranTypeID = Convert.ToInt16(oRow["TranTypeID"]);
                    oRptCustomerTransaction.Amount = Convert.ToDouble(oRow["TranTypeID"]);
                    oRptCustomerTransaction.Debit = Convert.ToDouble(oRow["Debit"]);
                    oRptCustomerTransaction.Credit = Convert.ToDouble(oRow["Credit"]);
                    oRptCustomerTransaction.InstrumentNo = (string)oRow["InstrumentNo"];
                    oRptCustomerTransaction.InstrumentDate = Convert.ToDateTime(oRow["InstrumentDate"]);
                    oRptCustomerTransaction.InstrumentType = Convert.ToInt16(oRow["InstrumentType"]);
                    oRptCustomerTransaction.InstrumentStatus = Convert.ToInt16(oRow["InstrumentStatus"]);

                    oRptCustomerTransaction.BranchID = Convert.ToInt32(oRow["BranchID"]);
                    oRptCustomerTransaction.BranchCode = (string)oRow["BranchCode"];
                    oRptCustomerTransaction.BranchName = (string)oRow["BranchName"];

                    oRptCustomerTransaction.EntryUserID = Convert.ToInt32(oRow["EntryUserID"]);
                    oRptCustomerTransaction.EntryDate = Convert.ToDateTime(oRow["EntryDate"]);
                    oRptCustomerTransaction.UpdateUserID = Convert.ToInt32(oRow["UpdateUserID"]);
                    oRptCustomerTransaction.Updatedate = Convert.ToDateTime(oRow["Updatedate"]);
                    oRptCustomerTransaction.Remarks = (string)oRow["Remarks"];
                    oRptCustomerTransaction.TranTypeName = (string)oRow["TranTypeName"];
                    oRptCustomerTransaction.TranSide = Convert.ToInt32(oRow["TranSide"]);
                    oRptCustomerTransaction.IsSystem = Convert.ToInt32(oRow["IsSystem"]);
                                        
                    oRptCustomerTransaction.SBUID = Convert.ToInt32(oRow["SBUID"]);
                    oRptCustomerTransaction.SBUCode = (string)oRow["SBUCode"];
                    oRptCustomerTransaction.SBUName = (string)oRow["SBUName"];

                    oRptCustomerTransaction.ChannelID = Convert.ToInt32(oRow["ChannelID"]);
                    oRptCustomerTransaction.ChannelCode = (string)oRow["ChannelCode"];
                    oRptCustomerTransaction.ChannelDescription = (string)oRow["ChannelDescription"];                    

                    oRptCustomerTransaction.AreaID = Convert.ToInt32(oRow["AreaID"]);
                    oRptCustomerTransaction.AreaCode = (string)oRow["AreaCode"];
                    oRptCustomerTransaction.AreaName = (string)oRow["AreaName"];

                    oRptCustomerTransaction.TerritoryID = Convert.ToInt32(oRow["TerritoryID"]);
                    oRptCustomerTransaction.TerritoryCode = (string)oRow["TerritoryCode"];
                    oRptCustomerTransaction.TerritoryName = (string)oRow["TerritoryName"];

                    oRptCustomerTransaction.UserName = (string)oRow["UserName"];
                    oRptCustomerTransaction.UserFullName = (string)oRow["UserFullName"];
                    oRptCustomerTransaction.BankID = Convert.ToInt32(oRow["BankID"]);
                    oRptCustomerTransaction.BankCode = (string)oRow["BankCode"];
                    oRptCustomerTransaction.BankName = (string)oRow["BankName"];

                    InnerList.Add(oRptCustomerTransaction);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    
    }
}
