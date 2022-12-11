// <summary>
// Compamy: Transcom Electronics Limited
// Author: Mithun Sarkar
// Date: Mar 05, 2012
// Time" :  12:45 PM
// Description: Yearly Month Wise SKU Wise National Sales Summary
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
    public class rptYearlySBUSummary
    {
        public int _nSBUID;
        public string _sSBUCode;
        public string _sSBUName;
        public int _nChannelId;
        public string _sChannelCode;
        public string _sChannelName;
        public int _nCustomerId;
        public string _sCustomerCode;
        public string _sCustomerName;
        public int _nParentCustomerID;
        public string _sParentCustomerCode;
        public string _sParentCustomerName;
        public int _nCustomerTypeId;
        public string _sCustomerTypeCode;
        public string _sCustomerTypeName;
        public int _nAreaId;
        public string _sAreaCode;
        public string _sAreaName;
        public int _nTerritoryId;
        public string _sTerritoryCode;
        public string _sTerritoryName;
        public int _nTGID;
        public string _sTGCode;
        public string _sTGName;
        public double _TGPosition;
        public int _nPGID;
        public string _sPGCode;
        public string _sPGName;
        public int _nMAGId;
        public string _sMAGCode;
        public string _sMAGName;
        public int _nASGId;
        public string _sASGCode;
        public string _sASGName;
        public int _nAGID;
        public string _sAGCode;
        public string _sAGName;
        public int _nProductID;
        public string _sProductCode;
        public string _sProductName;
        public int _nBrandID;
        public string _sBrandCode;
        public string _sBrandName;
        public int _nSubBrandID;
        public string _sSubBrandCode;
        public string _sSubBrandName;
        public double _BrandPOS;
        public double _JanSalesCYR;
        public double _FebSalesCYR;
        public double _MarSalesCYR;
        public double _AprSalesCYR;
        public double _MaySalesCYR;
        public double _JunSalesCYR;
        public double _JulSalesCYR;
        public double _AugSalesCYR;
        public double _SepSalesCYR;
        public double _OctSalesCYR;
        public double _NovSalesCYR;
        public double _DecSalesCYR;
        public double _JanSalesLYR;
        public double _FebSalesLYR;
        public double _MarSalesLYR;
        public double _AprSalesLYR;
        public double _MaySalesLYR;
        public double _JunSalesLYR;
        public double _JulSalesLYR;
        public double _AugSalesLYR;
        public double _SepSalesLYR;
        public double _OctSalesLYR;
        public double _NovSalesLYR;
        public double _DecSalesLYR;
        public double _CumSalesCYR;
        public double _TotalSalesLYR;
        public double _CumSalesLYR;
        public long _nProductCodeInNumber;
        public short _ISActive;
        public double _YearlyTargetQty;
        public double _YTDTargetQty;
        public int _nPTGSTID;
        public string _sPTGSTName;
        public double _PTGSTPosition;


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
        public int ChannelId
        {
            get { return _nChannelId; }
            set { _nChannelId = value; }
        }
        public string ChannelCode
        {
            get { return _sChannelCode; }
            set { _sChannelCode = value; }
        }
        public string ChannelName
        {
            get { return _sChannelName; }
            set { _sChannelName = value; }
        }
        public int CustomerId
        {
            get { return _nCustomerId; }
            set { _nCustomerId = value; }
        }
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value; }
        }
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
        public int ParentCustomerID
        {
            get { return _nParentCustomerID; }
            set { _nParentCustomerID = value; }
        }
        public string ParentCustomerCode
        {
            get { return _sParentCustomerCode; }
            set { _sParentCustomerCode = value; }
        }
        public string ParentCustomerName
        {
            get { return _sParentCustomerName; }
            set { _sParentCustomerName = value; }
        }
        public int CustomerTypeId
        {
            get { return _nCustomerTypeId; }
            set { _nCustomerTypeId = value; }
        }
        public string CustomerTypeCode
        {
            get { return _sCustomerTypeCode; }
            set { _sCustomerTypeCode = value; }
        }
        public string CustomerTypeName
        {
            get { return _sCustomerTypeName; }
            set { _sCustomerTypeName = value; }
        }
        public int AreaId
        {
            get { return _nAreaId; }
            set { _nAreaId = value; }
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
        public int TerritoryId
        {
            get { return _nTerritoryId; }
            set { _nTerritoryId = value; }
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
        public int TGID
        {
            get { return _nTGID; }
            set { _nTGID = value; }
        }
        public string TGCode
        {
            get { return _sTGCode; }
            set { _sTGCode = value; }
        }
        public string TGName
        {
            get { return _sTGName; }
            set { _sTGName = value; }
        }
        public double TGPosition
        {
            get { return _TGPosition; }
            set { _TGPosition = value; }
        }
        public int PGID
        {
            get { return _nPGID; }
            set { _nPGID = value; }
        }
        public string PGCode
        {
            get { return _sPGCode; }
            set { _sPGCode = value; }
        }
        public string PGName
        {
            get { return _sPGName; }
            set { _sPGName = value; }
        }
        public int MAGId
        {
            get { return _nMAGId; }
            set { _nMAGId = value; }
        }
        public string MAGCode
        {
            get { return _sMAGCode; }
            set { _sMAGCode = value; }
        }
        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value; }
        }
        public int ASGId
        {
            get { return _nASGId; }
            set { _nASGId = value; }
        }
        public string ASGCode
        {
            get { return _sASGCode; }
            set { _sASGCode = value; }
        }
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }
        public int AGID
        {
            get { return _nAGID; }
            set { _nAGID = value; }
        }
        public string AGCode
        {
            get { return _sAGCode; }
            set { _sAGCode = value; }
        }
        public string AGName
        {
            get { return _sAGName; }
            set { _sAGName = value; }
        }
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
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
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }
        public string BrandCode
        {
            get { return _sBrandCode; }
            set { _sBrandCode = value; }
        }
        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value; }
        }
        public int SubBrandID
        {
            get { return _nSubBrandID; }
            set { _nSubBrandID = value; }
        }
        public string SubBrandCode
        {
            get { return _sSubBrandCode; }
            set { _sSubBrandCode = value; }
        }
        public string SubBrandName
        {
            get { return _sSubBrandName; }
            set { _sSubBrandName = value; }
        }
        public double BrandPOS
        {
            get { return _BrandPOS; }
            set { _BrandPOS = value; }
        }
        public double JanSalesCYR
        {
            get { return _JanSalesCYR; }
            set { _JanSalesCYR = value; }
        }
        public double FebSalesCYR
        {
            get { return _FebSalesCYR; }
            set { _FebSalesCYR = value; }
        }
        public double MarSalesCYR
        {
            get { return _MarSalesCYR; }
            set { _MarSalesCYR = value; }
        }
        public double AprSalesCYR
        {
            get { return _AprSalesCYR; }
            set { _AprSalesCYR = value; }
        }
        public double MaySalesCYR
        {
            get { return _MaySalesCYR; }
            set { _MaySalesCYR = value; }
        }
        public double JunSalesCYR
        {
            get { return _JunSalesCYR; }
            set { _JunSalesCYR = value; }
        }
        public double JulSalesCYR
        {
            get { return _JulSalesCYR; }
            set { _JulSalesCYR = value; }
        }
        public double AugSalesCYR
        {
            get { return _AugSalesCYR; }
            set { _AugSalesCYR = value; }
        }
        public double SepSalesCYR
        {
            get { return _SepSalesCYR; }
            set { _SepSalesCYR = value; }
        }
        public double OctSalesCYR
        {
            get { return _OctSalesCYR; }
            set { _OctSalesCYR = value; }
        }
        public double NovSalesCYR
        {
            get { return _NovSalesCYR; }
            set { _NovSalesCYR = value; }
        }
        public double DecSalesCYR
        {
            get { return _DecSalesCYR; }
            set { _DecSalesCYR = value; }
        }
        public double JanSalesLYR
        {
            get { return _JanSalesLYR; }
            set { _JanSalesLYR = value; }
        }
        public double FebSalesLYR
        {
            get { return _FebSalesLYR; }
            set { _FebSalesLYR = value; }
        }
        public double MarSalesLYR
        {
            get { return _MarSalesLYR; }
            set { _MarSalesLYR = value; }
        }
        public double AprSalesLYR
        {
            get { return _AprSalesLYR; }
            set { _AprSalesLYR = value; }
        }
        public double MaySalesLYR
        {
            get { return _MaySalesLYR; }
            set { _MaySalesLYR = value; }
        }
        public double JunSalesLYR
        {
            get { return _JunSalesLYR; }
            set { _JunSalesLYR = value; }
        }
        public double JulSalesLYR
        {
            get { return _JulSalesLYR; }
            set { _JulSalesLYR = value; }
        }
        public double AugSalesLYR
        {
            get { return _AugSalesLYR; }
            set { _AugSalesLYR = value; }
        }
        public double SepSalesLYR
        {
            get { return _SepSalesLYR; }
            set { _SepSalesLYR = value; }
        }
        public double OctSalesLYR
        {
            get { return _OctSalesLYR; }
            set { _OctSalesLYR = value; }
        }
        public double NovSalesLYR
        {
            get { return _NovSalesLYR; }
            set { _NovSalesLYR = value; }
        }
        public double DecSalesLYR
        {
            get { return _DecSalesLYR; }
            set { _DecSalesLYR = value; }
        }
        public double CumSalesCYR
        {
            get { return _CumSalesCYR; }
            set { _CumSalesCYR = value; }
        }
        public double TotalSalesLYR
        {
            get { return _TotalSalesLYR; }
            set { _TotalSalesLYR = value; }
        }
        public double CumSalesLYR
        {
            get { return _CumSalesLYR; }
            set { _CumSalesLYR = value; }
        }
        public long ProductCodeInNumber
        {
            get { return _nProductCodeInNumber; }
            set { _nProductCodeInNumber = value; }
        }
        public short ISActive
        {
            get { return _ISActive; }
            set { _ISActive = value; }
        }
        public double YearlyTargetQty
        {
            get { return _YearlyTargetQty; }
            set { _YearlyTargetQty = value; }
        }
        public double YTDTargetQty
        {
            get { return _YTDTargetQty; }
            set { _YTDTargetQty = value; }
        }
        public int PTGSTID
        {
            get { return _nPTGSTID; }
            set { _nPTGSTID = value; }
        }
        public string PTGSTName
        {
            get { return _sPTGSTName; }
            set { _sPTGSTName = value; }
        }
        public double PTGSTPosition
        {
            get { return _PTGSTPosition; }
            set { _PTGSTPosition = value; }
        }
    }

    public class rptYearlySBUSummarys : CollectionBaseCustom
    {
        public void Add(rptYearlySBUSummary oYearlySBUSummary)
        {
            this.List.Add(oYearlySBUSummary);
        }
        public rptYearlySBUSummary this[Int32 Index]
        {
            get
            {
                return (rptYearlySBUSummary)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(rptYearlySBUSummary))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }
        public void YearlySBUWiseSummary(DateTime dbFromDate, DateTime dbToDate, DateTime LYFromDate, DateTime LYToDate, DateTime CYToDate, DateTime LYCumToDate)
        {
            dbToDate = dbToDate.AddDays(1);
            LYToDate = LYToDate.AddDays(1);
            LYCumToDate = LYCumToDate.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();

            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();


            sQueryStringMaster.Append("Select   ");
            sQueryStringMaster.Append("p2.SBUID,p2.SBUCode,p2.SBUName  ");
            sQueryStringMaster.Append(",P3.PGid,p3.PGCode, p3.PGName   ");
            sQueryStringMaster.Append(",P3.MAGid,p3.MAGCode, p3.MAGName   ");
            sQueryStringMaster.Append(",P3.ASGid,p3.ASGCode, p3.ASGName   ");
            sQueryStringMaster.Append(",p3.AGID,p3.AGCode, p3.AGName   ");
            sQueryStringMaster.Append(",P3.Brandid,p3.BrandCode, p3.Branddesc as BrandName   ");
            sQueryStringMaster.Append(",P1.Productid,p3.ProductCode, p3.ProductName,p3.IsActive   ");
            sQueryStringMaster.Append(", sum(JanSalesCYR) as JanSalesCYR, sum(FebSalesCYR) as FebSalesCYR, sum(MarSalesCYR) as MarSalesCYR, sum(AprSalesCYR) as AprSalesCYR  ");
            sQueryStringMaster.Append(", sum(MaySalesCYR) as MaySalesCYR, sum(JunSalesCYR) as JunSalesCYR, sum(JulSalesCYR) as JulSalesCYR, sum(AugSalesCYR) as AugSalesCYR  ");
            sQueryStringMaster.Append(", sum(SepSalesCYR) as SepSalesCYR, sum(OctSalesCYR) as OctSalesCYR, sum(NovSalesCYR) as NovSalesCYR, sum(DecSalesCYR) as DecSalesCYR  ");
            sQueryStringMaster.Append(", sum(CumSalesCYR) as  CumSalesCYR, sum(CumSalesLYR) as  CumSalesLYR, sum(TotalSalesLYR) as  TotalSalesLYR  ");
            sQueryStringMaster.Append(", sum(YearlyTarget) as YearlyTargetQty, sum(YTDTarget) as YTDTargetQty ");
            sQueryStringMaster.Append("from    ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("Select  ");
            sQueryStringMaster.Append("isnull(p1.Productid,p2.Productid)as Productid,isnull(p1.CustomerID,p2.CustomerID) as CustomerID,  ");
            sQueryStringMaster.Append("isnull(JanSalesCYR,0) as JanSalesCYR, isnull(FebSalesCYR,0) as FebSalesCYR, isnull(MarSalesCYR,0) as MarSalesCYR, isnull(AprSalesCYR,0) as AprSalesCYR,   ");
            sQueryStringMaster.Append("isnull(MaySalesCYR,0) as MaySalesCYR, isnull(JunSalesCYR,0) as JunSalesCYR, isnull(JulSalesCYR,0) as JulSalesCYR, isnull(AugSalesCYR,0) as AugSalesCYR,   ");
            sQueryStringMaster.Append("isnull(SepSalesCYR,0) as SepSalesCYR, isnull(OctSalesCYR,0) as OctSalesCYR, isnull(NovSalesCYR,0) as NovSalesCYR, isnull(DecSalesCYR,0) as DecSalesCYR,   ");
            sQueryStringMaster.Append("isnull(CumSalesCYR,0) as  CumSalesCYR, isnull(CumSalesLYR,0) as  CumSalesLYR, isnull(TotalSalesLYR,0) as  TotalSalesLYR,   ");
            sQueryStringMaster.Append("isnull(YearlyTarget,0) as YearlyTarget, isnull(YTDTarget,0) as YTDTarget ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("Select   ");
            sQueryStringMaster.Append("isnull(qq1.Productid,qq2.Productid)as Productid,isnull(qq1.CustomerID,qq2.CustomerID) as CustomerID,   ");
            sQueryStringMaster.Append("isnull(qq1.JanSales,0) as JanSalesCYR, isnull(qq1.FebSales,0) as FebSalesCYR, isnull(qq1.MarSales,0) as MarSalesCYR, isnull(qq1.AprSales,0) as AprSalesCYR,   ");
            sQueryStringMaster.Append("isnull(qq1.MaySales,0) as MaySalesCYR, isnull(qq1.JunSales,0) as JunSalesCYR, isnull(qq1.JulSales,0) as JulSalesCYR, isnull(qq1.AugSales,0) as AugSalesCYR,   ");
            sQueryStringMaster.Append("isnull(qq1.SepSales,0) as SepSalesCYR, isnull(qq1.OctSales,0) as OctSalesCYR, isnull(qq1.NovSales,0) as NovSalesCYR, isnull(qq1.DecSales,0) as DecSalesCYR,   ");
            sQueryStringMaster.Append("isnull(qq1.CumSales,0) as  CumSalesCYR, isnull(qq2.CumSalesLYR,0) as  CumSalesLYR, isnull(qq2.TotalSalesLYR,0) as  TotalSalesLYR   ");
            sQueryStringMaster.Append("from    ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("Select p2.*, isnull(p5.CumSalesCYR,0) as CumSales  ");
            sQueryStringMaster.Append("from    ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select p2.CustomerID,p2.ProductID     ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRJanCYR) - abs(sum(p2.DbJanCYR)),0) as JanSales      ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRFebCYR) - abs(sum(p2.DbFebCYR)),0) as FebSales      ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRMarCYR) - abs(sum(p2.DbMarCYR)),0) as MarSales      ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRAprCYR) - abs(sum(p2.DbAprCYR)),0) as AprSales      ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRMayCYR) - abs(sum(p2.DbMayCYR)),0) as MaySales      ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRJunCYR) - abs(sum(p2.DbJunCYR)),0) as JunSales     ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRJulCYR) - abs(sum(p2.DbJulCYR)),0) as JulSales      ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRAugCYR) - abs(sum(p2.DbAugCYR)),0) as AugSales     ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRSepCYR) - abs(sum(p2.DbSepCYR)),0) as SepSales     ");
            sQueryStringMaster.Append(", isnull(sum(p2.CROctCYR) - abs(sum(p2.DbOctCYR)),0) as OctSales      ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRNovCYR) - abs(sum(p2.DbNovCYR)),0) as NovSales     ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRDcmCYR) - abs(sum(p2.DbDcmCYR)),0) as DecSales   ");
            sQueryStringMaster.Append("from      ");
            sQueryStringMaster.Append("(     ");
            sQueryStringMaster.Append("select im.CustomerID, ProductID,    ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 1 then Quantity else 0 end) as CRJanCYR,     ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 2 then Quantity else 0 end) as CRFebCYR,      ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 3 then Quantity else 0 end) as CRMarCYR,     ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 4 then Quantity else 0 end) as CRAprCYR,     ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 5 then Quantity else 0 end) as CRMayCYR,     ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 6 then Quantity else 0 end) as CRJunCYR,     ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 7 then Quantity else 0 end) as CRJulCYR,     ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 8 then Quantity else 0 end) as CRAugCYR,     ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 9 then Quantity else 0 end) as CRSepCYR,     ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 10 then Quantity else 0 end) as CROctCYR,     ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 11 then Quantity else 0 end) as CRNovCYR,     ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 12 then Quantity else 0 end) as CRDcmCYR,     ");
            sQueryStringMaster.Append("0 as DbJanCYR, 0 as DbFebCYR, 0 as DbMarCYR, 0 as DbAprCYR, 0 as DbMayCYR, 0 as DbJunCYR,     ");
            sQueryStringMaster.Append("0 as DbJulCYR, 0 as DbAugCYR, 0 as DbSepCYR, 0 as DbOctCYR, 0 as DbNovCYR, 0 as DbDcmCYR     ");
            sQueryStringMaster.Append("from t_salesInvoice im,  t_salesInvoiceDetail cd     ");
            sQueryStringMaster.Append("where  im.InvoiceID = cd.InvoiceID and    ");
            sQueryStringMaster.Append("invoicedate between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)     ");
            sQueryStringMaster.Append("group by  im.CustomerID,ProductID     ");
            sQueryStringMaster.Append("union all      ");
            sQueryStringMaster.Append("select im.CustomerID,ProductID,     ");
            sQueryStringMaster.Append("0 as CRJanCYR, 0 as CRFebCYR, 0 as CRMarCYR, 0 as CRAprCYR, 0 as CRMayCYR, 0 as CRJunCYR,     ");
            sQueryStringMaster.Append("0 as CRJulCYR, 0 as CRAugCYR, 0 as CRSepCYR, 0 as CROctCYR, 0 as CRNovCYR, 0 as CRDcmCYR,     ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 1 then Quantity else 0 end) as DbJanCYR,     ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 2 then Quantity else 0 end) as DbFebCYR,      ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 3 then Quantity else 0 end) as DbMarCYR,     ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 4 then Quantity else 0 end) as DbAprCYR,     ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 5 then Quantity else 0 end) as DbMayCYR,     ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 6 then Quantity else 0 end) as DbJunCYR,     ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 7 then Quantity else 0 end) as DbJulCYR,     ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 8 then Quantity else 0 end) as DbAugCYR,     ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 9 then Quantity else 0 end) as DbSepCYR,     ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 10 then Quantity else 0 end) as DbOctCYR,     ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 11 then Quantity else 0 end) as DbNovCYR,     ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 12 then Quantity else 0 end) as DbDcmCYR     ");
            sQueryStringMaster.Append("from t_salesInvoice im,  t_salesInvoiceDetail cd     ");
            sQueryStringMaster.Append("where  im.InvoiceID = cd.InvoiceID and    ");
            sQueryStringMaster.Append("invoicedate between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?)     ");
            sQueryStringMaster.Append("group by  im.CustomerID,ProductID     ");
            sQueryStringMaster.Append(")     ");
            sQueryStringMaster.Append("as p2    ");
            sQueryStringMaster.Append("group by p2.customerid,p2.ProductID   ");
            sQueryStringMaster.Append(")as p2   ");
            sQueryStringMaster.Append("Left Outer Join    ");
            sQueryStringMaster.Append("(    ");
            sQueryStringMaster.Append("select Customerid,ProductID, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as CumSalesCYR     ");
            sQueryStringMaster.Append("From    ");
            sQueryStringMaster.Append("(    ");
            sQueryStringMaster.Append("select im.CustomerID,ProductID, sum(Quantity)as CrSalesAmount, 0 as drSalesAmount    ");
            sQueryStringMaster.Append("from t_salesInvoice im,  t_salesInvoiceDetail cd     ");
            sQueryStringMaster.Append("where  im.InvoiceID = cd.InvoiceID     ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)    ");
            sQueryStringMaster.Append("Group By im.Customerid,ProductID    ");
            sQueryStringMaster.Append("union all    ");
            sQueryStringMaster.Append("select im.CustomerID,ProductID, 0 as CrSalesAmount,sum(quantity)as drSalesAmount   ");
            sQueryStringMaster.Append("from t_salesInvoice im,  t_salesInvoiceDetail cd     ");
            sQueryStringMaster.Append("where  im.InvoiceID = cd.InvoiceID     ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?)   ");
            sQueryStringMaster.Append("Group By im.Customerid,ProductID    ");
            sQueryStringMaster.Append(")as qq1    ");
            sQueryStringMaster.Append("Group By Customerid,ProductID    ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as p5 on p2.CustomerID = p5.CustomerID and p2.ProductID = p5.ProductID   ");
            sQueryStringMaster.Append(")as qq1  ");
            sQueryStringMaster.Append("Full Outer Join     ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("Select p6.Customerid,p6.ProductID,p6.TotalSalesLYR,p7.CumSalesLYR from   ");
            sQueryStringMaster.Append("(     ");
            sQueryStringMaster.Append("select Customerid,ProductID, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as TotalSalesLYR      ");
            sQueryStringMaster.Append("From     ");
            sQueryStringMaster.Append("(     ");
            sQueryStringMaster.Append("select im.CustomerID,ProductID, sum(Quantity)as CrSalesAmount, 0 as drSalesAmount     ");
            sQueryStringMaster.Append("from t_salesInvoice im,  t_salesInvoiceDetail cd      ");
            sQueryStringMaster.Append("where  im.InvoiceID = cd.InvoiceID      ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)     ");
            sQueryStringMaster.Append("Group By im.Customerid,ProductID     ");
            sQueryStringMaster.Append("union all     ");
            sQueryStringMaster.Append("select im.CustomerID,ProductID, 0 as CrSalesAmount,sum(quantity)as drSalesAmount    ");
            sQueryStringMaster.Append("from t_salesInvoice im,  t_salesInvoiceDetail cd      ");
            sQueryStringMaster.Append("where  im.InvoiceID = cd.InvoiceID      ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?)    ");
            sQueryStringMaster.Append("Group By im.Customerid,ProductID     ");
            sQueryStringMaster.Append(")as qq1     ");
            sQueryStringMaster.Append("Group By Customerid,ProductID     ");
            sQueryStringMaster.Append(")    ");
            sQueryStringMaster.Append("as p6   ");
            sQueryStringMaster.Append("Left Outer Join     ");
            sQueryStringMaster.Append("(     ");
            sQueryStringMaster.Append("select Customerid,ProductID, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as CumSalesLYR      ");
            sQueryStringMaster.Append("From     ");
            sQueryStringMaster.Append("(     ");
            sQueryStringMaster.Append("select im.CustomerID,ProductID, sum(Quantity)as CrSalesAmount, 0 as drSalesAmount     ");
            sQueryStringMaster.Append("from t_salesInvoice im,  t_salesInvoiceDetail cd      ");
            sQueryStringMaster.Append("where  im.InvoiceID = cd.InvoiceID      ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)     ");
            sQueryStringMaster.Append("Group By im.Customerid,ProductID     ");
            sQueryStringMaster.Append("union all     ");
            sQueryStringMaster.Append("select im.CustomerID,ProductID, 0 as CrSalesAmount,sum(quantity)as drSalesAmount    ");
            sQueryStringMaster.Append("from t_salesInvoice im,  t_salesInvoiceDetail cd      ");
            sQueryStringMaster.Append("where  im.InvoiceID = cd.InvoiceID      ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?,?) and invoicestatus not in (?)    ");
            sQueryStringMaster.Append("Group By im.Customerid,ProductID     ");
            sQueryStringMaster.Append(")as qq1     ");
            sQueryStringMaster.Append("Group By Customerid,ProductID     ");
            sQueryStringMaster.Append(")    ");
            sQueryStringMaster.Append("as p7 on p6.CustomerID = p7.CustomerID and p6.ProductID = p7.ProductID    ");
            sQueryStringMaster.Append(")as qq2 on qq1.customerid = qq2.customerid and qq1.ProductID = qq2.ProductID  ");
            sQueryStringMaster.Append(")as p1  ");
            sQueryStringMaster.Append("Full Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("Select qq2.Customerid,qq2.ProductID,isnull(YearlyTarget,0) as YearlyTarget, isnull(YTDTarget,0) as YTDTarget ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select MarketGroupID as CustomerID, ProductGroupID as ProductID, sum(qty)as YearlyTarget   ");
            sQueryStringMaster.Append("From t_PlanBudgetTarget    ");
            sQueryStringMaster.Append("Where plantype in (?) and productgrouptype in (?) and periodtype in (?) and MarketScopeType in (?)   ");
            sQueryStringMaster.Append("and perioddate between ? and ?  ");
            sQueryStringMaster.Append("Group By MarketGroupID, ProductGroupID   ");
            sQueryStringMaster.Append(")as qq2   ");
            sQueryStringMaster.Append("Left Outer Join   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select MarketGroupID as CustomerID, ProductGroupID as ProductID, sum (qty)as YTDTarget   ");
            sQueryStringMaster.Append("From t_PlanBudgetTarget    ");
            sQueryStringMaster.Append("Where plantype in (?) and productgrouptype in (?) and periodtype in (?) and MarketScopeType in (?)   ");
            sQueryStringMaster.Append("and perioddate between ? and ?   ");
            sQueryStringMaster.Append("Group By MarketGroupID, ProductGroupID   ");
            sQueryStringMaster.Append(")as  qq3 on qq2.CustomerID = qq3.CustomerID and qq2.ProductID = qq3.ProductID   ");
            sQueryStringMaster.Append(") as p2 on p1.CustomerID = p2.CustomerID and p1.ProductID = p2.ProductID ");
            sQueryStringMaster.Append(")as p1 ");
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select * from v_customerDetails   ");
            sQueryStringMaster.Append(") as p2 on p1.CustomerID = p2.Customerid   ");
            sQueryStringMaster.Append("Left Outer Join   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select * from v_productDetails   ");
            sQueryStringMaster.Append(") as p3 on P1.ProductID = P3.ProductID   ");
            sQueryStringMaster.Append("group by   ");
            sQueryStringMaster.Append("p2.SBUID,p2.SBUCode,p2.SBUName  ");
            sQueryStringMaster.Append(",P3.PGid,p3.PGCode, p3.PGName   ");
            sQueryStringMaster.Append(",P3.MAGid,p3.MAGCode, p3.MAGName   ");
            sQueryStringMaster.Append(",P3.ASGid,p3.ASGCode, p3.ASGName   ");
            sQueryStringMaster.Append(",p3.AGID,p3.AGCode, p3.AGName   ");
            sQueryStringMaster.Append(",P3.Brandid,p3.BrandCode, p3.Branddesc    ");
            sQueryStringMaster.Append(",P1.Productid,p3.ProductCode, p3.ProductName,p3.IsActive  ");


            cmd.CommandTimeout = 0;
            cmd.CommandText = sQueryStringMaster.ToString();


            cmd.Parameters.AddWithValue("InvoiceDate", dbFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dbToDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dbToDate);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", dbFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dbToDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dbToDate);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);


            cmd.Parameters.AddWithValue("InvoiceDate", dbFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dbToDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dbToDate);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", dbFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dbToDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dbToDate);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", LYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", LYToDate);
            cmd.Parameters.AddWithValue("InvoiceDate", LYToDate);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", LYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", LYToDate);
            cmd.Parameters.AddWithValue("InvoiceDate", LYToDate);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", LYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", LYCumToDate);
            cmd.Parameters.AddWithValue("InvoiceDate", LYCumToDate);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", LYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", LYCumToDate);
            cmd.Parameters.AddWithValue("InvoiceDate", LYCumToDate);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("PlanType", (short)Dictionary.PlanType.Target);
            cmd.Parameters.AddWithValue("ProductGroupType", (short)Dictionary.BudgetTargetProductGroupType.Product);
            cmd.Parameters.AddWithValue("PeriodType", (short)Dictionary.PeriodType.Monthly);
            cmd.Parameters.AddWithValue("MarketScopeType", (short)Dictionary.MarketScopeType.Customer);
            cmd.Parameters.AddWithValue("InvoiceDate", dbFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", CYToDate);

            cmd.Parameters.AddWithValue("PlanType", (short)Dictionary.PlanType.Target);
            cmd.Parameters.AddWithValue("ProductGroupType", (short)Dictionary.BudgetTargetProductGroupType.Product);
            cmd.Parameters.AddWithValue("PeriodType", (short)Dictionary.PeriodType.Monthly);
            cmd.Parameters.AddWithValue("MarketScopeType", (short)Dictionary.MarketScopeType.Customer);
            cmd.Parameters.AddWithValue("InvoiceDate", dbFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dbToDate);

            GetDataYearlySBUWiseSummary(cmd);

        }

        private void GetDataYearlySBUWiseSummary(OleDbCommand cmd)
        {

            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptYearlySBUSummary oItem = new rptYearlySBUSummary();

                    if (reader["SBUID"] != DBNull.Value)
                        oItem.SBUID = Convert.ToInt32(reader["SBUID"]);
                    else oItem.SBUID = -1;

                    oItem.SBUCode = "";

                    if (reader["SBUName"] != DBNull.Value)
                        oItem.SBUName = (string)reader["SBUName"];
                    else oItem.SBUName = "";

                    oItem.ChannelId = -1;
                    oItem.ChannelCode = "";
                    oItem.ChannelName = "";
                    oItem.CustomerId = -1;
                    oItem.CustomerCode = "";
                    oItem.CustomerName = "";
                    oItem.ParentCustomerID = -1;
                    oItem.ParentCustomerCode = "";
                    oItem.ParentCustomerName = "";
                    oItem.CustomerTypeId = -1;
                    oItem.CustomerTypeCode = "";
                    oItem.CustomerTypeName = "";
                    oItem.AreaId = -1;
                    oItem.AreaCode = "";
                    oItem.AreaName = "";
                    oItem.TerritoryId = -1;
                    oItem.TerritoryCode = "";
                    oItem.TerritoryName = "";
                    oItem.TGID = -1;
                    oItem.TGCode = "";
                    oItem.TGName = "";
                    oItem.TGPosition = 0;

                    if (reader["PGID"] != DBNull.Value)
                        oItem.PGID = Convert.ToInt32(reader["PGID"]);
                    else oItem.PGID = -1;

                    if (reader["PGCode"] != DBNull.Value)
                        oItem.PGCode = (string)reader["PGCode"];
                    else oItem.PGCode = "";

                    if (reader["PGName"] != DBNull.Value)
                        oItem.PGName = (string)reader["PGName"];
                    else oItem.PGName = "";

                    if (reader["MAGid"] != DBNull.Value)
                        oItem.MAGId = Convert.ToInt32(reader["MAGid"]);
                    else oItem.MAGId = -1;

                    oItem.MAGCode = "";

                    if (reader["MAGName"] != DBNull.Value)
                        oItem.MAGName = (string)reader["MAGName"];
                    else oItem.MAGName = "";

                    if (reader["ASGid"] != DBNull.Value)
                        oItem.ASGId = Convert.ToInt32(reader["ASGid"]);
                    else oItem.ASGId = -1;

                    oItem.ASGCode = "";

                    if (reader["ASGName"] != DBNull.Value)
                        oItem.ASGName = (string)reader["ASGName"];
                    else oItem.ASGName = "";

                    if (reader["AGID"] != DBNull.Value)
                        oItem.AGID = Convert.ToInt32(reader["AGID"]);
                    else oItem.AGID = -1;

                    oItem.AGCode = "";

                    if (reader["AGName"] != DBNull.Value)
                        oItem.AGName = (string)reader["AGName"];
                    else oItem.AGName = "";

                    oItem.ProductID = -1;

                    if (reader["ProductCode"] != DBNull.Value)
                        oItem.ProductCode = (string)reader["ProductCode"];
                    else oItem.ProductCode = "";

                    if (reader["ProductName"] != DBNull.Value)
                        oItem.ProductName = (string)reader["ProductName"];
                    else oItem.ProductName = "";

                    if (reader["Brandid"] != DBNull.Value)
                        oItem.BrandID = Convert.ToInt32(reader["Brandid"]);
                    else oItem.BrandID = -1;

                    oItem.BrandCode = "";

                    if (reader["BrandName"] != DBNull.Value)
                        oItem.BrandName = (string)reader["BrandName"];
                    else oItem.BrandName = "";

                    oItem.SubBrandID = -1;
                    oItem.SubBrandCode = "";
                    oItem.SubBrandName = "";
                    oItem.BrandPOS = 0;

                    if (reader["JanSalesCYR"] != DBNull.Value)
                        oItem.JanSalesCYR = Convert.ToDouble(reader["JanSalesCYR"]);
                    else oItem.JanSalesCYR = 0;

                    if (reader["FebSalesCYR"] != DBNull.Value)
                        oItem.FebSalesCYR = Convert.ToDouble(reader["FebSalesCYR"]);
                    else oItem.FebSalesCYR = 0;

                    if (reader["MarSalesCYR"] != DBNull.Value)
                        oItem.MarSalesCYR = Convert.ToDouble(reader["MarSalesCYR"]);
                    else oItem.MarSalesCYR = 0;

                    if (reader["AprSalesCYR"] != DBNull.Value)
                        oItem.AprSalesCYR = Convert.ToDouble(reader["AprSalesCYR"]);
                    else oItem.AprSalesCYR = 0;

                    if (reader["MaySalesCYR"] != DBNull.Value)
                        oItem.MaySalesCYR = Convert.ToDouble(reader["MaySalesCYR"]);
                    else oItem.MaySalesCYR = 0;

                    if (reader["JunSalesCYR"] != DBNull.Value)
                        oItem.JunSalesCYR = Convert.ToDouble(reader["JunSalesCYR"]);
                    else oItem.JunSalesCYR = 0;

                    if (reader["JulSalesCYR"] != DBNull.Value)
                        oItem.JulSalesCYR = Convert.ToDouble(reader["JulSalesCYR"]);
                    else oItem.JulSalesCYR = 0;

                    if (reader["AugSalesCYR"] != DBNull.Value)
                        oItem.AugSalesCYR = Convert.ToDouble(reader["AugSalesCYR"]);
                    else oItem.AugSalesCYR = 0;

                    if (reader["SepSalesCYR"] != DBNull.Value)
                        oItem.SepSalesCYR = Convert.ToDouble(reader["SepSalesCYR"]);
                    else oItem.SepSalesCYR = 0;

                    if (reader["OctSalesCYR"] != DBNull.Value)
                        oItem.OctSalesCYR = Convert.ToDouble(reader["OctSalesCYR"]);
                    else oItem.OctSalesCYR = 0;

                    if (reader["NovSalesCYR"] != DBNull.Value)
                        oItem.NovSalesCYR = Convert.ToDouble(reader["NovSalesCYR"]);
                    else oItem.NovSalesCYR = 0;

                    if (reader["DecSalesCYR"] != DBNull.Value)
                        oItem.DecSalesCYR = Convert.ToDouble(reader["DecSalesCYR"]);
                    else oItem.DecSalesCYR = 0;

                    oItem.JanSalesLYR = 0;
                    oItem.FebSalesLYR = 0;
                    oItem.MarSalesLYR = 0;
                    oItem.AprSalesLYR = 0;
                    oItem.MaySalesLYR = 0;
                    oItem.JunSalesLYR = 0;
                    oItem.JunSalesLYR = 0;
                    oItem.AugSalesLYR = 0;
                    oItem.SepSalesLYR = 0;
                    oItem.OctSalesLYR = 0;
                    oItem.NovSalesLYR = 0;
                    oItem.DecSalesLYR = 0;

                    if (reader["CumSalesCYR"] != DBNull.Value)
                        oItem.CumSalesCYR = Convert.ToDouble(reader["CumSalesCYR"]);
                    else oItem.CumSalesCYR = 0;

                    if (reader["TotalSalesLYR"] != DBNull.Value)
                        oItem.TotalSalesLYR = Convert.ToDouble(reader["TotalSalesLYR"]);
                    else oItem.TotalSalesLYR = 0;

                    if (reader["CumSalesLYR"] != DBNull.Value)
                        oItem.CumSalesLYR = Convert.ToDouble(reader["CumSalesLYR"]);
                    else oItem.CumSalesLYR = 0;

                    try
                    {
                        oItem.ProductCodeInNumber = Convert.ToInt64((string)reader["ProductCode"]);
                    }
                    catch
                    {
                        oItem.ProductCodeInNumber = 1;
                    }

                    if (reader["IsActive"] != DBNull.Value)
                        oItem.ISActive = Convert.ToInt16(reader["IsActive"]);
                    else oItem.ISActive = -1;

                    if (reader["YearlyTargetQty"] != DBNull.Value)
                        oItem.YearlyTargetQty = Convert.ToDouble(reader["YearlyTargetQty"]);
                    else oItem.YearlyTargetQty = 0;

                    if (reader["YTDTargetQty"] != DBNull.Value)
                        oItem.YTDTargetQty = Convert.ToDouble(reader["YTDTargetQty"]);
                    else oItem.YTDTargetQty = 0;

                    oItem.PTGSTID = -1;
                    oItem.PTGSTName = "";
                    oItem.PTGSTPosition = 0;


                    Add(oItem);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void FromDataSetForYearlySBUWise(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    rptYearlySBUSummary oYearlySBUSummary = new rptYearlySBUSummary();

                    oYearlySBUSummary.SBUID = Convert.ToInt32(oRow["SBUID"].ToString());
                    oYearlySBUSummary.SBUCode = "";
                    oYearlySBUSummary.SBUName = (string)oRow["SBUName"];
                    oYearlySBUSummary.ChannelId = -1;
                    oYearlySBUSummary.ChannelCode = "";
                    oYearlySBUSummary.ChannelName = "";
                    oYearlySBUSummary.CustomerId = -1;
                    oYearlySBUSummary.CustomerCode = "";
                    oYearlySBUSummary.CustomerName = "";
                    oYearlySBUSummary.ParentCustomerID = -1;
                    oYearlySBUSummary.ParentCustomerCode = "";
                    oYearlySBUSummary.ParentCustomerName = "";
                    oYearlySBUSummary.CustomerTypeId = -1;
                    oYearlySBUSummary.CustomerTypeCode = "";
                    oYearlySBUSummary.CustomerTypeName = "";
                    oYearlySBUSummary.AreaId = -1;
                    oYearlySBUSummary.AreaCode = "";
                    oYearlySBUSummary.AreaName = "";
                    oYearlySBUSummary.TerritoryId = -1;
                    oYearlySBUSummary.TerritoryCode = "";
                    oYearlySBUSummary.TerritoryName = "";
                    oYearlySBUSummary.TGID = -1;
                    oYearlySBUSummary.TGCode = "";
                    oYearlySBUSummary.TGName = "";
                    oYearlySBUSummary.TGPosition = 0;

                    oYearlySBUSummary.PGID = Convert.ToInt32(oRow["PGID"].ToString());

                    oYearlySBUSummary.PGCode = (string)oRow["PGCode"];
                    oYearlySBUSummary.PGName = (string)oRow["PGName"];

                    oYearlySBUSummary.MAGId = Convert.ToInt32(oRow["MAGId"].ToString());
                    oYearlySBUSummary.MAGCode = "";
                    oYearlySBUSummary.MAGName = (string)oRow["MAGName"];
                    oYearlySBUSummary.ASGId = Convert.ToInt32(oRow["ASGId"].ToString());
                    oYearlySBUSummary.ASGCode = "";

                    oYearlySBUSummary.ASGName = (string)oRow["ASGName"];

                    oYearlySBUSummary.AGID = Convert.ToInt32(oRow["AGID"].ToString());
                    oYearlySBUSummary.AGCode = "";

                    oYearlySBUSummary.AGName = (string)oRow["AGName"];

                    oYearlySBUSummary.ProductID = -1;

                    oYearlySBUSummary.ProductCode = (string)oRow["ProductCode"];
                    oYearlySBUSummary.ProductName = (string)oRow["ProductName"];

                    oYearlySBUSummary.BrandID = Convert.ToInt32(oRow["BrandID"].ToString());
                    oYearlySBUSummary.BrandCode = "";
                    oYearlySBUSummary.BrandName = (string)oRow["BrandName"];
                    oYearlySBUSummary.SubBrandID = -1;
                    oYearlySBUSummary.SubBrandCode = "";
                    oYearlySBUSummary.SubBrandName = "";
                    oYearlySBUSummary.BrandPOS = 0;

                    oYearlySBUSummary.JanSalesCYR = (double)oRow["JanSalesCYR"];
                    oYearlySBUSummary.FebSalesCYR = (double)oRow["FebSalesCYR"];
                    oYearlySBUSummary.MarSalesCYR = (double)oRow["MarSalesCYR"];
                    oYearlySBUSummary.AprSalesCYR = (double)oRow["AprSalesCYR"];
                    oYearlySBUSummary.MaySalesCYR = (double)oRow["MaySalesCYR"];
                    oYearlySBUSummary.JunSalesCYR = (double)oRow["JunSalesCYR"];
                    oYearlySBUSummary.JulSalesCYR = (double)oRow["JulSalesCYR"];
                    oYearlySBUSummary.AugSalesCYR = (double)oRow["AugSalesCYR"];
                    oYearlySBUSummary.SepSalesCYR = (double)oRow["SepSalesCYR"];
                    oYearlySBUSummary.OctSalesCYR = (double)oRow["OctSalesCYR"];
                    oYearlySBUSummary.NovSalesCYR = (double)oRow["NovSalesCYR"];
                    oYearlySBUSummary.DecSalesCYR = (double)oRow["DecSalesCYR"];

                    oYearlySBUSummary.JanSalesLYR = 0;
                    oYearlySBUSummary.FebSalesLYR = 0;
                    oYearlySBUSummary.MarSalesLYR = 0;
                    oYearlySBUSummary.AprSalesLYR = 0;
                    oYearlySBUSummary.MaySalesLYR = 0;
                    oYearlySBUSummary.JunSalesLYR = 0;
                    oYearlySBUSummary.JunSalesLYR = 0;
                    oYearlySBUSummary.AugSalesLYR = 0;
                    oYearlySBUSummary.SepSalesLYR = 0;
                    oYearlySBUSummary.OctSalesLYR = 0;
                    oYearlySBUSummary.NovSalesLYR = 0;
                    oYearlySBUSummary.DecSalesLYR = 0;

                    oYearlySBUSummary.CumSalesCYR = (double)oRow["CumSalesCYR"];
                    oYearlySBUSummary.TotalSalesLYR = (double)oRow["TotalSalesLYR"];
                    oYearlySBUSummary.CumSalesLYR = (double)oRow["CumSalesLYR"];


                    try
                    {
                        oYearlySBUSummary.ProductCodeInNumber = Convert.ToInt64(oRow["ProductCode"].ToString());
                    }
                    catch
                    {
                        oYearlySBUSummary.ProductCodeInNumber = 1;
                    }

                    oYearlySBUSummary.ISActive = Convert.ToInt16(oRow["IsActive"].ToString());

                    oYearlySBUSummary.YearlyTargetQty = (double)oRow["YearlyTargetQty"];
                    oYearlySBUSummary.YTDTargetQty = (double)oRow["YTDTargetQty"];


                    oYearlySBUSummary.PTGSTID = -1;
                    oYearlySBUSummary.PTGSTName = "";
                    oYearlySBUSummary.PTGSTPosition = 0;

                    InnerList.Add(oYearlySBUSummary);
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
