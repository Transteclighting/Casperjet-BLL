// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Sep 04, 2013
// Time :  12:52 AM
// Description: Class for Plan, Budget & Target.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;
using CJ.Class.Library;

namespace CJ.Class
{
    public class PlanBudgetTarget
    {

        private int _nPlanID;
        private int _nVersionNo;
        private int _nPlanType;
        private int _nSBUID;
        private int _nProductGroupType;
        private int _nProductGroupID;
        private int _nPeriodType;
        private DateTime _dPeriodDate;
        private int _nMarketScopeType;
        private int _nMarketGroupID;
        private int _nQty;
        private double _Turnover;
        private double _COGS;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nStage;

        /// <summary>
        /// Get set property for PlanID
        /// </summary>
        public int PlanID
        {
            get { return _nPlanID; }
            set { _nPlanID = value; }
        }
        /// <summary>
        /// Get set property for VersionNo
        /// </summary>
        public int VersionNo
        {
            get { return _nVersionNo; }
            set { _nVersionNo = value; }
        }
        /// <summary>
        /// Get set property for PlanType
        /// </summary>
        public int PlanType
        {
            get { return _nPlanType; }
            set { _nPlanType = value; }
        }
        /// <summary>
        /// Get set property for SBUID
        /// </summary>
        public int SBUID
        {
            get { return _nSBUID; }
            set { _nSBUID = value; }
        }
        /// <summary>
        /// Get set property for ProductGroupType
        /// </summary>
        public int ProductGroupType
        {
            get { return _nProductGroupType; }
            set { _nProductGroupType = value; }
        }
        /// <summary>
        /// Get set property for ProductGroupID
        /// </summary>
        public int ProductGroupID
        {
            get { return _nProductGroupID; }
            set { _nProductGroupID = value; }
        }
        /// <summary>
        /// Get set property for PeriodType
        /// </summary>
        public int PeriodType
        {
            get { return _nPeriodType; }
            set { _nPeriodType = value; }
        }
        /// <summary>
        /// Get set property for PeriodDate
        /// </summary>
        public DateTime PeriodDate
        {
            get { return _dPeriodDate; }
            set { _dPeriodDate = value; }
        }
        /// <summary>
        /// Get set property for MarketScopeType
        /// </summary>
        public int MarketScopeType
        {
            get { return _nMarketScopeType; }
            set { _nMarketScopeType = value; }
        }
        /// <summary>
        /// Get set property for MarketGroupID
        /// </summary>
        public int MarketGroupID
        {
            get { return _nMarketGroupID; }
            set { _nMarketGroupID = value; }
        }
        /// <summary>
        /// Get set property for Qty
        /// </summary>
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }
        /// <summary>
        /// Get set property for Turnover
        /// </summary>
        public double Turnover
        {
            get { return _Turnover; }
            set { _Turnover = value; }
        }
        /// <summary>
        /// Get set property for _COGS
        /// </summary>
        public double COGS
        {
            get { return _COGS; }
            set { _COGS = value; }
        }
        /// <summary>
        /// Get set property for CreateUserID
        /// </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }
        /// <summary>
        /// Get set property for CreateDate
        /// </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        /// <summary>
        /// Get set property for Stage
        /// </summary>
        public int Stage
        {
            get { return _nStage; }
            set { _nStage = value; }
        }

        private int _nProductID;
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        private string _sProductCode;
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }
        private string _sProductName;
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }

        private int _nASGID;
        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
        }
        private string _sASGName;
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }
        private string _sPGName;
        public string PGName
        {
            get { return _sPGName; }
            set { _sPGName = value; }
        }


        private int _nSale1;
        public int Sale1
        {
            get { return _nSale1; }
            set { _nSale1 = value; }
        }
        private int _nSale2;
        public int Sale2
        {
            get { return _nSale2; }
            set { _nSale2 = value; }
        }
        private int _nSale3;
        public int Sale3
        {
            get { return _nSale3; }
            set { _nSale3 = value; }
        }

        private int _nPlan1;
        public int Plan1
        {
            get { return _nPlan1; }
            set { _nPlan1 = value; }
        }
        private int _nPlan2;
        public int Plan2
        {
            get { return _nPlan2; }
            set { _nPlan2 = value; }
        }
        private int _nPlan3;
        public int Plan3
        {
            get { return _nPlan3; }
            set { _nPlan3 = value; }
        }


        private int _PPMSaleQty;
        public int PPMSaleQty
        {
            get { return _PPMSaleQty; }
            set { _PPMSaleQty = value; }
        }

        private int _PPMPlanQty;
        public int PPMPlanQty
        {
            get { return _PPMPlanQty; }
            set { _PPMPlanQty = value; }
        }

        private int _PMSaleQtyW1;
        public int PMSaleQtyW1
        {
            get { return _PMSaleQtyW1; }
            set { _PMSaleQtyW1 = value; }
        }

        private int _PMSaleQtyW2;
        public int PMSaleQtyW2
        {
            get { return _PMSaleQtyW2; }
            set { _PMSaleQtyW2 = value; }
        }

        private int _PMSaleQtyW3;
        public int PMSaleQtyW3
        {
            get { return _PMSaleQtyW3; }
            set { _PMSaleQtyW3 = value; }
        }

        private int _PMSaleQtyW4;
        public int PMSaleQtyW4
        {
            get { return _PMSaleQtyW4; }
            set { _PMSaleQtyW4 = value; }
        }

        private int _PMSaleQtyW5;
        public int PMSaleQtyW5
        {
            get { return _PMSaleQtyW5; }
            set { _PMSaleQtyW5 = value; }
        }


        private int _PMPlanQtyW1;
        public int PMPlanQtyW1
        {
            get { return _PMPlanQtyW1; }
            set { _PMPlanQtyW1 = value; }
        }

        private int _PMPlanQtyW2;
        public int PMPlanQtyW2
        {
            get { return _PMPlanQtyW2; }
            set { _PMPlanQtyW2 = value; }
        }

        private int _PMPlanQtyW3;
        public int PMPlanQtyW3
        {
            get { return _PMPlanQtyW3; }
            set { _PMPlanQtyW3 = value; }
        }

        private int _PMPlanQtyW4;
        public int PMPlanQtyW4
        {
            get { return _PMPlanQtyW4; }
            set { _PMPlanQtyW4 = value; }
        }

        private int _PMPlanQtyW5;
        public int PMPlanQtyW5
        {
            get { return _PMPlanQtyW5; }
            set { _PMPlanQtyW5 = value; }
        }


        private int _CMPlanQtyW1;
        public int CMPlanQtyW1
        {
            get { return _CMPlanQtyW1; }
            set { _CMPlanQtyW1 = value; }
        }

        private int _CMPlanQtyW2;
        public int CMPlanQtyW2
        {
            get { return _CMPlanQtyW2; }
            set { _CMPlanQtyW2 = value; }
        }

        private int _CMPlanQtyW3;
        public int CMPlanQtyW3
        {
            get { return _CMPlanQtyW3; }
            set { _CMPlanQtyW3 = value; }
        }

        private int _CMPlanQtyW4;
        public int CMPlanQtyW4
        {
            get { return _CMPlanQtyW4; }
            set { _CMPlanQtyW4 = value; }
        }

        private int _CMPlanQtyW5;
        public int CMPlanQtyW5
        {
            get { return _CMPlanQtyW5; }
            set { _CMPlanQtyW5 = value; }
        }

        private int _Revenue;
        public int Revenue
        {
            get { return _Revenue; }
            set { _Revenue = value; }
        }

        private int _RSPWithoutVAT;
        public int RSPWithoutVAT
        {
            get { return _RSPWithoutVAT; }
            set { _RSPWithoutVAT = value; }
        }

        private int _Revenue1;
        public int Revenue1
        {
            get { return _Revenue1; }
            set { _Revenue1 = value; }
        }

        private int _Revenue2;
        public int Revenue2
        {
            get { return _Revenue2; }
            set { _Revenue2 = value; }
        }

        private int _Revenue3;
        public int Revenue3
        {
            get { return _Revenue3; }
            set { _Revenue3 = value; }
        }

        public void Add()
        {
            int nMaxPlanBudgetTragetID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([PlanID]) FROM t_PlanBudgetTarget";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxPlanBudgetTragetID = 1;
                }
                else
                {
                    nMaxPlanBudgetTragetID = Convert.ToInt32(maxID) + 1;
                }
                _nPlanID = nMaxPlanBudgetTragetID;

                sSql = "INSERT INTO t_planbudgettarget (PlanID,VersionNo,PlanType,SBUID,ProductGroupType,ProductGroupID,PeriodType, " +
                       "PeriodDate,MarketScopeType,MarketGroupID,Qty,Turnover,COGS,CreateUserID,CreateDate,Stage)  " +
                       "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PlanID", _nPlanID);
                cmd.Parameters.AddWithValue("VersionNo", _nVersionNo);
                cmd.Parameters.AddWithValue("PlanType", _nPlanType);
                cmd.Parameters.AddWithValue("SBUID", _nSBUID);
                cmd.Parameters.AddWithValue("ProductGroupType", _nProductGroupType);
                cmd.Parameters.AddWithValue("ProductGroupID", _nProductGroupID);
                cmd.Parameters.AddWithValue("PeriodType", _nPeriodType);
                cmd.Parameters.AddWithValue("PeriodDate", _dPeriodDate);
                cmd.Parameters.AddWithValue("MarketScopeType", _nMarketScopeType);
                cmd.Parameters.AddWithValue("MarketGroupID", _nMarketGroupID);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("Turnover", null);
                cmd.Parameters.AddWithValue("COGS", null);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("Stage", _nStage);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Delete(int nStage, DateTime dPlanDate, int nProductGroupID, int nCustomerID)
        {

            TELLib oTELLib = new TELLib();
            DateTime FirstDayOfCM = oTELLib.FirstDayofMonth(dPlanDate);
            DateTime FirstDayOfNextM = FirstDayOfCM.AddMonths(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Delete from t_planbudgettarget Where Stage=? and PeriodDate Between '" + FirstDayOfCM + "' and '" + FirstDayOfNextM + "' " +
                "and PeriodDate < '" + FirstDayOfNextM + "' and ProductGroupID =? and MarketGroupID=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Stage", nStage);
                cmd.Parameters.AddWithValue("ProductGroupID", nProductGroupID);
                cmd.Parameters.AddWithValue("MarketGroupID", nCustomerID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetMaxStage(int nCustomerID, string sASGName, DateTime dFirstDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            DateTime dEndDate = dFirstDate.AddMonths(1);
            int nCount = 0;
            try
            {
                cmd.CommandText = "select Max(Stage)Stage from t_planbudgettarget a " +
                                "INNER JOIN (Select ProductID, ASGName from v_ProductDetails) Prod  " +
                                "ON a.ProductGroupID=Prod.ProductID Where MarketGroupID=? and ASGName='" + sASGName + "'   " +
                                "and PeriodDate Between '" + dFirstDate + "' and '" + dEndDate + "' and PeriodDate < '" + dEndDate + "'";

                cmd.Parameters.AddWithValue("MarketGroupID", nCustomerID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nStage = (int)reader["MarketGroupID"];

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
    public class PlanBudgetTargets : CollectionBase
    {

        public PlanBudgetTarget this[int i]
        {
            get { return (PlanBudgetTarget)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(PlanBudgetTarget oPlanBudgetTarget)
        {
            InnerList.Add(oPlanBudgetTarget);
        }
        
        public void Refresh(DateTime PlanDate, int nCustomerID, int nPGID)
        {
            TELLib oTELLib = new TELLib();

            DateTime FirstDayCM = oTELLib.FirstDayofMonth(PlanDate);
            DateTime FirstDayLLM = FirstDayCM.AddMonths(-2);
            DateTime FirstDayNextM = FirstDayCM.AddMonths(1);
            DateTime LastDayCM = oTELLib.LastDayofMonth(PlanDate);

            int month = Convert.ToInt32(FirstDayCM.ToString("MM"));
            string CMSYearMonth = FirstDayCM.ToString("yyyy") + Convert.ToString(Convert.ToInt32(FirstDayCM.ToString("MM")));
            string LMSYearMonth = FirstDayCM.AddMonths(-1).ToString("yyyy") + Convert.ToString(Convert.ToInt32(FirstDayCM.AddMonths(-1).ToString("MM")));
            string LLMSYearMonth = FirstDayCM.AddMonths(-2).ToString("yyyy") + Convert.ToString(Convert.ToInt32(FirstDayCM.AddMonths(-2).ToString("MM")));

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            #region SQL
            string sSql = "Select CurrentStage.ASGID,CurrentStage.ASGName,CurrentStage.Stage,IsNull(Sale1,0)Sale1,IsNull(Sale2,0)Sale2, " +
                        "IsNull(Sale3,0)Sale3,IsNull(Plan1,0)Plan1,IsNull(Plan2,0)Plan2,IsNull(Plan3,0)Plan3,IsNull(Revenue1,0)Revenue1, " +
                        "IsNull(Revenue2,0)Revenue2,IsNull(Revenue3,0)Revenue3 from  " +
                        "( " +
                        "Select a.ASGID,a.ASGName,IsNull(Stage,0)Stage from  " +
                        "(Select distinct ASGID, ASGName from v_productdetails Where PGID=" + nPGID + ") a " +
                        "left outer JOIN " +
                        "( " +
                        "select ASGID, max(stage) Stage from t_PlanBudgetTarget x,  " +
                        "(Select ProductID, ASGID, ASGName From v_ProductDetails Where PGID=" + nPGID + ") y    " +
                        "Where  x.ProductGroupID=y.ProductID and   " +
                        "SBUID=2 and VersionNo Between 11 and 14   " +
                        "and PeriodDate Between '" + FirstDayCM + "' and '" + FirstDayNextM + "' and PeriodDate < '" + FirstDayNextM + "' and marketgroupid=" + nCustomerID + "  " +
                        "group by ASGID " +
                        ")Stage " +
                        "ON Stage.ASGID=a.ASGID " +
                        ")CurrentStage " +
                        "Left outer JOIN " +
                        "( " +
                        "Select  ASGID,  " +
                        "Sum(case YearMonth when '" + CMSYearMonth + "' then SaleQty  else 0 end) as Sale1,   " +
                        "Sum(case YearMonth when '" + LMSYearMonth + "' then SaleQty  else 0 end) as Sale2,  " +
                        "Sum(case YearMonth when '" + LLMSYearMonth + "' then SaleQty  else 0 end) as Sale3, " +
                        "Sum(case YearMonth when '" + CMSYearMonth + "' then PlanQty  else 0 end) as Plan1,  " +
                        "Sum(case YearMonth when '" + LMSYearMonth + "' then PlanQty  else 0 end) as Plan2, " +
                        "Sum(case YearMonth when '" + LLMSYearMonth + "' then PlanQty  else 0 end) as Plan3,   " +
                        "Sum(case YearMonth when '" + CMSYearMonth + "' then Revenue  else 0 end) as Revenue1,   " +
                        "Sum(case YearMonth when '" + LMSYearMonth + "' then Revenue  else 0 end) as Revenue2,  " +
                        "Sum(case YearMonth when '" + LLMSYearMonth + "' then Revenue  else 0 end) as Revenue3   " +
                        "from (   " +
                        "Select YearMonth, ASGID,Sum(SaleQty)SaleQty,Sum(PlanQty)PlanQty,Sum(Stage)Stage,Revenue from  " +
                        "( " +
                        "Select (Convert(varchar,MaxStage.YearID)+ Convert(varchar,MaxStage.MOnthNo))YearMonth,Revenue,MaxStage.ASGID,0 as SaleQty, PlanQty,MaxStage.Stage from  " +
                        "( " +
                        "select Year(PeriodDate)YearID, Month(PeriodDate)MonthNo,ASGID, max(stage) Stage from t_PlanBudgetTarget x,  " +
                        "(Select ProductID, ASGID, ASGName From v_ProductDetails Where PGID=" + nPGID + ") y    " +
                        "Where  x.ProductGroupID=y.ProductID and   " +
                        "SBUID=2 and VersionNo Between 11 and 14   " +
                        "and PeriodDate Between '" + FirstDayLLM + "' and '" + FirstDayNextM + "' and PeriodDate < '" + FirstDayNextM + "' and marketgroupid=" + nCustomerID + "  " +
                        "group by Year(PeriodDate), Month(PeriodDate),ASGID " +
                        ")MaxStage " +
                        "INNER JOIN " +
                        "( " +
                        "Select YearID, MonthNo,ASGID,Stage,Sum(PlanQty)PlanQty,Sum(Revenue)Revenue " +
                        "From " +
                        "( " +
                        "select Year(PeriodDate)YearID, Month(PeriodDate)MonthNo,ASGID,Stage,IsNull(Qty,0) as PlanQty,  " +
                        "(IsNull(Qty,0)*Revenue)Revenue from t_PlanBudgetTarget x,  " +
                        "(Select ProductID, ASGID, ASGName, (RSP-RSP*VAT)Revenue From v_ProductDetails Where PGID= " + nPGID + ") y " +
                        "Where  x.ProductGroupID=y.ProductID and SBUID=2 and VersionNo Between 11 and 14   " +
                        "and PeriodDate Between '" + FirstDayLLM + "' and '" + FirstDayNextM + "' and PeriodDate < '" + FirstDayNextM + "' and marketgroupid= " + nCustomerID + " " +
                        ")x " +
                        "group by YearID, MonthNo,ASGID,Stage " +
                        ")PlanQty " +
                        "ON MaxStage.YearID=PlanQty.YearID and MaxStage.MonthNo=PlanQty.MonthNo and MaxStage.ASGID=PlanQty.ASGID  " +
                        "and MaxStage.Stage=PlanQty.Stage " +
                        "UNION ALL " +
                        "select YearMonth,0 as Revenue,ASGID, Sum(SaleQty)SaleQty, 0 as PlanQty, 0 as Stage  " +
                        "from (   " +
                        "select YearMonth,ProductID,isnull((sum(CRQty)- sum(DRQty)),0) as SaleQty  " +
                        "from(   " +
                        "Select (Convert(varchar,YearID)+ Convert(varchar,MOnthNo))YearMonth, ProductID,CRQty,DRQty from (  " +
                        "select Year(InvoiceDate)YearID, Month(InvoiceDate)MonthNo,ProductID,Sum(Quantity) as CRQty, 0 as DRQty  " +
                        "from t_salesinvoice sa, t_salesinvoicedetail sd " +
                        "where sa.invoiceid = sd.invoiceid and invoicedate " +
                        "between '" + FirstDayLLM + "' and '" + FirstDayNextM + "' and invoicedate < '" + FirstDayNextM + "'    " +
                        "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3) and CustomerID= " + nCustomerID + " " +
                        "Group by Year(InvoiceDate),Month(InvoiceDate),ProductID  " +
                        ")CR  " +
                        "UNION  " +
                        "Select (Convert(varchar,YearID)+ Convert(varchar,MOnthNo))YearMonth, ProductID,CRQty,DRQty from (  " +
                        "select Year(InvoiceDate)YearID, Month(InvoiceDate)MonthNo,ProductID,0 as CRQty, Sum(Quantity) as DRQty  " +
                        "from t_salesinvoice sa, t_salesinvoicedetail sd " +
                        "where sa.invoiceid = sd.invoiceid and invoicedate  " +
                        "between '" + FirstDayLLM + "' and '" + FirstDayNextM + "' and invoicedate < '" + FirstDayNextM + "' " +
                        "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3) and CustomerID= " + nCustomerID + " " +
                        "Group by Year(InvoiceDate),Month(InvoiceDate),ProductID  " +
                        ")DR  " +
                        ")a  " +
                        "Group by YearMonth,ProductID    " +
                        ")x INNER JOIN (SElect Distinct ProductID, ASGID from v_ProductDetails Where PGID= " + nPGID + " )pd  " +
                        "ON PD.ProductID=x.ProductID  " +
                        "Group by YearMonth,ASGID " +
                        ") final Group by YearMonth, ASGID ,Revenue " +
                        ")x Group by  ASGID " +
                        ")Rpt " +
                        "ON Rpt.ASGID=CurrentStage.ASGID ";

            cmd.CommandTimeout = 0;
            #endregion
            #region SQL1
            //string sSql = "Select CurrentStage.ASGID,CurrentStage.ASGName,CurrentStage.Stage,IsNull(Sale1,0)Sale1,IsNull(Sale2,0)Sale2, " +
            //            "IsNull(Sale3,0)Sale3,IsNull(Plan1,0)Plan1,IsNull(Plan2,0)Plan2,IsNull(Plan3,0)Plan3 from  " +
            //            "( " +
            //            "Select a.ASGID,a.ASGName,IsNull(Stage,0)Stage from  " +
            //            "(Select distinct ASGID, ASGName from v_productdetails Where PGID=" + nPGID + ") a " +
            //            "left outer JOIN " +
            //            "( " +
            //            "select ASGID, max(stage) Stage from t_PlanBudgetTarget x,  " +
            //            "(Select ProductID, ASGID, ASGName From v_ProductDetails Where PGID=" + nPGID + ") y    " +
            //            "Where  x.ProductGroupID=y.ProductID and   " +
            //            "SBUID=2 and VersionNo Between 11 and 14   " +
            //            "and PeriodDate Between '" + FirstDayCM + "' and '" + FirstDayNextM + "' and PeriodDate < '" + FirstDayNextM + "' and marketgroupid=" + nCustomerID + "  " +
            //            "group by ASGID " +
            //            ")Stage " +
            //            "ON Stage.ASGID=a.ASGID " +
            //            ")CurrentStage " +
            //            "Left outer JOIN " +
            //            "( " +
            //            "Select  ASGID,  " +
            //            "Sum(case YearMonth when '" + CMSYearMonth + "' then SaleQty  else 0 end) as Sale1,   " +
            //            "Sum(case YearMonth when '" + LMSYearMonth + "' then SaleQty  else 0 end) as Sale2,  " +
            //            "Sum(case YearMonth when '" + LLMSYearMonth + "' then SaleQty  else 0 end) as Sale3, " +
            //            "Sum(case YearMonth when '" + CMSYearMonth + "' then PlanQty  else 0 end) as Plan1,  " +
            //            "Sum(case YearMonth when '" + LMSYearMonth + "' then PlanQty  else 0 end) as Plan2, " +
            //            "Sum(case YearMonth when '" + LLMSYearMonth + "' then PlanQty  else 0 end) as Plan3   " +
            //            "from (   " +
            //            "Select YearMonth, ASGID,Sum(SaleQty)SaleQty,Sum(PlanQty)PlanQty,Sum(Stage)Stage from  " +
            //            "( " +
            //            "Select (Convert(varchar,MaxStage.YearID)+ Convert(varchar,MaxStage.MOnthNo))YearMonth,MaxStage.ASGID,0 as SaleQty, PlanQty,MaxStage.Stage from  " +
            //            "( " +
            //            "select Year(PeriodDate)YearID, Month(PeriodDate)MonthNo,ASGID, max(stage) Stage from t_PlanBudgetTarget x,  " +
            //            "(Select ProductID, ASGID, ASGName From v_ProductDetails Where PGID=" + nPGID + ") y    " +
            //            "Where  x.ProductGroupID=y.ProductID and   " +
            //            "SBUID=2 and VersionNo Between 11 and 14   " +
            //            "and PeriodDate Between '" + FirstDayLLM + "' and '" + FirstDayNextM + "' and PeriodDate < '" + FirstDayNextM + "' and marketgroupid=" + nCustomerID + "  " +
            //            "group by Year(PeriodDate), Month(PeriodDate),ASGID " +
            //            ")MaxStage " +
            //            "INNER JOIN " +
            //            "( " +
            //            "select Year(PeriodDate)YearID, Month(PeriodDate)MonthNo,ASGID, Sum(Qty) as PlanQty, Stage from t_PlanBudgetTarget x,  " +
            //            "(Select ProductID, ASGID, ASGName From v_ProductDetails Where PGID=" + nPGID + ") y    " +
            //            "Where  x.ProductGroupID=y.ProductID and   " +
            //            "SBUID=2 and VersionNo Between 11 and 14   " +
            //            "and PeriodDate Between '" + FirstDayLLM + "' and '" + FirstDayNextM + "' and PeriodDate < '" + FirstDayNextM + "' and marketgroupid=" + nCustomerID + "  " +
            //            "group by Year(PeriodDate), Month(PeriodDate),ASGID,Stage " +
            //            ")PlanQty " +
            //            "ON MaxStage.YearID=PlanQty.YearID and MaxStage.MonthNo=PlanQty.MonthNo and MaxStage.ASGID=PlanQty.ASGID  " +
            //            "and MaxStage.Stage=PlanQty.Stage " +
            //            "UNION ALL " +
            //            "select YearMonth,ASGID, Sum(SaleQty)SaleQty, 0 as PlanQty, 0 as Stage  " +
            //            "from (   " +
            //            "select YearMonth,ProductID,isnull((sum(CRQty)- sum(DRQty)),0) as SaleQty  " +
            //            "from(   " +
            //            "Select (Convert(varchar,YearID)+ Convert(varchar,MOnthNo))YearMonth, ProductID,CRQty,DRQty from (  " +
            //            "select Year(InvoiceDate)YearID, Month(InvoiceDate)MonthNo,ProductID,Sum(Quantity) as CRQty, 0 as DRQty  " +
            //            "from t_salesinvoice sa, t_salesinvoicedetail sd " +
            //            "where sa.invoiceid = sd.invoiceid and invoicedate " +
            //            "between '" + FirstDayLLM + "' and '" + FirstDayNextM + "' and invoicedate < '" + FirstDayNextM + "'    " +
            //            "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3) and CustomerID= " + nCustomerID + " " +
            //            "Group by Year(InvoiceDate),Month(InvoiceDate),ProductID  " +
            //            ")CR  " +
            //            "UNION  " +
            //            "Select (Convert(varchar,YearID)+ Convert(varchar,MOnthNo))YearMonth, ProductID,CRQty,DRQty from (  " +
            //            "select Year(InvoiceDate)YearID, Month(InvoiceDate)MonthNo,ProductID,0 as CRQty, Sum(Quantity) as DRQty  " +
            //            "from t_salesinvoice sa, t_salesinvoicedetail sd " +
            //            "where sa.invoiceid = sd.invoiceid and invoicedate  " +
            //            "between '" + FirstDayLLM + "' and '" + FirstDayNextM + "' and invoicedate < '" + FirstDayNextM + "' " +
            //            "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3) and CustomerID= " + nCustomerID + " " +
            //            "Group by Year(InvoiceDate),Month(InvoiceDate),ProductID  " +
            //            ")DR  " +
            //            ")a  " +
            //            "Group by YearMonth,ProductID    " +
            //            ")x INNER JOIN (SElect Distinct ProductID, ASGID from v_ProductDetails Where PGID= " + nPGID + " )pd  " +
            //            "ON PD.ProductID=x.ProductID  " +
            //            "Group by YearMonth,ASGID " +
            //            ") final Group by YearMonth, ASGID " +
            //            ")x Group by  ASGID " +
            //            ")Rpt " +
            //            "ON Rpt.ASGID=CurrentStage.ASGID ";
                       #endregion
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PlanBudgetTarget oPlanBudgetTarget = new PlanBudgetTarget();

                    oPlanBudgetTarget.ASGID = int.Parse(reader["ASGID"].ToString());
                    oPlanBudgetTarget.ASGName = (string)reader["ASGName"];

                    oPlanBudgetTarget.Sale1 = int.Parse(reader["Sale1"].ToString());
                    oPlanBudgetTarget.Sale2 = int.Parse(reader["Sale2"].ToString());
                    oPlanBudgetTarget.Sale3 = int.Parse(reader["Sale3"].ToString());
                    oPlanBudgetTarget.Plan1 = int.Parse(reader["Plan1"].ToString());
                    oPlanBudgetTarget.Plan2 = int.Parse(reader["Plan2"].ToString());
                    oPlanBudgetTarget.Plan3 = int.Parse(reader["Plan3"].ToString());
                    oPlanBudgetTarget.Stage = int.Parse(reader["Stage"].ToString());

                    oPlanBudgetTarget.Revenue1 = Convert.ToInt32(reader["Revenue1"]);
                    oPlanBudgetTarget.Revenue2 = Convert.ToInt32(reader["Revenue2"]);
                    oPlanBudgetTarget.Revenue3 = Convert.ToInt32(reader["Revenue3"]);

                    InnerList.Add(oPlanBudgetTarget);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }       
        public void RefreshSKU(DateTime PlanDate, int nCustomerID, string sASG)
        {
            TELLib oTELLib = new TELLib();
            DateTime FirstDayLM = oTELLib.FirstDayofLastMonth(PlanDate);
            DateTime FirstDayLLM = FirstDayLM.AddMonths(-1);

            DateTime FirstDayCM = oTELLib.FirstDayofMonth(PlanDate);
            DateTime FirstDayNextM = FirstDayCM.AddMonths(1);
            //DateTime LastDayCM = oTELLib.LastDayofMonth(PlanDate);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            #region SQL
            string sSqls = "Select Portfolio.ProductID,ProductCode,ProductName, " +
            "IsNull(MonthltSaleQty,0)MonthltSaleQty, IsNull(MontylyPlanQty,0)MontylyPlanQty, " +
            "IsNull(SW1,0)SW1,IsNull(SW2,0)SW2,IsNull(SW3,0)SW3,IsNull(SW4,0)SW4,IsNull(SW5,0)SW5, " +
            "IsNull(PPQW1,0)PPQW1, IsNull(PPQW2,0)PPQW2,IsNull(PPQW3,0)PPQW3,IsNull(PPQW4,0)PPQW4,IsNull(PPQW5,0)PPQW5, " +
            "IsNull(PMQW1,0)PMQW1,IsNull(PMQW2,0)PMQW2, IsNull(PMQW3,0)PMQW3, IsNull(PMQW4,0)PMQW4, IsNull(PMQW5,0)PMQW5, " +
            "((IsNull(PMQW1,0)+IsNull(PMQW2,0)+ IsNull(PMQW3,0)+ IsNull(PMQW4,0)+ IsNull(PMQW5,0))*RSPWithoutVAT)Revenue,RSPWithoutVAT  " +
            "from  " +

            "(Select a.ProductID, ProductCode,ProductName,round((IsNull(RSP,0)-IsNull(RSP,0)*IsNull(VAT,0)),0)RSPWithoutVAT  " +
            "from t_TDProductPortfolio a, (Select ProductID,ProductCode,ProductName,ASGID,RSP,VAT,  " +
            "ASGName From v_ProductDetails Where ASGname='" + sASG + "') b " +
            "Where a.ProductID=b.ProductID and IsActive=1 and CustomerID=" + nCustomerID + ")Portfolio " +
            "Left Outer JOIN " +
            "( " +
            "Select ProductID, Sum(MonthltSaleQty)MonthltSaleQty, Sum(MontylyPlanQty)MontylyPlanQty, " +
            "Sum(SW1)SW1,Sum(SW2)SW2,Sum(SW3)SW3,Sum(SW4)SW4,Sum(SW5)SW5, " +
            "Sum(PPQW1)PPQW1, Sum(PPQW2)PPQW2,Sum(PPQW3)PPQW3,Sum(PPQW4)PPQW4,Sum(PPQW5)PPQW5, " +
            "Sum(PMQW1)PMQW1,Sum(PMQW2)PMQW2, Sum(PMQW3)PMQW3, Sum(PMQW4)PMQW4, Sum(PMQW5)PMQW5 " +
            "From " +
            "( " +
            "Select ProductID, Sum(MonthSaleQty) as MonthltSaleQty, Sum(PlanQty) as MontylyPlanQty, " +
            "0 as SW1,0 as SW2,0 as SW3,0 as SW4,0 as SW5, " +
            "0 as PPQW1, 0 as PPQW2,0 as PPQW3,0 as PPQW4, 0 as PPQW5,  " +
            "0 as PMQW1,0 as PMQW2,0 as PMQW3,0 as PMQW4, 0 as PMQW5 " +
            "from  " +
            "( " +
            "select ProductID,isnull((sum(CRQty)- sum(DRQty)),0) as MonthSaleQty, 0 as PlanQty " +
            "from(  " +
            "Select ProductID,CRQty,DRQty from ( " +
            "select ProductID, Sum(Quantity) as CRQty, 0 as DRQty " +
            "from t_salesinvoice sa, t_salesinvoicedetail sd    " +
            "where sa.invoiceid = sd.invoiceid and invoicedate     " +
            "between '" + FirstDayLLM + "' and '" + FirstDayLM + "' and invoicedate < '" + FirstDayLM + "'   " +
            "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3) and CustomerID= "+ nCustomerID + "  " +
            "Group by ProductID " +
            ")CR " +
            "UNION ALL " +
            "Select ProductID,CRQty,DRQty from ( " +
            "select ProductID,0 as CRQty, Sum(Quantity) as DRQty " +
            "from t_salesinvoice sa, t_salesinvoicedetail sd    " +
            "where sa.invoiceid = sd.invoiceid and invoicedate     " +
            "between '" + FirstDayLLM + "' and '" + FirstDayLM + "' and invoicedate < '" + FirstDayLM + "'   " +
            "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3) and CustomerID= " + nCustomerID + "   " +
            "Group by ProductID " +
            ")DR " +
            ")a " +
            "Group by ProductID " +
            "UNION ALL " +
            "Select ProductGroupID as ProductID, 0 as MonthSaleQty, Qty as PlanQty from  " +
            "( " +
            "Select Max(Stage)Stage from dbo.t_PlanBudgetTarget Where PeriodDate  " +
            "Between '" + FirstDayLLM + "' and '" + FirstDayLM + "' and PeriodDate < '" + FirstDayLM + "' and MarketGroupID=" + nCustomerID + " and VersionNo Between 11 and 14 " +
            ")Stage " +
            "INNER JOIN " +
            "( " +
            "select ProductGroupID, Qty, Stage from dbo.t_PlanBudgetTarget   " +
            "Where PeriodDate  " +
            "Between '" + FirstDayLLM + "' and '" + FirstDayLM + "' and PeriodDate < '" + FirstDayLM + "' and MarketGroupID=" + nCustomerID + " and VersionNo Between 11 and 14 " +
            ")TPlan " +
            "ON Stage.Stage=TPlan.Stage " +
            ")x group by ProductID " +
            "UNION ALL " +
                //-------Sale (Weekly)-------
            "Select ProductID, 0 as MonthltSaleQty,0 as MontylyPlanQty, SW1,SW2,SW3,SW4,SW5, 0 as PPQW1, 0 as PPQW2,0 as PPQW3,0 as PPQW4, 0 as PPQW5,  " +
            "0 as PMQW1,0 as PMQW2,0 as PMQW3,0 as PMQW4, 0 as PMQW5 " +
            "From  " +
            "( " +
            "Select ProductID,  " +
            "Sum(case WeekName when 'Week1' then SaleQty  else 0 end) as SW1,  " +
            "Sum(case WeekName when 'Week2' then SaleQty  else 0 end) as SW2,  " +
            "Sum(case WeekName when 'Week3' then SaleQty  else 0 end) as SW3,  " +
            "Sum(case WeekName when 'Week4' then SaleQty  else 0 end) as SW4,  " +
            "Sum(case WeekName when 'Week5' then SaleQty  else 0 end) as SW5   " +
            "from  " +
            "(  " +
            "Select ProductID,WeekName, Sum(SaleQty)SaleQty from  " +
            "( " +
            "select InvoiceDate,ProductID,isnull((sum(CRQty)- sum(DRQty)),0) as SaleQty " +
            "from(  " +
            "Select InvoiceDate,ProductID,CRQty,DRQty from ( " +
            "select Convert(datetime,replace(convert(varchar, InvoiceDate,6),'','-'),1)InvoiceDate, " +
            "ProductID, Sum(Quantity) as CRQty, 0 as DRQty " +
            "from t_salesinvoice sa, t_salesinvoicedetail sd  " +
            "where sa.invoiceid = sd.invoiceid and invoicedate   " +
            "between '" + FirstDayLM + "' and '" + FirstDayCM + "' and invoicedate < '" + FirstDayCM + "'   " +
            "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3) and CustomerID= "+ nCustomerID +"  " +
            "Group by InvoiceDate,ProductID " +
            ")CR " +
            "UNION ALL " +
            "Select InvoiceDate,ProductID, CRQty,DRQty from ( " +
            "select Convert(datetime,replace(convert(varchar, InvoiceDate,6),'','-'),1)InvoiceDate, " +
            "ProductID,0 as CRQty, Sum(Quantity) as DRQty " +
            "from t_salesinvoice sa, t_salesinvoicedetail sd " +
            "where sa.invoiceid = sd.invoiceid and invoicedate  " +
            "between '" + FirstDayLM + "' and '" + FirstDayCM + "' and invoicedate < '" + FirstDayCM + "'   " +
            "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3) and CustomerID= " + nCustomerID + "   " +
            "Group by InvoiceDate,ProductID " +
            ")DR " +
            ")a " +
            "Group by InvoiceDate,ProductID " +
            ") Sales , t_TDSalesPlanCalendar Where Sales.InvoiceDate between FromDate and ToDate " +
            "Group by ProductID,WeekName " +
            ")x Group by ProductID " +
            ")a " +
            "UNION ALL " +
            "Select ProductID, 0 as MonthltSaleQty,0 as MontylyPlanQty, 0 as SW1,0 as SW2,0 as SW3,0 as SW4,0 as SW5, " +
            "PPQW1, PPQW2,PPQW3,PPQW4,PPQW5, 0 as PMQW1,0 as PMQW2,0 as PMQW3,0 as PMQW4, 0 as PMQW5 " +
            "From  " +
            "( " +
            "Select ProductID,  " +
            "Sum(case WeekName when 'Week1' then PlanQty  else 0 end) as PPQW1,  " +
            "Sum(case WeekName when 'Week2' then PlanQty  else 0 end) as PPQW2,  " +
            "Sum(case WeekName when 'Week3' then PlanQty  else 0 end) as PPQW3,  " +
            "Sum(case WeekName when 'Week4' then PlanQty  else 0 end) as PPQW4,  " +
            "Sum(case WeekName when 'Week5' then PlanQty  else 0 end) as PPQW5   " +
            "from  " +
            "( " +
            "Select WeekName,ProductGroupID as ProductID, Qty as PlanQty from  " +
            "( " +
            "Select Max(Stage)Stage from dbo.t_PlanBudgetTarget Where PeriodDate  " +
            "Between '" + FirstDayLM + "' and '" + FirstDayCM + "' and PeriodDate < '" + FirstDayCM + "' and MarketGroupID=" + nCustomerID + " and VersionNo Between 11 and 14 " +
            ")Stage " +
            "INNER JOIN " +
            "( " +
            "select ProductGroupID, Qty, Stage, WeekName from dbo.t_PlanBudgetTarget a ,  t_TDSalesPlanCalendar b " +
            "Where PeriodDate between FromDate and ToDate and PeriodDate Between '" + FirstDayLM + "' and '" + FirstDayCM + "' and " +
            "PeriodDate < '" + FirstDayCM + "' and MarketGroupID=" + nCustomerID + " and VersionNo Between 11 and 14 " +
            ")TPlan " +
            "ON Stage.Stage=TPlan.Stage " +
            ")x Group by ProductID " +
            ")a " +
            "UNION ALL " +

            //-------------Plan Month-------------

            "Select ProductID, 0 as MonthltSaleQty,0 as MontylyPlanQty, 0 as SW1,0 as SW2,0 as SW3,0 as SW4,0 as SW5, " +
            "0 as PPQW1, 0 as PPQW2,0 as PPQW3,0 as PPQW4, 0 as PPQW5, PMQW1,PMQW2,PMQW3,PMQW4,PMQW5 " +
            "from  " +
            "( " +
            "Select ProductID,  " +
            "Sum(case WeekName when 'Week1' then PlanQty  else 0 end) as PMQW1,  " +
            "Sum(case WeekName when 'Week2' then PlanQty  else 0 end) as PMQW2,  " +
            "Sum(case WeekName when 'Week3' then PlanQty  else 0 end) as PMQW3,  " +
            "Sum(case WeekName when 'Week4' then PlanQty  else 0 end) as PMQW4,  " +
            "Sum(case WeekName when 'Week5' then PlanQty  else 0 end) as PMQW5   " +
            "from  " +
            "( " +
            "Select WeekName,Stage.ProductGroupID as ProductID, Qty as PlanQty from  " +
            "( " +
            "Select ProductGroupID, Max(Stage)Stage from dbo.t_PlanBudgetTarget Where PeriodDate  " +
            "Between '" + FirstDayCM + "' and '" + FirstDayNextM + "' and PeriodDate < '" + FirstDayNextM + "' and MarketGroupID=" + nCustomerID + " and VersionNo Between 11 and 14 " +
            "Group by ProductGroupID "+
            ")Stage " +
            "INNER JOIN " +
            "( " +
            "select ProductGroupID, Qty, Stage, WeekName from dbo.t_PlanBudgetTarget a ,  t_TDSalesPlanCalendar b " +
            "Where PeriodDate between FromDate and ToDate and PeriodDate  " +
            "Between '" + FirstDayCM + "' and '" + FirstDayNextM + "' and PeriodDate < '" + FirstDayNextM + "' and MarketGroupID=" + nCustomerID + " and VersionNo Between 11 and 14 " +
            ")TPlan " +
            "ON Stage.Stage=TPlan.Stage and Stage.ProductGroupID=TPlan.ProductGroupID " +
            ")x Group by ProductID " +
            ")a " +
            ")a Group by ProductID " +
            ")Detail " +
            "ON Detail.ProductID=Portfolio.ProductID ";

            cmd.CommandTimeout = 0;

            #endregion
            try
            {
                cmd.CommandText = sSqls;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PlanBudgetTarget oPlanBudgetTarget = new PlanBudgetTarget();

                    oPlanBudgetTarget.ProductID = int.Parse(reader["ProductID"].ToString());
                    oPlanBudgetTarget.ProductCode = (string)reader["ProductCode"];
                    oPlanBudgetTarget.ProductName = (string)reader["ProductName"];


                    oPlanBudgetTarget.PPMSaleQty = int.Parse(reader["MonthltSaleQty"].ToString());
                    oPlanBudgetTarget.PPMPlanQty = int.Parse(reader["MontylyPlanQty"].ToString());

                    oPlanBudgetTarget.PMSaleQtyW1 = int.Parse(reader["SW1"].ToString());
                    oPlanBudgetTarget.PMSaleQtyW2 = int.Parse(reader["SW2"].ToString());
                    oPlanBudgetTarget.PMSaleQtyW3 = int.Parse(reader["SW3"].ToString());
                    oPlanBudgetTarget.PMSaleQtyW4 = int.Parse(reader["SW4"].ToString());
                    oPlanBudgetTarget.PMSaleQtyW5 = int.Parse(reader["SW5"].ToString());


                    oPlanBudgetTarget.PMPlanQtyW1 = int.Parse(reader["PPQW1"].ToString());
                    oPlanBudgetTarget.PMPlanQtyW2 = int.Parse(reader["PPQW2"].ToString());
                    oPlanBudgetTarget.PMPlanQtyW3 = int.Parse(reader["PPQW3"].ToString());
                    oPlanBudgetTarget.PMPlanQtyW4 = int.Parse(reader["PPQW4"].ToString());
                    oPlanBudgetTarget.PMPlanQtyW5 = int.Parse(reader["PPQW5"].ToString());


                    oPlanBudgetTarget.CMPlanQtyW1 = int.Parse(reader["PMQW1"].ToString());
                    oPlanBudgetTarget.CMPlanQtyW2 = int.Parse(reader["PMQW2"].ToString());
                    oPlanBudgetTarget.CMPlanQtyW3 = int.Parse(reader["PMQW3"].ToString());
                    oPlanBudgetTarget.CMPlanQtyW4 = int.Parse(reader["PMQW4"].ToString());
                    oPlanBudgetTarget.CMPlanQtyW5 = int.Parse(reader["PMQW5"].ToString());

                    oPlanBudgetTarget.Revenue = int.Parse(reader["Revenue"].ToString());
                    oPlanBudgetTarget.RSPWithoutVAT = int.Parse(reader["RSPWithoutVAT"].ToString());


                    InnerList.Add(oPlanBudgetTarget);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetProductID(DateTime PlanDate, int nCustomerID, string sASG, int nStage)
        {
            TELLib oTELLib = new TELLib();
            DateTime FirstDayCM = oTELLib.FirstDayofMonth(PlanDate);
            DateTime FirstDayNextM = FirstDayCM.AddMonths(1);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            #region SQL
            string sSql = "Select ProductGroupID from t_planbudgettarget a INNER JOIN (Select ProductID,ASGName from v_ProductDetails) as b "+
                            "ON a.ProductGroupID=b.ProductID Where Stage=" + nStage + " and periodDate  " +
                            "Between '" + FirstDayCM + "' and '" + FirstDayNextM + "' and PeriodDate < '" + FirstDayNextM + "' and  " +
                            "ASGName='" + sASG + "' and MarketGroupID=" + nCustomerID + " Group by ProductGroupID ";
            #endregion
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PlanBudgetTarget oPlanBudgetTarget = new PlanBudgetTarget();

                    oPlanBudgetTarget.ProductGroupID = int.Parse(reader["ProductGroupID"].ToString());

                    InnerList.Add(oPlanBudgetTarget);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshASGLevel(DateTime dFirstDate, int nCustomerID, int nStage, string sASGName)
        {
            TELLib oTELLib = new TELLib();

            DateTime dEndDate = dFirstDate.AddMonths(1);
           
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select ProductGroupID,PeriodDate,MarketGroupID, Qty,CreateUserID,Stage, ASGName from t_planbudgettarget a " +
                            "INNER JOIN (Select ProductID, ASGName from v_ProductDetails) Prod " +
                            "ON a.ProductGroupID=Prod.ProductID Where MarketGroupID=? and Stage=? and ASGName='" + sASGName + "'  " +
                            "and PeriodDate Between '" + dFirstDate + "' and '" + dEndDate + "' and PeriodDate < '" + dEndDate + "' ";

            cmd.Parameters.AddWithValue("MarketGroupID", nCustomerID);
            cmd.Parameters.AddWithValue("Stage", nStage);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PlanBudgetTarget oPlanBudgetTarget = new PlanBudgetTarget();

                    oPlanBudgetTarget.ProductGroupID = int.Parse(reader["ProductGroupID"].ToString());
                    oPlanBudgetTarget.PeriodDate = Convert.ToDateTime(reader["PeriodDate"].ToString());
                    oPlanBudgetTarget.MarketGroupID = int.Parse(reader["MarketGroupID"].ToString());
                    oPlanBudgetTarget.Qty = int.Parse(reader["Qty"].ToString());

                    InnerList.Add(oPlanBudgetTarget);
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

