using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Library;
using CJ.Class;

namespace CJ.Class.ANDROID
{
    public class TargetVsAch
    {

        
        private string _sChannelName;
        private string _sAreaName;
        private int _nAreaID;
        private string _sTerritoryName;
        private int _nCustomerID;

        private int _nRegionID;
       

        private string _sASGName;
        private int _nASGID;

        private string _sBrandDesc;
        private int _nBrandID;

        private string _sCustomerName;
        private string _sType;
        private int _nDBType;
        private string _sOutlet;
        private DateTime _dOperationDate;
        private string _sMobileNo;
        

        // BLL TGT Vs Sales in TO
        private double _nTGTTO;
        private double _nSecTGTTO;
        private double _nPriTO;
        private double _nPriAch;
        private double _nSecTO;
        private double _nSecAch;
        private double _nReceivables;

        private double _nPriStockVal;
        private double _nSecStockVal;

        // End TGT Vs Sales in TO



        // BLL TGT Vs Sales in Qty

        private double _nTGTQty;
        private double _nPriQty;
        private double _nSecTGT;
        private double _nSecQty;


        // End TGT Vs Sales in Qty

        //BLL Daily Sales Monitoring in Qty
        private string _sRegionName;
        private string _sCustomerCode;
        private int _nDSRID;
        private string _sDSRCode;
        private string _sDSRName;
        private string _sMAGName;
        private double _TotalTGT;
        private double _MTDTGTQty;
        private double _MTDSalesQty;
        private double _Balance;
        private double _WTGTQty;
        private double _WSalesQty;
        private double _LOQty;
        private double _LDQty;
        private double _DayTGTQty;
        private int _nTerritorID;


        //End Daily Sales Monitoring in Qty



        private string _sLWeekNo;
        private string _sLSMonth;
        private string _sLSDate;
        private string _sLEDate;
        private double _LTAmt;
        private double _LSAmt;

        private string _sCWeekNo;
        private string _sCSMonth;
        private string _sCSDate;
        private string _sCEDate;
        private double _CTAmt;
        private double _CSAmt;
        private double _WTDTar;

        private double _nDTD;
        private double _nLD;
        private double _nMTD;
        private double _nLM;
        private double _nYTD;

        private int _MarketGroupID;
        public int MarketGroupID
        {
            get { return _MarketGroupID; }
            set { _MarketGroupID = value; }
        }

        private int _EmployeeID;
        public int EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }

        private string _Location;
        public string Location
        {
            get { return _Location; }
            set { _Location = value; }
        }

        private string _EmployeeName;
        public string EmployeeName
        {
            get { return _EmployeeName; }
            set { _EmployeeName = value; }
        }

        private string _Position;
        public string Position
        {
            get { return _Position; }
            set { _Position = value; }
        }

        private string _MobileNumber;
        public string MobileNumber
        {
            get { return _MobileNumber; }
            set { _MobileNumber = value; }
        }



        public string Channelname
        {
            get { return _sChannelName; }
            set { _sChannelName = value; }
        }

        public string AreaName
        {
            get { return _sAreaName; }
            set { _sAreaName = value; }
        }
        public string TerritoryName
        {
            get { return _sTerritoryName; }
            set { _sTerritoryName = value; }
        }

        public int AreaID
        {
            get { return _nAreaID; }
            set { _nAreaID = value; }
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

        public int DBType
        {
            get { return _nDBType; }
            set { _nDBType = value; }
        }

        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
        }

        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }

        public string BrandDesc
        {
            get { return _sBrandDesc; }
            set { _sBrandDesc = value; }
        }


        public string Type
        {
            get { return _sType; }
            set { _sType = value; }
        }
        public string Outlet
        {
            get { return _sOutlet; }
            set { _sOutlet = value; }
        }

        public DateTime OperationDate
        {
            get { return _dOperationDate; }
            set { _dOperationDate = value; }
        }
        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value; }
        }

        // Start TGT vs Sales (Primary & Sec) in Qty  Start

        public double TGTQty
        {
            get { return _nTGTQty; }
            set { _nTGTQty = value; }
        }

        public double PriQty
        {
            get { return _nPriQty; }
            set { _nPriQty = value; }
        }
        public double SecTGT
        {
            get { return _nSecTGT; }
            set { _nSecTGT = value; }
        }

        public double SecQty
        {
            get { return _nSecQty; }
            set { _nSecQty = value; }
        }

        // End TGT vs Sales (Primary & Sec)  


        //BLL Daily Sales Monitoring in Qty

        public string RegionName
        {
            get { return _sRegionName; }
            set { _sRegionName = value; }
        }

        public int RegionID
        {
            get { return _nRegionID; }
            set { _nRegionID = value; }
        }

        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value; }
        }
        public int DSRID
        {
            get { return _nDSRID; }
            set { _nDSRID = value; }
        }
        public int TerritorID
        {
            get { return _nTerritorID; }
            set { _nTerritorID = value; }
        }
        public string DSRCode
        {
            get { return _sDSRCode; }
            set { _sDSRCode = value; }
        }
        public string DSRName
        {
            get { return _sDSRName; }
            set { _sDSRName = value; }
        }
        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value; }
        }
        public double TotalTGT
        {
            get { return _TotalTGT; }
            set { _TotalTGT = value; }
        }
        public double MTDTGTQty
        {
            get { return _MTDTGTQty; }
            set { _MTDTGTQty = value; }
        }
        public double MTDSalesQty
        {
            get { return _MTDSalesQty; }
            set { _MTDSalesQty = value; }
        }
        public double Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }
        public double WTGTQty
        {
            get { return _WTGTQty; }
            set { _WTGTQty = value; }
        }
        public double WSalesQty
        {
            get { return _WSalesQty; }
            set { _WSalesQty = value; }
        }
        public double LOQty
        {
            get { return _LOQty; }
            set { _LOQty = value; }
        }
        public double LDQty
        {
            get { return _LDQty; }
            set { _LDQty = value; }
        }
        public double DayTGTQty
        {
            get { return _DayTGTQty; }
            set { _DayTGTQty = value; }
        }
        //End Daily Sales Monitoring in Qty



        public double TGTTO
        {
            get { return _nTGTTO; }
            set { _nTGTTO = value; }
        }

        public double SecTGTTO
        {
            get { return _nSecTGTTO; }
            set { _nSecTGTTO = value; }
        }

        public double PriTO
        {
            get { return _nPriTO; }
            set { _nPriTO = value; }
        }


        public double PriAch
        {
            get { return _nPriAch; }
            set { _nPriAch = value; }
        }

        public double SecTO
        {
            get { return _nSecTO; }
            set { _nSecTO = value; }
        }

        public double SecAch
        {
            get { return _nSecAch; }
            set { _nSecAch = value; }
        }

        public double Receivables
        {
            get { return _nReceivables; }
            set { _nReceivables = value; }
        }

        public double PriStockVal
        {
            get { return _nPriStockVal; }
            set { _nPriStockVal = value; }
        }


        public double SecStockVal
        {
            get { return _nSecStockVal; }
            set { _nSecStockVal = value; }
        }


        public string LWeekNo
        {
            get { return _sLWeekNo; }
            set { _sLWeekNo = value; }
        }
        public string LSMonth
        {
            get { return _sLSMonth; }
            set { _sLSMonth = value; }
        }
        public string LSDate
        {
            get { return _sLSDate; }
            set { _sLSDate = value; }
        }
        public string LEDate
        {
            get { return _sLEDate; }
            set { _sLEDate = value; }
        }
        public double LTAmt
        {
            get { return _LTAmt; }
            set { _LTAmt = value; }
        }
        public double LSAmt
        {
            get { return _LSAmt; }
            set { _LSAmt = value; }
        }

        public string CWeekNo
        {
            get { return _sCWeekNo; }
            set { _sCWeekNo = value; }
        }
        public string CSMonth
        {
            get { return _sCSMonth; }
            set { _sCSMonth = value; }
        }
        public string CSDate
        {
            get { return _sCSDate; }
            set { _sCSDate = value; }
        }
        public string CEDate
        {
            get { return _sCEDate; }
            set { _sCEDate = value; }
        }
        public double CTAmt
        {
            get { return _CTAmt; }
            set { _CTAmt = value; }
        }
        public double CSAmt
        {
            get { return _CSAmt; }
            set { _CSAmt = value; }
        }
        public double WTDTar
        {
            get { return _WTDTar; }
            set { _WTDTar = value; }
        }
        public string GetWeekFromDate()
        {
            string sResult = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            DateTime _dToday = new DateTime();
            _dToday = DateTime.Now.Date;
            try
            {

                cmd.CommandText = "select FromDate from t_CalendarWeek where '" + _dToday + "' between FromDate and ToDate ";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["FromDate"] != DBNull.Value)
                    {
                        sResult = Convert.ToDateTime(reader["FromDate"]).ToString("dd-MMM-yyyy");
                    }
                    else
                    {
                        sResult = "";
                    }

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return sResult;

        }

        public double DTD
        {
            get { return _nDTD; }
            set { _nDTD = value; }
        }
          public double LD
        {
            get { return _nLD; }
            set { _nLD = value; }
        }

          public double MTD
        {
            get { return _nMTD; }
            set { _nMTD = value; }
        }
          public double LM
        {
            get { return _nLM; }
            set { _nLM = value; }
        }
          public double YTD
        {
            get { return _nYTD; }
            set { _nYTD = value; }
        }

        private double _nSalesQty;
        public double SalesQty
        {
            get { return _nSalesQty; }
            set { _nSalesQty = value; }
        }

        private double _nTPQty;
        public double TPQty
        {
            get { return _nTPQty; }
            set { _nTPQty = value; }
        }

        private double _nIssueQty;
        public double IssueQty
        {
            get { return _nIssueQty; }
            set { _nIssueQty = value; }
        }

        private double _nReceiveQty;
        public double ReceiveQty
        {
            get { return _nReceiveQty; }
            set { _nReceiveQty = value; }
        }

        private int _DepartmentID;
        public int DepartmentID
        {
            get { return _DepartmentID; }
            set { _DepartmentID = value; }
        }



    }
    public class TargetVsAchs : CollectionBase
    {
        public TargetVsAch this[int i]
        {
            get { return (TargetVsAch)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(TargetVsAch oTargetVsAch)
        {
            InnerList.Add(oTargetVsAch);
        }
        public void Refresh(DateTime dStartDate)
        {

            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            DateTime _dFromDate = DateTime.Now.Date;
            DateTime _dLastWeek = dStartDate.AddDays(-1);

            sSql = "Select ShowroomCode as Outlet, right(AreaName,6) as AreaName, right(TerritoryName,6) as TerritoryName, " +
                          "  IsNull(lwtar.WeekNo,lwach.WeekNo) as LWeekNo, IsNull(lwtar.SMonth,lwach.SMonth) as LSMonth,   " +
                          "  IsNull(lwtar.SDate,lwach.SDate) as LSDate,IsNull(lwtar.EDate,lwach.EDate) as LEDate,IsNull(lwtar.TargetAmount,0) as LTAmt, " +
                          "  IsNull(lwach.SaleVal,0) as LSAmt, " +
                          "  IsNull(tar.WeekNo,ach.WeekNo) as CWeekNo, IsNull(tar.SMonth,ach.SMonth) as CSMonth,   " +
                          "  IsNull(tar.SDate,ach.SDate) as CSDate,IsNull(tar.EDate,ach.EDate) as CEDate,IsNull(tar.TargetAmount,0) as CTAmt, " +
                          "  IsNull(tar.WTDTar,0) as WTDTar, IsNull(ach.SaleVal,0) as CSAmt " +
                          "  from t_Showroom sr " +

                          "  Left Outer JOIN " +
                          "  (Select wk.WeekNo,month(FromDate) SMonth, day(fromDate)SDate, day(ToDate)EDate, tar.CustomerID,TargetAmount,  " +
                          " (TargetAmount/wd*wtd)WTDTar from  "+
                          " (select CYear,CMonth,WeekNo, FromDate, ToDate, convert(int,'" + _dFromDate + "'-FromDate+1) as wtd, " +
                          " convert(int,ToDate-FromDate+1) as wd   "+
                          " from t_CalendarWeek where '" + _dFromDate + "' between FromDate and ToDate) wk,   " +
                          " (select TYear, TMonth, WeekNo, CustomerID, Sum(TargetAmount) as TargetAmount from t_PlanExecutiveWeekTarget   "+
                          " group by TYear, TMonth, WeekNo, CustomerID)tar, t_Showroom sr  "+
                          " Where wk.CYear=tar.TYear and wk.CMonth=tar.TMonth and wk.WeekNo=tar.WeekNo and sr.CustomerID=tar.CustomerID)tar " +
                          "  on tar.CustomerID=sr.CustomerID  " +
                          
                          "  Left Outer JOIN " +
                          "  (Select WeekNo,month(FromDate) SMonth, day(fromDate)SDate, day(ToDate)EDate, a.WarehouseID,Sum(SaleVal) as SaleVal from  " +
                          "  ( " +
                          "  select CYear,CMonth,WeekNo, FromDate, ToDate, a.WarehouseID, Sum(NetSale) as SaleVal from DWDB.dbo.t_SalesDataCustomerProduct a, (select CYear,CMonth,WeekNo, FromDate, ToDate  " +
                          "  from t_CalendarWeek where '" + _dFromDate + "' between FromDate and ToDate) b , t_Showroom c Where c.WarehouseID=a.WarehouseID and " +
                          "  InvoiceDate between FromDate and ToDate and CompanyName='TEL' group by CYear,CMonth,WeekNo, FromDate, ToDate, a.WarehouseID " +
                          "  ) a group by WeekNo,month(FromDate) , day(fromDate), day(ToDate), a.WarehouseID)ach " +
                          "  on ach.WarehouseID=sr.WarehouseID  " +

                          "  Left Outer JOIN " +
                          "  (Select wk.WeekNo,month(FromDate) SMonth, day(fromDate)SDate, day(ToDate)EDate, tar.CustomerID,TargetAmount from  " +
                          "  (select CYear,CMonth,WeekNo, FromDate, ToDate  " +
                          "  from t_CalendarWeek where '" + _dLastWeek + "' between FromDate and ToDate) wk,  " +
                          "  (select TYear, TMonth, WeekNo, CustomerID, Sum(TargetAmount) as TargetAmount from t_PlanExecutiveWeekTarget  " +
                          "  group by TYear, TMonth, WeekNo, CustomerID)tar, t_Showroom sr " +
                          "  Where wk.CYear=tar.TYear and wk.CMonth=tar.TMonth and wk.WeekNo=tar.WeekNo and sr.CustomerID=tar.CustomerID)lwtar " +
                          "  on lwtar.CustomerID=sr.CustomerID  " +
                          
                          "  Left Outer JOIN " +
                          "  (Select WeekNo,month(FromDate) SMonth, day(fromDate)SDate, day(ToDate)EDate, a.WarehouseID,Sum(SaleVal) as SaleVal from  " +
                          "  ( " +
                          "  select CYear,CMonth,WeekNo, FromDate, ToDate, a.WarehouseID, Sum(NetSale) as SaleVal from DWDB.dbo.t_SalesDataCustomerProduct a, (select CYear,CMonth,WeekNo, FromDate, ToDate  " +
                          "  from t_CalendarWeek where '" + _dLastWeek + "' between FromDate and ToDate) b , t_Showroom c Where c.WarehouseID=a.WarehouseID and " +
                          "  InvoiceDate between FromDate and ToDate and CompanyName='TEL' group by CYear,CMonth,WeekNo, FromDate, ToDate, a.WarehouseID " +
                          "  ) a group by WeekNo,month(FromDate) , day(fromDate), day(ToDate), a.WarehouseID)lwach " +
                          "  on lwach.WarehouseID=sr.WarehouseID  " +
                          "  INNER JOIN " +
                          "  (select CustomerID, left(AreaName,9) as AreaName, left(TerritoryName,9) as TerritoryName from DWDB.dbo.t_CustomerDetails Where CompanyName='TEL')cust " +
                          "  ON cust.CustomerID=sr.CustomerID " +
                          "  Where IsPOSActive=1 order by AreaName, TerritoryName, Outlet";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    TargetVsAch oTargetVsAch = new TargetVsAch();


                    oTargetVsAch.AreaName = reader["AreaName"].ToString();
                    oTargetVsAch.TerritoryName = reader["TerritoryName"].ToString();
                    oTargetVsAch.Outlet = reader["Outlet"].ToString();
                    oTargetVsAch.LWeekNo = reader["LWeekNo"].ToString();
                    oTargetVsAch.LSMonth = reader["LSMonth"].ToString();

                    oTargetVsAch.LSDate = reader["LSDate"].ToString();
                    oTargetVsAch.LEDate = reader["LEDate"].ToString();
                    oTargetVsAch.LTAmt = Convert.ToDouble(reader["LTAmt"]);
                    oTargetVsAch.LSAmt = Convert.ToDouble(reader["LSAmt"]);

                    oTargetVsAch.CWeekNo = reader["CWeekNo"].ToString();
                    oTargetVsAch.CSMonth = reader["CSMonth"].ToString();
                    oTargetVsAch.CSDate = reader["CSDate"].ToString();
                    oTargetVsAch.CEDate = reader["CEDate"].ToString();
                    oTargetVsAch.CTAmt = Convert.ToDouble(reader["CTAmt"]);
                    oTargetVsAch.CSAmt = Convert.ToDouble(reader["CSAmt"]);
                    oTargetVsAch.WTDTar = Convert.ToDouble(reader["WTDTar"]);

                    InnerList.Add(oTargetVsAch);
                }
                reader.Close();
                InnerList.TrimToSize();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshBLLTOLM()
        {

            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            // DateTime _dFromDate = DateTime.Now.Date;
            // DateTime _dLastWeek = dStartDate.AddDays(-1);

            sSql = " select CustomerID,ChannelID,ChannelName,AreaID,AreaName,TerritoryID,TerritoryName,CustomerCode,CustomerName,  round(TGTTO,0)as TGTTO,round(SecTGTTO,0)As SecTGTTO, round(PriTO,0)as PriTO, PriAch= case when TGTTO <>0 then round(((PriTO/TGTTO)*100),0) else 0 end, SecTO, SecAch= case when TGTTO <>0 then round(((SecTO/TGTTO)*100),0) else 0 end, " +
               " round(Receivables,0)as Receivables " +
               " from " +
               " ( " +
               " select CustomerID,ChannelID,ChannelName,AreaID,AreaName,TerritoryID,TerritoryName,CustomerCode,CustomerName, sum(balance/1000)as Receivables,sum(TGTTO/1000)as TGTTO,sum(SecTGTTO/1000)as SecTGTTO, sum(PriTO/1000)as PriTO, sum(SecTO/1000)as SecTO " +
               " from " +
               " ( " +
               " select Final.CustomerID,ChannelID,ChannelName,AreaID,AreaName,TerritoryID,TerritoryName,CustomerCode,CustomerName,(balance*-1)as balance, round(TGTTO,0)as TGTTO,round(SecTGTTO,0)as SecTGTTO, " +
               " round(PriTO,0)as PriTO, round(SecTO,0)as SecTO " +
               " from " +
               " ( " +
               " select isnull(SalesTO.CustomerID,TGTTO.CustomerID)as CustomerID, isnull(TGTTO,0) as TGTTO,isnull(SecTGTTO,0)as SecTGTTO, isnull(PriTO,0)as PriTO,isnull(SecTO,0)as SecTO " +
               " from " +
               " ( " +
               " select isnull(PriTO.CustomerID,SecTO.DistributorID)as CustomerID,  isnull(PriSalesTO,0)as PriTO,  isnull(SecSalesTO,0)as SecTO " +
               " from " +
               " ( " +
               " select CustomerID,sum(SalesTO-CommAmt-Discount)as PriSalesTO " +
               " from " +
               " ( " +
               " select CustomerID,Sls.CustomerTypeID,Sls.ProductID,SalesTO,Discount,isnull(Comm,0)as Comm, isnull((SalesTO*Comm),0)as CommAmt " +
               " from " +
               " ( " +
               " select CustomerID,CustomerTypeID,ASGID,BrandID,a.ProductID,sum(GrossAmount)as SalesTO, sum(Discount)as Discount " +
               " from DWDB.dbo.t_SalesDataCustomerProduct a, BLLSysDB.dbo.v_ProductDetails b " +
               " where CompanyName='BLL' and Invoicedate between '01-Aug-2015' and '01-Sep-2015'  " +
               " and Invoicedate < '01-Sep-2015' and a.ProductID=b.ProductID " +
               " group by CustomerID,CustomerTypeID,ASGID,BrandID,a.ProductID " +
               " )as Sls " +
               " left outer join " +
               " ( " +
               " select CustomerTypeID,ProductGroupID,BrandID,ProvisionPercent as Comm " +
               " from BLLSysDB.dbo.t_ProvisionParam " +
               " where ProvisionType=1 and Isactive=1 " +
               " ) Com on Sls.CustomerTypeID=Com.CustomerTypeID and Sls.ASGID=Com.ProductGroupID and Sls.BrandID=Com.BrandID " +
               " )as Final " +
               " group by CustomerID " +
               " )as PriTO " +

               " full outer join " +
               " ( " +
               " select DistributorID,sum(Amount)as SecSalesTO " +
               " from " +
               " ( " +
               " select DistributorID, sum(NetAmount)as Amount " +
               " from BLLSysDB.dbo.t_DMSProductTran " +
               " where TranTypeID=2 and Trandate between '01-Aug-2015' and '01-Sep-2015'  and Trandate < '01-Sep-2015'  " +
               " and DistributorID in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1)  " +
               " group by DistributorID " +
               " union all " +
               " select b.CustomerID,  sum(TEBL) as Amount " +
               " from t_SMSDailySecondarySalesCollection a, BLLSysDB.dbo.t_Customer b " +
               " where trandate between '01-Aug-2015' and '01-Sep-2015'  and Trandate < '01-Sep-2015'  and a.CustomerID=b.CustomerCode " +
               " and b.CustomerID not in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1)  " +
               " group by b.CustomerID " +
               " )as SecTO " +
               " group by DistributorID " +
               " )as SecTO on PriTO.CustomerID=SecTO.DistributorID " +
               " )as SalesTO " +
               " full outer join " +
               " ( " +
               " select CustomerID,TGTTO,SecTGTTO  " +
               " from TELAddDB.dbo.t_DistributorDayTGTTO a, BLLsysDB.dbo.t_Customer b  " +
               " where TGTDate between '01-Aug-2015' and '01-Sep-2015'  and  TGTDate < '01-Sep-2015'  " +
               " and a.Customercode=b.Customercode " +
               " )as TGTTO on SalesTO.CustomerID=TGTTO.CustomerID " +
               " )as Final " +
               " inner join " +
               " ( " +
               " select CustomerID,CustomerCode,CustomerName,ChannelID,ChannelDescription as ChannelName,AreaID,AreaShortName as AreaName, TerritoryID,TerritoryShortName as TerritoryName,balance  " +
               " from BLLSysDB.dbo.v_CustomerDetails  " +

               " )as Cust on Final.CustomerID=cust.CustomerID " +
               " )As AreaTO " +
               " group by CustomerID,ChannelID,ChannelName,AreaID,AreaName,TerritoryID,TerritoryName,CustomerCode,CustomerName " +
               " )As GFinal " +
               " order by ChannelID,ChannelName,AreaID,AreaName,TerritoryID,TerritoryName,CustomerCode,CustomerName,TGTTO desc,SecTO desc ";



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    TargetVsAch oTargetVsAch = new TargetVsAch();

                    oTargetVsAch.Channelname = reader["ChannelName"].ToString();
                    oTargetVsAch.AreaName = reader["AreaName"].ToString();
                    oTargetVsAch.TerritoryName = reader["TerritoryName"].ToString();
                    oTargetVsAch.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                    oTargetVsAch.CustomerName = reader["CustomerName"].ToString();
                    oTargetVsAch.TGTTO = Convert.ToDouble(reader["TGTTO"]);
                    oTargetVsAch.SecTGTTO = Convert.ToDouble(reader["SecTGTTO"]);
                    oTargetVsAch.PriTO = Convert.ToDouble(reader["PriTO"]);
                    //oTargetVsAch.PriAch = Convert.ToDouble(reader["PriAch"]);
                    oTargetVsAch.SecTO = Convert.ToDouble(reader["SecTO"]);
                    // oTargetVsAch.SecAch = Convert.ToDouble(reader["SecAch"]);
                    oTargetVsAch.Receivables = Convert.ToDouble(reader["Receivables"]);


                    InnerList.Add(oTargetVsAch);
                }
                reader.Close();
                InnerList.TrimToSize();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshBLLTO()
        {

            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

           // DateTime _dFromDate = DateTime.Now.Date;
           // DateTime _dLastWeek = dStartDate.AddDays(-1);

            sSql = " select CustomerID,ChannelID,ChannelName,AreaID,AreaName,TerritoryID,TerritoryName,CustomerCode,CustomerName,  round(TGTTO,0)as TGTTO,round(SecTGTTO,0)As SecTGTTO, round(PriTO,0)as PriTO, PriAch= case when TGTTO <>0 then round(((PriTO/TGTTO)*100),0) else 0 end, SecTO, SecAch= case when TGTTO <>0 then round(((SecTO/TGTTO)*100),0) else 0 end, " +
               " round(Receivables,0)as Receivables " +
               " from " +
               " ( " +
               " select CustomerID,ChannelID,ChannelName,AreaID,AreaName,TerritoryID,TerritoryName,CustomerCode,CustomerName, sum(balance/1000)as Receivables,sum(TGTTO/1000)as TGTTO,sum(SecTGTTO/1000)as SecTGTTO, sum(PriTO/1000)as PriTO, sum(SecTO/1000)as SecTO " +
               " from " +
               " ( " +
               " select Final.CustomerID,ChannelID,ChannelName,AreaID,AreaName,TerritoryID,TerritoryName,CustomerCode,CustomerName,(balance*-1)as balance, round(TGTTO,0)as TGTTO,round(SecTGTTO,0)as SecTGTTO, " +
               " round(PriTO,0)as PriTO, round(SecTO,0)as SecTO " +
               " from " +
               " ( " +
               " select isnull(SalesTO.CustomerID,TGTTO.CustomerID)as CustomerID, isnull(TGTTO,0) as TGTTO,isnull(SecTGTTO,0)as SecTGTTO, isnull(PriTO,0)as PriTO,isnull(SecTO,0)as SecTO " +
               " from " +
               " ( " +
               " select isnull(PriTO.CustomerID,SecTO.DistributorID)as CustomerID,  isnull(PriSalesTO,0)as PriTO,  isnull(SecSalesTO,0)as SecTO " +
               " from " +
               " ( " +
               " select CustomerID,sum(SalesTO-CommAmt-Discount)as PriSalesTO " +
               " from " +
               " ( " +
               " select CustomerID,Sls.CustomerTypeID,Sls.ProductID,SalesTO,Discount,isnull(Comm,0)as Comm, isnull((SalesTO*Comm),0)as CommAmt " +
               " from " +
               " ( " +
               " select CustomerID,CustomerTypeID,ASGID,BrandID,a.ProductID,sum(GrossAmount)as SalesTO, sum(Discount)as Discount " +
               " from DWDB.dbo.t_SalesDataCustomerProduct a, BLLSysDB.dbo.v_ProductDetails b " +
               " where CompanyName='BLL' and Invoicedate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)  " +
               " and Invoicedate < CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106) and a.ProductID=b.ProductID " +
               " group by CustomerID,CustomerTypeID,ASGID,BrandID,a.ProductID " +
               " )as Sls " +
               " left outer join " +
               " ( " +
               " select CustomerTypeID,ProductGroupID,BrandID,ProvisionPercent as Comm " +
               " from BLLSysDB.dbo.t_ProvisionParam " +
               " where ProvisionType=1 and Isactive=1 " +
               " ) Com on Sls.CustomerTypeID=Com.CustomerTypeID and Sls.ASGID=Com.ProductGroupID and Sls.BrandID=Com.BrandID " +
               " )as Final " +
               " group by CustomerID " +
               " )as PriTO " +

               " full outer join " +
               " ( " +
               " select DistributorID,sum(Amount)as SecSalesTO " +
               " from " +
               " ( " +
               " select DistributorID, sum(NetAmount)as Amount " +
               " from BLLSysDB.dbo.t_DMSProductTran " +
               " where TranTypeID=2 and Trandate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)  and Trandate < CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)  " +
               " and DistributorID in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1)  " +
               " group by DistributorID " +
               " union all " +
               " select b.CustomerID,  sum(TEBL) as Amount " +
               " from t_SMSDailySecondarySalesCollection a, BLLSysDB.dbo.t_Customer b " +
               " where trandate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)  and Trandate < CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)  and a.CustomerID=b.CustomerCode " +
               " and b.CustomerID not in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1)  " +
               " group by b.CustomerID " +
               " )as SecTO " +
               " group by DistributorID " +
               " )as SecTO on PriTO.CustomerID=SecTO.DistributorID " +
               " )as SalesTO " +
               " full outer join " +
               " ( " +
               " select CustomerID,TGTTO,SecTGTTO  " +
               " from TELAddDB.dbo.t_DistributorDayTGTTO a, BLLsysDB.dbo.t_Customer b  " +
               " where TGTDate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)  and  TGTDate < CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)  " +
               " and a.Customercode=b.Customercode " +
               " )as TGTTO on SalesTO.CustomerID=TGTTO.CustomerID " +
               " )as Final " +
               " inner join " +
               " ( " +          

               " select CustomerID,CustomerCode,CustomerName,ChannelID,ChannelDescription as ChannelName,AreaID,AreaShortName as AreaName, TerritoryID,TerritoryShortName as TerritoryName,balance  "+
               " from BLLSysDB.dbo.v_CustomerDetails  " +

               " )as Cust on Final.CustomerID=cust.CustomerID " +
               " )As AreaTO " +
               " group by CustomerID,ChannelID,ChannelName,AreaID,AreaName,TerritoryID,TerritoryName,CustomerCode,CustomerName " +
               " )As GFinal " +
               " order by ChannelID,ChannelName,AreaID,AreaName,TerritoryID,TerritoryName,CustomerCode,CustomerName,TGTTO desc,SecTO desc ";

            
               
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    TargetVsAch oTargetVsAch = new TargetVsAch();

                    oTargetVsAch.Channelname = reader["ChannelName"].ToString();
                    oTargetVsAch.AreaName = reader["AreaName"].ToString();
                    oTargetVsAch.AreaID = Convert.ToInt32(reader["AreaID"]);
                    oTargetVsAch.TerritoryName = reader["TerritoryName"].ToString();
                    oTargetVsAch.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                    oTargetVsAch.CustomerName = reader["CustomerName"].ToString();
                    oTargetVsAch.TGTTO = Convert.ToDouble(reader["TGTTO"]);
                    oTargetVsAch.SecTGTTO = Convert.ToDouble(reader["SecTGTTO"]);
                    oTargetVsAch.PriTO = Convert.ToDouble(reader["PriTO"]);
                    //oTargetVsAch.PriAch = Convert.ToDouble(reader["PriAch"]);
                    oTargetVsAch.SecTO = Convert.ToDouble(reader["SecTO"]);
                   // oTargetVsAch.SecAch = Convert.ToDouble(reader["SecAch"]);
                    oTargetVsAch.Receivables = Convert.ToDouble(reader["Receivables"]);
                                      

                    InnerList.Add(oTargetVsAch);
                }
                reader.Close();
                InnerList.TrimToSize();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshBLLTOMTD()
        {

            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            // DateTime _dFromDate = DateTime.Now.Date;
            // DateTime _dLastWeek = dStartDate.AddDays(-1);

            // Query  modified by HRashid : Newly added in RegionID,RegionName,PriStockVal,SecStockVal

            sSql = " select CustomerID, ChannelID, ChannelName, RegionID, RegionName, AreaID, AreaName, TerritoryID, TerritoryName, CustomerCode, CustomerName, " +
              " round(sum(Receivables / 1000), 0)as Receivables,sum(TGTTO / 1000) as TGTTO,sum(SecTGTTO / 1000) as SecTGTTO, sum(PriTO / 1000) as PriTO, sum(SecTO / 1000) as SecTO " +
            " , sum(PriStockVal) as PriStockVal, sum(SecStockVal) as SecStockVal " +
            "   from " +
            "   ( " +
            "   select Cust.CustomerID, CustomerCode, CustomerName, ChannelID, ChannelName, RegionID, RegionName, AreaID, AreaName, TerritoryID, TerritoryName, isnull(Balance, 0) as Receivables, " +
            "   isnull(TGTTO, 0) as TGTTO, isnull(SecTGTTO, 0) as SecTGTTO, isnull(PriTO, 0) as PriTO, isnull((SecTO), 0) as SecTO, ISNULL(PriStockVal, 0) as PriStockVal, " +
            "   ISNULL(SecStockVal, 0) as SecStockVal " +
            "   from " +
            "   ( " +
            "   select CustomerID, CustomerCode, CustomerName, ChannelID, ChannelDescription as ChannelName, AreaID, AreaShortName as AreaName, TerritoryID, TerritoryShortName as TerritoryName, RegionID, RegionShortName as RegionName, (balance * -1) as Balance " +
            "   from BLLSysDB.dbo.v_CustomerDetails where channelID = 2 " +
            "   ) as Cust " +
            "   left outer join " +
            "   ( " +
            "   select isnull(SalesTO.CustomerID, TGTTO.CustomerID) as CustomerID, isnull(TGTTO, 0) as TGTTO, " +
            "   isnull(SecTGTTO, 0) as SecTGTTO, isnull(PriTO, 0) as PriTO, isnull(SecTO, 0) as SecTO, ISNULL(PriStockVal, 0) as PriStockVal, " +
            "   ISNULL(SecStockVal, 0) as SecStockVal " +
            "   from " +
            "   ( " +
            "   select isnull(PriTO.CustomerID, SecTO.DistributorID) as CustomerID, isnull(PriSalesTO, 0) as PriTO, isnull(SecSalesTO, 0) as SecTO, ISNULL(PriStockVal, 0) as PriStockVal,  ISNULL(SecStockVal, 0) as SecStockVal " +
            "   from " +
            "   ( " +
            "   select CustomerID, sum(SalesTO - CommAmt - Discount) as PriSalesTO, 0 as PriStockVal " +
            "   from " +
            "   ( " +
            "   select CustomerID, Sls.CustomerTypeID, Sls.ProductID, SalesTO, Discount, isnull(Comm, 0) as Comm, isnull((SalesTO * Comm), 0) as CommAmt " +
            "   from " +
            "   ( " +
            "   select CustomerID, CustomerTypeID, ASGID, BrandID, a.ProductID, sum(GrossAmount) as SalesTO, sum(Discount) as Discount " +
            "   from DWDB.dbo.t_SalesDataCustomerProduct a, BLLSysDB.dbo.v_ProductDetails b " +
            "   where CompanyName = 'BLL' and Invoicedate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25), DATEADD(dd, -(DAY(DATEADD(mm, 1, getdate())) - 1), DATEADD(mm, 1, getdate())), 106) " +
            "   and Invoicedate < CONVERT(VARCHAR(25), DATEADD(dd, -(DAY(DATEADD(mm, 1, getdate())) - 1), DATEADD(mm, 1, getdate())), 106) and a.ProductID = b.ProductID  " +
           "    group by CustomerID, CustomerTypeID, ASGID, BrandID, a.ProductID " +
            "   ) as Sls " +
            "   left outer join " +
            "   ( " +
            "   select CustomerTypeID, ProductGroupID, BrandID, ProvisionPercent as Comm " +
            "   from BLLSysDB.dbo.t_ProvisionParam " +
            "   where ProvisionType = 1 and Isactive = 1 " +
            "   ) Com on Sls.CustomerTypeID = Com.CustomerTypeID and Sls.ASGID = Com.ProductGroupID and Sls.BrandID = Com.BrandID " +
            "   ) as Final " +
            "   group by CustomerID " +
            "   ) as PriTO " +

            "   full outer join " +
            "   ( " +
            "   select ss.DistributorID, SecSalesTO, SecStockVal " +
            "   from " +
            "   ( " +
            "   select DistributorID, sum(Amount) as SecSalesTO " +
            "   from " +
            "   ( " +
            "   select DistributorID, sum(NetAmount) as Amount " +
            "   from BLLSysDB.dbo.t_DMSProductTran " +
            "   where TranTypeID = 2 and Trandate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25), DATEADD(dd, -(DAY(DATEADD(mm, 1, getdate())) - 1), DATEADD(mm, 1, getdate())), 106)  and Trandate < CONVERT(VARCHAR(25), DATEADD(dd, -(DAY(DATEADD(mm, 1, getdate())) - 1), DATEADD(mm, 1, getdate())), 106) " +
            "   and DistributorID in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive = 1) " +
            "   group by DistributorID " +
            "   union all " +
            "   select b.CustomerID, sum(TEBL) as Amount " +
            "   from t_SMSDailySecondarySalesCollection a, BLLSysDB.dbo.t_Customer b " +
            "   where trandate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25), DATEADD(dd, -(DAY(DATEADD(mm, 1, getdate())) - 1), DATEADD(mm, 1, getdate())), 106)  and Trandate < CONVERT(VARCHAR(25), DATEADD(dd, -(DAY(DATEADD(mm, 1, getdate())) - 1), DATEADD(mm, 1, getdate())), 106)  and a.CustomerID = b.CustomerCode " +
            "   and b.CustomerID not in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive = 1) " +
            "   group by b.CustomerID " +
            "   ) as SecTO " +
            "   group by DistributorID " +
            "   ) as ss " +

            "   inner join " +
            "   ( " +
            "   select a.DistributorID, sum(CurrentStock) as CRStock, sum(CurrentStock * NSP * .95) as SecStockVal " +
            "  from BLLSysDB.dbo.t_DMSProductStock a, BLLSysDB.dbo.t_DMSuser b, BLLSysDB.dbo.v_ProductDetails c, DWDB.dbo.t_CustomerDetails d " +
            "  where a.DistributorID = b.DistributorID and CurrentStock >= 0 and a.DistributorID in   " +
            "  (select DistributorID from BLLSysDB.dbo.t_DMSUser where Isactive = 1) and a.ProductID = c.ProductID and a.DistributorID = d.CustomerID " +
            "  group by a.DistributorID " +
            "  ) as SecStk on ss.DistributorID = SecStk.DistributorID " +

            "   ) as SecTO on PriTO.CustomerID = SecTO.DistributorID " +
            "   )as SalesTO " +
           "    full outer join " +
            "   ( " +
            "   select CustomerID, TGTTO, SecTGTTO " +
            "   from TELAddDB.dbo.t_DistributorDayTGTTO a, BLLsysDB.dbo.t_Customer b " +
            "  where TGTDate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25), DATEADD(dd, -(DAY(DATEADD(mm, 1, getdate())) - 1), DATEADD(mm, 1, getdate())), 106)  and  TGTDate < CONVERT(VARCHAR(25), DATEADD(dd, -(DAY(DATEADD(mm, 1, getdate())) - 1), DATEADD(mm, 1, getdate())), 106) " +
            "   and a.Customercode = b.Customercode " +
            "   ) as TGTTO on SalesTO.CustomerID = TGTTO.CustomerID " +
            "   )as Final on Final.CustomerID = cust.CustomerID " +
            "   )as GFinal " +
            "  group by CustomerID,ChannelID,ChannelName,RegionID,RegionName,AreaID,AreaName,TerritoryID,TerritoryName,CustomerCode,CustomerName  " +
            "   order by ChannelID, ChannelName, RegionID, RegionName, AreaID, AreaName, TerritoryID, TerritoryName, CustomerCode, CustomerName, TGTTO desc,SecTO desc ";


                // Old Code
                // "  select CustomerID,ChannelID,ChannelName,AreaID,AreaName,TerritoryID,TerritoryName,CustomerCode,CustomerName,round(sum(Receivables/1000),0)as Receivables,sum(TGTTO/1000)as TGTTO,sum(SecTGTTO/1000)as SecTGTTO, sum(PriTO/1000)as PriTO, sum(SecTO/1000)as SecTO  " +
                //" from " +
                //" (   " +
                //" select Cust.CustomerID,CustomerCode,CustomerName,ChannelID,ChannelName,AreaID,AreaName, TerritoryID, TerritoryName,isnull(Balance,0)as Receivables, " +
                //" isnull(TGTTO,0) as TGTTO,isnull(SecTGTTO,0)as SecTGTTO, isnull(PriTO,0)as PriTO,isnull((SecTO),0)as SecTO   " +
                //" from " +
                //" ( " +
                //" select CustomerID,CustomerCode,CustomerName,ChannelID,ChannelDescription as ChannelName,AreaID,AreaShortName as AreaName, TerritoryID,TerritoryShortName as TerritoryName,(balance *-1)as Balance  " +
                //" from BLLSysDB.dbo.v_CustomerDetails where channelID=2  " +
                //" )as Cust  " +
                //" left outer join " +
                //" (  " +
                //" select isnull(SalesTO.CustomerID,TGTTO.CustomerID)as CustomerID, isnull(TGTTO,0) as TGTTO,isnull(SecTGTTO,0)as SecTGTTO, isnull(PriTO,0)as PriTO,isnull(SecTO,0)as SecTO   " +
                //" from   " +
                //" (   " +
                //" select isnull(PriTO.CustomerID,SecTO.DistributorID)as CustomerID,  isnull(PriSalesTO,0)as PriTO,  isnull(SecSalesTO,0)as SecTO   " +
                //" from   " +
                //" (   " +
                //" select CustomerID,sum(SalesTO-CommAmt-Discount)as PriSalesTO   " +
                //" from  " +
                //" (  " +
                //" select CustomerID,Sls.CustomerTypeID,Sls.ProductID,SalesTO,Discount,isnull(Comm,0)as Comm, isnull((SalesTO*Comm),0)as CommAmt  " +
                //" from   " +
                //" (   " +
                //" select CustomerID,CustomerTypeID,ASGID,BrandID,a.ProductID,sum(GrossAmount)as SalesTO, sum(Discount)as Discount   " +
                //" from DWDB.dbo.t_SalesDataCustomerProduct a, BLLSysDB.dbo.v_ProductDetails b   " +
                //" where CompanyName='BLL' and Invoicedate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)    " +
                //" and Invoicedate < CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106) and a.ProductID=b.ProductID   " +
                //" group by CustomerID,CustomerTypeID,ASGID,BrandID,a.ProductID   " +
                //" )as Sls   " +
                //" left outer join   " +
                //" (   " +
                //" select CustomerTypeID,ProductGroupID,BrandID,ProvisionPercent as Comm   " +
                //" from BLLSysDB.dbo.t_ProvisionParam   " +
                //" where ProvisionType=1 and Isactive=1  " +
                //" ) Com on Sls.CustomerTypeID=Com.CustomerTypeID and Sls.ASGID=Com.ProductGroupID and Sls.BrandID=Com.BrandID   " +
                //" )as Final   " +
                //" group by CustomerID   " +
                //" )as PriTO  " +

            //" full outer join  " +
            //" (  " +
            //" select DistributorID,sum(Amount)as SecSalesTO  " +
            //" from  " +
            //" (  " +
            //" select DistributorID, sum(NetAmount)as Amount  " +
            //" from BLLSysDB.dbo.t_DMSProductTran  " +
            //" where TranTypeID=2 and Trandate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)  and Trandate < CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)   " +
            //" and DistributorID in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1)   " +
            //" group by DistributorID  " +
            //" union all  " +
            //" select b.CustomerID,  sum(TEBL) as Amount  " +
            //" from t_SMSDailySecondarySalesCollection a, BLLSysDB.dbo.t_Customer b  " +
            //" where trandate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)  and Trandate < CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)  and a.CustomerID=b.CustomerCode  " +
            //" and b.CustomerID not in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1)   " +
            //" group by b.CustomerID  " +
            //" )as SecTO  " +
            //" group by DistributorID  " +
            //" )as SecTO on PriTO.CustomerID=SecTO.DistributorID  " +
            //" )as SalesTO  " +
            //" full outer join  " +
            //" (  " +
            //" select CustomerID,TGTTO,SecTGTTO   " +
            //" from TELAddDB.dbo.t_DistributorDayTGTTO a, BLLsysDB.dbo.t_Customer b   " +
            //" where TGTDate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)  and  TGTDate < CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)   " +
            //" and a.Customercode=b.Customercode  " +
            //" )as TGTTO on SalesTO.CustomerID=TGTTO.CustomerID  " +
            //" )as Final on Final.CustomerID=cust.CustomerID  " +
            //" )as GFinal " +
            //" group by CustomerID,ChannelID,ChannelName,AreaID,AreaName,TerritoryID,TerritoryName,CustomerCode,CustomerName  " +
            //" order by ChannelID,ChannelName,AreaID,AreaName,TerritoryID,TerritoryName,CustomerCode,CustomerName,TGTTO desc,SecTO desc ";



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    TargetVsAch oTargetVsAch = new TargetVsAch();

                    oTargetVsAch.Channelname = reader["ChannelName"].ToString();
                    oTargetVsAch.RegionName = reader["RegionName"].ToString();
                    oTargetVsAch.RegionID = Convert.ToInt32(reader["RegionID"]);
                    oTargetVsAch.AreaName = reader["AreaName"].ToString();
                    oTargetVsAch.AreaID = Convert.ToInt32(reader["AreaID"]);
                    oTargetVsAch.TerritoryName = reader["TerritoryName"].ToString();
                    oTargetVsAch.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                    oTargetVsAch.CustomerName = reader["CustomerName"].ToString();
                    oTargetVsAch.TGTTO = Convert.ToDouble(reader["TGTTO"]);
                    oTargetVsAch.SecTGTTO = Convert.ToDouble(reader["SecTGTTO"]);
                    oTargetVsAch.PriTO = Convert.ToDouble(reader["PriTO"]);
                    //oTargetVsAch.PriAch = Convert.ToDouble(reader["PriAch"]);
                    oTargetVsAch.SecTO = Convert.ToDouble(reader["SecTO"]);
                    // oTargetVsAch.SecAch = Convert.ToDouble(reader["SecAch"]);
                    oTargetVsAch.Receivables = Convert.ToDouble(reader["Receivables"]);
                    oTargetVsAch.PriStockVal= Convert.ToDouble(reader["PriStockVal"]);
                    oTargetVsAch.SecStockVal = Convert.ToDouble(reader["SecStockVal"]);


                    InnerList.Add(oTargetVsAch);
                }
                reader.Close();
                InnerList.TrimToSize();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void SalesAndTGTQty(string nASG, string nBrand)
        {

            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            sSql = " select ChannelID,ChannelDescription as ChannelName,AreaID,AreaName,TerritoryName,Total.CustomerID,CustomerCode,Customername,ASGID,ASGName,Total.BrandID, BrandDesc, round(TGTQty,0)as TGTQty, PriQty, SecTGT, SecQty " +
                  " from " +
                  " ( " +
                  " select CustomerID,ASGID,ASGName,BrandID, BrandDesc, sum(TGTQty)as TGTQty, sum(PriQty)as PriQty,sum(SecTGT)as SecTGT, sum(SecQty)as SecQty " +
                  " from " +
                  " ( " +
                  " select CustomerID,ASGID,ASGName,BrandID, BrandDesc, 0 as TGTQty, sum(SalesQty)as PriQty,0 as SecTGT, 0 as SecQty  " +
                  " from " +
                  " ( " +
                  //------ Start of Primary Sales -------- 
                  " select CustomerID,ASGID,ASGName,BrandID, BrandDesc, isnull (sum(QtySA)- sum(QtyRA),0) as SalesQty " +
                  " from " +
                  " ( " +
                  " select  c.customerID,ASGID,ASGName,BrandID, BrandDesc,  sum (Quantity) as QtySA, 0 as  QtyRA  " +
                  " from bllsysdb.dbo.V_ProductDetails a, bllsysdb.dbo.t_salesinvoiceDetail b, bllsysdb.dbo.t_salesinvoice c, bllsysdb.dbo.v_customerDetails d " +
                  " where a.productID=b.productID and b.InvoiceID = c.InvoiceID and c.CustomerID=d.CustomerID and SBUID=1 and ChannelID in (2,12,8) and InvoicetypeID in (1,2) and invoiceStatus not in (3) " +
                  " and Invoicedate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106) and Invoicedate < CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106) " +
                  " group by c.customerID,ASGID,ASGName,BrandID, BrandDesc " +
                  " union all " +
                  " select  c.customerID,ASGID,ASGName,BrandID, BrandDesc,   0 as  QtySA,  sum(Quantity) as QtyRA  " +
                  " from bllsysdb.dbo.V_ProductDetails a, bllsysdb.dbo.t_salesinvoiceDetail b, bllsysdb.dbo.t_salesinvoice c, bllsysdb.dbo.v_customerDetails d " +
                  " where a.productID=b.productID and b.InvoiceID = c.InvoiceID and c.CustomerID=d.CustomerID and SBUID=1 and ChannelID in (2,12,8) and InvoicetypeID in (6,7,9,10,12) and invoiceStatus not in (3) " +
                  " and Invoicedate between  DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106) and Invoicedate < CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106) " +
                  " group by  c.customerID,ASGID,ASGName,BrandID, BrandDesc " +
                  " ) as b  " +
                  " group by  customerID,ASGID,ASGName,BrandID, BrandDesc " +
                  " ) TELBLL " +
                  " group by customerID,ASGID,ASGName,BrandID, BrandDesc " +
                  // ------ End of Primary Sales --------
                  " union all " +
                  // ------ Start of Target Qty -------- 
                  " select MarketGroupId, ASGID, ASGName, BrandID, BrandDesc,sum(Qty)as TGTQty,0 as PriQty,0 as SecTGT, 0 as SecQty " +
                  " from BLLSysDB.dbo.t_planbudgetTarget a, BLLSysDB.dbo.v_ProductDetails b " +
                  " where PeriodDate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and DATEADD (dd, -1, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0)) " +
                  " and a.ProductGroupID=b.ProductID " +
                  " group by MarketGroupId, ASGID,ASGName,BrandID, BrandDesc " +
                  // ------ End of Target Qty --------
                  " union all " +
                  // -------- Start of secondary Qty------
                  " select CustomerID, ASGID,ASGName,BrandID,BrandDesc,0 as TGTQty, 0 as PriQty,0 as SecTGT, sum(SecQty)As SecQty " +
                  " from " +
                  " ( " +
                  " select Cust.CustomerID, ASGID,ASGName,BrandID,BrandDesc, 0 as TGTQty, 0 as PriQty, 0 as SecTGT,SecQty " +
                  " from " +
                  " ( " +
                  " select CustomerID ,125 as ASGID,'GLS'as ASGName,1 as BrandID, 'Philips'as BrandDesc, sum(PGLS) as SecQty " +
                  " from t_SMSDailySecondarySalesCollection  " +
                  " where trandate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106) and trandate< CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106) " +
                  " and CustomerID not in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1 )  " +
                  " group by CustomerID " +
                  " union all " +
                  " select CustomerID, 125 as ASGID,'GLS'as ASGName,4 as BrandID, 'Transtec'as BrandDesc, sum(TGLS) as SecQty " +
                  " from t_SMSDailySecondarySalesCollection  " +
                  " where trandate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106) and trandate< CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106) " +
                  " and CustomerID not in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1 )  " +
                  " group by CustomerID " +
                  " union all " +
                  " select CustomerID, 126 as ASGID,'CFL'as ASGName,4 as BrandID, 'Transtec'as BrandDesc, sum(TCFL) as SecQty " +
                  " from t_SMSDailySecondarySalesCollection   " +
                  " where trandate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106) and trandate< CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)  " +
                  " and CustomerID not in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1 )  " +
                  " group by CustomerID " +
                  " union all " +
                  " select CustomerID,127 as ASGID,'TL'as ASGName,4 as BrandID, 'Transtec'as BrandDesc, sum(TTL) as SecQty " +
                  " from t_SMSDailySecondarySalesCollection  " +
                  " where trandate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106) and trandate< CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)  " +
                  " and CustomerID not in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1 )  " +
                  " group by CustomerID " +
                  " )as SMS  " +
                  " inner join BLLSysDB.dbo.v_Customerdetails as Cust on SMS.CustomerID=Cust.CustomerCode " +

                  " union all " +

                  " select DistributorID,ASGID,ASGName,BrandID,BrandDesc, 0 as TGTQty, 0 as PriQty,0 as SecTGT, sum(Qty)as SecQty  " +
                  " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c  " +
                  " where TranTypeID in (2) and a.TranID=b.TranID and Trandate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and  DATEADD (dd, -1, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0))  " +
                  " and b.ProductID=c.ProductID and DistributorID in ( select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1 ) " +
                  " group by DistributorID,ASGID,ASGName,BrandID,BrandDesc " +

                  " )As Sec  " +
                  " group by CustomerID, ASGID,ASGName,BrandID,BrandDesc  " +
                 // -------- End of secondary Qty------

                  " union all " +

                  // -------- Start of secondary Target Qty------
                  " select DistributorID, ASGID,ASGName,BrandID,BrandDesc,0 as TGTQty, 0 as PriQty,SecTGT, 0 as SecQty " +
                  " from " +
                  " ( " +
                  " select DistributorID, ASGID,ASGName= case when ASGID=125 then 'GLS' when ASGID=126 then 'CFL' when ASGID=127 then 'TL' " +
                  " when ASGID=139 then 'Ballast' when ASGID=140 then 'Starter' when ASGID=679  then 'LED' else 'NO' end, " +
                  " BrandID,BrandDesc= case when BrandID= 1 then 'Philips' when BrandID=4 then 'Transtec' else 'NO' end,  sum(TSOTGTQty)as SecTGT " +
                  " from BLLSysDB.dbo.t_DMSASGTarget  " +
                  " where TargetDate= DATEADD(month, DATEDIFF(month, 0, getdate()), 0)   " +
                  " group by DistributorID, ASGID,BrandID " +
                  " )As SecTGT " +
                // -------- End of secondary Target Qty------
                  " )as Final where ASGName= '"+nASG+"'   and BrandDesc= '" +nBrand+ "'  " +
                  " group by customerID,ASGID,ASGName,BrandID, BrandDesc " +
                  " )as Total inner join BLLSysDB.dbo.v_Customerdetails as Cust on Total.CustomerID=Cust.CustomerID " +
                  "   order by  ChannelID, ChannelName,AreaID,AreaName,TerritoryName,Total.CustomerID,CustomerCode,Customername,ASGID,ASGName,Total.BrandID, BrandDesc ";




            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    TargetVsAch oTargetVsAch = new TargetVsAch();


                    oTargetVsAch.Channelname = reader["ChannelName"].ToString();
                    oTargetVsAch.AreaName = reader["AreaName"].ToString();
                    oTargetVsAch.TerritoryName = reader["TerritoryName"].ToString();
                    oTargetVsAch.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                    oTargetVsAch.CustomerName = reader["Customername"].ToString();
                    oTargetVsAch.ASGID = Convert.ToInt16(reader["ASGID"]);
                    oTargetVsAch.ASGName = reader["ASGName"].ToString();
                    oTargetVsAch.BrandID = Convert.ToInt16(reader["BrandID"]);
                    oTargetVsAch.BrandDesc = reader["BrandDesc"].ToString();



                    oTargetVsAch.TGTQty = Convert.ToDouble(reader["TGTQty"]);
                    oTargetVsAch.PriQty = Convert.ToDouble(reader["PriQty"]);
                    oTargetVsAch.SecTGT = Convert.ToDouble(reader["SecTGT"]);
                    oTargetVsAch.SecQty = Convert.ToDouble(reader["SecQty"]);                               
                    
                    InnerList.Add(oTargetVsAch);
                }
                reader.Close();
                InnerList.TrimToSize();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DailySalesMonitoringInQty()
        {

            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            sSql = @"Select RegionName,Areaid,AreaName,TerritoryID,TerritoryName,CustomerID,CustomerCode,CustomerName,DSRID,DSRCode,DSRName,
                    MAGName, ASGName,TotalTGT, MTDTGTQty, MTDSalesQty,(TotalTGT-MTDSalesQty) as Balance, WTGTQty, WSalesQty,
                    LOQty,  LDQty,  DayTGTQty
                    from
                    (
                    -----------------------  Report format for a SA---------------
                    Select RegionName,Areaid,AreaName,TerritoryID,TerritoryName,CustomerID,CustomerCode,CustomerName,DSRID,DSRCode,DSRName,
                    MAGName, ASGName,sum(TotalTGT) as TotalTGT, sum(MTDTGTQty) as MTDTGTQty,sum(MTDSalesQty) as MTDSalesQty,sum(WTGTQty) as  WTGTQty,sum(WSalesQty) as WSalesQty,
                    sum(LOQty) as LOQty,sum(LDQty) as  LDQty,sum(DayTGTQty) as  DayTGTQty
                    from
                    (
                    Select RegionName,Areaid,AreaName,TerritoryID,TerritoryName,CustomerID,CustomerCode,CustomerName,DSRID,DSRCode,DSRName,
                    MAGName, ASGName,MTDTGTQty,TotalTGT, MTDSalesQty,  WTGTQty, WSalesQty,
                    LOQty,  LDQty,  DayTGTQty
                    from
                    (
                    Select OutletID, MAGName, ASGName, sum(MTDSQty) as MTDSalesQty,sum(TotalTGT) as TotalTGT, sum(MTDTGTQty) as MTDTGTQty, 
                    sum(LOQty) as LOQty, sum(LDQty) as  LDQty, sum(DayTGTQty) as DayTGTQty, sum(WSalesQty) as WSalesQty, sum(WTGTQty) as WTGTQty
                    from
                    ( 
                    ------------------------------Month wise Sales Qty Start----------------------
                    Select OutletID, MAGName, ASGName, sum(SaleQty) as MTDSQty,0 as TotalTGT, 0 as MTDTGTQty, 0 as LOQty, 0 as  LDQty, 0 as DayTGTQty, 0 as WSalesQty, 0 as WTGTQty
                    from t_DMSOrder a, t_DMSOrderItem b, v_ProductDetails c
                    where a.TranID=b.TranID and b.ProductID=c.ProductID and SaleQty>0 and IsDelivered=1 and DeliveryAmount>0
                    and DeliveryDate between   DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and 
                    DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0) and DeliveryDate <  DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0)
                    group by OutletID, MAGName, ASGName
                    ------------------------------Month wise End----------------------
                    union all
                    ------------------------------Month wise Sales TGT Start----------------------
                    Select OutletID,MAGName,ASGName,0 as MTDSQty, TotalTGT, MTDTGTQty, 0 as LOQty, 0 as  LDQty, 0 as DayTGTQty, 0 as WSalesQty, 0 as WTGTQty
                    from 
                    (
                    select OutletID, ASGID,sum(TSMTGTQty) as TotalTGT,
                    ((sum(TSMTGTQty)/(select Count(*) from BLLSysDB.dbo.t_CalendarSales 
                    where Year(TDate)= Year(getdate())  and Month(TDate)= Month(getdate()) and IsSalesDay=1))
                    *(select Count(*) from BLLSysDB.dbo.t_CalendarSales where Year(TDate)= Year(getdate())  
                    and Month(TDate)= Month(getdate()) and IsSalesDay=1 and TDate < getdate()))as MTDTGTQty
                    from BLLSysDB.dbo.t_DMSASGTarget 
                    where TargetDate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) +0, 0)  and DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) +1, 0)  and 
                    TargetDate < DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) +1, 0)   
                    and OutletID>0
                    group by OutletID,ASGID
                    ) as Q1 
                    left outer join (select distinct ASGID, MAGName,ASGName from v_ProductDetails where asgid not in  (129, 130, 131, 132, 135, 138, 142, 438, 656, 672, 677, 760, 762, 764, 767,785)) as Prod on Q1.ASGID=Prod.ASGID
                    ------------------------------Month wise Sales TGT End----------------------
                    union all
                    ----------------------Last Day Order Qty Start------------------
                    Select OutletID,MAGName,ASGName,0 as MTDSQty,0 as TotalTGT, 0 as MTDTGTQty, sum(Qty) as LOQty, 0 as  LDQty, 0 as DayTGTQty, 0 as WSalesQty, 0 as WTGTQty
                    from t_DMSOrder a, t_DMSOrderItem b, v_ProductDetails c
                    where CreateDate between DATEADD(dd,DATEDIFF(dd,0,GETDATE()),-2) and  DATEADD(dd,DATEDIFF(dd,0,GETDATE()),-1) 
                    and CreateDate< DATEADD(dd,DATEDIFF(dd,0,GETDATE()),-1) 
                    and a.TranID=b.TranID and NetAmount>0 and b.ProductID=c.ProductID and b.Qty>0
                    group by  OutletID,MAGName,ASGName
                    ----------------------Last Day Order Qty End------------------
                    union all
                    ----------------------Last Day Delivery Qty Start------------------
                    Select OutletID,MAGName,ASGName,0 as MTDSQty,0 as TotalTGT, 0 as MTDTGTQty, 0as LOQty, sum(SaleQty) as LDQty, 0 as DayTGTQty, 0 as WSalesQty, 0 as WTGTQty
                    from t_DMSOrder a, t_DMSOrderItem b, v_ProductDetails c
                    where DeliveryDate between DATEADD(dd,DATEDIFF(dd,0,GETDATE()),-1) and DATEADD(dd,DATEDIFF(dd,0,GETDATE()),0) 
                    and DeliveryDate< DATEADD(dd,DATEDIFF(dd,0,GETDATE()),0)
                    and a.TranID=b.TranID and DeliveryAmount>0 and IsDelivered=1 and SaleQty>0 and b.ProductID=c.ProductID 
                    group by OutletID,MAGName,ASGName
                    ----------------------Last Day Delivery Qty End------------------
                    union all
                    ---------------------- Today TGT Start------------------------
                    Select OutletID,MAGName,ASGName,0 as MTDSQty,0 as TotalTGT, 0 as MTDTGTQty, 0as LOQty, 0 as LDQty, DayTGTQty, 0 as WSalesQty, 0 as WTGTQty
                    from
                    (
                    select OutletID, ASGID, round(sum(TSMTGTQty)/(select Count(*) from BLLSysDB.dbo.t_CalendarSales 
                    where Year(TDate)= Year(getdate())  and Month(TDate)=  Month(getdate())  and IsSalesDay=1),0) As DayTGTQty
                    from BLLSysDB.dbo.t_DMSASGTarget 
                    where TargetDate between  DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) +0, 0) and DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) +1, 0) and 
                    TargetDate <  DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) +1, 0)  and OutletID>0
                    group by OutletID, ASGID
                    ) as Q3
                    left outer join (select distinct ASGID, MAGName,ASGName from v_ProductDetails where asgid not in  (129, 130, 131, 132, 135, 138, 142, 438, 656, 672, 677, 760, 762, 764, 767,758)  ) as Prod on Q3.ASGID=Prod.ASGID
                    ---------------------- Today TGT End------------------------
                    union all
                    -------------------------Week wise Sales Start---------------------------------

                    Select OutletID,MAGName,ASGName,0 as MTDSQty,0 as TotalTGT, 0 as MTDTGTQty, 0as LOQty, 0 as LDQty,0 as DayTGTQty, sum(SaleQty) as WSalesQty, 0 as WTGTQty
                    from t_DMSOrder a, t_DMSOrderItem b, v_ProductDetails c
                    where DeliveryDate>= (select FromDate from dbo.t_CalendarWeek where fromDate <=getdate() and todate >= getdate()) 
                    and   DeliveryDate <= (select Todate from dbo.t_CalendarWeek where fromDate <=getdate() and todate >= getdate())
                    and a.TranID=b.TranID and b.ProductID=c.ProductID and IsDelivered=1 and DeliveryAmount>0 and SaleQty>0
                    group by  OutletID,MAGName,ASGName
                    -------------------------Week wise Sales End---------------------------------
                    union all

                    -------------------------Week wise TGT Start---------------------------------
                    Select OutletID,MAGName,ASGName,0 as MTDSQty,0 as TotalTGT, 0 as MTDTGTQty, 0as LOQty, 0 as LDQty, 0 as DayTGTQty, 0 as WSalesQty, WTGTQty
                    from
                    (
                    Select OutletID, ASGID, sum(TSMTGTQty) as WTGTQty
                    from t_DMSASGTarget 
                    where TargetDate between '11-May-2019' and '18-May-2019'   and 
                    TargetDate <  '18-May-2019' 
                    and OutletID>0
                    group by OutletID,ASGID
                    ) as W1
                    left outer join (select distinct ASGID, MAGName,ASGName from v_ProductDetails where asgid not in  (129, 130, 131, 132, 135, 138, 142, 438, 656, 672, 677, 760, 762, 764, 767,758)) as Prod on W1.ASGID=Prod.ASGID
                    ) as Final group by OutletID,MAGName,ASGName
                    ) as Main
                    inner join
                    (
                    Select RegionName,Areaid,AreaName,TerritoryID,TerritoryName,a.CustomerID,CustomerCode,CustomerName,b.DSRID,DSRCode,DSRName,
                    RouteCode,RouteName,RetailID,RetailName
                    from v_CustomerDetails a, t_DMSDSR b, t_DMSRoute c, t_DMSClusterOutlet d
                    where a.CustomerID=b.DistributorID and b.DSRCode>0 and b.DSRID=c.DSRID and c.RouteID=d.RouteID
                    ) as Cust on Main.OutletID=Cust.RetailID
                    ) as FQ group by RegionName,Areaid,AreaName,TerritoryID,TerritoryName,CustomerID,CustomerCode,CustomerName,DSRID,DSRCode,DSRName,
                    MAGName, ASGName
                    ) as Final 
                    ";



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    TargetVsAch oTargetVsAch = new TargetVsAch();


                    oTargetVsAch.RegionName = reader["RegionName"].ToString();
                    oTargetVsAch.AreaID = Convert.ToInt32(reader["AreaID"]);
                    oTargetVsAch.AreaName = reader["AreaName"].ToString();
                    oTargetVsAch.TerritorID = Convert.ToInt32(reader["TerritoryID"]);
                    oTargetVsAch.TerritoryName = reader["TerritoryName"].ToString();
                    oTargetVsAch.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                    oTargetVsAch.CustomerCode = reader["CustomerCode"].ToString();
                    oTargetVsAch.CustomerName = reader["CustomerName"].ToString();
                    oTargetVsAch.DSRID = Convert.ToInt32(reader["DSRID"]);
                    oTargetVsAch.DSRCode = reader["DSRCode"].ToString();
                    oTargetVsAch.DSRName = reader["DSRName"].ToString();
                    oTargetVsAch.MAGName = reader["MAGName"].ToString();
                    oTargetVsAch.ASGName = reader["ASGName"].ToString();
                    oTargetVsAch.TotalTGT = Convert.ToDouble(reader["TotalTGT"]);
                    oTargetVsAch.MTDTGTQty = Convert.ToDouble(reader["MTDTGTQty"]);
                    oTargetVsAch.MTDSalesQty = Convert.ToDouble(reader["MTDSalesQty"]);
                    oTargetVsAch.Balance = Convert.ToDouble(reader["Balance"]);
                    oTargetVsAch.WTGTQty = Convert.ToDouble(reader["WTGTQty"]);
                    oTargetVsAch.WSalesQty = Convert.ToDouble(reader["WSalesQty"]);
                    oTargetVsAch.LOQty = Convert.ToDouble(reader["LOQty"]);
                    oTargetVsAch.LDQty = Convert.ToDouble(reader["LDQty"]);
                    oTargetVsAch.DayTGTQty = Convert.ToDouble(reader["DayTGTQty"]);

                    InnerList.Add(oTargetVsAch);
                }
                reader.Close();
                InnerList.TrimToSize();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void SalesAndTGTQty()
        {

            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            sSql = " select ChannelID,ChannelDescription as ChannelName,AreaID,AreaName,TerritoryName,Total.CustomerID,CustomerCode,Customername,ASGID,ASGName,Total.BrandID, BrandDesc, round(TGTQty,0)as TGTQty, PriQty, SecTGT, SecQty " +
                  " from " +
                  " ( " +
                  " select CustomerID,ASGID,ASGName,BrandID, BrandDesc, sum(TGTQty)as TGTQty, sum(PriQty)as PriQty,sum(SecTGT)as SecTGT, sum(SecQty)as SecQty " +
                  " from " +
                  " ( " +
                  " select CustomerID,ASGID,ASGName,BrandID, BrandDesc, 0 as TGTQty, sum(SalesQty)as PriQty,0 as SecTGT, 0 as SecQty  " +
                  " from " +
                  " ( " +
                //------ Start of Primary Sales -------- 
                  " select CustomerID,ASGID,ASGName,BrandID, BrandDesc, isnull (sum(QtySA)- sum(QtyRA),0) as SalesQty " +
                  " from " +
                  " ( " +
                  " select  c.customerID,ASGID,ASGName,BrandID, BrandDesc,  sum (Quantity) as QtySA, 0 as  QtyRA  " +
                  " from bllsysdb.dbo.V_ProductDetails a, bllsysdb.dbo.t_salesinvoiceDetail b, bllsysdb.dbo.t_salesinvoice c, bllsysdb.dbo.v_customerDetails d " +
                  " where a.productID=b.productID and b.InvoiceID = c.InvoiceID and c.CustomerID=d.CustomerID and SBUID=1 and ChannelID in (2,12,8) and InvoicetypeID in (1,2) and invoiceStatus not in (3) " +
                  " and Invoicedate between '01-Aug-2015' and '01-Sep-2015' and Invoicedate<'01-Sep-2015' " +
                  " group by c.customerID,ASGID,ASGName,BrandID, BrandDesc " +
                  " union all " +
                  " select  c.customerID,ASGID,ASGName,BrandID, BrandDesc,   0 as  QtySA,  sum(Quantity) as QtyRA  " +
                  " from bllsysdb.dbo.V_ProductDetails a, bllsysdb.dbo.t_salesinvoiceDetail b, bllsysdb.dbo.t_salesinvoice c, bllsysdb.dbo.v_customerDetails d " +
                  " where a.productID=b.productID and b.InvoiceID = c.InvoiceID and c.CustomerID=d.CustomerID and SBUID=1 and ChannelID in (2,12,8) and InvoicetypeID in (6,7,9,10,12) and invoiceStatus not in (3) " +
                  " and Invoicedate between  '01-Aug-2015' and '01-Sep-2015' and Invoicedate<'01-Sep-2015' " +
                  " group by  c.customerID,ASGID,ASGName,BrandID, BrandDesc " +
                  " ) as b  " +
                  " group by  customerID,ASGID,ASGName,BrandID, BrandDesc " +
                  " ) TELBLL " +
                  " group by customerID,ASGID,ASGName,BrandID, BrandDesc " +
                // ------ End of Primary Sales --------
                  " union all " +
                // ------ Start of Target Qty -------- 
                  " select MarketGroupId, ASGID, ASGName, BrandID, BrandDesc,sum(Qty)as TGTQty,0 as PriQty,0 as SecTGT, 0 as SecQty " +
                  " from BLLSysDB.dbo.t_planbudgetTarget a, BLLSysDB.dbo.v_ProductDetails b " +
                  " where PeriodDate between '01-Aug-2015' and '30-Aug-2015' " +
                  " and a.ProductGroupID=b.ProductID " +
                  " group by MarketGroupId, ASGID,ASGName,BrandID, BrandDesc " +
                // ------ End of Target Qty --------
                  " union all " +
                // -------- Start of secondary Qty------
                  " select CustomerID, ASGID,ASGName,BrandID,BrandDesc,0 as TGTQty, 0 as PriQty,0 as SecTGT, sum(SecQty)As SecQty " +
                  " from " +
                  " ( " +
                  " select Cust.CustomerID, ASGID,ASGName,BrandID,BrandDesc, 0 as TGTQty, 0 as PriQty, 0 as SecTGT,SecQty " +
                  " from " +
                  " ( " +
                  " select CustomerID ,125 as ASGID,'GLS'as ASGName,1 as BrandID, 'Philips'as BrandDesc, sum(PGLS) as SecQty " +
                  " from t_SMSDailySecondarySalesCollection  " +
                  " where trandate between '01-Aug-2015' and '01-Sep-2015' and Trandate < '01-Sep-2015' " +
                  " and CustomerID not in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1 )  " +
                  " group by CustomerID " +
                  " union all " +
                  " select CustomerID, 125 as ASGID,'GLS'as ASGName,4 as BrandID, 'Transtec'as BrandDesc, sum(TGLS) as SecQty " +
                  " from t_SMSDailySecondarySalesCollection  " +
                  " where trandate between '01-Aug-2015' and '01-Sep-2015' and Trandate < '01-Sep-2015' " +
                  " and CustomerID not in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1 )  " +
                  " group by CustomerID " +
                  " union all " +
                  " select CustomerID, 126 as ASGID,'CFL'as ASGName,4 as BrandID, 'Transtec'as BrandDesc, sum(TCFL) as SecQty " +
                  " from t_SMSDailySecondarySalesCollection   " +
                  " where trandate between '01-Aug-2015' and '01-Sep-2015' and Trandate < '01-Sep-2015'  " +
                  " and CustomerID not in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1 )  " +
                  " group by CustomerID " +
                  " union all " +
                  " select CustomerID,127 as ASGID,'TL'as ASGName,4 as BrandID, 'Transtec'as BrandDesc, sum(TTL) as SecQty " +
                  " from t_SMSDailySecondarySalesCollection  " +
                  " where trandate between '01-Aug-2015' and '01-Sep-2015' and Trandate < '01-Sep-2015'  " +
                  " and CustomerID not in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1 )  " +
                  " group by CustomerID " +
                  " )as SMS  " +
                  " inner join BLLSysDB.dbo.v_Customerdetails as Cust on SMS.CustomerID=Cust.CustomerCode " +

                  " union all " +

                  " select DistributorID,ASGID,ASGName,BrandID,BrandDesc, 0 as TGTQty, 0 as PriQty,0 as SecTGT, sum(Qty)as SecQty  " +
                  " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c  " +
                  " where TranTypeID in (2) and a.TranID=b.TranID and Trandate between '01-Aug-2015' and '01-Sep-2015' and Trandate < '01-Sep-2015'  " +
                  " and b.ProductID=c.ProductID and DistributorID in ( select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1 ) " +
                  " group by DistributorID,ASGID,ASGName,BrandID,BrandDesc " +

                  " )As Sec  " +
                  " group by CustomerID, ASGID,ASGName,BrandID,BrandDesc  " +
                // -------- End of secondary Qty------

                  " union all " +

                  // -------- Start of secondary Target Qty------
                  " select DistributorID, ASGID,ASGName,BrandID,BrandDesc,0 as TGTQty, 0 as PriQty,SecTGT, 0 as SecQty " +
                  " from " +
                  " ( " +
                  " select DistributorID, ASGID,ASGName= case when ASGID=125 then 'GLS' when ASGID=126 then 'CFL' when ASGID=127 then 'TL' " +
                  " when ASGID=139 then 'Ballast' when ASGID=140 then 'Starter' when ASGID=679  then 'LED' else 'NO' end, " +
                  " BrandID,BrandDesc= case when BrandID= 1 then 'Philips' when BrandID=4 then 'Transtec' else 'NO' end,  sum(TSOTGTQty)as SecTGT " +
                  " from BLLSysDB.dbo.t_DMSASGTarget  " +
                  " where TargetDate='01-Aug-2015'  " +
                  " group by DistributorID, ASGID,BrandID " +
                  " )As SecTGT " +
                // -------- End of secondary Target Qty------
                  " )as Final   " +
                  " group by customerID,ASGID,ASGName,BrandID, BrandDesc " +
                  " )as Total inner join BLLSysDB.dbo.v_Customerdetails as Cust on Total.CustomerID=Cust.CustomerID " +
                  "   order by  ChannelID, ChannelName,AreaID,AreaName,TerritoryName,Total.CustomerID,CustomerCode,Customername,ASGID,ASGName,Total.BrandID, BrandDesc ";




            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    TargetVsAch oTargetVsAch = new TargetVsAch();


                    oTargetVsAch.Channelname = reader["ChannelName"].ToString();
                    oTargetVsAch.AreaName = reader["AreaName"].ToString();
                    oTargetVsAch.TerritoryName = reader["TerritoryName"].ToString();
                    oTargetVsAch.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                    oTargetVsAch.CustomerName = reader["Customername"].ToString();
                    oTargetVsAch.ASGID = Convert.ToInt16(reader["ASGID"]);
                    oTargetVsAch.ASGName = reader["ASGName"].ToString();
                    oTargetVsAch.BrandID = Convert.ToInt16(reader["BrandID"]);
                    oTargetVsAch.BrandDesc = reader["BrandDesc"].ToString();



                    oTargetVsAch.TGTQty = Convert.ToDouble(reader["TGTQty"]);
                    oTargetVsAch.PriQty = Convert.ToDouble(reader["PriQty"]);
                    oTargetVsAch.SecTGT = Convert.ToDouble(reader["SecTGT"]);
                    oTargetVsAch.SecQty = Convert.ToDouble(reader["SecQty"]);

                    InnerList.Add(oTargetVsAch);
                }
                reader.Close();
                InnerList.TrimToSize();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void PriSalesValueBLL()
        {
            DateTime dFromDate = DateTime.Now.Date;
            DateTime dToDate = dFromDate.AddDays(1);
            DateTime dLastDate = dFromDate.AddDays(-1);

            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //old query
            //sSql = " select ChannelID,AreaID, AreaName, TerrritoryName,CustomerID, CustomerName, DTD, LD, MTD, LM, YTD   "+       
            //    " from      "+
            //    " ( "+
            //    " select Total.CustomerID,ChannelID,AreaID, AreaName, TerrritoryName, CustomerName, DTD, LD, MTD, LM, YTD "+          
            //    " from   "+    
            //    " ( "+
            //    " select CustomerID, sum(DTD)as DTD,sum(LD)as LD,sum(MTD)as MTD, sum(LM)as LM, sum(YTD)as YTD "+          
            //    " from "+     
            //    " ( "+
            //    " select CustomerID, isnull(sum(crAmount) - abs(sum(drAmount)),0) as DTD, 0 as LD,0 as MTD, 0 as LM,0 as YTD   "+        
            //    " from   "+    
            //    " (  "+    
            //    " select CustomerID,sum(invoiceamount) as crAmount, 0 as drAmount  "+
            //    " from bllsysdb.dbo.t_salesInvoice  "+
            //    " where invoicedate between '" + dFromDate + "'  and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
            //    " and invoicetypeid in (1,2,3,4,5,17) and invoicestatus not in (3)  "+
            //    " group by CustomerID  "+
            //    " union all        "+
            //    " select CustomerID, 0 as crAmount,sum(invoiceamount) as drAmount   "+
            //    " from bllsysdb.dbo.t_salesInvoice       "+
            //    " where invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
            //    " and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3)   "+
            //    " group by  CustomerID   "+
            //    " )as p2       "+
            //    " group by CustomerID  "+
            //    " union all "+
            //    " select CustomerID,0 as DTD, isnull(sum(crAmount) - abs(sum(drAmount)),0)as LD,0 as MTD, 0 as LM,0 as YTD  "+
            //    " from  "+    
            //    " (  "+   
            //    " select CustomerID,sum(invoiceamount) as crAmount, 0 as drAmount  "+
            //    " from bllsysdb.dbo.t_salesInvoice  "+
            //    " where invoicedate between '" + dLastDate + "'  and '" + dFromDate + "'  and invoicedate < '" + dFromDate + "'  " +
            //    " and invoicetypeid in (1,2,3,4,5,17) and invoicestatus not in (3)  "+
            //    " group by CustomerID  "+
            //    " union all  "+      
            //    " select CustomerID, 0 as crAmount,sum(invoiceamount) as drAmount   "+
            //    " from bllsysdb.dbo.t_salesInvoice   "+
            //    " where invoicedate between '" + dLastDate + "' and '" + dFromDate + "'  and invoicedate < '" + dFromDate + "'  " +
            //    " and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3)   "+
            //    " group by  CustomerID   "+
            //    " )as p2   "+    
            //    " group by CustomerID  "+
            //    " union all "+
            //    " select CustomerID, 0 as DTD, 0 as LD, isnull(sum(crAmount) - abs(sum(drAmount)),0)as MTD,0 as LM, 0 as YTD   "+        
            //    " from       "+
            //    " (      "+
            //    " select CustomerID,sum(invoiceamount) as crAmount, 0 as drAmount  "+
            //    " from bllsysdb.dbo.t_salesInvoice  "+
            //    " where invoicedate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0)  and DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0) "+
            //    " and invoicedate < DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0) "+
            //    " and invoicetypeid in (1,2,3,4,5,17) and invoicestatus not in (3)  "+
            //    " group by CustomerID  "+
            //    " union all        "+
            //    " select CustomerID, 0 as crAmount,sum(invoiceamount) as drAmount   "+
            //    " from bllsysdb.dbo.t_salesInvoice       "+
            //    " where invoicedate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0)  and DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0) "+
            //    " and invoicedate <  DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0) "+
            //    " and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3)   "+
            //    " group by  CustomerID   "+
            //    " )as p2       "+
            //    " group by CustomerID  "+
            //    " union all "+
            //    " select CustomerID, 0 as DTD, 0 as LD, 0 as MTD, isnull(sum(crAmount) - abs(sum(drAmount)),0)as LM,0 as YTD       "+    
            //    " from       "+
            //    " (      "+
            //    " select CustomerID,sum(invoiceamount) as crAmount, 0 as drAmount  "+
            //    " from bllsysdb.dbo.t_salesInvoice  "+
            //    " where invoicedate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) -1, 0)  and  DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0) "+
            //    " and invoicedate < DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0) "+
            //    " and invoicetypeid in (1,2,3,4,5,17) and invoicestatus not in (3) "+ 
            //    " group by CustomerID  "+
            //    " union all        "+
            //    " select CustomerID, 0 as crAmount,sum(invoiceamount) as drAmount   "+
            //    " from bllsysdb.dbo.t_salesInvoice       "+
            //    " where invoicedate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) -1, 0)  and  DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0) "+
            //    " and invoicedate < DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0) "+
            //    " and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3)   "+
            //    " group by  CustomerID   "+
            //    " )as p2       "+
            //    " group by CustomerID  "+
            //    " union all "+
            //    " select CustomerID, 0 as DTD, 0 as LD, 0 as MTD, 0 as LM, isnull(sum(crAmount) - abs(sum(drAmount)),0)as YTD   "+        
            //    " from       "+
            //    " (      "+
            //    " select CustomerID,sum(invoiceamount) as crAmount, 0 as drAmount  "+
            //    " from bllsysdb.dbo.t_salesInvoice  "+
            //    " where ( Invoicedate between '1/1/' + CONVERT(varchar, YEAR(GETDATE())) and  '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))  "+
            //    " and (Invoicedate <  '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) "+
            //    " and invoicetypeid in (1,2,3,4,5,17) and invoicestatus not in (3)  "+
            //    " group by CustomerID  "+
            //    " union all        "+
            //    " select CustomerID, 0 as crAmount,sum(invoiceamount) as drAmount   "+
            //    " from bllsysdb.dbo.t_salesInvoice       "+
            //    " where ( Invoicedate between '1/1/' + CONVERT(varchar, YEAR(GETDATE())) and  '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))  "+
            //    " and (Invoicedate <  '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) "+
            //    " and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3)   "+
            //    " group by  CustomerID   "+
            //    " )as p2       "+
            //    " group by CustomerID  "+
            //    " )As Sales "+
            //    " group by CustomerID "+
            //    " )As Total "+
            //    " left outer join "+
            //    " ( "+
            //    " select CustomerID,ChannelID,AreaID, AreaShortName as AreaName,TerritoryShortName as TerrritoryName, CustomerName  from  DWDB.dbo.t_CustomerDetails "+
            //    " where CompanyName='BLL'  "+
            //    " )as Cust on  Total.CustomerID=Cust.CustomerID "+
            //    " )as Gtotal "+
            //    " where ChannelID=2 "+
            //    " order by AreaID, AreaName, TerrritoryName, CustomerName ";
            //new query
            sSql = @"select ChannelID,RegionShortName,AreaID, AreaName, TerrritoryName,CustomerID, CustomerName, DTD, LD, MTD, LM, YTD
                    from
                    (
                    select Total.CustomerID, ChannelID, RegionShortName, AreaID, AreaName, TerrritoryName, CustomerName, DTD, LD, MTD, LM, YTD
                    from
                    (
                    select CustomerID, sum(DTD) as DTD, sum(LD) as LD, sum(MTD) as MTD, sum(LM) as LM, sum(YTD) as YTD
                    from
                    (
                    select CustomerID, isnull(sum(crAmount) - abs(sum(drAmount)), 0) as DTD, 0 as LD, 0 as MTD, 0 as LM, 0 as YTD
                    from
                    (
                    select CustomerID, sum(invoiceamount) as crAmount, 0 as drAmount
                    from bllsysdb.dbo.t_salesInvoice
                    where invoicedate between '"+dFromDate+@"'  and '"+dToDate+@"' and invoicedate < '"+dToDate+@"'
                    and invoicetypeid in (1, 2, 3, 4, 5, 17) and invoicestatus not in (3)
                    group by CustomerID
                    union all
                    select CustomerID, 0 as crAmount, sum(invoiceamount) as drAmount
                    from bllsysdb.dbo.t_salesInvoice
                    where invoicedate between '"+dFromDate+@"'  and '"+dToDate+@"' and invoicedate < '"+dToDate+@"'
                    and invoicetypeid in (6, 7, 8, 9, 10, 12) and invoicestatus not in (3)
                    group by  CustomerID
                    ) as p2
                    group by CustomerID
                    union all
                    select CustomerID, 0 as DTD, isnull(sum(crAmount) - abs(sum(drAmount)), 0) as LD, 0 as MTD, 0 as LM, 0 as YTD
                    from
                    (
                    select CustomerID, sum(invoiceamount) as crAmount, 0 as drAmount
                    from bllsysdb.dbo.t_salesInvoice
                    where invoicedate between '"+dLastDate+@"'  and '"+dFromDate+"' and invoicedate < '"+dFromDate+@"'
                    and invoicetypeid in (1, 2, 3, 4, 5, 17) and invoicestatus not in (3)
                    group by CustomerID
                    union all
                    select CustomerID, 0 as crAmount, sum(invoiceamount) as drAmount
                    from bllsysdb.dbo.t_salesInvoice
                    where invoicedate between '"+dLastDate+@"'  and '"+dFromDate+@"' and invoicedate < '"+dFromDate+@"'
                    and invoicetypeid in (6, 7, 8, 9, 10, 12) and invoicestatus not in (3)
                    group by  CustomerID
                    )as p2
                    group by CustomerID
                    union all
                    select CustomerID, 0 as DTD, 0 as LD, isnull(sum(crAmount) - abs(sum(drAmount)), 0) as MTD,0 as LM, 0 as YTD
                    from
                    (
                    select CustomerID, sum(invoiceamount) as crAmount, 0 as drAmount
                    from bllsysdb.dbo.t_salesInvoice
                    where invoicedate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0)  and DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0)
                    and invoicedate < DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0)
                    and invoicetypeid in (1, 2, 3, 4, 5, 17) and invoicestatus not in (3)
                    group by CustomerID
                    union all
                    select CustomerID, 0 as crAmount,sum(invoiceamount) as drAmount
                    from bllsysdb.dbo.t_salesInvoice
                    where invoicedate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0)  and DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) +1, 0) 
                    and invoicedate < DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0)
                    and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3)
                    group by  CustomerID
                    )as p2
                    group by CustomerID
                    union all
                    select CustomerID, 0 as DTD, 0 as LD, 0 as MTD, isnull(sum(crAmount) - abs(sum(drAmount)), 0) as LM,0 as YTD
                    from
                    (
                    select CustomerID, sum(invoiceamount) as crAmount, 0 as drAmount
                    from bllsysdb.dbo.t_salesInvoice
                    where invoicedate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) - 1, 0)  and  DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0)
                    and invoicedate < DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0)
                    and invoicetypeid in (1, 2, 3, 4, 5, 17) and invoicestatus not in (3)
                    group by CustomerID
                    union all
                    select CustomerID, 0 as crAmount,sum(invoiceamount) as drAmount
                    from bllsysdb.dbo.t_salesInvoice
                    where invoicedate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) -1, 0)  and DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0)
                    and invoicedate < DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0)
                    and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3)
                    group by  CustomerID
                    )as p2
                    group by CustomerID
                    union all
                    select CustomerID, 0 as DTD, 0 as LD, 0 as MTD, 0 as LM, isnull(sum(crAmount) - abs(sum(drAmount)), 0) as YTD
                    from
                    (
                    select CustomerID, sum(invoiceamount) as crAmount, 0 as drAmount
                    from bllsysdb.dbo.t_salesInvoice
                    where (Invoicedate between '1/1/' + CONVERT(varchar, YEAR(GETDATE())) and  '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))
                    and(Invoicedate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))
                    and invoicetypeid in (1,2,3,4,5,17) and invoicestatus not in (3)
                    group by CustomerID
                    union all
                    select CustomerID, 0 as crAmount,sum(invoiceamount) as drAmount
                    from bllsysdb.dbo.t_salesInvoice
                    where (Invoicedate between '1/1/' + CONVERT(varchar, YEAR(GETDATE())) and  '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))  
                    and(Invoicedate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))
                    and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3)
                    group by  CustomerID
                    )as p2
                    group by CustomerID
                    )As Sales
                    group by CustomerID
                    )As Total
                    left outer join
                    (
                    select CustomerID, ChannelID, RegionShortName, AreaID, AreaShortName as AreaName, TerritoryShortName as TerrritoryName, CustomerName  from v_CustomerDetails
                    ) as Cust on Total.CustomerID = Cust.CustomerID
                    )as Gtotal
                    where ChannelID = 2
                    order by AreaID, AreaName, TerrritoryName, CustomerName

                    ";



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    TargetVsAch oTargetVsAch = new TargetVsAch();


                    oTargetVsAch.AreaName = reader["AreaName"].ToString();
                    oTargetVsAch.TerritoryName = reader["TerrritoryName"].ToString();
                    oTargetVsAch.CustomerName = reader["CustomerName"].ToString();
                    oTargetVsAch.DTD = Convert.ToDouble(reader["DTD"]);
                    oTargetVsAch.LD = Convert.ToDouble(reader["LD"]);
                    oTargetVsAch.MTD = Convert.ToDouble(reader["MTD"]);
                    oTargetVsAch.LM = Convert.ToDouble(reader["LM"]);
                    oTargetVsAch.YTD = Convert.ToDouble(reader["YTD"]);   
                    InnerList.Add(oTargetVsAch);
                }
                reader.Close();
                InnerList.TrimToSize();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void SecSalesValueBLL1()
        {
            DateTime dFromDate = DateTime.Now.Date;
            DateTime dToDate = dFromDate.AddDays(1);
            DateTime dLastDate = dFromDate.AddDays(-1);

            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            sSql = " select Total.DistributorID as CustomerID,AreaID, AreaName, TerrritoryName, CustomerName, DTD, LD, MTD, LM, YTD  " +
                   " from      " +
                   " ( " +
                   " select DistributorID, sum(DTD)as DTD,sum(LD)as LD,sum(MTD)as MTD, sum(LM)as LM, sum(YTD)as YTD " +
                   " from " +
                   " ( " +
                   " select DistributorID, sum(NetAmount) as DTD,0 as LD, 0 as MTD, 0 as LM, 0 as YTD  " +
                   " from bllsysdb.dbo.t_DMSProductTran " +
                   " where TranDate between '" + dFromDate + "'  and '" + dToDate + "' and TranDate < '" + dToDate + "' " +
                   " and Trantypeid=2 " +
                   " group by DistributorID " +
                   " union all " +
                   " select DistributorID,0 as DTD, sum(NetAmount) as LD, 0 as MTD, 0 as LM, 0 as YTD  " +
                   " from bllsysdb.dbo.t_DMSProductTran " +
                   " where TranDate between '" + dLastDate + "'  and  '" + dFromDate + "'  and TranDate < '" + dFromDate + "'  " +
                   " and Trantypeid=2 " +
                   " group by DistributorID " +
                   " union all " +
                   " select DistributorID,0 as DTD,0 as LD, sum(NetAmount) as MTD, 0 as LM, 0 as YTD  " +
                   " from bllsysdb.dbo.t_DMSProductTran " +
                   " where TranDate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0)  and DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0) " +
                   " and TranDate < DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0) " +
                   " and Trantypeid=2 " +
                   " group by DistributorID " +
                   " union all " +
                   " select DistributorID,0 as DTD,0 as LD, 0 as MTD, sum(NetAmount)as LM, 0 as YTD  " +
                   " from bllsysdb.dbo.t_DMSProductTran " +
                   " where TranDate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) -1, 0)  and DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0)  and TranDate < DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0) " +
                   " and Trantypeid=2 " +
                   " group by DistributorID " +
                   " union all " +
                   " select DistributorID,0 as DTD,0 as LD, 0 as MTD,0 as LM, sum(NetAmount)as YTD  " +
                   " from bllsysdb.dbo.t_DMSProductTran " +
                   " where TranDate between '1/1/' + CONVERT(varchar, YEAR(GETDATE()))  and '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)  and TranDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1) " +
                   " and Trantypeid=2 " +
                   " group by DistributorID " +
                   " )As Sales " +
                   " group by DistributorID " +
                   " )As Total " +
                   " left outer join " +
                   " ( " +
                   " select CustomerID,AreaID, AreaShortName as AreaName,TerritoryShortName as TerrritoryName, CustomerName  from  BLLSysDB.dbo.v_CustomerDetails " +
                   " )as Cust on  Total.DistributorID=Cust.CustomerID order by AreaId,TerrritoryName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    TargetVsAch oTargetVsAch = new TargetVsAch();


                    oTargetVsAch.AreaName = reader["AreaName"].ToString();
                    oTargetVsAch.TerritoryName = reader["TerrritoryName"].ToString();
                    oTargetVsAch.CustomerName = reader["CustomerName"].ToString();
                    oTargetVsAch.DTD = Convert.ToDouble(reader["DTD"]);
                    oTargetVsAch.LD = Convert.ToDouble(reader["LD"]);
                    oTargetVsAch.MTD = Convert.ToDouble(reader["MTD"]);
                    oTargetVsAch.LM = Convert.ToDouble(reader["LM"]);
                    oTargetVsAch.YTD = Convert.ToDouble(reader["YTD"]);
                    InnerList.Add(oTargetVsAch);
                }
                reader.Close();
                InnerList.TrimToSize();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void SecSalesValueBLL()
        {
            DateTime dFromDate = DateTime.Now.Date;
            DateTime dToDate = dFromDate.AddDays(1);
            DateTime dLastDate = dFromDate.AddDays(-1);

            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //old query
            //sSql = " select Total.DistributorID as CustomerID,AreaID, AreaName, TerrritoryName, CustomerName, DTD, LD, MTD, LM, YTD  "+
            //       " from  "+    
            //       " ( "+
            // " select DistributorID, sum(DTD)as DTD,sum(LD)as LD,sum(MTD)as MTD, sum(LM)as LM, sum(YTD)as YTD "+
            // " from "+
            // " ( "+
            //  // -- DMS Data Start------
            // "  select DistributorID, sum(DTD)as DTD,sum(LD)as LD,sum(MTD)as MTD, sum(LM)as LM, sum(YTD)as YTD  "+
            //       " from  "+
            //       " (  "+
            //       " select DistributorID, sum(NetAmount) as DTD,0 as LD, 0 as MTD, 0 as LM, 0 as YTD   "+
            //       " from bllsysdb.dbo.t_DMSProductTran  "+
            //       " where TranDate between '" + dFromDate + "'  and '" + dToDate + "' and TranDate < '" + dToDate + "' "+
            //       " and Trantypeid=2 and DistributorID in (select DistributorID from bllsysdb.dbo.t_DMSuser where isactive=1 ) " +
            //       " group by DistributorID  "+
            //       " union all  "+
            //       " select DistributorID,0 as DTD, sum(NetAmount) as LD, 0 as MTD, 0 as LM, 0 as YTD   "+
            //       " from bllsysdb.dbo.t_DMSProductTran  "+
            //       " where TranDate between '" + dLastDate + "'  and  '" + dFromDate + "'  and TranDate < '" + dFromDate + "' "+
            //       " and Trantypeid=2  and DistributorID in (select DistributorID from bllsysdb.dbo.t_DMSuser where isactive=1 ) " +
            //       " group by DistributorID  "+
            //       " union all  "+
            //       " select DistributorID,0 as DTD,0 as LD, sum(NetAmount) as MTD, 0 as LM, 0 as YTD   "+
            //       " from bllsysdb.dbo.t_DMSProductTran  "+
            //       " where TranDate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0)  and DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0) and TranDate < DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0) "+
            //       " and Trantypeid=2 and DistributorID in (select DistributorID from bllsysdb.dbo.t_DMSuser where isactive=1 ) " +
            //       " group by DistributorID  "+
            //       " union all "+
            //       " select DistributorID,0 as DTD,0 as LD, 0 as MTD, sum(NetAmount)as LM, 0 as YTD  "+ 
            //       " from bllsysdb.dbo.t_DMSProductTran  "+
            //       " where TranDate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) -1, 0)  and DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0)  and TranDate < DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0) "+
            //       " and Trantypeid=2 and DistributorID in (select DistributorID from bllsysdb.dbo.t_DMSuser where isactive=1 ) " +
            //       " group by DistributorID  "+
            //       " union all  "+
            //       " select DistributorID,0 as DTD,0 as LD, 0 as MTD,0 as LM, sum(NetAmount)as YTD   "+
            //       " from bllsysdb.dbo.t_DMSProductTran "+
            //       " where TranDate between '1/1/' + CONVERT(varchar, YEAR(GETDATE()))  and '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)  and TranDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)  "+
            //       " and Trantypeid=2 and DistributorID in (select DistributorID from bllsysdb.dbo.t_DMSuser where isactive=1 ) " +
            //       " group by DistributorID  "+
            //       " )As Sales  "+
            //       " group by DistributorID  "+
            //  //-- DMS Data End------
            //  " union all "+
            // // -- SMS  Data Start------ 
            // " select CustomerID as DistributorID, sum(DTD)as DTD,sum(LD)as LD,sum(MTD)as MTD, sum(LM)as LM, sum(YTD)as YTD  "+
            //       " from  "+
            //       " (  "+
            //       " select b.CustomerID, sum(TEBL) as DTD,0 as LD, 0 as MTD, 0 as LM, 0 as YTD   "+
            //       " from TELSysDB.dbo.t_SMSDailySecondarySalesCollection a, bllsysdb.dbo.t_Customer b " +
            //       " where TranDate between '" + dFromDate + "'  and '" + dToDate + "' and TranDate < '" + dToDate + "' "+
            //       " and a.CustomerID=b.CustomerCode and b.CustomerID not in (select DistributorID from bllsysdb.dbo.t_DMSuser where isactive=1 ) " +
            //       " group by b.CustomerID  "+
            //       " union all  "+
            //       " select b.CustomerID, 0 as DTD, sum(TEBL) as LD, 0 as MTD, 0 as LM, 0 as YTD   "+
            //       " from TELSysDB.dbo.t_SMSDailySecondarySalesCollection a, bllsysdb.dbo.t_Customer b " +
            //       " where TranDate between '" + dLastDate + "'  and  '" + dFromDate + "'  and TranDate < '" + dFromDate + "' "+
            //       " and a.CustomerID=b.CustomerCode and b.CustomerID not in (select DistributorID from bllsysdb.dbo.t_DMSuser where isactive=1 ) " +
            //       " group by b.CustomerID  "+
            //       " union all  "+
            //       " select b.CustomerID, 0 as DTD, 0 as LD, sum(TEBL) as MTD, 0 as LM, 0 as YTD   "+
            //       " from TELSysDB.dbo.t_SMSDailySecondarySalesCollection a, bllsysdb.dbo.t_Customer b " +
            //       " where TranDate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0)  and DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0) and TranDate < DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0) "+
            //       " and a.CustomerID=b.CustomerCode and b.CustomerID not in (select DistributorID from bllsysdb.dbo.t_DMSuser where isactive=1 ) " +
            //       " group by b.CustomerID "+
            //       " union all "+
            //       " select b.CustomerID, 0 as DTD, 0 as LD, 0 as MTD, sum(TEBL) as LM, 0 as YTD   "+
            //       " from TELSysDB.dbo.t_SMSDailySecondarySalesCollection a, bllsysdb.dbo.t_Customer b " +
            //       " where TranDate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) -1, 0)  and DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0)  and TranDate < DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0) "+
            //       " and a.CustomerID=b.CustomerCode and b.CustomerID not in (select DistributorID from bllsysdb.dbo.t_DMSuser where isactive=1 ) " +
            //       " group by b.CustomerID "+
            //       " union all "+
            //       " select b.CustomerID, 0 as DTD, 0 as LD, 0 as MTD, 0 as LM, sum(TEBL) as YTD   "+
            //       " from TELSysDB.dbo.t_SMSDailySecondarySalesCollection a, bllsysdb.dbo.t_Customer b " +
            //       " where TranDate between '1/1/' + CONVERT(varchar, YEAR(GETDATE()))  and '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)  and TranDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1) "+
            //       " and a.CustomerID=b.CustomerCode and b.CustomerID not in (select DistributorID from bllsysdb.dbo.t_DMSuser where isactive=1 ) " +
            //       " group by b.CustomerID  "+
            //       " )As Sales "+
            //       " group by CustomerID  "+
            //    //   -- SMS  Data End------
            // "  )as STotal "+
            // " group  by DistributorID "+
            //       " )As Total "+
            // "  left outer join  "+
            //       " ( "+
            //       " select CustomerID,AreaID, AreaShortName as AreaName,TerritoryShortName as TerrritoryName, CustomerName  from  BLLSysDB.dbo.v_CustomerDetails  " +
            //       " )as Cust on  Total.DistributorID=Cust.CustomerID order by AreaID, AreaName, TerrritoryName, CustomerName ";

            //new query
            sSql = @"select Total.DistributorID as CustomerID,RegionShortName,AreaID, AreaName, TerrritoryName, CustomerName, DTD, LD, MTD, LM, YTD
                        from
                        (
                        select DistributorID, sum(DTD) as DTD, sum(LD) as LD, sum(MTD) as MTD, sum(LM) as LM, sum(YTD) as YTD
                        from
                        (
                        select DistributorID, sum(DTD) as DTD, sum(LD) as LD, sum(MTD) as MTD, sum(LM) as LM, sum(YTD) as YTD
                        from
                        (
                        select DistributorID, sum(NetAmount) as DTD, 0 as LD, 0 as MTD, 0 as LM, 0 as YTD
                        from bllsysdb.dbo.t_DMSProductTran
                        where TranDate between '"+dFromDate+@"'  and '"+dToDate+@"' and TranDate < '"+dToDate+@"'
                        and Trantypeid = 2 and DistributorID in (select DistributorID from bllsysdb.dbo.t_DMSuser where isactive = 1 )
                        group by DistributorID
                        union all
                        select DistributorID, 0 as DTD, sum(NetAmount) as LD, 0 as MTD, 0 as LM, 0 as YTD
                        from bllsysdb.dbo.t_DMSProductTran
                        where TranDate between '"+dLastDate+@"' and '"+dFromDate+@"' and TranDate < '"+dFromDate+@"'
                        and Trantypeid = 2  and DistributorID in (select DistributorID from bllsysdb.dbo.t_DMSuser where isactive = 1 )
                        group by DistributorID
                        union all
                        select DistributorID, 0 as DTD, 0 as LD, sum(NetAmount) as MTD, 0 as LM, 0 as YTD
                        from bllsysdb.dbo.t_DMSProductTran
                        where TranDate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0)  and DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0) and TranDate < DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0)
                        and Trantypeid = 2 and DistributorID in (select DistributorID from bllsysdb.dbo.t_DMSuser where isactive = 1 )
                        group by DistributorID
                        union all
                        select DistributorID,0 as DTD,0 as LD, 0 as MTD, sum(NetAmount) as LM, 0 as YTD
                        from bllsysdb.dbo.t_DMSProductTran
                        where TranDate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) -1, 0)  and DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0)  and TranDate < DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0)
                        and Trantypeid = 2 and DistributorID in (select DistributorID from bllsysdb.dbo.t_DMSuser where isactive = 1 )
                        group by DistributorID
                        union all
                        select DistributorID,0 as DTD,0 as LD, 0 as MTD,0 as LM, sum(NetAmount) as YTD
                        from bllsysdb.dbo.t_DMSProductTran
                        where TranDate between '1/1/' + CONVERT(varchar, YEAR(GETDATE()))  and '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)  and TranDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)
                        and Trantypeid = 2 and DistributorID in (select DistributorID from bllsysdb.dbo.t_DMSuser where isactive = 1 ) 
                        group by DistributorID
                        )As Sales
                        group by DistributorID


                        )as STotal
                        group by DistributorID
                        )As Total
                        left outer join
                        (
                        select CustomerID, RegionShortName, AreaID, AreaShortName as AreaName, TerritoryShortName as TerrritoryName, CustomerName  from BLLSysDB.dbo.v_CustomerDetails
                        ) as Cust on Total.DistributorID = Cust.CustomerID order by AreaID, AreaName, TerrritoryName, CustomerName


";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    TargetVsAch oTargetVsAch = new TargetVsAch();


                    oTargetVsAch.AreaName = reader["AreaName"].ToString();
                    oTargetVsAch.TerritoryName = reader["TerrritoryName"].ToString();
                    oTargetVsAch.CustomerName = reader["CustomerName"].ToString();
                    oTargetVsAch.DTD = Convert.ToDouble(reader["DTD"]);
                    oTargetVsAch.LD = Convert.ToDouble(reader["LD"]);
                    oTargetVsAch.MTD = Convert.ToDouble(reader["MTD"]);
                    oTargetVsAch.LM = Convert.ToDouble(reader["LM"]);
                    oTargetVsAch.YTD = Convert.ToDouble(reader["YTD"]);
                    InnerList.Add(oTargetVsAch);
                }
                reader.Close();
                InnerList.TrimToSize();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void SecSalesValueBLLDWH()
        {
            DateTime dFromDate = DateTime.Now.Date;
            DateTime dToDate = dFromDate.AddDays(1);
            DateTime dLastDate = dFromDate.AddDays(-1);

            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            sSql = " select Total.CustomerID as CustomerID, AreaID, AreaName, TerrritoryName, CustomerName, (DTD)as DTD,(LD)as LD,(MTD)as MTD,(LM )as LM,(YTD)as YTD  " +
                   " from  " +
                   " ( " +
                   " select CustomerID, sum(DTD)as DTD,sum(LD)as LD,sum(MTD)as MTD, sum(LM)as LM, sum(YTD)as YTD " +
                   " from " +
                   " ( " +                

                   " select b.CustomerID , sum(Amount) as DTD, 0 as LD, 0 as MTD, 0 as LM, 0 as YTD   " +
                   " from DWDB.dbo.t_BLLSecondarySales a, bllsysdb.dbo.t_Customer b  " +
                   " where a.CustomerID=b.CustomerID and  TranDate between '" + dFromDate + "'  and '" + dToDate + "'  and TranDate <  '" + dToDate + "'  " +
                   " group by b.CustomerID  " +

                   " union all  " +

                   " select b.CustomerID, 0 as DTD, sum(Amount) as LD, 0 as MTD, 0 as LM, 0 as YTD   " +
                   " from DWDB.dbo.t_BLLSecondarySales a, bllsysdb.dbo.t_Customer b  " +
                   " where a.CustomerID=b.CustomerID and  TranDate between '" + dLastDate + "'   and '" + dFromDate + "'  and TranDate <  '" + dFromDate + "' " +
                   " group by b.CustomerID  " +

                   " union all  " +
                 
                   " select b.CustomerID, 0 as DTD, 0 as LD, sum(Amount)as MTD, 0 as LM, 0 as YTD   " +
                   " from DWDB.dbo.t_BLLSecondarySales a, bllsysdb.dbo.t_Customer b  " +
                   " where a.CustomerID=b.CustomerID and  TranDate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0)  and DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0)  and TranDate < DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0) " +
                   " group by b.CustomerID " +
                   
                   " union all " +               

                   " select b.CustomerID, 0 as DTD, 0 as LD, 0 as MTD, sum(Amount) as LM, 0 as YTD   " +
                   " from DWDB.dbo.t_BLLSecondarySales a, bllsysdb.dbo.t_Customer b  " +
                   " where a.CustomerID=b.CustomerID and  TranDate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) -1, 0)  and DATEADD(month, DATEDIFF(month, 0, getdate()), 0)  and TranDate < DATEADD(month, DATEDIFF(month, 0, getdate()), 0) " +
                   " group by b.CustomerID " +
                   " union all  " +             

                   " select b.CustomerID, 0 as DTD, 0 as LD, 0 as MTD, 0 as LM, sum(Amount) as YTD   " +
                   " from DWDB.dbo.t_BLLSecondarySales a, bllsysdb.dbo.t_Customer b  " +
                   " where a.CustomerID=b.CustomerID and  TranDate between '1/1/' + CONVERT(varchar, YEAR(GETDATE()))  and '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)  and TranDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1) " +
                   " group by b.CustomerID " +

                   " )As Sales  " +
                   " group by CustomerID  " +
                
                   " )As Total " +
                   "  left outer join  " +
                   " ( " +
                   " select CustomerID,AreaID, AreaShortName as AreaName,TerritoryShortName as TerrritoryName, CustomerName  from  BLLSysDB.dbo.v_CustomerDetails  " +
                   " )as Cust on  Total.CustomerID=Cust.CustomerID order by AreaID, AreaName, TerrritoryName, CustomerName ";



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    TargetVsAch oTargetVsAch = new TargetVsAch();


                    oTargetVsAch.AreaName = reader["AreaName"].ToString();
                    oTargetVsAch.TerritoryName = reader["TerrritoryName"].ToString();
                    oTargetVsAch.CustomerName = reader["CustomerName"].ToString();
                    oTargetVsAch.DTD = Convert.ToDouble(reader["DTD"]);
                    oTargetVsAch.LD = Convert.ToDouble(reader["LD"]);
                    oTargetVsAch.MTD = Convert.ToDouble(reader["MTD"]);
                    oTargetVsAch.LM = Convert.ToDouble(reader["LM"]);
                    oTargetVsAch.YTD = Convert.ToDouble(reader["YTD"]);
                    InnerList.Add(oTargetVsAch);
                }
                reader.Close();
                InnerList.TrimToSize();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetDMSStatus(string sAndroidAppID, string sUserName)
        {

            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);

            //sSql = " select AreaShortName as AreaName,userName as CustomerName,OperationDate,MobileNo,CASE When day(OperationDate)= day (getdate())  then 1 else 2 end as DBType " +
            //       " from bllsysdb.dbo.t_DMSuser a,  bllsysdb.dbo.v_Customerdetails b " +
            //       " where a.DistributorID=b.CustomerID and a.Isactive=1 order by OperationDate,AreaID,TerritoryID,CustomerID  ";


            //sSql = "  select AreaShortName as AreaName,userName as CustomerName,isnull(OperationDate,'01-Jan-1900')as OperationDate, isnull(MobileNo,0)as MobileNo, " +
            //  " CASE When day(OperationDate)= day (getdate())  then 1 else 2 end as DBType " +
            //  " from bllsysdb.dbo.t_DMSuser a,  bllsysdb.dbo.v_Customerdetails b " +
            //  " where a.DistributorID=b.CustomerID and a.Isactive=1 and b.CustomerTypeID = 229 ";

            sSql = "  select AreaShortName as AreaName,CustomerShortName as CustomerName,isnull(OperationDate,'01-Jan-1900')as OperationDate, isnull(MobileNo,0)as MobileNo, " +
              " CASE When day(OperationDate)= day (getdate())  then 1 else 2 end as DBType " +
              " from bllsysdb.dbo.t_DMSuser a,  bllsysdb.dbo.v_Customerdetails b " +
              " where a.DistributorID=b.CustomerID and a.Isactive=1 and OperationDate>=DATEADD(dd,DATEDIFF(dd,0,GETDATE()),-1) ";

            if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
            {
                sSql = sSql + " and b.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
            }
            sSql = sSql + " order by OperationDate,AreaID,TerritoryID  ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    TargetVsAch oTargetVsAch = new TargetVsAch();
                                       
                    oTargetVsAch.AreaName = reader["AreaName"].ToString();                    
                    oTargetVsAch.CustomerName = reader["CustomerName"].ToString();
                    oTargetVsAch.OperationDate = Convert.ToDateTime(reader["OperationDate"]);                   
                    oTargetVsAch.DBType = Convert.ToInt16(reader["DBType"]);
                    oTargetVsAch.MobileNo = reader["MobileNo"].ToString();
                    
                    InnerList.Add(oTargetVsAch);
                }
                reader.Close();
                InnerList.TrimToSize();
                //cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetDMSSalesStatus(string sAndroidAppID, string sUserName)
        {

            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);

            //sSql = " select AreaShortName as AreaName,userName as CustomerName,OperationDate,MobileNo,CASE When day(OperationDate)= day (getdate())  then 1 else 2 end as DBType " +
            //       " from bllsysdb.dbo.t_DMSuser a,  bllsysdb.dbo.v_Customerdetails b " +
            //       " where a.DistributorID=b.CustomerID and a.Isactive=1 order by OperationDate,AreaID,TerritoryID,CustomerID  ";


            //sSql = "  select AreaShortName as AreaName,userName as CustomerName,isnull(OperationDate,'01-Jan-1900')as OperationDate, isnull(MobileNo,0)as MobileNo, " +
            //  " CASE When day(OperationDate)= day (getdate())  then 1 else 2 end as DBType " +
            //  " from bllsysdb.dbo.t_DMSuser a,  bllsysdb.dbo.v_Customerdetails b " +
            //  " where a.DistributorID=b.CustomerID and a.Isactive=1 and b.CustomerTypeID = 229 ";

            sSql = "  select CustomerName, DeliveryDate, " +
                   " SalesQty, TPQty, IssueQty, ReceiveQty  " +
                   "  from " +
                   "  ( " +
                   "  select DistributorID, DeliveryDate, sum(SalesQty) as SalesQty, sum(TPQty) as TPQty, sum(IssQty) as IssueQty, " +
                   "  sum(RecQty) as ReceiveQty " +
                   "  from " +
                   "  ( " +
                   "  select DistributorID, DeliveryDate, ProductID, sum(SaleQty) as SalesQty, sum(FreeQty) as TPQty, sum(RepIssueQty) as IssQty, " +
                   "  sum(RepRecQty) as RecQty " +
                   "  from t_DMSOrder a, t_DMSOrderItem b " +
                   "  where IsDelivered = 1 " +
                   "  and DeliveryDate between DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), -1) and  DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 0) and DeliveryDate < DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 0) " +
                   "  and a.TranID = b.TranID and(SaleQty + FreeQty + RepIssueQty + RepRecQty) > 0 " +
                   "  group by DistributorID, DeliveryDate, ProductID " +
                   "  ) as ttqty group by DistributorID, DeliveryDate " +
                   "  ) as final " +
                   "  left outer join " +
                   "  ( " +
                   "  select CustomerID, CustomerShortName as CustomerName " +
                   "  from v_CustomerDetails " +
                   "     ) as op on final.DistributorID = op.CustomerID ";

            if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
            {
                sSql = sSql + "  where DistributorID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
            }
            //sSql = sSql + " order by OperationDate,AreaID,TerritoryID  ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    TargetVsAch oTargetVsAch = new TargetVsAch();

                    oTargetVsAch.CustomerName = reader["CustomerName"].ToString();
                    oTargetVsAch.OperationDate = Convert.ToDateTime(reader["DeliveryDate"]);
                    oTargetVsAch.SalesQty = Convert.ToInt16(reader["SalesQty"]);
                    oTargetVsAch.TPQty = Convert.ToInt16(reader["TPQty"]);
                    oTargetVsAch.IssueQty = Convert.ToInt16(reader["IssueQty"]);
                   // oTargetVsAch.ReceiveQty = Convert.ToInt16(reader["ReceiveQty"]);

                    InnerList.Add(oTargetVsAch);
                }
                reader.Close();
                InnerList.TrimToSize();
                //cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetBLLPhonebook(string sAndroidAppID, string sUserName)
        {

            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);

            //sSql = " select AreaShortName as AreaName,userName as CustomerName,OperationDate,MobileNo,CASE When day(OperationDate)= day (getdate())  then 1 else 2 end as DBType " +
            //       " from bllsysdb.dbo.t_DMSuser a,  bllsysdb.dbo.v_Customerdetails b " +
            //       " where a.DistributorID=b.CustomerID and a.Isactive=1 order by OperationDate,AreaID,TerritoryID,CustomerID  ";


            //sSql = "  select AreaShortName as AreaName,userName as CustomerName,isnull(OperationDate,'01-Jan-1900')as OperationDate, isnull(MobileNo,0)as MobileNo, " +
            //  " CASE When day(OperationDate)= day (getdate())  then 1 else 2 end as DBType " +
            //  " from bllsysdb.dbo.t_DMSuser a,  bllsysdb.dbo.v_Customerdetails b " +
            //  " where a.DistributorID=b.CustomerID and a.Isactive=1 and b.CustomerTypeID = 229 ";

            sSql = @" select  MarketGroupID,EmployeeID,Location,EmployeeName,Position,MobileNo,DepartmentID,Department, Grade,
                Sort= case when Grade='G-2' then 2 when Grade='G-1' then 3 when Grade='M-2' then 4 
                when Grade='M-1' then 5
                when Grade='O-5' then 6
                when Grade='O-4' then 7
                when Grade='O-3' then 8
                when Grade='O-2' then 9
                when Grade='O-1' then 10
                else 11 end
                from
                (
                -----Procurement & Commercial Start----
                select 0 as MarketGroupID,EmployeeID,'HQ' as Location,EmployeeName,DesignationName as Position,MobileNo, DepartmentID, DepartmentName as Department, JobGradeCode as Grade
                from LINKSERVERTEL.TELSYSDB.dbo.v_EmployeeDetails
                where DepartmentID=83046 and CompanyID=82943 and IspayrollEmployee=1
                and mobileno is not null and mobileno <>'0'
                -----Procurement & Commercial End----
                union all
                -----MIS & IT Start----
                select 0 as MarketGroupID,EmployeeID,'HQ' as Location,EmployeeName,DesignationName as Position,MobileNo, DepartmentID, DepartmentName as Department, JobGradeCode
                from LINKSERVERTEL.TELSYSDB.dbo.v_EmployeeDetails
                where DepartmentID=82973 and CompanyID=82943 and IspayrollEmployee=1
                and mobileno is not null and mobileno <>'0'
                -----MIS & IT End----
                union all
                -----Logistics Start----
                select 0 as MarketGroupID,EmployeeID,'HQ' as Location,EmployeeName,DesignationName as Position,MobileNo, DepartmentID, DepartmentName as Department, JobGradeCode
                from LINKSERVERTEL.TELSYSDB.dbo.v_EmployeeDetails
                where DepartmentID=82972 and CompanyID=82943 and IspayrollEmployee=1
                and mobileno is not null and mobileno <>'0'

                -----Logisitcs End----
                union all
                -----Finance & Accounts Start----
                select 0 as MarketGroupID,EmployeeID,'HQ' as Location,EmployeeName,DesignationName as Position,MobileNo, DepartmentID, DepartmentName as Department, JobGradeCode
                from LINKSERVERTEL.TELSYSDB.dbo.v_EmployeeDetails
                where DepartmentID=82969 and CompanyID=82943 and IspayrollEmployee=1
                and mobileno is not null and mobileno <>'0'

                -----Finance & Accounts End----
                union all
                -----HR Start----
                select 0 as MarketGroupID,EmployeeID,'HQ' as Location,EmployeeName,DesignationName as Position,MobileNo, DepartmentID, DepartmentName as Department, JobGradeCode
                from LINKSERVERTEL.TELSYSDB.dbo.v_EmployeeDetails
                where DepartmentID=82980 and CompanyID=82943 and IspayrollEmployee=1
                and mobileno is not null and mobileno <>'0'
                -----HR End----
                union all
                -----Marketing Start----
                select 0 as MarketGroupID,EmployeeID,'HQ' as Location,EmployeeName,DesignationName as Position,MobileNo, DepartmentID, DepartmentName as Department, JobGradeCode
                from LINKSERVERTEL.TELSYSDB.dbo.v_EmployeeDetails 
                where DepartmentID=83045  and CompanyID=82943 and IspayrollEmployee=1
                and mobileno is not null and mobileno <>'0'
                -----Marketing End----

                union all
                -----Sales Ho Start ---------------------
                select 0 as MarketGroupID, EmployeeID,'HQ'as Location, EmployeeName,DesignationName,MobileNo, DepartmentID, DepartmentName as Department, JobGradeCode as Code
                from LINKSERVERTEL.TELSYSDB.dbo.v_EmployeeDetails 
                where DepartmentID=83044  and CompanyID=82943 and IspayrollEmployee=1
                and mobileno is not null and mobileno <>'0'and empstatus not in (5,0,6) 
                and EmployeeID not in (select isnull(EmployeeID,0) from BLLsysdb.dbo.t_MarketGroup )

                )As HeadOffice 
 
                ----------------Sales HO End------------
                union all 

                select MarketGroupID,main.EmployeeID,AreaName as Location,EmployeeName, Position,MobileNumber,83044 as DepartmentID, 'Sales' as  Department, 'Sales' as JobGradeCode, 15 as Sort
                from
                (
                Select MarketGroupID, a.EmployeeID,b.EmployeeName, MarketGroupDesc as AreaName,'ASM' as Position 
                from t_MarketGroup a, LINKSERVERTEL.TELSYSDB.dbo.t_Employee b
                where MarketGroupType=1 and a.EmployeeID=b.EmployeeID
                union all
                Select ParentID, a.EmployeeID,b.EmployeeName, MarketGroupDesc as Territory, 'TSM' as Position 
                from t_MarketGroup a, LINKSERVERTEL.TELSYSDB.dbo.t_Employee b
                where MarketGroupType=2 and a.EmployeeID=b.EmployeeID
                )As Main
                left outer join
                (
                select EmployeeID, MobileID, MobileNumber
                from LINKSERVERTEL.TELSYSDB.dbo.t_MobileNumberAssign a, LINKSERVERTEL.TELSYSDB.dbo.t_MobileNumber b
                where a.MobileID=b.ID and EmployeeID is not null
                and CreditLimit>0 --and EdgePackageAmount=0
                )As Mob on Main.EmployeeID=Mob.EmployeeID
                order by Department,Sort,MarketGroupID,Position ";

            //if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
            //{
            //    sSql = sSql + " and b.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
            //    " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
            //}
            //sSql = sSql + " order by OperationDate,AreaID,TerritoryID  ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    TargetVsAch oTargetVsAch = new TargetVsAch();

                    //oTargetVsAch.AreaName = reader["AreaName"].ToString();
                    //oTargetVsAch.CustomerName = reader["CustomerName"].ToString();
                    //oTargetVsAch.OperationDate = Convert.ToDateTime(reader["OperationDate"]);
                    //oTargetVsAch.DBType = Convert.ToInt16(reader["DBType"]);
                    //oTargetVsAch.MobileNo = reader["MobileNo"].ToString();
                    oTargetVsAch.MarketGroupID = Convert.ToInt32(reader["MarketGroupID"]);
                    oTargetVsAch.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                    oTargetVsAch.Location = reader["Location"].ToString();
                    oTargetVsAch.EmployeeName = reader["EmployeeName"].ToString();
                    oTargetVsAch.Position = reader["Position"].ToString();
                    oTargetVsAch.MobileNumber = reader["MobileNo"].ToString();
                    oTargetVsAch.DepartmentID = Convert.ToInt32(reader["DepartmentID"]);


                    InnerList.Add(oTargetVsAch);
                }
                reader.Close();
                InnerList.TrimToSize();
                //cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}

