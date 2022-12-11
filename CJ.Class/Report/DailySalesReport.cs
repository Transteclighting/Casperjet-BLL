// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: July 3, 2011
// Time" :  04:09 PM
// Description: Report.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Report
{
    [Serializable]
    public class DailySalesReport
    {
        public DailySalesReport()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public int _SBUID;
        public string _SBUCode;
        public string _SBUName;
        public int _ChannelId;
        public string _ChannelCode;
        public string _ChannelName;
        public int _CustomerId;
        public string _CustomerName;
        public string _CustomerCode;
        public int _CustomerTypeId;
        public string _CustomerTypeCode;
        public string _CustomerTypeName;
        public int _AreaId;
        public string _AreaCode;
        public string _AreaName;
        public int _TerritoryId;
        public string _TerritoryCode;
        public string _TerritoryName;
        public double _DailySales;
        public double _MonthlySales;
        public double _YearlySales;
        public double _MonthlyTarget;
        public double _YearlyTarget;
        public int _CodeInNumber;
        public int _PGID;
        public string _PGCode;
        public string _PGName;
        public int _MAGID;
        public string _MAGCode;
        public string _MAGName;
        public int _ASGID;
        public string _ASGCode;
        public string _ASGName;
        public int _BrandID;
        public string _BrandCode;
        public string _BrandName;
        public int _DailyQuantity;
        public int _MonthlyQuantity;
        public int _YearlyQuantity;
        public double _DailyGrossSales;
        public double _MonthlyGrossSales;
        public double _YearlyGrossSales;
        public double _MonthlyTargetQty;
        public double _YearlyTargetQty;
        public double _MonthlyTargetTO;
        public double _YearlyTargetTO;




        public double _RetailNetSales;
        public double RetailNetSales
        {
            get { return _RetailNetSales; }
            set { _RetailNetSales = value; }
        }
        public double _B2BNetSales;
        public double B2BNetSales
        {
            get { return _B2BNetSales; }
            set { _B2BNetSales = value; }
        }
        public double _B2CNetSales;
        public double B2CNetSales
        {
            get { return _B2CNetSales; }
            set { _B2CNetSales = value; }
        }
        public double _HPANetSales;
        public double HPANetSales
        {
            get { return _HPANetSales; }
            set { _HPANetSales = value; }
        }
        public double _DealerNetSales;
        public double DealerNetSales
        {
            get { return _DealerNetSales; }
            set { _DealerNetSales = value; }
        }
        public double _EstoreNetSales;
        public double EstoreNetSales
        {
            get { return _EstoreNetSales; }
            set { _EstoreNetSales = value; }
        }




        public int SBUID
        {
            get { return _SBUID; }
            set { _SBUID = value; }
        }
        public string SBUCode
        {
            get { return _SBUCode; }
            set { _SBUCode = value; }
        }
        public string SBUName
        {
            get { return _SBUName; }
            set { _SBUName = value; }
        }
        public int ChannelId
        {
            get { return _ChannelId; }
            set { _ChannelId = value; }
        }
        public string ChannelCode
        {
            get { return _ChannelCode; }
            set { _ChannelCode = value; }
        }
        public string ChannelName
        {
            get { return _ChannelName; }
            set { _ChannelName = value; }
        }
        public int CustomerId
        {
            get { return _CustomerId; }
            set { _CustomerId = value; }
        }
        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }
        public string CustomerCode
        {
            get { return _CustomerCode; }
            set { _CustomerCode = value; }
        }
        public int CustomerTypeId
        {
            get { return _CustomerTypeId; }
            set { _CustomerTypeId = value; }
        }
        public string CustomerTypeCode
        {
            get { return _CustomerTypeCode; }
            set { _CustomerTypeCode = value; }
        }
        public string CustomerTypeName
        {
            get { return _CustomerTypeName; }
            set { _CustomerTypeName = value; }
        }
        public int AreaId
        {
            get { return _AreaId; }
            set { _AreaId = value; }
        }
        public string AreaCode
        {
            get { return _AreaCode; }
            set { _AreaCode = value; }
        }
        public string AreaName
        {
            get { return _AreaName; }
            set { _AreaName = value; }
        }
        public int TerritoryId
        {
            get { return _TerritoryId; }
            set { _TerritoryId = value; }
        }
        public string TerritoryCode
        {
            get { return _TerritoryCode; }
            set { _TerritoryCode = value; }
        }
        public string TerritoryName
        {
            get { return _TerritoryName; }
            set { _TerritoryName = value; }
        }
        public double DailySales
        {
            get { return _DailySales; }
            set { _DailySales = value; }
        }
        public double MonthlySales
        {
            get { return _MonthlySales; }
            set { _MonthlySales = value; }
        }
        public double YearlySales
        {
            get { return _YearlySales; }
            set { _YearlySales = value; }
        }
        public double MonthlyTarget
        {
            get { return _MonthlyTarget; }
            set { _MonthlyTarget = value; }
        }
        public double YearlyTarget
        {
            get { return _YearlyTarget; }
            set { _YearlyTarget = value; }
        }

        private string _sPaymentModeName;
        public string PaymentModeName
        {
            get { return _sPaymentModeName; }
            set { _sPaymentModeName = value; }
        }
        private double _CreditAmount;
        public double CreditAmount
        {
            get { return _CreditAmount; }
            set { _CreditAmount = value; }
        }
        private double _DebitAmount;
        public double DebitAmount
        {
            get { return _DebitAmount; }
            set { _DebitAmount = value; }
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

        private int _nFreeQty;
        public int FreeQty
        {
            get { return _nFreeQty; }
            set { _nFreeQty = value; }
        }
        private int _nTotalQty;
        public int TotalQty
        {
            get { return _nTotalQty; }
            set { _nTotalQty = value; }
        }
        private double _ChargeAmount;
        public double ChargeAmount
        {
            get { return _ChargeAmount; }
            set { _ChargeAmount = value; }
        }
        private double _VAT;
        public double VAT
        {
            get { return _VAT; }
            set { _VAT = value; }
        }
        private int _nQty;
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }
        private double _GrossAmount;
        public double GrossAmount
        {
            get { return _GrossAmount; }
            set { _GrossAmount = value; }
        }
        private double _DiscountAmount;
        public double DiscountAmount
        {
            get { return _DiscountAmount; }
            set { _DiscountAmount = value; }
        }
        private double _NetAmount;
        public double NetAmount
        {
            get { return _NetAmount; }
            set { _NetAmount = value; }
        }


        private double _CrRtlAmt;
        public double CrRtlAmt
        {
            get { return _CrRtlAmt; }
            set { _CrRtlAmt = value; }
        }
        private double _CrB2CAmt;
        public double CrB2CAmt
        {
            get { return _CrB2CAmt; }
            set { _CrB2CAmt = value; }
        }
        private double _CrB2BAmt;
        public double CrB2BAmt
        {
            get { return _CrB2BAmt; }
            set { _CrB2BAmt = value; }
        }
        private double _CrHPAAmt;
        public double CrHPAAmt
        {
            get { return _CrHPAAmt; }
            set { _CrHPAAmt = value; }
        }
        private double _CrDealerAmt;
        public double CrDealerAmt
        {
            get { return _CrDealerAmt; }
            set { _CrDealerAmt = value; }
        }

        private double _CrETDAmt;
        public double CrETDAmt
        {
            get { return _CrETDAmt; }
            set { _CrETDAmt = value; }
        }

        private double _DrRtlAmt;
        public double DrRtlAmt
        {
            get { return _DrRtlAmt; }
            set { _DrRtlAmt = value; }
        }
        private double _DrB2CAmt;
        public double DrB2CAmt
        {
            get { return _DrB2CAmt; }
            set { _DrB2CAmt = value; }
        }
        private double _DrB2BAmt;
        public double DrB2BAmt
        {
            get { return _DrB2BAmt; }
            set { _DrB2BAmt = value; }
        }
        private double _DrHPAAmt;
        public double DrHPAAmt
        {
            get { return _DrHPAAmt; }
            set { _DrHPAAmt = value; }
        }
        private double _DrDealerAmt;
        public double DrDealerAmt
        {
            get { return _DrDealerAmt; }
            set { _DrDealerAmt = value; }
        }

        private double _DrETDAmt;
        public double DrETDAmt
        {
            get { return _DrETDAmt; }
            set { _DrETDAmt = value; }
        }

        public void GetChannelWiseNetSales(DateTime dFromDate, DateTime dToDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            try
            {
                cmd.CommandText = "Select max(Retail) Retail, max(B2C) B2C,max(B2B) B2B, " +
                        "max(HPA) HPA,max(Dealer) Dealer,max(eStore) eStore " +
                        "From  " +
                        "( " +
                        "Select  " +
                        "case when SalesType=1 then sum(NetSales) else 0 end as 'Retail', " +
                        "case when SalesType=2 then sum(NetSales) else 0 end as 'B2C', " +
                        "case when SalesType=3 then sum(NetSales) else 0 end as 'B2B', " +
                        "case when SalesType=4 then sum(NetSales) else 0 end as 'HPA', " +
                        "case when SalesType=5 then sum(NetSales) else 0 end as 'Dealer', " +
                        "case when SalesType=6 then sum(NetSales) else 0 end as 'eStore' " +
                        "From  " +
                        "( " +
                        "Select 1 SalesType,0 SalesQty,0 GrossSales,0 Discount,0 OC,0 VAT,0 NetSales,0 COGS  " +
                        "Union All " +
                        "Select 2 SalesType,0 SalesQty,0 GrossSales,0 Discount,0 OC,0 VAT,0 NetSales,0 COGS  " +
                        "Union All " +
                        "Select 3 SalesType,0 SalesQty,0 GrossSales,0 Discount,0 OC,0 VAT,0 NetSales,0 COGS  " +
                        "Union All " +
                        "Select 4 SalesType,0 SalesQty,0 GrossSales,0 Discount,0 OC,0 VAT,0 NetSales,0 COGS  " +
                        "Union All " +
                        "Select 5 SalesType,0 SalesQty,0 GrossSales,0 Discount,0 OC,0 VAT,0 NetSales,0 COGS  " +
                        "Union All " +
                        "Select 6 SalesType,0 SalesQty,0 GrossSales,0 Discount,0 OC,0 VAT,0 NetSales,0 COGS  " +
                        "Union All " +
                        "Select SalesType, SalesQty,GrossSales,Discount,OC,VAT, " +
                        "(GrossSales+OC-VAT-Discount) as NetSales,COGS   " +
                        "From  " +
                        "( " +
                        "Select SalesType, isnull((sum(crqty)- sum(drqty)),0) as SalesQty,isnull((sum(crGrossSales)- sum(drGrossSales)),0) as GrossSales,  " +
                        "isnull((sum(crDiscount)- sum(drDiscount)),0) as Discount,isnull((sum(crOC)- sum(drOC)),0) as OC,isnull((sum(crCOGS)- sum(drCOGS)),0) as COGS,isnull((sum(crVAT)- sum(drVAT)),0) as VAT  " +
                        "From  " +
                        "(  " +
                        "Select SalesType,sum(quantity)as crqty, 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales,  " +
                        "sum(Discount) as crDiscount, 0 as drDiscount,sum(OC) as crOC, 0 as drOC,sum(COGS) as crCOGS, 0 as drCOGS,sum(VAT) as crVAT, 0 as drVAT  " +
                        "from  " +
                        "(  " +
                        "Select SalesType,a.InvoiceID,ProductID,Quantity,(Quantity*unitprice)as GrossSales, " +
                        "(AvgDisc*Quantity) as Discount,(AvgOC*Quantity) as OC,  " +
                        "(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT  " +
                        "from  " +
                        "(  " +
                        "select SalesType,sa.InvoiceID,year(invoicedate) as TYear,month(invoicedate) as TMonth, " +
                        "sa.CustomerID,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity  " +
                        "from t_salesinvoice sa, t_salesinvoicedetail sd,t_RetailConsumer c  " +
                        "where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID=c.ConsumerID and  " +
                        "invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  " +
                        "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)   " +
                        ")as a  " +
                        "left outer join  " +
                        "(  " +
                        "select sa.InvoiceID,isnull((Discount/sum(quantity)),0) as AvgDisc,isnull((OtherCharge/sum(quantity)),0) as AvgOC  " +
                        "from t_salesinvoice sa, t_salesinvoicedetail sd  " +
                        "where sa.invoiceid = sd.invoiceid and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  " +
                        "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)   " +
                        "group by sa.InvoiceID,Discount,OtherCharge  " +
                        ") as b on a.invoiceid = b.invoiceid " +
                        ") as final  " +
                        "Group By SalesType  " +
                        "Union All " +
                        "Select SalesType,0 as crqty, sum(quantity)as drqty, 0 as crGrossSales,sum(GrossSales) as drGrossSales,  " +
                        "0 as crDiscount,sum(Discount) as drDiscount,0 as crOC,sum(OC) as drOC,0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT  " +
                        "from  " +
                        "( " +
                        "Select SalesType,a.InvoiceID,ProductID,Quantity,(Quantity*unitprice)as GrossSales,(AvgDisc*Quantity) as Discount,(AvgOC*Quantity) as OC,  " +
                        "(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT  " +
                        "from  " +
                        "(  " +
                        "select SalesType,sa.InvoiceID,year(invoicedate) as TYear,month(invoicedate) as TMonth, " +
                        "sa.CustomerID,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity  " +
                        "from t_salesinvoice sa, t_salesinvoicedetail sd,t_RetailConsumer c   " +
                        "where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID=c.ConsumerID and  " +
                        "invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  " +
                        "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)   " +
                        ")as a  " +
                        "left outer join  " +
                        "(  " +
                        "select sa.InvoiceID,isnull((Discount/sum(quantity)),0) as AvgDisc,isnull((OtherCharge/sum(quantity)),0) as AvgOC  " +
                        "from t_salesinvoice sa, t_salesinvoicedetail sd  " +
                        "where sa.invoiceid = sd.invoiceid and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'  " +
                        "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)   " +
                        "group by sa.InvoiceID,Discount,OtherCharge  " +
                        ") as b on a.invoiceid = b.invoiceid " +
                        ")as FinalQuery  " +
                        "Group by SalesType " +
                        ") as sales  " +
                        "Group by SalesType " +
                        ") x  " +
                        ") aa group by SalesType " +
                        ") Main";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //_nWarehouseID = (int)reader["WarehouseID"];
                    _RetailNetSales = Convert.ToDouble(reader["Retail"].ToString());
                    _B2BNetSales = Convert.ToDouble(reader["B2B"].ToString());
                    _B2CNetSales = Convert.ToDouble(reader["B2C"].ToString());
                    _HPANetSales = Convert.ToDouble(reader["HPA"].ToString());
                    _DealerNetSales = Convert.ToDouble(reader["Dealer"].ToString());
                    _EstoreNetSales = Convert.ToDouble(reader["eStore"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }

    public class DailySalesReports : CollectionBaseCustom
    {

        public void Add(DailySalesReport oDailySalesReport)
        {
            this.List.Add(oDailySalesReport);
        }
        public DailySalesReport this[Int32 Index]
        {
            get
            {
                return (DailySalesReport)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(DailySalesReport))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        /// <summary>
        /// Customer wise daily slaes report
        /// </summary>   
        public void DailySalesReportCustomerWise(DateTime dYFromDate, DateTime dYToDate, DateTime dMFromDate, DateTime dMToDate, DateTime dDFromDate, DateTime dDToDate)
        {
            dYToDate = dYToDate.AddDays(1);
            dMToDate = dMToDate.AddDays(1);
            dDToDate = dDToDate.AddDays(1);
            // InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();


            //sQueryStringMaster.Append("Select SBUID,SBUCode,SBUName,ChannelID,ChannelCode,Channeldescription AS ChannelName,CustomerTypeID,CustomerTypeCode,CustomerTypeName,  ");
            sQueryStringMaster.Append("Select SBUID,SBUCode,SBUName,ChannelID,ChannelCode,Channeldescription AS ChannelName,CustomerTypeID,CustomerTypeCode,CustomerTypeName,  ");
            sQueryStringMaster.Append("AreaID,AreaCode,AreaName,TerritoryID,TerritoryCode,TerritoryName,St.CustomerID,CustomerCode,CustomerName, ");
            sQueryStringMaster.Append("isnull(sum(DailySales),0)as DailySales, isnull(sum(MonthlySales),0)as MonthlySales, isnull(sum(YearlySales),0) as YearlySales, ");
            sQueryStringMaster.Append("isnull(sum(MonthlyTarget),0) as MonthlyTarget,isnull(sum(YearlyTarget),0) as YearlyTarget ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("Select isnull(sales.customerid,target.Customerid)as CustomerID, ");
            sQueryStringMaster.Append("isnull(DailySales,0)as DailySales, isnull(MonthlySales,0)as MonthlySales, isnull(YearlySales,0) as YearlySales, ");
            sQueryStringMaster.Append("isnull(YearlyTarget,0) as YearlyTarget,isnull(MonthlyTarget,0) as MonthlyTarget ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("Select p1.Customerid,isnull(DailySales,0)as DailySales, isnull(MonthlySales,0)as MonthlySales, isnull(YearlySales,0) as YearlySales  ");
            sQueryStringMaster.Append("From  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as YearlySales  ");
            sQueryStringMaster.Append("From  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ? and im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append("union all  ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount, sum(invoiceamount)as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ? and im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(")as qq1  ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(")as p1  ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as MonthlySales  ");
            sQueryStringMaster.Append("From  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ? and im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append("union all  ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount, sum(invoiceamount)as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ? and im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(")as qq1  ");
            sQueryStringMaster.Append("Group By Customerid             ");
            sQueryStringMaster.Append(")as p2 on p1.customerid = p2.customerid  ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as DailySales  ");
            sQueryStringMaster.Append("From  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ? and im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append("union all  ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount, sum(invoiceamount)as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where invoicedate between ? and ? and invoicedate< ? and im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(")as qq1  ");
            sQueryStringMaster.Append("Group By Customerid             ");
            sQueryStringMaster.Append(")as p3 on p1.customerid = p3.customerid  ");
            sQueryStringMaster.Append(") as Sales ");
            sQueryStringMaster.Append("Full outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("Select y.CustomerID, isnull(YearlyTarget,0) as YearlyTarget,isnull(MonthlyTarget,0) as MonthlyTarget  ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select MarketGroupID as Customerid, sum (Turnover)as YearlyTarget  ");
            sQueryStringMaster.Append("from t_planbudgettarget  ");
            sQueryStringMaster.Append("where plantype in (?) and productgrouptype in (?) and periodtype in (?) and MarketScopeType in (?)   ");
            sQueryStringMaster.Append("and perioddate between ? and ?  ");
            sQueryStringMaster.Append("group by  MarketGroupID ");
            sQueryStringMaster.Append(")as Y ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select MarketGroupID as Customerid, sum (Turnover)as MonthlyTarget  ");
            sQueryStringMaster.Append("from t_planbudgettarget  ");
            sQueryStringMaster.Append("where plantype in (?) and productgrouptype in (?) and periodtype in (?) and MarketScopeType in (?)   ");
            sQueryStringMaster.Append("and perioddate between ? and ?  ");
            sQueryStringMaster.Append("group by  MarketGroupID ");
            sQueryStringMaster.Append(") as m on y.Customerid = m.Customerid ");
            sQueryStringMaster.Append(") as Target on sales.customerid = target.Customerid ");
            sQueryStringMaster.Append(")as st ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("SELECT * from v_customerdetails  ");
            sQueryStringMaster.Append(")as cd on st.customerid = cd.customerid ");
            sQueryStringMaster.Append("Group by ");
            sQueryStringMaster.Append("SBUID,SBUCode,SBUName,ChannelID,ChannelCode,Channeldescription, CustomerTypeID,CustomerTypeCode,CustomerTypeName,AreaID,AreaCode,AreaName,  ");
            sQueryStringMaster.Append("TerritoryID,TerritoryCode,TerritoryName,St.CustomerID,CustomerCode,CustomerName ");



            OleDbCommand oCmd = DBController.Instance.GetCommand();
            //Command time out
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();



            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);


            oCmd.Parameters.AddWithValue("InvoiceDate", dDFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dDFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("PlanType", (short)Dictionary.PlanType.Target);
            oCmd.Parameters.AddWithValue("ProductGroupType", (short)Dictionary.BudgetTargetProductGroupType.Product);
            oCmd.Parameters.AddWithValue("PeriodType", (short)Dictionary.PeriodType.Monthly);
            oCmd.Parameters.AddWithValue("MarketScopeType", (short)Dictionary.MarketScopeType.Customer);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);

            oCmd.Parameters.AddWithValue("PlanType", (short)Dictionary.PlanType.Target);
            oCmd.Parameters.AddWithValue("ProductGroupType", (short)Dictionary.BudgetTargetProductGroupType.Product);
            oCmd.Parameters.AddWithValue("PeriodType", (short)Dictionary.PeriodType.Monthly);
            oCmd.Parameters.AddWithValue("MarketScopeType", (short)Dictionary.MarketScopeType.Customer);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);


            GetDataCustomerWise(oCmd);

        }


        /// <summary>
        /// Customer wise daily Net slaes report
        /// </summary>   
        public void DailyNetSalesReportCustomerWise(DateTime dYFromDate, DateTime dYToDate, DateTime dMFromDate, DateTime dMToDate, DateTime dDFromDate, DateTime dDToDate)
        {
            dYToDate = dYToDate.AddDays(1);
            dMToDate = dMToDate.AddDays(1);
            dDToDate = dDToDate.AddDays(1);
            // InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();


            //***Modified by Kanij Dated on 29-APR-2015***

            sQueryStringMaster.Append("Select SBUID,SBUCode,SBUName,ChannelID,ChannelCode,Channeldescription AS ChannelName,CustomerTypeID,CustomerTypeCode,CustomerTypeName,  ");
            sQueryStringMaster.Append("AreaID,AreaCode,AreaName,TerritoryID,TerritoryCode,TerritoryName,St.CustomerID,CustomerCode,CustomerName, ");
            sQueryStringMaster.Append("isnull(sum(DailySales),0)as DailySales, isnull(sum(MonthlySales),0)as MonthlySales, isnull(sum(YearlySales),0) as YearlySales, ");
            sQueryStringMaster.Append("isnull(sum(MonthlyTarget),0) as MonthlyTarget,isnull(sum(YearlyTarget),0) as YearlyTarget ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("Select isnull(sales.customerid,target.Customerid)as CustomerID, ");
            sQueryStringMaster.Append("isnull(DailySales,0)as DailySales, isnull(MonthlySales,0)as MonthlySales, isnull(YearlySales,0) as YearlySales, ");
            sQueryStringMaster.Append("isnull(YearlyTarget,0) as YearlyTarget,isnull(MonthlyTarget,0) as MonthlyTarget ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("Select p1.Customerid,isnull(DailySales,0)as DailySales, isnull(MonthlySales,0)as MonthlySales, isnull(YearlySales,0) as YearlySales  ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrNetSalesAmount)- abs(sum(DrNetSaleAmount)),0) as YearlySales  ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select a.Customerid,(CrSalesAmount-isnull(vat,0))as  CrNetSalesAmount,DrSalesAmount as DrNetSaleAmount  ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ?  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(") as a  ");
            sQueryStringMaster.Append("inner join  ");
            sQueryStringMaster.Append("(select CustomerID,sum(Quantity*Tradeprice*vatamount)as VAT  ");
            sQueryStringMaster.Append("from t_salesinvoice sa , t_salesinvoicedetail sd  ");
            sQueryStringMaster.Append("where sa.invoiceid = sd.invoiceid and invoicedate between ? and ? and invoicedate < ?  ");
            sQueryStringMaster.Append("and invoicetypeid in (?,?,?,?)and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group by customerid  ");
            sQueryStringMaster.Append(")as b on a.customerid=b.customerid  ");
            sQueryStringMaster.Append("union all  ");
            sQueryStringMaster.Append("select a.Customerid,CrSalesAmount as CrNetSaleAmount,(DrSalesAmount-isnull(vat,0))as  DrNetSalesAmount ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as DrSalesAmount, 0 as CrSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ?  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(") as a  ");
            sQueryStringMaster.Append("inner join  ");
            sQueryStringMaster.Append("(select CustomerID,sum(Quantity*Tradeprice*vatamount)as VAT ");
            sQueryStringMaster.Append("from t_salesinvoice sa , t_salesinvoicedetail sd  ");
            sQueryStringMaster.Append("where sa.invoiceid = sd.invoiceid and invoicedate between ? and ? and invoicedate < ?  ");
            sQueryStringMaster.Append("and invoicetypeid in (?,?,?,?,?)and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as b on a.customerid=b.customerid  ");
            sQueryStringMaster.Append(")as qq1  ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(")as p1  ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");

            sQueryStringMaster.Append("select Customerid, isnull(sum(CrNetSalesAmount)- abs(sum(DrNetSaleAmount)),0) as MonthlySales  ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select a.Customerid,(CrSalesAmount-isnull(vat,0))as  CrNetSalesAmount,DrSalesAmount as DrNetSaleAmount ");
            sQueryStringMaster.Append("From  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount ");
            sQueryStringMaster.Append("from t_SalesInvoice im  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ?  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(") as a  ");
            sQueryStringMaster.Append("inner join  ");
            sQueryStringMaster.Append("(select CustomerID,sum(Quantity*Tradeprice*vatamount)as VAT  ");
            sQueryStringMaster.Append("from t_salesinvoice sa , t_salesinvoicedetail sd  ");
            sQueryStringMaster.Append("where sa.invoiceid = sd.invoiceid and invoicedate between ? and ? and invoicedate < ?  ");
            sQueryStringMaster.Append("and invoicetypeid in (?,?,?,?)and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group by customerid  ");
            sQueryStringMaster.Append(")as b on a.customerid=b.customerid ");
            sQueryStringMaster.Append("union all  ");
            sQueryStringMaster.Append("select a.Customerid,CrSalesAmount as CrNetSaleAmount,(DrSalesAmount-isnull(vat,0))as  DrNetSalesAmount ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as DrSalesAmount, 0 as CrSalesAmount ");
            sQueryStringMaster.Append("from t_SalesInvoice im  ");
            sQueryStringMaster.Append("where invoicedate between ? and ? and invoicedate< ? ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(") as a ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("(select CustomerID,sum(Quantity*Tradeprice*vatamount)as VAT ");
            sQueryStringMaster.Append("from t_salesinvoice sa , t_salesinvoicedetail sd ");
            sQueryStringMaster.Append("where sa.invoiceid = sd.invoiceid and invoicedate between ? and ? and invoicedate < ? ");
            sQueryStringMaster.Append("and invoicetypeid in (?,?,?,?,?)and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group by customerid  ");
            sQueryStringMaster.Append(")as b on a.customerid=b.customerid  ");
            sQueryStringMaster.Append(")as qq1  ");
            sQueryStringMaster.Append("Group By Customerid             ");
            sQueryStringMaster.Append(")as p2 on p1.customerid = p2.customerid  ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");

            sQueryStringMaster.Append("select Customerid, isnull(sum(CrNetSalesAmount)- abs(sum(DrNetSaleAmount)),0) as DailySales ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select a.Customerid,(CrSalesAmount-isnull(vat,0))as  CrNetSalesAmount,DrSalesAmount as DrNetSaleAmount ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount ");
            sQueryStringMaster.Append("from t_SalesInvoice im  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ?  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(") as a  ");
            sQueryStringMaster.Append("inner join  ");
            sQueryStringMaster.Append("(select CustomerID,sum(Quantity*Tradeprice*vatamount)as VAT ");
            sQueryStringMaster.Append("from t_salesinvoice sa , t_salesinvoicedetail sd  ");
            sQueryStringMaster.Append("where sa.invoiceid = sd.invoiceid and invoicedate between ? and ? and invoicedate < ?  ");
            sQueryStringMaster.Append("and invoicetypeid in (?,?,?,?)and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group by customerid  ");
            sQueryStringMaster.Append(")as b on a.customerid=b.customerid  ");
            sQueryStringMaster.Append("union all ");
            sQueryStringMaster.Append("select a.Customerid,CrSalesAmount as CrNetSaleAmount,(DrSalesAmount-isnull(vat,0))as  DrNetSalesAmount ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as DrSalesAmount, 0 as CrSalesAmount ");
            sQueryStringMaster.Append("from t_SalesInvoice im ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ? ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(") as a ");
            sQueryStringMaster.Append("inner join  ");
            sQueryStringMaster.Append("(select CustomerID,sum(Quantity*Tradeprice*vatamount)as VAT ");
            sQueryStringMaster.Append("from t_salesinvoice sa , t_salesinvoicedetail sd ");
            sQueryStringMaster.Append("where sa.invoiceid = sd.invoiceid and invoicedate between ? and ? and invoicedate < ?  ");
            sQueryStringMaster.Append("and invoicetypeid in (?,?,?,?,?)and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group by customerid  ");
            sQueryStringMaster.Append(")as b on a.customerid=b.customerid ");
            sQueryStringMaster.Append(")as qq1 ");
            sQueryStringMaster.Append("Group By Customerid             ");
            sQueryStringMaster.Append(")as p3 on p1.customerid = p3.customerid  ");
            sQueryStringMaster.Append(") as Sales  ");
            sQueryStringMaster.Append("Full outer join ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("Select y.CustomerID, isnull(YearlyTarget,0) as YearlyTarget,isnull(MonthlyTarget,0) as MonthlyTarget ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select MarketGroupID as Customerid, sum (Turnover)as YearlyTarget ");
            sQueryStringMaster.Append("from t_planbudgettarget ");
            sQueryStringMaster.Append("where plantype in (?) and productgrouptype in (?) and periodtype in (?) and MarketScopeType in (?) ");
            sQueryStringMaster.Append("and perioddate between ? and ? ");
            sQueryStringMaster.Append("group by  MarketGroupID ");
            sQueryStringMaster.Append(")as Y  ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select MarketGroupID as Customerid, sum (Turnover)as MonthlyTarget  ");
            sQueryStringMaster.Append("from t_planbudgettarget ");
            sQueryStringMaster.Append("where plantype in (?) and productgrouptype in (?) and periodtype in (?) and MarketScopeType in (?)  ");
            sQueryStringMaster.Append("and perioddate between ? and ?  ");
            sQueryStringMaster.Append("group by  MarketGroupID  ");
            sQueryStringMaster.Append(") as m on y.Customerid = m.Customerid  ");
            sQueryStringMaster.Append(") as Target on sales.customerid = target.Customerid  ");
            sQueryStringMaster.Append(")as st  ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("SELECT * from v_customerdetails ");
            sQueryStringMaster.Append(")as cd on st.customerid = cd.customerid  ");
            sQueryStringMaster.Append("Group by  ");
            sQueryStringMaster.Append("SBUID,SBUCode,SBUName,ChannelID,ChannelCode,Channeldescription, CustomerTypeID,CustomerTypeCode,CustomerTypeName,AreaID,AreaCode,AreaName,  ");
            sQueryStringMaster.Append("TerritoryID,TerritoryCode,TerritoryName,St.CustomerID,CustomerCode,CustomerName ");



            OleDbCommand oCmd = DBController.Instance.GetCommand();
            //Command time out
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();



            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);


            oCmd.Parameters.AddWithValue("InvoiceDate", dDFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dDFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dDFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dDFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("PlanType", (short)Dictionary.PlanType.Target);
            oCmd.Parameters.AddWithValue("ProductGroupType", (short)Dictionary.BudgetTargetProductGroupType.Product);
            oCmd.Parameters.AddWithValue("PeriodType", (short)Dictionary.PeriodType.Monthly);
            oCmd.Parameters.AddWithValue("MarketScopeType", (short)Dictionary.MarketScopeType.Customer);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);

            oCmd.Parameters.AddWithValue("PlanType", (short)Dictionary.PlanType.Target);
            oCmd.Parameters.AddWithValue("ProductGroupType", (short)Dictionary.BudgetTargetProductGroupType.Product);
            oCmd.Parameters.AddWithValue("PeriodType", (short)Dictionary.PeriodType.Monthly);
            oCmd.Parameters.AddWithValue("MarketScopeType", (short)Dictionary.MarketScopeType.Customer);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);




            GetDataCustomerWise(oCmd);

        }

        private void GetDataCustomerWise(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DailySalesReport oItem = new DailySalesReport();

                    if (reader["SBUID"] != DBNull.Value)
                        oItem.SBUID = Convert.ToInt32(reader["SBUID"]);
                    else oItem.SBUID = -1;
                    if (reader["SBUCode"] != DBNull.Value)
                        oItem.SBUCode = (string)reader["SBUCode"];
                    else oItem.SBUCode = "";
                    if (reader["SBUName"] != DBNull.Value)
                        oItem.SBUName = (string)reader["SBUName"];
                    else oItem.SBUName = "";
                    if (reader["ChannelID"] != DBNull.Value)
                        oItem.ChannelId = (int)reader["ChannelID"];
                    else oItem.ChannelId = -1;
                    if (reader["ChannelCode"] != DBNull.Value)
                        oItem.ChannelCode = (string)reader["ChannelCode"];
                    else oItem.ChannelCode = "";
                    if (reader["ChannelName"] != DBNull.Value)
                        oItem.ChannelName = (string)reader["ChannelName"];
                    else oItem.ChannelName = "";
                    if (reader["CustomerTypeId"] != DBNull.Value)
                        oItem.CustomerTypeId = (int)reader["CustomerTypeId"];
                    else oItem.CustomerTypeId = -1;
                    if (reader["CustomerTypeCode"] != DBNull.Value)
                        oItem.CustomerTypeCode = (string)reader["CustomerTypeCode"];
                    else oItem.CustomerTypeCode = "";
                    if (reader["CustomerTypeName"] != DBNull.Value)
                        oItem.CustomerTypeName = (string)reader["CustomerTypeName"];
                    else oItem.CustomerTypeName = "";
                    if (reader["AreaId"] != DBNull.Value)
                        oItem.AreaId = (int)reader["AreaId"];
                    else oItem.AreaId = -1;
                    if (reader["AreaCode"] != DBNull.Value)
                        oItem.AreaCode = (string)reader["AreaCode"];
                    else oItem.AreaCode = "";
                    if (reader["AreaName"] != DBNull.Value)
                        oItem.AreaName = (string)reader["AreaName"];
                    else oItem.AreaName = "";
                    if (reader["TerritoryId"] != DBNull.Value)
                        oItem.TerritoryId = (int)reader["TerritoryId"];
                    else oItem.TerritoryId = -1;
                    if (reader["TerritoryCode"] != DBNull.Value)
                        oItem.TerritoryCode = (string)reader["TerritoryCode"];
                    else oItem.TerritoryCode = "";
                    if (reader["TerritoryName"] != DBNull.Value)
                        oItem.TerritoryName = (string)reader["TerritoryName"];
                    else oItem.TerritoryName = "";
                    if (reader["CustomerId"] != DBNull.Value)
                        oItem.CustomerId = (int)reader["CustomerId"];
                    else oItem.CustomerId = -1;
                    if (reader["CustomerCode"] != DBNull.Value)
                        oItem.CustomerCode = (string)reader["CustomerCode"];
                    else oItem.CustomerCode = "";
                    if (reader["CustomerName"] != DBNull.Value)
                        oItem.CustomerName = (string)reader["CustomerName"];
                    else oItem.CustomerName = "";

                    if (reader["DailySales"] != DBNull.Value)
                        oItem.DailySales = (double)reader["DailySales"];
                    else oItem.DailySales = 0;
                    if (reader["MonthlySales"] != DBNull.Value)
                        oItem.MonthlySales = (double)reader["MonthlySales"];
                    else oItem.MonthlySales = 0;
                    if (reader["YearlySales"] != DBNull.Value)
                        oItem.YearlySales = (double)reader["YearlySales"];
                    else oItem.YearlySales = 0;
                    if (reader["MonthlyTarget"] != DBNull.Value)
                        oItem.MonthlyTarget = (double)reader["MonthlyTarget"];
                    else oItem.MonthlyTarget = 0;
                    if (reader["YearlyTarget"] != DBNull.Value)
                        oItem.YearlyTarget = (double)reader["YearlyTarget"];
                    else oItem.YearlyTarget = 0;


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
        public void FromDataSetForCustomerWise(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    DailySalesReport oDailySalesReport = new DailySalesReport();

                    oDailySalesReport.SBUID = Convert.ToInt32(oRow["SBUID"].ToString());
                    oDailySalesReport.SBUCode = (string)oRow["SBUCode"];
                    oDailySalesReport.SBUName = (string)oRow["SBUName"];
                    oDailySalesReport.ChannelId = (int)oRow["ChannelID"];
                    oDailySalesReport.ChannelCode = (string)oRow["ChannelCode"];
                    oDailySalesReport.ChannelName = (string)oRow["ChannelName"];
                    oDailySalesReport.CustomerTypeId = (int)oRow["CustomerTypeId"];
                    oDailySalesReport.CustomerTypeCode = (string)oRow["CustomerTypeCode"];
                    oDailySalesReport.CustomerTypeName = (string)oRow["CustomerTypeName"];
                    oDailySalesReport.AreaId = (int)oRow["AreaId"];
                    oDailySalesReport.AreaCode = (string)oRow["AreaCode"];
                    oDailySalesReport.AreaName = (string)oRow["AreaName"];
                    oDailySalesReport.TerritoryId = (int)oRow["TerritoryId"];
                    oDailySalesReport.TerritoryCode = (string)oRow["TerritoryCode"];
                    oDailySalesReport.TerritoryName = (string)oRow["TerritoryName"];
                    oDailySalesReport.CustomerId = (int)oRow["CustomerId"];
                    oDailySalesReport.CustomerCode = (string)oRow["CustomerCode"];
                    oDailySalesReport.CustomerName = (string)oRow["CustomerName"];

                    oDailySalesReport.DailySales = (double)oRow["DailySales"];
                    oDailySalesReport.MonthlySales = (double)oRow["MonthlySales"];
                    oDailySalesReport.YearlySales = (double)oRow["YearlySales"];
                    oDailySalesReport.MonthlyTarget = (double)oRow["MonthlyTarget"];
                    oDailySalesReport.YearlyTarget = (double)oRow["YearlyTarget"];

                    InnerList.Add(oDailySalesReport);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Territory wise daily slaes report
        /// </summary>
        /// 
        public void DailySalesReportTerritoryWise(DateTime dYFromDate, DateTime dYToDate, DateTime dMFromDate, DateTime dMToDate, DateTime dDFromDate, DateTime dDToDate)
        {
            dYToDate = dYToDate.AddDays(1);
            dMToDate = dMToDate.AddDays(1);
            dDToDate = dDToDate.AddDays(1);

            // InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();


            sQueryStringMaster.Append("Select SBUID,SBUCode,SBUName,ChannelID,ChannelCode,Channeldescription AS ChannelName,  ");
            sQueryStringMaster.Append("AreaID,AreaCode,AreaName,TerritoryID,TerritoryCode,TerritoryName, ");
            sQueryStringMaster.Append("isnull(sum(DailySales),0)as DailySales, isnull(sum(MonthlySales),0)as MonthlySales, isnull(sum(YearlySales),0) as YearlySales, ");
            sQueryStringMaster.Append("isnull(sum(MonthlyTarget),0) as MonthlyTarget,isnull(sum(YearlyTarget),0) as YearlyTarget ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("Select isnull(sales.customerid,target.Customerid)as CustomerID, ");
            sQueryStringMaster.Append("isnull(DailySales,0)as DailySales, isnull(MonthlySales,0)as MonthlySales, isnull(YearlySales,0) as YearlySales, ");
            sQueryStringMaster.Append("isnull(YearlyTarget,0) as YearlyTarget,isnull(MonthlyTarget,0) as MonthlyTarget ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("Select p1.Customerid,isnull(DailySales,0)as DailySales, isnull(MonthlySales,0)as MonthlySales, isnull(YearlySales,0) as YearlySales  ");
            sQueryStringMaster.Append("From  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as YearlySales  ");
            sQueryStringMaster.Append("From  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ? and im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append("union all  ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount, sum(invoiceamount)as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ? and im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(")as qq1  ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(")as p1  ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as MonthlySales  ");
            sQueryStringMaster.Append("From  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ? and im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append("union all  ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount, sum(invoiceamount)as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ? and im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(")as qq1  ");
            sQueryStringMaster.Append("Group By Customerid             ");
            sQueryStringMaster.Append(")as p2 on p1.customerid = p2.customerid  ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as DailySales  ");
            sQueryStringMaster.Append("From  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ? and im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append("union all  ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount, sum(invoiceamount)as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where invoicedate between ? and ? and invoicedate< ? and im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(")as qq1  ");
            sQueryStringMaster.Append("Group By Customerid             ");
            sQueryStringMaster.Append(")as p3 on p1.customerid = p3.customerid  ");
            sQueryStringMaster.Append(") as Sales ");
            sQueryStringMaster.Append("Full outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("Select y.CustomerID, isnull(YearlyTarget,0) as YearlyTarget,isnull(MonthlyTarget,0) as MonthlyTarget  ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select MarketGroupID as Customerid, sum (Turnover)as YearlyTarget  ");
            sQueryStringMaster.Append("from t_planbudgettarget  ");
            sQueryStringMaster.Append("where plantype in (?) and productgrouptype in (?) and periodtype in (?) and MarketScopeType in (?)   ");
            sQueryStringMaster.Append("and perioddate between ? and ?  ");
            sQueryStringMaster.Append("group by  MarketGroupID ");
            sQueryStringMaster.Append(")as Y ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select MarketGroupID as Customerid, sum (Turnover)as MonthlyTarget  ");
            sQueryStringMaster.Append("from t_planbudgettarget  ");
            sQueryStringMaster.Append("where plantype in (?) and productgrouptype in (?) and periodtype in (?) and MarketScopeType in (?)   ");
            sQueryStringMaster.Append("and perioddate between ? and ?  ");
            sQueryStringMaster.Append("group by  MarketGroupID ");
            sQueryStringMaster.Append(") as m on y.Customerid = m.Customerid ");
            sQueryStringMaster.Append(") as Target on sales.customerid = target.Customerid ");
            sQueryStringMaster.Append(")as st ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("SELECT * from v_customerdetails  ");
            sQueryStringMaster.Append(")as cd on st.customerid = cd.customerid ");
            sQueryStringMaster.Append("Group by ");
            sQueryStringMaster.Append("SBUID,SBUCode,SBUName,ChannelID,ChannelCode,Channeldescription, AreaID,AreaCode,AreaName,  ");
            sQueryStringMaster.Append("TerritoryID,TerritoryCode,TerritoryName ");



            OleDbCommand oCmd = DBController.Instance.GetCommand();
            //Command time out
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();



            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);


            oCmd.Parameters.AddWithValue("InvoiceDate", dDFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dDFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("PlanType", (short)Dictionary.PlanType.Target);
            oCmd.Parameters.AddWithValue("ProductGroupType", (short)Dictionary.BudgetTargetProductGroupType.Product);
            oCmd.Parameters.AddWithValue("PeriodType", (short)Dictionary.PeriodType.Monthly);
            oCmd.Parameters.AddWithValue("MarketScopeType", (short)Dictionary.MarketScopeType.Customer);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);

            oCmd.Parameters.AddWithValue("PlanType", (short)Dictionary.PlanType.Target);
            oCmd.Parameters.AddWithValue("ProductGroupType", (short)Dictionary.BudgetTargetProductGroupType.Product);
            oCmd.Parameters.AddWithValue("PeriodType", (short)Dictionary.PeriodType.Monthly);
            oCmd.Parameters.AddWithValue("MarketScopeType", (short)Dictionary.MarketScopeType.Customer);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);


            GetDataTerritoryWise(oCmd);

        }

        /// <summary>
        /// Territory wise daily Net slaes report
        /// </summary>
        /// 
        public void DailyNetSalesReportTerritoryWise(DateTime dYFromDate, DateTime dYToDate, DateTime dMFromDate, DateTime dMToDate, DateTime dDFromDate, DateTime dDToDate)
        {
            dYToDate = dYToDate.AddDays(1);
            dMToDate = dMToDate.AddDays(1);
            dDToDate = dDToDate.AddDays(1);

            // InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();


            //***Modified by Kanij Dated on 29-APR-2015***

            sQueryStringMaster.Append("Select SBUID,SBUCode,SBUName,ChannelID,ChannelCode,Channeldescription AS ChannelName,  ");
            sQueryStringMaster.Append("AreaID,AreaCode,AreaName,TerritoryID,TerritoryCode,TerritoryName, ");
            sQueryStringMaster.Append("isnull(sum(DailySales),0)as DailySales, isnull(sum(MonthlySales),0)as MonthlySales, isnull(sum(YearlySales),0) as YearlySales, ");
            sQueryStringMaster.Append("isnull(sum(MonthlyTarget),0) as MonthlyTarget,isnull(sum(YearlyTarget),0) as YearlyTarget ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("Select isnull(sales.customerid,target.Customerid)as CustomerID, ");
            sQueryStringMaster.Append("isnull(DailySales,0)as DailySales, isnull(MonthlySales,0)as MonthlySales, isnull(YearlySales,0) as YearlySales, ");
            sQueryStringMaster.Append("isnull(YearlyTarget,0) as YearlyTarget,isnull(MonthlyTarget,0) as MonthlyTarget ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("Select p1.Customerid,isnull(DailySales,0)as DailySales, isnull(MonthlySales,0)as MonthlySales, isnull(YearlySales,0) as YearlySales  ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrNetSalesAmount)- abs(sum(DrNetSaleAmount)),0) as YearlySales  ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select a.Customerid,(CrSalesAmount-isnull(vat,0))as  CrNetSalesAmount,DrSalesAmount as DrNetSaleAmount  ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ?  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(") as a  ");
            sQueryStringMaster.Append("inner join  ");
            sQueryStringMaster.Append("(select CustomerID,sum(Quantity*Tradeprice*vatamount)as VAT  ");
            sQueryStringMaster.Append("from t_salesinvoice sa , t_salesinvoicedetail sd  ");
            sQueryStringMaster.Append("where sa.invoiceid = sd.invoiceid and invoicedate between ? and ? and invoicedate < ?  ");
            sQueryStringMaster.Append("and invoicetypeid in (?,?,?,?)and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group by customerid  ");
            sQueryStringMaster.Append(")as b on a.customerid=b.customerid  ");
            sQueryStringMaster.Append("union all  ");
            sQueryStringMaster.Append("select a.Customerid,CrSalesAmount as CrNetSaleAmount,(DrSalesAmount-isnull(vat,0))as  DrNetSalesAmount ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as DrSalesAmount, 0 as CrSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ?  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(") as a  ");
            sQueryStringMaster.Append("inner join  ");
            sQueryStringMaster.Append("(select CustomerID,sum(Quantity*Tradeprice*vatamount)as VAT ");
            sQueryStringMaster.Append("from t_salesinvoice sa , t_salesinvoicedetail sd  ");
            sQueryStringMaster.Append("where sa.invoiceid = sd.invoiceid and invoicedate between ? and ? and invoicedate < ?  ");
            sQueryStringMaster.Append("and invoicetypeid in (?,?,?,?,?)and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as b on a.customerid=b.customerid  ");
            sQueryStringMaster.Append(")as qq1  ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(")as p1  ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");

            sQueryStringMaster.Append("select Customerid, isnull(sum(CrNetSalesAmount)- abs(sum(DrNetSaleAmount)),0) as MonthlySales  ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select a.Customerid,(CrSalesAmount-isnull(vat,0))as  CrNetSalesAmount,DrSalesAmount as DrNetSaleAmount ");
            sQueryStringMaster.Append("From  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount ");
            sQueryStringMaster.Append("from t_SalesInvoice im  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ?  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(") as a  ");
            sQueryStringMaster.Append("inner join  ");
            sQueryStringMaster.Append("(select CustomerID,sum(Quantity*Tradeprice*vatamount)as VAT  ");
            sQueryStringMaster.Append("from t_salesinvoice sa , t_salesinvoicedetail sd  ");
            sQueryStringMaster.Append("where sa.invoiceid = sd.invoiceid and invoicedate between ? and ? and invoicedate < ?  ");
            sQueryStringMaster.Append("and invoicetypeid in (?,?,?,?)and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group by customerid  ");
            sQueryStringMaster.Append(")as b on a.customerid=b.customerid ");
            sQueryStringMaster.Append("union all  ");
            sQueryStringMaster.Append("select a.Customerid,CrSalesAmount as CrNetSaleAmount,(DrSalesAmount-isnull(vat,0))as  DrNetSalesAmount ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as DrSalesAmount, 0 as CrSalesAmount ");
            sQueryStringMaster.Append("from t_SalesInvoice im  ");
            sQueryStringMaster.Append("where invoicedate between ? and ? and invoicedate< ? ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(") as a ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("(select CustomerID,sum(Quantity*Tradeprice*vatamount)as VAT ");
            sQueryStringMaster.Append("from t_salesinvoice sa , t_salesinvoicedetail sd ");
            sQueryStringMaster.Append("where sa.invoiceid = sd.invoiceid and invoicedate between ? and ? and invoicedate < ? ");
            sQueryStringMaster.Append("and invoicetypeid in (?,?,?,?,?)and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group by customerid  ");
            sQueryStringMaster.Append(")as b on a.customerid=b.customerid  ");
            sQueryStringMaster.Append(")as qq1  ");
            sQueryStringMaster.Append("Group By Customerid             ");
            sQueryStringMaster.Append(")as p2 on p1.customerid = p2.customerid  ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");

            sQueryStringMaster.Append("select Customerid, isnull(sum(CrNetSalesAmount)- abs(sum(DrNetSaleAmount)),0) as DailySales ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select a.Customerid,(CrSalesAmount-isnull(vat,0))as  CrNetSalesAmount,DrSalesAmount as DrNetSaleAmount ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount ");
            sQueryStringMaster.Append("from t_SalesInvoice im  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ?  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(") as a  ");
            sQueryStringMaster.Append("inner join  ");
            sQueryStringMaster.Append("(select CustomerID,sum(Quantity*Tradeprice*vatamount)as VAT ");
            sQueryStringMaster.Append("from t_salesinvoice sa , t_salesinvoicedetail sd  ");
            sQueryStringMaster.Append("where sa.invoiceid = sd.invoiceid and invoicedate between ? and ? and invoicedate < ?  ");
            sQueryStringMaster.Append("and invoicetypeid in (?,?,?,?)and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group by customerid  ");
            sQueryStringMaster.Append(")as b on a.customerid=b.customerid  ");
            sQueryStringMaster.Append("union all ");
            sQueryStringMaster.Append("select a.Customerid,CrSalesAmount as CrNetSaleAmount,(DrSalesAmount-isnull(vat,0))as  DrNetSalesAmount ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as DrSalesAmount, 0 as CrSalesAmount ");
            sQueryStringMaster.Append("from t_SalesInvoice im ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ? ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(") as a ");
            sQueryStringMaster.Append("inner join  ");
            sQueryStringMaster.Append("(select CustomerID,sum(Quantity*Tradeprice*vatamount)as VAT ");
            sQueryStringMaster.Append("from t_salesinvoice sa , t_salesinvoicedetail sd ");
            sQueryStringMaster.Append("where sa.invoiceid = sd.invoiceid and invoicedate between ? and ? and invoicedate < ?  ");
            sQueryStringMaster.Append("and invoicetypeid in (?,?,?,?,?)and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group by customerid  ");
            sQueryStringMaster.Append(")as b on a.customerid=b.customerid ");
            sQueryStringMaster.Append(")as qq1 ");
            sQueryStringMaster.Append("Group By Customerid             ");
            sQueryStringMaster.Append(")as p3 on p1.customerid = p3.customerid  ");
            sQueryStringMaster.Append(") as Sales  ");
            sQueryStringMaster.Append("Full outer join ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("Select y.CustomerID, isnull(YearlyTarget,0) as YearlyTarget,isnull(MonthlyTarget,0) as MonthlyTarget ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select MarketGroupID as Customerid, sum (Turnover)as YearlyTarget ");
            sQueryStringMaster.Append("from t_planbudgettarget ");
            sQueryStringMaster.Append("where plantype in (?) and productgrouptype in (?) and periodtype in (?) and MarketScopeType in (?) ");
            sQueryStringMaster.Append("and perioddate between ? and ? ");
            sQueryStringMaster.Append("group by  MarketGroupID ");
            sQueryStringMaster.Append(")as Y  ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select MarketGroupID as Customerid, sum (Turnover)as MonthlyTarget  ");
            sQueryStringMaster.Append("from t_planbudgettarget ");
            sQueryStringMaster.Append("where plantype in (?) and productgrouptype in (?) and periodtype in (?) and MarketScopeType in (?)  ");
            sQueryStringMaster.Append("and perioddate between ? and ?  ");
            sQueryStringMaster.Append("group by  MarketGroupID  ");
            sQueryStringMaster.Append(") as m on y.Customerid = m.Customerid  ");
            sQueryStringMaster.Append(") as Target on sales.customerid = target.Customerid  ");
            sQueryStringMaster.Append(")as st  ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("SELECT * from v_customerdetails ");
            sQueryStringMaster.Append(")as cd on st.customerid = cd.customerid  ");
            sQueryStringMaster.Append("Group by  ");
            sQueryStringMaster.Append("SBUID,SBUCode,SBUName,ChannelID,ChannelCode,Channeldescription, AreaID,AreaCode,AreaName,  ");
            sQueryStringMaster.Append("TerritoryID,TerritoryCode,TerritoryName ");




            OleDbCommand oCmd = DBController.Instance.GetCommand();
            //Command time out
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();



            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);


            oCmd.Parameters.AddWithValue("InvoiceDate", dDFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dDFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dDFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dDFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("PlanType", (short)Dictionary.PlanType.Target);
            oCmd.Parameters.AddWithValue("ProductGroupType", (short)Dictionary.BudgetTargetProductGroupType.Product);
            oCmd.Parameters.AddWithValue("PeriodType", (short)Dictionary.PeriodType.Monthly);
            oCmd.Parameters.AddWithValue("MarketScopeType", (short)Dictionary.MarketScopeType.Customer);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);

            oCmd.Parameters.AddWithValue("PlanType", (short)Dictionary.PlanType.Target);
            oCmd.Parameters.AddWithValue("ProductGroupType", (short)Dictionary.BudgetTargetProductGroupType.Product);
            oCmd.Parameters.AddWithValue("PeriodType", (short)Dictionary.PeriodType.Monthly);
            oCmd.Parameters.AddWithValue("MarketScopeType", (short)Dictionary.MarketScopeType.Customer);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);



            GetDataTerritoryWise(oCmd);

        }

        private void GetDataTerritoryWise(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DailySalesReport oItem = new DailySalesReport();

                    if (reader["SBUID"] != DBNull.Value)
                        oItem.SBUID = Convert.ToInt32(reader["SBUID"]);
                    else oItem.SBUID = -1;
                    if (reader["SBUCode"] != DBNull.Value)
                        oItem.SBUCode = (string)reader["SBUCode"];
                    else oItem.SBUCode = "";
                    if (reader["SBUName"] != DBNull.Value)
                        oItem.SBUName = (string)reader["SBUName"];
                    else oItem.SBUName = "";
                    if (reader["ChannelID"] != DBNull.Value)
                        oItem.ChannelId = (int)reader["ChannelID"];
                    else oItem.ChannelId = -1;
                    if (reader["ChannelCode"] != DBNull.Value)
                        oItem.ChannelCode = (string)reader["ChannelCode"];
                    else oItem.ChannelCode = "";
                    if (reader["ChannelName"] != DBNull.Value)
                        oItem.ChannelName = (string)reader["ChannelName"];
                    else oItem.ChannelName = "";

                    oItem.CustomerTypeId = -1;
                    oItem.CustomerTypeCode = "";
                    oItem.CustomerTypeName = "";

                    if (reader["AreaId"] != DBNull.Value)
                        oItem.AreaId = (int)reader["AreaId"];
                    else oItem.AreaId = -1;
                    if (reader["AreaCode"] != DBNull.Value)
                        oItem.AreaCode = (string)reader["AreaCode"];
                    else oItem.AreaCode = "";
                    if (reader["AreaName"] != DBNull.Value)
                        oItem.AreaName = (string)reader["AreaName"];
                    else oItem.AreaName = "";
                    if (reader["TerritoryId"] != DBNull.Value)
                        oItem.TerritoryId = (int)reader["TerritoryId"];
                    else oItem.TerritoryId = -1;
                    if (reader["TerritoryCode"] != DBNull.Value)
                        oItem.TerritoryCode = (string)reader["TerritoryCode"];
                    else oItem.TerritoryCode = "";
                    if (reader["TerritoryName"] != DBNull.Value)
                        oItem.TerritoryName = (string)reader["TerritoryName"];
                    else oItem.TerritoryName = "";

                    oItem.CustomerId = -1;
                    oItem.CustomerCode = "";
                    oItem.CustomerName = "";

                    if (reader["DailySales"] != DBNull.Value)
                        oItem.DailySales = (double)reader["DailySales"];
                    else oItem.DailySales = 0;
                    if (reader["MonthlySales"] != DBNull.Value)
                        oItem.MonthlySales = (double)reader["MonthlySales"];
                    else oItem.MonthlySales = 0;
                    if (reader["YearlySales"] != DBNull.Value)
                        oItem.YearlySales = (double)reader["YearlySales"];
                    else oItem.YearlySales = 0;
                    if (reader["MonthlyTarget"] != DBNull.Value)
                        oItem.MonthlyTarget = (double)reader["MonthlyTarget"];
                    else oItem.MonthlyTarget = 0;
                    if (reader["YearlyTarget"] != DBNull.Value)
                        oItem.YearlyTarget = (double)reader["YearlyTarget"];
                    else oItem.YearlyTarget = 0;



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
        public void FromDataSetForTerritoryWise(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    DailySalesReport oDailySalesReport = new DailySalesReport();

                    oDailySalesReport.SBUID = Convert.ToInt32(oRow["SBUID"].ToString());
                    oDailySalesReport.SBUCode = (string)oRow["SBUCode"];
                    oDailySalesReport.SBUName = (string)oRow["SBUName"];
                    oDailySalesReport.ChannelId = (int)oRow["ChannelID"];
                    oDailySalesReport.ChannelCode = (string)oRow["ChannelCode"];
                    oDailySalesReport.ChannelName = (string)oRow["ChannelName"];
                    oDailySalesReport.CustomerTypeId = -1;
                    oDailySalesReport.CustomerTypeCode = "";
                    oDailySalesReport.CustomerTypeName = "";
                    oDailySalesReport.AreaId = (int)oRow["AreaId"];
                    oDailySalesReport.AreaCode = (string)oRow["AreaCode"];
                    oDailySalesReport.AreaName = (string)oRow["AreaName"];
                    oDailySalesReport.TerritoryId = (int)oRow["TerritoryId"];
                    oDailySalesReport.TerritoryCode = (string)oRow["TerritoryCode"];
                    oDailySalesReport.TerritoryName = (string)oRow["TerritoryName"];
                    oDailySalesReport.CustomerId = -1;
                    oDailySalesReport.CustomerCode = "";
                    oDailySalesReport.CustomerName = "";

                    oDailySalesReport.DailySales = (double)oRow["DailySales"];
                    oDailySalesReport.MonthlySales = (double)oRow["MonthlySales"];
                    oDailySalesReport.YearlySales = (double)oRow["YearlySales"];
                    oDailySalesReport.MonthlyTarget = (double)oRow["MonthlyTarget"];
                    oDailySalesReport.YearlyTarget = (double)oRow["YearlyTarget"];

                    InnerList.Add(oDailySalesReport);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Area wise daily slaes report
        /// </summary>
        /// 
        public void DailySalesReportAreaWise(DateTime dYFromDate, DateTime dYToDate, DateTime dMFromDate, DateTime dMToDate, DateTime dDFromDate, DateTime dDToDate)
        {
            dYToDate = dYToDate.AddDays(1);
            dMToDate = dMToDate.AddDays(1);
            dDToDate = dDToDate.AddDays(1);

            // InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();


            sQueryStringMaster.Append("Select SBUID,SBUCode,SBUName,ChannelID,ChannelCode,Channeldescription AS ChannelName,  ");
            sQueryStringMaster.Append("AreaID,AreaCode,AreaName, ");
            sQueryStringMaster.Append("isnull(sum(DailySales),0)as DailySales, isnull(sum(MonthlySales),0)as MonthlySales, isnull(sum(YearlySales),0) as YearlySales, ");
            sQueryStringMaster.Append("isnull(sum(MonthlyTarget),0) as MonthlyTarget,isnull(sum(YearlyTarget),0) as YearlyTarget ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("Select isnull(sales.customerid,target.Customerid)as CustomerID, ");
            sQueryStringMaster.Append("isnull(DailySales,0)as DailySales, isnull(MonthlySales,0)as MonthlySales, isnull(YearlySales,0) as YearlySales, ");
            sQueryStringMaster.Append("isnull(YearlyTarget,0) as YearlyTarget,isnull(MonthlyTarget,0) as MonthlyTarget ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("Select p1.Customerid,isnull(DailySales,0)as DailySales, isnull(MonthlySales,0)as MonthlySales, isnull(YearlySales,0) as YearlySales  ");
            sQueryStringMaster.Append("From  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as YearlySales  ");
            sQueryStringMaster.Append("From  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ? and im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append("union all  ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount, sum(invoiceamount)as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ? and im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(")as qq1  ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(")as p1  ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as MonthlySales  ");
            sQueryStringMaster.Append("From  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ? and im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append("union all  ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount, sum(invoiceamount)as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ? and im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(")as qq1  ");
            sQueryStringMaster.Append("Group By Customerid             ");
            sQueryStringMaster.Append(")as p2 on p1.customerid = p2.customerid  ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as DailySales  ");
            sQueryStringMaster.Append("From  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ? and im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append("union all  ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount, sum(invoiceamount)as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where invoicedate between ? and ? and invoicedate< ? and im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(")as qq1  ");
            sQueryStringMaster.Append("Group By Customerid             ");
            sQueryStringMaster.Append(")as p3 on p1.customerid = p3.customerid  ");
            sQueryStringMaster.Append(") as Sales ");
            sQueryStringMaster.Append("Full outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("Select y.CustomerID, isnull(YearlyTarget,0) as YearlyTarget,isnull(MonthlyTarget,0) as MonthlyTarget  ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select MarketGroupID as Customerid, sum (Turnover)as YearlyTarget  ");
            sQueryStringMaster.Append("from t_planbudgettarget  ");
            sQueryStringMaster.Append("where plantype in (?) and productgrouptype in (?) and periodtype in (?) and MarketScopeType in (?)   ");
            sQueryStringMaster.Append("and perioddate between ? and ?  ");
            sQueryStringMaster.Append("group by  MarketGroupID ");
            sQueryStringMaster.Append(")as Y ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select MarketGroupID as Customerid, sum (Turnover)as MonthlyTarget  ");
            sQueryStringMaster.Append("from t_planbudgettarget  ");
            sQueryStringMaster.Append("where plantype in (?) and productgrouptype in (?) and periodtype in (?) and MarketScopeType in (?)   ");
            sQueryStringMaster.Append("and perioddate between ? and ?  ");
            sQueryStringMaster.Append("group by  MarketGroupID ");
            sQueryStringMaster.Append(") as m on y.Customerid = m.Customerid ");
            sQueryStringMaster.Append(") as Target on sales.customerid = target.Customerid ");
            sQueryStringMaster.Append(")as st ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("SELECT * from v_customerdetails  ");
            sQueryStringMaster.Append(")as cd on st.customerid = cd.customerid ");
            sQueryStringMaster.Append("Group by ");
            sQueryStringMaster.Append("SBUID,SBUCode,SBUName,ChannelID,ChannelCode,Channeldescription, AreaID,AreaCode,AreaName  ");




            OleDbCommand oCmd = DBController.Instance.GetCommand();
            //Command time out
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();



            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);


            oCmd.Parameters.AddWithValue("InvoiceDate", dDFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dDFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("PlanType", (short)Dictionary.PlanType.Target);
            oCmd.Parameters.AddWithValue("ProductGroupType", (short)Dictionary.BudgetTargetProductGroupType.Product);
            oCmd.Parameters.AddWithValue("PeriodType", (short)Dictionary.PeriodType.Monthly);
            oCmd.Parameters.AddWithValue("MarketScopeType", (short)Dictionary.MarketScopeType.Customer);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);

            oCmd.Parameters.AddWithValue("PlanType", (short)Dictionary.PlanType.Target);
            oCmd.Parameters.AddWithValue("ProductGroupType", (short)Dictionary.BudgetTargetProductGroupType.Product);
            oCmd.Parameters.AddWithValue("PeriodType", (short)Dictionary.PeriodType.Monthly);
            oCmd.Parameters.AddWithValue("MarketScopeType", (short)Dictionary.MarketScopeType.Customer);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);


            GetDataAreaWise(oCmd);

        }

        /// <summary>
        /// Area wise daily Net slaes report
        /// </summary>
        ///

        public void DailyNetSalesReportAreaWise(DateTime dYFromDate, DateTime dYToDate, DateTime dMFromDate, DateTime dMToDate, DateTime dDFromDate, DateTime dDToDate)
        {
            dYToDate = dYToDate.AddDays(1);
            dMToDate = dMToDate.AddDays(1);
            dDToDate = dDToDate.AddDays(1);

            // InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();




            //***Modified by Kanij Dated on 29-APR-2015***

            sQueryStringMaster.Append("Select SBUID,SBUCode,SBUName,ChannelID,ChannelCode,Channeldescription AS ChannelName, ");
            sQueryStringMaster.Append("AreaID,AreaCode,AreaName, ");
            sQueryStringMaster.Append("isnull(sum(DailySales),0)as DailySales, isnull(sum(MonthlySales),0)as MonthlySales, isnull(sum(YearlySales),0) as YearlySales, ");
            sQueryStringMaster.Append("isnull(sum(MonthlyTarget),0) as MonthlyTarget,isnull(sum(YearlyTarget),0) as YearlyTarget  ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("Select isnull(sales.customerid,target.Customerid)as CustomerID,  ");
            sQueryStringMaster.Append("isnull(DailySales,0)as DailySales, isnull(MonthlySales,0)as MonthlySales, isnull(YearlySales,0) as YearlySales, ");
            sQueryStringMaster.Append("isnull(YearlyTarget,0) as YearlyTarget,isnull(MonthlyTarget,0) as MonthlyTarget ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("Select p1.Customerid,isnull(DailySales,0)as DailySales, isnull(MonthlySales,0)as MonthlySales, isnull(YearlySales,0) as YearlySales  ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrNetSalesAmount)- abs(sum(DrNetSaleAmount)),0) as YearlySales  ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select a.Customerid,(CrSalesAmount-isnull(vat,0))as  CrNetSalesAmount,DrSalesAmount as DrNetSaleAmount  ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ?  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(") as a  ");
            sQueryStringMaster.Append("inner join  ");
            sQueryStringMaster.Append("(select CustomerID,sum(Quantity*Tradeprice*vatamount)as VAT  ");
            sQueryStringMaster.Append("from t_salesinvoice sa , t_salesinvoicedetail sd  ");
            sQueryStringMaster.Append("where sa.invoiceid = sd.invoiceid and invoicedate between ? and ? and invoicedate < ?  ");
            sQueryStringMaster.Append("and invoicetypeid in (?,?,?,?)and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group by customerid  ");
            sQueryStringMaster.Append(")as b on a.customerid=b.customerid  ");
            sQueryStringMaster.Append("union all  ");
            sQueryStringMaster.Append("select a.Customerid,CrSalesAmount as CrNetSaleAmount,(DrSalesAmount-isnull(vat,0))as  DrNetSalesAmount ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as DrSalesAmount, 0 as CrSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ?  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(") as a  ");
            sQueryStringMaster.Append("inner join  ");
            sQueryStringMaster.Append("(select CustomerID,sum(Quantity*Tradeprice*vatamount)as VAT ");
            sQueryStringMaster.Append("from t_salesinvoice sa , t_salesinvoicedetail sd  ");
            sQueryStringMaster.Append("where sa.invoiceid = sd.invoiceid and invoicedate between ? and ? and invoicedate < ?  ");
            sQueryStringMaster.Append("and invoicetypeid in (?,?,?,?,?)and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as b on a.customerid=b.customerid  ");
            sQueryStringMaster.Append(")as qq1  ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(")as p1  ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");

            sQueryStringMaster.Append("select Customerid, isnull(sum(CrNetSalesAmount)- abs(sum(DrNetSaleAmount)),0) as MonthlySales  ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select a.Customerid,(CrSalesAmount-isnull(vat,0))as  CrNetSalesAmount,DrSalesAmount as DrNetSaleAmount ");
            sQueryStringMaster.Append("From  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount ");
            sQueryStringMaster.Append("from t_SalesInvoice im  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ?  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(") as a  ");
            sQueryStringMaster.Append("inner join  ");
            sQueryStringMaster.Append("(select CustomerID,sum(Quantity*Tradeprice*vatamount)as VAT  ");
            sQueryStringMaster.Append("from t_salesinvoice sa , t_salesinvoicedetail sd  ");
            sQueryStringMaster.Append("where sa.invoiceid = sd.invoiceid and invoicedate between ? and ? and invoicedate < ?  ");
            sQueryStringMaster.Append("and invoicetypeid in (?,?,?,?)and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group by customerid  ");
            sQueryStringMaster.Append(")as b on a.customerid=b.customerid ");
            sQueryStringMaster.Append("union all  ");
            sQueryStringMaster.Append("select a.Customerid,CrSalesAmount as CrNetSaleAmount,(DrSalesAmount-isnull(vat,0))as  DrNetSalesAmount ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as DrSalesAmount, 0 as CrSalesAmount ");
            sQueryStringMaster.Append("from t_SalesInvoice im  ");
            sQueryStringMaster.Append("where invoicedate between ? and ? and invoicedate< ? ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(") as a ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("(select CustomerID,sum(Quantity*Tradeprice*vatamount)as VAT ");
            sQueryStringMaster.Append("from t_salesinvoice sa , t_salesinvoicedetail sd ");
            sQueryStringMaster.Append("where sa.invoiceid = sd.invoiceid and invoicedate between ? and ? and invoicedate < ? ");
            sQueryStringMaster.Append("and invoicetypeid in (?,?,?,?,?)and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group by customerid  ");
            sQueryStringMaster.Append(")as b on a.customerid=b.customerid  ");
            sQueryStringMaster.Append(")as qq1  ");
            sQueryStringMaster.Append("Group By Customerid             ");
            sQueryStringMaster.Append(")as p2 on p1.customerid = p2.customerid  ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");

            sQueryStringMaster.Append("select Customerid, isnull(sum(CrNetSalesAmount)- abs(sum(DrNetSaleAmount)),0) as DailySales ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select a.Customerid,(CrSalesAmount-isnull(vat,0))as  CrNetSalesAmount,DrSalesAmount as DrNetSaleAmount ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount ");
            sQueryStringMaster.Append("from t_SalesInvoice im  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ?  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(") as a  ");
            sQueryStringMaster.Append("inner join  ");
            sQueryStringMaster.Append("(select CustomerID,sum(Quantity*Tradeprice*vatamount)as VAT ");
            sQueryStringMaster.Append("from t_salesinvoice sa , t_salesinvoicedetail sd  ");
            sQueryStringMaster.Append("where sa.invoiceid = sd.invoiceid and invoicedate between ? and ? and invoicedate < ?  ");
            sQueryStringMaster.Append("and invoicetypeid in (?,?,?,?)and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group by customerid  ");
            sQueryStringMaster.Append(")as b on a.customerid=b.customerid  ");
            sQueryStringMaster.Append("union all ");
            sQueryStringMaster.Append("select a.Customerid,CrSalesAmount as CrNetSaleAmount,(DrSalesAmount-isnull(vat,0))as  DrNetSalesAmount ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as DrSalesAmount, 0 as CrSalesAmount ");
            sQueryStringMaster.Append("from t_SalesInvoice im ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ? ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(") as a ");
            sQueryStringMaster.Append("inner join  ");
            sQueryStringMaster.Append("(select CustomerID,sum(Quantity*Tradeprice*vatamount)as VAT ");
            sQueryStringMaster.Append("from t_salesinvoice sa , t_salesinvoicedetail sd ");
            sQueryStringMaster.Append("where sa.invoiceid = sd.invoiceid and invoicedate between ? and ? and invoicedate < ?  ");
            sQueryStringMaster.Append("and invoicetypeid in (?,?,?,?,?)and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group by customerid  ");
            sQueryStringMaster.Append(")as b on a.customerid=b.customerid ");
            sQueryStringMaster.Append(")as qq1 ");
            sQueryStringMaster.Append("Group By Customerid             ");
            sQueryStringMaster.Append(")as p3 on p1.customerid = p3.customerid  ");
            sQueryStringMaster.Append(") as Sales  ");
            sQueryStringMaster.Append("Full outer join ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("Select y.CustomerID, isnull(YearlyTarget,0) as YearlyTarget,isnull(MonthlyTarget,0) as MonthlyTarget ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select MarketGroupID as Customerid, sum (Turnover)as YearlyTarget ");
            sQueryStringMaster.Append("from t_planbudgettarget ");
            sQueryStringMaster.Append("where plantype in (?) and productgrouptype in (?) and periodtype in (?) and MarketScopeType in (?) ");
            sQueryStringMaster.Append("and perioddate between ? and ? ");
            sQueryStringMaster.Append("group by  MarketGroupID ");
            sQueryStringMaster.Append(")as Y  ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select MarketGroupID as Customerid, sum (Turnover)as MonthlyTarget  ");
            sQueryStringMaster.Append("from t_planbudgettarget ");
            sQueryStringMaster.Append("where plantype in (?) and productgrouptype in (?) and periodtype in (?) and MarketScopeType in (?)  ");
            sQueryStringMaster.Append("and perioddate between ? and ?  ");
            sQueryStringMaster.Append("group by  MarketGroupID  ");
            sQueryStringMaster.Append(") as m on y.Customerid = m.Customerid  ");
            sQueryStringMaster.Append(") as Target on sales.customerid = target.Customerid  ");
            sQueryStringMaster.Append(")as st  ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("SELECT * from v_customerdetails ");
            sQueryStringMaster.Append(")as cd on st.customerid = cd.customerid  ");
            sQueryStringMaster.Append("Group by  ");
            sQueryStringMaster.Append("SBUID,SBUCode,SBUName,ChannelID,ChannelCode,Channeldescription, AreaID,AreaCode,AreaName  ");



            OleDbCommand oCmd = DBController.Instance.GetCommand();
            //Command time out
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();



            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);


            oCmd.Parameters.AddWithValue("InvoiceDate", dDFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dDFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dDFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dDFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("PlanType", (short)Dictionary.PlanType.Target);
            oCmd.Parameters.AddWithValue("ProductGroupType", (short)Dictionary.BudgetTargetProductGroupType.Product);
            oCmd.Parameters.AddWithValue("PeriodType", (short)Dictionary.PeriodType.Monthly);
            oCmd.Parameters.AddWithValue("MarketScopeType", (short)Dictionary.MarketScopeType.Customer);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);

            oCmd.Parameters.AddWithValue("PlanType", (short)Dictionary.PlanType.Target);
            oCmd.Parameters.AddWithValue("ProductGroupType", (short)Dictionary.BudgetTargetProductGroupType.Product);
            oCmd.Parameters.AddWithValue("PeriodType", (short)Dictionary.PeriodType.Monthly);
            oCmd.Parameters.AddWithValue("MarketScopeType", (short)Dictionary.MarketScopeType.Customer);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);





            // GetDataChannelWise(oCmd);

            GetDataAreaWise(oCmd);

        }

        private void GetDataAreaWise(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DailySalesReport oItem = new DailySalesReport();

                    if (reader["SBUID"] != DBNull.Value)
                        oItem.SBUID = Convert.ToInt32(reader["SBUID"]);
                    else oItem.SBUID = -1;
                    if (reader["SBUCode"] != DBNull.Value)
                        oItem.SBUCode = (string)reader["SBUCode"];
                    else oItem.SBUCode = "";
                    if (reader["SBUName"] != DBNull.Value)
                        oItem.SBUName = (string)reader["SBUName"];
                    else oItem.SBUName = "";
                    if (reader["ChannelID"] != DBNull.Value)
                        oItem.ChannelId = (int)reader["ChannelID"];
                    else oItem.ChannelId = -1;
                    if (reader["ChannelCode"] != DBNull.Value)
                        oItem.ChannelCode = (string)reader["ChannelCode"];
                    else oItem.ChannelCode = "";
                    if (reader["ChannelName"] != DBNull.Value)
                        oItem.ChannelName = (string)reader["ChannelName"];
                    else oItem.ChannelName = "";

                    oItem.CustomerTypeId = -1;
                    oItem.CustomerTypeCode = "";
                    oItem.CustomerTypeName = "";

                    if (reader["AreaId"] != DBNull.Value)
                        oItem.AreaId = (int)reader["AreaId"];
                    else oItem.AreaId = -1;
                    if (reader["AreaCode"] != DBNull.Value)
                        oItem.AreaCode = (string)reader["AreaCode"];
                    else oItem.AreaCode = "";
                    if (reader["AreaName"] != DBNull.Value)
                        oItem.AreaName = (string)reader["AreaName"];
                    else oItem.AreaName = "";


                    oItem.TerritoryId = -1;
                    oItem.TerritoryCode = "";
                    oItem.TerritoryName = "";

                    oItem.CustomerId = -1;
                    oItem.CustomerCode = "";
                    oItem.CustomerName = "";

                    if (reader["DailySales"] != DBNull.Value)
                        oItem.DailySales = (double)reader["DailySales"];
                    else oItem.DailySales = 0;
                    if (reader["MonthlySales"] != DBNull.Value)
                        oItem.MonthlySales = (double)reader["MonthlySales"];
                    else oItem.MonthlySales = 0;
                    if (reader["YearlySales"] != DBNull.Value)
                        oItem.YearlySales = (double)reader["YearlySales"];
                    else oItem.YearlySales = 0;
                    if (reader["MonthlyTarget"] != DBNull.Value)
                        oItem.MonthlyTarget = (double)reader["MonthlyTarget"];
                    else oItem.MonthlyTarget = 0;
                    if (reader["YearlyTarget"] != DBNull.Value)
                        oItem.YearlyTarget = (double)reader["YearlyTarget"];
                    else oItem.YearlyTarget = 0;



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
        public void FromDataSetForAreaWise(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    DailySalesReport oDailySalesReport = new DailySalesReport();

                    oDailySalesReport.SBUID = Convert.ToInt32(oRow["SBUID"].ToString());
                    oDailySalesReport.SBUCode = (string)oRow["SBUCode"];
                    oDailySalesReport.SBUName = (string)oRow["SBUName"];
                    oDailySalesReport.ChannelId = (int)oRow["ChannelID"];
                    oDailySalesReport.ChannelCode = (string)oRow["ChannelCode"];
                    oDailySalesReport.ChannelName = (string)oRow["ChannelName"];
                    oDailySalesReport.CustomerTypeId = -1;
                    oDailySalesReport.CustomerTypeCode = "";
                    oDailySalesReport.CustomerTypeName = "";
                    oDailySalesReport.AreaId = (int)oRow["AreaId"];
                    oDailySalesReport.AreaCode = (string)oRow["AreaCode"];
                    oDailySalesReport.AreaName = (string)oRow["AreaName"];
                    oDailySalesReport.TerritoryId = -1;
                    oDailySalesReport.TerritoryCode = "";
                    oDailySalesReport.TerritoryName = "";
                    oDailySalesReport.CustomerId = -1;
                    oDailySalesReport.CustomerCode = "";
                    oDailySalesReport.CustomerName = "";

                    oDailySalesReport.DailySales = (double)oRow["DailySales"];
                    oDailySalesReport.MonthlySales = (double)oRow["MonthlySales"];
                    oDailySalesReport.YearlySales = (double)oRow["YearlySales"];
                    oDailySalesReport.MonthlyTarget = (double)oRow["MonthlyTarget"];
                    oDailySalesReport.YearlyTarget = (double)oRow["YearlyTarget"];

                    InnerList.Add(oDailySalesReport);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Channel wise daily slaes report
        /// </summary>
        /// 
        public void DailySalesReportChaneelWise(DateTime dYFromDate, DateTime dYToDate, DateTime dMFromDate, DateTime dMToDate, DateTime dDFromDate, DateTime dDToDate)
        {
            dYToDate = dYToDate.AddDays(1);
            dMToDate = dMToDate.AddDays(1);
            dDToDate = dDToDate.AddDays(1);

            // InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();


            sQueryStringMaster.Append("Select SBUID,SBUCode,SBUName,ChannelID,ChannelCode,Channeldescription AS ChannelName,");

            sQueryStringMaster.Append("isnull(sum(DailySales),0)as DailySales, isnull(sum(MonthlySales),0)as MonthlySales, isnull(sum(YearlySales),0) as YearlySales, ");
            sQueryStringMaster.Append("isnull(sum(MonthlyTarget),0) as MonthlyTarget,isnull(sum(YearlyTarget),0) as YearlyTarget ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("Select isnull(sales.customerid,target.Customerid)as CustomerID, ");
            sQueryStringMaster.Append("isnull(DailySales,0)as DailySales, isnull(MonthlySales,0)as MonthlySales, isnull(YearlySales,0) as YearlySales, ");
            sQueryStringMaster.Append("isnull(YearlyTarget,0) as YearlyTarget,isnull(MonthlyTarget,0) as MonthlyTarget ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("Select p1.Customerid,isnull(DailySales,0)as DailySales, isnull(MonthlySales,0)as MonthlySales, isnull(YearlySales,0) as YearlySales  ");
            sQueryStringMaster.Append("From  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as YearlySales  ");
            sQueryStringMaster.Append("From  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ? and im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append("union all  ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount, sum(invoiceamount)as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ? and im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(")as qq1  ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(")as p1  ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as MonthlySales  ");
            sQueryStringMaster.Append("From  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ? and im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append("union all  ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount, sum(invoiceamount)as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ? and im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(")as qq1  ");
            sQueryStringMaster.Append("Group By Customerid             ");
            sQueryStringMaster.Append(")as p2 on p1.customerid = p2.customerid  ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as DailySales  ");
            sQueryStringMaster.Append("From  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ? and im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append("union all  ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount, sum(invoiceamount)as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where invoicedate between ? and ? and invoicedate< ? and im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(")as qq1  ");
            sQueryStringMaster.Append("Group By Customerid             ");
            sQueryStringMaster.Append(")as p3 on p1.customerid = p3.customerid  ");
            sQueryStringMaster.Append(") as Sales ");
            sQueryStringMaster.Append("Full outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("Select y.CustomerID, isnull(YearlyTarget,0) as YearlyTarget,isnull(MonthlyTarget,0) as MonthlyTarget  ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select MarketGroupID as Customerid, sum (Turnover)as YearlyTarget  ");
            sQueryStringMaster.Append("from t_planbudgettarget  ");
            sQueryStringMaster.Append("where plantype in (?) and productgrouptype in (?) and periodtype in (?) and MarketScopeType in (?)   ");
            sQueryStringMaster.Append("and perioddate between ? and ?  ");
            sQueryStringMaster.Append("group by  MarketGroupID ");
            sQueryStringMaster.Append(")as Y ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select MarketGroupID as Customerid, sum (Turnover)as MonthlyTarget  ");
            sQueryStringMaster.Append("from t_planbudgettarget  ");
            sQueryStringMaster.Append("where plantype in (?) and productgrouptype in (?) and periodtype in (?) and MarketScopeType in (?)   ");
            sQueryStringMaster.Append("and perioddate between ? and ?  ");
            sQueryStringMaster.Append("group by  MarketGroupID ");
            sQueryStringMaster.Append(") as m on y.Customerid = m.Customerid ");
            sQueryStringMaster.Append(") as Target on sales.customerid = target.Customerid ");
            sQueryStringMaster.Append(")as st ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("SELECT * from v_customerdetails  ");
            sQueryStringMaster.Append(")as cd on st.customerid = cd.customerid ");
            sQueryStringMaster.Append("Group by ");
            sQueryStringMaster.Append("SBUID,SBUCode,SBUName,ChannelID,ChannelCode,Channeldescription");




            OleDbCommand oCmd = DBController.Instance.GetCommand();
            //Command time out
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();



            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);


            oCmd.Parameters.AddWithValue("InvoiceDate", dDFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dDFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("PlanType", (short)Dictionary.PlanType.Target);
            oCmd.Parameters.AddWithValue("ProductGroupType", (short)Dictionary.BudgetTargetProductGroupType.Product);
            oCmd.Parameters.AddWithValue("PeriodType", (short)Dictionary.PeriodType.Monthly);
            oCmd.Parameters.AddWithValue("MarketScopeType", (short)Dictionary.MarketScopeType.Customer);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);

            oCmd.Parameters.AddWithValue("PlanType", (short)Dictionary.PlanType.Target);
            oCmd.Parameters.AddWithValue("ProductGroupType", (short)Dictionary.BudgetTargetProductGroupType.Product);
            oCmd.Parameters.AddWithValue("PeriodType", (short)Dictionary.PeriodType.Monthly);
            oCmd.Parameters.AddWithValue("MarketScopeType", (short)Dictionary.MarketScopeType.Customer);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);

            
            


            GetDataChannelWise(oCmd);

        }

        /// <summary>
        /// Channel wise daily Net sales report
        /// </summary>
        /// 
        public void DailyNetSalesReportChaneelWise(DateTime dYFromDate, DateTime dYToDate, DateTime dMFromDate, DateTime dMToDate, DateTime dDFromDate, DateTime dDToDate)
        {
            dYToDate = dYToDate.AddDays(1);
            dMToDate = dMToDate.AddDays(1);
            dDToDate = dDToDate.AddDays(1);

            // InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();




            //***Modified by Kanij Dated on 29-APR-2015***

            sQueryStringMaster.Append("Select SBUID,SBUCode,SBUName,ChannelID,ChannelCode,Channeldescription AS ChannelName, ");

            sQueryStringMaster.Append("isnull(sum(DailySales),0)as DailySales, isnull(sum(MonthlySales),0)as MonthlySales, isnull(sum(YearlySales),0) as YearlySales, ");
            sQueryStringMaster.Append("isnull(sum(MonthlyTarget),0) as MonthlyTarget,isnull(sum(YearlyTarget),0) as YearlyTarget  ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("Select isnull(sales.customerid,target.Customerid)as CustomerID,  ");
            sQueryStringMaster.Append("isnull(DailySales,0)as DailySales, isnull(MonthlySales,0)as MonthlySales, isnull(YearlySales,0) as YearlySales, ");
            sQueryStringMaster.Append("isnull(YearlyTarget,0) as YearlyTarget,isnull(MonthlyTarget,0) as MonthlyTarget ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("Select p1.Customerid,isnull(DailySales,0)as DailySales, isnull(MonthlySales,0)as MonthlySales, isnull(YearlySales,0) as YearlySales  ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrNetSalesAmount)- abs(sum(DrNetSaleAmount)),0) as YearlySales  ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select a.Customerid,(CrSalesAmount-isnull(vat,0))as  CrNetSalesAmount,DrSalesAmount as DrNetSaleAmount  ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ?  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(") as a  ");
            sQueryStringMaster.Append("inner join  ");
            sQueryStringMaster.Append("(select CustomerID,sum(Quantity*Tradeprice*vatamount)as VAT  ");
            sQueryStringMaster.Append("from t_salesinvoice sa , t_salesinvoicedetail sd  ");
            sQueryStringMaster.Append("where sa.invoiceid = sd.invoiceid and invoicedate between ? and ? and invoicedate < ?  ");
            sQueryStringMaster.Append("and invoicetypeid in (?,?,?,?)and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group by customerid  ");
            sQueryStringMaster.Append(")as b on a.customerid=b.customerid  ");
            sQueryStringMaster.Append("union all  ");
            sQueryStringMaster.Append("select a.Customerid,CrSalesAmount as CrNetSaleAmount,(DrSalesAmount-isnull(vat,0))as  DrNetSalesAmount ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as DrSalesAmount, 0 as CrSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ?  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(") as a  ");
            sQueryStringMaster.Append("inner join  ");
            sQueryStringMaster.Append("(select CustomerID,sum(Quantity*Tradeprice*vatamount)as VAT ");
            sQueryStringMaster.Append("from t_salesinvoice sa , t_salesinvoicedetail sd  ");
            sQueryStringMaster.Append("where sa.invoiceid = sd.invoiceid and invoicedate between ? and ? and invoicedate < ?  ");
            sQueryStringMaster.Append("and invoicetypeid in (?,?,?,?,?)and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("Group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as b on a.customerid=b.customerid  ");
            sQueryStringMaster.Append(")as qq1  ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(")as p1  ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");

            sQueryStringMaster.Append("select Customerid, isnull(sum(CrNetSalesAmount)- abs(sum(DrNetSaleAmount)),0) as MonthlySales  ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select a.Customerid,(CrSalesAmount-isnull(vat,0))as  CrNetSalesAmount,DrSalesAmount as DrNetSaleAmount ");
            sQueryStringMaster.Append("From  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount ");
            sQueryStringMaster.Append("from t_SalesInvoice im  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ?  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(") as a  ");
            sQueryStringMaster.Append("inner join  ");
            sQueryStringMaster.Append("(select CustomerID,sum(Quantity*Tradeprice*vatamount)as VAT  ");
            sQueryStringMaster.Append("from t_salesinvoice sa , t_salesinvoicedetail sd  ");
            sQueryStringMaster.Append("where sa.invoiceid = sd.invoiceid and invoicedate between ? and ? and invoicedate < ?  ");
            sQueryStringMaster.Append("and invoicetypeid in (?,?,?,?)and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group by customerid  ");
            sQueryStringMaster.Append(")as b on a.customerid=b.customerid ");
            sQueryStringMaster.Append("union all  ");
            sQueryStringMaster.Append("select a.Customerid,CrSalesAmount as CrNetSaleAmount,(DrSalesAmount-isnull(vat,0))as  DrNetSalesAmount ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as DrSalesAmount, 0 as CrSalesAmount ");
            sQueryStringMaster.Append("from t_SalesInvoice im  ");
            sQueryStringMaster.Append("where invoicedate between ? and ? and invoicedate< ? ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(") as a ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("(select CustomerID,sum(Quantity*Tradeprice*vatamount)as VAT ");
            sQueryStringMaster.Append("from t_salesinvoice sa , t_salesinvoicedetail sd ");
            sQueryStringMaster.Append("where sa.invoiceid = sd.invoiceid and invoicedate between ? and ? and invoicedate < ? ");
            sQueryStringMaster.Append("and invoicetypeid in (?,?,?,?,?)and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group by customerid  ");
            sQueryStringMaster.Append(")as b on a.customerid=b.customerid  ");
            sQueryStringMaster.Append(")as qq1  ");
            sQueryStringMaster.Append("Group By Customerid             ");
            sQueryStringMaster.Append(")as p2 on p1.customerid = p2.customerid  ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");

            sQueryStringMaster.Append("select Customerid, isnull(sum(CrNetSalesAmount)- abs(sum(DrNetSaleAmount)),0) as DailySales ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select a.Customerid,(CrSalesAmount-isnull(vat,0))as  CrNetSalesAmount,DrSalesAmount as DrNetSaleAmount ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount ");
            sQueryStringMaster.Append("from t_SalesInvoice im  ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ?  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(") as a  ");
            sQueryStringMaster.Append("inner join  ");
            sQueryStringMaster.Append("(select CustomerID,sum(Quantity*Tradeprice*vatamount)as VAT ");
            sQueryStringMaster.Append("from t_salesinvoice sa , t_salesinvoicedetail sd  ");
            sQueryStringMaster.Append("where sa.invoiceid = sd.invoiceid and invoicedate between ? and ? and invoicedate < ?  ");
            sQueryStringMaster.Append("and invoicetypeid in (?,?,?,?)and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group by customerid  ");
            sQueryStringMaster.Append(")as b on a.customerid=b.customerid  ");
            sQueryStringMaster.Append("union all ");
            sQueryStringMaster.Append("select a.Customerid,CrSalesAmount as CrNetSaleAmount,(DrSalesAmount-isnull(vat,0))as  DrNetSalesAmount ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as DrSalesAmount, 0 as CrSalesAmount ");
            sQueryStringMaster.Append("from t_SalesInvoice im ");
            sQueryStringMaster.Append("where invoicedate between ? and ?  and invoicedate< ? ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(") as a ");
            sQueryStringMaster.Append("inner join  ");
            sQueryStringMaster.Append("(select CustomerID,sum(Quantity*Tradeprice*vatamount)as VAT ");
            sQueryStringMaster.Append("from t_salesinvoice sa , t_salesinvoicedetail sd ");
            sQueryStringMaster.Append("where sa.invoiceid = sd.invoiceid and invoicedate between ? and ? and invoicedate < ?  ");
            sQueryStringMaster.Append("and invoicetypeid in (?,?,?,?,?)and invoicestatus not in (?) ");
            sQueryStringMaster.Append("Group by customerid  ");
            sQueryStringMaster.Append(")as b on a.customerid=b.customerid ");
            sQueryStringMaster.Append(")as qq1 ");
            sQueryStringMaster.Append("Group By Customerid             ");
            sQueryStringMaster.Append(")as p3 on p1.customerid = p3.customerid  ");
            sQueryStringMaster.Append(") as Sales  ");
            sQueryStringMaster.Append("Full outer join ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("Select y.CustomerID, isnull(YearlyTarget,0) as YearlyTarget,isnull(MonthlyTarget,0) as MonthlyTarget ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select MarketGroupID as Customerid, sum (Turnover)as YearlyTarget ");
            sQueryStringMaster.Append("from t_planbudgettarget ");
            sQueryStringMaster.Append("where plantype in (?) and productgrouptype in (?) and periodtype in (?) and MarketScopeType in (?) ");
            sQueryStringMaster.Append("and perioddate between ? and ? ");
            sQueryStringMaster.Append("group by  MarketGroupID ");
            sQueryStringMaster.Append(")as Y  ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select MarketGroupID as Customerid, sum (Turnover)as MonthlyTarget  ");
            sQueryStringMaster.Append("from t_planbudgettarget ");
            sQueryStringMaster.Append("where plantype in (?) and productgrouptype in (?) and periodtype in (?) and MarketScopeType in (?)  ");
            sQueryStringMaster.Append("and perioddate between ? and ?  ");
            sQueryStringMaster.Append("group by  MarketGroupID  ");
            sQueryStringMaster.Append(") as m on y.Customerid = m.Customerid  ");
            sQueryStringMaster.Append(") as Target on sales.customerid = target.Customerid  ");
            sQueryStringMaster.Append(")as st  ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("SELECT * from v_customerdetails ");
            sQueryStringMaster.Append(")as cd on st.customerid = cd.customerid  ");
            sQueryStringMaster.Append("Group by  ");
            sQueryStringMaster.Append("SBUID,SBUCode,SBUName,ChannelID,ChannelCode,Channeldescription");




            OleDbCommand oCmd = DBController.Instance.GetCommand();
            //Command time out
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();



            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);


            oCmd.Parameters.AddWithValue("InvoiceDate", dDFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dDFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dDFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dDFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dDToDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("PlanType", (short)Dictionary.PlanType.Target);
            oCmd.Parameters.AddWithValue("ProductGroupType", (short)Dictionary.BudgetTargetProductGroupType.Product);
            oCmd.Parameters.AddWithValue("PeriodType", (short)Dictionary.PeriodType.Monthly);
            oCmd.Parameters.AddWithValue("MarketScopeType", (short)Dictionary.MarketScopeType.Customer);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate);

            oCmd.Parameters.AddWithValue("PlanType", (short)Dictionary.PlanType.Target);
            oCmd.Parameters.AddWithValue("ProductGroupType", (short)Dictionary.BudgetTargetProductGroupType.Product);
            oCmd.Parameters.AddWithValue("PeriodType", (short)Dictionary.PeriodType.Monthly);
            oCmd.Parameters.AddWithValue("MarketScopeType", (short)Dictionary.MarketScopeType.Customer);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dMToDate);





            GetDataChannelWise(oCmd);

        }

        private void GetDataChannelWise(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DailySalesReport oItem = new DailySalesReport();

                    if (reader["SBUID"] != DBNull.Value)
                        oItem.SBUID = Convert.ToInt32(reader["SBUID"]);
                    else oItem.SBUID = -1;
                    if (reader["SBUCode"] != DBNull.Value)
                        oItem.SBUCode = (string)reader["SBUCode"];
                    else oItem.SBUCode = "";
                    if (reader["SBUName"] != DBNull.Value)
                        oItem.SBUName = (string)reader["SBUName"];
                    else oItem.SBUName = "";
                    if (reader["ChannelID"] != DBNull.Value)
                        oItem.ChannelId = (int)reader["ChannelID"];
                    else oItem.ChannelId = -1;
                    if (reader["ChannelCode"] != DBNull.Value)
                        oItem.ChannelCode = (string)reader["ChannelCode"];
                    else oItem.ChannelCode = "";
                    if (reader["ChannelName"] != DBNull.Value)
                        oItem.ChannelName = (string)reader["ChannelName"];
                    else oItem.ChannelName = "";

                    oItem.CustomerTypeId = -1;
                    oItem.CustomerTypeCode = "";
                    oItem.CustomerTypeName = "";

                    oItem.AreaId = -1;
                    oItem.AreaCode = "";
                    oItem.AreaName = "";

                    oItem.TerritoryId = -1;
                    oItem.TerritoryCode = "";
                    oItem.TerritoryName = "";

                    oItem.CustomerId = -1;
                    oItem.CustomerCode = "";
                    oItem.CustomerName = "";

                    if (reader["DailySales"] != DBNull.Value)
                        oItem.DailySales = (double)reader["DailySales"];
                    else oItem.DailySales = 0;
                    if (reader["MonthlySales"] != DBNull.Value)
                        oItem.MonthlySales = (double)reader["MonthlySales"];
                    else oItem.MonthlySales = 0;
                    if (reader["YearlySales"] != DBNull.Value)
                        oItem.YearlySales = (double)reader["YearlySales"];
                    else oItem.YearlySales = 0;
                    if (reader["MonthlyTarget"] != DBNull.Value)
                        oItem.MonthlyTarget = (double)reader["MonthlyTarget"];
                    else oItem.MonthlyTarget = 0;
                    if (reader["YearlyTarget"] != DBNull.Value)
                        oItem.YearlyTarget = (double)reader["YearlyTarget"];
                    else oItem.YearlyTarget = 0;


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
        public void FromDataSetForChannelWise(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    DailySalesReport oDailySalesReport = new DailySalesReport();

                    oDailySalesReport.SBUID = Convert.ToInt32(oRow["SBUID"].ToString());
                    oDailySalesReport.SBUCode = (string)oRow["SBUCode"];
                    oDailySalesReport.SBUName = (string)oRow["SBUName"];
                    oDailySalesReport.ChannelId = (int)oRow["ChannelID"];
                    oDailySalesReport.ChannelCode = (string)oRow["ChannelCode"];
                    oDailySalesReport.ChannelName = (string)oRow["ChannelName"];
                    oDailySalesReport.CustomerTypeId = -1;
                    oDailySalesReport.CustomerTypeCode = "";
                    oDailySalesReport.CustomerTypeName = "";
                    oDailySalesReport.AreaId = -1;
                    oDailySalesReport.AreaCode = "";
                    oDailySalesReport.AreaName = "";
                    oDailySalesReport.TerritoryId = -1;
                    oDailySalesReport.TerritoryCode = "";
                    oDailySalesReport.TerritoryName = "";
                    oDailySalesReport.CustomerId = -1;
                    oDailySalesReport.CustomerCode = "";
                    oDailySalesReport.CustomerName = "";

                    oDailySalesReport.DailySales = (double)oRow["DailySales"];
                    oDailySalesReport.MonthlySales = (double)oRow["MonthlySales"];
                    oDailySalesReport.YearlySales = (double)oRow["YearlySales"];
                    oDailySalesReport.MonthlyTarget = (double)oRow["MonthlyTarget"];
                    oDailySalesReport.YearlyTarget = (double)oRow["YearlyTarget"];

                    InnerList.Add(oDailySalesReport);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshPOSSalesStatement(DateTime dFromDate, DateTime dToDate)//Hakim
        {
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select PaymentModeName, CrRtlAmt, CrB2CAmt, CrB2BAmt, CrHPAAmt, CrDealerAmt,CrETDAmt,  " +
                          " DrRtlAmt, DrB2CAmt, DrB2BAmt, DrHPAAmt, DrDealerAmt,DrETDAmt,   " +
                          " ((CrRtlAmt+ CrB2CAmt+ CrB2BAmt+ CrHPAAmt+ CrDealerAmt+CrETDAmt)-   " +
                          " (DrRtlAmt+ DrB2CAmt+ DrB2BAmt+ DrHPAAmt+ DrDealerAmt+DrETDAmt))as NetAmt from   " +
                          " ( " +
                          "  Select PaymentModeName, " +
                          "  SUM(CASE When SalesType=1 then CRAmt else 0 end) as CrRtlAmt, " +
                          "  SUM(CASE When SalesType=2 then CRAmt else 0 end) as CrB2CAmt, " +
                          "  SUM(CASE When SalesType=3 then CRAmt else 0 end) as CrB2BAmt, " +
                          "  SUM(CASE When SalesType=4 then CRAmt else 0 end) as CrHPAAmt, " +
                          "  SUM(CASE When SalesType=5 then CRAmt else 0 end) as CrDealerAmt, " +
                          "  SUM(CASE When SalesType=6 then CRAmt else 0 end) as CrETDAmt,  " +
                          "  SUM(CASE When SalesType=1 then DRAmt else 0 end) as DrRtlAmt, " +
                          "  SUM(CASE When SalesType=2 then DRAmt else 0 end) as DrB2CAmt, " +
                          "  SUM(CASE When SalesType=3 then DRAmt else 0 end) as DrB2BAmt, " +
                          "  SUM(CASE When SalesType=4 then DRAmt else 0 end) as DrHPAAmt, " +
                          "  SUM(CASE When SalesType=5 then DRAmt else 0 end) as DrDealerAmt, " +
                          "  SUM(CASE When SalesType=6 then DRAmt else 0 end) as DrETDAmt  " +
                          "  from " +
                          "  ( " +
                          "  Select PaymentModeName, SalesType, Sum(CRAmt) as CRAmt, Sum(DRAmt) as DRAmt  " +
                          "  From   " +
                          "  (  " +
                          "  select PaymentModeName, d.SalesType, Sum(Amount) as CRAmt, 0 as DRAmt   " +
                          "  from dbo.t_SalesInvoicePaymentMode a, t_salesInvoice b, t_PaymentMode c, t_RetailConsumer d  " +
                          "  Where a.InvoiceID=b.InvoiceID and a.PaymentModeID=c.PaymentModeID and  b.SundryCustomerID=d.ConsumerID and " +
                          "  InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                          "  and InvoiceTypeID in (1,2,4,5) and InvoiceStatus not in (3) Group by PaymentModeName, d.SalesType " +

                          "  UNION ALL  " +

                          "  select PaymentModeName, d.SalesType, 0 as CRAmt, Sum(Amount) as DRAmt  " +
                          "  from dbo.t_SalesInvoicePaymentMode a, t_salesInvoice b, t_PaymentMode c, t_RetailConsumer d  " +
                          "  Where a.InvoiceID=b.InvoiceID and a.PaymentModeID=c.PaymentModeID and  b.SundryCustomerID=d.ConsumerID and " +
                         "  InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                          "  and InvoiceTypeID in (6,7,9,10,12) and InvoiceStatus not in (3) Group by PaymentModeName, d.SalesType  " +
                          "  )f group by PaymentModeName, SalesType  " +
                          "  )a group by PaymentModeName ) z";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DailySalesReport _oDailySalesReport = new DailySalesReport();

                    _oDailySalesReport.PaymentModeName = reader["PaymentModeName"].ToString();

                    _oDailySalesReport.CrRtlAmt = Convert.ToDouble(reader["CrRtlAmt"].ToString());
                    _oDailySalesReport.CrB2BAmt = Convert.ToDouble(reader["CrB2BAmt"].ToString());
                    _oDailySalesReport.CrB2CAmt = Convert.ToDouble(reader["CrB2CAmt"].ToString());
                    _oDailySalesReport.CrHPAAmt = Convert.ToDouble(reader["CrHPAAmt"].ToString());
                    _oDailySalesReport.CrDealerAmt = Convert.ToDouble(reader["CrDealerAmt"].ToString());
                    _oDailySalesReport.CrETDAmt = Convert.ToDouble(reader["CrETDAmt"].ToString());
                    _oDailySalesReport.DrRtlAmt = Convert.ToDouble(reader["DrRtlAmt"].ToString());
                    _oDailySalesReport.DrB2BAmt = Convert.ToDouble(reader["DrB2BAmt"].ToString());
                    _oDailySalesReport.DrB2CAmt = Convert.ToDouble(reader["DrB2CAmt"].ToString());
                    _oDailySalesReport.DrHPAAmt = Convert.ToDouble(reader["DrHPAAmt"].ToString());
                    _oDailySalesReport.DrDealerAmt = Convert.ToDouble(reader["DrDealerAmt"].ToString());
                    _oDailySalesReport.DrETDAmt = Convert.ToDouble(reader["DrETDAmt"].ToString());
                    _oDailySalesReport.NetAmount = Convert.ToDouble(reader["NetAmt"].ToString());

                    InnerList.Add(_oDailySalesReport);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshPOSSalesStatementRT(DateTime dFromDate, DateTime dToDate, int nWarehouseID)//Hakim
        {
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = @"  Select PaymentModeName, CrRtlAmt, CrB2CAmt, CrB2BAmt, CrHPAAmt, CrDealerAmt,CrETDAmt,  
                    DrRtlAmt, DrB2CAmt, DrB2BAmt, DrHPAAmt, DrDealerAmt,DrETDAmt,    ((CrRtlAmt+ CrB2CAmt+ CrB2BAmt+ CrHPAAmt+ 
                    CrDealerAmt+CrETDAmt)-    (DrRtlAmt+ DrB2CAmt+ DrB2BAmt+ DrHPAAmt+ DrDealerAmt+DrETDAmt))as NetAmt from    
                    (   Select PaymentModeName,   SUM(CASE When SalesType=1 then CRAmt else 0 end) as CrRtlAmt,   
                    SUM(CASE When SalesType=2 then CRAmt else 0 end) as CrB2CAmt,   SUM(CASE When SalesType=3 then CRAmt else 0 end) 
                    as CrB2BAmt,   SUM(CASE When SalesType=4 then CRAmt else 0 end) as CrHPAAmt,   SUM(CASE When SalesType=5 
                    then CRAmt else 0 end) as CrDealerAmt,   SUM(CASE When SalesType=6 then CRAmt else 0 end) as CrETDAmt,  
                    SUM(CASE When SalesType=1 then DRAmt else 0 end) as DrRtlAmt,   SUM(CASE When SalesType=2 then DRAmt else 0 end)
                    as DrB2CAmt,   SUM(CASE When SalesType=3 then DRAmt else 0 end) as DrB2BAmt,   SUM(CASE When SalesType=4 then
                    DRAmt else 0 end) as DrHPAAmt,   SUM(CASE When SalesType=5 then DRAmt else 0 end) as DrDealerAmt,   
                    SUM(CASE When SalesType=6 then DRAmt else 0 end) as DrETDAmt    from   (   Select PaymentModeName, 
                    SalesType, Sum(CRAmt) as CRAmt, Sum(DRAmt) as DRAmt    From     (    select PaymentModeName, d.SalesType,
                    Sum(Amount) as CRAmt, 0 as DRAmt     from dbo.t_SalesInvoicePaymentMode a, t_salesInvoice b, t_PaymentMode c,
                    t_RetailConsumer d    Where a.InvoiceID=b.InvoiceID and b.WarehouseID=d.WarehouseID and b.WarehouseID=" + nWarehouseID + @"
                    and a.PaymentModeID=c.PaymentModeID and  b.SundryCustomerID=d.ConsumerID and   InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate +
                    @"'    and InvoiceTypeID in (1,2,4,5) and InvoiceStatus not in (3) Group by PaymentModeName, d.SalesType   UNION ALL    select PaymentModeName, d.SalesType, 0 as CRAmt, Sum(Amount) as DRAmt   
                    from dbo.t_SalesInvoicePaymentMode a, t_salesInvoice b, t_PaymentMode c, t_RetailConsumer d   
                    Where a.InvoiceID=b.InvoiceID and b.WarehouseID=d.WarehouseID and b.WarehouseID=" + nWarehouseID + @" and a.PaymentModeID=c.PaymentModeID and  b.SundryCustomerID=d.ConsumerID and   InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                    @" and InvoiceTypeID in (6,7,9,10,12) and InvoiceStatus not in (3) Group by PaymentModeName, d.SalesType    )f group by PaymentModeName, SalesType    )a group by PaymentModeName ) z";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DailySalesReport _oDailySalesReport = new DailySalesReport();

                    _oDailySalesReport.PaymentModeName = reader["PaymentModeName"].ToString();

                    _oDailySalesReport.CrRtlAmt = Convert.ToDouble(reader["CrRtlAmt"].ToString());
                    _oDailySalesReport.CrB2BAmt = Convert.ToDouble(reader["CrB2BAmt"].ToString());
                    _oDailySalesReport.CrB2CAmt = Convert.ToDouble(reader["CrB2CAmt"].ToString());
                    _oDailySalesReport.CrHPAAmt = Convert.ToDouble(reader["CrHPAAmt"].ToString());
                    _oDailySalesReport.CrDealerAmt = Convert.ToDouble(reader["CrDealerAmt"].ToString());
                    _oDailySalesReport.CrETDAmt = Convert.ToDouble(reader["CrETDAmt"].ToString());
                    _oDailySalesReport.DrRtlAmt = Convert.ToDouble(reader["DrRtlAmt"].ToString());
                    _oDailySalesReport.DrB2BAmt = Convert.ToDouble(reader["DrB2BAmt"].ToString());
                    _oDailySalesReport.DrB2CAmt = Convert.ToDouble(reader["DrB2CAmt"].ToString());
                    _oDailySalesReport.DrHPAAmt = Convert.ToDouble(reader["DrHPAAmt"].ToString());
                    _oDailySalesReport.DrDealerAmt = Convert.ToDouble(reader["DrDealerAmt"].ToString());
                    _oDailySalesReport.DrETDAmt = Convert.ToDouble(reader["DrETDAmt"].ToString());
                    _oDailySalesReport.NetAmount = Convert.ToDouble(reader["NetAmt"].ToString());

                    InnerList.Add(_oDailySalesReport);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshPOSSaleQtyNValue(DateTime dFromDate, DateTime dToDate, string sProductCode, string sProductName)//Hakim
        {
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            //sSql = "Select ProductCode, ProductName, Qty, GrossAmount, Discount, NetSaleAmount " +
            //        "from  " +
            //        "( " +
            //        "Select ProductCode, ProductName,Sum(CRQty-DRQty) as Qty,Sum(CRGrossAmount-DRGrossAmount) as GrossAmount, " +
            //        "Sum(CRDiscount-DRDiscount)as Discount, Sum(CRNetSaleAmount-DRNetSaleAmount) as NetSaleAmount " +
            //        "from  " +
            //        "( " +
            //        "Select ProductCode, ProductName, Sum(Qty) as CRQty, 0 as DRQty, Sum(GrossAmount) as CRGrossAmount, 0 as DRGrossAmount, " +
            //        "Sum(Discount) as CRDiscount, 0 as DRDiscount, Sum(NetSaleAmount) as CRNetSaleAmount, 0 as DRNetSaleAmount " +
            //        "from  " +
            //        "( " +
            //        "Select ProductCode, ProductName, Qty, GrossAmount, Round((PromotionalDiscount+AveDis),0) as Discount,  " +
            //        "Round((GrossAmount-(PromotionalDiscount+AveDis)),0) as NetSaleAmount from  " +
            //        "( " +
            //        "select a.InvoiceID,a.ProductID, ProductCode, ProductName, (Quantity+FreeQty)Qty, (Quantity*UnitPrice) GrossAmount,  " +
            //        "PromotionalDiscount from dbo.t_SalesInvoiceDetail a, t_SalesInvoice b, t_Product c " +
            //        "Where a.ProductID=c.ProductID and a.InvoiceID=b.InvoiceID and  " +
            //        "InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "' " +
            //        "and InvoiceTypeID in (1,2,4,5) and InvoiceStatus not in (3) " +
            //        ")a " +
            //        "INNER JOIN " +
            //        "( " +
            //        "Select a.InvoiceID,ProductID,((DisPer*Discount)/100)AveDis from  " +
            //        "(Select a.InvoiceID,ProductID, ((Amount/InvoGrossAmt)*100)DisPer from  " +
            //        "(Select InvoiceID, ProductID, (Quantity*UnitPrice)Amount from dbo.t_SalesInvoiceDetail )a " +
            //        "INNER JOIN " +
            //        "(Select InvoiceID, SUM(Quantity*UnitPrice)InvoGrossAmt from dbo.t_SalesInvoiceDetail Group by InvoiceID)b " +
            //        "ON a.InvoiceID=b.InvoiceID " +
            //        ")a INNER JOIN t_SalesInvoice b ON a.InvoiceID=b.InvoiceID " +
            //        ")b ON a.InvoiceID=b.InvoiceID and a.ProductID=b.ProductID " +
            //        ") cr group by ProductCode, ProductName " +

            //        "UNION ALL " +

            //        "Select ProductCode, ProductName, 0 as CRQty, Sum(Qty) as DRQty, 0 as CRGrossAmount, Sum(GrossAmount) as DRGrossAmount, " +
            //        "0 as CRDiscount, Sum(Discount) as DRDiscount, 0 as CRNetSaleAmount, Sum(NetSaleAmount) as DRNetSaleAmount " +
            //        "from  " +
            //        "( " +
            //        "Select ProductCode, ProductName, Qty, GrossAmount, Round((PromotionalDiscount+AveDis),0) as Discount,  " +
            //        "Round((GrossAmount-(PromotionalDiscount+AveDis)),0) as NetSaleAmount from  " +
            //        "( " +
            //        "select a.InvoiceID,a.ProductID, ProductCode, ProductName, (Quantity+FreeQty)Qty, (Quantity*UnitPrice) GrossAmount,  " +
            //        "PromotionalDiscount from dbo.t_SalesInvoiceDetail a, t_SalesInvoice b, t_Product c " +
            //        "Where a.ProductID=c.ProductID and a.InvoiceID=b.InvoiceID and  " +
            //        "InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "' " +
            //        "and InvoiceTypeID in (6,7,9,10,12) and InvoiceStatus not in (3) " +
            //        ")a " +
            //        "INNER JOIN " +
            //        "( " +
            //        "Select a.InvoiceID,ProductID,((DisPer*Discount)/100)AveDis from  " +
            //        "(Select a.InvoiceID,ProductID, ((Amount/InvoGrossAmt)*100)DisPer from  " +
            //        "(Select InvoiceID, ProductID, (Quantity*UnitPrice)Amount from dbo.t_SalesInvoiceDetail )a " +
            //        "INNER JOIN " +
            //        "(Select InvoiceID, SUM(Quantity*UnitPrice)InvoGrossAmt from dbo.t_SalesInvoiceDetail Group by InvoiceID)b " +
            //        "ON a.InvoiceID=b.InvoiceID " +
            //        ")a INNER JOIN t_SalesInvoice b ON a.InvoiceID=b.InvoiceID " +
            //        ")b ON a.InvoiceID=b.InvoiceID and a.ProductID=b.ProductID " +
            //        ") dr group by ProductCode, ProductName " +
            //        ") Final Group by ProductCode, ProductName " +
            //        ")x Where 1=1 ";


            sSql = "Select * From  " +
                "(  " +
                "Select ProductID, ProductCode, ProductName, AGID, AGName, ASGID, ASGName, MAGID,  " +
                "MAGName, PGID, PGName, BrandID, BrandDesc,  " +
                "sum(Quantity) Quantity, sum(FreeQty) FreeQty, sum(TotalQty) TotalQty,  " +
                "sum(GrossAmount) GrossAmount, sum(Charges) Charges, sum(Discount) Discount,  " +
                "sum(VAT) VAT, sum(NetSales) NetSales  " +
                "From  " +
                "(  " +
                //-- -OLD Invoice----
                "Select a.ProductID, ProductCode, ProductName, AGID, AGName, ASGID,  " +
                "ASGName, MAGID, MAGName, PGID, PGName, BrandID, BrandDesc,  " +
                "Case when InvoiceTypeID in (6, 7, 8, 9, 10, 11, 12) then  Quantity * -1  " +
                "else Quantity end as Quantity,  " +
                "Case when InvoiceTypeID in (6, 7, 8, 9, 10, 11, 12) then FreeQty*-1  " +
                "else FreeQty end as FreeQty,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then TotalQty*-1  " +
                "else TotalQty end as TotalQty,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then GrossAmount*-1  " +
                "else GrossAmount end as GrossAmount,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then Charge*-1  " +
                "else Charge end as Charges,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then Discount*-1  " +
                "else Discount end as Discount,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then a.VAT * -1  " +
                "else a.VAT end as VAT,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then NetSales*-1  " +
                "else NetSales end as NetSales  " +
                "From  " +
                "(  " +
                //----main----
                "Select a.InvoiceID, ProductID, Quantity, FreeQty, TotalQty, VAT,  " +
                "GrossAmount, InvoiceTypeID, ((DisPer * Discount) / 100) Discount, ((DisPer * Charge) / 100) Charge,  " +
                "(GrossAmount + ((DisPer * Charge) / 100)) - (((DisPer * Discount) / 100) + VAT) as NetSales  " +
                "from  " +
                "(  " +
                "Select a.InvoiceID, ProductID, Quantity, FreeQty, TotalQty, Amount as GrossAmount,  " +
                "VAT, ((Amount / InvoGrossAmt) * 100) DisPer  " +
                "From  " +
                "(  " +
                "Select InvoiceID, ProductID, Quantity, FreeQty, Quantity + FreeQty as TotalQty,  " +
                "(TradePrice * Quantity * VatAmount) as VAT, (Quantity * UnitPrice) Amount from dbo.t_SalesInvoiceDetail  " +
                ") a  " +
                "INNER JOIN  " +
                "(  " +
                "Select InvoiceID, SUM(Quantity * UnitPrice) InvoGrossAmt  " +
                "from dbo.t_SalesInvoiceDetail Group by InvoiceID  " +
                ") b  " +
                "ON a.InvoiceID = b.InvoiceID  " +
                ")a INNER JOIN (  " +
                "Select a.*, isnull(Charge, 0) Charge  " +
                "From  " +
                "(  " +
                "Select * From t_SalesInvoice  " +
                ") a  " +
                "left outer join  " +
                "(  " +
                "select InvoiceID,  " +
                "sum((InstallationCharge + FreightCharge + OtherCharge)) as Charge  " +
                "From t_SalesInvoiceOtherInfo  " +
                "group by InvoiceID having sum((InstallationCharge + FreightCharge + OtherCharge)) <> 0  " +
                ") b on a.InvoiceID = b.InvoiceID  " +
                ") b ON a.InvoiceID = b.InvoiceID  " +
                "where a.InvoiceID not in (Select InvoiceID from t_SalesInvoiceDetailNew)  " +
                "and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                //-- - main----
                ") a,v_ProductDetails b  " +
                "where a.ProductID = b.ProductID  " +
                //----End OLD Invoice-- -
                "Union ALL  " +
                //---- - New Invoice----
                "Select ProductID, ProductCode, ProductName, AGID, AGName, ASGID,  " +
                "ASGName, MAGID, MAGName, PGID, PGName, BrandID, BrandDesc,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then Quantity*-1  " +
                "else Quantity end as Quantity,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then FreeQty*-1  " +
                "else FreeQty end as FreeQty,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then TotalQty*-1  " +
                "else TotalQty end as TotalQty,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then GrossAmount*-1  " +
                "else GrossAmount end as GrossAmount,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then Charges*-1  " +
                "else Charges end as Charges,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then Discounts*-1  " +
                "else Discounts end as Discount,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then VAT*-1  " +
                "else VAT end as VAT,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then NetSales*-1  " +
                "else NetSales end as NetSales  " +
                "From  " +
                "(  " +
                "Select b.ProductID, ProductCode, ProductName,  " +
                "AGID, AGName, ASGID, ASGName, MAGID, MAGName, PGID, PGName, BrandID, BrandDesc,  " +
                "Quantity, FreeQty, InvoiceTypeID, Quantity + FreeQty as TotalQty,  " +
                "UnitPrice * Quantity as GrossAmount, Charges, b.Discounts,  " +
                "b.TradePrice * VATAmount * Quantity As VAT,  " +
                "((UnitPrice * Quantity) + Charges) - (b.Discounts + (b.TradePrice * VATAmount * Quantity)) as NetSales  " +
                "From t_SalesInvoice a, t_SalesInvoiceDetailNew b, v_ProductDetails c  " +
                "where a.InvoiceID = b.InvoiceID and b.ProductID = c.ProductID  " +
                "and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                ") xx  " +
                //---- - End New Invoice------
                ") aaaa group by ProductID, ProductCode, ProductName, AGID, AGName, ASGID, ASGName, MAGID,  " +
                "MAGName, PGID, PGName, BrandID, BrandDesc  " +
                ")  Main where 1=1";

            if (sProductCode != "")
            {
                sSql = sSql + " and ProductCode='" + sProductCode + "' ";
            }
            if (sProductName != "")
            {
                sSql = sSql + " and ProductName like '%" + sProductName + "%' ";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DailySalesReport _oDailySalesReport = new DailySalesReport();
                    _oDailySalesReport.ProductCode = reader["ProductCode"].ToString();
                    _oDailySalesReport.ProductName = reader["ProductName"].ToString();
                    _oDailySalesReport.Qty = Convert.ToInt32(reader["Quantity"].ToString());
                    _oDailySalesReport.FreeQty = Convert.ToInt32(reader["FreeQty"].ToString());
                    _oDailySalesReport.TotalQty = Convert.ToInt32(reader["TotalQty"].ToString());
                    _oDailySalesReport.GrossAmount = Convert.ToDouble(reader["GrossAmount"].ToString());
                    _oDailySalesReport.ChargeAmount = Convert.ToDouble(reader["Charges"].ToString());
                    _oDailySalesReport.DiscountAmount = Convert.ToDouble(reader["Discount"].ToString());
                    _oDailySalesReport.VAT = Convert.ToDouble(reader["VAT"].ToString());
                    _oDailySalesReport.NetAmount = Convert.ToDouble(reader["NetSales"].ToString());

                    InnerList.Add(_oDailySalesReport);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshPOSSaleQtyNValueRT(DateTime dFromDate, DateTime dToDate, string sProductCode, string sProductName)//Hakim
        {
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            
            sSql = String.Format(@"SELECT ProductID, ProductCode, ProductName, AGID, AGName, ASGID, ASGName, MAGID, MAGName, PGID, PGName, BrandID, BrandDesc, Quantity, FreeQty, TotalQty, GrossAmount, Charges, Discount, VAT, NetSales
                FROM (SELECT ProductID, ProductCode, ProductName, AGID, AGName, ASGID, ASGName, MAGID, MAGName, PGID, PGName, BrandID, BrandDesc, SUM(Quantity) AS Quantity, SUM(FreeQty) AS FreeQty, SUM(TotalQty) AS TotalQty, 
                SUM(GrossAmount) AS GrossAmount, SUM(Charges) AS Charges, SUM(Discount) AS Discount, SUM(VAT) AS VAT, SUM(NetSales) AS NetSales
                FROM (SELECT a.ProductID, b.ProductCode, b.ProductName, b.AGID, b.AGName, b.ASGID, b.ASGName, b.MAGID, b.MAGName, b.PGID, b.PGName, b.BrandID, b.BrandDesc, CASE WHEN InvoiceTypeID IN (6, 7, 8, 9, 10, 
                11, 12) THEN Quantity * - 1 ELSE Quantity END AS Quantity, CASE WHEN InvoiceTypeID IN (6, 7, 8, 9, 10, 11, 12) THEN FreeQty * - 1 ELSE FreeQty END AS FreeQty, CASE WHEN InvoiceTypeID IN (6, 7, 8,
                9, 10, 11, 12) THEN TotalQty * - 1 ELSE TotalQty END AS TotalQty, CASE WHEN InvoiceTypeID IN (6, 7, 8, 9, 10, 11, 12) THEN GrossAmount * - 1 ELSE GrossAmount END AS GrossAmount, 
                CASE WHEN InvoiceTypeID IN (6, 7, 8, 9, 10, 11, 12) THEN Charge * - 1 ELSE Charge END AS Charges, CASE WHEN InvoiceTypeID IN (6, 7, 8, 9, 10, 11, 12) 
                THEN Discount * - 1 ELSE Discount END AS Discount, CASE WHEN InvoiceTypeID IN (6, 7, 8, 9, 10, 11, 12) THEN a.VAT * - 1 ELSE a.VAT END AS VAT, CASE WHEN InvoiceTypeID IN (6, 7, 8, 9, 10, 11, 12) 
                THEN NetSales * - 1 ELSE NetSales END AS NetSales
                FROM (SELECT a.InvoiceID, ProductID, Quantity, FreeQty, TotalQty, VAT, GrossAmount, b.InvoiceTypeID, a.DisPer * b.Discount / 100 AS Discount, a.DisPer * b.Charge / 100 AS Charge, 
                (GrossAmount + a.DisPer * b.Charge / 100) - (a.DisPer * b.Discount / 100 + VAT) AS NetSales
                FROM (SELECT a.InvoiceID, a.ProductID, a.Quantity, a.FreeQty, a.TotalQty, a.Amount AS GrossAmount, a.VAT, a.Amount / b.InvoGrossAmt * 100 AS DisPer
                FROM (SELECT InvoiceID, ProductID, Quantity, FreeQty, Quantity + FreeQty AS TotalQty, TradePrice * Quantity * VATAmount AS VAT, Quantity * UnitPrice AS Amount
                FROM t_SalesInvoiceDetail) AS a INNER JOIN
                (SELECT InvoiceID, SUM(Quantity * UnitPrice) AS InvoGrossAmt
                FROM t_SalesInvoiceDetail
                GROUP BY InvoiceID) AS b ON a.InvoiceID = b.InvoiceID) AS a INNER JOIN
                (SELECT a.InvoiceID, a.InvoiceNo, a.InvoiceDate, a.InvoiceStatus, a.CustomerID, a.WarehouseID, a.InvoiceAmount, a.Discount, a.Remarks, a.OrderID, a.SalesPersonID, 
                a.UpdateUserID, a.UpdateDate, a.CreateDate, a.VATChallanNo, a.InvoiceTypeID, a.InvoiceBy, a.DeliveryAddress, a.PriceOptionID, a.DeliveredBy, a.DeliveryDate, 
                a.InvoicePrintCounter, a.RefInvoiceID, a.InvoicePrintByString, a.DueAmount, a.RefDetails, a.OtherCharge, a.UploadStatus, a.UploadDate, a.DownloadDate, a.RowStatus, 
                a.Terminal, a.SundryCustomerID, a.SalesPromotionID, a.DeliveryMode, a.Flag, a.CustThanaID, a.IsOldInvoice, a.IsSentEmil, a.EmailSentDate, a.NoOfLineItem, a.NoOfPromo, 
                a.NoOfPaymentMode, a.NetSales, a.TotalVat, a.InvoiceConsumerID, a.IsRTInvoice, ISNULL(b.Charge, 0) AS Charge
                FROM (SELECT InvoiceID, InvoiceNo, InvoiceDate, InvoiceStatus, CustomerID, WarehouseID, InvoiceAmount, Discount, Remarks, OrderID, SalesPersonID, UpdateUserID, 
                UpdateDate, CreateDate, VATChallanNo, InvoiceTypeID, InvoiceBy, DeliveryAddress, PriceOptionID, DeliveredBy, DeliveryDate, InvoicePrintCounter, RefInvoiceID, 
                InvoicePrintByString, DueAmount, RefDetails, OtherCharge, UploadStatus, UploadDate, DownloadDate, RowStatus, Terminal, SundryCustomerID, 
                SalesPromotionID, DeliveryMode, Flag, CustThanaID, IsOldInvoice, IsSentEmil, EmailSentDate, NoOfLineItem, NoOfPromo, NoOfPaymentMode, NetSales, TotalVat, 
                InvoiceConsumerID, IsRTInvoice
                FROM t_SalesInvoice
                WHERE (WarehouseID = {2})) AS a LEFT OUTER JOIN
                (SELECT InvoiceID, SUM(InstallationCharge + FreightCharge + OtherCharge) AS Charge
                FROM t_SalesInvoiceOtherInfo
                GROUP BY InvoiceID
                HAVING  (SUM(InstallationCharge + FreightCharge + OtherCharge) <> 0)) AS b ON a.InvoiceID = b.InvoiceID) AS b ON a.InvoiceID = b.InvoiceID
                WHERE (a.InvoiceID NOT IN
                (SELECT InvoiceID
                FROM t_SalesInvoiceDetailNew)) AND (b.InvoiceDate BETWEEN '{0}' AND '{1}') AND (b.InvoiceDate < '{1}')) 
                AS a INNER JOIN
                v_ProductDetails AS b ON a.ProductID = b.ProductID
                UNION ALL
                SELECT ProductID, ProductCode, ProductName, AGID, AGName, ASGID, ASGName, MAGID, MAGName, PGID, PGName, BrandID, BrandDesc, CASE WHEN InvoiceTypeID IN (6, 7, 8, 9, 10, 11, 12) 
                THEN Quantity * - 1 ELSE Quantity END AS Quantity, CASE WHEN InvoiceTypeID IN (6, 7, 8, 9, 10, 11, 12) THEN FreeQty * - 1 ELSE FreeQty END AS FreeQty, CASE WHEN InvoiceTypeID IN (6, 7, 8, 9, 10, 
                11, 12) THEN TotalQty * - 1 ELSE TotalQty END AS TotalQty, CASE WHEN InvoiceTypeID IN (6, 7, 8, 9, 10, 11, 12) THEN GrossAmount * - 1 ELSE GrossAmount END AS GrossAmount, 
                CASE WHEN InvoiceTypeID IN (6, 7, 8, 9, 10, 11, 12) THEN Charges * - 1 ELSE Charges END AS Charges, CASE WHEN InvoiceTypeID IN (6, 7, 8, 9, 10, 11, 12) 
                THEN Discounts * - 1 ELSE Discounts END AS Discount, CASE WHEN InvoiceTypeID IN (6, 7, 8, 9, 10, 11, 12) THEN VAT * - 1 ELSE VAT END AS VAT, CASE WHEN InvoiceTypeID IN (6, 7, 8, 9, 10, 11, 12) 
                THEN NetSales * - 1 ELSE NetSales END AS NetSales
                FROM (SELECT b.ProductID, c.ProductCode, c.ProductName, c.AGID, c.AGName, c.ASGID, c.ASGName, c.MAGID, c.MAGName, c.PGID, c.PGName, c.BrandID, c.BrandDesc, b.Quantity, b.FreeQty, 
                a.InvoiceTypeID, b.Quantity + b.FreeQty AS TotalQty, b.UnitPrice * b.Quantity AS GrossAmount, b.Charges, b.Discounts, b.TradePrice * b.VATAmount * b.Quantity AS VAT, 
                (b.UnitPrice * b.Quantity + b.Charges) - (b.Discounts + b.TradePrice * b.VATAmount * b.Quantity) AS NetSales
                FROM t_SalesInvoice AS a INNER JOIN
                t_SalesInvoiceDetailNew AS b ON a.InvoiceID = b.InvoiceID INNER JOIN
                v_ProductDetails AS c ON b.ProductID = c.ProductID
                WHERE (a.WarehouseID = {2}) AND (a.InvoiceDate BETWEEN '{0}' AND '{1}') AND (a.InvoiceDate < '{1}')) AS xx) AS aaaa
                GROUP BY ProductID, ProductCode, ProductName, AGID, AGName, ASGID, ASGName, MAGID, MAGName, PGID, PGName, BrandID, BrandDesc) AS Main
                WHERE (1 = 1)", dFromDate, dToDate,Utility.WarehouseID);

            if (sProductCode != "")
            {
                sSql = sSql + " and ProductCode='" + sProductCode + "' ";
            }
            if (sProductName != "")
            {
                sSql = sSql + " and ProductName like '%" + sProductName + "%' ";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DailySalesReport _oDailySalesReport = new DailySalesReport();
                    _oDailySalesReport.ProductCode = reader["ProductCode"].ToString();
                    _oDailySalesReport.ProductName = reader["ProductName"].ToString();
                    _oDailySalesReport.Qty = Convert.ToInt32(reader["Quantity"].ToString());
                    _oDailySalesReport.FreeQty = Convert.ToInt32(reader["FreeQty"].ToString());
                    _oDailySalesReport.TotalQty = Convert.ToInt32(reader["TotalQty"].ToString());
                    _oDailySalesReport.GrossAmount = Convert.ToDouble(reader["GrossAmount"].ToString());
                    _oDailySalesReport.ChargeAmount = Convert.ToDouble(reader["Charges"].ToString());
                    _oDailySalesReport.DiscountAmount = Convert.ToDouble(reader["Discount"].ToString());
                    _oDailySalesReport.VAT = Convert.ToDouble(reader["VAT"].ToString());
                    _oDailySalesReport.NetAmount = Convert.ToDouble(reader["NetSales"].ToString());

                    InnerList.Add(_oDailySalesReport);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshPOSSaleQtyNValueNew(DateTime dFromDate, DateTime dToDate, string sProductCode, string sProductName,int ReportKey)//Shuvo
        {
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            string sQueryString = "";
            if (ReportKey == (int)Dictionary.ReportKeyfrmSaleQtyNValue.Sale_Qty_and_Value_All)
            {
                sQueryString = "";
            }
            if (ReportKey == (int)Dictionary.ReportKeyfrmSaleQtyNValue.Sale_Qty_and_Value_Dealer)
            {
                sQueryString = " and SalesType=" + (int)Dictionary.SalesType.Dealer + "";
            }
            if (ReportKey == (int)Dictionary.ReportKeyfrmSaleQtyNValue.Sale_Qty_and_Value_Retail_Other)
            {
                sQueryString = " and SalesType<>" + (int)Dictionary.SalesType.Dealer + "";
            }



            sSql = "Select * From  " +
                "(  " +
                "Select ProductID, ProductCode, ProductName, AGID, AGName, ASGID, ASGName, MAGID,  " +
                "MAGName, PGID, PGName, BrandID, BrandDesc,  " +
                "sum(Quantity) Quantity, sum(FreeQty) FreeQty, sum(TotalQty) TotalQty,  " +
                "sum(GrossAmount) GrossAmount, sum(Charges) Charges, sum(Discount) Discount,  " +
                "sum(VAT) VAT, sum(NetSales) NetSales  " +
                "From  " +
                "(  " +
                //---- - New Invoice----
                "Select ProductID, ProductCode, ProductName, AGID, AGName, ASGID,  " +
                "ASGName, MAGID, MAGName, PGID, PGName, BrandID, BrandDesc,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then Quantity*-1  " +
                "else Quantity end as Quantity,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then FreeQty*-1  " +
                "else FreeQty end as FreeQty,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then TotalQty*-1  " +
                "else TotalQty end as TotalQty,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then GrossAmount*-1  " +
                "else GrossAmount end as GrossAmount,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then Charges*-1  " +
                "else Charges end as Charges,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then Discounts*-1  " +
                "else Discounts end as Discount,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then VAT*-1  " +
                "else VAT end as VAT,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then NetSales*-1  " +
                "else NetSales end as NetSales  " +
                "From  " +
                "(  " +
                "Select b.ProductID, ProductCode, ProductName,  " +
                "AGID, AGName, ASGID, ASGName, MAGID, MAGName, PGID, PGName, BrandID, BrandDesc,  " +
                "Quantity, FreeQty, InvoiceTypeID, Quantity + FreeQty as TotalQty,  " +
                "UnitPrice * Quantity as GrossAmount, Charges, b.Discounts,  " +
                "b.TradePrice * VATAmount * Quantity As VAT,  " +
                "((UnitPrice * Quantity) + Charges) - (b.Discounts + (b.TradePrice * VATAmount * Quantity)) as NetSales  " +
                "From t_SalesInvoice a, t_SalesInvoiceDetailNew b, v_ProductDetails c,t_RetailConsumer d    " +
                "where a.InvoiceID = b.InvoiceID and b.ProductID = c.ProductID and a.SundryCustomerID=d.ConsumerID  " +
                "" + sQueryString + "  and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +

                ") xx  " +
                //---- - End New Invoice------
                ") Main group by ProductID, ProductCode, ProductName, AGID, AGName, ASGID, ASGName, MAGID,  " +
                "MAGName, PGID, PGName, BrandID, BrandDesc  " +
                ")  Main where 1=1";

            if (sProductCode != "")
            {
                sSql = sSql + " and ProductCode='" + sProductCode + "' ";
            }
            if (sProductName != "")
            {
                sSql = sSql + " and ProductName like '%" + sProductName + "%' ";
            }
            sSql = sSql + "  Order by ProductCode,MAGName,BrandDesc";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DailySalesReport _oDailySalesReport = new DailySalesReport();
                    _oDailySalesReport.ProductCode = reader["ProductCode"].ToString();
                    _oDailySalesReport.ProductName = reader["ProductName"].ToString();
                    _oDailySalesReport.Qty = Convert.ToInt32(reader["Quantity"].ToString());
                    _oDailySalesReport.FreeQty = Convert.ToInt32(reader["FreeQty"].ToString());
                    _oDailySalesReport.TotalQty = Convert.ToInt32(reader["TotalQty"].ToString());
                    _oDailySalesReport.GrossAmount = Convert.ToDouble(reader["GrossAmount"].ToString());
                    _oDailySalesReport.ChargeAmount = Convert.ToDouble(reader["Charges"].ToString());
                    _oDailySalesReport.DiscountAmount = Convert.ToDouble(reader["Discount"].ToString());
                    _oDailySalesReport.VAT = Convert.ToDouble(reader["VAT"].ToString());
                    _oDailySalesReport.NetAmount = Convert.ToDouble(reader["NetSales"].ToString());

                    InnerList.Add(_oDailySalesReport);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshPOSSaleQtyNValueNewRT(DateTime dFromDate, DateTime dToDate, string sProductCode, string sProductName, int ReportKey)//Shuvo
        {
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            string sQueryString = "";
            if (ReportKey == (int)Dictionary.ReportKeyfrmSaleQtyNValue.Sale_Qty_and_Value_All)
            {
                sQueryString = "";
            }
            if (ReportKey == (int)Dictionary.ReportKeyfrmSaleQtyNValue.Sale_Qty_and_Value_Dealer)
            {
                sQueryString = " and SalesType=" + (int)Dictionary.SalesType.Dealer + "";
            }
            if (ReportKey == (int)Dictionary.ReportKeyfrmSaleQtyNValue.Sale_Qty_and_Value_Retail_Other)
            {
                sQueryString = " and SalesType<>" + (int)Dictionary.SalesType.Dealer + "";
            }



            sSql = "Select * From  " +
                "(  " +
                "Select ProductID, ProductCode, ProductName, AGID, AGName, ASGID, ASGName, MAGID,  " +
                "MAGName, PGID, PGName, BrandID, BrandDesc,  " +
                "sum(Quantity) Quantity, sum(FreeQty) FreeQty, sum(TotalQty) TotalQty,  " +
                "sum(GrossAmount) GrossAmount, sum(Charges) Charges, sum(Discount) Discount,  " +
                "sum(VAT) VAT, sum(NetSales) NetSales  " +
                "From  " +
                "(  " +
                //---- - New Invoice----
                "Select ProductID, ProductCode, ProductName, AGID, AGName, ASGID,  " +
                "ASGName, MAGID, MAGName, PGID, PGName, BrandID, BrandDesc,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then Quantity*-1  " +
                "else Quantity end as Quantity,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then FreeQty*-1  " +
                "else FreeQty end as FreeQty,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then TotalQty*-1  " +
                "else TotalQty end as TotalQty,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then GrossAmount*-1  " +
                "else GrossAmount end as GrossAmount,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then Charges*-1  " +
                "else Charges end as Charges,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then Discounts*-1  " +
                "else Discounts end as Discount,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then VAT*-1  " +
                "else VAT end as VAT,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then NetSales*-1  " +
                "else NetSales end as NetSales  " +
                "From  " +
                "(  " +
                "Select b.ProductID, ProductCode, ProductName,  " +
                "AGID, AGName, ASGID, ASGName, MAGID, MAGName, PGID, PGName, BrandID, BrandDesc,  " +
                "Quantity, FreeQty, InvoiceTypeID, Quantity + FreeQty as TotalQty,  " +
                "UnitPrice * Quantity as GrossAmount, Charges, b.Discounts,  " +
                "b.TradePrice * VATAmount * Quantity As VAT,  " +
                "((UnitPrice * Quantity) + Charges) - (b.Discounts + (b.TradePrice * VATAmount * Quantity)) as NetSales  " +
                "From t_SalesInvoice a, t_SalesInvoiceDetailNew b, v_ProductDetails c,t_RetailConsumer d    " +
                "where a.WarehouseID=d.WarehouseID and a.WarehouseID="+Utility.WarehouseID+" and a.InvoiceID = b.InvoiceID and b.ProductID = c.ProductID and a.SundryCustomerID=d.ConsumerID  " +
                "" + sQueryString + "  and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +

                ") xx  " +
                //---- - End New Invoice------
                ") Main group by ProductID, ProductCode, ProductName, AGID, AGName, ASGID, ASGName, MAGID,  " +
                "MAGName, PGID, PGName, BrandID, BrandDesc  " +
                ")  Main where 1=1";

            if (sProductCode != "")
            {
                sSql = sSql + " and ProductCode='" + sProductCode + "' ";
            }
            if (sProductName != "")
            {
                sSql = sSql + " and ProductName like '%" + sProductName + "%' ";
            }
            sSql = sSql + "  Order by ProductCode,MAGName,BrandDesc";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DailySalesReport _oDailySalesReport = new DailySalesReport();
                    _oDailySalesReport.ProductCode = reader["ProductCode"].ToString();
                    _oDailySalesReport.ProductName = reader["ProductName"].ToString();
                    _oDailySalesReport.Qty = Convert.ToInt32(reader["Quantity"].ToString());
                    _oDailySalesReport.FreeQty = Convert.ToInt32(reader["FreeQty"].ToString());
                    _oDailySalesReport.TotalQty = Convert.ToInt32(reader["TotalQty"].ToString());
                    _oDailySalesReport.GrossAmount = Convert.ToDouble(reader["GrossAmount"].ToString());
                    _oDailySalesReport.ChargeAmount = Convert.ToDouble(reader["Charges"].ToString());
                    _oDailySalesReport.DiscountAmount = Convert.ToDouble(reader["Discount"].ToString());
                    _oDailySalesReport.VAT = Convert.ToDouble(reader["VAT"].ToString());
                    _oDailySalesReport.NetAmount = Convert.ToDouble(reader["NetSales"].ToString());

                    InnerList.Add(_oDailySalesReport);

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
