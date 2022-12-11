using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.POS;

namespace CJ.Class.Report
{
    public class rptTDSalesPlan
    {
        private string _sOutlet;
        private string _sProductGroup;
        private string _sMAG;
        private string _sASG;
        private string _sProductCode;
        private string _sProductName;
        private int _nMonth;
        private int _nYear;
        private int _nExecutiveQty;
        private int _nOutletManagerQty;
        private int _nZonalMgrQty;
        private int _nNationalMgrQty;
        private int _nLastQty;
        private string _sLastStage;
        private double _oRevenue;

        public double Revenue
        {
            get { return _oRevenue; }
            set { _oRevenue = value; }
        }

        public string LastStage
        {
            get { return _sLastStage; }
            set { _sLastStage = value; }
        }

        public int LastQty
        {
            get { return _nLastQty; }
            set { _nLastQty = value; }
        }

        public int NationalMgrQty
        {
            get { return _nNationalMgrQty; }
            set { _nNationalMgrQty = value; }
        }

        public int ZonalMgrQty
        {
            get { return _nZonalMgrQty; }
            set { _nZonalMgrQty = value; }
        }

        public int OutletManagerQty
        {
            get { return _nOutletManagerQty; }
            set { _nOutletManagerQty = value; }
        }

        public int ExecutiveQty
        {
            get { return _nExecutiveQty; }
            set { _nExecutiveQty = value; }
        } 

        public string Outlet
        {
            get { return _sOutlet; }
            set { _sOutlet = value; }
        }

        public string ProductGroup
        {
            get { return _sProductGroup; }
            set { _sProductGroup = value; }
        }

        public string MAG
        {
            get { return _sMAG; }
            set { _sMAG = value; }
        }

        public string ASG
        {
            get { return _sASG; }
            set { _sASG = value; }
        }

        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }

        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }

        public int Month
        {
            get { return _nMonth; }
            set { _nMonth = value; }
        }

        public int Year
        {
            get { return _nYear; }
            set { _nYear = value; }
        } 
        
    }

    public class rptTDSalesPlans : CollectionBaseCustom
    {

        public void Add(rptTDSalesPlan orptTDSalesPlan)
        {
            this.List.Add(orptTDSalesPlan);
        }
        public rptTDSalesPlan this[int i]
        {
            get { return (rptTDSalesPlan)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void GetTDSalesPlan(int nCustomerID, int nPGID, int nMAGID, int nASGID, string sProductCode, string sProductName, DateTime dStartDate)
        {

            DateTime dEndDate;

            dEndDate = dStartDate.AddMonths(1);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select CustomerID,CustomerName, TerritoryName,ProductCode, ProductName,ASGID,Cust.ASGName,MAGID,MAGName,PGID,PGName, " +
            "IsNull(a.Year,0)Year, IsNull(a.Month,0)Month,  " +
            "IsNull(Executive,0)Executive,IsNull(OutletManager,0)OutletManager,IsNull(ZonalManager,0)ZonalManager, " +
            "IsNull(NationalManager,0)NationalManager,IsNull(LastQty,0)LastQty,LastStage=CASE When LastStage=1 then 'Executive' " +
            "When LastStage=2 then 'OutletManager' When LastStage=3 then 'ZonalManager' When LastStage=4 then 'NationalManager' else 'NoPlan' end " +
            ",IsNull(Revenue,0)Revenue from  " +
            "( " +
            "Select CustomerID,CustomerName, TerritoryName,ProductID,ProductCode, ProductName,ASGID,ASGName,MAGID,MAGName,PGID,PGName from  " +
            "( " +
            "select CustomerID, Left(CustomerName,3)CustomerName, TerritoryName,b.ProductID,ProductCode, ProductName, " +
            "ASGID,ASGName,MAGID,MAGName,PGID,PGName from v_CustomerDetails a, v_ProductDetails b,(Select ProductID,IsActive from t_TDproductPortFolio)c " +
            "Where CustomerTypeID=5 and CustomerID NOT IN (7,789,2171,2170)and PGID Not IN (705,468,333,8) " +
            "and c.ProductID=b.ProductID and c.IsActive=1 ";
            if(nCustomerID != -1)
            {
                sSql = sSql + " and CustomerID=" + nCustomerID + "  ";
            }
            if (nPGID != -1)
            {
                sSql = sSql + " and PGID=" + nPGID + "  ";
            }
            if (nMAGID != -1)
            {
                sSql = sSql + " and MAGID=" + nMAGID + "  ";
            }
            if (nASGID != -1)
            {
                sSql = sSql + " and ASGID=" + nASGID + "  ";
            }
            if (sProductCode.Trim() != "")
            {
                sSql = sSql + " and ProductCode='" + sProductCode + "'  ";
            }
            if (sProductName.Trim() != "")
            {
                sSql = sSql + " and ProductName like '%" + sProductName + "%'  ";
            }

            sSql = sSql + ")x Group by CustomerID,CustomerName, TerritoryName,ProductID,ProductCode, ProductName,ASGID,ASGName,MAGID,MAGName,PGID,PGName " +
            ")Cust " +
            "Left Outer JOIN " +
            "( " +
            "Select ProductGroupID, MarketGroupID, ASGName,Year, Month, " +
            "SUM(CASE When Stage=1 then Qty else 0 end ) as Executive, " +
            "SUM(CASE When Stage=2 then Qty else 0 end ) as OutletManager, " +
            "SUM(CASE When Stage=3 then Qty else 0 end ) as ZonalManager, " +
            "SUM(CASE When Stage=4 then Qty else 0 end ) as NationalManager " +
            "from ( " +
            "select ProductGroupID, MarketGroupID,Qty,ASGName,Year(PeriodDate)as Year,CONVERT(CHAR(3), PeriodDate, 109) AS Month,Stage from t_PlanBudgetTarget a, " +
            "(Select ProductID,ProductCode,ProductName, ASGName, PGName from v_ProductDetails)Prod  " +
            "Where a.ProductGroupID=Prod.ProductID and versionNo between 11 and 14 and PlanType=2 and SBUID=2 and ProductGroupType=1  " +
            "and PeriodDate between '" + dStartDate + "' and '" + dEndDate + "' and PeriodDate <'" + dEndDate + "' " +
            ")x Group by ProductGroupID, MarketGroupID, ASGName, Year, Month " +
            ")a " +
            "ON Cust.CustomerID=a.MarketGroupID and Cust.ASGName=a.ASGName and Cust.ProductID=a.ProductGroupID " +
            "Left Outer JOIN " +
            "( " +
            "Select MaxQty.*, Revenue from  " +
            "( " +
            "select MarketGroupID,ProductGroupID,Month, Year,Max(Stage)LastStage,SUM(Qty)LastQty  from ( " +
            "select MarketGroupID,ProductGroupID,Qty,Year(PeriodDate)as Year,CONVERT(CHAR(3), PeriodDate, 109) AS Month, Stage from " +
            "t_PlanBudgetTarget " +
            "Where versionNo between 11 and 14 and PlanType=2 and SBUID=2 and ProductGroupType=1  " +
            "and PeriodDate between '" + dStartDate + "' and '" + dEndDate + "' and PeriodDate <'" + dEndDate + "' " +
            ")x " +
            "Group by MarketGroupID,ProductGroupID,Month,Year,Stage " +
            ")MaxQty " +
            "inner JOIN " +
            "( " +
            "select MarketGroupID,ProductGroupID,Month, Year,Revenue,Max(Stage)LastStage  from  " +
            "( " +
            "select MarketGroupID,ProductGroupID,Qty,Year(PeriodDate)as Year,CONVERT(CHAR(3), PeriodDate, 109) AS Month,Revenue, Stage from " +
            "t_PlanBudgetTarget a,(select ProductID, (RSP-RSP*VAT)Revenue from v_ProductDetails)Prod " +
            "Where prod.ProductID=a.ProductGroupID and versionNo between 11 and 14 and PlanType=2 and SBUID=2 and ProductGroupType=1  " +
            "and PeriodDate between '" + dStartDate + "' and '" + dEndDate + "' and PeriodDate <'" + dEndDate + "' " +
            ")x " +
            "Group by MarketGroupID,ProductGroupID,Month,Year,Revenue " +
            ")MaxStage " +
            "ON MaxQty.MarketGroupID=MaxStage.MarketGroupID and MaxQty.ProductGroupID=MaxStage.ProductGroupID " +
            "and MaxQty.Year=MaxStage.Year and MaxQty.Month=MaxStage.Month and MaxQty.LastStage=MaxStage.LastStage " +
            ")LastStage " +
            "ON a.MarketGroupID=LastStage.MarketGroupID and a.ProductGroupID=LastStage.ProductGroupID " +
            "and LastStage.Year=a.year and LastStage.Month=a.Month ";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptTDSalesPlan orptTDSalesPlan = new rptTDSalesPlan();


                    orptTDSalesPlan.ProductCode = (string)reader["ProductCode"];
                    orptTDSalesPlan.ProductName = (string)reader["ProductName"];


                    orptTDSalesPlan.ExecutiveQty = int.Parse(reader["Executive"].ToString());
                    orptTDSalesPlan.OutletManagerQty = int.Parse(reader["OutletManager"].ToString());
                    orptTDSalesPlan.ZonalMgrQty = int.Parse(reader["ZonalManager"].ToString());
                    orptTDSalesPlan.NationalMgrQty = int.Parse(reader["NationalManager"].ToString());
                    orptTDSalesPlan.LastQty = int.Parse(reader["LastQty"].ToString());
                    orptTDSalesPlan.LastStage = (string)reader["LastStage"];
                    orptTDSalesPlan.Revenue = Convert.ToDouble(reader["Revenue"].ToString());

                    orptTDSalesPlan.ASG = (string)reader["ASGName"];
                    orptTDSalesPlan.MAG = (string)reader["MAGName"];
                    orptTDSalesPlan.ProductGroup = (string)reader["PGName"];


                    InnerList.Add(orptTDSalesPlan);
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
