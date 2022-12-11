// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak k. Chakraborty
// Date: Nov 19, 2012
// Time" :  10:30 AM
// Description: Customer Transaction ledger TEL & BLL combined [807]
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

   public class CustTranLedgerTELNBLL
    {
        
        private long _lCustomerID;
        private string _sCustomerCode;
        private string _sCustomerName;
        private string _sCustomerAddress;
        private string _sCustomerTelephone;
        private string _sCellphoneNo;
        private string _sContractperson;        
        private string _sTranNo;
        private long _lTranID;
        private DateTime _dTranDate;
        private string _sTranTypeName;
        private int _nTranSide;
        private string _sInstrumentNo;        
        private int _sInstrumentType;
        private string _sInstType;
          
        
        private double _Debit;
        private double _Credit;
        private string _sRemarks;
        private string _sCompany;
        private double _BLLOpeningOS;
        private double _TELOpeningOS;
        private double _TELBLLOS;        
        private double _Outstanding; 
        
        private double _OpeningOutstanding;            
        


       

        public long CustomerID
        {
            get { return _lCustomerID; }
            set { _lCustomerID = value; }
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
        public string CustomerAddress
        {
            get { return _sCustomerAddress; }
            set { _sCustomerAddress = value; }

        }
        public string CustomerTelephone
        {
            get { return _sCustomerTelephone; }
            set { _sCustomerTelephone = value; }

        }
        public string CellphoneNo
        {
            get { return _sCellphoneNo; }
            set { _sCellphoneNo = value; }

        }
        public string Contractperson
        {
            get { return _sContractperson; }
            set { _sContractperson = value; }

        }
        public long TranID
        {
            get { return _lTranID; }
            set { _lTranID = value; }
        }
        public string TranNo
        {
            get { return _sTranNo; }
            set { _sTranNo = value; }
        }

        public DateTime TranDate
        {
            get { return _dTranDate; }
            set { _dTranDate = value; }
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
        
        public string InstrumentNo
        {
            get { return _sInstrumentNo; }
            set { _sInstrumentNo = value; }
        }
        
        public int InstrumentType
        {
            get { return _sInstrumentType; }
            set { _sInstrumentType = value; }
        }
       public string InstType
       {
           get { return _sInstType; }
           set { _sInstType = value; }
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
       public string Remarks
       {
           get { return _sRemarks; }
           set { _sRemarks = value; }
       }
       public string Company
       {
           get { return _sCompany; }
           set { _sCompany = value; }
       } 
                
        public double BLLOpeningOS
        {
            get { return _BLLOpeningOS; }
            set { _BLLOpeningOS = value; }
        }

        public double TELOpeningOS
        {
           get { return _TELOpeningOS; }
           set { _TELOpeningOS = value; }
        }

        public double TELBLLOS
        {
            get { return _TELBLLOS; }
            set { _TELBLLOS = value; }
        }
       public double Outstanding
        {
            get { return _Outstanding; }
            set { _Outstanding = value; }
        }
        
        public double OpeningOutstanding
        {
            get { return _OpeningOutstanding; }
            set { _OpeningOutstanding = value; }
        }
        
           
        
    }

    public class CustTranLedgerTELNBLLDetails : CollectionBaseCustom
    {
        public void Add(CustTranLedgerTELNBLL oCustTranLedgerTELNBLL)
        {
            this.List.Add(oCustTranLedgerTELNBLL);
        }

        public CustTranLedgerTELNBLL this[Int32 Index]
        {
            get
            {
                return (CustTranLedgerTELNBLL)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(CustTranLedgerTELNBLL))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }


        public void CustomerTranTELBLL(DateTime dYFromDate, DateTime dYToDate, string sCustomerCode)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            // Query for the report [807]
               

                    sQueryStringMaster.Append(" select Qu1.CustomerID,Qu1.CustomerCode, Qu1.CustomerName,  ");
                    sQueryStringMaster.Append(" Qu1.CustomerAddress, Qu1.CustomerTelephone, Qu1.CellphoneNo,Qu1.Contractperson, Qu1.TranID,Qu1.TranNo,  ");
                    sQueryStringMaster.Append(" Qu1.TranDate,Qu1.TranTypeName,Qu1.TranSide, Qu1.InstrumentNo,Qu1.InstrumentType, Qu1.Debit,Qu1.Credit,Qu1.Remarks, ");
                    sQueryStringMaster.Append(" Qu1.Company,Qu2.BLLOpeningOS,Qu2.TELOpeningOS,Qu2.TELBLLOS ");
                    sQueryStringMaster.Append(" from ");
                    sQueryStringMaster.Append(" ( ");
                    sQueryStringMaster.Append(" select Total.CustomerID,Total.CustomerCode, Total.CustomerName,  ");
                    sQueryStringMaster.Append(" Total.CustomerAddress, Total.CustomerTelephone, Total.CellphoneNo,Total.Contractperson, Total.TranID,Total.TranNo,  ");
                    sQueryStringMaster.Append(" Total.TranDate,Total.TranTypeName,Total.TranSide, Total.InstrumentNo,Total.InstrumentType, Total.Debit,Total.Credit,Total.Remarks,Total.OpeningOS,Total.Company ");

                    sQueryStringMaster.Append(" from  ");
                    sQueryStringMaster.Append(" ( ");
                    sQueryStringMaster.Append(" select  details.CustomerID,details.CustomerCode, details.CustomerName,  ");
                    sQueryStringMaster.Append(" details.CustomerAddress, details.CustomerTelephone, details.CellphoneNo,details.Contractperson, Final.TranID,Final.TranNo,  ");
                    sQueryStringMaster.Append(" Final.TranDate,Final.TranTypeName,Final.TranSide, Final.InstrumentNo,Final.InstrumentType, Final.Debit,Final.Credit,Final.Remarks,Final.OpeningOS,'BLL' as Company  ");
                    sQueryStringMaster.Append(" from  ");
                    sQueryStringMaster.Append(" ( ");
                    sQueryStringMaster.Append(" Select a.*, isnull(OpeningOS,0) as OpeningOS ");
                    sQueryStringMaster.Append(" from ");
                    sQueryStringMaster.Append(" ( ");
                    sQueryStringMaster.Append(" select q6.*,TranTypeCode,TranTypeName,TranSide,(case q7.TranSide When 1 then q6.Amount End) as Credit,(case q7.TranSide When 2 then q6.Amount End) as Debit  ");
                    sQueryStringMaster.Append(" from  ");
                    sQueryStringMaster.Append(" ( ");
                    sQueryStringMaster.Append(" select * from bllsysdb.dbo.t_CustomerTran Where TranDate Between ? and ? and TranDate< ?  ");
                    sQueryStringMaster.Append(" ) as q6  ");
                    sQueryStringMaster.Append("  Left Outer Join  ");
                    sQueryStringMaster.Append(" ( ");
                    sQueryStringMaster.Append(" select TranTypeID,TranTypeCode,TranTypeName,TranSide from bllsysdb.dbo.t_CustomerTranType ");
                    sQueryStringMaster.Append(" ) as q7 on q7.TranTypeID=q6.TranTypeID  ");
                    sQueryStringMaster.Append(" ) as a ");
                    sQueryStringMaster.Append(" Left outer Join ");
                    sQueryStringMaster.Append(" ( ");
                    sQueryStringMaster.Append(" Select q1.CustomerID,(((q1.CurrentBalance - isnull(q2.CreditAmount,0) ) + isnull(q3.DebitAmount,0))*-1) as OpeningOS ");
                    sQueryStringMaster.Append(" from ");
                    sQueryStringMaster.Append(" (  ");
                    sQueryStringMaster.Append(" select customerid, CurrentBalance from bllsysdb.dbo.t_customerAccount   ");
                    sQueryStringMaster.Append(" )  ");
                    sQueryStringMaster.Append(" as q1   ");
                    sQueryStringMaster.Append(" left outer join ");
                    sQueryStringMaster.Append(" (   ");
                    sQueryStringMaster.Append(" select customerid, sum(amount)as CreditAmount from bllsysdb.dbo.t_customerTran ct, bllsysdb.dbo.t_customerTrantype ctt  ");
                    sQueryStringMaster.Append(" where ct.trantypeid = ctt.trantypeid and transide = 1 and ct.TranDate between ? and ? ");
                    sQueryStringMaster.Append(" group by customerid   ");
                    sQueryStringMaster.Append(" )    ");
                    sQueryStringMaster.Append(" as q2   ");
                    sQueryStringMaster.Append(" on q1.customerid = q2.customerid  ");
                    sQueryStringMaster.Append(" left outer join   ");
                    sQueryStringMaster.Append(" (  ");
                    sQueryStringMaster.Append(" select customerid, sum(amount)as DebitAmount from bllsysdb.dbo.t_customerTran ct, bllsysdb.dbo.t_customerTrantype ctt    ");
                    sQueryStringMaster.Append(" where ct.trantypeid = ctt.trantypeid and transide = 2  and ct.TranDate between ? and ? ");
                    sQueryStringMaster.Append(" group by customerid   ");
                    sQueryStringMaster.Append(" ) as q3  ");
                    sQueryStringMaster.Append(" on q1.customerid = q3.customerid  ");
                    sQueryStringMaster.Append(" ) as b on a.customerid = b.customerid ");
                    sQueryStringMaster.Append(" ) as Final  ");
                    sQueryStringMaster.Append(" inner join ");
                    sQueryStringMaster.Append(" ( ");
                    sQueryStringMaster.Append(" select * from bllsysdb.dbo.v_customerdetails ");
                    sQueryStringMaster.Append(" ) as details on Final.customerid = details.customerid ");
                     
                    sQueryStringMaster.Append(" Union all  ");
                       
                    sQueryStringMaster.Append(" select  details.CustomerID,details.CustomerCode, details.CustomerName,  ");
                    sQueryStringMaster.Append(" details.CustomerAddress, details.CustomerTelephone, details.CellphoneNo,details.Contractperson, Final.TranID,Final.TranNo,  ");
                    sQueryStringMaster.Append(" Final.TranDate,Final.TranTypeName,Final.TranSide, Final.InstrumentNo,Final.InstrumentType, Final.Debit,Final.Credit,Final.Remarks,Final.OpeningOS,'TEL' as Company  ");
                    sQueryStringMaster.Append(" from  ");
                    sQueryStringMaster.Append(" ( ");
                    sQueryStringMaster.Append(" Select a.*, isnull(OpeningOS,0) as OpeningOS ");
                    sQueryStringMaster.Append(" from ");
                    sQueryStringMaster.Append(" ( ");
                    sQueryStringMaster.Append(" select q6.*,TranTypeCode,TranTypeName,TranSide,(case q7.TranSide When 1 then q6.Amount End) as Credit,(case q7.TranSide When 2 then q6.Amount End) as Debit  ");
                    sQueryStringMaster.Append(" from  ");
                    sQueryStringMaster.Append(" ( ");
                    sQueryStringMaster.Append(" select * from telsysdb.dbo.t_CustomerTran Where TranDate Between ? and ? and TranDate< ?  ");
                    sQueryStringMaster.Append(" ) as q6  ");
                    sQueryStringMaster.Append("  Left Outer Join  ");
                    sQueryStringMaster.Append(" ( ");
                    sQueryStringMaster.Append(" select TranTypeID,TranTypeCode,TranTypeName,TranSide from telsysdb.dbo.t_CustomerTranType ");
                    sQueryStringMaster.Append(" ) as q7 on q7.TranTypeID=q6.TranTypeID  ");
                    sQueryStringMaster.Append(" ) as a ");
                    sQueryStringMaster.Append(" Left outer Join ");
                    sQueryStringMaster.Append(" ( ");
                    sQueryStringMaster.Append(" Select q1.CustomerID,(((q1.CurrentBalance - isnull(q2.CreditAmount,0) ) + isnull(q3.DebitAmount,0))*-1) as OpeningOS ");
                    sQueryStringMaster.Append(" from ");
                    sQueryStringMaster.Append(" (  ");
                    sQueryStringMaster.Append(" select customerid, CurrentBalance from telsysdb.dbo.t_customerAccount   ");
                    sQueryStringMaster.Append(" )  ");
                    sQueryStringMaster.Append(" as q1  "); 
                    sQueryStringMaster.Append(" left outer join ");
                    sQueryStringMaster.Append(" (  ");
                    sQueryStringMaster.Append(" select customerid, sum(amount)as CreditAmount from telsysdb.dbo.t_customerTran ct, telsysdb.dbo.t_customerTrantype ctt  ");
                    sQueryStringMaster.Append(" where ct.trantypeid = ctt.trantypeid and transide = 1 and ct.TranDate between ? and ? ");
                    sQueryStringMaster.Append(" group by customerid   ");
                    sQueryStringMaster.Append(" )    ");
                    sQueryStringMaster.Append(" as q2   ");
                    sQueryStringMaster.Append(" on q1.customerid = q2.customerid  ");
                    sQueryStringMaster.Append(" left outer join   ");
                    sQueryStringMaster.Append(" ( ");
                    sQueryStringMaster.Append(" select customerid, sum(amount)as DebitAmount from telsysdb.dbo.t_customerTran ct, telsysdb.dbo.t_customerTrantype ctt    ");
                    sQueryStringMaster.Append(" where ct.trantypeid = ctt.trantypeid and transide = 2  and ct.TranDate between ? and ? ");
                    sQueryStringMaster.Append(" group by customerid   ");
                    sQueryStringMaster.Append(" ) as q3  ");
                    sQueryStringMaster.Append(" on q1.customerid = q3.customerid  ");
                    sQueryStringMaster.Append(" ) as b on a.customerid = b.customerid ");
                    sQueryStringMaster.Append(" ) as Final  ");
                    sQueryStringMaster.Append(" inner join ");
                    sQueryStringMaster.Append(" ( ");
                    sQueryStringMaster.Append(" select * from telsysdb.dbo.v_customerdetails ");
                    sQueryStringMaster.Append(" ) as details on Final.customerid = details.customerid  ");
                    sQueryStringMaster.Append("  ) As Total ");
                    sQueryStringMaster.Append(" where CustomerCode= ? ");

                    sQueryStringMaster.Append(" ) as Qu1 ");

                   sQueryStringMaster.Append("  left outer join ");
                   sQueryStringMaster.Append("  ( ");
                   sQueryStringMaster.Append("  select Final.CustomerCode, Final.BLLOpeningOS,Final.TELOpeningOS, sum(Final.BLLOpeningOS+ Final.TELOpeningOS)as TELBLLOS ");
                   sQueryStringMaster.Append(" from ");
                   sQueryStringMaster.Append(" ( ");
                   sQueryStringMaster.Append(" select isnull(Q1.CustomerCode, Q2.CustomerCode)as CustomerCode,isnull(q1.BLLOpeningOS,0) as BLLOpeningOS, isnull (q2.TELOpeningOS, 0)as TELOpeningOS ");
                   sQueryStringMaster.Append(" from ");
                   sQueryStringMaster.Append(" (  ");
                   sQueryStringMaster.Append("  select BLL.CustomerCode, BLL.CustomerName, BLL.OpeningOS as BLLOpeningOS ,BLL.Company  ");
                   sQueryStringMaster.Append("  from  ");
                   sQueryStringMaster.Append("  ( ");
                   sQueryStringMaster.Append("  select details.CustomerCode, details.CustomerName, Final.OpeningOS,'BLL' as Company  ");
                   sQueryStringMaster.Append("  from  ");
                   sQueryStringMaster.Append("  ( ");
                   sQueryStringMaster.Append("  Select a.*, isnull(OpeningOS,0) as OpeningOS ");
                   sQueryStringMaster.Append("  from ");
                   sQueryStringMaster.Append("  ( ");
                   sQueryStringMaster.Append("  select q6.*,TranTypeCode,TranTypeName,TranSide,(case q7.TranSide When 1 then q6.Amount End) as Credit,(case q7.TranSide When 2 then q6.Amount End) as Debit  ");
                   sQueryStringMaster.Append("  from  ");
                   sQueryStringMaster.Append(" ( ");
                   sQueryStringMaster.Append("  select * from bllsysdb.dbo.t_CustomerTran Where TranDate Between ? and ? and TranDate< ?  ");
                   sQueryStringMaster.Append("  ) as q6  ");
                   sQueryStringMaster.Append("   Left Outer Join  ");
                   sQueryStringMaster.Append("  ( ");
                   sQueryStringMaster.Append("  select TranTypeID,TranTypeCode,TranTypeName,TranSide from bllsysdb.dbo.t_CustomerTranType ");
                    sQueryStringMaster.Append(" ) as q7 on q7.TranTypeID=q6.TranTypeID  ");
                    sQueryStringMaster.Append(" ) as a ");
                    sQueryStringMaster.Append("  Left outer Join ");
                    sQueryStringMaster.Append(" ( ");
                    sQueryStringMaster.Append(" Select q1.CustomerID,(((q1.CurrentBalance - isnull(q2.CreditAmount,0) ) + isnull(q3.DebitAmount,0))*-1) as OpeningOS ");
                    sQueryStringMaster.Append(" from ");
                    sQueryStringMaster.Append(" (  ");
                    sQueryStringMaster.Append(" select customerid, CurrentBalance from bllsysdb.dbo.t_customerAccount   ");
                    sQueryStringMaster.Append(" )  ");
                    sQueryStringMaster.Append(" as q1  "); 
                    sQueryStringMaster.Append(" left outer join ");
                    sQueryStringMaster.Append(" (   ");
                    sQueryStringMaster.Append(" select customerid, sum(amount)as CreditAmount from bllsysdb.dbo.t_customerTran ct, bllsysdb.dbo.t_customerTrantype ctt  ");
                    sQueryStringMaster.Append(" where ct.trantypeid = ctt.trantypeid and transide = 1 and ct.TranDate between ? and ? ");
                    sQueryStringMaster.Append(" group by customerid   ");
                    sQueryStringMaster.Append(" )    ");
                    sQueryStringMaster.Append(" as q2  ");
                    sQueryStringMaster.Append(" on q1.customerid = q2.customerid  ");
                    sQueryStringMaster.Append(" left outer join   ");
                    sQueryStringMaster.Append(" (  ");
                    sQueryStringMaster.Append(" select customerid, sum(amount)as DebitAmount from bllsysdb.dbo.t_customerTran ct, bllsysdb.dbo.t_customerTrantype ctt    ");
                    sQueryStringMaster.Append(" where ct.trantypeid = ctt.trantypeid and transide = 2  and ct.TranDate between ? and ? ");
                    sQueryStringMaster.Append(" group by customerid   ");
                    sQueryStringMaster.Append(" ) as q3  ");
                    sQueryStringMaster.Append("  on q1.customerid = q3.customerid  ");
                    sQueryStringMaster.Append("  ) as b on a.customerid = b.customerid ");
                    sQueryStringMaster.Append("  ) as Final  ");
                    sQueryStringMaster.Append("  inner join ");
                    sQueryStringMaster.Append("  ( ");
                    sQueryStringMaster.Append("  select * from bllsysdb.dbo.v_customerdetails ");
                    sQueryStringMaster.Append("  ) as details on Final.customerid = details.customerid ");
                    sQueryStringMaster.Append(" where Customercode=? ");
                    sQueryStringMaster.Append(" group by details.CustomerID,details.CustomerCode, details.CustomerName, Final.OpeningOS ");
                    sQueryStringMaster.Append("  ) as BLL ");
                   sQueryStringMaster.Append(" ) as q1 ");
                   sQueryStringMaster.Append(" full outer join ");
                   sQueryStringMaster.Append(" ( ");
                     
                   sQueryStringMaster.Append(" select TEL.CustomerCode, TEL.CustomerName, TEL.OpeningOS as TELOpeningOS,TEL.Company  ");
                   sQueryStringMaster.Append("  from  ");
                   sQueryStringMaster.Append("  ( ");
                   sQueryStringMaster.Append("  select details.CustomerCode, details.CustomerName, Final.OpeningOS,'TEL' as Company  ");
                   sQueryStringMaster.Append("  from  ");
                   sQueryStringMaster.Append("  ( ");
                   sQueryStringMaster.Append("  Select a.*, isnull(OpeningOS,0) as OpeningOS ");
                   sQueryStringMaster.Append("  from ");
                   sQueryStringMaster.Append("  ( ");
                    sQueryStringMaster.Append(" select q6.*,TranTypeCode,TranTypeName,TranSide,(case q7.TranSide When 1 then q6.Amount End) as Credit,(case q7.TranSide When 2 then q6.Amount End) as Debit  ");
                   sQueryStringMaster.Append("  from  ");
                   sQueryStringMaster.Append("  ( ");
                   sQueryStringMaster.Append("  select * from telsysdb.dbo.t_CustomerTran Where TranDate Between ? and ? and TranDate< ?  ");
                   sQueryStringMaster.Append("  ) as q6  ");
                   sQueryStringMaster.Append("   Left Outer Join ");
                   sQueryStringMaster.Append("  ( ");
                   sQueryStringMaster.Append("  select TranTypeID,TranTypeCode,TranTypeName,TranSide from bllsysdb.dbo.t_CustomerTranType ");
                   sQueryStringMaster.Append("  ) as q7 on q7.TranTypeID=q6.TranTypeID  ");
                   sQueryStringMaster.Append("  ) as a ");
                   sQueryStringMaster.Append("  Left outer Join ");
                   sQueryStringMaster.Append("  ( ");
                   sQueryStringMaster.Append("  Select q1.CustomerID,(((q1.CurrentBalance - isnull(q2.CreditAmount,0) ) + isnull(q3.DebitAmount,0))*-1) as OpeningOS ");
                   sQueryStringMaster.Append("  from ");
                   sQueryStringMaster.Append("  ( ");
                   sQueryStringMaster.Append("  select customerid, CurrentBalance from telsysdb.dbo.t_customerAccount   ");
                   sQueryStringMaster.Append("  )  ");
                   sQueryStringMaster.Append("  as q1  "); 
                   sQueryStringMaster.Append("  left outer join ");
                   sQueryStringMaster.Append("  (   ");
                   sQueryStringMaster.Append("  select customerid, sum(amount)as CreditAmount from telsysdb.dbo.t_customerTran ct, telsysdb.dbo.t_customerTrantype ctt  ");
                   sQueryStringMaster.Append("  where ct.trantypeid = ctt.trantypeid and transide = 1 and ct.TranDate between ? and ? ");
                   sQueryStringMaster.Append("  group by customerid   ");
                   sQueryStringMaster.Append("  )    ");
                   sQueryStringMaster.Append("  as q2   ");
                   sQueryStringMaster.Append("  on q1.customerid = q2.customerid  ");
                   sQueryStringMaster.Append("  left outer join   ");
                   sQueryStringMaster.Append("  (  ");
                   sQueryStringMaster.Append("  select customerid, sum(amount)as DebitAmount from telsysdb.dbo.t_customerTran ct, telsysdb.dbo.t_customerTrantype ctt    ");
                   sQueryStringMaster.Append("  where ct.trantypeid = ctt.trantypeid and transide = 2  and ct.TranDate between ? and ? ");
                   sQueryStringMaster.Append("  group by customerid  ");
                   sQueryStringMaster.Append("  ) as q3 ");
                   sQueryStringMaster.Append("  on q1.customerid = q3.customerid  ");
                   sQueryStringMaster.Append("  ) as b on a.customerid = b.customerid ");
                   sQueryStringMaster.Append("  ) as Final  ");
                   sQueryStringMaster.Append("  inner join ");
                   sQueryStringMaster.Append("  ( ");
                   sQueryStringMaster.Append("  select * from telsysdb.dbo.v_customerdetails ");
                   sQueryStringMaster.Append("  ) as details on Final.customerid = details.customerid ");
                   sQueryStringMaster.Append(" where Customercode= ? ");
                   sQueryStringMaster.Append(" group by details.CustomerID,details.CustomerCode, details.CustomerName, Final.OpeningOS ");
                   sQueryStringMaster.Append(" ) as TEL  ");
                   sQueryStringMaster.Append(" ) as q2 on q1.CustomerCode=q2.CustomerCode  ");
                   sQueryStringMaster.Append(" )as Final  ");
                   sQueryStringMaster.Append(" group by Final.CustomerCode, Final.BLLOpeningOS,Final.TELOpeningOS ");
                   sQueryStringMaster.Append("  ) Qu2 on Qu1.CustomerCode=Qu2.CustomerCode ");
                   sQueryStringMaster.Append(" order by TranDate ");
                  


            
            OleDbCommand oCmd = DBController.Instance.GetCommand();
            //Command time out
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();


            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.AddDays(1));           

            oCmd.Parameters.AddWithValue("ct.TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("ct.TranDate", DateTime.Today.Date.AddDays(1));

            oCmd.Parameters.AddWithValue("ct.TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("ct.TranDate", DateTime.Today.Date.AddDays(1));

            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.AddDays(1));

            oCmd.Parameters.AddWithValue("ct.TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("ct.TranDate", DateTime.Today.Date.AddDays(1));

            oCmd.Parameters.AddWithValue("ct.TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("ct.TranDate", DateTime.Today.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("CustomerCode", (string)sCustomerCode);



            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.AddDays(1));


            oCmd.Parameters.AddWithValue("ct.TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("ct.TranDate", DateTime.Today.Date.AddDays(1));

            oCmd.Parameters.AddWithValue("ct.TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("ct.TranDate", DateTime.Today.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("CustomerCode", (string)sCustomerCode);

            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.AddDays(1));

            oCmd.Parameters.AddWithValue("ct.TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("ct.TranDate", DateTime.Today.Date.AddDays(1));

            oCmd.Parameters.AddWithValue("ct.TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("ct.TranDate", DateTime.Today.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("CustomerCode", (string)sCustomerCode);


            GetDataCustomerTranTELNBLL(oCmd);

        }
        private void GetDataCustomerTranTELNBLL(OleDbCommand cmd)
        {
            int nSum = 0;
            int nCount = 0;
            int nCCount = 0;
           
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustTranLedgerTELNBLL oItem = new CustTranLedgerTELNBLL();

                    if (reader["CustomerId"] != DBNull.Value)
                        oItem.CustomerID = Convert.ToInt32(reader["CustomerId"]);
                    else oItem.CustomerID = 0;

                    if (reader["CustomerCode"] != DBNull.Value)
                        oItem.CustomerCode = (string)reader["CustomerCode"];
                    else oItem.CustomerCode = "";

                    if (reader["CustomerName"] != DBNull.Value)
                        oItem.CustomerName = (string)reader["CustomerName"];
                    else oItem.CustomerName = "";

                    if (reader["CustomerAddress"] != DBNull.Value)
                        oItem.CustomerAddress = (string)reader["CustomerAddress"];
                    else oItem.CustomerAddress = "";

                    if (reader["CustomerTelephone"] != DBNull.Value)
                        oItem.CustomerTelephone = (string)reader["CustomerTelephone"];
                    else oItem.CustomerTelephone = "";

                    if (reader["CellphoneNo"] != DBNull.Value)
                        oItem.CellphoneNo = (string)reader["CellphoneNo"];
                    else oItem.CellphoneNo = "";

                    if (reader["Contractperson"] != DBNull.Value)
                        oItem.Contractperson = (string)reader["Contractperson"];
                    else oItem.Contractperson = "";

                    if (reader["TranID"] != DBNull.Value)
                        oItem.TranID = Convert.ToInt32(reader["TranID"]);
                    else oItem.TranID = -1;

                    if (reader["TranNo"] != DBNull.Value)
                        oItem.TranNo = (string)reader["TranNo"];
                    else oItem.TranNo = "";

                    if (reader["Trandate"] != DBNull.Value)
                        oItem.TranDate = (DateTime)reader["Trandate"];
                    else oItem.TranDate = Convert.ToDateTime("01-Jan-1980");

                    if (reader["TranTypeName"] != DBNull.Value)
                        oItem.TranTypeName = (string)reader["TranTypeName"];
                    else oItem.TranTypeName = "";

                    if (reader["TranSide"] != DBNull.Value)
                        oItem.TranSide = Convert.ToInt32(reader["TranSide"]);
                    else oItem.TranSide = -1;


                    if (reader["InstrumentNo"] != DBNull.Value)
                        oItem.InstrumentNo = (string)reader["InstrumentNo"];
                    else oItem.InstrumentNo = "";

                    if (reader["InstrumentType"] != DBNull.Value)
                    {
                        oItem.InstrumentType = int.Parse(reader["InstrumentType"].ToString());
                        if (oItem.InstrumentType == 0)
                        {
                            oItem.InstType = "DD";

                        }
                        if (oItem.InstrumentType == 1)
                        {
                            oItem.InstType = "Payorder";

                        }
                        if (oItem.InstrumentType == 2)
                        {
                            oItem.InstType = "Cash";

                        }
                        if (oItem.InstrumentType == 3)
                        {
                            oItem.InstType = "Cheque";

                        }
                        if (oItem.InstrumentType == 4)
                        {
                            oItem.InstType = "TT";

                        }
                    }
                    else oItem.InstrumentType = -1;

                    if (reader["Remarks"] != DBNull.Value)
                        oItem.Remarks = (string)reader["Remarks"];
                    else oItem.Remarks = "";

                    if (reader["Company"] != DBNull.Value)
                        oItem.Company = (string)reader["Company"];
                    else oItem.Company = "";

                    if (nCount == 0)
                    {
                        if (reader["TELBLLOS"] != DBNull.Value)
                        {

                            oItem.TELBLLOS = Convert.ToDouble(reader["TELBLLOS"]);
                            oItem.Outstanding = Convert.ToDouble(reader["TELBLLOS"]);
                            ++nCount;

                        }
                        else
                        {
                            oItem.TELBLLOS = 0;
                            oItem.Outstanding = 0;
                        }
                    }              
                    
                    if (reader["Debit"] != DBNull.Value)
                    {
                        oItem.Debit = Convert.ToDouble(reader["Debit"]);
                    }
                    else oItem.Debit = 0;

                    if (reader["Credit"] != DBNull.Value)
                    {
                        oItem.Credit = Convert.ToDouble(reader["Credit"]);
                    }
                    else oItem.Credit = 0;

                    InnerList.Add(oItem);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void FromDataSetForCustTranTELNBLL(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    CustTranLedgerTELNBLL oCustTranLedgerTELNBLL = new CustTranLedgerTELNBLL();


                    oCustTranLedgerTELNBLL.CustomerID = Convert.ToInt32(oRow["CustomerID"]);
                    oCustTranLedgerTELNBLL.CustomerCode = (string)oRow["CustomerCode"];
                    oCustTranLedgerTELNBLL.CustomerName = (string)oRow["CustomerName"];
                    oCustTranLedgerTELNBLL.CustomerAddress = (string)oRow["CustomerAddress"];
                    oCustTranLedgerTELNBLL.CustomerTelephone = (string)oRow["CustomerTelephone"];
                    oCustTranLedgerTELNBLL.CellphoneNo = (string)oRow["CellphoneNo"];
                    oCustTranLedgerTELNBLL.Contractperson = (string)oRow["Contractperson"];
                    oCustTranLedgerTELNBLL.TranID = Convert.ToInt32(oRow["TranID"]);
                    oCustTranLedgerTELNBLL.TranNo = (string)oRow["TranNo"];
                    
                    oCustTranLedgerTELNBLL.TranDate = (DateTime)oRow["TranDate"];
                    oCustTranLedgerTELNBLL.TranTypeName = (string)oRow["TraTypeName"];
                    oCustTranLedgerTELNBLL.TranSide = Convert.ToInt32(oRow["TranSide"]);
                    
                    oCustTranLedgerTELNBLL.InstrumentNo = (string)oRow["InstrumentNo"];
                    oCustTranLedgerTELNBLL.InstrumentType = Convert.ToInt16(oRow["InstrumentType"]);
                    oCustTranLedgerTELNBLL.InstType = (string)oRow["InstType"];

                    oCustTranLedgerTELNBLL.Debit = (double)oRow["Debit"];
                    oCustTranLedgerTELNBLL.Credit = (double)oRow["Credit"];
                    oCustTranLedgerTELNBLL.Remarks = (string)oRow["Remarks"];
                    oCustTranLedgerTELNBLL.Company = (string)oRow["Company"];
                    //oCustTranLedgerTELNBLL.BLLOpeningOS = (double)oRow["BLLOpeningOS"];
                    //oCustTranLedgerTELNBLL.TELOpeningOS = (double)oRow["TELOpeningOS"];
                    oCustTranLedgerTELNBLL.TELBLLOS = (double)oRow["TELBLLOS"];
                    InnerList.Add(oCustTranLedgerTELNBLL);

                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetCustomerTransection()
        {
            double _Outstanding = 0;
            int _nCount = 0;
            foreach (CustTranLedgerTELNBLL oCustTranLedgerTELNBLL in this)
            {
                if (_nCount == 0)
                {
                    _Outstanding = oCustTranLedgerTELNBLL.Outstanding; 
                    _nCount++;
                }

                if (oCustTranLedgerTELNBLL.Debit >= 0)
                {
                    _Outstanding = _Outstanding + oCustTranLedgerTELNBLL.Debit;
                    oCustTranLedgerTELNBLL.Outstanding = _Outstanding;

                }
                if (oCustTranLedgerTELNBLL.Credit >= 0)
                {
                    _Outstanding = _Outstanding - oCustTranLedgerTELNBLL.Credit;
                    oCustTranLedgerTELNBLL.Outstanding = _Outstanding;
                }
            }
        }


    
    }
}
