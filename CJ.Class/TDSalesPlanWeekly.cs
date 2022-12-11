// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Sep 2, 2013
// Time :  10:58 AM
// Description: Class for TD Sales Plan (Revised).
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

using CJ.Class.Library;

namespace CJ.Class
{

    public class TDSalesPlanWeekly
    {
        private int _nTDSalesPlanID;
        private string _sCode;
        private int _nCustomerID;
        private int _nASGID;
        private int _nSalesPersonelID;
        private int _nPlanMonth;
        private int _nPlanYear;
        private int _nQuantity;
        private int _nIsPlanned;
        private int _nStage;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private bool _bFlag;

        /// <summary>
        /// Get set property for TDSalesPlanID
        /// </summary>
        public int TDSalesPlanID
        {
            get { return _nTDSalesPlanID; }
            set { _nTDSalesPlanID = value; }
        }
        /// <summary>
        /// Get set property for Code
        /// </summary>
        public string Code
        {
            get { return _sCode; }
            set { _sCode = value.Trim(); }
        }
        /// <summary>
        /// Get set property for CustomerID
        /// </summary>
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        /// <summary>
        /// Get set property for ASGID
        /// </summary>
        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
        }
        /// <summary>
        /// Get set property for SalesPersonelID
        /// </summary>
        public int SalesPersonelID
        {
            get { return _nSalesPersonelID; }
            set { _nSalesPersonelID = value; }
        }
        /// <summary>
        /// Get set property for PlanMonth
        /// </summary>
        public int PlanMonth
        {
            get { return _nPlanMonth; }
            set { _nPlanMonth = value; }
        }
        /// <summary>
        /// Get set property for PlanYear
        /// </summary>
        public int PlanYear
        {
            get { return _nPlanYear; }
            set { _nPlanYear = value; }
        }
        /// <summary>
        /// Get set property for Quantity
        /// </summary>
        public int Quantity
        {
            get { return _nQuantity; }
            set { _nQuantity = value; }
        }
        /// <summary>
        /// Get set property for IsPlanned
        /// </summary>
        public int IsPlanned
        {
            get { return _nIsPlanned; }
            set { _nIsPlanned = value; }
        }
        /// <summary>
        /// Get set property for Status
        /// </summary>
        public int Stage
        {
            get { return _nStage; }
            set { _nStage = value; }
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
       
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }

        private string _sSalesPerson;
        public string SalesPerson
        {
            get { return _sSalesPerson; }
            set { _sSalesPerson = value; }
        }
        private string _sPGName;
        public string PGName
        {
            get { return _sPGName; }
            set { _sPGName = value; }
        }
        private string _sStatusName;
        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value; }
        }
        private string _sASGName;
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }
        private double _sASP;
        public double ASP
        {
            get { return _sASP; }
            set { _sASP = value; }
        }
        private string _sMonthName;
        public string MonthName
        {
            get { return _sMonthName; }
            set { _sMonthName = value; }
        }

        public void Add()
        {
            int nMaxSalesPlanID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TDSalesPlanID]) FROM t_TDSalesPlan";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSalesPlanID = 1;
                }
                else
                {
                    nMaxSalesPlanID = Convert.ToInt32(maxID) + 1;
                }
                _nTDSalesPlanID = nMaxSalesPlanID;

                sSql = "INSERT INTO t_TDSalesPlan (TDSalesPlanID,Code,CustomerID,ASGID,SalesPersonelID,PlanMonth, " +
                "PlanYear,Quantity,IsPlanned,Status,CreateUserID,CreateDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TDSalesPlanID", _nTDSalesPlanID);
                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("ASGID", _nASGID);
                cmd.Parameters.AddWithValue("SalesPersonelID", _nSalesPersonelID);
                cmd.Parameters.AddWithValue("PlanMonth", _nPlanMonth);
                cmd.Parameters.AddWithValue("PlanYear", _nPlanYear);
                cmd.Parameters.AddWithValue("Quantity", _nQuantity);
                cmd.Parameters.AddWithValue("IsPlanned", _nIsPlanned);
                cmd.Parameters.AddWithValue("Status", _nStage);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);


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
            //OleDbCommand cmd = DBController.Instance.GetCommand();
            //string sSql = "";

            //try
            //{

            //    sSql = "Update t_TDSalesPlan Set SalesPersonelID=?,PlanningMonth=?, " +
            //           "Week1=?,Week2=?,Week3=?,Week4=?,Week5=?,SubmittedBy=?,SubmitDate=? Where SalesPlanCode=? and ASGID=?";

            //    cmd.CommandText = sSql;
            //    cmd.CommandType = CommandType.Text;

            //    cmd.Parameters.AddWithValue("SalesPersonelID", _nSalesPersonelID);
            //    cmd.Parameters.AddWithValue("PlanningMonth", _dPlanningMonth);
            //    cmd.Parameters.AddWithValue("Week1", _nWeek1);
            //    cmd.Parameters.AddWithValue("Week2", _nWeek2);
            //    cmd.Parameters.AddWithValue("Week3", _nWeek3);
            //    cmd.Parameters.AddWithValue("Week4", _nWeek4);
            //    cmd.Parameters.AddWithValue("Week5", _nWeek5);
            //    cmd.Parameters.AddWithValue("SubmittedBy", Utility.UserId);
            //    cmd.Parameters.AddWithValue("SubmitDate", DateTime.Now);

            //    cmd.Parameters.AddWithValue("SalesPlanCode", _sSalesPlanCode);
            //    cmd.Parameters.AddWithValue("ASGID", _nASGID);

            //    cmd.ExecuteNonQuery();
            //    cmd.Dispose();

            //}
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}
        }
        public void GetPGIDByCode(string sSalesPlanCode)
        {
            //OleDbCommand cmd = DBController.Instance.GetCommand();
            //try
            //{
            //    cmd.CommandText = "SELECT Distinct PGID,SalesPersonelID FROM t_TDSalesPlan Where SalesPlanCode=?";
            //    cmd.Parameters.AddWithValue("SalesPlanCode", sSalesPlanCode);
            //    cmd.CommandType = CommandType.Text;
            //    IDataReader reader = cmd.ExecuteReader();
            //    if (reader.Read())
            //    {
            //        _nPGID = (int)reader["PGID"];
            //        _nSalesPersonelID = (int)reader["SalesPersonelID"];
            //    }

            //    reader.Close();
            //}
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}
        }
        public void GetStatus(string sSalesPlanCode)
        {
            //OleDbCommand cmd = DBController.Instance.GetCommand();
            //try
            //{
            //    cmd.CommandText = "SELECT Distinct Status FROM t_TDSalesPlan Where SalesPlanCode=?";
            //    cmd.Parameters.AddWithValue("SalesPlanCode", sSalesPlanCode);
            //    cmd.CommandType = CommandType.Text;
            //    IDataReader reader = cmd.ExecuteReader();
            //    if (reader.Read())
            //    {
            //        _nStatus = (int)reader["Status"];
            //    }

            //    reader.Close();
            //}
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}
        }
        public void CheckDuplicate()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_TDSalesPlan where PlanMonth =? and PlanYear=? and ASGID=?";
                cmd.Parameters.AddWithValue("PlanMonth", _nPlanMonth);
                cmd.Parameters.AddWithValue("PlanYear", _nPlanYear);
                cmd.Parameters.AddWithValue("ASGID", _nASGID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) Flag = false;
            else Flag = true;

        }
        public void UpdateStatus()
        {
            //OleDbCommand cmd = DBController.Instance.GetCommand();
            //string sSql = "";

            //try
            //{

            //    sSql = "Update t_TDSalesPlan Set Status=? Where SalesPlanCode=? ";

            //    cmd.CommandText = sSql;
            //    cmd.CommandType = CommandType.Text;

            //    cmd.Parameters.AddWithValue("Status", (int)Dictionary.YesOrNoStatus.YES);
            //    cmd.Parameters.AddWithValue("SalesPlanCode", _sSalesPlanCode);

            //    cmd.ExecuteNonQuery();
            //    cmd.Dispose();

            //}
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}
        }


    }
    public class TDSalesPlanWeeklys : CollectionBase
    {

        public TDSalesPlanWeekly this[int i]
        {
            get { return (TDSalesPlanWeekly)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public int GetIndexByID(int nTDSalesPlanWeekly)
        {
            int i = 0;
            foreach (TDSalesPlanWeekly oTDSalesPlanWeekly in this)
            {
                if (oTDSalesPlanWeekly.TDSalesPlanID == nTDSalesPlanWeekly)
                    return i;
                i++;
            }
            return -1;
        }
        public void Add(TDSalesPlanWeekly oTDSalesPlanWeekly)
        {
            InnerList.Add(oTDSalesPlanWeekly);
        }

        public void Refresh(DateTime PlanDate, int nCustomerID)
        {
            TELLib oTELLib = new TELLib();
            DateTime FirstDayLM = oTELLib.FirstDayofLastMonth(PlanDate);
            DateTime FirstDayLLM = oTELLib.FirstDayofLastMonth(FirstDayLM);
            DateTime FirstDayCM = oTELLib.FirstDayofMonth(PlanDate);
            DateTime FirstDayNextM = FirstDayCM.AddMonths(1);
            DateTime LastDayCM = oTELLib.LastDayofMonth(PlanDate);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //string sSql = "Select CustomerID, a.ASGID,ASGName, 0 as ASP, PGName,PlanYear, PlanMonth, PlanMonthName= CASE When PlanMonth=1 then 'Jan' " +
            //            "When PlanMonth=2 then 'Feb' When PlanMonth=3 then 'Mar' When PlanMonth=4 then 'Apr' When PlanMonth=5 then 'May' " +
            //            "When PlanMonth=6 then 'Jun' When PlanMonth=7 then 'Jul' When PlanMonth=8 then 'Aug' When PlanMonth=9 then 'Sep' " +
            //            "When PlanMonth=10 then 'Oct' When PlanMonth=11 then 'Nov' When PlanMonth=12 then 'Dec' end, Quantity, IsPlanned, Status from t_TDSalesPlan a,   " +
            //            "(Select Distinct ASGID, ASGName, PGID, PGName from v_productdetails Where PGID IN (1,4,6) and ASGID <> 78)b   " +
            //            "Where CustomerID=? and PGID=? and PlanYear=? and PlanMonth=? and a.ASGID=b.ASGID  ";

            string sSql = "Select CMPlan.ASGID,CMPlan.ASGName,CMPlan.PGName,CMPlan.MarketGroupID as CustomerID, CMPlan.Qty as CMPlanQty, " +
            "IsNull(LMPlan.Qty,0)LMPlan, IsNull(LLMPlan.Qty,0)LLMPlan, Stage, StageName, " +
            "LLMSalesQty,LLMSaleAmt,LMSalesQty,LMSaleAmt,CMSalesQty,CMSaleAmt " +
            "from ( " +
            "select a.MarketGroupID,Qty,a.Stage, StageName=CASE When a.Stage=1 Then 'Sales Executive' " +
            "When a.Stage=2 Then 'Outlet Manager' When a.Stage=3 Then 'Zonal Manager' When a.Stage=2 Then 'National Manager'  " +
            "else 'Others' end ,b.Asgid,b.asgname,b.pgname " +
            "from   " +
            "(select x.MarketGroupID,sum(Qty) qty,x.Stage,asgid  " +
            "from t_PlanBudgetTarget x,(Select ProductID, ASGID, ASGName, PGName From v_ProductDetails) y  " +
            "Where  x.ProductGroupID=y.ProductID group by x.MarketGroupID,x.Stage,asgid) a " +
            "inner join " +
            "(select marketgroupid,max(stage) stage,asgid,asgname,pgname from t_PlanBudgetTarget x,(Select ProductID, ASGID, ASGName, PGName From v_ProductDetails) y  " +
            "Where  x.ProductGroupID=y.ProductID and " +
            "SBUID=2 and VersionNo Between 11 and 14 " +
            "and PeriodDate Between '" + FirstDayCM + "' and '" + FirstDayNextM + "' and PeriodDate < '" + FirstDayNextM + "' " +
            "group by marketgroupid,asgid,asgname,pgname) b  " +
            "on (a.marketgroupid=b.marketgroupid and a.stage=b.stage and a.asgid=b.asgid)Where a.MarketGroupID=" + nCustomerID + "  " +
            ")CMPlan " +
            "Left Outer JOIN " +
            "(select a.MarketGroupID,Qty,b.Asgid,b.asgname,b.pgname " +
            "from   " +
            "(select x.MarketGroupID,sum(Qty) qty,x.Stage,asgid  " +
            "from t_PlanBudgetTarget x,(Select ProductID, ASGID, ASGName, PGName From v_ProductDetails) y  " +
            "Where  x.ProductGroupID=y.ProductID group by x.MarketGroupID,x.Stage,asgid) a " +
            "inner join " +
            "(select marketgroupid,max(stage) stage,asgid,asgname,pgname from t_PlanBudgetTarget x,(Select ProductID, ASGID, ASGName, PGName From v_ProductDetails) y  " +
            "Where  x.ProductGroupID=y.ProductID and " +
            "SBUID=2 and VersionNo Between 11 and 14 " +
            "and PeriodDate Between '" + FirstDayLM + "' and '" + FirstDayCM + "' and PeriodDate < '" + FirstDayCM + "' " +
            "group by marketgroupid,asgid,asgname,pgname) b  " +
            "on (a.marketgroupid=b.marketgroupid and a.stage=b.stage and a.asgid=b.asgid)Where a.MarketGroupID=" + nCustomerID + "  " +
            ")LMPlan " +
            "ON CMPlan.ASGID=LMPlan.ASGID " +
            "Left Outer JOIN " +
            "( " +
            "select a.MarketGroupID,Qty,b.Asgid,b.asgname,b.pgname " +
            "from   " +
            "(select x.MarketGroupID,sum(Qty) qty,x.Stage,asgid  " +
            "from t_PlanBudgetTarget x,(Select ProductID, ASGID, ASGName, PGName From v_ProductDetails) y  " +
            "Where  x.ProductGroupID=y.ProductID group by x.MarketGroupID,x.Stage,asgid) a " +
            "inner join " +
            "(select marketgroupid,max(stage) stage,asgid,asgname,pgname from t_PlanBudgetTarget x,(Select ProductID, ASGID, ASGName, PGName From v_ProductDetails) y  " +
            "Where  x.ProductGroupID=y.ProductID and " +
            "SBUID=2 and VersionNo Between 11 and 14 " +
            "and PeriodDate Between '" + FirstDayLLM + "' and '" + FirstDayLM + "' and PeriodDate < '" + FirstDayLM + "' " +
            "group by marketgroupid,asgid,asgname,pgname) b  " +
            "on (a.marketgroupid=b.marketgroupid and a.stage=b.stage and a.asgid=b.asgid)Where a.MarketGroupID=" + nCustomerID + "  " +
            ")LLMPlan " +
            "ON CMPlan.ASGID=LLMPlan.ASGID " +
            "Left OUter JOIN  " +
            "( " +
            "Select ASGID, CustomerID, Sum(LLMSalesQty)LLMSalesQty,Sum(LLMSaleAmt)LLMSaleAmt, " +
            "Sum(LMSalesQty)LMSalesQty,Sum(LMSaleAmt)LMSaleAmt,Sum(CMSalesQty)CMSalesQty,Sum(CMSaleAmt)CMSaleAmt " +
            "From ( " +
            "Select ASGID, ASGName, PGName, CustomerID,a.ProductID,LLMSalesQty,LLMSaleAmt,LMSalesQty,LMSaleAmt,CMSalesQty,CMSaleAmt from  " +
            "( " +
            "Select CustomerID,ProductID, " +
            "Sum(case Status when 'LLMStatus' then CMSaleQty  else 0 end) as LLMSalesQty, " +
            "Sum(case Status when 'LLMStatus' then CMSaleAmt  else 0 end) as LLMSaleAmt, " +
            "Sum(case Status when 'LMStatus' then CMSaleQty  else 0 end) as LMSalesQty, " +
            "Sum(case Status when 'LMStatus' then CMSaleAmt  else 0 end) as LMSaleAmt, " +
            "Sum(case Status when 'CMStatus' then CMSaleQty  else 0 end) as CMSalesQty, " +
            "Sum(case Status when 'CMStatus' then CMSaleAmt  else 0 end) as CMSaleAmt " +
            "from ( " +
            "select CustomerID,ProductID,'CMStatus'as Status, isnull((sum(CRQty)- sum(DRQty)),0) as CMSaleQty, isnull((sum(CRAmt)- sum(DRAmt)),0) as CMSaleAmt   " +
            "from (   " +
            "select InvoiceDate,CustomerID,ProductID,sum(Quantity)as CRQty, 0 as DRQty, Sum(Amt) as CRAmt, 0 as DRAmt   " +
            "from(  " +
            "select InvoiceDate,sa.CustomerID,ProductID,Quantity,(UnitPrice*Quantity)Amt   " +
            "from t_salesinvoice sa, t_salesinvoicedetail sd   " +
            "where sa.invoiceid = sd.invoiceid and invoicedate    " +
            "between '" + FirstDayCM + "' and '" + FirstDayNextM + "' and invoicedate < '" + FirstDayNextM + "'  " +
            "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)    " +
            ")CR  " +
            "Group by InvoiceDate,CustomerID,ProductID   " +
            "union all   " +
            "select InvoiceDate,CustomerID,ProductID,0 as CRQty,sum(Quantity)as DRQty , 0 as CRAmt, Sum(Amt) as DRAmt   " +
            "from (  " +
            "select InvoiceDate,sa.CustomerID,ProductID,Quantity,(UnitPrice*Quantity)Amt   " +
            "from t_salesinvoice sa, t_salesinvoicedetail sd    " +
            "where sa.invoiceid = sd.invoiceid and invoicedate    " +
            "between '" + FirstDayCM + "' and '" + FirstDayNextM + "' and invoicedate < '" + FirstDayNextM + "'  " +
            "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)    " +
            ")DR  " +
            "Group by InvoiceDate,CustomerID,ProductID  " +
            ")a Group by CustomerID,ProductID  " +
            "UNION ALL " +
            "select CustomerID,ProductID,'LMStatus'as Status, isnull((sum(CRQty)- sum(DRQty)),0) as LMSaleQty, isnull((sum(CRAmt)- sum(DRAmt)),0) as LMSaleAmt   " +
            "from (   " +
            "select InvoiceDate,CustomerID,ProductID,sum(Quantity)as CRQty, 0 as DRQty, Sum(Amt) as CRAmt, 0 as DRAmt   " +
            "from(  " +
            "select InvoiceDate,sa.CustomerID,ProductID,Quantity,(UnitPrice*Quantity)Amt   " +
            "from t_salesinvoice sa, t_salesinvoicedetail sd   " +
            "where sa.invoiceid = sd.invoiceid and invoicedate    " +
            "between '" + FirstDayLM + "' and '" + FirstDayCM + "' and invoicedate < '" + FirstDayCM + "'  " +
            "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)    " +
            ")CR  " +
            "Group by InvoiceDate,CustomerID,ProductID   " +
            "union all   " +
            "select InvoiceDate,CustomerID,ProductID,0 as CRQty,sum(Quantity)as DRQty , 0 as CRAmt, Sum(Amt) as DRAmt   " +
            "from (  " +
            "select InvoiceDate,sa.CustomerID,ProductID,Quantity,(UnitPrice*Quantity)Amt   " +
            "from t_salesinvoice sa, t_salesinvoicedetail sd    " +
            "where sa.invoiceid = sd.invoiceid and invoicedate    " +
            "between '" + FirstDayLM + "' and '" + FirstDayCM + "' and invoicedate < '" + FirstDayCM + "'  " +
            "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)    " +
            ")DR  " +
            "Group by InvoiceDate,CustomerID,ProductID  " +
            ")a Group by CustomerID,ProductID  " +
            "UNION ALL " +
            "select CustomerID,ProductID,'LLMStatus'as Status, isnull((sum(CRQty)- sum(DRQty)),0) as LLMSaleQty, isnull((sum(CRAmt)- sum(DRAmt)),0) as LLMSaleAmt   " +
            "from (   " +
            "select InvoiceDate,CustomerID,ProductID,sum(Quantity)as CRQty, 0 as DRQty, Sum(Amt) as CRAmt, 0 as DRAmt   " +
            "from(  " +
            "select InvoiceDate,sa.CustomerID,ProductID,Quantity,(UnitPrice*Quantity)Amt   " +
            "from t_salesinvoice sa, t_salesinvoicedetail sd   " +
            "where sa.invoiceid = sd.invoiceid and invoicedate    " +
            "between '" + FirstDayLLM + "' and '" + FirstDayLM + "' and invoicedate < '" + FirstDayLM + "'  " +
            "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)    " +
            ")CR  " +
            "Group by InvoiceDate,CustomerID,ProductID   " +
            "union all   " +
            "select InvoiceDate,CustomerID,ProductID,0 as CRQty,sum(Quantity)as DRQty , 0 as CRAmt, Sum(Amt) as DRAmt   " +
            "from (  " +
            "select InvoiceDate,sa.CustomerID,ProductID,Quantity,(UnitPrice*Quantity)Amt   " +
            "from t_salesinvoice sa, t_salesinvoicedetail sd    " +
            "where sa.invoiceid = sd.invoiceid and invoicedate    " +
            "between '" + FirstDayLLM + "' and '" + FirstDayLM + "' and invoicedate < '" + FirstDayLM + "'  " +
            "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)    " +
            ")DR  " +
            "Group by InvoiceDate,CustomerID,ProductID  " +
            ")a Group by CustomerID,ProductID  " +
            ")f Group by CustomerID,ProductID " +
            ")a INNER JOIN (Select ProductID, ASGID, ASGName, PGName from v_ProductDetails)b " +
            "ON a.ProductID=b.ProductID " +
            ")Final Where CustomerID=" + nCustomerID + " " +
            "Group by  ASGID,CustomerID  " +
            ")Sale " +
            "ON Sale.ASGID=CMPlan.ASGID ";

            //cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
            //cmd.Parameters.AddWithValue("PGID", nPGID);
            //cmd.Parameters.AddWithValue("YearID", nYear);
            //cmd.Parameters.AddWithValue("MonthNo", nMonth);

            string sASGName = "'CAC'";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TDSalesPlanWeekly oTDSalesPlanWeekly = new TDSalesPlanWeekly();

                    oTDSalesPlanWeekly.ASGID = (int)reader["ASGID"];
                    oTDSalesPlanWeekly.ASGName = (string)reader["ASGName"];
                    oTDSalesPlanWeekly.ASP = Convert.ToDouble(reader["ASP"].ToString());
                    oTDSalesPlanWeekly.PGName = (string)reader["PGName"];
                    oTDSalesPlanWeekly.Quantity = int.Parse(reader["Quantity"].ToString());
                    oTDSalesPlanWeekly.MonthName = (string)reader["PlanMonthName"];
                    oTDSalesPlanWeekly.PlanYear = int.Parse(reader["PlanYear"].ToString());
                    oTDSalesPlanWeekly.IsPlanned = int.Parse(reader["IsPlanned"].ToString());
                    //oTDSalesPlanWeekly.Status = int.Parse(reader["Status"].ToString());

                    InnerList.Add(oTDSalesPlanWeekly);

                    sASGName = sASGName + "," + "'" + oTDSalesPlanWeekly.ASGName + "'";
                }

                //GetUnmatchASG(nCustomerID, nYear, nMonth, nPGID, sASGName);
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public void GetUnmatchASG(int nCustomerID, int nYearID, int nMonthNo, int nPGID, string sASGName)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.ASGID, a.ASGName,ASP, PGID,PGName,IsNull(CustomerID,0)CustomerID, IsNull(PlanYear,0)PlanYear, " +
                            "IsNull(PlanMonth,0)PlanMonth, '' as PlanMonthName, IsNull(Quantity,0)Quantity, " +
                            "IsNull(IsPlanned,0)IsPlanned, IsNull(Status,0)Status  from   " +
                            "(  " +
                            "Select ASGID, ASGName, PGID, PGName, round((RSP/Qty),0)ASP from  " +
                            "( " +
                            "Select ASGID, ASGName, PGID, PGName, Count(ASGID)Qty,Sum(RSP)RSP from  " +
                            "( " +
                            "Select ProductID,ASGID, ASGName, PGID, PGName, RSP from v_productdetails Where PGID IN (1,4,6) and ASGID <> 78 and IsActive=1 " +
                            ") a group by ASGID, ASGName, PGID,PGName)a  " +
                            ")a   " +
                            "Left OUter JOIN   " +
                            "(  " +
                            "Select CustomerID, a.ASGID,ASGName, PlanYear,   " +
                            "PlanMonth, Quantity, IsPlanned, Status from t_TDSalesPlan a,   " +
                            "(Select Distinct ASGID, ASGName, PGID,PGName from v_productdetails Where PGID IN (1,4,6) and ASGID <> 78)b   " +
                            "Where CustomerID=? and PlanYear=? and PlanMonth=? and a.ASGID=b.ASGID  " +
                            "and ASGName Not IN (" + sASGName + ")  " +
                            ") b   " +
                            "ON a.ASGID=b.ASGID where a.PGID=? and a.ASGName Not IN (" + sASGName + ")";

            cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
            cmd.Parameters.AddWithValue("YearID", nYearID);
            cmd.Parameters.AddWithValue("MonthNo", nMonthNo);
            cmd.Parameters.AddWithValue("PGID", nPGID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TDSalesPlanWeekly oTDSalesPlanWeekly = new TDSalesPlanWeekly();

                    oTDSalesPlanWeekly.ASGID = (int)reader["ASGID"];
                    oTDSalesPlanWeekly.ASGName = (string)reader["ASGName"];
                    oTDSalesPlanWeekly.ASP = Convert.ToDouble(reader["ASP"].ToString());
                    oTDSalesPlanWeekly.PGName = (string)reader["PGName"];
                    oTDSalesPlanWeekly.Quantity = int.Parse(reader["Quantity"].ToString());
                    oTDSalesPlanWeekly.MonthName = (string)reader["PlanMonthName"];
                    oTDSalesPlanWeekly.PlanYear = int.Parse(reader["PlanYear"].ToString());
                    oTDSalesPlanWeekly.IsPlanned = int.Parse(reader["IsPlanned"].ToString());
                    //oTDSalesPlanWeekly.Status = int.Parse(reader["Status"].ToString());

                    InnerList.Add(oTDSalesPlanWeekly);
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


