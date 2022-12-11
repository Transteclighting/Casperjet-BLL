// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Nov 14, 2018
// Time :  10:50 AM
// Description: Class for POS Dashboard
// Modify Person And Date:
// </summary>


using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.POS
{
    public class POSDashboard
    {
        private string _sWeek;
        public string Week
        {
            get { return _sWeek; }
            set { _sWeek = value; }
        }

        private string _sValPercent;
        public string sValPercent
        {
            get { return _sValPercent; }
            set { _sValPercent = value; }
        }

        private string _sQtyPercent;
        public string sQtyPercent
        {
            get { return _sQtyPercent; }
            set { _sQtyPercent = value; }
        }

        private string _sMAGName;
        public string sMAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value; }
        }

        private string _sBrandName;
        public string sBrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value; }
        }

        private string _sEmployeeCode;
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value; }
        }

        private string _sEmployeeName;
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value; }
        }

        private double _TargetSalesValue;
        public double TargetSalesValue
        {
            get { return _TargetSalesValue; }
            set { _TargetSalesValue = value; }
        }

        private double _ActualSalesValue;
        public double ActualSalesValue
        {
            get { return _ActualSalesValue; }
            set { _ActualSalesValue = value; }
        }

        private int _TargetSalesQty;
        public int TargetSalesQty
        {
            get { return _TargetSalesQty; }
            set { _TargetSalesQty = value; }
        }

        private int _ActualSalesQty;
        public int ActualSalesQty
        {
            get { return _ActualSalesQty; }
            set { _ActualSalesQty = value; }
        }

        private int _nMonth;
        public int nMonth
        {
            get { return _nMonth; }
            set { _nMonth = value; }
        }

        private string _sMonth;
        public string sMonth
        {
            get { return _sMonth; }
            set { _sMonth = value; }
        }

        private string _sChannelName;
        public string ChannelName
        {
            get { return _sChannelName; }
            set { _sChannelName = value; }
        }
        public int GetChannelID(int nIndex)
        {
            int nChannelID = 0;
            if (nIndex == (int)Dictionary.POSChannel.Retail)
            {
                nChannelID = 4;
            }
            else if (nIndex == (int)Dictionary.POSChannel.Dealer)
            {
                nChannelID = 3;
            }
            else if (nIndex == (int)Dictionary.POSChannel.B2B)
            {
                nChannelID = 13;
            }
            else if (nIndex == (int)Dictionary.POSChannel.eStore)
            {
                nChannelID = 16;
            }
            else
            {
                nChannelID = 0;
            }

            return nChannelID;
        }

        public string GetSalesType(int nIndex)
        {
            string sSalesType = "";
            if (nIndex == (int)Dictionary.POSChannel.Retail)
            {
                sSalesType = "1,2,4";
            }
            else if (nIndex == (int)Dictionary.POSChannel.Dealer)
            {
                sSalesType = "5";
            }
            else if (nIndex == (int)Dictionary.POSChannel.B2B)
            {
                sSalesType = "3";
            }
            else if (nIndex == (int)Dictionary.POSChannel.eStore)
            {
                sSalesType = "6";
            }
            else
            {
                sSalesType = "";
            }

            return sSalesType;
        }

        public double SalesData(DateTime dFromDate, DateTime dToDate)
        {

            double _Value = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = " Select Sum(GrossSales + OC - VAT - Discount) as Actual from " +
                    " ( " +
                    " Select isnull((sum(crqty) - sum(drqty)), 0) as SalesQty, isnull((sum(crGrossSales) - sum(drGrossSales)), 0) as GrossSales, " +
                    " isnull((sum(crDiscount) - sum(drDiscount)), 0) as Discount, isnull((sum(crOC) - sum(drOC)), 0) as OC, " +
                    " isnull((sum(crCOGS) - sum(drCOGS)), 0) as COGS, isnull((sum(crVAT) - sum(drVAT)), 0) as VAT " +
                    " From " +
                    " ( " +
                    " Select SalesPersonID, ProductID, sum(quantity) as crqty, " +
                    " 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, " +
                    " sum(Discount) as crDiscount, 0 as drDiscount, sum(OC) as crOC, 0 as drOC, sum(COGS) as crCOGS, " +
                    " 0 as drCOGS, sum(VAT) as crVAT, 0 as drVAT  from " +
                    " ( " +
                    " Select SalesPersonID, a.InvoiceID, ProductID, Quantity, (Quantity * unitprice) as GrossSales, " +
                    " (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                    " (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                    " from " +
                    " ( " +
                    " select SalesPersonID, sa.InvoiceID, ProductID, UnitPrice, Costprice, " +
                    " TradePrice, VatAmount, Discount, quantity " +
                    " from t_salesinvoice sa, t_salesinvoicedetail sd where sa.invoiceid = sd.invoiceid and " +
                    " invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                    " and invoicetypeid in (1, 2, 4, 5)and invoicestatus not in (3) " +
                    " ) as a " +
                    " left outer join " +
                    " ( " +
                    " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, isnull((OtherCharge / sum(quantity)), 0) as AvgOC " +
                    " from t_salesinvoice sa, t_salesinvoicedetail sd where sa.invoiceid = sd.invoiceid and " +
                    " invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                    " and invoicetypeid in (1, 2, 4, 5) and invoicestatus not in (3) " +
                    " group by SalesPersonID, sa.InvoiceID, Discount, OtherCharge " +
                    " ) as b " +
                    " on a.invoiceid = b.invoiceid " +
                    " ) as final  Group By SalesPersonID, ProductID " +
                    " Union all " +
                    " Select SalesPersonID, ProductID, 0 as crqty,  " +
                    " sum(quantity) as drqty, 0 as crGrossSales, sum(GrossSales) as drGrossSales,  " +
                    " 0 as crDiscount, sum(Discount) as drDiscount, 0 as crOC, sum(OC) as drOC,  " +
                    " 0 as crCOGS, sum(COGS) as drCOGS, 0 as crVAT, sum(VAT) as drVAT " +
                    " from ( " +
                    " Select SalesPersonID, a.InvoiceID, ProductID, Quantity, " +
                    " (Quantity * unitprice) as GrossSales, (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                    "(Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                    " from( " +
                    " select SalesPersonID, sa.InvoiceID, ProductID, UnitPrice, Costprice, TradePrice, VatAmount, Discount, quantity " +
                    " from t_salesinvoice sa, t_salesinvoicedetail sd " +
                    " where sa.invoiceid = sd.invoiceid and " +
                    " invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                    " and invoicetypeid in (6, 7, 9, 10, 12)and invoicestatus not in (3)) as a " +
                    " left outer join " +
                    " ( " +
                    " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, isnull((OtherCharge / sum(quantity)), 0) as AvgOC " +
                    " from t_salesinvoice sa, t_salesinvoicedetail sd " +
                    " where sa.invoiceid = sd.invoiceid and invoicedate " +
                    " between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  and invoicetypeid in (6, 7, 9, 10, 12) and " +
                    " invoicestatus not in (3)   group by sa.InvoiceID, Discount, OtherCharge " +
                    " ) as b " +
                    " on a.invoiceid = b.invoiceid " +
                    " ) as final " +
                    " Group By SalesPersonID,ProductID " +
                    " )as FinalQuery ) x  ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    _Value = Math.Round((double)reader["Actual"]);
                }

                reader.Close();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            return _Value;
        }

        public double SalesDataRT(DateTime dFromDate, DateTime dToDate)
        {

            double _Value = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = " Select Sum(GrossSales + OC - VAT - Discount) as Actual from " +
                    " ( " +
                    " Select isnull((sum(crqty) - sum(drqty)), 0) as SalesQty, isnull((sum(crGrossSales) - sum(drGrossSales)), 0) as GrossSales, " +
                    " isnull((sum(crDiscount) - sum(drDiscount)), 0) as Discount, isnull((sum(crOC) - sum(drOC)), 0) as OC, " +
                    " isnull((sum(crCOGS) - sum(drCOGS)), 0) as COGS, isnull((sum(crVAT) - sum(drVAT)), 0) as VAT " +
                    " From " +
                    " ( " +
                    " Select SalesPersonID, ProductID, sum(quantity) as crqty, " +
                    " 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, " +
                    " sum(Discount) as crDiscount, 0 as drDiscount, sum(OC) as crOC, 0 as drOC, sum(COGS) as crCOGS, " +
                    " 0 as drCOGS, sum(VAT) as crVAT, 0 as drVAT  from " +
                    " ( " +
                    " Select SalesPersonID, a.InvoiceID, ProductID, Quantity, (Quantity * unitprice) as GrossSales, " +
                    " (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                    " (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                    " from " +
                    " ( " +
                    " select SalesPersonID, sa.InvoiceID, ProductID, UnitPrice, Costprice, " +
                    " TradePrice, VatAmount, Discount, quantity " +
                    " from t_salesinvoice sa, t_salesinvoicedetail sd where sa.invoiceid = sd.invoiceid and " +
                    " sa.WarehouseID=" + Utility.WarehouseID+" and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                    " and invoicetypeid in (1, 2, 4, 5)and invoicestatus not in (3) " +
                    " ) as a " +
                    " left outer join " +
                    " ( " +
                    " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, isnull((OtherCharge / sum(quantity)), 0) as AvgOC " +
                    " from t_salesinvoice sa, t_salesinvoicedetail sd where sa.invoiceid = sd.invoiceid and " +
                    " sa.WarehouseID=" + Utility.WarehouseID + " and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                    " and invoicetypeid in (1, 2, 4, 5) and invoicestatus not in (3) " +
                    " group by SalesPersonID, sa.InvoiceID, Discount, OtherCharge " +
                    " ) as b " +
                    " on a.invoiceid = b.invoiceid " +
                    " ) as final  Group By SalesPersonID, ProductID " +
                    " Union all " +
                    " Select SalesPersonID, ProductID, 0 as crqty,  " +
                    " sum(quantity) as drqty, 0 as crGrossSales, sum(GrossSales) as drGrossSales,  " +
                    " 0 as crDiscount, sum(Discount) as drDiscount, 0 as crOC, sum(OC) as drOC,  " +
                    " 0 as crCOGS, sum(COGS) as drCOGS, 0 as crVAT, sum(VAT) as drVAT " +
                    " from ( " +
                    " Select SalesPersonID, a.InvoiceID, ProductID, Quantity, " +
                    " (Quantity * unitprice) as GrossSales, (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                    "(Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                    " from( " +
                    " select SalesPersonID, sa.InvoiceID, ProductID, UnitPrice, Costprice, TradePrice, VatAmount, Discount, quantity " +
                    " from t_salesinvoice sa, t_salesinvoicedetail sd " +
                    " where sa.WarehouseID=" + Utility.WarehouseID + " and sa.invoiceid = sd.invoiceid and " +
                    " invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                    " and invoicetypeid in (6, 7, 9, 10, 12)and invoicestatus not in (3)) as a " +
                    " left outer join " +
                    " ( " +
                    " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, isnull((OtherCharge / sum(quantity)), 0) as AvgOC " +
                    " from t_salesinvoice sa, t_salesinvoicedetail sd " +
                    " where sa.WarehouseID=" + Utility.WarehouseID + " and sa.invoiceid = sd.invoiceid and invoicedate " +
                    " between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  and invoicetypeid in (6, 7, 9, 10, 12) and " +
                    " invoicestatus not in (3)   group by sa.InvoiceID, Discount, OtherCharge " +
                    " ) as b " +
                    " on a.invoiceid = b.invoiceid " +
                    " ) as final " +
                    " Group By SalesPersonID,ProductID " +
                    " )as FinalQuery ) x  ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    _Value = Math.Round((double)reader["Actual"]);
                }

                reader.Close();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            return _Value;
        }

        public double GetMTDTarget(DateTime dFromDate)
        {
            double _Value = 0;
            int nYear = dFromDate.Year;
            int nMonth = dFromDate.Month;
            string _sDate = dFromDate.ToString("dd-MMM-yyyy");

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = " Select Sum(TargetAmt) as MTDTarget from " +
                   " ( " +
                   " select Sum(TargetAmount) as TargetAmt from t_PlanExecutiveLeadTarget where TYear = " + nYear + " " +
                   " and TMonth = " + nMonth + " and TargetType = " + (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty + " and WeekNo < (Select WeekNo from t_CalendarWeek where '" + _sDate + "' between FromDate and ToDate) " +
                   " UNION ALL " +
                   " Select(TargetAmt / (Select day(ToDate - FromDate) as TotalDay from t_CalendarWeek where '" + _sDate + "' between FromDate and ToDate) " +
                   " * (Select day('" + _sDate + "' - FromDate) as TotalDay from t_CalendarWeek where '" + _sDate + "' between FromDate and ToDate)) TargetAmount from " +
                   "  ( " +
                   "  select Sum(TargetAmount) as TargetAmt from t_PlanExecutiveLeadTarget where TYear = " + nYear + " " +
                   "  and TMonth = " + nMonth + " and TargetType = " + (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty + " and WeekNo = (Select WeekNo from t_CalendarWeek where '" + _sDate + "' between FromDate and ToDate) " +
                   " ) x)Final ";



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (reader["MTDTarget"] != DBNull.Value)
                    {
                        _Value = Convert.ToDouble(reader["MTDTarget"]);
                    }
                    else
                    {
                        _Value = 0;
                    }

                }

                reader.Close();

                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            return _Value;
        }

        public double GetMTDTargetRT(DateTime dFromDate)
        {
            double _Value = 0;
            int nYear = dFromDate.Year;
            int nMonth = dFromDate.Month;
            string _sDate = dFromDate.ToString("dd-MMM-yyyy");

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = " Select Sum(TargetAmt) as MTDTarget from " +
                   " ( " +
                   " select Sum(TargetAmount) as TargetAmt from t_PlanExecutiveLeadTarget where TYear = " + nYear + " " +
                   " and TMonth = " + nMonth + " and CustomerID=" + Utility.CustomerID + " and TargetType = " + (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty + " and WeekNo < (Select WeekNo from t_CalendarWeek where '" + _sDate + "' between FromDate and ToDate) " +
                   " UNION ALL " +
                   " Select(TargetAmt / (Select day(ToDate - FromDate) as TotalDay from t_CalendarWeek where '" + _sDate + "' between FromDate and ToDate) " +
                   " * (Select day('" + _sDate + "' - FromDate) as TotalDay from t_CalendarWeek where '" + _sDate + "' between FromDate and ToDate)) TargetAmount from " +
                   "  ( " +
                   "  select Sum(TargetAmount) as TargetAmt from t_PlanExecutiveLeadTarget where TYear = " + nYear + " " +
                   "  and TMonth = " + nMonth + " and CustomerID=" + Utility.CustomerID + " and TargetType = " + (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty + " and WeekNo = (Select WeekNo from t_CalendarWeek where '" + _sDate + "' between FromDate and ToDate) " +
                   " ) x)Final ";



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (reader["MTDTarget"] != DBNull.Value)
                    {
                        _Value = Convert.ToDouble(reader["MTDTarget"]);
                    }
                    else
                    {
                        _Value = 0;
                    }

                }

                reader.Close();

                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            return _Value;
        }

        public double GetLeadInvoiceAmount(DateTime dFromDate)
        {
            double _Value = 0;
            int nYear = dFromDate.Year;
            int nMonth = dFromDate.Month;
            string _sDate = dFromDate.ToString("dd-MMM-yyyy");

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = " Select Sum(InvoiceAmount) as InvoiceAmount from t_SalesLeadManagement a, t_SalesInvoice b " +
                   " where a.InvoiceNo = b.InvoiceNo and Status = "+(int)Dictionary.SalesLeadStatusPOS.Sales_Executed + " and month(a.InvoiceDate) = "+ nMonth + " and year(a.InvoiceDate) = "+ nYear + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (reader["InvoiceAmount"] != DBNull.Value)
                    {
                        _Value = Convert.ToDouble(reader["InvoiceAmount"]);
                    }
                    else
                    {
                        _Value = 0;
                    }

                }

                reader.Close();

                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            return _Value;
        }

        public double GetLeadInvoiceAmountRT(DateTime dFromDate)
        {
            double _Value = 0;
            int nYear = dFromDate.Year;
            int nMonth = dFromDate.Month;
            string _sDate = dFromDate.ToString("dd-MMM-yyyy");

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = " Select Sum(InvoiceAmount) as InvoiceAmount from t_SalesLeadManagement a, t_SalesInvoice b " +
                   " where a.WarehouseID=" + Utility.WarehouseID+" and a.InvoiceNo = b.InvoiceNo and Status = " + (int)Dictionary.SalesLeadStatusPOS.Sales_Executed + " and month(a.InvoiceDate) = " + nMonth + " and year(a.InvoiceDate) = " + nYear + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (reader["InvoiceAmount"] != DBNull.Value)
                    {
                        _Value = Convert.ToDouble(reader["InvoiceAmount"]);
                    }
                    else
                    {
                        _Value = 0;
                    }

                }

                reader.Close();

                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            return _Value;
        }
    }
    public class POSDashboards : CollectionBase
    {
        public POSDashboard this[int i]
        {
            get { return (POSDashboard)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(POSDashboard oPOSDashboard)
        {
            InnerList.Add(oPOSDashboard);
        }
        public void WeekSales(DateTime dFromDate, DateTime dToDate, int nChannel, string sSalesType, int nSalesPersonID, int nMAGID, int nBrandID)
        {
            dToDate = dToDate.AddDays(1);
            int nYear = dFromDate.Year;
            int nMonth = dFromDate.Month;


            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select WeekNo, sum(Target) as Target, Sum(TargetQty) as TargetQty, Sum(Actual) as Actual, Sum(ActualQty) as ActualQty from  " +
                       " ( " +
                       " Select WeekNo, Sum(TargetAmount) as Target, Sum(TargetQty) as TargetQty, 0 as Actual, 0 as ActualQty from[dbo].[t_PlanExecutiveLeadTarget] where TargetType = " + (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty + " " +
                       " and TMonth = " + nMonth + " and TYear = " + nYear + " ";

            if (nChannel != 0)
            {
                sSql += " and Channel = " + nChannel + " ";
            }
            if (nSalesPersonID != 0)
            {
                sSql += " and SalesPersonID = " + nSalesPersonID + " ";
            }
            if (nMAGID != 0)
            {
                sSql += " and MAGID = " + nMAGID + " ";
            }
            if (nBrandID != 0)
            {
                sSql += " and BrandID = " + nBrandID + " ";
            }

            sSql += " Group by WeekNo " +
                       " UNION ALL " +
                       " Select WeekNo, 0 as Target, 0 as TargetQty, Sum(GrossSales + OC - VAT - Discount) as Actual, sum(SalesQty) as ActualQty " +
                       " From " +
                       " ( " +
                       " Select WeekNo, " +
                       " isnull((sum(crqty) - sum(drqty)), 0) as SalesQty, isnull((sum(crGrossSales) - sum(drGrossSales)), 0) as GrossSales, " +
                       " isnull((sum(crDiscount) - sum(drDiscount)), 0) as Discount, isnull((sum(crOC) - sum(drOC)), 0) as OC, " +
                       " isnull((sum(crCOGS) - sum(drCOGS)), 0) as COGS, isnull((sum(crVAT) - sum(drVAT)), 0) as VAT " +
                       " From " +
                       " ( " +
                       " Select SalesPersonID, SalesType, TYear, WeekNo, TMonth, ProductID, sum(quantity) as crqty, " +
                       " 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, " +
                       " sum(Discount) as crDiscount, 0 as drDiscount, sum(OC) as crOC, 0 as drOC, sum(COGS) as crCOGS, " +
                       " 0 as drCOGS, sum(VAT) as crVAT, 0 as drVAT  from " +
                       " ( " +
                       " Select SalesPersonID, SalesType, a.InvoiceID, " +
                       " WeekNo, TYear, TMonth, ProductID, Quantity, (Quantity * unitprice) as GrossSales, " +
                       " (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                       " (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                       " from " +
                       " ( " +
                       " select SalesPersonID, SalesType, sa.InvoiceID, WeekNo, year(invoicedate) as TYear, " +
                       " month(invoicedate) as TMonth, ProductID, UnitPrice, Costprice, " +
                       " TradePrice, VatAmount, Discount, quantity " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd, t_RetailConsumer sc, t_CalendarWeek " +
                       " where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID = sc.ConsumerID and " +
                       " invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                       " and convert(datetime, (convert(varchar(12), InvoiceDate, 106))) between fromdate and todate " +
                       " and invoicetypeid in (1, 2, 4, 5)and invoicestatus not in (3) " +
                       " ) as a " +
                       " left outer join " +
                       " ( " +
                       " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, " +
                       " isnull((OtherCharge / sum(quantity)), 0) as AvgOC  from t_salesinvoice sa, t_salesinvoicedetail sd " +
                       " where sa.invoiceid = sd.invoiceid and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  and invoicetypeid in (1, 2, 4, 5) and " +
                       " invoicestatus not in (3)   group by SalesPersonID, sa.InvoiceID, Discount, OtherCharge " +
                       " ) as b " +
                       " on a.invoiceid = b.invoiceid " +
                       " ) as final  Group By SalesPersonID, SalesType, TYear, TMonth, WeekNo, ProductID " +
                       " Union all " +
                       " Select SalesPersonID, SalesType, TYear, WeekNo, TMonth, ProductID, 0 as crqty, " +
                       " sum(quantity) as drqty, 0 as crGrossSales, sum(GrossSales) as drGrossSales, " +
                       " 0 as crDiscount, sum(Discount) as drDiscount, 0 as crOC, sum(OC) as drOC, " +
                       " 0 as crCOGS, sum(COGS) as drCOGS, 0 as crVAT, sum(VAT) as drVAT " +
                       " from( " +
                       " Select SalesPersonID, a.InvoiceID, WeekNo, TYear, TMonth, SalesType, ProductID, Quantity, " +
                       " (Quantity * unitprice) as GrossSales, (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                       " (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                       " from( " +
                       " select SalesPersonID, sa.InvoiceID, WeekNo, year(invoicedate) as TYear, month(invoicedate) as TMonth, " +
                       " SalesType, ProductID, UnitPrice, Costprice, TradePrice, VatAmount, Discount, quantity " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd, t_Retailconsumer sc, t_CalendarWeek " +
                       " where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID = sc.ConsumerID and " +
                       " invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                       " and convert(datetime, (convert(varchar(12), InvoiceDate, 106))) between fromdate and todate " +
                       " and invoicetypeid in (6, 7, 9, 10, 12)and invoicestatus not in (3)) as a " +
                       " left outer join " +
                       " ( " +
                       " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, isnull((OtherCharge / sum(quantity)), 0) as AvgOC " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd " +
                       " where sa.invoiceid = sd.invoiceid and invoicedate " +
                       " between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  and invoicetypeid in (6, 7, 9, 10, 12) and " +
                       " invoicestatus not in (3)   group by sa.InvoiceID, Discount, OtherCharge " +
                       " ) as b " +
                       " on a.invoiceid = b.invoiceid " +
                       " ) as final " +
                       " Group By SalesPersonID,SalesType,WeekNo,TYear,TMonth,ProductID " +
                       " )as FinalQuery, v_ProductDetails b Where FinalQuery.ProductID = b.ProductID and TYear = " + nYear + " and TMonth = " + nMonth + " ";
            if (sSalesType != "")
            {
                sSql += " and SalesType IN("+ sSalesType + ")  ";
            }

            if (nSalesPersonID != 0)
            {
                sSql += " and SalesPersonID = " + nSalesPersonID + " ";
            }
            if (nMAGID != 0)
            {
                sSql += " and MAGID = " + nMAGID + " ";
            }
            if (nBrandID != 0)
            {
                sSql += " and BrandID = " + nBrandID + " ";
            }
            sSql += " Group by  WeekNo )x Group by  WeekNo " +
                       " ) final group by WeekNo Order by WeekNo ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    POSDashboard oPOSDashboard = new POSDashboard();

                    oPOSDashboard.Week = reader["WeekNo"].ToString();
                    oPOSDashboard.TargetSalesValue = Math.Round((double)reader["Target"]);
                    oPOSDashboard.ActualSalesValue = Math.Round((double)reader["Actual"]);
                    oPOSDashboard.TargetSalesQty = Convert.ToInt32(reader["TargetQty"]);
                    oPOSDashboard.ActualSalesQty = Convert.ToInt32(reader["ActualQty"]);
                    if (oPOSDashboard.TargetSalesValue != 0)
                    {
                        oPOSDashboard.sValPercent = Math.Round(oPOSDashboard.ActualSalesValue / oPOSDashboard.TargetSalesValue * 100, 0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sValPercent = "0";
                    }

                    if (oPOSDashboard.TargetSalesQty != 0)
                    {
                        oPOSDashboard.sQtyPercent = Math.Round(Convert.ToDouble(oPOSDashboard.ActualSalesQty) / oPOSDashboard.TargetSalesQty * 100, 0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sQtyPercent = "0";
                    }
                    InnerList.Add(oPOSDashboard);
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

        public void WeekSalesRT(DateTime dFromDate, DateTime dToDate, int nChannel, string sSalesType, int nSalesPersonID, int nMAGID, int nBrandID)
        {
            dToDate = dToDate.AddDays(1);
            int nYear = dFromDate.Year;
            int nMonth = dFromDate.Month;


            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select WeekNo, sum(Target) as Target, Sum(TargetQty) as TargetQty, Sum(Actual) as Actual, Sum(ActualQty) as ActualQty from  " +
                       " ( " +
                       " Select WeekNo, Sum(TargetAmount) as Target, Sum(TargetQty) as TargetQty, 0 as Actual, 0 as ActualQty from[dbo].[t_PlanExecutiveLeadTarget] where CustomerID=" + Utility.CustomerID+" and TargetType = " + (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty + " " +
                       " and TMonth = " + nMonth + " and TYear = " + nYear + " ";

            if (nChannel != 0)
            {
                sSql += " and Channel = " + nChannel + " ";
            }
            if (nSalesPersonID != 0)
            {
                sSql += " and SalesPersonID = " + nSalesPersonID + " ";
            }
            if (nMAGID != 0)
            {
                sSql += " and MAGID = " + nMAGID + " ";
            }
            if (nBrandID != 0)
            {
                sSql += " and BrandID = " + nBrandID + " ";
            }

            sSql += " Group by WeekNo " +
                       " UNION ALL " +
                       " Select WeekNo, 0 as Target, 0 as TargetQty, Sum(GrossSales + OC - VAT - Discount) as Actual, sum(SalesQty) as ActualQty " +
                       " From " +
                       " ( " +
                       " Select WeekNo, " +
                       " isnull((sum(crqty) - sum(drqty)), 0) as SalesQty, isnull((sum(crGrossSales) - sum(drGrossSales)), 0) as GrossSales, " +
                       " isnull((sum(crDiscount) - sum(drDiscount)), 0) as Discount, isnull((sum(crOC) - sum(drOC)), 0) as OC, " +
                       " isnull((sum(crCOGS) - sum(drCOGS)), 0) as COGS, isnull((sum(crVAT) - sum(drVAT)), 0) as VAT " +
                       " From " +
                       " ( " +
                       " Select SalesPersonID, SalesType, TYear, WeekNo, TMonth, ProductID, sum(quantity) as crqty, " +
                       " 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, " +
                       " sum(Discount) as crDiscount, 0 as drDiscount, sum(OC) as crOC, 0 as drOC, sum(COGS) as crCOGS, " +
                       " 0 as drCOGS, sum(VAT) as crVAT, 0 as drVAT  from " +
                       " ( " +
                       " Select SalesPersonID, SalesType, a.InvoiceID, " +
                       " WeekNo, TYear, TMonth, ProductID, Quantity, (Quantity * unitprice) as GrossSales, " +
                       " (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                       " (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                       " from " +
                       " ( " +
                       " select SalesPersonID, SalesType, sa.InvoiceID, WeekNo, year(invoicedate) as TYear, " +
                       " month(invoicedate) as TMonth, ProductID, UnitPrice, Costprice, " +
                       " TradePrice, VatAmount, Discount, quantity " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd, t_RetailConsumer sc, t_CalendarWeek " +
                       " where sa.WarehouseID=" + Utility.WarehouseID+" and sa.invoiceid = sd.invoiceid and sa.SundryCustomerID = sc.ConsumerID and " +
                       " sa.WarehouseID=sc.WarehouseID and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                       " and convert(datetime, (convert(varchar(12), InvoiceDate, 106))) between fromdate and todate " +
                       " and invoicetypeid in (1, 2, 4, 5)and invoicestatus not in (3) " +
                       " ) as a " +
                       " left outer join " +
                       " ( " +
                       " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, " +
                       " isnull((OtherCharge / sum(quantity)), 0) as AvgOC  from t_salesinvoice sa, t_salesinvoicedetail sd " +
                       " where sa.WarehouseID=" + Utility.WarehouseID + " and sa.invoiceid = sd.invoiceid and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  and invoicetypeid in (1, 2, 4, 5) and " +
                       " invoicestatus not in (3)   group by SalesPersonID, sa.InvoiceID, Discount, OtherCharge " +
                       " ) as b " +
                       " on a.invoiceid = b.invoiceid " +
                       " ) as final  Group By SalesPersonID, SalesType, TYear, TMonth, WeekNo, ProductID " +
                       " Union all " +
                       " Select SalesPersonID, SalesType, TYear, WeekNo, TMonth, ProductID, 0 as crqty, " +
                       " sum(quantity) as drqty, 0 as crGrossSales, sum(GrossSales) as drGrossSales, " +
                       " 0 as crDiscount, sum(Discount) as drDiscount, 0 as crOC, sum(OC) as drOC, " +
                       " 0 as crCOGS, sum(COGS) as drCOGS, 0 as crVAT, sum(VAT) as drVAT " +
                       " from( " +
                       " Select SalesPersonID, a.InvoiceID, WeekNo, TYear, TMonth, SalesType, ProductID, Quantity, " +
                       " (Quantity * unitprice) as GrossSales, (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                       " (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                       " from( " +
                       " select SalesPersonID, sa.InvoiceID, WeekNo, year(invoicedate) as TYear, month(invoicedate) as TMonth, " +
                       " SalesType, ProductID, UnitPrice, Costprice, TradePrice, VatAmount, Discount, quantity " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd, t_Retailconsumer sc, t_CalendarWeek " +
                       " where sa.WarehouseID=" + Utility.WarehouseID + " and sa.invoiceid = sd.invoiceid and sa.SundryCustomerID = sc.ConsumerID and " +
                       " sa.WarehouseID=sc.WarehouseID and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                       " and convert(datetime, (convert(varchar(12), InvoiceDate, 106))) between fromdate and todate " +
                       " and invoicetypeid in (6, 7, 9, 10, 12)and invoicestatus not in (3)) as a " +
                       " left outer join " +
                       " ( " +
                       " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, isnull((OtherCharge / sum(quantity)), 0) as AvgOC " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd " +
                       " where sa.WarehouseID=" + Utility.WarehouseID + " and sa.invoiceid = sd.invoiceid and invoicedate " +
                       " between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  and invoicetypeid in (6, 7, 9, 10, 12) and " +
                       " invoicestatus not in (3)   group by sa.InvoiceID, Discount, OtherCharge " +
                       " ) as b " +
                       " on a.invoiceid = b.invoiceid " +
                       " ) as final " +
                       " Group By SalesPersonID,SalesType,WeekNo,TYear,TMonth,ProductID " +
                       " )as FinalQuery, v_ProductDetails b Where FinalQuery.ProductID = b.ProductID and TYear = " + nYear + " and TMonth = " + nMonth + " ";
            if (sSalesType != "")
            {
                sSql += " and SalesType IN(" + sSalesType + ")  ";
            }

            if (nSalesPersonID != 0)
            {
                sSql += " and SalesPersonID = " + nSalesPersonID + " ";
            }
            if (nMAGID != 0)
            {
                sSql += " and MAGID = " + nMAGID + " ";
            }
            if (nBrandID != 0)
            {
                sSql += " and BrandID = " + nBrandID + " ";
            }
            sSql += " Group by  WeekNo )x Group by  WeekNo " +
                       " ) final group by WeekNo Order by WeekNo ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    POSDashboard oPOSDashboard = new POSDashboard();

                    oPOSDashboard.Week = reader["WeekNo"].ToString();
                    oPOSDashboard.TargetSalesValue = Math.Round((double)reader["Target"]);
                    oPOSDashboard.ActualSalesValue = Math.Round((double)reader["Actual"]);
                    oPOSDashboard.TargetSalesQty = Convert.ToInt32(reader["TargetQty"]);
                    oPOSDashboard.ActualSalesQty = Convert.ToInt32(reader["ActualQty"]);
                    if (oPOSDashboard.TargetSalesValue != 0)
                    {
                        oPOSDashboard.sValPercent = Math.Round(oPOSDashboard.ActualSalesValue / oPOSDashboard.TargetSalesValue * 100, 0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sValPercent = "0";
                    }

                    if (oPOSDashboard.TargetSalesQty != 0)
                    {
                        oPOSDashboard.sQtyPercent = Math.Round(Convert.ToDouble(oPOSDashboard.ActualSalesQty) / oPOSDashboard.TargetSalesQty * 100, 0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sQtyPercent = "0";
                    }
                    InnerList.Add(oPOSDashboard);
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

        public void MonthSales(DateTime dFromDate, DateTime dToDate, int nChannel, string sSalesType, int nSalesPersonID, int nMAGID, int nBrandID)
        {
            dToDate = dToDate.AddDays(1);
            int nYear = dFromDate.Year;

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select TMonth, sum(Target) as Target, Sum(TargetQty) as TargetQty, Sum(Actual) as Actual, Sum(ActualQty) as ActualQty from  " +
                       " ( " +
                       " Select TMonth, Sum(TargetAmount) as Target, Sum(TargetQty) as TargetQty, 0 as Actual, 0 as ActualQty from[dbo].[t_PlanExecutiveLeadTarget] where TargetType = " + (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty + " " +
                       " and TYear = " + nYear + " ";

            if (nChannel != 0)
            {
                sSql += " and Channel = " + nChannel + " ";
            }
            if (nSalesPersonID != 0)
            {
                sSql += " and SalesPersonID = " + nSalesPersonID + " ";
            }
            if (nMAGID != 0)
            {
                sSql += " and MAGID = " + nMAGID + " ";
            }
            if (nBrandID != 0)
            {
                sSql += " and BrandID = " + nBrandID + " ";
            }
            sSql += " Group by TMonth " +
                       " UNION ALL " +
                       " Select TMonth, 0 as Target, 0 as TargetQty, Sum(GrossSales + OC - VAT - Discount) as Actual, Sum(SalesQty) as ActualQty " +
                       " From " +
                       " ( " +
                       " Select TMonth, " +
                       " isnull((sum(crqty) - sum(drqty)), 0) as SalesQty, isnull((sum(crGrossSales) - sum(drGrossSales)), 0) as GrossSales, " +
                       " isnull((sum(crDiscount) - sum(drDiscount)), 0) as Discount, isnull((sum(crOC) - sum(drOC)), 0) as OC, " +
                       " isnull((sum(crCOGS) - sum(drCOGS)), 0) as COGS, isnull((sum(crVAT) - sum(drVAT)), 0) as VAT " +
                       " From " +
                       " ( " +
                       " Select SalesPersonID, SalesType, TYear, WeekNo, TMonth, ProductID, sum(quantity) as crqty, " +
                       " 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, " +
                       " sum(Discount) as crDiscount, 0 as drDiscount, sum(OC) as crOC, 0 as drOC, sum(COGS) as crCOGS, " +
                       " 0 as drCOGS, sum(VAT) as crVAT, 0 as drVAT  from " +
                       " ( " +
                       " Select SalesPersonID, SalesType, a.InvoiceID, " +
                       " WeekNo, TYear, TMonth, ProductID, Quantity, (Quantity * unitprice) as GrossSales, " +
                       " (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                       " (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                       " from " +
                       " ( " +
                       " select SalesPersonID, SalesType, sa.InvoiceID, WeekNo, year(invoicedate) as TYear, " +
                       " month(invoicedate) as TMonth, ProductID, UnitPrice, Costprice, " +
                       " TradePrice, VatAmount, Discount, quantity " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd, t_RetailConsumer sc, t_CalendarWeek " +
                       " where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID = sc.ConsumerID and " +
                       " invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                       " and convert(datetime, (convert(varchar(12), InvoiceDate, 106))) between fromdate and todate " +
                       " and invoicetypeid in (1, 2, 4, 5)and invoicestatus not in (3) " +
                       " ) as a " +
                       " left outer join " +
                       " ( " +
                       " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, " +
                       " isnull((OtherCharge / sum(quantity)), 0) as AvgOC  from t_salesinvoice sa, t_salesinvoicedetail sd " +
                       " where sa.invoiceid = sd.invoiceid and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  and invoicetypeid in (1, 2, 4, 5) and " +
                       " invoicestatus not in (3)   group by SalesPersonID, sa.InvoiceID, Discount, OtherCharge " +
                       " ) as b " +
                       " on a.invoiceid = b.invoiceid " +
                       " ) as final  Group By SalesPersonID, SalesType, TYear, TMonth, WeekNo, ProductID " +
                       " Union all " +
                       " Select SalesPersonID, SalesType, TYear, WeekNo, TMonth, ProductID, 0 as crqty, " +
                       " sum(quantity) as drqty, 0 as crGrossSales, sum(GrossSales) as drGrossSales, " +
                       " 0 as crDiscount, sum(Discount) as drDiscount, 0 as crOC, sum(OC) as drOC, " +
                       " 0 as crCOGS, sum(COGS) as drCOGS, 0 as crVAT, sum(VAT) as drVAT " +
                       " from( " +
                       " Select SalesPersonID, a.InvoiceID, WeekNo, TYear, TMonth, SalesType, ProductID, Quantity, " +
                       " (Quantity * unitprice) as GrossSales, (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                       " (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                       " from( " +
                       " select SalesPersonID, sa.InvoiceID, WeekNo, year(invoicedate) as TYear, month(invoicedate) as TMonth, " +
                       " SalesType, ProductID, UnitPrice, Costprice, TradePrice, VatAmount, Discount, quantity " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd, t_Retailconsumer sc, t_CalendarWeek " +
                       " where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID = sc.ConsumerID and " +
                       " invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                       " and convert(datetime, (convert(varchar(12), InvoiceDate, 106))) between fromdate and todate " +
                       " and invoicetypeid in (6, 7, 9, 10, 12)and invoicestatus not in (3)) as a " +
                       " left outer join " +
                       " ( " +
                       " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, isnull((OtherCharge / sum(quantity)), 0) as AvgOC " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd " +
                       " where sa.invoiceid = sd.invoiceid and invoicedate " +
                       " between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  and invoicetypeid in (6, 7, 9, 10, 12) and " +
                       " invoicestatus not in (3)   group by sa.InvoiceID, Discount, OtherCharge " +
                       " ) as b " +
                       " on a.invoiceid = b.invoiceid " +
                       " ) as final " +
                       " Group By SalesPersonID,SalesType,WeekNo,TYear,TMonth,ProductID " +
                       " )as FinalQuery, v_ProductDetails b Where FinalQuery.ProductID = b.ProductID and TYear = " + nYear + " ";
            if (sSalesType != "")
            {
                sSql += " and SalesType IN(" + sSalesType + ")  ";
            }

            if (nSalesPersonID != 0)
            {
                sSql += " and SalesPersonID = " + nSalesPersonID + " ";
            }
            if (nMAGID != 0)
            {
                sSql += " and MAGID = " + nMAGID + " ";
            }
            if (nBrandID != 0)
            {
                sSql += " and BrandID = " + nBrandID + " ";
            }

            sSql += " Group by  TMonth )x Group by TMonth " +
                       " ) final group by TMonth Order by TMonth ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    POSDashboard oPOSDashboard = new POSDashboard();

                    oPOSDashboard.sMonth = new DateTime(2010, (int)reader["TMonth"], 1).ToString("MMM");
                    oPOSDashboard.TargetSalesValue = Math.Round((double)reader["Target"]);
                    oPOSDashboard.ActualSalesValue = Math.Round((double)reader["Actual"]);
                    oPOSDashboard.TargetSalesQty = Convert.ToInt32(reader["TargetQty"]);
                    oPOSDashboard.ActualSalesQty = Convert.ToInt32(reader["ActualQty"]);
                    if (oPOSDashboard.TargetSalesValue != 0)
                    {
                        oPOSDashboard.sValPercent = Math.Round(oPOSDashboard.ActualSalesValue / oPOSDashboard.TargetSalesValue * 100, 0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sValPercent = "0";
                    }

                    if (oPOSDashboard.TargetSalesQty != 0)
                    {
                        oPOSDashboard.sQtyPercent = Math.Round(Convert.ToDouble(oPOSDashboard.ActualSalesQty) / oPOSDashboard.TargetSalesQty * 100, 0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sQtyPercent = "0";
                    }
                    InnerList.Add(oPOSDashboard);
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

        public void MonthSalesRT(DateTime dFromDate, DateTime dToDate, int nChannel, string sSalesType, int nSalesPersonID, int nMAGID, int nBrandID)
        {
            dToDate = dToDate.AddDays(1);
            int nYear = dFromDate.Year;

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select TMonth, sum(Target) as Target, Sum(TargetQty) as TargetQty, Sum(Actual) as Actual, Sum(ActualQty) as ActualQty from  " +
                       " ( " +
                       " Select TMonth, Sum(TargetAmount) as Target, Sum(TargetQty) as TargetQty, 0 as Actual, 0 as ActualQty from[dbo].[t_PlanExecutiveLeadTarget] where CustomerID=" + Utility.CustomerID + " and TargetType = " + (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty + " " +
                       " and TYear = " + nYear + " ";

            if (nChannel != 0)
            {
                sSql += " and Channel = " + nChannel + " ";
            }
            if (nSalesPersonID != 0)
            {
                sSql += " and SalesPersonID = " + nSalesPersonID + " ";
            }
            if (nMAGID != 0)
            {
                sSql += " and MAGID = " + nMAGID + " ";
            }
            if (nBrandID != 0)
            {
                sSql += " and BrandID = " + nBrandID + " ";
            }
            sSql += " Group by TMonth " +
                       " UNION ALL " +
                       " Select TMonth, 0 as Target, 0 as TargetQty, Sum(GrossSales + OC - VAT - Discount) as Actual, Sum(SalesQty) as ActualQty " +
                       " From " +
                       " ( " +
                       " Select TMonth, " +
                       " isnull((sum(crqty) - sum(drqty)), 0) as SalesQty, isnull((sum(crGrossSales) - sum(drGrossSales)), 0) as GrossSales, " +
                       " isnull((sum(crDiscount) - sum(drDiscount)), 0) as Discount, isnull((sum(crOC) - sum(drOC)), 0) as OC, " +
                       " isnull((sum(crCOGS) - sum(drCOGS)), 0) as COGS, isnull((sum(crVAT) - sum(drVAT)), 0) as VAT " +
                       " From " +
                       " ( " +
                       " Select SalesPersonID, SalesType, TYear, WeekNo, TMonth, ProductID, sum(quantity) as crqty, " +
                       " 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, " +
                       " sum(Discount) as crDiscount, 0 as drDiscount, sum(OC) as crOC, 0 as drOC, sum(COGS) as crCOGS, " +
                       " 0 as drCOGS, sum(VAT) as crVAT, 0 as drVAT  from " +
                       " ( " +
                       " Select SalesPersonID, SalesType, a.InvoiceID, " +
                       " WeekNo, TYear, TMonth, ProductID, Quantity, (Quantity * unitprice) as GrossSales, " +
                       " (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                       " (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                       " from " +
                       " ( " +
                       " select SalesPersonID, SalesType, sa.InvoiceID, WeekNo, year(invoicedate) as TYear, " +
                       " month(invoicedate) as TMonth, ProductID, UnitPrice, Costprice, " +
                       " TradePrice, VatAmount, Discount, quantity " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd, t_RetailConsumer sc, t_CalendarWeek " +
                       " where sa.WarehouseID=" + Utility.WarehouseID+" and sa.invoiceid = sd.invoiceid and sa.SundryCustomerID = sc.ConsumerID and sa.WarehouseID = sc.WarehouseID and " +
                       " invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                       " and convert(datetime, (convert(varchar(12), InvoiceDate, 106))) between fromdate and todate " +
                       " and invoicetypeid in (1, 2, 4, 5)and invoicestatus not in (3) " +
                       " ) as a " +
                       " left outer join " +
                       " ( " +
                       " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, " +
                       " isnull((OtherCharge / sum(quantity)), 0) as AvgOC  from t_salesinvoice sa, t_salesinvoicedetail sd " +
                       " where sa.WarehouseID=" + Utility.WarehouseID + " and sa.invoiceid = sd.invoiceid and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  and invoicetypeid in (1, 2, 4, 5) and " +
                       " invoicestatus not in (3)   group by SalesPersonID, sa.InvoiceID, Discount, OtherCharge " +
                       " ) as b " +
                       " on a.invoiceid = b.invoiceid " +
                       " ) as final  Group By SalesPersonID, SalesType, TYear, TMonth, WeekNo, ProductID " +
                       " Union all " +
                       " Select SalesPersonID, SalesType, TYear, WeekNo, TMonth, ProductID, 0 as crqty, " +
                       " sum(quantity) as drqty, 0 as crGrossSales, sum(GrossSales) as drGrossSales, " +
                       " 0 as crDiscount, sum(Discount) as drDiscount, 0 as crOC, sum(OC) as drOC, " +
                       " 0 as crCOGS, sum(COGS) as drCOGS, 0 as crVAT, sum(VAT) as drVAT " +
                       " from( " +
                       " Select SalesPersonID, a.InvoiceID, WeekNo, TYear, TMonth, SalesType, ProductID, Quantity, " +
                       " (Quantity * unitprice) as GrossSales, (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                       " (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                       " from( " +
                       " select SalesPersonID, sa.InvoiceID, WeekNo, year(invoicedate) as TYear, month(invoicedate) as TMonth, " +
                       " SalesType, ProductID, UnitPrice, Costprice, TradePrice, VatAmount, Discount, quantity " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd, t_Retailconsumer sc, t_CalendarWeek " +
                       " where sa.WarehouseID=" + Utility.WarehouseID + " and sa.invoiceid = sd.invoiceid and sa.SundryCustomerID = sc.ConsumerID and " +
                       " sa.WarehouseID = sc.WarehouseID and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                       " and convert(datetime, (convert(varchar(12), InvoiceDate, 106))) between fromdate and todate " +
                       " and invoicetypeid in (6, 7, 9, 10, 12)and invoicestatus not in (3)) as a " +
                       " left outer join " +
                       " ( " +
                       " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, isnull((OtherCharge / sum(quantity)), 0) as AvgOC " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd " +
                       " where sa.WarehouseID=" + Utility.WarehouseID + " and sa.invoiceid = sd.invoiceid and invoicedate " +
                       " between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  and invoicetypeid in (6, 7, 9, 10, 12) and " +
                       " invoicestatus not in (3)   group by sa.InvoiceID, Discount, OtherCharge " +
                       " ) as b " +
                       " on a.invoiceid = b.invoiceid " +
                       " ) as final " +
                       " Group By SalesPersonID,SalesType,WeekNo,TYear,TMonth,ProductID " +
                       " )as FinalQuery, v_ProductDetails b Where FinalQuery.ProductID = b.ProductID and TYear = " + nYear + " ";
            if (sSalesType != "")
            {
                sSql += " and SalesType IN(" + sSalesType + ")  ";
            }

            if (nSalesPersonID != 0)
            {
                sSql += " and SalesPersonID = " + nSalesPersonID + " ";
            }
            if (nMAGID != 0)
            {
                sSql += " and MAGID = " + nMAGID + " ";
            }
            if (nBrandID != 0)
            {
                sSql += " and BrandID = " + nBrandID + " ";
            }

            sSql += " Group by  TMonth )x Group by TMonth " +
                       " ) final group by TMonth Order by TMonth ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    POSDashboard oPOSDashboard = new POSDashboard();

                    oPOSDashboard.sMonth = new DateTime(2010, (int)reader["TMonth"], 1).ToString("MMM");
                    oPOSDashboard.TargetSalesValue = Math.Round((double)reader["Target"]);
                    oPOSDashboard.ActualSalesValue = Math.Round((double)reader["Actual"]);
                    oPOSDashboard.TargetSalesQty = Convert.ToInt32(reader["TargetQty"]);
                    oPOSDashboard.ActualSalesQty = Convert.ToInt32(reader["ActualQty"]);
                    if (oPOSDashboard.TargetSalesValue != 0)
                    {
                        oPOSDashboard.sValPercent = Math.Round(oPOSDashboard.ActualSalesValue / oPOSDashboard.TargetSalesValue * 100, 0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sValPercent = "0";
                    }

                    if (oPOSDashboard.TargetSalesQty != 0)
                    {
                        oPOSDashboard.sQtyPercent = Math.Round(Convert.ToDouble(oPOSDashboard.ActualSalesQty) / oPOSDashboard.TargetSalesQty * 100, 0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sQtyPercent = "0";
                    }
                    InnerList.Add(oPOSDashboard);
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

        public void MAGSales(DateTime dFromDate, DateTime dToDate, int nChannel, string sSalesType, int nSalesPersonID, int nBrandID)
        {
            dToDate = dToDate.AddDays(1);
            int nYear = dFromDate.Year;
            int nMonth = dFromDate.Month;


            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select MAGName, MAGSort, sum(Target) as Target, Sum(TargetQty) as TargetQty, Sum(Actual) as Actual, Sum(ActualQty) as ActualQty from  " +
                       " ( " +
                       " Select MAGName, MAGSort, Sum(TargetAmount) as Target, Sum(TargetQty) as TargetQty, 0 as Actual, 0 as ActualQty from [dbo].[t_PlanExecutiveLeadTarget] a, " +
                       " (select PdtGroupID as MAGID, PdtGroupName as MAGName, POS as MAGSort from t_ProductGroup where PdtGroupType = 2) b "+
                       " where a.MAGID = b.MAGID and TargetType = " + (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty + " " +
                       " and TMonth = " + nMonth + " and TYear = " + nYear + " ";

            if (nChannel != 0)
            {
                sSql += " and Channel = " + nChannel + " ";
            }
            if (nSalesPersonID != 0)
            {
                sSql += " and SalesPersonID = " + nSalesPersonID + " ";
            }
            if (nBrandID != 0)
            {
                sSql += " and BrandID = " + nBrandID + " ";
            }

            sSql += " Group by MAGName, MAGSort " +
                       " UNION ALL " +
                       " Select MAGName, MAGSort, 0 as Target, 0 as TargetQty, (GrossSales + OC - VAT - Discount) as Actual, SalesQty as ActualQty " +
                       " From " +
                       " ( " +
                       " Select MAGName, MAGSort, " +
                       " isnull((sum(crqty) - sum(drqty)), 0) as SalesQty, isnull((sum(crGrossSales) - sum(drGrossSales)), 0) as GrossSales, " +
                       " isnull((sum(crDiscount) - sum(drDiscount)), 0) as Discount, isnull((sum(crOC) - sum(drOC)), 0) as OC, " +
                       " isnull((sum(crCOGS) - sum(drCOGS)), 0) as COGS, isnull((sum(crVAT) - sum(drVAT)), 0) as VAT " +
                       " From " +
                       " ( " +
                       " Select SalesPersonID, SalesType, TYear, WeekNo, TMonth, ProductID, sum(quantity) as crqty, " +
                       " 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, " +
                       " sum(Discount) as crDiscount, 0 as drDiscount, sum(OC) as crOC, 0 as drOC, sum(COGS) as crCOGS, " +
                       " 0 as drCOGS, sum(VAT) as crVAT, 0 as drVAT  from " +
                       " ( " +
                       " Select SalesPersonID, SalesType, a.InvoiceID, " +
                       " WeekNo, TYear, TMonth, ProductID, Quantity, (Quantity * unitprice) as GrossSales, " +
                       " (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                       " (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                       " from " +
                       " ( " +
                       " select SalesPersonID, SalesType, sa.InvoiceID, WeekNo, year(invoicedate) as TYear, " +
                       " month(invoicedate) as TMonth, ProductID, UnitPrice, Costprice, " +
                       " TradePrice, VatAmount, Discount, quantity " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd, t_RetailConsumer sc, t_CalendarWeek " +
                       " where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID = sc.ConsumerID and " +
                       " invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                       " and convert(datetime, (convert(varchar(12), InvoiceDate, 106))) between fromdate and todate " +
                       " and invoicetypeid in (1, 2, 4, 5)and invoicestatus not in (3) " +
                       " ) as a " +
                       " left outer join " +
                       " ( " +
                       " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, " +
                       " isnull((OtherCharge / sum(quantity)), 0) as AvgOC  from t_salesinvoice sa, t_salesinvoicedetail sd " +
                       " where sa.invoiceid = sd.invoiceid and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  and invoicetypeid in (1, 2, 4, 5) and " +
                       " invoicestatus not in (3)   group by SalesPersonID, sa.InvoiceID, Discount, OtherCharge " +
                       " ) as b " +
                       " on a.invoiceid = b.invoiceid " +
                       " ) as final  Group By SalesPersonID, SalesType, TYear, TMonth, WeekNo, ProductID " +
                       " Union all " +
                       " Select SalesPersonID, SalesType, TYear, WeekNo, TMonth, ProductID, 0 as crqty, " +
                       " sum(quantity) as drqty, 0 as crGrossSales, sum(GrossSales) as drGrossSales, " +
                       " 0 as crDiscount, sum(Discount) as drDiscount, 0 as crOC, sum(OC) as drOC, " +
                       " 0 as crCOGS, sum(COGS) as drCOGS, 0 as crVAT, sum(VAT) as drVAT " +
                       " from( " +
                       " Select SalesPersonID, a.InvoiceID, WeekNo, TYear, TMonth, SalesType, ProductID, Quantity, " +
                       " (Quantity * unitprice) as GrossSales, (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                       " (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                       " from( " +
                       " select SalesPersonID, sa.InvoiceID, WeekNo, year(invoicedate) as TYear, month(invoicedate) as TMonth, " +
                       " SalesType, ProductID, UnitPrice, Costprice, TradePrice, VatAmount, Discount, quantity " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd, t_Retailconsumer sc, t_CalendarWeek " +
                       " where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID = sc.ConsumerID and " +
                       " invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                       " and convert(datetime, (convert(varchar(12), InvoiceDate, 106))) between fromdate and todate " +
                       " and invoicetypeid in (6, 7, 9, 10, 12)and invoicestatus not in (3)) as a " +
                       " left outer join " +
                       " ( " +
                       " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, isnull((OtherCharge / sum(quantity)), 0) as AvgOC " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd " +
                       " where sa.invoiceid = sd.invoiceid and invoicedate " +
                       " between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  and invoicetypeid in (6, 7, 9, 10, 12) and " +
                       " invoicestatus not in (3)   group by sa.InvoiceID, Discount, OtherCharge " +
                       " ) as b " +
                       " on a.invoiceid = b.invoiceid " +
                       " ) as final " +
                       " Group By SalesPersonID,SalesType,WeekNo,TYear,TMonth,ProductID " +
                       " )as FinalQuery, v_ProductDetails b Where FinalQuery.ProductID = b.ProductID and TYear = " + nYear + " and TMonth = " + nMonth + " ";
            if (sSalesType != "")
            {
                sSql += " and SalesType IN(" + sSalesType + ")  ";
            }

            if (nSalesPersonID != 0)
            {
                sSql += " and SalesPersonID = " + nSalesPersonID + " ";
            }
            if (nBrandID != 0)
            {
                sSql += " and BrandID = " + nBrandID + " ";
            }
            sSql += " Group by  MAGName, MAGSort )x " +
                       " ) final Group by MAGName, MAGSort having sum(Target) + Sum(Actual) > 0 Order by MAGSort ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    POSDashboard oPOSDashboard = new POSDashboard();

                    oPOSDashboard.sMAGName = reader["MAGName"].ToString();
                    oPOSDashboard.TargetSalesValue = Math.Round((double)reader["Target"]);
                    oPOSDashboard.ActualSalesValue = Math.Round((double)reader["Actual"]);
                    oPOSDashboard.TargetSalesQty = Convert.ToInt32(reader["TargetQty"]);
                    oPOSDashboard.ActualSalesQty = Convert.ToInt32(reader["ActualQty"]);
                    if (oPOSDashboard.TargetSalesValue != 0)
                    {
                        oPOSDashboard.sValPercent = Math.Round(oPOSDashboard.ActualSalesValue / oPOSDashboard.TargetSalesValue * 100,0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sValPercent = "0";
                    }

                    if (oPOSDashboard.TargetSalesQty != 0)
                    {
                        oPOSDashboard.sQtyPercent = Math.Round(Convert.ToDouble(oPOSDashboard.ActualSalesQty) / oPOSDashboard.TargetSalesQty * 100,0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sQtyPercent = "0";
                    }

                    InnerList.Add(oPOSDashboard);
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

        public void MAGSalesRT(DateTime dFromDate, DateTime dToDate, int nChannel, string sSalesType, int nSalesPersonID, int nBrandID)
        {
            dToDate = dToDate.AddDays(1);
            int nYear = dFromDate.Year;
            int nMonth = dFromDate.Month;


            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select MAGName, MAGSort, sum(Target) as Target, Sum(TargetQty) as TargetQty, Sum(Actual) as Actual, Sum(ActualQty) as ActualQty from  " +
                       " ( " +
                       " Select MAGName, MAGSort, Sum(TargetAmount) as Target, Sum(TargetQty) as TargetQty, 0 as Actual, 0 as ActualQty from [dbo].[t_PlanExecutiveLeadTarget] a, " +
                       " (select PdtGroupID as MAGID, PdtGroupName as MAGName, POS as MAGSort from t_ProductGroup where PdtGroupType = 2) b " +
                       " where a.CustomerID=" + Utility.CustomerID + " and a.MAGID = b.MAGID and TargetType = " + (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty + " " +
                       " and TMonth = " + nMonth + " and TYear = " + nYear + " ";

            if (nChannel != 0)
            {
                sSql += " and Channel = " + nChannel + " ";
            }
            if (nSalesPersonID != 0)
            {
                sSql += " and SalesPersonID = " + nSalesPersonID + " ";
            }
            if (nBrandID != 0)
            {
                sSql += " and BrandID = " + nBrandID + " ";
            }

            sSql += " Group by MAGName, MAGSort " +
                       " UNION ALL " +
                       " Select MAGName, MAGSort, 0 as Target, 0 as TargetQty, (GrossSales + OC - VAT - Discount) as Actual, SalesQty as ActualQty " +
                       " From " +
                       " ( " +
                       " Select MAGName, MAGSort, " +
                       " isnull((sum(crqty) - sum(drqty)), 0) as SalesQty, isnull((sum(crGrossSales) - sum(drGrossSales)), 0) as GrossSales, " +
                       " isnull((sum(crDiscount) - sum(drDiscount)), 0) as Discount, isnull((sum(crOC) - sum(drOC)), 0) as OC, " +
                       " isnull((sum(crCOGS) - sum(drCOGS)), 0) as COGS, isnull((sum(crVAT) - sum(drVAT)), 0) as VAT " +
                       " From " +
                       " ( " +
                       " Select SalesPersonID, SalesType, TYear, WeekNo, TMonth, ProductID, sum(quantity) as crqty, " +
                       " 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, " +
                       " sum(Discount) as crDiscount, 0 as drDiscount, sum(OC) as crOC, 0 as drOC, sum(COGS) as crCOGS, " +
                       " 0 as drCOGS, sum(VAT) as crVAT, 0 as drVAT  from " +
                       " ( " +
                       " Select SalesPersonID, SalesType, a.InvoiceID, " +
                       " WeekNo, TYear, TMonth, ProductID, Quantity, (Quantity * unitprice) as GrossSales, " +
                       " (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                       " (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                       " from " +
                       " ( " +
                       " select SalesPersonID, SalesType, sa.InvoiceID, WeekNo, year(invoicedate) as TYear, " +
                       " month(invoicedate) as TMonth, ProductID, UnitPrice, Costprice, " +
                       " TradePrice, VatAmount, Discount, quantity " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd, t_RetailConsumer sc, t_CalendarWeek " +
                       " where sa.WarehouseID="+Utility.WarehouseID+" and sa.invoiceid = sd.invoiceid and sa.SundryCustomerID = sc.ConsumerID and " +
                       " sa.WarehouseID = sc.WarehouseID and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                       " and convert(datetime, (convert(varchar(12), InvoiceDate, 106))) between fromdate and todate " +
                       " and invoicetypeid in (1, 2, 4, 5)and invoicestatus not in (3) " +
                       " ) as a " +
                       " left outer join " +
                       " ( " +
                       " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, " +
                       " isnull((OtherCharge / sum(quantity)), 0) as AvgOC  from t_salesinvoice sa, t_salesinvoicedetail sd " +
                       " where sa.WarehouseID=" + Utility.WarehouseID + " and sa.invoiceid = sd.invoiceid and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  and invoicetypeid in (1, 2, 4, 5) and " +
                       " invoicestatus not in (3)   group by SalesPersonID, sa.InvoiceID, Discount, OtherCharge " +
                       " ) as b " +
                       " on a.invoiceid = b.invoiceid " +
                       " ) as final  Group By SalesPersonID, SalesType, TYear, TMonth, WeekNo, ProductID " +
                       " Union all " +
                       " Select SalesPersonID, SalesType, TYear, WeekNo, TMonth, ProductID, 0 as crqty, " +
                       " sum(quantity) as drqty, 0 as crGrossSales, sum(GrossSales) as drGrossSales, " +
                       " 0 as crDiscount, sum(Discount) as drDiscount, 0 as crOC, sum(OC) as drOC, " +
                       " 0 as crCOGS, sum(COGS) as drCOGS, 0 as crVAT, sum(VAT) as drVAT " +
                       " from( " +
                       " Select SalesPersonID, a.InvoiceID, WeekNo, TYear, TMonth, SalesType, ProductID, Quantity, " +
                       " (Quantity * unitprice) as GrossSales, (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                       " (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                       " from( " +
                       " select SalesPersonID, sa.InvoiceID, WeekNo, year(invoicedate) as TYear, month(invoicedate) as TMonth, " +
                       " SalesType, ProductID, UnitPrice, Costprice, TradePrice, VatAmount, Discount, quantity " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd, t_Retailconsumer sc, t_CalendarWeek " +
                       " where sa.WarehouseID=" + Utility.WarehouseID + " and sa.invoiceid = sd.invoiceid and sa.SundryCustomerID = sc.ConsumerID and " +
                       " sa.WarehouseID = sc.WarehouseID and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                       " and convert(datetime, (convert(varchar(12), InvoiceDate, 106))) between fromdate and todate " +
                       " and invoicetypeid in (6, 7, 9, 10, 12)and invoicestatus not in (3)) as a " +
                       " left outer join " +
                       " ( " +
                       " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, isnull((OtherCharge / sum(quantity)), 0) as AvgOC " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd " +
                       " where sa.WarehouseID=" + Utility.WarehouseID + " and sa.invoiceid = sd.invoiceid and invoicedate " +
                       " between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  and invoicetypeid in (6, 7, 9, 10, 12) and " +
                       " invoicestatus not in (3)   group by sa.InvoiceID, Discount, OtherCharge " +
                       " ) as b " +
                       " on a.invoiceid = b.invoiceid " +
                       " ) as final " +
                       " Group By SalesPersonID,SalesType,WeekNo,TYear,TMonth,ProductID " +
                       " )as FinalQuery, v_ProductDetails b Where FinalQuery.ProductID = b.ProductID and TYear = " + nYear + " and TMonth = " + nMonth + " ";
            if (sSalesType != "")
            {
                sSql += " and SalesType IN(" + sSalesType + ")  ";
            }

            if (nSalesPersonID != 0)
            {
                sSql += " and SalesPersonID = " + nSalesPersonID + " ";
            }
            if (nBrandID != 0)
            {
                sSql += " and BrandID = " + nBrandID + " ";
            }
            sSql += " Group by  MAGName, MAGSort )x " +
                       " ) final Group by MAGName, MAGSort having sum(Target) + Sum(Actual) > 0 Order by MAGSort ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    POSDashboard oPOSDashboard = new POSDashboard();

                    oPOSDashboard.sMAGName = reader["MAGName"].ToString();
                    oPOSDashboard.TargetSalesValue = Math.Round((double)reader["Target"]);
                    oPOSDashboard.ActualSalesValue = Math.Round((double)reader["Actual"]);
                    oPOSDashboard.TargetSalesQty = Convert.ToInt32(reader["TargetQty"]);
                    oPOSDashboard.ActualSalesQty = Convert.ToInt32(reader["ActualQty"]);
                    if (oPOSDashboard.TargetSalesValue != 0)
                    {
                        oPOSDashboard.sValPercent = Math.Round(oPOSDashboard.ActualSalesValue / oPOSDashboard.TargetSalesValue * 100, 0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sValPercent = "0";
                    }

                    if (oPOSDashboard.TargetSalesQty != 0)
                    {
                        oPOSDashboard.sQtyPercent = Math.Round(Convert.ToDouble(oPOSDashboard.ActualSalesQty) / oPOSDashboard.TargetSalesQty * 100, 0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sQtyPercent = "0";
                    }

                    InnerList.Add(oPOSDashboard);
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

        public void BrandSales(DateTime dFromDate, DateTime dToDate, int nChannel, string sSalesType, int nSalesPersonID, int nMAGID)
        {
            dToDate = dToDate.AddDays(1);
            int nYear = dFromDate.Year;
            int nMonth = dFromDate.Month;


            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select BrandName, BrandSort, sum(Target) as Target, Sum(TargetQty) as TargetQty, Sum(Actual) as Actual, Sum(ActualQty) as ActualQty from  " +
                       " ( " +
                       " Select BrandName, BrandSort, Sum(TargetAmount) as Target, Sum(TargetQty) as TargetQty, 0 as Actual, 0 as ActualQty from [dbo].[t_PlanExecutiveLeadTarget] a, " +
                       " (select BrandID, BrandDesc as BrandName, BrandPos as BrandSort from t_Brand) b " +
                       " where a.BrandID = b.BrandID and TargetType = " + (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty + " " +
                       " and TMonth = " + nMonth + " and TYear = " + nYear + " ";

            if (nChannel != 0)
            {
                sSql += " and Channel = " + nChannel + " ";
            }
            if (nSalesPersonID != 0)
            {
                sSql += " and SalesPersonID = " + nSalesPersonID + " ";
            }
            if (nMAGID != 0)
            {
                sSql += " and MAGID = " + nMAGID + " ";
            }

            sSql += " Group by BrandName, BrandSort " +
                       " UNION ALL " +
                       " Select BrandName, BrandSort, 0 as Target, 0 as TargetQty, (GrossSales + OC - VAT - Discount) as Actual, SalesQty as ActualQty " +
                       " From " +
                       " ( " +
                       " Select BrandDesc as BrandName, BrandSort, " +
                       " isnull((sum(crqty) - sum(drqty)), 0) as SalesQty, isnull((sum(crGrossSales) - sum(drGrossSales)), 0) as GrossSales, " +
                       " isnull((sum(crDiscount) - sum(drDiscount)), 0) as Discount, isnull((sum(crOC) - sum(drOC)), 0) as OC, " +
                       " isnull((sum(crCOGS) - sum(drCOGS)), 0) as COGS, isnull((sum(crVAT) - sum(drVAT)), 0) as VAT " +
                       " From " +
                       " ( " +
                       " Select SalesPersonID, SalesType, TYear, WeekNo, TMonth, ProductID, sum(quantity) as crqty, " +
                       " 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, " +
                       " sum(Discount) as crDiscount, 0 as drDiscount, sum(OC) as crOC, 0 as drOC, sum(COGS) as crCOGS, " +
                       " 0 as drCOGS, sum(VAT) as crVAT, 0 as drVAT  from " +
                       " ( " +
                       " Select SalesPersonID, SalesType, a.InvoiceID, " +
                       " WeekNo, TYear, TMonth, ProductID, Quantity, (Quantity * unitprice) as GrossSales, " +
                       " (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                       " (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                       " from " +
                       " ( " +
                       " select SalesPersonID, SalesType, sa.InvoiceID, WeekNo, year(invoicedate) as TYear, " +
                       " month(invoicedate) as TMonth, ProductID, UnitPrice, Costprice, " +
                       " TradePrice, VatAmount, Discount, quantity " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd, t_RetailConsumer sc, t_CalendarWeek " +
                       " where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID = sc.ConsumerID and " +
                       " invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                       " and convert(datetime, (convert(varchar(12), InvoiceDate, 106))) between fromdate and todate " +
                       " and invoicetypeid in (1, 2, 4, 5)and invoicestatus not in (3) " +
                       " ) as a " +
                       " left outer join " +
                       " ( " +
                       " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, " +
                       " isnull((OtherCharge / sum(quantity)), 0) as AvgOC  from t_salesinvoice sa, t_salesinvoicedetail sd " +
                       " where sa.invoiceid = sd.invoiceid and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  and invoicetypeid in (1, 2, 4, 5) and " +
                       " invoicestatus not in (3)   group by SalesPersonID, sa.InvoiceID, Discount, OtherCharge " +
                       " ) as b " +
                       " on a.invoiceid = b.invoiceid " +
                       " ) as final  Group By SalesPersonID, SalesType, TYear, TMonth, WeekNo, ProductID " +
                       " Union all " +
                       " Select SalesPersonID, SalesType, TYear, WeekNo, TMonth, ProductID, 0 as crqty, " +
                       " sum(quantity) as drqty, 0 as crGrossSales, sum(GrossSales) as drGrossSales, " +
                       " 0 as crDiscount, sum(Discount) as drDiscount, 0 as crOC, sum(OC) as drOC, " +
                       " 0 as crCOGS, sum(COGS) as drCOGS, 0 as crVAT, sum(VAT) as drVAT " +
                       " from( " +
                       " Select SalesPersonID, a.InvoiceID, WeekNo, TYear, TMonth, SalesType, ProductID, Quantity, " +
                       " (Quantity * unitprice) as GrossSales, (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                       " (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                       " from( " +
                       " select SalesPersonID, sa.InvoiceID, WeekNo, year(invoicedate) as TYear, month(invoicedate) as TMonth, " +
                       " SalesType, ProductID, UnitPrice, Costprice, TradePrice, VatAmount, Discount, quantity " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd, t_Retailconsumer sc, t_CalendarWeek " +
                       " where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID = sc.ConsumerID and " +
                       " invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                       " and convert(datetime, (convert(varchar(12), InvoiceDate, 106))) between fromdate and todate " +
                       " and invoicetypeid in (6, 7, 9, 10, 12)and invoicestatus not in (3)) as a " +
                       " left outer join " +
                       " ( " +
                       " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, isnull((OtherCharge / sum(quantity)), 0) as AvgOC " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd " +
                       " where sa.invoiceid = sd.invoiceid and invoicedate " +
                       " between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  and invoicetypeid in (6, 7, 9, 10, 12) and " +
                       " invoicestatus not in (3)   group by sa.InvoiceID, Discount, OtherCharge " +
                       " ) as b " +
                       " on a.invoiceid = b.invoiceid " +
                       " ) as final " +
                       " Group By SalesPersonID,SalesType,WeekNo,TYear,TMonth,ProductID " +
                       " )as FinalQuery, v_ProductDetails b Where FinalQuery.ProductID = b.ProductID and TYear = " + nYear + " and TMonth = " + nMonth + " ";
            if (sSalesType != "")
            {
                sSql += " and SalesType IN(" + sSalesType + ")  ";
            }

            if (nSalesPersonID != 0)
            {
                sSql += " and SalesPersonID = " + nSalesPersonID + " ";
            }
            if (nMAGID != 0)
            {
                sSql += " and MAGID = " + nMAGID + " ";
            }
            sSql += " Group by  BrandDesc, BrandSort )x " +
                       " ) final Group by BrandName, BrandSort having sum(Target) + Sum(Actual) > 0 Order by BrandSort ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    POSDashboard oPOSDashboard = new POSDashboard();

                    oPOSDashboard.sBrandName = reader["BrandName"].ToString();
                    oPOSDashboard.TargetSalesValue = Math.Round((double)reader["Target"]);
                    oPOSDashboard.ActualSalesValue = Math.Round((double)reader["Actual"]);
                    oPOSDashboard.TargetSalesQty = Convert.ToInt32(reader["TargetQty"]);
                    oPOSDashboard.ActualSalesQty = Convert.ToInt32(reader["ActualQty"]);
                    if (oPOSDashboard.TargetSalesValue != 0)
                    {
                        oPOSDashboard.sValPercent = Math.Round(oPOSDashboard.ActualSalesValue / oPOSDashboard.TargetSalesValue * 100, 0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sValPercent = "0";
                    }

                    if (oPOSDashboard.TargetSalesQty != 0)
                    {
                        oPOSDashboard.sQtyPercent = Math.Round(Convert.ToDouble(oPOSDashboard.ActualSalesQty) / oPOSDashboard.TargetSalesQty * 100, 0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sQtyPercent = "0";
                    }

                    InnerList.Add(oPOSDashboard);
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
        public void BrandSalesRT(DateTime dFromDate, DateTime dToDate, int nChannel, string sSalesType, int nSalesPersonID, int nMAGID)
        {
            dToDate = dToDate.AddDays(1);
            int nYear = dFromDate.Year;
            int nMonth = dFromDate.Month;


            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select BrandName, BrandSort, sum(Target) as Target, Sum(TargetQty) as TargetQty, Sum(Actual) as Actual, Sum(ActualQty) as ActualQty from  " +
                       " ( " +
                       " Select BrandName, BrandSort, Sum(TargetAmount) as Target, Sum(TargetQty) as TargetQty, 0 as Actual, 0 as ActualQty from [dbo].[t_PlanExecutiveLeadTarget] a, " +
                       " (select BrandID, BrandDesc as BrandName, BrandPos as BrandSort from t_Brand) b " +
                       " where a.CustomerID=" + Utility.CustomerID + " and a.BrandID = b.BrandID and TargetType = " + (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty + " " +
                       " and TMonth = " + nMonth + " and TYear = " + nYear + " ";

            if (nChannel != 0)
            {
                sSql += " and Channel = " + nChannel + " ";
            }
            if (nSalesPersonID != 0)
            {
                sSql += " and SalesPersonID = " + nSalesPersonID + " ";
            }
            if (nMAGID != 0)
            {
                sSql += " and MAGID = " + nMAGID + " ";
            }

            sSql += " Group by BrandName, BrandSort " +
                       " UNION ALL " +
                       " Select BrandName, BrandSort, 0 as Target, 0 as TargetQty, (GrossSales + OC - VAT - Discount) as Actual, SalesQty as ActualQty " +
                       " From " +
                       " ( " +
                       " Select BrandDesc as BrandName, BrandSort, " +
                       " isnull((sum(crqty) - sum(drqty)), 0) as SalesQty, isnull((sum(crGrossSales) - sum(drGrossSales)), 0) as GrossSales, " +
                       " isnull((sum(crDiscount) - sum(drDiscount)), 0) as Discount, isnull((sum(crOC) - sum(drOC)), 0) as OC, " +
                       " isnull((sum(crCOGS) - sum(drCOGS)), 0) as COGS, isnull((sum(crVAT) - sum(drVAT)), 0) as VAT " +
                       " From " +
                       " ( " +
                       " Select SalesPersonID, SalesType, TYear, WeekNo, TMonth, ProductID, sum(quantity) as crqty, " +
                       " 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, " +
                       " sum(Discount) as crDiscount, 0 as drDiscount, sum(OC) as crOC, 0 as drOC, sum(COGS) as crCOGS, " +
                       " 0 as drCOGS, sum(VAT) as crVAT, 0 as drVAT  from " +
                       " ( " +
                       " Select SalesPersonID, SalesType, a.InvoiceID, " +
                       " WeekNo, TYear, TMonth, ProductID, Quantity, (Quantity * unitprice) as GrossSales, " +
                       " (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                       " (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                       " from " +
                       " ( " +
                       " select SalesPersonID, SalesType, sa.InvoiceID, WeekNo, year(invoicedate) as TYear, " +
                       " month(invoicedate) as TMonth, ProductID, UnitPrice, Costprice, " +
                       " TradePrice, VatAmount, Discount, quantity " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd, t_RetailConsumer sc, t_CalendarWeek " +
                       " where sa.WarehouseID="+Utility.WarehouseID+" and sa.invoiceid = sd.invoiceid and sa.SundryCustomerID = sc.ConsumerID and " +
                       " sa.WarehouseID=sc.WarehouseID and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                       " and convert(datetime, (convert(varchar(12), InvoiceDate, 106))) between fromdate and todate " +
                       " and invoicetypeid in (1, 2, 4, 5)and invoicestatus not in (3) " +
                       " ) as a " +
                       " left outer join " +
                       " ( " +
                       " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, " +
                       " isnull((OtherCharge / sum(quantity)), 0) as AvgOC  from t_salesinvoice sa, t_salesinvoicedetail sd " +
                       " where sa.WarehouseID=" + Utility.WarehouseID + " and sa.invoiceid = sd.invoiceid and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  and invoicetypeid in (1, 2, 4, 5) and " +
                       " invoicestatus not in (3)   group by SalesPersonID, sa.InvoiceID, Discount, OtherCharge " +
                       " ) as b " +
                       " on a.invoiceid = b.invoiceid " +
                       " ) as final  Group By SalesPersonID, SalesType, TYear, TMonth, WeekNo, ProductID " +
                       " Union all " +
                       " Select SalesPersonID, SalesType, TYear, WeekNo, TMonth, ProductID, 0 as crqty, " +
                       " sum(quantity) as drqty, 0 as crGrossSales, sum(GrossSales) as drGrossSales, " +
                       " 0 as crDiscount, sum(Discount) as drDiscount, 0 as crOC, sum(OC) as drOC, " +
                       " 0 as crCOGS, sum(COGS) as drCOGS, 0 as crVAT, sum(VAT) as drVAT " +
                       " from( " +
                       " Select SalesPersonID, a.InvoiceID, WeekNo, TYear, TMonth, SalesType, ProductID, Quantity, " +
                       " (Quantity * unitprice) as GrossSales, (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                       " (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                       " from( " +
                       " select SalesPersonID, sa.InvoiceID, WeekNo, year(invoicedate) as TYear, month(invoicedate) as TMonth, " +
                       " SalesType, ProductID, UnitPrice, Costprice, TradePrice, VatAmount, Discount, quantity " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd, t_Retailconsumer sc, t_CalendarWeek " +
                       " where sa.WarehouseID=" + Utility.WarehouseID + " and sa.invoiceid = sd.invoiceid and sa.SundryCustomerID = sc.ConsumerID and " +
                       " sa.WarehouseID=sc.WarehouseID and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                       " and convert(datetime, (convert(varchar(12), InvoiceDate, 106))) between fromdate and todate " +
                       " and invoicetypeid in (6, 7, 9, 10, 12)and invoicestatus not in (3)) as a " +
                       " left outer join " +
                       " ( " +
                       " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, isnull((OtherCharge / sum(quantity)), 0) as AvgOC " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd " +
                       " where sa.WarehouseID=" + Utility.WarehouseID + " and sa.invoiceid = sd.invoiceid and invoicedate " +
                       " between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  and invoicetypeid in (6, 7, 9, 10, 12) and " +
                       " invoicestatus not in (3)   group by sa.InvoiceID, Discount, OtherCharge " +
                       " ) as b " +
                       " on a.invoiceid = b.invoiceid " +
                       " ) as final " +
                       " Group By SalesPersonID,SalesType,WeekNo,TYear,TMonth,ProductID " +
                       " )as FinalQuery, v_ProductDetails b Where FinalQuery.ProductID = b.ProductID and TYear = " + nYear + " and TMonth = " + nMonth + " ";
            if (sSalesType != "")
            {
                sSql += " and SalesType IN(" + sSalesType + ")  ";
            }

            if (nSalesPersonID != 0)
            {
                sSql += " and SalesPersonID = " + nSalesPersonID + " ";
            }
            if (nMAGID != 0)
            {
                sSql += " and MAGID = " + nMAGID + " ";
            }
            sSql += " Group by  BrandDesc, BrandSort )x " +
                       " ) final Group by BrandName, BrandSort having sum(Target) + Sum(Actual) > 0 Order by BrandSort ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    POSDashboard oPOSDashboard = new POSDashboard();

                    oPOSDashboard.sBrandName = reader["BrandName"].ToString();
                    oPOSDashboard.TargetSalesValue = Math.Round((double)reader["Target"]);
                    oPOSDashboard.ActualSalesValue = Math.Round((double)reader["Actual"]);
                    oPOSDashboard.TargetSalesQty = Convert.ToInt32(reader["TargetQty"]);
                    oPOSDashboard.ActualSalesQty = Convert.ToInt32(reader["ActualQty"]);
                    if (oPOSDashboard.TargetSalesValue != 0)
                    {
                        oPOSDashboard.sValPercent = Math.Round(oPOSDashboard.ActualSalesValue / oPOSDashboard.TargetSalesValue * 100, 0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sValPercent = "0";
                    }

                    if (oPOSDashboard.TargetSalesQty != 0)
                    {
                        oPOSDashboard.sQtyPercent = Math.Round(Convert.ToDouble(oPOSDashboard.ActualSalesQty) / oPOSDashboard.TargetSalesQty * 100, 0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sQtyPercent = "0";
                    }

                    InnerList.Add(oPOSDashboard);
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

        public void EmpoyeeSales(DateTime dFromDate, DateTime dToDate, int nChannel, string sSalesType, int nTargetType, int nMAGID, int nBrandID)
        {
            dToDate = dToDate.AddDays(1);
            int nYear = dFromDate.Year;
            int nMonth = dFromDate.Month;


            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select SalesPersonID, EmployeeCode, EmployeeName, sum(Target) as Target, Sum(TargetQty) as TargetQty, Sum(Actual) as Actual, Sum(ActualQty) as ActualQty from  " +
                       " ( " +
                       " Select SalesPersonID, Sum(TargetAmount) as Target, Sum(TargetQty) as TargetQty, 0 as Actual, 0 as ActualQty from[dbo].[t_PlanExecutiveLeadTarget] where  TargetType = " + nTargetType + " " +
                       " and TMonth = " + nMonth + " and TYear = " + nYear + " ";

            if (nChannel != 0)
            {
                sSql += " and Channel = " + nChannel + " ";
            }
            if (nMAGID != 0)
            {
                sSql += " and MAGID = " + nMAGID + " ";
            }
            if (nBrandID != 0)
            {
                sSql += " and BrandID = " + nBrandID + " ";
            }

            sSql += " Group by SalesPersonID " +
                       " UNION ALL " +
                       " Select SalesPersonID, 0 as Target, 0 as TargetQty, Sum(GrossSales + OC - VAT - Discount) as Actual, sum(SalesQty) as ActualQty " +
                       " From " +
                       " ( " +
                       " Select SalesPersonID, " +
                       " isnull((sum(crqty) - sum(drqty)), 0) as SalesQty, isnull((sum(crGrossSales) - sum(drGrossSales)), 0) as GrossSales, " +
                       " isnull((sum(crDiscount) - sum(drDiscount)), 0) as Discount, isnull((sum(crOC) - sum(drOC)), 0) as OC, " +
                       " isnull((sum(crCOGS) - sum(drCOGS)), 0) as COGS, isnull((sum(crVAT) - sum(drVAT)), 0) as VAT " +
                       " From " +
                       " ( " +
                       " Select SalesPersonID, SalesType, TYear, WeekNo, TMonth, ProductID, sum(quantity) as crqty, " +
                       " 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, " +
                       " sum(Discount) as crDiscount, 0 as drDiscount, sum(OC) as crOC, 0 as drOC, sum(COGS) as crCOGS, " +
                       " 0 as drCOGS, sum(VAT) as crVAT, 0 as drVAT  from " +
                       " ( " +
                       " Select SalesPersonID, SalesType, a.InvoiceID, " +
                       " WeekNo, TYear, TMonth, ProductID, Quantity, (Quantity * unitprice) as GrossSales, " +
                       " (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                       " (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                       " from " +
                       " ( " +
                       " select SalesPersonID, SalesType, sa.InvoiceID, WeekNo, year(invoicedate) as TYear, " +
                       " month(invoicedate) as TMonth, ProductID, UnitPrice, Costprice, " +
                       " TradePrice, VatAmount, Discount, quantity " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd, t_RetailConsumer sc, t_CalendarWeek " +
                       " where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID = sc.ConsumerID and " +
                       " invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                       " and convert(datetime, (convert(varchar(12), InvoiceDate, 106))) between fromdate and todate " +
                       " and invoicetypeid in (1, 2, 4, 5)and invoicestatus not in (3) " +
                       " ) as a " +
                       " left outer join " +
                       " ( " +
                       " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, " +
                       " isnull((OtherCharge / sum(quantity)), 0) as AvgOC  from t_salesinvoice sa, t_salesinvoicedetail sd " +
                       " where sa.invoiceid = sd.invoiceid and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  and invoicetypeid in (1, 2, 4, 5) and " +
                       " invoicestatus not in (3)   group by SalesPersonID, sa.InvoiceID, Discount, OtherCharge " +
                       " ) as b " +
                       " on a.invoiceid = b.invoiceid " +
                       " ) as final  Group By SalesPersonID, SalesType, TYear, TMonth, WeekNo, ProductID " +
                       " Union all " +
                       " Select SalesPersonID, SalesType, TYear, WeekNo, TMonth, ProductID, 0 as crqty, " +
                       " sum(quantity) as drqty, 0 as crGrossSales, sum(GrossSales) as drGrossSales, " +
                       " 0 as crDiscount, sum(Discount) as drDiscount, 0 as crOC, sum(OC) as drOC, " +
                       " 0 as crCOGS, sum(COGS) as drCOGS, 0 as crVAT, sum(VAT) as drVAT " +
                       " from( " +
                       " Select SalesPersonID, a.InvoiceID, WeekNo, TYear, TMonth, SalesType, ProductID, Quantity, " +
                       " (Quantity * unitprice) as GrossSales, (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                       " (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                       " from( " +
                       " select SalesPersonID, sa.InvoiceID, WeekNo, year(invoicedate) as TYear, month(invoicedate) as TMonth, " +
                       " SalesType, ProductID, UnitPrice, Costprice, TradePrice, VatAmount, Discount, quantity " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd, t_Retailconsumer sc, t_CalendarWeek " +
                       " where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID = sc.ConsumerID and " +
                       " invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                       " and convert(datetime, (convert(varchar(12), InvoiceDate, 106))) between fromdate and todate " +
                       " and invoicetypeid in (6, 7, 9, 10, 12)and invoicestatus not in (3)) as a " +
                       " left outer join " +
                       " ( " +
                       " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, isnull((OtherCharge / sum(quantity)), 0) as AvgOC " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd " +
                       " where sa.invoiceid = sd.invoiceid and invoicedate " +
                       " between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  and invoicetypeid in (6, 7, 9, 10, 12) and " +
                       " invoicestatus not in (3)   group by sa.InvoiceID, Discount, OtherCharge " +
                       " ) as b " +
                       " on a.invoiceid = b.invoiceid " +
                       " ) as final " +
                       " Group By SalesPersonID,SalesType,WeekNo,TYear,TMonth,ProductID " +
                       " )as FinalQuery, v_ProductDetails b Where FinalQuery.ProductID = b.ProductID and TYear = " + nYear + " and TMonth = " + nMonth + " ";
            if (sSalesType != "")
            {
                sSql += " and SalesType IN(" + sSalesType + ")  ";
            }
            if (nMAGID != 0)
            {
                sSql += " and MAGID = " + nMAGID + " ";
            }
            if (nBrandID != 0)
            {
                sSql += " and BrandID = " + nBrandID + " ";
            }
            sSql += " Group by  SalesPersonID )x Group by  SalesPersonID " +
                       " ) final, t_Employee c where final.SalesPersonID = c.EmployeeID group by SalesPersonID, EmployeeCode, EmployeeName Order by EmployeeName  ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    POSDashboard oPOSDashboard = new POSDashboard();

                    oPOSDashboard.EmployeeCode = reader["EmployeeCode"].ToString();
                    oPOSDashboard.EmployeeName = reader["EmployeeName"].ToString();
                    oPOSDashboard.TargetSalesValue = Math.Round((double)reader["Target"]);
                    oPOSDashboard.ActualSalesValue = Math.Round((double)reader["Actual"]);
                    oPOSDashboard.TargetSalesQty = Convert.ToInt32(reader["TargetQty"]);
                    oPOSDashboard.ActualSalesQty = Convert.ToInt32(reader["ActualQty"]);
                    if (oPOSDashboard.TargetSalesValue != 0)
                    {
                        oPOSDashboard.sValPercent = Math.Round(oPOSDashboard.ActualSalesValue / oPOSDashboard.TargetSalesValue * 100, 0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sValPercent = "0";
                    }

                    if (oPOSDashboard.TargetSalesQty != 0)
                    {
                        oPOSDashboard.sQtyPercent = Math.Round(Convert.ToDouble(oPOSDashboard.ActualSalesQty) / oPOSDashboard.TargetSalesQty * 100, 0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sQtyPercent = "0";
                    }
                    InnerList.Add(oPOSDashboard);
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

        public void EmpoyeeSalesRT(DateTime dFromDate, DateTime dToDate, int nChannel, string sSalesType, int nTargetType, int nMAGID, int nBrandID)
        {
            dToDate = dToDate.AddDays(1);
            int nYear = dFromDate.Year;
            int nMonth = dFromDate.Month;


            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select SalesPersonID, EmployeeCode, EmployeeName, sum(Target) as Target, Sum(TargetQty) as TargetQty, Sum(Actual) as Actual, Sum(ActualQty) as ActualQty from  " +
                       " ( " +
                       " Select SalesPersonID, Sum(TargetAmount) as Target, Sum(TargetQty) as TargetQty, 0 as Actual, 0 as ActualQty from[dbo].[t_PlanExecutiveLeadTarget] where CustomerID=" + Utility.CustomerID + " and TargetType = " + nTargetType + " " +
                       " and TMonth = " + nMonth + " and TYear = " + nYear + " ";

            if (nChannel != 0)
            {
                sSql += " and Channel = " + nChannel + " ";
            }
            if (nMAGID != 0)
            {
                sSql += " and MAGID = " + nMAGID + " ";
            }
            if (nBrandID != 0)
            {
                sSql += " and BrandID = " + nBrandID + " ";
            }

            sSql += " Group by SalesPersonID " +
                       " UNION ALL " +
                       " Select SalesPersonID, 0 as Target, 0 as TargetQty, Sum(GrossSales + OC - VAT - Discount) as Actual, sum(SalesQty) as ActualQty " +
                       " From " +
                       " ( " +
                       " Select SalesPersonID, " +
                       " isnull((sum(crqty) - sum(drqty)), 0) as SalesQty, isnull((sum(crGrossSales) - sum(drGrossSales)), 0) as GrossSales, " +
                       " isnull((sum(crDiscount) - sum(drDiscount)), 0) as Discount, isnull((sum(crOC) - sum(drOC)), 0) as OC, " +
                       " isnull((sum(crCOGS) - sum(drCOGS)), 0) as COGS, isnull((sum(crVAT) - sum(drVAT)), 0) as VAT " +
                       " From " +
                       " ( " +
                       " Select SalesPersonID, SalesType, TYear, WeekNo, TMonth, ProductID, sum(quantity) as crqty, " +
                       " 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, " +
                       " sum(Discount) as crDiscount, 0 as drDiscount, sum(OC) as crOC, 0 as drOC, sum(COGS) as crCOGS, " +
                       " 0 as drCOGS, sum(VAT) as crVAT, 0 as drVAT  from " +
                       " ( " +
                       " Select SalesPersonID, SalesType, a.InvoiceID, " +
                       " WeekNo, TYear, TMonth, ProductID, Quantity, (Quantity * unitprice) as GrossSales, " +
                       " (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                       " (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                       " from " +
                       " ( " +
                       " select SalesPersonID, SalesType, sa.InvoiceID, WeekNo, year(invoicedate) as TYear, " +
                       " month(invoicedate) as TMonth, ProductID, UnitPrice, Costprice, " +
                       " TradePrice, VatAmount, Discount, quantity " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd, t_RetailConsumer sc, t_CalendarWeek " +
                       " where sa.WarehouseID=" + Utility.WarehouseID + " and sa.invoiceid = sd.invoiceid and sa.SundryCustomerID = sc.ConsumerID and " +
                       " sa.WarehouseID=sc.WarehouseID and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                       " and convert(datetime, (convert(varchar(12), InvoiceDate, 106))) between fromdate and todate " +
                       " and invoicetypeid in (1, 2, 4, 5)and invoicestatus not in (3) " +
                       " ) as a " +
                       " left outer join " +
                       " ( " +
                       " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, " +
                       " isnull((OtherCharge / sum(quantity)), 0) as AvgOC  from t_salesinvoice sa, t_salesinvoicedetail sd " +
                       " where sa.WarehouseID=" + Utility.WarehouseID + " and sa.invoiceid = sd.invoiceid and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  and invoicetypeid in (1, 2, 4, 5) and " +
                       " invoicestatus not in (3)   group by SalesPersonID, sa.InvoiceID, Discount, OtherCharge " +
                       " ) as b " +
                       " on a.invoiceid = b.invoiceid " +
                       " ) as final  Group By SalesPersonID, SalesType, TYear, TMonth, WeekNo, ProductID " +
                       " Union all " +
                       " Select SalesPersonID, SalesType, TYear, WeekNo, TMonth, ProductID, 0 as crqty, " +
                       " sum(quantity) as drqty, 0 as crGrossSales, sum(GrossSales) as drGrossSales, " +
                       " 0 as crDiscount, sum(Discount) as drDiscount, 0 as crOC, sum(OC) as drOC, " +
                       " 0 as crCOGS, sum(COGS) as drCOGS, 0 as crVAT, sum(VAT) as drVAT " +
                       " from( " +
                       " Select SalesPersonID, a.InvoiceID, WeekNo, TYear, TMonth, SalesType, ProductID, Quantity, " +
                       " (Quantity * unitprice) as GrossSales, (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                       " (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                       " from( " +
                       " select SalesPersonID, sa.InvoiceID, WeekNo, year(invoicedate) as TYear, month(invoicedate) as TMonth, " +
                       " SalesType, ProductID, UnitPrice, Costprice, TradePrice, VatAmount, Discount, quantity " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd, t_Retailconsumer sc, t_CalendarWeek " +
                       " where sa.WarehouseID=" + Utility.WarehouseID + " and sa.invoiceid = sd.invoiceid and sa.SundryCustomerID = sc.ConsumerID and " +
                       " sa.WarehouseID=sc.WarehouseID and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                       " and convert(datetime, (convert(varchar(12), InvoiceDate, 106))) between fromdate and todate " +
                       " and invoicetypeid in (6, 7, 9, 10, 12)and invoicestatus not in (3)) as a " +
                       " left outer join " +
                       " ( " +
                       " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, isnull((OtherCharge / sum(quantity)), 0) as AvgOC " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd " +
                       " where sa.WarehouseID=" + Utility.WarehouseID + " and sa.invoiceid = sd.invoiceid and invoicedate " +
                       " between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  and invoicetypeid in (6, 7, 9, 10, 12) and " +
                       " invoicestatus not in (3)   group by sa.InvoiceID, Discount, OtherCharge " +
                       " ) as b " +
                       " on a.invoiceid = b.invoiceid " +
                       " ) as final " +
                       " Group By SalesPersonID,SalesType,WeekNo,TYear,TMonth,ProductID " +
                       " )as FinalQuery, v_ProductDetails b Where FinalQuery.ProductID = b.ProductID and TYear = " + nYear + " and TMonth = " + nMonth + " ";
            if (sSalesType != "")
            {
                sSql += " and SalesType IN(" + sSalesType + ")  ";
            }
            if (nMAGID != 0)
            {
                sSql += " and MAGID = " + nMAGID + " ";
            }
            if (nBrandID != 0)
            {
                sSql += " and BrandID = " + nBrandID + " ";
            }
            sSql += " Group by  SalesPersonID )x Group by  SalesPersonID " +
                       " ) final, t_Employee c where final.SalesPersonID = c.EmployeeID group by SalesPersonID, EmployeeCode, EmployeeName Order by EmployeeName  ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    POSDashboard oPOSDashboard = new POSDashboard();

                    oPOSDashboard.EmployeeCode = reader["EmployeeCode"].ToString();
                    oPOSDashboard.EmployeeName = reader["EmployeeName"].ToString();
                    oPOSDashboard.TargetSalesValue = Math.Round((double)reader["Target"]);
                    oPOSDashboard.ActualSalesValue = Math.Round((double)reader["Actual"]);
                    oPOSDashboard.TargetSalesQty = Convert.ToInt32(reader["TargetQty"]);
                    oPOSDashboard.ActualSalesQty = Convert.ToInt32(reader["ActualQty"]);
                    if (oPOSDashboard.TargetSalesValue != 0)
                    {
                        oPOSDashboard.sValPercent = Math.Round(oPOSDashboard.ActualSalesValue / oPOSDashboard.TargetSalesValue * 100, 0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sValPercent = "0";
                    }

                    if (oPOSDashboard.TargetSalesQty != 0)
                    {
                        oPOSDashboard.sQtyPercent = Math.Round(Convert.ToDouble(oPOSDashboard.ActualSalesQty) / oPOSDashboard.TargetSalesQty * 100, 0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sQtyPercent = "0";
                    }
                    InnerList.Add(oPOSDashboard);
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
        public void EmpoyeeSalesLead(DateTime dFromDate, DateTime dToDate, int nChannel, string sSalesType, int nMAGID, int nBrandID)
        {
            dToDate = dToDate.AddDays(1);
            int nYear = dFromDate.Year;
            int nMonth = dFromDate.Month;


            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select SalesPersonID, EmployeeCode, EmployeeName, sum(Target) as Target, Sum(TargetQty) as TargetQty, Sum(Actual) as Actual, Sum(ActualQty) as ActualQty from  " +
                       " ( " +
                       " Select SalesPersonID, Sum(TargetAmount) as Target, Sum(TargetQty) as TargetQty, 0 as Actual, 0 as ActualQty from[dbo].[t_PlanExecutiveLeadTarget] where TargetType = " + (int)Dictionary.PlanVersionType.ExecutiveLeadTarget + " " +
                       " and TMonth = " + nMonth + " and TYear = " + nYear + " ";

            if (nChannel != 0)
            {
                sSql += " and Channel = " + nChannel + " ";
            }
            if (nMAGID != 0)
            {
                sSql += " and MAGID = " + nMAGID + " ";
            }
            if (nBrandID != 0)
            {
                sSql += " and BrandID = " + nBrandID + " ";
            }

            sSql += " Group by SalesPersonID " +
            " UNION ALL Select SalesPersonID, 0 as Target, 0 as TargetQty, " +
            " Sum(LeadAmount) as Actual, Sum(Qty) as ActualQty from " +
            " [dbo].[t_SalesLeadManagement] Where Status Not IN (3, 4) " +
            " and month(ExpExecuteDate) = "+ nMonth + " and year(ExpExecuteDate) = "+ nYear + " ";
            if (sSalesType != "")
            {
                sSql += " and CustomerType IN(" + sSalesType + ")  ";
            }
            if (nMAGID != 0)
            {
                sSql += " and MAGID = " + nMAGID + " ";
            }
            if (nBrandID != 0)
            {
                sSql += " and BrandID = " + nBrandID + " ";
            }
            sSql += " Group by  SalesPersonID ) final, t_Employee c where final.SalesPersonID = c.EmployeeID group by SalesPersonID, EmployeeCode, EmployeeName Order by EmployeeName  ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    POSDashboard oPOSDashboard = new POSDashboard();

                    oPOSDashboard.EmployeeCode = reader["EmployeeCode"].ToString();
                    oPOSDashboard.EmployeeName = reader["EmployeeName"].ToString();
                    oPOSDashboard.TargetSalesValue = Math.Round((double)reader["Target"]);
                    oPOSDashboard.ActualSalesValue = Math.Round((double)reader["Actual"]);
                    oPOSDashboard.TargetSalesQty = Convert.ToInt32(reader["TargetQty"]);
                    oPOSDashboard.ActualSalesQty = Convert.ToInt32(reader["ActualQty"]);
                    if (oPOSDashboard.TargetSalesValue != 0)
                    {
                        oPOSDashboard.sValPercent = Math.Round(oPOSDashboard.ActualSalesValue / oPOSDashboard.TargetSalesValue * 100, 0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sValPercent = "0";
                    }

                    if (oPOSDashboard.TargetSalesQty != 0)
                    {
                        oPOSDashboard.sQtyPercent = Math.Round(Convert.ToDouble(oPOSDashboard.ActualSalesQty) / oPOSDashboard.TargetSalesQty * 100, 0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sQtyPercent = "0";
                    }
                    InnerList.Add(oPOSDashboard);
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

        public void EmpoyeeSalesLeadRT(DateTime dFromDate, DateTime dToDate, int nChannel, string sSalesType, int nMAGID, int nBrandID)
        {
            dToDate = dToDate.AddDays(1);
            int nYear = dFromDate.Year;
            int nMonth = dFromDate.Month;


            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select SalesPersonID, EmployeeCode, EmployeeName, sum(Target) as Target, Sum(TargetQty) as TargetQty, Sum(Actual) as Actual, Sum(ActualQty) as ActualQty from  " +
                       " ( " +
                       " Select SalesPersonID, Sum(TargetAmount) as Target, Sum(TargetQty) as TargetQty, 0 as Actual, 0 as ActualQty from[dbo].[t_PlanExecutiveLeadTarget] where CustomerID=" + Utility.CustomerID+" and TargetType = " + (int)Dictionary.PlanVersionType.ExecutiveLeadTarget + " " +
                       " and TMonth = " + nMonth + " and TYear = " + nYear + " ";

            if (nChannel != 0)
            {
                sSql += " and Channel = " + nChannel + " ";
            }
            if (nMAGID != 0)
            {
                sSql += " and MAGID = " + nMAGID + " ";
            }
            if (nBrandID != 0)
            {
                sSql += " and BrandID = " + nBrandID + " ";
            }

            sSql += " Group by SalesPersonID " +
            " UNION ALL Select SalesPersonID, 0 as Target, 0 as TargetQty, " +
            " Sum(LeadAmount) as Actual, Sum(Qty) as ActualQty from " +
            " [dbo].[t_SalesLeadManagement] Where WarehouseID=" + Utility.WarehouseID + " and Status Not IN (3, 4) " +
            " and month(ExpExecuteDate) = " + nMonth + " and year(ExpExecuteDate) = " + nYear + " ";
            if (sSalesType != "")
            {
                sSql += " and CustomerType IN(" + sSalesType + ")  ";
            }
            if (nMAGID != 0)
            {
                sSql += " and MAGID = " + nMAGID + " ";
            }
            if (nBrandID != 0)
            {
                sSql += " and BrandID = " + nBrandID + " ";
            }
            sSql += " Group by  SalesPersonID ) final, t_Employee c where final.SalesPersonID = c.EmployeeID group by SalesPersonID, EmployeeCode, EmployeeName Order by EmployeeName  ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    POSDashboard oPOSDashboard = new POSDashboard();

                    oPOSDashboard.EmployeeCode = reader["EmployeeCode"].ToString();
                    oPOSDashboard.EmployeeName = reader["EmployeeName"].ToString();
                    oPOSDashboard.TargetSalesValue = Math.Round((double)reader["Target"]);
                    oPOSDashboard.ActualSalesValue = Math.Round((double)reader["Actual"]);
                    oPOSDashboard.TargetSalesQty = Convert.ToInt32(reader["TargetQty"]);
                    oPOSDashboard.ActualSalesQty = Convert.ToInt32(reader["ActualQty"]);
                    if (oPOSDashboard.TargetSalesValue != 0)
                    {
                        oPOSDashboard.sValPercent = Math.Round(oPOSDashboard.ActualSalesValue / oPOSDashboard.TargetSalesValue * 100, 0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sValPercent = "0";
                    }

                    if (oPOSDashboard.TargetSalesQty != 0)
                    {
                        oPOSDashboard.sQtyPercent = Math.Round(Convert.ToDouble(oPOSDashboard.ActualSalesQty) / oPOSDashboard.TargetSalesQty * 100, 0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sQtyPercent = "0";
                    }
                    InnerList.Add(oPOSDashboard);
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

        public void ChannelSales(DateTime dFromDate, DateTime dToDate, int nSalesPersonID, int nMAGID, int nBrandID)
        {
            dToDate = dToDate.AddDays(1);
            int nYear = dFromDate.Year;
            int nMonth = dFromDate.Month;

           
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select ChannelName, sum(Target) as Target, Sum(TargetQty) as TargetQty, Sum(Actual) as Actual, Sum(ActualQty) as ActualQty from  " +
                       " ( " +
                       " SElect ChannelName, Sum(TargetAmount) as Target, Sum(TargetQty) as TargetQty, Sum(Actual) as Actual, Sum(ActualQty) as ActualQty from " +
                       " (Select Case When Channel = 3 then 'Dealer' When Channel = 13 then 'B2B' When " +
                       " Channel = 16 then 'eStore' else 'Retail' end as ChannelName, TargetAmount, " +
                       " TargetQty, 0 as Actual, 0 as ActualQty from[dbo].[t_PlanExecutiveLeadTarget] " +
                       " where TargetType =  " + (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty + " " +
                       " and TMonth = " + nMonth + " and TYear = " + nYear + " ";
                       
            if (nSalesPersonID != 0)
            {
                sSql += " and SalesPersonID = " + nSalesPersonID + " ";
            }
            if (nMAGID != 0)
            {
                sSql += " and MAGID = " + nMAGID + " ";
            }
            if (nBrandID != 0)
            {
                sSql += " and BrandID = " + nBrandID + " ";
            }
            sSql += " )x Group by ChannelName " +
                       " UNION ALL " +
                       " Select Case when SalesType = 5 then 'Dealer' when SalesType = 3 then 'B2B' when SalesType = 6 then 'eStore' else 'Retail' end as ChannelName, "+ 
                       " 0 as Target, 0 as TargetQty, (GrossSales + OC - VAT - Discount) as Actual, SalesQty as ActualQty " +
                       " From " +
                       " ( " +
                       " Select SalesType, " +
                       " isnull((sum(crqty) - sum(drqty)), 0) as SalesQty, isnull((sum(crGrossSales) - sum(drGrossSales)), 0) as GrossSales, " +
                       " isnull((sum(crDiscount) - sum(drDiscount)), 0) as Discount, isnull((sum(crOC) - sum(drOC)), 0) as OC, " +
                       " isnull((sum(crCOGS) - sum(drCOGS)), 0) as COGS, isnull((sum(crVAT) - sum(drVAT)), 0) as VAT " +
                       " From " +
                       " ( " +
                       " Select SalesPersonID, SalesType, TYear, WeekNo, TMonth, ProductID, sum(quantity) as crqty, " +
                       " 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, " +
                       " sum(Discount) as crDiscount, 0 as drDiscount, sum(OC) as crOC, 0 as drOC, sum(COGS) as crCOGS, " +
                       " 0 as drCOGS, sum(VAT) as crVAT, 0 as drVAT  from " +
                       " ( " +
                       " Select SalesPersonID, SalesType, a.InvoiceID, " +
                       " WeekNo, TYear, TMonth, ProductID, Quantity, (Quantity * unitprice) as GrossSales, " +
                       " (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                       " (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                       " from " +
                       " ( " +
                       " select SalesPersonID, SalesType, sa.InvoiceID, WeekNo, year(invoicedate) as TYear, " +
                       " month(invoicedate) as TMonth, ProductID, UnitPrice, Costprice, " +
                       " TradePrice, VatAmount, Discount, quantity " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd, t_RetailConsumer sc, t_CalendarWeek " +
                       " where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID = sc.ConsumerID and " +
                       " invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                       " and convert(datetime, (convert(varchar(12), InvoiceDate, 106))) between fromdate and todate " +
                       " and invoicetypeid in (1, 2, 4, 5)and invoicestatus not in (3) " +
                       " ) as a " +
                       " left outer join " +
                       " ( " +
                       " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, " +
                       " isnull((OtherCharge / sum(quantity)), 0) as AvgOC  from t_salesinvoice sa, t_salesinvoicedetail sd " +
                       " where sa.invoiceid = sd.invoiceid and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  and invoicetypeid in (1, 2, 4, 5) and " +
                       " invoicestatus not in (3)   group by SalesPersonID, sa.InvoiceID, Discount, OtherCharge " +
                       " ) as b " +
                       " on a.invoiceid = b.invoiceid " +
                       " ) as final  Group By SalesPersonID, SalesType, TYear, TMonth, WeekNo, ProductID " +
                       " Union all " +
                       " Select SalesPersonID, SalesType, TYear, WeekNo, TMonth, ProductID, 0 as crqty, " +
                       " sum(quantity) as drqty, 0 as crGrossSales, sum(GrossSales) as drGrossSales, " +
                       " 0 as crDiscount, sum(Discount) as drDiscount, 0 as crOC, sum(OC) as drOC, " +
                       " 0 as crCOGS, sum(COGS) as drCOGS, 0 as crVAT, sum(VAT) as drVAT " +
                       " from( " +
                       " Select SalesPersonID, a.InvoiceID, WeekNo, TYear, TMonth, SalesType, ProductID, Quantity, " +
                       " (Quantity * unitprice) as GrossSales, (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                       " (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                       " from( " +
                       " select SalesPersonID, sa.InvoiceID, WeekNo, year(invoicedate) as TYear, month(invoicedate) as TMonth, " +
                       " SalesType, ProductID, UnitPrice, Costprice, TradePrice, VatAmount, Discount, quantity " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd, t_Retailconsumer sc, t_CalendarWeek " +
                       " where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID = sc.ConsumerID and " +
                       " invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                       " and convert(datetime, (convert(varchar(12), InvoiceDate, 106))) between fromdate and todate " +
                       " and invoicetypeid in (6, 7, 9, 10, 12)and invoicestatus not in (3)) as a " +
                       " left outer join " +
                       " ( " +
                       " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, isnull((OtherCharge / sum(quantity)), 0) as AvgOC " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd " +
                       " where sa.invoiceid = sd.invoiceid and invoicedate " +
                       " between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  and invoicetypeid in (6, 7, 9, 10, 12) and " +
                       " invoicestatus not in (3)   group by sa.InvoiceID, Discount, OtherCharge " +
                       " ) as b " +
                       " on a.invoiceid = b.invoiceid " +
                       " ) as final " +
                       " Group By SalesPersonID,SalesType,WeekNo,TYear,TMonth,ProductID " +
                       " )as FinalQuery, v_ProductDetails b Where FinalQuery.ProductID = b.ProductID ";

            if (nSalesPersonID != 0)
            {
                sSql += " and SalesPersonID = " + nSalesPersonID + " ";
            }
            if (nMAGID != 0)
            {
                sSql += " and MAGID = " + nMAGID + " ";
            }
            if (nBrandID != 0)
            {
                sSql += " and BrandID = " + nBrandID + " ";
            }
            sSql += " Group by  SalesType )x " +
                       " ) final Group by ChannelName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    POSDashboard oPOSDashboard = new POSDashboard();

                    oPOSDashboard.ChannelName = reader["ChannelName"].ToString();
                    oPOSDashboard.TargetSalesValue = Math.Round((double)reader["Target"]);
                    oPOSDashboard.ActualSalesValue = Math.Round((double)reader["Actual"]);
                    oPOSDashboard.TargetSalesQty = Convert.ToInt32(reader["TargetQty"]);
                    oPOSDashboard.ActualSalesQty = Convert.ToInt32(reader["ActualQty"]);
                    if (oPOSDashboard.TargetSalesValue != 0)
                    {
                        oPOSDashboard.sValPercent = Math.Round(oPOSDashboard.ActualSalesValue / oPOSDashboard.TargetSalesValue * 100, 0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sValPercent = "0";
                    }

                    if (oPOSDashboard.TargetSalesQty != 0)
                    {
                        oPOSDashboard.sQtyPercent = Math.Round(Convert.ToDouble(oPOSDashboard.ActualSalesQty) / oPOSDashboard.TargetSalesQty * 100, 0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sQtyPercent = "0";
                    }

                    InnerList.Add(oPOSDashboard);
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

        public void ChannelSalesRT(DateTime dFromDate, DateTime dToDate, int nSalesPersonID, int nMAGID, int nBrandID)
        {
            dToDate = dToDate.AddDays(1);
            int nYear = dFromDate.Year;
            int nMonth = dFromDate.Month;


            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select ChannelName, sum(Target) as Target, Sum(TargetQty) as TargetQty, Sum(Actual) as Actual, Sum(ActualQty) as ActualQty from  " +
                       " ( " +
                       " SElect ChannelName, Sum(TargetAmount) as Target, Sum(TargetQty) as TargetQty, Sum(Actual) as Actual, Sum(ActualQty) as ActualQty from " +
                       " (Select Case When Channel = 3 then 'Dealer' When Channel = 13 then 'B2B' When " +
                       " Channel = 16 then 'eStore' else 'Retail' end as ChannelName, TargetAmount, " +
                       " TargetQty, 0 as Actual, 0 as ActualQty from[dbo].[t_PlanExecutiveLeadTarget] " +
                       " where CustomerID=" + Utility.CustomerID + " and TargetType =  " + (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty + " " +
                       " and TMonth = " + nMonth + " and TYear = " + nYear + " ";

            if (nSalesPersonID != 0)
            {
                sSql += " and SalesPersonID = " + nSalesPersonID + " ";
            }
            if (nMAGID != 0)
            {
                sSql += " and MAGID = " + nMAGID + " ";
            }
            if (nBrandID != 0)
            {
                sSql += " and BrandID = " + nBrandID + " ";
            }
            sSql += " )x Group by ChannelName " +
                       " UNION ALL " +
                       " Select Case when SalesType = 5 then 'Dealer' when SalesType = 3 then 'B2B' when SalesType = 6 then 'eStore' else 'Retail' end as ChannelName, " +
                       " 0 as Target, 0 as TargetQty, (GrossSales + OC - VAT - Discount) as Actual, SalesQty as ActualQty " +
                       " From " +
                       " ( " +
                       " Select SalesType, " +
                       " isnull((sum(crqty) - sum(drqty)), 0) as SalesQty, isnull((sum(crGrossSales) - sum(drGrossSales)), 0) as GrossSales, " +
                       " isnull((sum(crDiscount) - sum(drDiscount)), 0) as Discount, isnull((sum(crOC) - sum(drOC)), 0) as OC, " +
                       " isnull((sum(crCOGS) - sum(drCOGS)), 0) as COGS, isnull((sum(crVAT) - sum(drVAT)), 0) as VAT " +
                       " From " +
                       " ( " +
                       " Select SalesPersonID, SalesType, TYear, WeekNo, TMonth, ProductID, sum(quantity) as crqty, " +
                       " 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, " +
                       " sum(Discount) as crDiscount, 0 as drDiscount, sum(OC) as crOC, 0 as drOC, sum(COGS) as crCOGS, " +
                       " 0 as drCOGS, sum(VAT) as crVAT, 0 as drVAT  from " +
                       " ( " +
                       " Select SalesPersonID, SalesType, a.InvoiceID, " +
                       " WeekNo, TYear, TMonth, ProductID, Quantity, (Quantity * unitprice) as GrossSales, " +
                       " (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                       " (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                       " from " +
                       " ( " +
                       " select SalesPersonID, SalesType, sa.InvoiceID, WeekNo, year(invoicedate) as TYear, " +
                       " month(invoicedate) as TMonth, ProductID, UnitPrice, Costprice, " +
                       " TradePrice, VatAmount, Discount, quantity " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd, t_RetailConsumer sc, t_CalendarWeek " +
                       " where sa.WarehouseID=" + Utility.WarehouseID+" and sa.invoiceid = sd.invoiceid and sa.SundryCustomerID = sc.ConsumerID and " +
                       " sa.WarehouseID=sc.WarehouseID and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                       " and convert(datetime, (convert(varchar(12), InvoiceDate, 106))) between fromdate and todate " +
                       " and invoicetypeid in (1, 2, 4, 5)and invoicestatus not in (3) " +
                       " ) as a " +
                       " left outer join " +
                       " ( " +
                       " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, " +
                       " isnull((OtherCharge / sum(quantity)), 0) as AvgOC  from t_salesinvoice sa, t_salesinvoicedetail sd " +
                       " where sa.WarehouseID=" + Utility.WarehouseID + " and sa.invoiceid = sd.invoiceid and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  and invoicetypeid in (1, 2, 4, 5) and " +
                       " invoicestatus not in (3)   group by SalesPersonID, sa.InvoiceID, Discount, OtherCharge " +
                       " ) as b " +
                       " on a.invoiceid = b.invoiceid " +
                       " ) as final  Group By SalesPersonID, SalesType, TYear, TMonth, WeekNo, ProductID " +
                       " Union all " +
                       " Select SalesPersonID, SalesType, TYear, WeekNo, TMonth, ProductID, 0 as crqty, " +
                       " sum(quantity) as drqty, 0 as crGrossSales, sum(GrossSales) as drGrossSales, " +
                       " 0 as crDiscount, sum(Discount) as drDiscount, 0 as crOC, sum(OC) as drOC, " +
                       " 0 as crCOGS, sum(COGS) as drCOGS, 0 as crVAT, sum(VAT) as drVAT " +
                       " from( " +
                       " Select SalesPersonID, a.InvoiceID, WeekNo, TYear, TMonth, SalesType, ProductID, Quantity, " +
                       " (Quantity * unitprice) as GrossSales, (AvgDisc * Quantity) as Discount, (AvgOC * Quantity) as OC, " +
                       " (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT " +
                       " from( " +
                       " select SalesPersonID, sa.InvoiceID, WeekNo, year(invoicedate) as TYear, month(invoicedate) as TMonth, " +
                       " SalesType, ProductID, UnitPrice, Costprice, TradePrice, VatAmount, Discount, quantity " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd, t_Retailconsumer sc, t_CalendarWeek " +
                       " where sa.WarehouseID=" + Utility.WarehouseID + " and sa.invoiceid = sd.invoiceid and sa.SundryCustomerID = sc.ConsumerID and " +
                       " sa.WarehouseID=sc.WarehouseID and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                       " and convert(datetime, (convert(varchar(12), InvoiceDate, 106))) between fromdate and todate " +
                       " and invoicetypeid in (6, 7, 9, 10, 12)and invoicestatus not in (3)) as a " +
                       " left outer join " +
                       " ( " +
                       " select sa.InvoiceID, isnull((Discount / sum(quantity)), 0) as AvgDisc, isnull((OtherCharge / sum(quantity)), 0) as AvgOC " +
                       " from t_salesinvoice sa, t_salesinvoicedetail sd " +
                       " where sa.WarehouseID=" + Utility.WarehouseID + " and sa.invoiceid = sd.invoiceid and invoicedate " +
                       " between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  and invoicetypeid in (6, 7, 9, 10, 12) and " +
                       " invoicestatus not in (3)   group by sa.InvoiceID, Discount, OtherCharge " +
                       " ) as b " +
                       " on a.invoiceid = b.invoiceid " +
                       " ) as final " +
                       " Group By SalesPersonID,SalesType,WeekNo,TYear,TMonth,ProductID " +
                       " )as FinalQuery, v_ProductDetails b Where FinalQuery.ProductID = b.ProductID ";

            if (nSalesPersonID != 0)
            {
                sSql += " and SalesPersonID = " + nSalesPersonID + " ";
            }
            if (nMAGID != 0)
            {
                sSql += " and MAGID = " + nMAGID + " ";
            }
            if (nBrandID != 0)
            {
                sSql += " and BrandID = " + nBrandID + " ";
            }
            sSql += " Group by  SalesType )x " +
                       " ) final Group by ChannelName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    POSDashboard oPOSDashboard = new POSDashboard();

                    oPOSDashboard.ChannelName = reader["ChannelName"].ToString();
                    oPOSDashboard.TargetSalesValue = Math.Round((double)reader["Target"]);
                    oPOSDashboard.ActualSalesValue = Math.Round((double)reader["Actual"]);
                    oPOSDashboard.TargetSalesQty = Convert.ToInt32(reader["TargetQty"]);
                    oPOSDashboard.ActualSalesQty = Convert.ToInt32(reader["ActualQty"]);
                    if (oPOSDashboard.TargetSalesValue != 0)
                    {
                        oPOSDashboard.sValPercent = Math.Round(oPOSDashboard.ActualSalesValue / oPOSDashboard.TargetSalesValue * 100, 0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sValPercent = "0";
                    }

                    if (oPOSDashboard.TargetSalesQty != 0)
                    {
                        oPOSDashboard.sQtyPercent = Math.Round(Convert.ToDouble(oPOSDashboard.ActualSalesQty) / oPOSDashboard.TargetSalesQty * 100, 0).ToString();
                    }
                    else
                    {
                        oPOSDashboard.sQtyPercent = "0";
                    }

                    InnerList.Add(oPOSDashboard);
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

    }
}
