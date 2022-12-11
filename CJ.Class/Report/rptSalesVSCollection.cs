// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sunadr Biswas
// Date: July 3;2011
// Time :  05:00 PM
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
    public class rptSalesVSCollection
    {
        private long _SBUID;
        private string _SBUCode;
        private string _SBUName;
        private long _ChannelId;
        private string _ChannelCode;
        private string _ChannelName;
        private long _CustomerId;
        private string _CustomerName;
        private string _CustomerCode;
        private long _CustomerTypeId;
        private string _CustomerTypeCode;
        private string _CustomerTypeName;
        private long _AreaId;
        private string _AreaCode;
        private string _AreaName;
        private long _TerritoryId;
        private string _TerritoryCode;
        private string _TerritoryName;
        //private long _SalesPersonID;
        //private string _SalesPersonCode;
        //private string _SalesPersonName;
        private double _JanSales;
        private double _FebSales;
        private double _MarSales;
        private double _AprSales;
        private double _MaySales;
        private double _JunSales;
        private double _JulSales;
        private double _AugSales;
        private double _SepSales;
        private double _OctSales;
        private double _NovSales;
        private double _DecSales;
        private double _JanColl;
        private double _FebColl;
        private double _MarColl;
        private double _AprColl;
        private double _MayColl;
        private double _JunColl;
        private double _JulColl;
        private double _AugColl;
        private double _SepColl;
        private double _OctColl;
        private double _NovColl;
        private double _DecColl;
        private double _CurrentOS;
        private long _ParentCustomerID;
        private string _ParentCustomerCode;
        private string _ParentCustomerName;
        private double _CumSalesCYR;
        private double _CumCollCYR;
        private double _CumSalesLYR;
        private double _CumCollLYR;
        private double _TotalSalesLYR;
        private double _TotalCollLYR;
        private double _TargetTO;
        private double _TargetColl;
        private long _CodeInNumber;
        private int _IsActive;
        //private double _JanTarget;
        //private double _FebTarget;
        //private double _MarTarget;
        //private double _AprTarget;
        //private double _MayTarget;
        //private double _JunTarget;
        //private double _JulTarget;
        //private double _AugTarget;
        //private double _SepTarget;
        //private double _OctTarget;
        //private double _NovTarget;
        //private double _DecTarget;
        //private double _CumTerCYR;
        //private double _TotalTerLYR;
        //private double _CumTerLYR;
        //private double _JanSalesLYR;
        //private double _FebSalesLYR;
        //private double _MarSalesLYR;
        //private double _AprSalesLYR;
        //private double _MaySalesLYR;
        //private double _JunSalesLYR;
        //private double _JulSalesLYR;
        //private double _AugSalesLYR;
        //private double _SepSalesLYR;
        //private double _OctSalesLYR;
        //private double _NovSalesLYR;
        //private double _DecSalesLYR;
        //private long _PGID;
        //private string _PGCode;
        //private string _PGName;
        //private long _MAGID;
        //private string _MAGCode;
        //private string _MAGName;
        //private long _ASGID;
        //private string _ASGCode;
        //private string _ASGName;
        //private long _AGID;
        //private string _AGCode;
        //private string _AGName;
        //private long _ProductID;
        //private string _ProductCode;
        //private string _ProductName;
        //private long _BrandID;
        //private string _BrandCode;
        //private string _BrandName;
        //private long _SubBrandID;
        //private string _SubBrandCode;
        //private string _SubBrandName;
        //private double _TotalTerCYR;


        public long SBUID
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
        public long ChannelId
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
        public long CustomerId
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
        public long CustomerTypeId
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
        public long AreaId
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
        public long TerritoryId
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
        //public long SalesPersonID
        //{
        //    get { return _SalesPersonID; }
        //    set { _SalesPersonID = value; }

        //}
        //public string SalesPersonCode
        //{
        //    get { return _SalesPersonCode; }
        //    set { _SalesPersonCode = value; }
        //}
        //public string SalesPersonName
        //{
        //    get { return _SalesPersonName; }
        //    set { _SalesPersonName = value; }
        //}
        public double JanSales
        {
            get { return _JanSales; }
            set { _JanSales = value; }
        }
        public double FebSales
        {
            get { return _FebSales; }
            set { _FebSales = value; }
        }
        public double MarSales
        {
            get { return _MarSales; }
            set { _MarSales = value; }
        }
        public double AprSales
        {
            get { return _AprSales; }
            set { _AprSales = value; }
        }
        public double MaySales
        {
            get { return _MaySales; }
            set { _MaySales = value; }
        }
        public double JunSales
        {
            get { return _JunSales; }
            set { _JunSales = value; }
        }
        public double JulSales
        {
            get { return _JulSales; }
            set { _JulSales = value; }
        }
        public double AugSales
        {
            get { return _AugSales; }
            set { _AugSales = value; }

        }
        public double SepSales
        {
            get { return _SepSales; }
            set { _SepSales = value; }
        }
        public double OctSales
        {
            get { return _OctSales; }
            set { _OctSales = value; }
        }
        public double NovSales
        {
            get { return _NovSales; }
            set { _NovSales = value; }
        }
        public double DecSales
        {
            get { return _DecSales; }
            set { _DecSales = value; }
        }
        public double JanColl
        {
            get { return _JanColl; }
            set { _JanColl = value; }
        }
        public double FebColl
        {
            get { return _FebColl; }
            set { _FebColl = value; }
        }
        public double MarColl
        {
            get { return _MarColl; }
            set { _MarColl = value; }
        }
        public double AprColl
        {
            get { return _AprColl; }
            set { _AprColl = value; }
        }
        public double MayColl
        {
            get { return _MayColl; }
            set { _MayColl = value; }
        }
        public double JunColl
        {
            get { return _JunColl; }
            set { _JunColl = value; }

        }
        public double JulColl
        {
            get { return _JulColl; }
            set { _JulColl = value; }

        }
        public double AugColl
        {
            get { return _AugColl; }
            set { _AugColl = value; }
        }
        public double SepColl
        {
            get { return _SepColl; }
            set { _SepColl = value; }
        }
        public double OctColl
        {
            get { return _OctColl; }
            set { _OctColl = value; }
        }
        public double NovColl
        {
            get { return _NovColl; }
            set { _NovColl = value; }
        }
        public double DecColl
        {
            get { return _DecColl; }
            set { _DecColl = value; }
        }
        public double CurrentOS
        {
            get { return _CurrentOS; }
            set { _CurrentOS = value; }
        }
        public long ParentCustomerID
        {
            get { return _ParentCustomerID; }
            set { _ParentCustomerID = value; }
        }
        public string ParentCustomerCode
        {
            get { return _ParentCustomerCode; }
            set { _ParentCustomerCode = value; }
        }
        public string ParentCustomerName
        {
            get { return _ParentCustomerName; }
            set { _ParentCustomerName = value; }

        }
        public double CumSalesCYR
        {
            get { return _CumSalesCYR; }
            set { _CumSalesCYR = value; }
        }

        public double CumCollCYR
        {
            get { return _CumCollCYR; }
            set { _CumCollCYR = value; }
        }
        public double CumSalesLYR
        {
            get { return _CumSalesLYR; }
            set { _CumSalesLYR = value; }
        }
        public double CumCollLYR
        {
            get { return _CumCollLYR; }
            set { _CumCollLYR = value; }
        }
        public double TotalSalesLYR
        {
            get { return _TotalSalesLYR; }
            set { _TotalSalesLYR = value; }
        }
        public double TotalCollLYR
        {
            get { return _TotalCollLYR; }
            set { _TotalCollLYR = value; }
        }
        public double TargetTO
        {
            get { return _TargetTO; }
            set { _TargetTO = value; }
        }
        public double TargetColl
        {
            get { return _TargetColl; }
            set { _TargetColl = value; }
        }
        public long CodeInNumber
        {
            get { return _CodeInNumber; }
            set { _CodeInNumber = value; }
        }
        public int IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }

        }
        //public double JanTarget
        //{
        //    get { return _JanTarget; }
        //    set { _JanTarget = value; }
        //}
        //public double FebTarget
        //{
        //    get { return _FebTarget; }
        //    set { _FebTarget = value; }
        //}
        //public double MarTarget
        //{
        //    get { return _MarTarget; }
        //    set { _MarTarget = value; }
        //}
        //public double AprTarget
        //{
        //    get { return _AprTarget; }
        //    set { _AprTarget = value; }
        //}
        //public double MayTarget
        //{
        //    get { return _MayTarget; }
        //    set { _MayTarget = value; }
        //}
        //public double JunTarget
        //{
        //    get { return _JunTarget; }
        //    set { _JunTarget = value; }
        //}
        //public double JulTarget
        //{
        //    get { return _JulTarget; }
        //    set { _JulTarget = value; }
        //}
        //public double AugTarget
        //{
        //    get { return _AugTarget; }
        //    set { _AugTarget = value; }
        //}
        //public double SepTarget
        //{
        //    get { return _SepTarget; }
        //    set { _SepTarget = value; }
        //}
        //public double OctTarget
        //{
        //    get { return _OctTarget; }
        //    set { _OctTarget = value; }

        //}
        //public double NovTarget
        //{
        //    get { return _NovTarget; }
        //    set { _NovTarget = value; }
        //}
        //public double DecTarget
        //{
        //    get { return _DecTarget; }
        //    set { _DecTarget = value; }
        //}
        //public double CumTerCYR
        //{
        //    get { return _CumTerCYR; }
        //    set { _CumTerCYR = value; }
        //}    
        //public double TotalTerLYR
        //{
        //    get { return _TotalTerLYR; }
        //    set { _TotalTerLYR = value; }
        //}
        //public double CumTerLYR
        //{
        //    get { return _CumTerLYR; }
        //    set { _CumTerLYR = value; }
        //}
        //public double JanSalesLYR
        //{
        //    get { return _JanSalesLYR; }
        //    set { _JanSalesLYR = value; }
        //}
        //public double FebSalesLYR
        //{
        //    get { return _FebSalesLYR; }
        //    set { _FebSalesLYR = value; }
        //}
        //public double MarSalesLYR
        //{
        //    get { return _MarSalesLYR; }
        //    set { _MarSalesLYR = value; }
        //}
        //public double AprSalesLYR
        //{
        //    get { return _AprSalesLYR; }
        //    set { _AprSalesLYR = value; }
        //}
        //public double MaySalesLYR
        //{
        //    get { return _MaySalesLYR; }
        //    set { _MaySalesLYR = value; }
        //}
        //public double JunSalesLYR
        //{
        //    get { return _JunSalesLYR; }
        //    set { _JunSalesLYR = value; }
        //}
        //public double JulSalesLYR
        //{
        //    get { return _JulSalesLYR; }
        //    set { _JulSalesLYR = value; }

        //}
        //public double AugSalesLYR
        //{
        //    get { return _AugSalesLYR; }
        //    set { _AugSalesLYR = value; }
        //}
        //public double SepSalesLYR
        //{
        //    get { return _SepSalesLYR; }
        //    set { _SepSalesLYR = value; }
        //}
        //public double OctSalesLYR
        //{
        //    get { return _OctSalesLYR; }
        //    set { _OctSalesLYR = value; }
        //}
        //public double NovSalesLYR
        //{
        //    get { return _NovSalesLYR; }
        //    set { _NovSalesLYR = value; }
        //}
        //public double DecSalesLYR
        //{
        //    get { return _DecSalesLYR; }
        //    set { _DecSalesLYR = value; }
        //}
        //public long PGID
        //{
        //    get { return _PGID; }
        //    set { _PGID = value; }
        //}
        //public string PGCode
        //{
        //    get { return _PGCode; }
        //    set { _PGCode = value; }
        //}
        //public string PGName
        //{
        //    get { return _PGName; }
        //    set { _PGName = value; }
        //}
        //public long MAGID
        //{
        //    get { return _MAGID; }
        //    set { _MAGID = value; }
        //}
        //public string MAGCode
        //{
        //    get { return _MAGCode; }
        //    set { _MAGCode = value; }

        //}
        //public string MAGName
        //{
        //    get { return _MAGName; }
        //    set { _MAGName = value; }

        //}
        //public long ASGID
        //{
        //    get { return _ASGID; }
        //    set { _ASGID = value; }
        //}
        //public string ASGCode
        //{
        //    get { return _ASGCode; }
        //    set { _ASGCode = value; }
        //}
        //public string ASGName
        //{
        //    get { return _ASGName; }
        //    set { _ASGName = value; }
        //}
        //public long AGID
        //{
        //    get { return _AGID; }
        //    set { _AGID = value; }
        //}
        //public string AGCode
        //{
        //    get { return _AGCode; }
        //    set { _AGCode = value; }
        //}
        //public string AGName
        //{
        //    get { return _AGName; }
        //    set { _AGName = value; }
        //}
        //public long ProductID
        //{
        //    get { return _ProductID; }
        //    set { _ProductID = value; }
        //}
        //public string ProductCode
        //{
        //    get { return _ProductCode; }
        //    set { _ProductCode = value; }
        //}
        //public string ProductName
        //{
        //    get { return _ProductName; }
        //    set { _ProductName = value; }

        //}
        //public long BrandID
        //{
        //    get { return _BrandID; }
        //    set { _BrandID = value; }
        //}
        //public string BrandCode
        //{
        //    get { return _BrandCode; }
        //    set { _BrandCode = value; }
        //}

        //public string BrandName
        //{
        //    get { return _BrandName; }
        //    set { _BrandName = value; }
        //}
        //public long SubBrandID
        //{
        //    get { return _SubBrandID; }
        //    set { _SubBrandID = value; }
        //}
        //public string SubBrandCode
        //{
        //    get { return _SubBrandCode; }
        //    set { _SubBrandCode = value; }
        //}
        //public string SubBrandName
        //{
        //    get { return _SubBrandName; }
        //    set { _SubBrandName = value; }
        //}
        //public double TotalTerCYR
        //{
        //    get { return _TotalTerCYR; }
        //    set { _TotalTerCYR = value; }
        //}
     
    
           
    }
    public class rptSalesVSCollections : CollectionBaseCustom
    {

        public void Add(rptSalesVSCollection orptSalesVSCollection)
        {
            this.List.Add(orptSalesVSCollection);
        }
        public rptSalesVSCollection this[Int32 Index]
        {
            get
            {
                return (rptSalesVSCollection)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(rptSalesVSCollection))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        /// <summary>
        /// Sales VS Collection Report Customer wise
        /// </summary>
        /// <param name="dCFromDate"></param>
        /// <param name="dCToDate"></param>
        /// <param name="dLFromDate"></param>
        /// <param name="dLToDate"></param>
        public void GetMonthlySalesVsCollectionCustomerWise(DateTime dCYFromDate,DateTime dCYToDate,DateTime dLYCFromDate,DateTime dLYCToDate, DateTime dLYFromDate, DateTime dLYToDate, DateTime dFromDate, DateTime dToDate)
        {
            dCYToDate = dCYToDate.AddDays(1);
            dLYCToDate = dLYCToDate.AddDays(1);
            dLYToDate = dLYToDate.AddDays(1);
            dFromDate = dFromDate.AddDays(1);
            dToDate = dToDate.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();

            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            sQueryStringMaster.Append("Select p.SBUID, p.SBUCode, p.SBUName   ");
            sQueryStringMaster.Append(",p.ChannelID, p.ChannelCode, p.Channeldescription as ChannelName  ");
            sQueryStringMaster.Append(",p.CustomerTypeID, p.CustomerTypeCode, p.CustomerTypeName  ");
            sQueryStringMaster.Append(",p.AreaID, p.AreaCode, p.AreaName  ");
            sQueryStringMaster.Append(",p.TerritoryID, p.TerritoryCode, p.TerritoryName  ");
            sQueryStringMaster.Append(",p.CustomerID, p.CustomerCode, p.CustomerName,p.IsActive  ");
            sQueryStringMaster.Append(",isnull(p.ParentCustomerID, p.CustomerID) as ParentCustomerID  ");
            sQueryStringMaster.Append(",isnull(p.ParentCustomerCode, p.CustomerCode) as ParentCustomerCode  ");
            sQueryStringMaster.Append(",isnull(p.ParentCustomerName, p.CustomerName) as ParentCustomerName  ");
            sQueryStringMaster.Append(",sum(isnull(JanSales,0))as JanSales, sum(isnull(FebSales,0))as FebSales, sum(isnull(MarSales,0))as MarSales  ");
            sQueryStringMaster.Append(",sum(isnull(AprSales,0))as AprSales, sum(isnull(MaySales,0))as MaySales, sum(isnull(JunSales,0))as JunSales  ");
            sQueryStringMaster.Append(",sum(isnull(JulSales,0))as JulSales, sum(isnull(AugSales,0))as AugSales, sum(isnull(SepSales,0))as SepSales  ");
            sQueryStringMaster.Append(",sum(isnull(OctSales,0))as OctSales, sum(isnull(NovSales,0))as NovSales, sum(isnull(DecSales,0))as DecSales  ");
            sQueryStringMaster.Append(",sum(isnull(JanColl,0))as JanColl, sum(isnull(FebColl,0))as FebColl, sum(isnull(MarColl,0))as MarColl  ");
            sQueryStringMaster.Append(",sum(isnull(AprColl,0))as AprColl, sum(isnull(MayColl,0))as MayColl, sum(isnull(JunColl,0))as JunColl  ");
            sQueryStringMaster.Append(",sum(isnull(JulColl,0))as JulColl, sum(isnull(AugColl,0))as AugColl, sum(isnull(SepColl,0))as SepColl  ");
            sQueryStringMaster.Append(",sum(isnull(OctColl,0))as OctColl, sum(isnull(NovColl,0))as NovColl, sum(isnull(DecColl,0))as DecColl  ");
            sQueryStringMaster.Append(",sum(isnull(CumSalesCYR,0))as CumSalesCYR,sum(isnull(CumCollCYR,0))as CumCollCYR ");
            sQueryStringMaster.Append(",sum(isnull(CumSalesLYR,0))as CumSalesLYR,sum(isnull(CumCollLYR,0))as CumCollLYR ");
            sQueryStringMaster.Append(",sum(isnull(TotalSalesLYR,0))as TotalSalesLYR,sum(isnull(TotalCollLYR,0))as TotalCollLYR  ");
            sQueryStringMaster.Append(",sum(isnull(p11.CurrentOS,0))as CurrentOS, sum(isnull(MonthlyTargetAmt,0)) as TargetTO ");
            sQueryStringMaster.Append("from   ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select * from v_customerDetails    ");
            sQueryStringMaster.Append(")as p   ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select p.CustomerID  ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRJanCYR) - abs(sum(p2.DbJanCYR)),0) as JanSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRFebCYR) - abs(sum(p2.DbFebCYR)),0) as FebSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRMarCYR) - abs(sum(p2.DbMarCYR)),0) as MarSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRAprCYR) - abs(sum(p2.DbAprCYR)),0) as AprSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRMayCYR) - abs(sum(p2.DbMayCYR)),0) as MaySales  ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRJunCYR) - abs(sum(p2.DbJunCYR)),0) as JunSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRJulCYR) - abs(sum(p2.DbJulCYR)),0) as JulSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRAugCYR) - abs(sum(p2.DbAugCYR)),0) as AugSales  ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRSepCYR) - abs(sum(p2.DbSepCYR)),0) as SepSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CROctCYR) - abs(sum(p2.DbOctCYR)),0) as OctSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRNovCYR) - abs(sum(p2.DbNovCYR)),0) as NovSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRDcmCYR) - abs(sum(p2.DbDcmCYR)),0) as DecSales  ");
            sQueryStringMaster.Append("from   ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select * from t_customer    ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as p  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 1 then InvoiceAmount else 0 end) as CRJanCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 2 then InvoiceAmount else 0 end) as CRFebCYR,   ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 3 then InvoiceAmount else 0 end) as CRMarCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 4 then InvoiceAmount else 0 end) as CRAprCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 5 then InvoiceAmount else 0 end) as CRMayCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 6 then InvoiceAmount else 0 end) as CRJunCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 7 then InvoiceAmount else 0 end) as CRJulCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 8 then InvoiceAmount else 0 end) as CRAugCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 9 then InvoiceAmount else 0 end) as CRSepCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 10 then InvoiceAmount else 0 end) as CROctCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 11 then InvoiceAmount else 0 end) as CRNovCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 12 then InvoiceAmount else 0 end) as CRDcmCYR,  ");
            sQueryStringMaster.Append("0 as DbJanCYR, 0 as DbFebCYR, 0 as DbMarCYR, 0 as DbAprCYR, 0 as DbMayCYR, 0 as DbJunCYR,  ");
            sQueryStringMaster.Append("0 as DbJulCYR, 0 as DbAugCYR, 0 as DbSepCYR, 0 as DbOctCYR, 0 as DbNovCYR, 0 as DbDcmCYR  ");
            sQueryStringMaster.Append("from t_salesInvoice im,  t_customer cd  ");
            sQueryStringMaster.Append("where  im.CustomerID = cd.CustomerID and  ");
            sQueryStringMaster.Append("invoicedate between ? and ? and invoicedate< ? and invoicetypeid in (?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("group by  im.CustomerID  ");
            sQueryStringMaster.Append("union all   ");
            sQueryStringMaster.Append("select im.CustomerID,  ");
            sQueryStringMaster.Append("0 as CRJanCYR, 0 as CRFebCYR, 0 as CRMarCYR, 0 as CRAprCYR, 0 as CRMayCYR, 0 as CRJunCYR,  ");
            sQueryStringMaster.Append("0 as CRJulCYR, 0 as CRAugCYR, 0 as CRSepCYR, 0 as CROctCYR, 0 as CRNovCYR, 0 as CRDcmCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 1 then InvoiceAmount else 0 end) as DbJanCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 2 then InvoiceAmount else 0 end) as DbFebCYR,   ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 3 then InvoiceAmount else 0 end) as DbMarCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 4 then InvoiceAmount else 0 end) as DbAprCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 5 then InvoiceAmount else 0 end) as DbMayCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 6 then InvoiceAmount else 0 end) as DbJunCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 7 then InvoiceAmount else 0 end) as DbJulCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 8 then InvoiceAmount else 0 end) as DbAugCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 9 then InvoiceAmount else 0 end) as DbSepCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 10 then InvoiceAmount else 0 end) as DbOctCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 11 then InvoiceAmount else 0 end) as DbNovCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 12 then InvoiceAmount else 0 end) as DbDcmCYR  ");
            sQueryStringMaster.Append("from t_salesInvoice im,  t_customer cd  ");
            sQueryStringMaster.Append("where  im.CustomerID = cd.CustomerID and  ");
            sQueryStringMaster.Append("invoicedate between ? and ? and invoicedate< ? and invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("group by  im.CustomerID  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as p2 on p.CustomerID = p2.CustomerID  ");
            sQueryStringMaster.Append("group by p.customerid  ");
            sQueryStringMaster.Append(")as p2 on p.CustomerID = p2.CustomerID   ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select q1.customerid  ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountJan,0) - isnull(q5.DebitAmountJan,0)) as JanColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountFeb,0) - isnull(q5.DebitAmountFeb,0)) as FebColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountMar,0) - isnull(q5.DebitAmountMar,0)) as MarColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountApr,0) - isnull(q5.DebitAmountApr,0)) as AprColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountMay,0) - isnull(q5.DebitAmountMay,0)) as MayColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountJun,0) - isnull(q5.DebitAmountJun,0)) as JunColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountJul,0) - isnull(q5.DebitAmountJul,0)) as JulColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountAug,0) - isnull(q5.DebitAmountAug,0)) as AugColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountSep,0) - isnull(q5.DebitAmountSep,0)) as SepColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountOct,0) - isnull(q5.DebitAmountOct,0)) as OctColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountNov,0) - isnull(q5.DebitAmountNov,0)) as NovColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountDec,0) - isnull(q5.DebitAmountDec,0)) as DecColl   ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q1  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 1 then Amount else 0 end) as CreditAmountJan  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 2 then Amount else 0 end) as CreditAmountFeb  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 3 then Amount else 0 end) as CreditAmountMar  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 4 then Amount else 0 end) as CreditAmountApr  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 5 then Amount else 0 end) as CreditAmountMay  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 6 then Amount else 0 end) as CreditAmountJun  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 7 then Amount else 0 end) as CreditAmountJul  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 8 then Amount else 0 end) as CreditAmountAug  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 9 then Amount else 0 end) as CreditAmountSep  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 10 then Amount else 0 end) as CreditAmountOct  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 11 then Amount else 0 end) as CreditAmountNov  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 12 then Amount else 0 end) as CreditAmountDec  ");
            sQueryStringMaster.Append("from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.TranDate < ?   ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q4  ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 1 then Amount else 0 end) as DebitAmountJan  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 2 then Amount else 0 end) as DebitAmountFeb  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 3 then Amount else 0 end) as DebitAmountMar  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 4 then Amount else 0 end) as DebitAmountApr  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 5 then Amount else 0 end) as DebitAmountMay  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 6 then Amount else 0 end) as DebitAmountJun  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 7 then Amount else 0 end) as DebitAmountJul  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 8 then Amount else 0 end) as DebitAmountAug  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 9 then Amount else 0 end) as DebitAmountSep  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 10 then Amount else 0 end) as DebitAmountOct  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 11 then Amount else 0 end) as DebitAmountNov  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 12 then Amount else 0 end) as DebitAmountDec  ");
            sQueryStringMaster.Append("from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.TranDate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q5  ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as p3  ");
            sQueryStringMaster.Append("on p.Customerid = p3.Customerid   ");

            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as CumSalesCYR     ");
            sQueryStringMaster.Append("From    ");
            sQueryStringMaster.Append("(    ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount    ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)    ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append("union all    ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount,sum(invoiceamount)as drSalesAmount   ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?)   ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append(")as qq1    ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(") as p4  ");
            sQueryStringMaster.Append("on p.Customerid = p4.Customerid  ");
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ( isnull(q4.CreditAmount,0) - isnull(q5.DebitAmount,0)) as CumCollCYR   ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q1  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q4  ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?)  and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q5  ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid  ");
            sQueryStringMaster.Append(")as p5  ");
            sQueryStringMaster.Append("on p.Customerid = p5.Customerid  ");

            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as CumSalesLYR     ");
            sQueryStringMaster.Append("From    ");
            sQueryStringMaster.Append("(    ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount    ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)    ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append("union all    ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount,sum(invoiceamount)as drSalesAmount   ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?)   ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append(")as qq1    ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(") as p8  ");
            sQueryStringMaster.Append("on p.Customerid = p8.Customerid  ");
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ( isnull(q4.CreditAmount,0) - isnull(q5.DebitAmount,0)) as CumCollLYR   ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q1  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q4  ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?)  and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q5  ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid  ");
            sQueryStringMaster.Append(")as p7  ");
            sQueryStringMaster.Append("on p.Customerid = p7.Customerid  ");
            ////////////////////////////
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as TotalSalesLYR     ");
            sQueryStringMaster.Append("From    ");
            sQueryStringMaster.Append("(    ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount    ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)    ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append("union all    ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount,sum(invoiceamount)as drSalesAmount   ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?)   ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append(")as qq1    ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(") as p9  ");
            sQueryStringMaster.Append("on p.Customerid = p9.Customerid  ");
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ( isnull(q4.CreditAmount,0) - isnull(q5.DebitAmount,0)) as TotalCollLYR   ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q1  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q4  ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?)  and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q5  ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid  ");
            sQueryStringMaster.Append(")as p10  ");
            sQueryStringMaster.Append("on p.Customerid = p10.Customerid  ");

            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ((q1.CurrentBalance - isnull(q2.CreditAmount,0) ) + isnull(q3.DebitAmount,0)) as CurrentOS  ");
            sQueryStringMaster.Append("from   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount   ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q1   ");
            sQueryStringMaster.Append("left outer join   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt    ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and transide = ? and ct.TranDate between ? and ? and TranDate < ?  ");
            sQueryStringMaster.Append("group by customerid   ");
            sQueryStringMaster.Append(")    ");
            sQueryStringMaster.Append("as q2   ");
            sQueryStringMaster.Append("on q1.customerid = q2.customerid   ");
            sQueryStringMaster.Append("left outer join   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt    ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and transide = ?  and ct.TranDate between ? and ? and TranDate < ?  ");
            sQueryStringMaster.Append("group by customerid   ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q3   ");
            sQueryStringMaster.Append("on q1.customerid = q3.customerid   ");
            sQueryStringMaster.Append(")as p11  ");
            sQueryStringMaster.Append("on p.customerid = p11.customerid   ");
            //////////////////////////////

            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select MarketGroupID as CustomerID, sum(Turnover)as MonthlyTargetAmt ");
            sQueryStringMaster.Append("From t_PlanBudgetTarget   ");
            sQueryStringMaster.Append("Where plantype in (?) and periodtype in (?) and MarketScopeType in (?)   ");
            sQueryStringMaster.Append("and PeriodDate between ? and ? ");
            sQueryStringMaster.Append("Group By MarketGroupID ");
            sQueryStringMaster.Append(")as p6 ");
            sQueryStringMaster.Append("on p.Customerid = p6.Customerid  ");

            sQueryStringMaster.Append("group by   ");
            sQueryStringMaster.Append("p.SBUID, p.SBUCode, p.SBUName   ");
            sQueryStringMaster.Append(",p.ChannelID, p.ChannelCode, p.Channeldescription   ");
            sQueryStringMaster.Append(",p.CustomerTypeID, p.CustomerTypeCode, p.CustomerTypeName  ");
            sQueryStringMaster.Append(",p.AreaID, p.AreaCode, p.AreaName  ");
            sQueryStringMaster.Append(",p.TerritoryID, p.TerritoryCode, p.TerritoryName  ");
            sQueryStringMaster.Append(",p.CustomerID, p.CustomerCode, p.CustomerName,p.IsActive  ");
            sQueryStringMaster.Append(",isnull(p.ParentCustomerID, p.CustomerID)  ");
            sQueryStringMaster.Append(",isnull(p.ParentCustomerCode, p.CustomerCode)  ");
            sQueryStringMaster.Append(",isnull(p.ParentCustomerName, p.CustomerName)  ");
        
            //Command time out
            cmd.CommandTimeout = 0;
            cmd.CommandText = sQueryStringMaster.ToString();

            cmd.Parameters.AddWithValue("InvoiceDate", dCYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", dCYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);


            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dCYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dCYToDate);
            cmd.Parameters.AddWithValue("TranDate", dCYToDate);



            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dCYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dCYToDate);
            cmd.Parameters.AddWithValue("TranDate", dCYToDate);


            cmd.Parameters.AddWithValue("InvoiceDate", dCYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", dCYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dCYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dCYToDate);
            cmd.Parameters.AddWithValue("TranDate", dCYToDate);



            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dCYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dCYToDate);
            cmd.Parameters.AddWithValue("TranDate", dCYToDate);

            cmd.Parameters.AddWithValue("InvoiceDate", dLYCFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate",dLYCToDate);
            cmd.Parameters.AddWithValue("InvoiceDate",dLYCToDate);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", dLYCFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate",dLYCToDate);
            cmd.Parameters.AddWithValue("InvoiceDate",dLYCToDate);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dLYCFromDate);
            cmd.Parameters.AddWithValue("TranDate",dLYCToDate);
            cmd.Parameters.AddWithValue("TranDate",dLYCToDate);



            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dLYCFromDate);
            cmd.Parameters.AddWithValue("TranDate",dLYCToDate);
            cmd.Parameters.AddWithValue("TranDate",dLYCToDate);


            cmd.Parameters.AddWithValue("InvoiceDate", dLYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dLYToDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dLYToDate);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", dLYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dLYToDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dLYToDate);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dLYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dLYToDate);
            cmd.Parameters.AddWithValue("TranDate", dLYToDate);


            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dLYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dLYToDate);
            cmd.Parameters.AddWithValue("TranDate", dLYToDate);

            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionSide.CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dFromDate);
            cmd.Parameters.AddWithValue("TranDate", dToDate);
            cmd.Parameters.AddWithValue("TranDate", dToDate);

            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionSide.DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dFromDate);
            cmd.Parameters.AddWithValue("TranDate", dToDate);
            cmd.Parameters.AddWithValue("TranDate", dToDate);

            cmd.Parameters.AddWithValue("PlanType", (short)Dictionary.PlanType.Target);
            cmd.Parameters.AddWithValue("PeriodType", (short)Dictionary.PeriodType.Monthly);
            cmd.Parameters.AddWithValue("MarketScopeType", (short)Dictionary.MarketScopeType.Customer);
            cmd.Parameters.AddWithValue("PeriodDate", dCYFromDate);
            cmd.Parameters.AddWithValue("PeriodDate", dCYToDate);

        

            GetMonthlySalesVsCollectionCustomerWiseData(cmd);
        }
        private void GetMonthlySalesVsCollectionCustomerWiseData(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptSalesVSCollection oItem = new rptSalesVSCollection();

                    if (reader["SBUID"] != DBNull.Value)
                        oItem.SBUID = Convert.ToInt64(reader["SBUID"]);
                    else oItem.SBUID = -1;
                    if (reader["SBUCode"] != DBNull.Value)
                        oItem.SBUCode = (string)(reader["SBUCode"]);
                    else oItem.SBUCode = "";
                    if (reader["SBUName"] != DBNull.Value)
                        oItem.SBUName = (string)(reader["SBUName"]);
                    else oItem.SBUName = "";              

                    if (reader["ChannelId"] != DBNull.Value)
                        oItem.ChannelId = Convert.ToInt64(reader["ChannelId"]);
                    else oItem.ChannelId = -1;
                    if (reader["ChannelCode"] != DBNull.Value)
                        oItem.ChannelCode = (string)(reader["ChannelCode"]);
                    else oItem.ChannelCode = "";
                    if (reader["ChannelName"] != DBNull.Value)
                        oItem.ChannelName = (string)(reader["ChannelName"]);
                    else oItem.ChannelName = "";

                    if (reader["CustomerTypeId"] != DBNull.Value)
                        oItem.CustomerTypeId = Convert.ToInt64(reader["CustomerTypeId"]);
                    else oItem.CustomerTypeId = -1;
                    if (reader["CustomerTypeCode"] != DBNull.Value)
                        oItem.CustomerTypeCode = (string)(reader["CustomerTypeCode"]);
                    else oItem.CustomerTypeCode = "";
                    if (reader["CustomerTypeName"] != DBNull.Value)
                        oItem.CustomerTypeName = (string)(reader["CustomerTypeName"]);
                    else oItem.CustomerTypeName = "";

                    if (reader["AreaId"] != DBNull.Value)
                        oItem.AreaId = Convert.ToInt64(reader["AreaId"]);
                    else oItem.AreaId = -1;
                    if (reader["AreaCode"] != DBNull.Value)
                        oItem.AreaCode = (string)(reader["AreaCode"]);
                    else oItem.AreaCode = "";
                    if (reader["AreaName"] != DBNull.Value)
                        oItem.AreaName = (string)(reader["AreaName"]);
                    else oItem.AreaName = "";
                    if (reader["CustomerId"] != DBNull.Value)
                        oItem.CustomerId = Convert.ToInt64(reader["CustomerId"]);
                    else oItem.CustomerId = -1;
                    if (reader["CustomerCode"] != DBNull.Value)
                        oItem.CustomerCode = (string)(reader["CustomerCode"]);
                    else oItem.CustomerCode = "";
                    if (reader["CustomerName"] != DBNull.Value)
                        oItem.CustomerName = (string)(reader["CustomerName"]);
                    else oItem.CustomerName = "";
                    if (reader["IsActive"] != DBNull.Value)
                        oItem.IsActive = Convert.ToInt16(reader["IsActive"]);
                    else oItem.IsActive = 1;

                    if (reader["ParentCustomerID"] != DBNull.Value)
                        oItem.ParentCustomerID = Convert.ToInt64(reader["ParentCustomerID"]);
                    else oItem.ParentCustomerID = -1;
                    if (reader["ParentCustomerCode"] != DBNull.Value)
                        oItem.ParentCustomerCode = (string)(reader["ParentCustomerCode"]);
                    else oItem.ParentCustomerCode = "";
                    if (reader["ParentCustomerName"] != DBNull.Value)
                        oItem.ParentCustomerName = (string)(reader["ParentCustomerName"]);
                    else oItem.ParentCustomerName = "";
                    if (reader["TerritoryId"] != DBNull.Value)
                        oItem.TerritoryId = Convert.ToInt64(reader["TerritoryId"]);
                    else oItem.TerritoryId = -1;
                    if (reader["TerritoryCode"] != DBNull.Value)
                        oItem.TerritoryCode = (string)(reader["TerritoryCode"]);
                    else oItem.TerritoryCode = "";
                    if (reader["TerritoryName"] != DBNull.Value)
                    oItem.TerritoryName = (string)(reader["TerritoryName"]);
                    else oItem.TerritoryName = "";

                    if (reader["JanSales"] != DBNull.Value)
                        oItem.JanSales =  Convert.ToDouble(reader["JanSales"]);
                    else oItem.JanSales = 0;
                    if (reader["FebSales"] != DBNull.Value)
                        oItem.FebSales =  Convert.ToDouble(reader["FebSales"]);
                    else oItem.FebSales = 0;
                    if (reader["MarSales"] != DBNull.Value)
                        oItem.MarSales =  Convert.ToDouble(reader["MarSales"]);
                    else oItem.MarSales = 0;
                    if (reader["AprSales"] != DBNull.Value)
                        oItem.AprSales =  Convert.ToDouble(reader["AprSales"]);
                    else oItem.AprSales = 0;
                    if (reader["MaySales"] != DBNull.Value)
                        oItem.MaySales =  Convert.ToDouble(reader["MaySales"]);
                    else oItem.MaySales = 0;
                    if (reader["JunSales"] != DBNull.Value)
                        oItem.JunSales =  Convert.ToDouble(reader["JunSales"]);
                    else oItem.JunSales = 0;
                    if (reader["JulSales"] != DBNull.Value)
                        oItem.JulSales = Convert.ToDouble(reader["JulSales"]);
                    else oItem.JulSales = 0;
                    if (reader["AugSales"] != DBNull.Value)
                        oItem.AugSales =  Convert.ToDouble(reader["AugSales"]);
                    else oItem.AugSales = 0;
                    if (reader["SepSales"] != DBNull.Value)
                        oItem.SepSales =  Convert.ToDouble(reader["SepSales"]);
                    else oItem.SepSales = 0;
                    if (reader["OctSales"] != DBNull.Value)
                        oItem.OctSales =  Convert.ToDouble(reader["OctSales"]);
                    else oItem.OctSales = 0;
                    if (reader["NovSales"] != DBNull.Value)
                        oItem.NovSales =  Convert.ToDouble(reader["NovSales"]);
                    else oItem.NovSales = 0;
                    if (reader["DecSales"] != DBNull.Value)
                        oItem.DecSales =  Convert.ToDouble(reader["DecSales"]);
                    else oItem.DecSales = 0;

                    if (reader["JanColl"] != DBNull.Value)
                        oItem.JanColl =  Convert.ToDouble(reader["JanColl"]);
                    else oItem.JanColl = 0;
                    if (reader["FebColl"] != DBNull.Value)
                        oItem.FebColl =  Convert.ToDouble(reader["FebColl"]);
                    else oItem.FebColl = 0;
                    if (reader["MarColl"] != DBNull.Value)
                        oItem.MarColl =  Convert.ToDouble(reader["MarColl"]);
                    else oItem.MarColl = 0;
                    if (reader["AprColl"] != DBNull.Value)
                        oItem.AprColl =  Convert.ToDouble(reader["AprColl"]);
                    else oItem.AprColl = 0;
                    if (reader["MayColl"] != DBNull.Value)
                        oItem.MayColl =  Convert.ToDouble(reader["MayColl"]);
                    else oItem.MayColl = 0;
                    if (reader["JunColl"] != DBNull.Value)
                        oItem.JunColl =  Convert.ToDouble(reader["JunColl"]);
                    else oItem.JunColl = 0;
                    if (reader["JulColl"] != DBNull.Value)
                        oItem.JulColl =  Convert.ToDouble(reader["JulColl"]);
                    else oItem.JulColl = 0;
                    if (reader["AugColl"] != DBNull.Value)
                        oItem.AugColl =  Convert.ToDouble(reader["AugColl"]);
                    else oItem.AugColl = 0;
                    if (reader["SepColl"] != DBNull.Value)
                        oItem.SepColl =  Convert.ToDouble(reader["SepColl"]);
                    else oItem.SepColl = 0;
                    if (reader["OctColl"] != DBNull.Value)
                        oItem.OctColl =  Convert.ToDouble(reader["OctColl"]);
                    else oItem.OctColl = 0;
                    if (reader["NovColl"] != DBNull.Value)
                        oItem.NovColl =  Convert.ToDouble(reader["NovColl"]);
                    else oItem.NovColl = 0;
                    if (reader["DecColl"] != DBNull.Value)
                        oItem.DecColl =  Convert.ToDouble(reader["DecColl"]);
                    else oItem.DecColl = 0;

                    if (reader["CumSalesCYR"] != DBNull.Value)
                        oItem.CumSalesCYR =  Convert.ToDouble(reader["CumSalesCYR"]);
                    else oItem.CumSalesCYR = 0;
                    if (reader["CumCollCYR"] != DBNull.Value)
                        oItem.CumCollCYR =  Convert.ToDouble(reader["CumCollCYR"]);
                    else oItem.CumCollCYR = 0;
                    if (reader["CumSalesLYR"] != DBNull.Value)
                        oItem.CumSalesLYR = Convert.ToDouble(reader["CumSalesLYR"]);
                    else oItem.CumSalesLYR = 0;
                    if (reader["CumCollLYR"] != DBNull.Value)
                        oItem.CumCollLYR = Convert.ToDouble(reader["CumCollLYR"]);
                    else oItem.CumCollLYR = 0;
                    if (reader["TotalSalesLYR"] != DBNull.Value)
                        oItem.TotalSalesLYR =  Convert.ToDouble(reader["TotalSalesLYR"]);
                    else oItem.TotalSalesLYR = 0;
                    if (reader["TotalCollLYR"] != DBNull.Value)
                        oItem.TotalCollLYR =  Convert.ToDouble(reader["TotalCollLYR"]);
                    else oItem.TotalCollLYR = 0;
                    if (reader["TargetTO"] != DBNull.Value)
                        oItem.TargetTO =  Convert.ToDouble(reader["TargetTO"]);
                    else oItem.TargetTO = 0;
                    if (reader["CurrentOS"] != DBNull.Value)
                        oItem.CurrentOS = Convert.ToDouble(reader["CurrentOS"]);
                    else oItem.CurrentOS = 0;


                    Add(oItem);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void FromDataSetCustomerWise(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    rptSalesVSCollection oItem = new rptSalesVSCollection();

                  
                        oItem.SBUID = Convert.ToInt64(oRow["SBUID"]);    
                        oItem.SBUCode = (string)(oRow["SBUCode"]);     
                        oItem.SBUName = (string)(oRow["SBUName"]);        
                                     
                        oItem.ChannelId = Convert.ToInt64(oRow["ChannelId"]);               
                        oItem.ChannelCode = (string)(oRow["ChannelCode"]);              
                        oItem.ChannelName = (string)(oRow["ChannelName"]);                 
                        oItem.CustomerTypeId = Convert.ToInt64(oRow["CustomerTypeId"]);               
                        oItem.CustomerTypeCode = (string)(oRow["CustomerTypeCode"]);                  
                        oItem.CustomerTypeName = (string)(oRow["CustomerTypeName"]);                 
                        oItem.AreaId = Convert.ToInt64(oRow["AreaId"]);                  
                        oItem.AreaCode = (string)(oRow["AreaCode"]);                  
                        oItem.AreaName = (string)(oRow["AreaName"]);                 
                        oItem.CustomerId = Convert.ToInt64(oRow["CustomerId"]);               
                        oItem.CustomerCode = (string)(oRow["CustomerCode"]);                
                        oItem.CustomerName = (string)(oRow["CustomerName"]);                 
                        oItem.IsActive = Convert.ToInt16(oRow["IsActive"]);               
                        oItem.ParentCustomerID = Convert.ToInt64(oRow["ParentCustomerID"]);                
                        oItem.ParentCustomerCode = (string)(oRow["ParentCustomerCode"]);               
                        oItem.ParentCustomerName = (string)(oRow["ParentCustomerName"]);                   
                        oItem.TerritoryId = Convert.ToInt64(oRow["TerritoryId"]);                  
                        oItem.TerritoryCode = (string)(oRow["TerritoryCode"]);                
                        oItem.TerritoryName = (string)(oRow["TerritoryName"]);
                   
                        oItem.JanSales = Convert.ToDouble(oRow["JanSales"]);                  
                        oItem.FebSales = Convert.ToDouble(oRow["FebSales"]);                
                        oItem.MarSales = Convert.ToDouble(oRow["MarSales"]);                  
                        oItem.AprSales = Convert.ToDouble(oRow["AprSales"]);                  
                        oItem.MaySales = Convert.ToDouble(oRow["MaySales"]);                   
                        oItem.JunSales = Convert.ToDouble(oRow["JunSales"]);
                        oItem.JulSales = Convert.ToDouble(oRow["JulSales"]);                   
                        oItem.AugSales = Convert.ToDouble(oRow["AugSales"]);                   
                        oItem.SepSales = Convert.ToDouble(oRow["SepSales"]);               
                        oItem.OctSales = Convert.ToDouble(oRow["OctSales"]);                
                        oItem.NovSales = Convert.ToDouble(oRow["NovSales"]);                 
                        oItem.DecSales = Convert.ToDouble(oRow["DecSales"]);
              
                        oItem.JanColl = Convert.ToDouble(oRow["JanColl"]);                  
                        oItem.FebColl = Convert.ToDouble(oRow["FebColl"]);                  
                        oItem.MarColl = Convert.ToDouble(oRow["MarColl"]);              
                        oItem.AprColl = Convert.ToDouble(oRow["AprColl"]);                 
                        oItem.MayColl = Convert.ToDouble(oRow["MayColl"]);                   
                        oItem.JunColl = Convert.ToDouble(oRow["JunColl"]);                
                        oItem.JulColl = Convert.ToDouble(oRow["JulColl"]);
                        oItem.AugColl = Convert.ToDouble(oRow["AugColl"]);                 
                        oItem.SepColl = Convert.ToDouble(oRow["SepColl"]);                  
                        oItem.OctColl = Convert.ToDouble(oRow["OctColl"]);                
                        oItem.NovColl = Convert.ToDouble(oRow["NovColl"]);                 
                        oItem.DecColl = Convert.ToDouble(oRow["DecColl"]);
                 
                        oItem.CumSalesCYR = Convert.ToDouble(oRow["CumSalesCYR"]);               
                        oItem.CumCollCYR = Convert.ToDouble(oRow["CumCollCYR"]);              
                        oItem.CumSalesLYR = Convert.ToDouble(oRow["CumSalesLYR"]);               
                        oItem.CumCollLYR = Convert.ToDouble(oRow["CumCollLYR"]);                 
                        oItem.TotalSalesLYR = Convert.ToDouble(oRow["TotalSalesLYR"]);                 
                        oItem.TotalCollLYR = Convert.ToDouble(oRow["TotalCollLYR"]);                 
                        oItem.TargetTO = Convert.ToDouble(oRow["TargetTO"]);                  
                        oItem.CurrentOS = Convert.ToDouble(oRow["CurrentOS"]);
                  
                    InnerList.Add(oItem);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Sales VS Collection Report Customer wise
        /// </summary>
        /// <param name="dCFromDate"></param>
        /// <param name="dCToDate"></param>
        /// <param name="dLFromDate"></param>
        /// <param name="dLToDate"></param>
        public void GetYearlyMonthlySalesVsCollectionParentCustomerWise(DateTime dCYFromDate, DateTime dCYToDate, DateTime dFromDate, DateTime dToDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            sQueryStringMaster.Append("Select p.SBUID, p.SBUCode, p.SBUName   ");
            sQueryStringMaster.Append(",p.ChannelID, p.ChannelCode, p.Channeldescription as ChannelName  ");

            sQueryStringMaster.Append(",isnull(p.ParentCustomerID, p.CustomerID) as ParentCustomerID  ");
            sQueryStringMaster.Append(",isnull(p.ParentCustomerCode, p.CustomerCode) as ParentCustomerCode  ");
            sQueryStringMaster.Append(",isnull(p.ParentCustomerName, p.CustomerName) as ParentCustomerName  ");
            sQueryStringMaster.Append(",sum(isnull(JanSales,0))as JanSales, sum(isnull(FebSales,0))as FebSales, sum(isnull(MarSales,0))as MarSales  ");
            sQueryStringMaster.Append(",sum(isnull(AprSales,0))as AprSales, sum(isnull(MaySales,0))as MaySales, sum(isnull(JunSales,0))as JunSales  ");
            sQueryStringMaster.Append(",sum(isnull(JulSales,0))as JulSales, sum(isnull(AugSales,0))as AugSales, sum(isnull(SepSales,0))as SepSales  ");
            sQueryStringMaster.Append(",sum(isnull(OctSales,0))as OctSales, sum(isnull(NovSales,0))as NovSales, sum(isnull(DecSales,0))as DecSales  ");
            sQueryStringMaster.Append(",sum(isnull(JanColl,0))as JanColl, sum(isnull(FebColl,0))as FebColl, sum(isnull(MarColl,0))as MarColl  ");
            sQueryStringMaster.Append(",sum(isnull(AprColl,0))as AprColl, sum(isnull(MayColl,0))as MayColl, sum(isnull(JunColl,0))as JunColl  ");
            sQueryStringMaster.Append(",sum(isnull(JulColl,0))as JulColl, sum(isnull(AugColl,0))as AugColl, sum(isnull(SepColl,0))as SepColl  ");
            sQueryStringMaster.Append(",sum(isnull(OctColl,0))as OctColl, sum(isnull(NovColl,0))as NovColl, sum(isnull(DecColl,0))as DecColl  ");
            sQueryStringMaster.Append(",sum(isnull(p11.currentOS,0))as CurrentOS  ");
            sQueryStringMaster.Append("from   ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select * from v_customerDetails  ");
            sQueryStringMaster.Append(")as p   ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select p.CustomerID  ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRJanCYR) - abs(sum(p2.DbJanCYR)),0) as JanSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRFebCYR) - abs(sum(p2.DbFebCYR)),0) as FebSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRMarCYR) - abs(sum(p2.DbMarCYR)),0) as MarSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRAprCYR) - abs(sum(p2.DbAprCYR)),0) as AprSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRMayCYR) - abs(sum(p2.DbMayCYR)),0) as MaySales  ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRJunCYR) - abs(sum(p2.DbJunCYR)),0) as JunSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRJulCYR) - abs(sum(p2.DbJulCYR)),0) as JulSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRAugCYR) - abs(sum(p2.DbAugCYR)),0) as AugSales  ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRSepCYR) - abs(sum(p2.DbSepCYR)),0) as SepSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CROctCYR) - abs(sum(p2.DbOctCYR)),0) as OctSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRNovCYR) - abs(sum(p2.DbNovCYR)),0) as NovSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRDcmCYR) - abs(sum(p2.DbDcmCYR)),0) as DecSales  ");
            sQueryStringMaster.Append("from   ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select * from t_customer    ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as p  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 1 then InvoiceAmount else 0 end) as CRJanCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 2 then InvoiceAmount else 0 end) as CRFebCYR,   ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 3 then InvoiceAmount else 0 end) as CRMarCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 4 then InvoiceAmount else 0 end) as CRAprCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 5 then InvoiceAmount else 0 end) as CRMayCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 6 then InvoiceAmount else 0 end) as CRJunCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 7 then InvoiceAmount else 0 end) as CRJulCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 8 then InvoiceAmount else 0 end) as CRAugCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 9 then InvoiceAmount else 0 end) as CRSepCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 10 then InvoiceAmount else 0 end) as CROctCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 11 then InvoiceAmount else 0 end) as CRNovCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 12 then InvoiceAmount else 0 end) as CRDcmCYR,  ");
            sQueryStringMaster.Append("0 as DbJanCYR, 0 as DbFebCYR, 0 as DbMarCYR, 0 as DbAprCYR, 0 as DbMayCYR, 0 as DbJunCYR,  ");
            sQueryStringMaster.Append("0 as DbJulCYR, 0 as DbAugCYR, 0 as DbSepCYR, 0 as DbOctCYR, 0 as DbNovCYR, 0 as DbDcmCYR  ");
            sQueryStringMaster.Append("from t_salesInvoice im,  t_customer cd  ");
            sQueryStringMaster.Append("where  im.CustomerID = cd.CustomerID and  ");
            sQueryStringMaster.Append("invoicedate between ? and ? and invoicedate< ? and invoicetypeid in (?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("group by  im.CustomerID  ");
            sQueryStringMaster.Append("union all   ");
            sQueryStringMaster.Append("select im.CustomerID,  ");
            sQueryStringMaster.Append("0 as CRJanCYR, 0 as CRFebCYR, 0 as CRMarCYR, 0 as CRAprCYR, 0 as CRMayCYR, 0 as CRJunCYR,  ");
            sQueryStringMaster.Append("0 as CRJulCYR, 0 as CRAugCYR, 0 as CRSepCYR, 0 as CROctCYR, 0 as CRNovCYR, 0 as CRDcmCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 1 then InvoiceAmount else 0 end) as DbJanCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 2 then InvoiceAmount else 0 end) as DbFebCYR,   ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 3 then InvoiceAmount else 0 end) as DbMarCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 4 then InvoiceAmount else 0 end) as DbAprCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 5 then InvoiceAmount else 0 end) as DbMayCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 6 then InvoiceAmount else 0 end) as DbJunCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 7 then InvoiceAmount else 0 end) as DbJulCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 8 then InvoiceAmount else 0 end) as DbAugCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 9 then InvoiceAmount else 0 end) as DbSepCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 10 then InvoiceAmount else 0 end) as DbOctCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 11 then InvoiceAmount else 0 end) as DbNovCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 12 then InvoiceAmount else 0 end) as DbDcmCYR  ");
            sQueryStringMaster.Append("from t_salesInvoice im,  t_customer cd  ");
            sQueryStringMaster.Append("where  im.CustomerID = cd.CustomerID and  ");
            sQueryStringMaster.Append("invoicedate between ? and ? and invoicedate< ? and invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("group by  im.CustomerID  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as p2 on p.CustomerID = p2.CustomerID  ");
            sQueryStringMaster.Append("group by p.customerid  ");
            sQueryStringMaster.Append(")as p2 on p.CustomerID = p2.CustomerID   ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select q1.customerid  ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountJan,0) - isnull(q5.DebitAmountJan,0)) as JanColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountFeb,0) - isnull(q5.DebitAmountFeb,0)) as FebColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountMar,0) - isnull(q5.DebitAmountMar,0)) as MarColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountApr,0) - isnull(q5.DebitAmountApr,0)) as AprColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountMay,0) - isnull(q5.DebitAmountMay,0)) as MayColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountJun,0) - isnull(q5.DebitAmountJun,0)) as JunColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountJul,0) - isnull(q5.DebitAmountJul,0)) as JulColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountAug,0) - isnull(q5.DebitAmountAug,0)) as AugColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountSep,0) - isnull(q5.DebitAmountSep,0)) as SepColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountOct,0) - isnull(q5.DebitAmountOct,0)) as OctColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountNov,0) - isnull(q5.DebitAmountNov,0)) as NovColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountDec,0) - isnull(q5.DebitAmountDec,0)) as DecColl   ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q1  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 1 then Amount else 0 end) as CreditAmountJan  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 2 then Amount else 0 end) as CreditAmountFeb  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 3 then Amount else 0 end) as CreditAmountMar  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 4 then Amount else 0 end) as CreditAmountApr  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 5 then Amount else 0 end) as CreditAmountMay  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 6 then Amount else 0 end) as CreditAmountJun  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 7 then Amount else 0 end) as CreditAmountJul  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 8 then Amount else 0 end) as CreditAmountAug  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 9 then Amount else 0 end) as CreditAmountSep  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 10 then Amount else 0 end) as CreditAmountOct  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 11 then Amount else 0 end) as CreditAmountNov  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 12 then Amount else 0 end) as CreditAmountDec  ");
            sQueryStringMaster.Append("from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.TranDate < ?   ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q4  ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 1 then Amount else 0 end) as DebitAmountJan  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 2 then Amount else 0 end) as DebitAmountFeb  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 3 then Amount else 0 end) as DebitAmountMar  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 4 then Amount else 0 end) as DebitAmountApr  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 5 then Amount else 0 end) as DebitAmountMay  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 6 then Amount else 0 end) as DebitAmountJun  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 7 then Amount else 0 end) as DebitAmountJul  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 8 then Amount else 0 end) as DebitAmountAug  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 9 then Amount else 0 end) as DebitAmountSep  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 10 then Amount else 0 end) as DebitAmountOct  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 11 then Amount else 0 end) as DebitAmountNov  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 12 then Amount else 0 end) as DebitAmountDec  ");
            sQueryStringMaster.Append("from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.TranDate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q5  ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as p3  ");
            sQueryStringMaster.Append("on p.Customerid = p3.Customerid   ");

            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ((q1.CurrentBalance - isnull(q2.CreditAmount,0) ) + isnull(q3.DebitAmount,0)) as CurrentOS  ");
            sQueryStringMaster.Append("from   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount   ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q1   ");
            sQueryStringMaster.Append("left outer join   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt    ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and transide = ? and ct.TranDate between ? and ? and TranDate < ?  ");
            sQueryStringMaster.Append("group by customerid   ");
            sQueryStringMaster.Append(")    ");
            sQueryStringMaster.Append("as q2   ");
            sQueryStringMaster.Append("on q1.customerid = q2.customerid   ");
            sQueryStringMaster.Append("left outer join   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt    ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and transide = ?  and ct.TranDate between ? and ? and TranDate < ?  ");
            sQueryStringMaster.Append("group by customerid   ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q3   ");
            sQueryStringMaster.Append("on q1.customerid = q3.customerid   ");
            sQueryStringMaster.Append(")as p11  ");
            sQueryStringMaster.Append("on p.customerid = p11.customerid   ");

            sQueryStringMaster.Append("group by   ");
            sQueryStringMaster.Append("p.SBUID, p.SBUCode, p.SBUName   ");
            sQueryStringMaster.Append(",p.ChannelID, p.ChannelCode, p.Channeldescription   ");

            sQueryStringMaster.Append(",isnull(p.ParentCustomerID, p.CustomerID)  ");
            sQueryStringMaster.Append(",isnull(p.ParentCustomerCode, p.CustomerCode)  ");
            sQueryStringMaster.Append(",isnull(p.ParentCustomerName, p.CustomerName)  ");


           
            //Command time out
            cmd.CommandTimeout = 0;
            cmd.CommandText = sQueryStringMaster.ToString();

            //cmd.Parameters.AddWithValue("IsActive", Dictionary.ActiveOrInActiveStatus.ACTIVE);

            cmd.Parameters.AddWithValue("InvoiceDate", dCYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", dCYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);


            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dCYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));



            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dCYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));

            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionSide.CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dFromDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dToDate.AddDays(1));

            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionSide.DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dFromDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dToDate.AddDays(1));


            GetYearlyMonthlySalesVsCollectionParentCustomerWiseData(cmd);
        }
        private void GetYearlyMonthlySalesVsCollectionParentCustomerWiseData(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptSalesVSCollection oItem = new rptSalesVSCollection();


                    if (reader["SBUID"] != DBNull.Value)
                        oItem.SBUID = Convert.ToInt64(reader["SBUID"]);
                    else oItem.SBUID = -1;
                    if (reader["SBUCode"] != DBNull.Value)
                        oItem.SBUCode = (string)(reader["SBUCode"]);
                    else oItem.SBUCode = "";
                    if (reader["SBUName"] != DBNull.Value)
                        oItem.SBUName = (string)(reader["SBUName"]);
                    else oItem.SBUName = "";

                    if (reader["ChannelId"] != DBNull.Value)
                        oItem.ChannelId = Convert.ToInt64(reader["ChannelId"]);
                    else oItem.ChannelId = -1;
                    if (reader["ChannelCode"] != DBNull.Value)
                        oItem.ChannelCode = (string)(reader["ChannelCode"]);
                    else oItem.ChannelCode = "";
                    if (reader["ChannelName"] != DBNull.Value)
                        oItem.ChannelName = (string)(reader["ChannelName"]);
                    else oItem.ChannelName = "";

                    oItem.CustomerTypeId = -1;
                    oItem.CustomerTypeCode = "";
                    oItem.CustomerTypeName = "";

                    oItem.AreaId = -1;
                    oItem.AreaCode = "";
                    oItem.AreaName = "";
                    oItem.CustomerId = -1;
                    oItem.CustomerCode = "";
                    oItem.CustomerName = "";
                    oItem.IsActive = 1;

                    oItem.ParentCustomerID = -1;
                    oItem.ParentCustomerCode = "";
                    oItem.ParentCustomerName = "";
                    oItem.TerritoryId = -1;
                    oItem.TerritoryCode = "";
                    oItem.TerritoryName = "";

                    if (reader["ParentCustomerID"] != DBNull.Value)
                        oItem.ParentCustomerID = Convert.ToInt64(reader["ParentCustomerID"]);
                    else oItem.ParentCustomerID = -1;
                    if (reader["ParentCustomerCode"] != DBNull.Value)
                        oItem.ParentCustomerCode = (string)(reader["ParentCustomerCode"]);
                    else oItem.ParentCustomerCode = "";
                    if (reader["ParentCustomerName"] != DBNull.Value)
                        oItem.ParentCustomerName = (string)(reader["ParentCustomerName"]);
                    else oItem.ParentCustomerName = "";
                    oItem.TerritoryId = -1;
                    oItem.TerritoryCode = "";
                    oItem.TerritoryName = "";

                    if (reader["JanSales"] != DBNull.Value)
                        oItem.JanSales = Convert.ToDouble(reader["JanSales"]);
                    else oItem.JanSales = 0;
                    if (reader["FebSales"] != DBNull.Value)
                        oItem.FebSales = Convert.ToDouble(reader["FebSales"]);
                    else oItem.FebSales = 0;
                    if (reader["MarSales"] != DBNull.Value)
                        oItem.MarSales = Convert.ToDouble(reader["MarSales"]);
                    else oItem.MarSales = 0;
                    if (reader["AprSales"] != DBNull.Value)
                        oItem.AprSales = Convert.ToDouble(reader["AprSales"]);
                    else oItem.AprSales = 0;
                    if (reader["MaySales"] != DBNull.Value)
                        oItem.MaySales = Convert.ToDouble(reader["MaySales"]);
                    else oItem.MaySales = 0;
                    if (reader["JunSales"] != DBNull.Value)
                        oItem.JunSales = Convert.ToDouble(reader["JunSales"]);
                    else oItem.JunSales = 0;
                    if (reader["JulSales"] != DBNull.Value)
                        oItem.JulSales = Convert.ToDouble(reader["JulSales"]);
                    else oItem.JulSales = 0;
                    if (reader["AugSales"] != DBNull.Value)
                        oItem.AugSales = Convert.ToDouble(reader["AugSales"]);
                    else oItem.AugSales = 0;
                    if (reader["SepSales"] != DBNull.Value)
                        oItem.SepSales = Convert.ToDouble(reader["SepSales"]);
                    else oItem.SepSales = 0;
                    if (reader["OctSales"] != DBNull.Value)
                        oItem.OctSales = Convert.ToDouble(reader["OctSales"]);
                    else oItem.OctSales = 0;
                    if (reader["NovSales"] != DBNull.Value)
                        oItem.NovSales = Convert.ToDouble(reader["NovSales"]);
                    else oItem.NovSales = 0;
                    if (reader["DecSales"] != DBNull.Value)
                        oItem.DecSales = Convert.ToDouble(reader["DecSales"]);
                    else oItem.DecSales = 0;

                    if (reader["JanColl"] != DBNull.Value)
                        oItem.JanColl = Convert.ToDouble(reader["JanColl"]);
                    else oItem.JanColl = 0;
                    if (reader["FebColl"] != DBNull.Value)
                        oItem.FebColl = Convert.ToDouble(reader["FebColl"]);
                    else oItem.FebColl = 0;
                    if (reader["MarColl"] != DBNull.Value)
                        oItem.MarColl = Convert.ToDouble(reader["MarColl"]);
                    else oItem.MarColl = 0;
                    if (reader["AprColl"] != DBNull.Value)
                        oItem.AprColl = Convert.ToDouble(reader["AprColl"]);
                    else oItem.AprColl = 0;
                    if (reader["MayColl"] != DBNull.Value)
                        oItem.MayColl = Convert.ToDouble(reader["MayColl"]);
                    else oItem.MayColl = 0;
                    if (reader["JunColl"] != DBNull.Value)
                        oItem.JunColl = Convert.ToDouble(reader["JunColl"]);
                    else oItem.JunColl = 0;
                    if (reader["JulColl"] != DBNull.Value)
                        oItem.JulColl = Convert.ToDouble(reader["JulColl"]);
                    else oItem.JulColl = 0;
                    if (reader["AugColl"] != DBNull.Value)
                        oItem.AugColl = Convert.ToDouble(reader["AugColl"]);
                    else oItem.AugColl = 0;
                    if (reader["SepColl"] != DBNull.Value)
                        oItem.SepColl = Convert.ToDouble(reader["SepColl"]);
                    else oItem.SepColl = 0;
                    if (reader["OctColl"] != DBNull.Value)
                        oItem.OctColl = Convert.ToDouble(reader["OctColl"]);
                    else oItem.OctColl = 0;
                    if (reader["NovColl"] != DBNull.Value)
                        oItem.NovColl = Convert.ToDouble(reader["NovColl"]);
                    else oItem.NovColl = 0;
                    if (reader["DecColl"] != DBNull.Value)
                        oItem.DecColl = Convert.ToDouble(reader["DecColl"]);
                    else oItem.DecColl = 0;

                     oItem.CumSalesCYR = 0;
                     oItem.CumCollCYR = 0;
                     oItem.CumSalesLYR = 0;
                     oItem.CumCollLYR = 0;
                     oItem.TotalSalesLYR = 0;
                     oItem.TotalCollLYR = 0;
                     oItem.TargetTO = 0;
                    if (reader["CurrentOS"] != DBNull.Value)
                        oItem.CurrentOS = Convert.ToDouble(reader["CurrentOS"]);
                    else oItem.CurrentOS = 0;

                    Add(oItem);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void FromDataSetParentCustomerWise(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    rptSalesVSCollection oItem = new rptSalesVSCollection();


                    oItem.SBUID = Convert.ToInt64(oRow["SBUID"]);
                    oItem.SBUCode = (string)(oRow["SBUCode"]);
                    oItem.SBUName = (string)(oRow["SBUName"]);

                    oItem.ChannelId = Convert.ToInt64(oRow["ChannelId"]);
                    oItem.ChannelCode = (string)(oRow["ChannelCode"]);
                    oItem.ChannelName = (string)(oRow["ChannelName"]);
                    oItem.CustomerTypeId = Convert.ToInt64(oRow["CustomerTypeId"]);
                    oItem.CustomerTypeCode = (string)(oRow["CustomerTypeCode"]);
                    oItem.CustomerTypeName = (string)(oRow["CustomerTypeName"]);
                    oItem.AreaId = Convert.ToInt64(oRow["AreaId"]);
                    oItem.AreaCode = (string)(oRow["AreaCode"]);
                    oItem.AreaName = (string)(oRow["AreaName"]);
                    oItem.CustomerId = Convert.ToInt64(oRow["CustomerId"]);
                    oItem.CustomerCode = (string)(oRow["CustomerCode"]);
                    oItem.CustomerName = (string)(oRow["CustomerName"]);
                    oItem.IsActive = Convert.ToInt16(oRow["IsActive"]);
                    oItem.ParentCustomerID = Convert.ToInt64(oRow["ParentCustomerID"]);
                    oItem.ParentCustomerCode = (string)(oRow["ParentCustomerCode"]);
                    oItem.ParentCustomerName = (string)(oRow["ParentCustomerName"]);
                    oItem.TerritoryId = Convert.ToInt64(oRow["TerritoryId"]);
                    oItem.TerritoryCode = (string)(oRow["TerritoryCode"]);
                    oItem.TerritoryName = (string)(oRow["TerritoryName"]);

                    oItem.JanSales = Convert.ToDouble(oRow["JanSales"]);
                    oItem.FebSales = Convert.ToDouble(oRow["FebSales"]);
                    oItem.MarSales = Convert.ToDouble(oRow["MarSales"]);
                    oItem.AprSales = Convert.ToDouble(oRow["AprSales"]);
                    oItem.MaySales = Convert.ToDouble(oRow["MaySales"]);
                    oItem.JunSales = Convert.ToDouble(oRow["JunSales"]);
                    oItem.JulSales = Convert.ToDouble(oRow["JulSales"]);
                    oItem.AugSales = Convert.ToDouble(oRow["AugSales"]);
                    oItem.SepSales = Convert.ToDouble(oRow["SepSales"]);
                    oItem.OctSales = Convert.ToDouble(oRow["OctSales"]);
                    oItem.NovSales = Convert.ToDouble(oRow["NovSales"]);
                    oItem.DecSales = Convert.ToDouble(oRow["DecSales"]);

                    oItem.JanColl = Convert.ToDouble(oRow["JanColl"]);
                    oItem.FebColl = Convert.ToDouble(oRow["FebColl"]);
                    oItem.MarColl = Convert.ToDouble(oRow["MarColl"]);
                    oItem.AprColl = Convert.ToDouble(oRow["AprColl"]);
                    oItem.MayColl = Convert.ToDouble(oRow["MayColl"]);
                    oItem.JunColl = Convert.ToDouble(oRow["JunColl"]);
                    oItem.JulColl = Convert.ToDouble(oRow["JulColl"]);
                    oItem.AugColl = Convert.ToDouble(oRow["AugColl"]);
                    oItem.SepColl = Convert.ToDouble(oRow["SepColl"]);
                    oItem.OctColl = Convert.ToDouble(oRow["OctColl"]);
                    oItem.NovColl = Convert.ToDouble(oRow["NovColl"]);
                    oItem.DecColl = Convert.ToDouble(oRow["DecColl"]);

                    oItem.CumSalesCYR = Convert.ToDouble(oRow["CumSalesCYR"]);
                    oItem.CumCollCYR = Convert.ToDouble(oRow["CumCollCYR"]);
                    oItem.CumSalesLYR = Convert.ToDouble(oRow["CumSalesLYR"]);
                    oItem.CumCollLYR = Convert.ToDouble(oRow["CumCollLYR"]);
                    oItem.TotalSalesLYR = Convert.ToDouble(oRow["TotalSalesLYR"]);
                    oItem.TotalCollLYR = Convert.ToDouble(oRow["TotalCollLYR"]);
                    oItem.TargetTO = Convert.ToDouble(oRow["TargetTO"]);
                    oItem.CurrentOS = Convert.ToDouble(oRow["CurrentOS"]);

                    InnerList.Add(oItem);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Sales VS Collection Report SBU wise
        /// </summary>
        /// <param name="dCFromDate"></param>
        /// <param name="dCToDate"></param>
        /// <param name="dLFromDate"></param>
        /// <param name="dLToDate"></param>
        public void GetMonthlySalesVsCollectionSBUWise(DateTime dCYFromDate, DateTime dCYToDate, DateTime dLYCFromDate, DateTime dLYCToDate, DateTime dLYFromDate, DateTime dLYToDate, DateTime dFromDate, DateTime dToDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();
            sQueryStringMaster.Append(" Select qqq1.*  ");
            sQueryStringMaster.Append(",Isnull(qqq2.MonthlyTargetAmt,0) as TargetTO  ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("( ");

            sQueryStringMaster.Append("Select p.SBUID, p.SBUCode, p.SBUName   ");
            sQueryStringMaster.Append(",sum(isnull(JanSales,0))as JanSales, sum(isnull(FebSales,0))as FebSales, sum(isnull(MarSales,0))as MarSales  ");
            sQueryStringMaster.Append(",sum(isnull(AprSales,0))as AprSales, sum(isnull(MaySales,0))as MaySales, sum(isnull(JunSales,0))as JunSales  ");
            sQueryStringMaster.Append(",sum(isnull(JulSales,0))as JulSales, sum(isnull(AugSales,0))as AugSales, sum(isnull(SepSales,0))as SepSales  ");
            sQueryStringMaster.Append(",sum(isnull(OctSales,0))as OctSales, sum(isnull(NovSales,0))as NovSales, sum(isnull(DecSales,0))as DecSales  ");
            sQueryStringMaster.Append(",sum(isnull(JanColl,0))as JanColl, sum(isnull(FebColl,0))as FebColl, sum(isnull(MarColl,0))as MarColl  ");
            sQueryStringMaster.Append(",sum(isnull(AprColl,0))as AprColl, sum(isnull(MayColl,0))as MayColl, sum(isnull(JunColl,0))as JunColl  ");
            sQueryStringMaster.Append(",sum(isnull(JulColl,0))as JulColl, sum(isnull(AugColl,0))as AugColl, sum(isnull(SepColl,0))as SepColl  ");
            sQueryStringMaster.Append(",sum(isnull(OctColl,0))as OctColl, sum(isnull(NovColl,0))as NovColl, sum(isnull(DecColl,0))as DecColl  ");
            sQueryStringMaster.Append(",sum(isnull(CumSalesCYR,0))as CumSalesCYR,sum(isnull(CumCollCYR,0))as CumCollCYR ");
            sQueryStringMaster.Append(",sum(isnull(CumSalesLYR,0))as CumSalesLYR,sum(isnull(CumCollLYR,0))as CumCollLYR ");
            sQueryStringMaster.Append(",sum(isnull(TotalSalesLYR,0))as TotalSalesLYR,sum(isnull(TotalCollLYR,0))as TotalCollLYR ");
            sQueryStringMaster.Append(",sum(isnull(p11.currentOS,0))as CurrentOS  ");
            sQueryStringMaster.Append("from   ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select * from v_customerDetails   ");
            sQueryStringMaster.Append(")as p   ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select p.CustomerID  ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRJanCYR) - abs(sum(p2.DbJanCYR)),0) as JanSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRFebCYR) - abs(sum(p2.DbFebCYR)),0) as FebSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRMarCYR) - abs(sum(p2.DbMarCYR)),0) as MarSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRAprCYR) - abs(sum(p2.DbAprCYR)),0) as AprSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRMayCYR) - abs(sum(p2.DbMayCYR)),0) as MaySales  ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRJunCYR) - abs(sum(p2.DbJunCYR)),0) as JunSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRJulCYR) - abs(sum(p2.DbJulCYR)),0) as JulSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRAugCYR) - abs(sum(p2.DbAugCYR)),0) as AugSales  ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRSepCYR) - abs(sum(p2.DbSepCYR)),0) as SepSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CROctCYR) - abs(sum(p2.DbOctCYR)),0) as OctSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRNovCYR) - abs(sum(p2.DbNovCYR)),0) as NovSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRDcmCYR) - abs(sum(p2.DbDcmCYR)),0) as DecSales  ");
            sQueryStringMaster.Append("from   ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select * from t_customer    ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as p  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 1 then InvoiceAmount else 0 end) as CRJanCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 2 then InvoiceAmount else 0 end) as CRFebCYR,   ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 3 then InvoiceAmount else 0 end) as CRMarCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 4 then InvoiceAmount else 0 end) as CRAprCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 5 then InvoiceAmount else 0 end) as CRMayCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 6 then InvoiceAmount else 0 end) as CRJunCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 7 then InvoiceAmount else 0 end) as CRJulCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 8 then InvoiceAmount else 0 end) as CRAugCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 9 then InvoiceAmount else 0 end) as CRSepCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 10 then InvoiceAmount else 0 end) as CROctCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 11 then InvoiceAmount else 0 end) as CRNovCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 12 then InvoiceAmount else 0 end) as CRDcmCYR,  ");
            sQueryStringMaster.Append("0 as DbJanCYR, 0 as DbFebCYR, 0 as DbMarCYR, 0 as DbAprCYR, 0 as DbMayCYR, 0 as DbJunCYR,  ");
            sQueryStringMaster.Append("0 as DbJulCYR, 0 as DbAugCYR, 0 as DbSepCYR, 0 as DbOctCYR, 0 as DbNovCYR, 0 as DbDcmCYR  ");
            sQueryStringMaster.Append("from t_salesInvoice im,  t_customer cd  ");
            sQueryStringMaster.Append("where  im.CustomerID = cd.CustomerID and  ");
            sQueryStringMaster.Append("invoicedate between ? and ? and invoicedate< ? and invoicetypeid in (?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("group by  im.CustomerID  ");
            sQueryStringMaster.Append("union all   ");
            sQueryStringMaster.Append("select im.CustomerID,  ");
            sQueryStringMaster.Append("0 as CRJanCYR, 0 as CRFebCYR, 0 as CRMarCYR, 0 as CRAprCYR, 0 as CRMayCYR, 0 as CRJunCYR,  ");
            sQueryStringMaster.Append("0 as CRJulCYR, 0 as CRAugCYR, 0 as CRSepCYR, 0 as CROctCYR, 0 as CRNovCYR, 0 as CRDcmCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 1 then InvoiceAmount else 0 end) as DbJanCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 2 then InvoiceAmount else 0 end) as DbFebCYR,   ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 3 then InvoiceAmount else 0 end) as DbMarCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 4 then InvoiceAmount else 0 end) as DbAprCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 5 then InvoiceAmount else 0 end) as DbMayCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 6 then InvoiceAmount else 0 end) as DbJunCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 7 then InvoiceAmount else 0 end) as DbJulCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 8 then InvoiceAmount else 0 end) as DbAugCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 9 then InvoiceAmount else 0 end) as DbSepCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 10 then InvoiceAmount else 0 end) as DbOctCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 11 then InvoiceAmount else 0 end) as DbNovCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 12 then InvoiceAmount else 0 end) as DbDcmCYR  ");
            sQueryStringMaster.Append("from t_salesInvoice im,  t_customer cd  ");
            sQueryStringMaster.Append("where  im.CustomerID = cd.CustomerID and  ");
            sQueryStringMaster.Append("invoicedate between ? and ? and invoicedate< ? and invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("group by  im.CustomerID  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as p2 on p.CustomerID = p2.CustomerID  ");
            sQueryStringMaster.Append("group by p.customerid  ");
            sQueryStringMaster.Append(")as p2 on p.CustomerID = p2.CustomerID   ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select q1.customerid  ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountJan,0) - isnull(q5.DebitAmountJan,0)) as JanColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountFeb,0) - isnull(q5.DebitAmountFeb,0)) as FebColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountMar,0) - isnull(q5.DebitAmountMar,0)) as MarColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountApr,0) - isnull(q5.DebitAmountApr,0)) as AprColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountMay,0) - isnull(q5.DebitAmountMay,0)) as MayColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountJun,0) - isnull(q5.DebitAmountJun,0)) as JunColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountJul,0) - isnull(q5.DebitAmountJul,0)) as JulColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountAug,0) - isnull(q5.DebitAmountAug,0)) as AugColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountSep,0) - isnull(q5.DebitAmountSep,0)) as SepColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountOct,0) - isnull(q5.DebitAmountOct,0)) as OctColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountNov,0) - isnull(q5.DebitAmountNov,0)) as NovColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountDec,0) - isnull(q5.DebitAmountDec,0)) as DecColl   ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q1  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 1 then Amount else 0 end) as CreditAmountJan  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 2 then Amount else 0 end) as CreditAmountFeb  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 3 then Amount else 0 end) as CreditAmountMar  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 4 then Amount else 0 end) as CreditAmountApr  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 5 then Amount else 0 end) as CreditAmountMay  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 6 then Amount else 0 end) as CreditAmountJun  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 7 then Amount else 0 end) as CreditAmountJul  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 8 then Amount else 0 end) as CreditAmountAug  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 9 then Amount else 0 end) as CreditAmountSep  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 10 then Amount else 0 end) as CreditAmountOct  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 11 then Amount else 0 end) as CreditAmountNov  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 12 then Amount else 0 end) as CreditAmountDec  ");
            sQueryStringMaster.Append("from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.TranDate < ?   ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q4  ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 1 then Amount else 0 end) as DebitAmountJan  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 2 then Amount else 0 end) as DebitAmountFeb  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 3 then Amount else 0 end) as DebitAmountMar  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 4 then Amount else 0 end) as DebitAmountApr  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 5 then Amount else 0 end) as DebitAmountMay  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 6 then Amount else 0 end) as DebitAmountJun  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 7 then Amount else 0 end) as DebitAmountJul  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 8 then Amount else 0 end) as DebitAmountAug  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 9 then Amount else 0 end) as DebitAmountSep  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 10 then Amount else 0 end) as DebitAmountOct  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 11 then Amount else 0 end) as DebitAmountNov  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 12 then Amount else 0 end) as DebitAmountDec  ");
            sQueryStringMaster.Append("from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.TranDate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q5  ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as p3  ");
            sQueryStringMaster.Append("on p.Customerid = p3.Customerid   ");

            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as CumSalesCYR     ");
            sQueryStringMaster.Append("From    ");
            sQueryStringMaster.Append("(    ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount    ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)    ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append("union all    ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount,sum(invoiceamount)as drSalesAmount   ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?)   ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append(")as qq1    ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(") as p4  ");
            sQueryStringMaster.Append("on p.Customerid = p4.Customerid  ");
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ( isnull(q4.CreditAmount,0) - isnull(q5.DebitAmount,0)) as CumCollCYR   ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q1  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q4  ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?)  and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q5  ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid  ");
            sQueryStringMaster.Append(")as p5  ");
            sQueryStringMaster.Append("on p.Customerid = p5.Customerid  ");

            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as CumSalesLYR     ");
            sQueryStringMaster.Append("From    ");
            sQueryStringMaster.Append("(    ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount    ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)    ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append("union all    ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount,sum(invoiceamount)as drSalesAmount   ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?)   ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append(")as qq1    ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(") as p8  ");
            sQueryStringMaster.Append("on p.Customerid = p8.Customerid  ");
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ( isnull(q4.CreditAmount,0) - isnull(q5.DebitAmount,0)) as CumCollLYR   ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q1  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q4  ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?)  and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q5  ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid  ");
            sQueryStringMaster.Append(")as p7  ");
            sQueryStringMaster.Append("on p.Customerid = p7.Customerid  ");
            ////////////////////////////
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as TotalSalesLYR     ");
            sQueryStringMaster.Append("From    ");
            sQueryStringMaster.Append("(    ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount    ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)    ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append("union all    ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount,sum(invoiceamount)as drSalesAmount   ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?)   ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append(")as qq1    ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(") as p9  ");
            sQueryStringMaster.Append("on p.Customerid = p9.Customerid  ");
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ( isnull(q4.CreditAmount,0) - isnull(q5.DebitAmount,0)) as TotalCollLYR   ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q1  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q4  ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?)  and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q5  ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid  ");
            sQueryStringMaster.Append(")as p10  ");
            sQueryStringMaster.Append("on p.Customerid = p10.Customerid  ");

            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ((q1.CurrentBalance - isnull(q2.CreditAmount,0) ) + isnull(q3.DebitAmount,0)) as CurrentOS  ");
            sQueryStringMaster.Append("from   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount   ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q1   ");
            sQueryStringMaster.Append("left outer join   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt    ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and transide = ? and ct.TranDate between ? and ? and TranDate < ?  ");
            sQueryStringMaster.Append("group by customerid   ");
            sQueryStringMaster.Append(")    ");
            sQueryStringMaster.Append("as q2   ");
            sQueryStringMaster.Append("on q1.customerid = q2.customerid   ");
            sQueryStringMaster.Append("left outer join   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt    ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and transide = ?  and ct.TranDate between ? and ? and TranDate < ?  ");
            sQueryStringMaster.Append("group by customerid   ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q3   ");
            sQueryStringMaster.Append("on q1.customerid = q3.customerid   ");
            sQueryStringMaster.Append(")as p11  ");
            sQueryStringMaster.Append("on p.customerid = p11.customerid   ");
            //////////////////////////////
            sQueryStringMaster.Append("group by   ");
            sQueryStringMaster.Append("p.SBUID, p.SBUCode, p.SBUName   ");
            sQueryStringMaster.Append(") as qqq1 ");
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select SBUID, sum(Turnover)as MonthlyTargetAmt ");
            sQueryStringMaster.Append("From t_PlanBudgetTarget   ");
            sQueryStringMaster.Append("Where plantype in (?) and periodtype in (?)    ");
            sQueryStringMaster.Append("and perioddate between ? and ? ");
            sQueryStringMaster.Append("Group By SBUID ");
            sQueryStringMaster.Append(")as qqq2 ");
            sQueryStringMaster.Append("on qqq1.SBUID = qqq2.SBUID  ");


            //Command time out
            cmd.CommandTimeout = 0;
            cmd.CommandText = sQueryStringMaster.ToString();

            cmd.Parameters.AddWithValue("InvoiceDate", dCYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", dCYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);


            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dCYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));



            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dCYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));


            cmd.Parameters.AddWithValue("InvoiceDate", dCYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", dCYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dCYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));



            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dCYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));

            cmd.Parameters.AddWithValue("InvoiceDate", dLYCFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dLYCToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dLYCToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", dLYCFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dLYCToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dLYCToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dLYCFromDate);
            cmd.Parameters.AddWithValue("TranDate", dLYCToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dLYCToDate.AddDays(1));



            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dLYCFromDate);
            cmd.Parameters.AddWithValue("TranDate", dLYCToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dLYCToDate.AddDays(1));

            cmd.Parameters.AddWithValue("InvoiceDate", dLYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dLYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dLYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", dLYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dLYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dLYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dLYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dLYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dLYToDate.AddDays(1));


            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dLYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dLYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dLYToDate.AddDays(1));

            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionSide.CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dFromDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dToDate.AddDays(1));

            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionSide.DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dFromDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dToDate.AddDays(1));

            cmd.Parameters.AddWithValue("PlanType", (short)Dictionary.PlanType.Target);
            cmd.Parameters.AddWithValue("PeriodType", (short)Dictionary.PeriodType.Monthly);
            cmd.Parameters.AddWithValue("PeriodDate", dCYFromDate);
            cmd.Parameters.AddWithValue("PeriodDate", dCYToDate.AddDays(1));




            GetMonthlySalesVsCollectionSBUWiseData(cmd);
        }
        private void GetMonthlySalesVsCollectionSBUWiseData(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptSalesVSCollection oItem = new rptSalesVSCollection();

                    if (reader["SBUID"] != DBNull.Value)
                        oItem.SBUID = Convert.ToInt64(reader["SBUID"]);
                    else oItem.SBUID = -1;
                    if (reader["SBUCode"] != DBNull.Value)
                        oItem.SBUCode = (string)(reader["SBUCode"]);
                    else oItem.SBUCode = "";
                    if (reader["SBUName"] != DBNull.Value)
                        oItem.SBUName = (string)(reader["SBUName"]);
                    else oItem.SBUName = "";

                   oItem.ChannelId = -1;
                   oItem.ChannelCode = "";
                   oItem.ChannelName = "";

                    oItem.CustomerTypeId = -1;
                    oItem.CustomerTypeCode = "";
                    oItem.CustomerTypeName = "";

                    oItem.AreaId = -1;
                    oItem.AreaCode = "";
                    oItem.AreaName = "";
                    oItem.CustomerId = -1;
                    oItem.CustomerCode = "";
                    oItem.CustomerName = "";
                    oItem.IsActive = 1;

                    oItem.ParentCustomerID = -1;
                    oItem.ParentCustomerCode = "";
                    oItem.ParentCustomerName = "";
                    oItem.TerritoryId = -1;
                    oItem.TerritoryCode = "";
                    oItem.TerritoryName = "";

                    if (reader["JanSales"] != DBNull.Value)
                        oItem.JanSales = Convert.ToDouble(reader["JanSales"]);
                    else oItem.JanSales = 0;
                    if (reader["FebSales"] != DBNull.Value)
                        oItem.FebSales = Convert.ToDouble(reader["FebSales"]);
                    else oItem.FebSales = 0;
                    if (reader["MarSales"] != DBNull.Value)
                        oItem.MarSales = Convert.ToDouble(reader["MarSales"]);
                    else oItem.MarSales = 0;
                    if (reader["AprSales"] != DBNull.Value)
                        oItem.AprSales = Convert.ToDouble(reader["AprSales"]);
                    else oItem.AprSales = 0;
                    if (reader["MaySales"] != DBNull.Value)
                        oItem.MaySales = Convert.ToDouble(reader["MaySales"]);
                    else oItem.MaySales = 0;
                    if (reader["JunSales"] != DBNull.Value)
                        oItem.JunSales = Convert.ToDouble(reader["JunSales"]);
                    else oItem.JunSales = 0;
                    if (reader["JulSales"] != DBNull.Value)
                        oItem.JulSales = Convert.ToDouble(reader["JulSales"]);
                    else oItem.JulSales = 0;
                    if (reader["AugSales"] != DBNull.Value)
                        oItem.AugSales = Convert.ToDouble(reader["AugSales"]);
                    else oItem.AugSales = 0;
                    if (reader["SepSales"] != DBNull.Value)
                        oItem.SepSales = Convert.ToDouble(reader["SepSales"]);
                    else oItem.SepSales = 0;
                    if (reader["OctSales"] != DBNull.Value)
                        oItem.OctSales = Convert.ToDouble(reader["OctSales"]);
                    else oItem.OctSales = 0;
                    if (reader["NovSales"] != DBNull.Value)
                        oItem.NovSales = Convert.ToDouble(reader["NovSales"]);
                    else oItem.NovSales = 0;
                    if (reader["DecSales"] != DBNull.Value)
                        oItem.DecSales = Convert.ToDouble(reader["DecSales"]);
                    else oItem.DecSales = 0;

                    if (reader["JanColl"] != DBNull.Value)
                        oItem.JanColl = Convert.ToDouble(reader["JanColl"]);
                    else oItem.JanColl = 0;
                    if (reader["FebColl"] != DBNull.Value)
                        oItem.FebColl = Convert.ToDouble(reader["FebColl"]);
                    else oItem.FebColl = 0;
                    if (reader["MarColl"] != DBNull.Value)
                        oItem.MarColl = Convert.ToDouble(reader["MarColl"]);
                    else oItem.MarColl = 0;
                    if (reader["AprColl"] != DBNull.Value)
                        oItem.AprColl = Convert.ToDouble(reader["AprColl"]);
                    else oItem.AprColl = 0;
                    if (reader["MayColl"] != DBNull.Value)
                        oItem.MayColl = Convert.ToDouble(reader["MayColl"]);
                    else oItem.MayColl = 0;
                    if (reader["JunColl"] != DBNull.Value)
                        oItem.JunColl = Convert.ToDouble(reader["JunColl"]);
                    else oItem.JunColl = 0;
                    if (reader["JulColl"] != DBNull.Value)
                        oItem.JulColl = Convert.ToDouble(reader["JulColl"]);
                    else oItem.JulColl = 0;
                    if (reader["AugColl"] != DBNull.Value)
                        oItem.AugColl = Convert.ToDouble(reader["AugColl"]);
                    else oItem.AugColl = 0;
                    if (reader["SepColl"] != DBNull.Value)
                        oItem.SepColl = Convert.ToDouble(reader["SepColl"]);
                    else oItem.SepColl = 0;
                    if (reader["OctColl"] != DBNull.Value)
                        oItem.OctColl = Convert.ToDouble(reader["OctColl"]);
                    else oItem.OctColl = 0;
                    if (reader["NovColl"] != DBNull.Value)
                        oItem.NovColl = Convert.ToDouble(reader["NovColl"]);
                    else oItem.NovColl = 0;
                    if (reader["DecColl"] != DBNull.Value)
                        oItem.DecColl = Convert.ToDouble(reader["DecColl"]);
                    else oItem.DecColl = 0;

                    if (reader["CumSalesCYR"] != DBNull.Value)
                        oItem.CumSalesCYR = Convert.ToDouble(reader["CumSalesCYR"]);
                    else oItem.CumSalesCYR = 0;
                    if (reader["CumCollCYR"] != DBNull.Value)
                        oItem.CumCollCYR = Convert.ToDouble(reader["CumCollCYR"]);
                    else oItem.CumCollCYR = 0;
                    if (reader["CumSalesLYR"] != DBNull.Value)
                        oItem.CumSalesLYR = Convert.ToDouble(reader["CumSalesLYR"]);
                    else oItem.CumSalesLYR = 0;
                    if (reader["CumCollLYR"] != DBNull.Value)
                        oItem.CumCollLYR = Convert.ToDouble(reader["CumCollLYR"]);
                    else oItem.CumCollLYR = 0;
                    if (reader["TotalSalesLYR"] != DBNull.Value)
                        oItem.TotalSalesLYR = Convert.ToDouble(reader["TotalSalesLYR"]);
                    else oItem.TotalSalesLYR = 0;
                    if (reader["TotalCollLYR"] != DBNull.Value)
                        oItem.TotalCollLYR = Convert.ToDouble(reader["TotalCollLYR"]);
                    else oItem.TotalCollLYR = 0;
                    if (reader["TargetTO"] != DBNull.Value)
                        oItem.TargetTO = Convert.ToDouble(reader["TargetTO"]);
                    else oItem.TargetTO = 0;
                    if (reader["CurrentOS"] != DBNull.Value)
                        oItem.CurrentOS = Convert.ToDouble(reader["CurrentOS"]);
                    else oItem.CurrentOS = 0;


                    Add(oItem);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void FromDataSetSBUWise(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    rptSalesVSCollection oItem = new rptSalesVSCollection();


                    oItem.SBUID = Convert.ToInt64(oRow["SBUID"]);
                    oItem.SBUCode = (string)(oRow["SBUCode"]);
                    oItem.SBUName = (string)(oRow["SBUName"]);

                    oItem.ChannelId = Convert.ToInt64(oRow["ChannelId"]);
                    oItem.ChannelCode = (string)(oRow["ChannelCode"]);
                    oItem.ChannelName = (string)(oRow["ChannelName"]);
                    oItem.CustomerTypeId = Convert.ToInt64(oRow["CustomerTypeId"]);
                    oItem.CustomerTypeCode = (string)(oRow["CustomerTypeCode"]);
                    oItem.CustomerTypeName = (string)(oRow["CustomerTypeName"]);
                    oItem.AreaId = Convert.ToInt64(oRow["AreaId"]);
                    oItem.AreaCode = (string)(oRow["AreaCode"]);
                    oItem.AreaName = (string)(oRow["AreaName"]);
                    oItem.CustomerId = Convert.ToInt64(oRow["CustomerId"]);
                    oItem.CustomerCode = (string)(oRow["CustomerCode"]);
                    oItem.CustomerName = (string)(oRow["CustomerName"]);
                    oItem.IsActive = Convert.ToInt16(oRow["IsActive"]);
                    oItem.ParentCustomerID = Convert.ToInt64(oRow["ParentCustomerID"]);
                    oItem.ParentCustomerCode = (string)(oRow["ParentCustomerCode"]);
                    oItem.ParentCustomerName = (string)(oRow["ParentCustomerName"]);
                    oItem.TerritoryId = Convert.ToInt64(oRow["TerritoryId"]);
                    oItem.TerritoryCode = (string)(oRow["TerritoryCode"]);
                    oItem.TerritoryName = (string)(oRow["TerritoryName"]);

                    oItem.JanSales = Convert.ToDouble(oRow["JanSales"]);
                    oItem.FebSales = Convert.ToDouble(oRow["FebSales"]);
                    oItem.MarSales = Convert.ToDouble(oRow["MarSales"]);
                    oItem.AprSales = Convert.ToDouble(oRow["AprSales"]);
                    oItem.MaySales = Convert.ToDouble(oRow["MaySales"]);
                    oItem.JunSales = Convert.ToDouble(oRow["JunSales"]);
                    oItem.JulSales = Convert.ToDouble(oRow["JulSales"]);
                    oItem.AugSales = Convert.ToDouble(oRow["AugSales"]);
                    oItem.SepSales = Convert.ToDouble(oRow["SepSales"]);
                    oItem.OctSales = Convert.ToDouble(oRow["OctSales"]);
                    oItem.NovSales = Convert.ToDouble(oRow["NovSales"]);
                    oItem.DecSales = Convert.ToDouble(oRow["DecSales"]);

                    oItem.JanColl = Convert.ToDouble(oRow["JanColl"]);
                    oItem.FebColl = Convert.ToDouble(oRow["FebColl"]);
                    oItem.MarColl = Convert.ToDouble(oRow["MarColl"]);
                    oItem.AprColl = Convert.ToDouble(oRow["AprColl"]);
                    oItem.MayColl = Convert.ToDouble(oRow["MayColl"]);
                    oItem.JunColl = Convert.ToDouble(oRow["JunColl"]);
                    oItem.JulColl = Convert.ToDouble(oRow["JulColl"]);
                    oItem.AugColl = Convert.ToDouble(oRow["AugColl"]);
                    oItem.SepColl = Convert.ToDouble(oRow["SepColl"]);
                    oItem.OctColl = Convert.ToDouble(oRow["OctColl"]);
                    oItem.NovColl = Convert.ToDouble(oRow["NovColl"]);
                    oItem.DecColl = Convert.ToDouble(oRow["DecColl"]);

                    oItem.CumSalesCYR = Convert.ToDouble(oRow["CumSalesCYR"]);
                    oItem.CumCollCYR = Convert.ToDouble(oRow["CumCollCYR"]);
                    oItem.CumSalesLYR = Convert.ToDouble(oRow["CumSalesLYR"]);
                    oItem.CumCollLYR = Convert.ToDouble(oRow["CumCollLYR"]);
                    oItem.TotalSalesLYR = Convert.ToDouble(oRow["TotalSalesLYR"]);
                    oItem.TotalCollLYR = Convert.ToDouble(oRow["TotalCollLYR"]);
                    oItem.TargetTO = Convert.ToDouble(oRow["TargetTO"]);
                    oItem.CurrentOS = Convert.ToDouble(oRow["CurrentOS"]);

                    InnerList.Add(oItem);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Sales VS Collection Report Channel wise
        /// </summary>
        /// <param name="dCFromDate"></param>
        /// <param name="dCToDate"></param>
        /// <param name="dLFromDate"></param>
        /// <param name="dLToDate"></param>
        public void GetMonthlySalesVsCollectionChannelWise(DateTime dCYFromDate, DateTime dCYToDate, DateTime dLYCFromDate, DateTime dLYCToDate, DateTime dLYFromDate, DateTime dLYToDate, DateTime dFromDate, DateTime dToDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();
            sQueryStringMaster.Append("Select p.SBUID, p.SBUCode, p.SBUName   ");
            sQueryStringMaster.Append(",p.ChannelID, p.ChannelCode, p.Channeldescription as ChannelName  ");
            sQueryStringMaster.Append(",sum(isnull(JanSales,0))as JanSales, sum(isnull(FebSales,0))as FebSales, sum(isnull(MarSales,0))as MarSales  ");
            sQueryStringMaster.Append(",sum(isnull(AprSales,0))as AprSales, sum(isnull(MaySales,0))as MaySales, sum(isnull(JunSales,0))as JunSales  ");
            sQueryStringMaster.Append(",sum(isnull(JulSales,0))as JulSales, sum(isnull(AugSales,0))as AugSales, sum(isnull(SepSales,0))as SepSales  ");
            sQueryStringMaster.Append(",sum(isnull(OctSales,0))as OctSales, sum(isnull(NovSales,0))as NovSales, sum(isnull(DecSales,0))as DecSales  ");
            sQueryStringMaster.Append(",sum(isnull(JanColl,0))as JanColl, sum(isnull(FebColl,0))as FebColl, sum(isnull(MarColl,0))as MarColl  ");
            sQueryStringMaster.Append(",sum(isnull(AprColl,0))as AprColl, sum(isnull(MayColl,0))as MayColl, sum(isnull(JunColl,0))as JunColl  ");
            sQueryStringMaster.Append(",sum(isnull(JulColl,0))as JulColl, sum(isnull(AugColl,0))as AugColl, sum(isnull(SepColl,0))as SepColl  ");
            sQueryStringMaster.Append(",sum(isnull(OctColl,0))as OctColl, sum(isnull(NovColl,0))as NovColl, sum(isnull(DecColl,0))as DecColl  ");
            sQueryStringMaster.Append(",sum(isnull(CumSalesCYR,0))as CumSalesCYR,sum(isnull(CumCollCYR,0))as CumCollCYR ");
            sQueryStringMaster.Append(",sum(isnull(CumSalesLYR,0))as CumSalesLYR,sum(isnull(CumCollLYR,0))as CumCollLYR ");
            sQueryStringMaster.Append(",sum(isnull(TotalSalesLYR,0))as TotalSalesLYR,sum(isnull(TotalCollLYR,0))as TotalCollLYR ");
            sQueryStringMaster.Append(",sum(isnull(p11.currentOS,0))as CurrentOS, sum(isnull(MonthlyTargetAmt,0)) as TargetTO ");
            sQueryStringMaster.Append("from   ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select * from v_customerDetails    ");
            sQueryStringMaster.Append(")as p   ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select p.CustomerID  ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRJanCYR) - abs(sum(p2.DbJanCYR)),0) as JanSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRFebCYR) - abs(sum(p2.DbFebCYR)),0) as FebSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRMarCYR) - abs(sum(p2.DbMarCYR)),0) as MarSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRAprCYR) - abs(sum(p2.DbAprCYR)),0) as AprSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRMayCYR) - abs(sum(p2.DbMayCYR)),0) as MaySales  ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRJunCYR) - abs(sum(p2.DbJunCYR)),0) as JunSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRJulCYR) - abs(sum(p2.DbJulCYR)),0) as JulSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRAugCYR) - abs(sum(p2.DbAugCYR)),0) as AugSales  ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRSepCYR) - abs(sum(p2.DbSepCYR)),0) as SepSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CROctCYR) - abs(sum(p2.DbOctCYR)),0) as OctSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRNovCYR) - abs(sum(p2.DbNovCYR)),0) as NovSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRDcmCYR) - abs(sum(p2.DbDcmCYR)),0) as DecSales  ");
            sQueryStringMaster.Append("from   ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select * from t_customer    ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as p  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 1 then InvoiceAmount else 0 end) as CRJanCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 2 then InvoiceAmount else 0 end) as CRFebCYR,   ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 3 then InvoiceAmount else 0 end) as CRMarCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 4 then InvoiceAmount else 0 end) as CRAprCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 5 then InvoiceAmount else 0 end) as CRMayCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 6 then InvoiceAmount else 0 end) as CRJunCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 7 then InvoiceAmount else 0 end) as CRJulCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 8 then InvoiceAmount else 0 end) as CRAugCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 9 then InvoiceAmount else 0 end) as CRSepCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 10 then InvoiceAmount else 0 end) as CROctCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 11 then InvoiceAmount else 0 end) as CRNovCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 12 then InvoiceAmount else 0 end) as CRDcmCYR,  ");
            sQueryStringMaster.Append("0 as DbJanCYR, 0 as DbFebCYR, 0 as DbMarCYR, 0 as DbAprCYR, 0 as DbMayCYR, 0 as DbJunCYR,  ");
            sQueryStringMaster.Append("0 as DbJulCYR, 0 as DbAugCYR, 0 as DbSepCYR, 0 as DbOctCYR, 0 as DbNovCYR, 0 as DbDcmCYR  ");
            sQueryStringMaster.Append("from t_salesInvoice im,  t_customer cd  ");
            sQueryStringMaster.Append("where  im.CustomerID = cd.CustomerID and  ");
            sQueryStringMaster.Append("invoicedate between ? and ? and invoicedate< ? and invoicetypeid in (?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("group by  im.CustomerID  ");
            sQueryStringMaster.Append("union all   ");
            sQueryStringMaster.Append("select im.CustomerID,  ");
            sQueryStringMaster.Append("0 as CRJanCYR, 0 as CRFebCYR, 0 as CRMarCYR, 0 as CRAprCYR, 0 as CRMayCYR, 0 as CRJunCYR,  ");
            sQueryStringMaster.Append("0 as CRJulCYR, 0 as CRAugCYR, 0 as CRSepCYR, 0 as CROctCYR, 0 as CRNovCYR, 0 as CRDcmCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 1 then InvoiceAmount else 0 end) as DbJanCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 2 then InvoiceAmount else 0 end) as DbFebCYR,   ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 3 then InvoiceAmount else 0 end) as DbMarCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 4 then InvoiceAmount else 0 end) as DbAprCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 5 then InvoiceAmount else 0 end) as DbMayCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 6 then InvoiceAmount else 0 end) as DbJunCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 7 then InvoiceAmount else 0 end) as DbJulCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 8 then InvoiceAmount else 0 end) as DbAugCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 9 then InvoiceAmount else 0 end) as DbSepCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 10 then InvoiceAmount else 0 end) as DbOctCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 11 then InvoiceAmount else 0 end) as DbNovCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 12 then InvoiceAmount else 0 end) as DbDcmCYR  ");
            sQueryStringMaster.Append("from t_salesInvoice im,  t_customer cd  ");
            sQueryStringMaster.Append("where  im.CustomerID = cd.CustomerID and  ");
            sQueryStringMaster.Append("invoicedate between ? and ? and invoicedate< ? and invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("group by  im.CustomerID  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as p2 on p.CustomerID = p2.CustomerID  ");
            sQueryStringMaster.Append("group by p.customerid  ");
            sQueryStringMaster.Append(")as p2 on p.CustomerID = p2.CustomerID   ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select q1.customerid  ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountJan,0) - isnull(q5.DebitAmountJan,0)) as JanColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountFeb,0) - isnull(q5.DebitAmountFeb,0)) as FebColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountMar,0) - isnull(q5.DebitAmountMar,0)) as MarColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountApr,0) - isnull(q5.DebitAmountApr,0)) as AprColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountMay,0) - isnull(q5.DebitAmountMay,0)) as MayColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountJun,0) - isnull(q5.DebitAmountJun,0)) as JunColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountJul,0) - isnull(q5.DebitAmountJul,0)) as JulColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountAug,0) - isnull(q5.DebitAmountAug,0)) as AugColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountSep,0) - isnull(q5.DebitAmountSep,0)) as SepColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountOct,0) - isnull(q5.DebitAmountOct,0)) as OctColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountNov,0) - isnull(q5.DebitAmountNov,0)) as NovColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountDec,0) - isnull(q5.DebitAmountDec,0)) as DecColl   ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q1  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 1 then Amount else 0 end) as CreditAmountJan  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 2 then Amount else 0 end) as CreditAmountFeb  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 3 then Amount else 0 end) as CreditAmountMar  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 4 then Amount else 0 end) as CreditAmountApr  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 5 then Amount else 0 end) as CreditAmountMay  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 6 then Amount else 0 end) as CreditAmountJun  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 7 then Amount else 0 end) as CreditAmountJul  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 8 then Amount else 0 end) as CreditAmountAug  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 9 then Amount else 0 end) as CreditAmountSep  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 10 then Amount else 0 end) as CreditAmountOct  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 11 then Amount else 0 end) as CreditAmountNov  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 12 then Amount else 0 end) as CreditAmountDec  ");
            sQueryStringMaster.Append("from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.TranDate < ?   ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q4  ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 1 then Amount else 0 end) as DebitAmountJan  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 2 then Amount else 0 end) as DebitAmountFeb  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 3 then Amount else 0 end) as DebitAmountMar  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 4 then Amount else 0 end) as DebitAmountApr  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 5 then Amount else 0 end) as DebitAmountMay  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 6 then Amount else 0 end) as DebitAmountJun  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 7 then Amount else 0 end) as DebitAmountJul  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 8 then Amount else 0 end) as DebitAmountAug  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 9 then Amount else 0 end) as DebitAmountSep  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 10 then Amount else 0 end) as DebitAmountOct  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 11 then Amount else 0 end) as DebitAmountNov  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 12 then Amount else 0 end) as DebitAmountDec  ");
            sQueryStringMaster.Append("from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.TranDate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q5  ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as p3  ");
            sQueryStringMaster.Append("on p.Customerid = p3.Customerid   ");

            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as CumSalesCYR     ");
            sQueryStringMaster.Append("From    ");
            sQueryStringMaster.Append("(    ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount    ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)    ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append("union all    ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount,sum(invoiceamount)as drSalesAmount   ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?)   ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append(")as qq1    ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(") as p4  ");
            sQueryStringMaster.Append("on p.Customerid = p4.Customerid  ");
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ( isnull(q4.CreditAmount,0) - isnull(q5.DebitAmount,0)) as CumCollCYR   ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q1  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q4  ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?)  and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q5  ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid  ");
            sQueryStringMaster.Append(")as p5  ");
            sQueryStringMaster.Append("on p.Customerid = p5.Customerid  ");

            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as CumSalesLYR     ");
            sQueryStringMaster.Append("From    ");
            sQueryStringMaster.Append("(    ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount    ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)    ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append("union all    ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount,sum(invoiceamount)as drSalesAmount   ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?)   ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append(")as qq1    ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(") as p8  ");
            sQueryStringMaster.Append("on p.Customerid = p8.Customerid  ");
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ( isnull(q4.CreditAmount,0) - isnull(q5.DebitAmount,0)) as CumCollLYR   ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q1  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q4  ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?)  and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q5  ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid  ");
            sQueryStringMaster.Append(")as p7  ");
            sQueryStringMaster.Append("on p.Customerid = p7.Customerid  ");
            ////////////////////////////
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as TotalSalesLYR     ");
            sQueryStringMaster.Append("From    ");
            sQueryStringMaster.Append("(    ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount    ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)    ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append("union all    ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount,sum(invoiceamount)as drSalesAmount   ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?)   ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append(")as qq1    ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(") as p9  ");
            sQueryStringMaster.Append("on p.Customerid = p9.Customerid  ");
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ( isnull(q4.CreditAmount,0) - isnull(q5.DebitAmount,0)) as TotalCollLYR   ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q1  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q4  ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?)  and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q5  ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid  ");
            sQueryStringMaster.Append(")as p10  ");
            sQueryStringMaster.Append("on p.Customerid = p10.Customerid  ");

            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ((q1.CurrentBalance - isnull(q2.CreditAmount,0) ) + isnull(q3.DebitAmount,0)) as CurrentOS  ");
            sQueryStringMaster.Append("from   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount   ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q1   ");
            sQueryStringMaster.Append("left outer join   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt    ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and transide = ? and ct.TranDate between ? and ? and TranDate < ?  ");
            sQueryStringMaster.Append("group by customerid   ");
            sQueryStringMaster.Append(")    ");
            sQueryStringMaster.Append("as q2   ");
            sQueryStringMaster.Append("on q1.customerid = q2.customerid   ");
            sQueryStringMaster.Append("left outer join   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt    ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and transide = ?  and ct.TranDate between ? and ? and TranDate < ?  ");
            sQueryStringMaster.Append("group by customerid   ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q3   ");
            sQueryStringMaster.Append("on q1.customerid = q3.customerid   ");
            sQueryStringMaster.Append(")as p11  ");
            sQueryStringMaster.Append("on p.customerid = p11.customerid   ");
            //////////////////////////////
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select MarketGroupID as CustomerID, sum(Turnover)as MonthlyTargetAmt ");
            sQueryStringMaster.Append("From t_PlanBudgetTarget   ");
            sQueryStringMaster.Append("Where plantype in (?) and periodtype in (?) and MarketScopeType in (?)   ");
            sQueryStringMaster.Append("and perioddate between ? and ? ");
            sQueryStringMaster.Append("Group By MarketGroupID ");
            sQueryStringMaster.Append(")as p6 ");
            sQueryStringMaster.Append("on p.Customerid = p6.Customerid  ");

            sQueryStringMaster.Append("group by   ");
            sQueryStringMaster.Append("p.SBUID, p.SBUCode, p.SBUName   ");
            sQueryStringMaster.Append(",p.ChannelID, p.ChannelCode, p.Channeldescription   ");
            

            //Command time out
            cmd.CommandTimeout = 0;
            cmd.CommandText = sQueryStringMaster.ToString();

            cmd.Parameters.AddWithValue("InvoiceDate", dCYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", dCYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);


            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dCYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));



            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dCYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));


            cmd.Parameters.AddWithValue("InvoiceDate", dCYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", dCYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dCYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));



            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dCYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));

            cmd.Parameters.AddWithValue("InvoiceDate", dLYCFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dLYCToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dLYCToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", dLYCFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dLYCToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dLYCToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dLYCFromDate);
            cmd.Parameters.AddWithValue("TranDate", dLYCToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dLYCToDate.AddDays(1));



            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dLYCFromDate);
            cmd.Parameters.AddWithValue("TranDate", dLYCToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dLYCToDate.AddDays(1));

            cmd.Parameters.AddWithValue("InvoiceDate", dLYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dLYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dLYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", dLYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dLYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dLYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dLYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dLYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dLYToDate.AddDays(1));


            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dLYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dLYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dLYToDate.AddDays(1));

            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionSide.CREDIT);
            cmd.Parameters.AddWithValue("TranDate",dFromDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dToDate.AddDays(1));

            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionSide.DEBIT);
            cmd.Parameters.AddWithValue("TranDate",dFromDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dToDate.AddDays(1));

            cmd.Parameters.AddWithValue("PlanType", (short)Dictionary.PlanType.Target);
            cmd.Parameters.AddWithValue("PeriodType", (short)Dictionary.PeriodType.Monthly);
            cmd.Parameters.AddWithValue("MarketScopeType", (short)Dictionary.MarketScopeType.Customer);
            cmd.Parameters.AddWithValue("PeriodDate", dCYFromDate);
            cmd.Parameters.AddWithValue("PeriodDate", dCYToDate.AddDays(1));



            GetMonthlySalesVsCollectionChannelWiseData(cmd);
        }
        private void GetMonthlySalesVsCollectionChannelWiseData(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptSalesVSCollection oItem = new rptSalesVSCollection();

                    if (reader["SBUID"] != DBNull.Value)
                        oItem.SBUID = Convert.ToInt64(reader["SBUID"]);
                    else oItem.SBUID = -1;
                    if (reader["SBUCode"] != DBNull.Value)
                        oItem.SBUCode = (string)(reader["SBUCode"]);
                    else oItem.SBUCode = "";
                    if (reader["SBUName"] != DBNull.Value)
                        oItem.SBUName = (string)(reader["SBUName"]);
                    else oItem.SBUName = "";

                    if (reader["ChannelId"] != DBNull.Value)
                        oItem.ChannelId = Convert.ToInt64(reader["ChannelId"]);
                    else oItem.ChannelId = -1;
                    if (reader["ChannelCode"] != DBNull.Value)
                        oItem.ChannelCode = (string)(reader["ChannelCode"]);
                    else oItem.ChannelCode = "";
                    if (reader["ChannelName"] != DBNull.Value)
                        oItem.ChannelName = (string)(reader["ChannelName"]);
                    else oItem.ChannelName = "";

                    oItem.CustomerTypeId = -1;
                    oItem.CustomerTypeCode = "";
                    oItem.CustomerTypeName = "";

                    oItem.AreaId = -1;
                    oItem.AreaCode = "";
                    oItem.AreaName = "";
                    oItem.CustomerId = -1;
                    oItem.CustomerCode = "";
                    oItem.CustomerName = "";
                    oItem.IsActive = 1;

                    oItem.ParentCustomerID = -1;
                    oItem.ParentCustomerCode = "";
                    oItem.ParentCustomerName = "";
                    oItem.TerritoryId = -1;
                    oItem.TerritoryCode = "";
                    oItem.TerritoryName = "";

                    if (reader["JanSales"] != DBNull.Value)
                        oItem.JanSales = Convert.ToDouble(reader["JanSales"]);
                    else oItem.JanSales = 0;
                    if (reader["FebSales"] != DBNull.Value)
                        oItem.FebSales = Convert.ToDouble(reader["FebSales"]);
                    else oItem.FebSales = 0;
                    if (reader["MarSales"] != DBNull.Value)
                        oItem.MarSales = Convert.ToDouble(reader["MarSales"]);
                    else oItem.MarSales = 0;
                    if (reader["AprSales"] != DBNull.Value)
                        oItem.AprSales = Convert.ToDouble(reader["AprSales"]);
                    else oItem.AprSales = 0;
                    if (reader["MaySales"] != DBNull.Value)
                        oItem.MaySales = Convert.ToDouble(reader["MaySales"]);
                    else oItem.MaySales = 0;
                    if (reader["JunSales"] != DBNull.Value)
                        oItem.JunSales = Convert.ToDouble(reader["JunSales"]);
                    else oItem.JunSales = 0;
                    if (reader["JulSales"] != DBNull.Value)
                        oItem.JulSales = Convert.ToDouble(reader["JulSales"]);
                    else oItem.JulSales = 0;
                    if (reader["AugSales"] != DBNull.Value)
                        oItem.AugSales = Convert.ToDouble(reader["AugSales"]);
                    else oItem.AugSales = 0;
                    if (reader["SepSales"] != DBNull.Value)
                        oItem.SepSales = Convert.ToDouble(reader["SepSales"]);
                    else oItem.SepSales = 0;
                    if (reader["OctSales"] != DBNull.Value)
                        oItem.OctSales = Convert.ToDouble(reader["OctSales"]);
                    else oItem.OctSales = 0;
                    if (reader["NovSales"] != DBNull.Value)
                        oItem.NovSales = Convert.ToDouble(reader["NovSales"]);
                    else oItem.NovSales = 0;
                    if (reader["DecSales"] != DBNull.Value)
                        oItem.DecSales = Convert.ToDouble(reader["DecSales"]);
                    else oItem.DecSales = 0;

                    if (reader["JanColl"] != DBNull.Value)
                        oItem.JanColl = Convert.ToDouble(reader["JanColl"]);
                    else oItem.JanColl = 0;
                    if (reader["FebColl"] != DBNull.Value)
                        oItem.FebColl = Convert.ToDouble(reader["FebColl"]);
                    else oItem.FebColl = 0;
                    if (reader["MarColl"] != DBNull.Value)
                        oItem.MarColl = Convert.ToDouble(reader["MarColl"]);
                    else oItem.MarColl = 0;
                    if (reader["AprColl"] != DBNull.Value)
                        oItem.AprColl = Convert.ToDouble(reader["AprColl"]);
                    else oItem.AprColl = 0;
                    if (reader["MayColl"] != DBNull.Value)
                        oItem.MayColl = Convert.ToDouble(reader["MayColl"]);
                    else oItem.MayColl = 0;
                    if (reader["JunColl"] != DBNull.Value)
                        oItem.JunColl = Convert.ToDouble(reader["JunColl"]);
                    else oItem.JunColl = 0;
                    if (reader["JulColl"] != DBNull.Value)
                        oItem.JulColl = Convert.ToDouble(reader["JulColl"]);
                    else oItem.JulColl = 0;
                    if (reader["AugColl"] != DBNull.Value)
                        oItem.AugColl = Convert.ToDouble(reader["AugColl"]);
                    else oItem.AugColl = 0;
                    if (reader["SepColl"] != DBNull.Value)
                        oItem.SepColl = Convert.ToDouble(reader["SepColl"]);
                    else oItem.SepColl = 0;
                    if (reader["OctColl"] != DBNull.Value)
                        oItem.OctColl = Convert.ToDouble(reader["OctColl"]);
                    else oItem.OctColl = 0;
                    if (reader["NovColl"] != DBNull.Value)
                        oItem.NovColl = Convert.ToDouble(reader["NovColl"]);
                    else oItem.NovColl = 0;
                    if (reader["DecColl"] != DBNull.Value)
                        oItem.DecColl = Convert.ToDouble(reader["DecColl"]);
                    else oItem.DecColl = 0;

                    if (reader["CumSalesCYR"] != DBNull.Value)
                        oItem.CumSalesCYR = Convert.ToDouble(reader["CumSalesCYR"]);
                    else oItem.CumSalesCYR = 0;
                    if (reader["CumCollCYR"] != DBNull.Value)
                        oItem.CumCollCYR = Convert.ToDouble(reader["CumCollCYR"]);
                    else oItem.CumCollCYR = 0;
                    if (reader["CumSalesLYR"] != DBNull.Value)
                        oItem.CumSalesLYR = Convert.ToDouble(reader["CumSalesLYR"]);
                    else oItem.CumSalesLYR = 0;
                    if (reader["CumCollLYR"] != DBNull.Value)
                        oItem.CumCollLYR = Convert.ToDouble(reader["CumCollLYR"]);
                    else oItem.CumCollLYR = 0;
                    if (reader["TotalSalesLYR"] != DBNull.Value)
                        oItem.TotalSalesLYR = Convert.ToDouble(reader["TotalSalesLYR"]);
                    else oItem.TotalSalesLYR = 0;
                    if (reader["TotalCollLYR"] != DBNull.Value)
                        oItem.TotalCollLYR = Convert.ToDouble(reader["TotalCollLYR"]);
                    else oItem.TotalCollLYR = 0;
                    if (reader["TargetTO"] != DBNull.Value)
                        oItem.TargetTO = Convert.ToDouble(reader["TargetTO"]);
                    else oItem.TargetTO = 0;
                    if (reader["CurrentOS"] != DBNull.Value)
                        oItem.CurrentOS = Convert.ToDouble(reader["CurrentOS"]);
                    else oItem.CurrentOS = 0;


                    Add(oItem);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void FromDataSetChannelWise(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    rptSalesVSCollection oItem = new rptSalesVSCollection();


                    oItem.SBUID = Convert.ToInt64(oRow["SBUID"]);
                    oItem.SBUCode = (string)(oRow["SBUCode"]);
                    oItem.SBUName = (string)(oRow["SBUName"]);

                    oItem.ChannelId = Convert.ToInt64(oRow["ChannelId"]);
                    oItem.ChannelCode = (string)(oRow["ChannelCode"]);
                    oItem.ChannelName = (string)(oRow["ChannelName"]);
                    oItem.CustomerTypeId = Convert.ToInt64(oRow["CustomerTypeId"]);
                    oItem.CustomerTypeCode = (string)(oRow["CustomerTypeCode"]);
                    oItem.CustomerTypeName = (string)(oRow["CustomerTypeName"]);
                    oItem.AreaId = Convert.ToInt64(oRow["AreaId"]);
                    oItem.AreaCode = (string)(oRow["AreaCode"]);
                    oItem.AreaName = (string)(oRow["AreaName"]);
                    oItem.CustomerId = Convert.ToInt64(oRow["CustomerId"]);
                    oItem.CustomerCode = (string)(oRow["CustomerCode"]);
                    oItem.CustomerName = (string)(oRow["CustomerName"]);
                    oItem.IsActive = Convert.ToInt16(oRow["IsActive"]);
                    oItem.ParentCustomerID = Convert.ToInt64(oRow["ParentCustomerID"]);
                    oItem.ParentCustomerCode = (string)(oRow["ParentCustomerCode"]);
                    oItem.ParentCustomerName = (string)(oRow["ParentCustomerName"]);
                    oItem.TerritoryId = Convert.ToInt64(oRow["TerritoryId"]);
                    oItem.TerritoryCode = (string)(oRow["TerritoryCode"]);
                    oItem.TerritoryName = (string)(oRow["TerritoryName"]);

                    oItem.JanSales = Convert.ToDouble(oRow["JanSales"]);
                    oItem.FebSales = Convert.ToDouble(oRow["FebSales"]);
                    oItem.MarSales = Convert.ToDouble(oRow["MarSales"]);
                    oItem.AprSales = Convert.ToDouble(oRow["AprSales"]);
                    oItem.MaySales = Convert.ToDouble(oRow["MaySales"]);
                    oItem.JunSales = Convert.ToDouble(oRow["JunSales"]);
                    oItem.JulSales = Convert.ToDouble(oRow["JulSales"]);
                    oItem.AugSales = Convert.ToDouble(oRow["AugSales"]);
                    oItem.SepSales = Convert.ToDouble(oRow["SepSales"]);
                    oItem.OctSales = Convert.ToDouble(oRow["OctSales"]);
                    oItem.NovSales = Convert.ToDouble(oRow["NovSales"]);
                    oItem.DecSales = Convert.ToDouble(oRow["DecSales"]);

                    oItem.JanColl = Convert.ToDouble(oRow["JanColl"]);
                    oItem.FebColl = Convert.ToDouble(oRow["FebColl"]);
                    oItem.MarColl = Convert.ToDouble(oRow["MarColl"]);
                    oItem.AprColl = Convert.ToDouble(oRow["AprColl"]);
                    oItem.MayColl = Convert.ToDouble(oRow["MayColl"]);
                    oItem.JunColl = Convert.ToDouble(oRow["JunColl"]);
                    oItem.JulColl = Convert.ToDouble(oRow["JulColl"]);
                    oItem.AugColl = Convert.ToDouble(oRow["AugColl"]);
                    oItem.SepColl = Convert.ToDouble(oRow["SepColl"]);
                    oItem.OctColl = Convert.ToDouble(oRow["OctColl"]);
                    oItem.NovColl = Convert.ToDouble(oRow["NovColl"]);
                    oItem.DecColl = Convert.ToDouble(oRow["DecColl"]);

                    oItem.CumSalesCYR = Convert.ToDouble(oRow["CumSalesCYR"]);
                    oItem.CumCollCYR = Convert.ToDouble(oRow["CumCollCYR"]);
                    oItem.CumSalesLYR = Convert.ToDouble(oRow["CumSalesLYR"]);
                    oItem.CumCollLYR = Convert.ToDouble(oRow["CumCollLYR"]);
                    oItem.TotalSalesLYR = Convert.ToDouble(oRow["TotalSalesLYR"]);
                    oItem.TotalCollLYR = Convert.ToDouble(oRow["TotalCollLYR"]);
                    oItem.TargetTO = Convert.ToDouble(oRow["TargetTO"]);
                    oItem.CurrentOS = Convert.ToDouble(oRow["CurrentOS"]);

                    InnerList.Add(oItem);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Sales VS Collection Report Channel wise
        /// </summary>
        /// <param name="dCFromDate"></param>
        /// <param name="dCToDate"></param>
        /// <param name="dLFromDate"></param>
        /// <param name="dLToDate"></param>
        public void GetMonthlySalesVsCollectionAreaWise(DateTime dCYFromDate, DateTime dCYToDate, DateTime dLYCFromDate, DateTime dLYCToDate, DateTime dLYFromDate, DateTime dLYToDate, DateTime dFromDate, DateTime dToDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            sQueryStringMaster.Append("Select p.SBUID, p.SBUCode, p.SBUName   ");
            sQueryStringMaster.Append(",p.ChannelID, p.ChannelCode, p.Channeldescription as ChannelName  ");
            sQueryStringMaster.Append(",p.AreaID, p.AreaCode, p.AreaName  ");
            sQueryStringMaster.Append(",sum(isnull(JanSales,0))as JanSales, sum(isnull(FebSales,0))as FebSales, sum(isnull(MarSales,0))as MarSales  ");
            sQueryStringMaster.Append(",sum(isnull(AprSales,0))as AprSales, sum(isnull(MaySales,0))as MaySales, sum(isnull(JunSales,0))as JunSales  ");
            sQueryStringMaster.Append(",sum(isnull(JulSales,0))as JulSales, sum(isnull(AugSales,0))as AugSales, sum(isnull(SepSales,0))as SepSales  ");
            sQueryStringMaster.Append(",sum(isnull(OctSales,0))as OctSales, sum(isnull(NovSales,0))as NovSales, sum(isnull(DecSales,0))as DecSales  ");
            sQueryStringMaster.Append(",sum(isnull(JanColl,0))as JanColl, sum(isnull(FebColl,0))as FebColl, sum(isnull(MarColl,0))as MarColl  ");
            sQueryStringMaster.Append(",sum(isnull(AprColl,0))as AprColl, sum(isnull(MayColl,0))as MayColl, sum(isnull(JunColl,0))as JunColl  ");
            sQueryStringMaster.Append(",sum(isnull(JulColl,0))as JulColl, sum(isnull(AugColl,0))as AugColl, sum(isnull(SepColl,0))as SepColl  ");
            sQueryStringMaster.Append(",sum(isnull(OctColl,0))as OctColl, sum(isnull(NovColl,0))as NovColl, sum(isnull(DecColl,0))as DecColl  ");
            sQueryStringMaster.Append(",sum(isnull(CumSalesCYR,0))as CumSalesCYR,sum(isnull(CumCollCYR,0))as CumCollCYR ");
            sQueryStringMaster.Append(",sum(isnull(CumSalesLYR,0))as CumSalesLYR,sum(isnull(CumCollLYR,0))as CumCollLYR ");
            sQueryStringMaster.Append(",sum(isnull(TotalSalesLYR,0))as TotalSalesLYR,sum(isnull(TotalCollLYR,0))as TotalCollLYR  ");
            sQueryStringMaster.Append(",sum(isnull(p11.CurrentOS,0))as CurrentOS, sum(isnull(MonthlyTargetAmt,0)) as TargetTO ");
            sQueryStringMaster.Append("from   ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select * from v_customerDetails    ");
            sQueryStringMaster.Append(")as p   ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select p.CustomerID  ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRJanCYR) - abs(sum(p2.DbJanCYR)),0) as JanSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRFebCYR) - abs(sum(p2.DbFebCYR)),0) as FebSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRMarCYR) - abs(sum(p2.DbMarCYR)),0) as MarSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRAprCYR) - abs(sum(p2.DbAprCYR)),0) as AprSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRMayCYR) - abs(sum(p2.DbMayCYR)),0) as MaySales  ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRJunCYR) - abs(sum(p2.DbJunCYR)),0) as JunSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRJulCYR) - abs(sum(p2.DbJulCYR)),0) as JulSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRAugCYR) - abs(sum(p2.DbAugCYR)),0) as AugSales  ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRSepCYR) - abs(sum(p2.DbSepCYR)),0) as SepSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CROctCYR) - abs(sum(p2.DbOctCYR)),0) as OctSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRNovCYR) - abs(sum(p2.DbNovCYR)),0) as NovSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRDcmCYR) - abs(sum(p2.DbDcmCYR)),0) as DecSales  ");
            sQueryStringMaster.Append("from   ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select * from t_customer    ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as p  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 1 then InvoiceAmount else 0 end) as CRJanCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 2 then InvoiceAmount else 0 end) as CRFebCYR,   ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 3 then InvoiceAmount else 0 end) as CRMarCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 4 then InvoiceAmount else 0 end) as CRAprCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 5 then InvoiceAmount else 0 end) as CRMayCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 6 then InvoiceAmount else 0 end) as CRJunCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 7 then InvoiceAmount else 0 end) as CRJulCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 8 then InvoiceAmount else 0 end) as CRAugCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 9 then InvoiceAmount else 0 end) as CRSepCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 10 then InvoiceAmount else 0 end) as CROctCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 11 then InvoiceAmount else 0 end) as CRNovCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 12 then InvoiceAmount else 0 end) as CRDcmCYR,  ");
            sQueryStringMaster.Append("0 as DbJanCYR, 0 as DbFebCYR, 0 as DbMarCYR, 0 as DbAprCYR, 0 as DbMayCYR, 0 as DbJunCYR,  ");
            sQueryStringMaster.Append("0 as DbJulCYR, 0 as DbAugCYR, 0 as DbSepCYR, 0 as DbOctCYR, 0 as DbNovCYR, 0 as DbDcmCYR  ");
            sQueryStringMaster.Append("from t_salesInvoice im,  t_customer cd  ");
            sQueryStringMaster.Append("where  im.CustomerID = cd.CustomerID and  ");
            sQueryStringMaster.Append("invoicedate between ? and ? and invoicedate< ? and invoicetypeid in (?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("group by  im.CustomerID  ");
            sQueryStringMaster.Append("union all   ");
            sQueryStringMaster.Append("select im.CustomerID,  ");
            sQueryStringMaster.Append("0 as CRJanCYR, 0 as CRFebCYR, 0 as CRMarCYR, 0 as CRAprCYR, 0 as CRMayCYR, 0 as CRJunCYR,  ");
            sQueryStringMaster.Append("0 as CRJulCYR, 0 as CRAugCYR, 0 as CRSepCYR, 0 as CROctCYR, 0 as CRNovCYR, 0 as CRDcmCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 1 then InvoiceAmount else 0 end) as DbJanCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 2 then InvoiceAmount else 0 end) as DbFebCYR,   ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 3 then InvoiceAmount else 0 end) as DbMarCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 4 then InvoiceAmount else 0 end) as DbAprCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 5 then InvoiceAmount else 0 end) as DbMayCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 6 then InvoiceAmount else 0 end) as DbJunCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 7 then InvoiceAmount else 0 end) as DbJulCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 8 then InvoiceAmount else 0 end) as DbAugCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 9 then InvoiceAmount else 0 end) as DbSepCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 10 then InvoiceAmount else 0 end) as DbOctCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 11 then InvoiceAmount else 0 end) as DbNovCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 12 then InvoiceAmount else 0 end) as DbDcmCYR  ");
            sQueryStringMaster.Append("from t_salesInvoice im,  t_customer cd  ");
            sQueryStringMaster.Append("where  im.CustomerID = cd.CustomerID and  ");
            sQueryStringMaster.Append("invoicedate between ? and ? and invoicedate< ? and invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("group by  im.CustomerID  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as p2 on p.CustomerID = p2.CustomerID  ");
            sQueryStringMaster.Append("group by p.customerid  ");
            sQueryStringMaster.Append(")as p2 on p.CustomerID = p2.CustomerID   ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select q1.customerid  ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountJan,0) - isnull(q5.DebitAmountJan,0)) as JanColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountFeb,0) - isnull(q5.DebitAmountFeb,0)) as FebColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountMar,0) - isnull(q5.DebitAmountMar,0)) as MarColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountApr,0) - isnull(q5.DebitAmountApr,0)) as AprColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountMay,0) - isnull(q5.DebitAmountMay,0)) as MayColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountJun,0) - isnull(q5.DebitAmountJun,0)) as JunColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountJul,0) - isnull(q5.DebitAmountJul,0)) as JulColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountAug,0) - isnull(q5.DebitAmountAug,0)) as AugColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountSep,0) - isnull(q5.DebitAmountSep,0)) as SepColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountOct,0) - isnull(q5.DebitAmountOct,0)) as OctColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountNov,0) - isnull(q5.DebitAmountNov,0)) as NovColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountDec,0) - isnull(q5.DebitAmountDec,0)) as DecColl   ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q1  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 1 then Amount else 0 end) as CreditAmountJan  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 2 then Amount else 0 end) as CreditAmountFeb  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 3 then Amount else 0 end) as CreditAmountMar  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 4 then Amount else 0 end) as CreditAmountApr  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 5 then Amount else 0 end) as CreditAmountMay  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 6 then Amount else 0 end) as CreditAmountJun  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 7 then Amount else 0 end) as CreditAmountJul  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 8 then Amount else 0 end) as CreditAmountAug  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 9 then Amount else 0 end) as CreditAmountSep  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 10 then Amount else 0 end) as CreditAmountOct  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 11 then Amount else 0 end) as CreditAmountNov  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 12 then Amount else 0 end) as CreditAmountDec  ");
            sQueryStringMaster.Append("from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.TranDate < ?   ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q4  ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 1 then Amount else 0 end) as DebitAmountJan  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 2 then Amount else 0 end) as DebitAmountFeb  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 3 then Amount else 0 end) as DebitAmountMar  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 4 then Amount else 0 end) as DebitAmountApr  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 5 then Amount else 0 end) as DebitAmountMay  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 6 then Amount else 0 end) as DebitAmountJun  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 7 then Amount else 0 end) as DebitAmountJul  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 8 then Amount else 0 end) as DebitAmountAug  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 9 then Amount else 0 end) as DebitAmountSep  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 10 then Amount else 0 end) as DebitAmountOct  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 11 then Amount else 0 end) as DebitAmountNov  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 12 then Amount else 0 end) as DebitAmountDec  ");
            sQueryStringMaster.Append("from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.TranDate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q5  ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as p3  ");
            sQueryStringMaster.Append("on p.Customerid = p3.Customerid   ");

            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as CumSalesCYR     ");
            sQueryStringMaster.Append("From    ");
            sQueryStringMaster.Append("(    ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount    ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)    ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append("union all    ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount,sum(invoiceamount)as drSalesAmount   ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?)   ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append(")as qq1    ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(") as p4  ");
            sQueryStringMaster.Append("on p.Customerid = p4.Customerid  ");
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ( isnull(q4.CreditAmount,0) - isnull(q5.DebitAmount,0)) as CumCollCYR   ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q1  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q4  ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?)  and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q5  ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid  ");
            sQueryStringMaster.Append(")as p5  ");
            sQueryStringMaster.Append("on p.Customerid = p5.Customerid  ");

            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as CumSalesLYR     ");
            sQueryStringMaster.Append("From    ");
            sQueryStringMaster.Append("(    ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount    ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)    ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append("union all    ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount,sum(invoiceamount)as drSalesAmount   ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?)   ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append(")as qq1    ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(") as p8  ");
            sQueryStringMaster.Append("on p.Customerid = p8.Customerid  ");
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ( isnull(q4.CreditAmount,0) - isnull(q5.DebitAmount,0)) as CumCollLYR   ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q1  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q4  ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?)  and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q5  ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid  ");
            sQueryStringMaster.Append(")as p7  ");
            sQueryStringMaster.Append("on p.Customerid = p7.Customerid  ");
            ////////////////////////////
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as TotalSalesLYR     ");
            sQueryStringMaster.Append("From    ");
            sQueryStringMaster.Append("(    ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount    ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)    ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append("union all    ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount,sum(invoiceamount)as drSalesAmount   ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?)   ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append(")as qq1    ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(") as p9  ");
            sQueryStringMaster.Append("on p.Customerid = p9.Customerid  ");
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ( isnull(q4.CreditAmount,0) - isnull(q5.DebitAmount,0)) as TotalCollLYR   ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q1  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q4  ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?)  and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q5  ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid  ");
            sQueryStringMaster.Append(")as p10  ");
            sQueryStringMaster.Append("on p.Customerid = p10.Customerid  ");

            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ((q1.CurrentBalance - isnull(q2.CreditAmount,0) ) + isnull(q3.DebitAmount,0)) as CurrentOS  ");
            sQueryStringMaster.Append("from   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount   ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q1   ");
            sQueryStringMaster.Append("left outer join   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt    ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and transide = ? and ct.TranDate between ? and ? and TranDate < ?  ");
            sQueryStringMaster.Append("group by customerid   ");
            sQueryStringMaster.Append(")    ");
            sQueryStringMaster.Append("as q2   ");
            sQueryStringMaster.Append("on q1.customerid = q2.customerid   ");
            sQueryStringMaster.Append("left outer join   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt    ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and transide = ?  and ct.TranDate between ? and ? and TranDate < ?  ");
            sQueryStringMaster.Append("group by customerid   ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q3   ");
            sQueryStringMaster.Append("on q1.customerid = q3.customerid   ");
            sQueryStringMaster.Append(")as p11  ");
            sQueryStringMaster.Append("on p.customerid = p11.customerid   ");

            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select MarketGroupID as CustomerID, sum(Turnover)as MonthlyTargetAmt ");
            sQueryStringMaster.Append("From t_PlanBudgetTarget   ");
            sQueryStringMaster.Append("Where plantype in (?) and periodtype in (?) and MarketScopeType in (?)   ");
            sQueryStringMaster.Append("and perioddate between ? and ? ");
            sQueryStringMaster.Append("Group By MarketGroupID ");
            sQueryStringMaster.Append(")as p6 ");
            sQueryStringMaster.Append("on p.Customerid = p6.Customerid  ");

            sQueryStringMaster.Append("group by   ");
            sQueryStringMaster.Append("p.SBUID, p.SBUCode, p.SBUName   ");
            sQueryStringMaster.Append(",p.ChannelID, p.ChannelCode, p.Channeldescription   ");
            sQueryStringMaster.Append(",p.AreaID, p.AreaCode, p.AreaName  ");
         
            //Command time out
            cmd.CommandTimeout = 0;
            cmd.CommandText = sQueryStringMaster.ToString();

            //cmd.Parameters.AddWithValue("IsActive", Dictionary.ActiveOrInActiveStatus.ACTIVE);

            cmd.Parameters.AddWithValue("InvoiceDate", dCYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", dCYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);


            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dCYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));



            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dCYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));


            cmd.Parameters.AddWithValue("InvoiceDate", dCYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", dCYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dCYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));



            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dCYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));

            cmd.Parameters.AddWithValue("InvoiceDate", dLYCFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dLYCToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dLYCToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", dLYCFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dLYCToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dLYCToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dLYCFromDate);
            cmd.Parameters.AddWithValue("TranDate", dLYCToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dLYCToDate.AddDays(1));



            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dLYCFromDate);
            cmd.Parameters.AddWithValue("TranDate", dLYCToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dLYCToDate.AddDays(1));

            cmd.Parameters.AddWithValue("InvoiceDate", dLYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate",dLYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate",dLYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", dLYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate",dLYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate",dLYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dLYFromDate);
            cmd.Parameters.AddWithValue("TranDate",dLYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate",dLYToDate.AddDays(1));



            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dLYFromDate);
            cmd.Parameters.AddWithValue("TranDate",dLYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate",dLYToDate.AddDays(1));

            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionSide.CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dFromDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dToDate.AddDays(1));

            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionSide.DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dFromDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dToDate.AddDays(1));

            cmd.Parameters.AddWithValue("PlanType", (short)Dictionary.PlanType.Target);
            cmd.Parameters.AddWithValue("PeriodType", (short)Dictionary.PeriodType.Monthly);
            cmd.Parameters.AddWithValue("MarketScopeType", (short)Dictionary.MarketScopeType.Customer);
            cmd.Parameters.AddWithValue("PeriodDate", dCYFromDate);
            cmd.Parameters.AddWithValue("PeriodDate", dCYToDate.AddDays(1));


            GetMonthlySalesVsCollectionAreaWiseData(cmd);
        }
        private void GetMonthlySalesVsCollectionAreaWiseData(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptSalesVSCollection oItem = new rptSalesVSCollection();

                    if (reader["SBUID"] != DBNull.Value)
                        oItem.SBUID = Convert.ToInt64(reader["SBUID"]);
                    else oItem.SBUID = -1;
                    if (reader["SBUCode"] != DBNull.Value)
                        oItem.SBUCode = (string)(reader["SBUCode"]);
                    else oItem.SBUCode = "";
                    if (reader["SBUName"] != DBNull.Value)
                        oItem.SBUName = (string)(reader["SBUName"]);
                    else oItem.SBUName = "";

                    if (reader["ChannelId"] != DBNull.Value)
                        oItem.ChannelId = Convert.ToInt64(reader["ChannelId"]);
                    else oItem.ChannelId = -1;
                    if (reader["ChannelCode"] != DBNull.Value)
                        oItem.ChannelCode = (string)(reader["ChannelCode"]);
                    else oItem.ChannelCode = "";
                    if (reader["ChannelName"] != DBNull.Value)
                        oItem.ChannelName = (string)(reader["ChannelName"]);
                    else oItem.ChannelName = "";

                    oItem.CustomerTypeId = -1;
                    oItem.CustomerTypeCode = "";
                    oItem.CustomerTypeName = "";

                    if (reader["AreaId"] != DBNull.Value)
                        oItem.AreaId = Convert.ToInt64(reader["AreaId"]);
                    else oItem.AreaId = -1;
                    if (reader["AreaCode"] != DBNull.Value)
                        oItem.AreaCode = (string)(reader["AreaCode"]);
                    else oItem.AreaCode = "";
                    if (reader["AreaName"] != DBNull.Value)
                        oItem.AreaName = (string)(reader["AreaName"]);
                    else oItem.AreaName = "";

                    oItem.CustomerId = -1;
                    oItem.CustomerCode = "";
                    oItem.CustomerName = "";
                    oItem.IsActive = 1;

                    oItem.ParentCustomerID = -1;
                    oItem.ParentCustomerCode = "";
                    oItem.ParentCustomerName = "";
                    oItem.TerritoryId = -1;
                    oItem.TerritoryCode = "";
                    oItem.TerritoryName = "";

                    if (reader["JanSales"] != DBNull.Value)
                        oItem.JanSales = Convert.ToDouble(reader["JanSales"]);
                    else oItem.JanSales = 0;
                    if (reader["FebSales"] != DBNull.Value)
                        oItem.FebSales = Convert.ToDouble(reader["FebSales"]);
                    else oItem.FebSales = 0;
                    if (reader["MarSales"] != DBNull.Value)
                        oItem.MarSales = Convert.ToDouble(reader["MarSales"]);
                    else oItem.MarSales = 0;
                    if (reader["AprSales"] != DBNull.Value)
                        oItem.AprSales = Convert.ToDouble(reader["AprSales"]);
                    else oItem.AprSales = 0;
                    if (reader["MaySales"] != DBNull.Value)
                        oItem.MaySales = Convert.ToDouble(reader["MaySales"]);
                    else oItem.MaySales = 0;
                    if (reader["JunSales"] != DBNull.Value)
                        oItem.JunSales = Convert.ToDouble(reader["JunSales"]);
                    else oItem.JunSales = 0;
                    if (reader["JulSales"] != DBNull.Value)
                        oItem.JulSales = Convert.ToDouble(reader["JulSales"]);
                    else oItem.JulSales = 0;
                    if (reader["AugSales"] != DBNull.Value)
                        oItem.AugSales = Convert.ToDouble(reader["AugSales"]);
                    else oItem.AugSales = 0;
                    if (reader["SepSales"] != DBNull.Value)
                        oItem.SepSales = Convert.ToDouble(reader["SepSales"]);
                    else oItem.SepSales = 0;
                    if (reader["OctSales"] != DBNull.Value)
                        oItem.OctSales = Convert.ToDouble(reader["OctSales"]);
                    else oItem.OctSales = 0;
                    if (reader["NovSales"] != DBNull.Value)
                        oItem.NovSales = Convert.ToDouble(reader["NovSales"]);
                    else oItem.NovSales = 0;
                    if (reader["DecSales"] != DBNull.Value)
                        oItem.DecSales = Convert.ToDouble(reader["DecSales"]);
                    else oItem.DecSales = 0;

                    if (reader["JanColl"] != DBNull.Value)
                        oItem.JanColl = Convert.ToDouble(reader["JanColl"]);
                    else oItem.JanColl = 0;
                    if (reader["FebColl"] != DBNull.Value)
                        oItem.FebColl = Convert.ToDouble(reader["FebColl"]);
                    else oItem.FebColl = 0;
                    if (reader["MarColl"] != DBNull.Value)
                        oItem.MarColl = Convert.ToDouble(reader["MarColl"]);
                    else oItem.MarColl = 0;
                    if (reader["AprColl"] != DBNull.Value)
                        oItem.AprColl = Convert.ToDouble(reader["AprColl"]);
                    else oItem.AprColl = 0;
                    if (reader["MayColl"] != DBNull.Value)
                        oItem.MayColl = Convert.ToDouble(reader["MayColl"]);
                    else oItem.MayColl = 0;
                    if (reader["JunColl"] != DBNull.Value)
                        oItem.JunColl = Convert.ToDouble(reader["JunColl"]);
                    else oItem.JunColl = 0;
                    if (reader["JulColl"] != DBNull.Value)
                        oItem.JulColl = Convert.ToDouble(reader["JulColl"]);
                    else oItem.JulColl = 0;
                    if (reader["AugColl"] != DBNull.Value)
                        oItem.AugColl = Convert.ToDouble(reader["AugColl"]);
                    else oItem.AugColl = 0;
                    if (reader["SepColl"] != DBNull.Value)
                        oItem.SepColl = Convert.ToDouble(reader["SepColl"]);
                    else oItem.SepColl = 0;
                    if (reader["OctColl"] != DBNull.Value)
                        oItem.OctColl = Convert.ToDouble(reader["OctColl"]);
                    else oItem.OctColl = 0;
                    if (reader["NovColl"] != DBNull.Value)
                        oItem.NovColl = Convert.ToDouble(reader["NovColl"]);
                    else oItem.NovColl = 0;
                    if (reader["DecColl"] != DBNull.Value)
                        oItem.DecColl = Convert.ToDouble(reader["DecColl"]);
                    else oItem.DecColl = 0;

                    if (reader["CumSalesCYR"] != DBNull.Value)
                        oItem.CumSalesCYR = Convert.ToDouble(reader["CumSalesCYR"]);
                    else oItem.CumSalesCYR = 0;
                    if (reader["CumCollCYR"] != DBNull.Value)
                        oItem.CumCollCYR = Convert.ToDouble(reader["CumCollCYR"]);
                    else oItem.CumCollCYR = 0;
                    if (reader["CumSalesLYR"] != DBNull.Value)
                        oItem.CumSalesLYR = Convert.ToDouble(reader["CumSalesLYR"]);
                    else oItem.CumSalesLYR = 0;
                    if (reader["CumCollLYR"] != DBNull.Value)
                        oItem.CumCollLYR = Convert.ToDouble(reader["CumCollLYR"]);
                    else oItem.CumCollLYR = 0;
                    if (reader["TotalSalesLYR"] != DBNull.Value)
                        oItem.TotalSalesLYR = Convert.ToDouble(reader["TotalSalesLYR"]);
                    else oItem.TotalSalesLYR = 0;
                    if (reader["TotalCollLYR"] != DBNull.Value)
                        oItem.TotalCollLYR = Convert.ToDouble(reader["TotalCollLYR"]);
                    else oItem.TotalCollLYR = 0;
                    if (reader["TargetTO"] != DBNull.Value)
                        oItem.TargetTO = Convert.ToDouble(reader["TargetTO"]);
                    else oItem.TargetTO = 0;
                    if (reader["CurrentOS"] != DBNull.Value)
                        oItem.CurrentOS = Convert.ToDouble(reader["CurrentOS"]);
                    else oItem.CurrentOS = 0;


                    Add(oItem);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void FromDataSetAreaWise(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    rptSalesVSCollection oItem = new rptSalesVSCollection();


                    oItem.SBUID = Convert.ToInt64(oRow["SBUID"]);
                    oItem.SBUCode = (string)(oRow["SBUCode"]);
                    oItem.SBUName = (string)(oRow["SBUName"]);

                    oItem.ChannelId = Convert.ToInt64(oRow["ChannelId"]);
                    oItem.ChannelCode = (string)(oRow["ChannelCode"]);
                    oItem.ChannelName = (string)(oRow["ChannelName"]);
                    oItem.CustomerTypeId = Convert.ToInt64(oRow["CustomerTypeId"]);
                    oItem.CustomerTypeCode = (string)(oRow["CustomerTypeCode"]);
                    oItem.CustomerTypeName = (string)(oRow["CustomerTypeName"]);
                    oItem.AreaId = Convert.ToInt64(oRow["AreaId"]);
                    oItem.AreaCode = (string)(oRow["AreaCode"]);
                    oItem.AreaName = (string)(oRow["AreaName"]);
                    oItem.CustomerId = Convert.ToInt64(oRow["CustomerId"]);
                    oItem.CustomerCode = (string)(oRow["CustomerCode"]);
                    oItem.CustomerName = (string)(oRow["CustomerName"]);
                    oItem.IsActive = Convert.ToInt16(oRow["IsActive"]);
                    oItem.ParentCustomerID = Convert.ToInt64(oRow["ParentCustomerID"]);
                    oItem.ParentCustomerCode = (string)(oRow["ParentCustomerCode"]);
                    oItem.ParentCustomerName = (string)(oRow["ParentCustomerName"]);
                    oItem.TerritoryId = Convert.ToInt64(oRow["TerritoryId"]);
                    oItem.TerritoryCode = (string)(oRow["TerritoryCode"]);
                    oItem.TerritoryName = (string)(oRow["TerritoryName"]);

                    oItem.JanSales = Convert.ToDouble(oRow["JanSales"]);
                    oItem.FebSales = Convert.ToDouble(oRow["FebSales"]);
                    oItem.MarSales = Convert.ToDouble(oRow["MarSales"]);
                    oItem.AprSales = Convert.ToDouble(oRow["AprSales"]);
                    oItem.MaySales = Convert.ToDouble(oRow["MaySales"]);
                    oItem.JunSales = Convert.ToDouble(oRow["JunSales"]);
                    oItem.JulSales = Convert.ToDouble(oRow["JulSales"]);
                    oItem.AugSales = Convert.ToDouble(oRow["AugSales"]);
                    oItem.SepSales = Convert.ToDouble(oRow["SepSales"]);
                    oItem.OctSales = Convert.ToDouble(oRow["OctSales"]);
                    oItem.NovSales = Convert.ToDouble(oRow["NovSales"]);
                    oItem.DecSales = Convert.ToDouble(oRow["DecSales"]);

                    oItem.JanColl = Convert.ToDouble(oRow["JanColl"]);
                    oItem.FebColl = Convert.ToDouble(oRow["FebColl"]);
                    oItem.MarColl = Convert.ToDouble(oRow["MarColl"]);
                    oItem.AprColl = Convert.ToDouble(oRow["AprColl"]);
                    oItem.MayColl = Convert.ToDouble(oRow["MayColl"]);
                    oItem.JunColl = Convert.ToDouble(oRow["JunColl"]);
                    oItem.JulColl = Convert.ToDouble(oRow["JulColl"]);
                    oItem.AugColl = Convert.ToDouble(oRow["AugColl"]);
                    oItem.SepColl = Convert.ToDouble(oRow["SepColl"]);
                    oItem.OctColl = Convert.ToDouble(oRow["OctColl"]);
                    oItem.NovColl = Convert.ToDouble(oRow["NovColl"]);
                    oItem.DecColl = Convert.ToDouble(oRow["DecColl"]);

                    oItem.CumSalesCYR = Convert.ToDouble(oRow["CumSalesCYR"]);
                    oItem.CumCollCYR = Convert.ToDouble(oRow["CumCollCYR"]);
                    oItem.CumSalesLYR = Convert.ToDouble(oRow["CumSalesLYR"]);
                    oItem.CumCollLYR = Convert.ToDouble(oRow["CumCollLYR"]);
                    oItem.TotalSalesLYR = Convert.ToDouble(oRow["TotalSalesLYR"]);
                    oItem.TotalCollLYR = Convert.ToDouble(oRow["TotalCollLYR"]);
                    oItem.TargetTO = Convert.ToDouble(oRow["TargetTO"]);
                    oItem.CurrentOS = Convert.ToDouble(oRow["CurrentOS"]);

                    InnerList.Add(oItem);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Sales VS Collection Report Territory wise
        /// </summary>
        /// <param name="dCFromDate"></param>
        /// <param name="dCToDate"></param>
        /// <param name="dLFromDate"></param>
        /// <param name="dLToDate"></param>
        public void GetMonthlySalesVsCollectionTerritoryWise(DateTime dCYFromDate, DateTime dCYToDate, DateTime dLYCFromDate, DateTime dLYCToDate, DateTime dLYFromDate, DateTime dLYToDate, DateTime dFromDate, DateTime dToDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            sQueryStringMaster.Append("Select p.SBUID, p.SBUCode, p.SBUName   ");
            sQueryStringMaster.Append(",p.ChannelID, p.ChannelCode, p.Channeldescription as ChannelName  ");
            //sQueryStringMaster.Append(",p.CustomerTypeID, p.CustomerTypeCode, p.CustomerTypeName  ");
            sQueryStringMaster.Append(",p.AreaID, p.AreaCode, p.AreaName  ");
            sQueryStringMaster.Append(",p.TerritoryID, p.TerritoryCode, p.TerritoryName  ");
            //sQueryStringMaster.Append(",p.CustomerID, p.CustomerCode, p.CustomerName,p.IsActive  ");
            //sQueryStringMaster.Append(",isnull(p.ParentCustomerID, p.CustomerID) as ParentCustomerID  ");
            //sQueryStringMaster.Append(",isnull(p.ParentCustomerCode, p.CustomerCode) as ParentCustomerCode  ");
            //sQueryStringMaster.Append(",isnull(p.ParentCustomerName, p.CustomerName) as ParentCustomerName  ");
            sQueryStringMaster.Append(",sum(isnull(JanSales,0))as JanSales, sum(isnull(FebSales,0))as FebSales, sum(isnull(MarSales,0))as MarSales  ");
            sQueryStringMaster.Append(",sum(isnull(AprSales,0))as AprSales, sum(isnull(MaySales,0))as MaySales, sum(isnull(JunSales,0))as JunSales  ");
            sQueryStringMaster.Append(",sum(isnull(JulSales,0))as JulSales, sum(isnull(AugSales,0))as AugSales, sum(isnull(SepSales,0))as SepSales  ");
            sQueryStringMaster.Append(",sum(isnull(OctSales,0))as OctSales, sum(isnull(NovSales,0))as NovSales, sum(isnull(DecSales,0))as DecSales  ");
            sQueryStringMaster.Append(",sum(isnull(JanColl,0))as JanColl, sum(isnull(FebColl,0))as FebColl, sum(isnull(MarColl,0))as MarColl  ");
            sQueryStringMaster.Append(",sum(isnull(AprColl,0))as AprColl, sum(isnull(MayColl,0))as MayColl, sum(isnull(JunColl,0))as JunColl  ");
            sQueryStringMaster.Append(",sum(isnull(JulColl,0))as JulColl, sum(isnull(AugColl,0))as AugColl, sum(isnull(SepColl,0))as SepColl  ");
            sQueryStringMaster.Append(",sum(isnull(OctColl,0))as OctColl, sum(isnull(NovColl,0))as NovColl, sum(isnull(DecColl,0))as DecColl  ");
            sQueryStringMaster.Append(",sum(isnull(CumSalesCYR,0))as CumSalesCYR,sum(isnull(CumCollCYR,0))as CumCollCYR ");
            sQueryStringMaster.Append(",sum(isnull(CumSalesLYR,0))as CumSalesLYR,sum(isnull(CumCollLYR,0))as CumCollLYR ");
            sQueryStringMaster.Append(",sum(isnull(TotalSalesLYR,0))as TotalSalesLYR,sum(isnull(TotalCollLYR,0))as TotalCollLYR  ");
            sQueryStringMaster.Append(",sum(isnull(p11.CurrentOS,0))as CurrentOS, sum(isnull(MonthlyTargetAmt,0)) as TargetTO ");
            sQueryStringMaster.Append("from   ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select * from v_customerDetails    ");
            sQueryStringMaster.Append(")as p   ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select p.CustomerID  ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRJanCYR) - abs(sum(p2.DbJanCYR)),0) as JanSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRFebCYR) - abs(sum(p2.DbFebCYR)),0) as FebSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRMarCYR) - abs(sum(p2.DbMarCYR)),0) as MarSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRAprCYR) - abs(sum(p2.DbAprCYR)),0) as AprSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRMayCYR) - abs(sum(p2.DbMayCYR)),0) as MaySales  ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRJunCYR) - abs(sum(p2.DbJunCYR)),0) as JunSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRJulCYR) - abs(sum(p2.DbJulCYR)),0) as JulSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRAugCYR) - abs(sum(p2.DbAugCYR)),0) as AugSales  ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRSepCYR) - abs(sum(p2.DbSepCYR)),0) as SepSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CROctCYR) - abs(sum(p2.DbOctCYR)),0) as OctSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRNovCYR) - abs(sum(p2.DbNovCYR)),0) as NovSales   ");
            sQueryStringMaster.Append(", isnull(sum(p2.CRDcmCYR) - abs(sum(p2.DbDcmCYR)),0) as DecSales  ");
            sQueryStringMaster.Append("from   ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select * from t_customer    ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as p  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 1 then InvoiceAmount else 0 end) as CRJanCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 2 then InvoiceAmount else 0 end) as CRFebCYR,   ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 3 then InvoiceAmount else 0 end) as CRMarCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 4 then InvoiceAmount else 0 end) as CRAprCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 5 then InvoiceAmount else 0 end) as CRMayCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 6 then InvoiceAmount else 0 end) as CRJunCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 7 then InvoiceAmount else 0 end) as CRJulCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 8 then InvoiceAmount else 0 end) as CRAugCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 9 then InvoiceAmount else 0 end) as CRSepCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 10 then InvoiceAmount else 0 end) as CROctCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 11 then InvoiceAmount else 0 end) as CRNovCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 12 then InvoiceAmount else 0 end) as CRDcmCYR,  ");
            sQueryStringMaster.Append("0 as DbJanCYR, 0 as DbFebCYR, 0 as DbMarCYR, 0 as DbAprCYR, 0 as DbMayCYR, 0 as DbJunCYR,  ");
            sQueryStringMaster.Append("0 as DbJulCYR, 0 as DbAugCYR, 0 as DbSepCYR, 0 as DbOctCYR, 0 as DbNovCYR, 0 as DbDcmCYR  ");
            sQueryStringMaster.Append("from t_salesInvoice im,  t_customer cd  ");
            sQueryStringMaster.Append("where  im.CustomerID = cd.CustomerID and  ");
            sQueryStringMaster.Append("invoicedate between ? and ? and invoicedate< ? and invoicetypeid in (?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("group by  im.CustomerID  ");
            sQueryStringMaster.Append("union all   ");
            sQueryStringMaster.Append("select im.CustomerID,  ");
            sQueryStringMaster.Append("0 as CRJanCYR, 0 as CRFebCYR, 0 as CRMarCYR, 0 as CRAprCYR, 0 as CRMayCYR, 0 as CRJunCYR,  ");
            sQueryStringMaster.Append("0 as CRJulCYR, 0 as CRAugCYR, 0 as CRSepCYR, 0 as CROctCYR, 0 as CRNovCYR, 0 as CRDcmCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 1 then InvoiceAmount else 0 end) as DbJanCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 2 then InvoiceAmount else 0 end) as DbFebCYR,   ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 3 then InvoiceAmount else 0 end) as DbMarCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 4 then InvoiceAmount else 0 end) as DbAprCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 5 then InvoiceAmount else 0 end) as DbMayCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 6 then InvoiceAmount else 0 end) as DbJunCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 7 then InvoiceAmount else 0 end) as DbJulCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 8 then InvoiceAmount else 0 end) as DbAugCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 9 then InvoiceAmount else 0 end) as DbSepCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 10 then InvoiceAmount else 0 end) as DbOctCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 11 then InvoiceAmount else 0 end) as DbNovCYR,  ");
            sQueryStringMaster.Append("sum(case month(invoicedate) when 12 then InvoiceAmount else 0 end) as DbDcmCYR  ");
            sQueryStringMaster.Append("from t_salesInvoice im,  t_customer cd  ");
            sQueryStringMaster.Append("where  im.CustomerID = cd.CustomerID and  ");
            sQueryStringMaster.Append("invoicedate between ? and ? and invoicedate< ? and invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("group by  im.CustomerID  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as p2 on p.CustomerID = p2.CustomerID  ");
            sQueryStringMaster.Append("group by p.customerid  ");
            sQueryStringMaster.Append(")as p2 on p.CustomerID = p2.CustomerID   ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select q1.customerid  ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountJan,0) - isnull(q5.DebitAmountJan,0)) as JanColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountFeb,0) - isnull(q5.DebitAmountFeb,0)) as FebColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountMar,0) - isnull(q5.DebitAmountMar,0)) as MarColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountApr,0) - isnull(q5.DebitAmountApr,0)) as AprColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountMay,0) - isnull(q5.DebitAmountMay,0)) as MayColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountJun,0) - isnull(q5.DebitAmountJun,0)) as JunColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountJul,0) - isnull(q5.DebitAmountJul,0)) as JulColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountAug,0) - isnull(q5.DebitAmountAug,0)) as AugColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountSep,0) - isnull(q5.DebitAmountSep,0)) as SepColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountOct,0) - isnull(q5.DebitAmountOct,0)) as OctColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountNov,0) - isnull(q5.DebitAmountNov,0)) as NovColl   ");
            sQueryStringMaster.Append(", ( isnull(q4.CreditAmountDec,0) - isnull(q5.DebitAmountDec,0)) as DecColl   ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q1  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 1 then Amount else 0 end) as CreditAmountJan  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 2 then Amount else 0 end) as CreditAmountFeb  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 3 then Amount else 0 end) as CreditAmountMar  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 4 then Amount else 0 end) as CreditAmountApr  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 5 then Amount else 0 end) as CreditAmountMay  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 6 then Amount else 0 end) as CreditAmountJun  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 7 then Amount else 0 end) as CreditAmountJul  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 8 then Amount else 0 end) as CreditAmountAug  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 9 then Amount else 0 end) as CreditAmountSep  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 10 then Amount else 0 end) as CreditAmountOct  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 11 then Amount else 0 end) as CreditAmountNov  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 12 then Amount else 0 end) as CreditAmountDec  ");
            sQueryStringMaster.Append("from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.TranDate < ?   ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q4  ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 1 then Amount else 0 end) as DebitAmountJan  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 2 then Amount else 0 end) as DebitAmountFeb  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 3 then Amount else 0 end) as DebitAmountMar  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 4 then Amount else 0 end) as DebitAmountApr  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 5 then Amount else 0 end) as DebitAmountMay  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 6 then Amount else 0 end) as DebitAmountJun  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 7 then Amount else 0 end) as DebitAmountJul  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 8 then Amount else 0 end) as DebitAmountAug  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 9 then Amount else 0 end) as DebitAmountSep  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 10 then Amount else 0 end) as DebitAmountOct  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 11 then Amount else 0 end) as DebitAmountNov  ");
            sQueryStringMaster.Append(",sum(case month(TranDate) when 12 then Amount else 0 end) as DebitAmountDec  ");
            sQueryStringMaster.Append("from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.TranDate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q5  ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as p3  ");
            sQueryStringMaster.Append("on p.Customerid = p3.Customerid   ");

            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as CumSalesCYR     ");
            sQueryStringMaster.Append("From    ");
            sQueryStringMaster.Append("(    ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount    ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)    ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append("union all    ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount,sum(invoiceamount)as drSalesAmount   ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?)   ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append(")as qq1    ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(") as p4  ");
            sQueryStringMaster.Append("on p.Customerid = p4.Customerid  ");
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ( isnull(q4.CreditAmount,0) - isnull(q5.DebitAmount,0)) as CumCollCYR   ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q1  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q4  ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?)  and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q5  ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid  ");
            sQueryStringMaster.Append(")as p5  ");
            sQueryStringMaster.Append("on p.Customerid = p5.Customerid  ");

            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as CumSalesLYR     ");
            sQueryStringMaster.Append("From    ");
            sQueryStringMaster.Append("(    ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount    ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)    ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append("union all    ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount,sum(invoiceamount)as drSalesAmount   ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?)   ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append(")as qq1    ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(") as p8  ");
            sQueryStringMaster.Append("on p.Customerid = p8.Customerid  ");
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ( isnull(q4.CreditAmount,0) - isnull(q5.DebitAmount,0)) as CumCollLYR   ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q1  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q4  ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?)  and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q5  ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid  ");
            sQueryStringMaster.Append(")as p7  ");
            sQueryStringMaster.Append("on p.Customerid = p7.Customerid  ");
            ////////////////////////////
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as TotalSalesLYR     ");
            sQueryStringMaster.Append("From    ");
            sQueryStringMaster.Append("(    ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount    ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)    ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append("union all    ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount,sum(invoiceamount)as drSalesAmount   ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_Customer cd    ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid    ");
            sQueryStringMaster.Append("and InvoiceDate Between ? and ? and invoicedate< ? and im.invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?)   ");
            sQueryStringMaster.Append("Group By im.Customerid    ");
            sQueryStringMaster.Append(")as qq1    ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(") as p9  ");
            sQueryStringMaster.Append("on p.Customerid = p9.Customerid  ");
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ( isnull(q4.CreditAmount,0) - isnull(q5.DebitAmount,0)) as TotalCollLYR   ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q1  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q4  ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?)  and ct.TranDate between ? and ? and ct.trandate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q5  ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid  ");
            sQueryStringMaster.Append(")as p10  ");
            sQueryStringMaster.Append("on p.Customerid = p10.Customerid  ");

            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ((q1.CurrentBalance - isnull(q2.CreditAmount,0) ) + isnull(q3.DebitAmount,0)) as CurrentOS  ");
            sQueryStringMaster.Append("from   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount   ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q1   ");
            sQueryStringMaster.Append("left outer join   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt    ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and transide = ? and ct.TranDate between ? and ? and TranDate < ?  ");
            sQueryStringMaster.Append("group by customerid   ");
            sQueryStringMaster.Append(")    ");
            sQueryStringMaster.Append("as q2   ");
            sQueryStringMaster.Append("on q1.customerid = q2.customerid   ");
            sQueryStringMaster.Append("left outer join   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt    ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and transide = ?  and ct.TranDate between ? and ? and TranDate < ?  ");
            sQueryStringMaster.Append("group by customerid   ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q3   ");
            sQueryStringMaster.Append("on q1.customerid = q3.customerid   ");
            sQueryStringMaster.Append(")as p11  ");
            sQueryStringMaster.Append("on p.customerid = p11.customerid   ");
            //////////////////////////////

            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select MarketGroupID as CustomerID, sum(Turnover)as MonthlyTargetAmt ");
            sQueryStringMaster.Append("From t_PlanBudgetTarget   ");
            sQueryStringMaster.Append("Where plantype in (?) and periodtype in (?) and MarketScopeType in (?)   ");
            sQueryStringMaster.Append("and perioddate between ? and ? ");
            sQueryStringMaster.Append("Group By MarketGroupID ");
            sQueryStringMaster.Append(")as p6 ");
            sQueryStringMaster.Append("on p.Customerid = p6.Customerid  ");

            sQueryStringMaster.Append("group by   ");
            sQueryStringMaster.Append("p.SBUID, p.SBUCode, p.SBUName   ");
            sQueryStringMaster.Append(",p.ChannelID, p.ChannelCode, p.Channeldescription   ");
            //sQueryStringMaster.Append(",p.CustomerTypeID, p.CustomerTypeCode, p.CustomerTypeName  ");
            sQueryStringMaster.Append(",p.AreaID, p.AreaCode, p.AreaName  ");
            sQueryStringMaster.Append(",p.TerritoryID, p.TerritoryCode, p.TerritoryName  ");
            //sQueryStringMaster.Append(",p.CustomerID, p.CustomerCode, p.CustomerName,p.IsActive  ");
            //sQueryStringMaster.Append(",isnull(p.ParentCustomerID, p.CustomerID)  ");
            //sQueryStringMaster.Append(",isnull(p.ParentCustomerCode, p.CustomerCode)  ");
            //sQueryStringMaster.Append(",isnull(p.ParentCustomerName, p.CustomerName)  ");


           
            //Command time out
            cmd.CommandTimeout = 0;
            cmd.CommandText = sQueryStringMaster.ToString();

            //cmd.Parameters.AddWithValue("IsActive", Dictionary.ActiveOrInActiveStatus.ACTIVE);

            cmd.Parameters.AddWithValue("InvoiceDate", dCYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", dCYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);


            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dCYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));



            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dCYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));


            cmd.Parameters.AddWithValue("InvoiceDate", dCYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", dCYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dCYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));



            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dCYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dCYToDate.AddDays(1));

            cmd.Parameters.AddWithValue("InvoiceDate", dLYCFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dLYCToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dLYCToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", dLYCFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dLYCToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dLYCToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dLYCFromDate);
            cmd.Parameters.AddWithValue("TranDate", dLYCToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dLYCToDate.AddDays(1));



            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dLYCFromDate);
            cmd.Parameters.AddWithValue("TranDate", dLYCToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dLYCToDate.AddDays(1));

            cmd.Parameters.AddWithValue("InvoiceDate", dLYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dLYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dLYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", dLYFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dLYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", dLYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dLYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dLYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dLYToDate.AddDays(1));



            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dLYFromDate);
            cmd.Parameters.AddWithValue("TranDate", dLYToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dLYToDate.AddDays(1));


            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionSide.CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dFromDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dToDate.AddDays(1));

            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionSide.DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dFromDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dToDate.AddDays(1));
            cmd.Parameters.AddWithValue("TranDate", dToDate.AddDays(1));

            cmd.Parameters.AddWithValue("PlanType", (short)Dictionary.PlanType.Target);
            cmd.Parameters.AddWithValue("PeriodType", (short)Dictionary.PeriodType.Monthly);
            cmd.Parameters.AddWithValue("MarketScopeType", (short)Dictionary.MarketScopeType.Customer);
            cmd.Parameters.AddWithValue("PeriodDate", dCYFromDate);
            cmd.Parameters.AddWithValue("PeriodDate", dCYToDate.AddDays(1));

            GetMonthlySalesVsCollectionTerritoryWiseData(cmd);
        }
        private void GetMonthlySalesVsCollectionTerritoryWiseData(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptSalesVSCollection oItem = new rptSalesVSCollection();

                    if (reader["SBUID"] != DBNull.Value)
                        oItem.SBUID = Convert.ToInt64(reader["SBUID"]);
                    else oItem.SBUID = -1;
                    if (reader["SBUCode"] != DBNull.Value)
                        oItem.SBUCode = (string)(reader["SBUCode"]);
                    else oItem.SBUCode = "";
                    if (reader["SBUName"] != DBNull.Value)
                        oItem.SBUName = (string)(reader["SBUName"]);
                    else oItem.SBUName = "";

                    if (reader["ChannelId"] != DBNull.Value)
                        oItem.ChannelId = Convert.ToInt64(reader["ChannelId"]);
                    else oItem.ChannelId = -1;
                    if (reader["ChannelCode"] != DBNull.Value)
                        oItem.ChannelCode = (string)(reader["ChannelCode"]);
                    else oItem.ChannelCode = "";
                    if (reader["ChannelName"] != DBNull.Value)
                        oItem.ChannelName = (string)(reader["ChannelName"]);
                    else oItem.ChannelName = "";

                    oItem.CustomerTypeId = -1;
                    oItem.CustomerTypeCode = "";
                    oItem.CustomerTypeName = "";

                    if (reader["AreaId"] != DBNull.Value)
                        oItem.AreaId = Convert.ToInt64(reader["AreaId"]);
                    else oItem.AreaId = -1;
                    if (reader["AreaCode"] != DBNull.Value)
                        oItem.AreaCode = (string)(reader["AreaCode"]);
                    else oItem.AreaCode = "";
                    if (reader["AreaName"] != DBNull.Value)
                        oItem.AreaName = (string)(reader["AreaName"]);
                    else oItem.AreaName = "";

                    oItem.CustomerId = -1;
                    oItem.CustomerCode = "";
                    oItem.CustomerName = "";
                    oItem.IsActive = 1;

                    oItem.ParentCustomerID = -1;
                    oItem.ParentCustomerCode = "";
                    oItem.ParentCustomerName = "";
                    if (reader["TerritoryId"] != DBNull.Value)
                        oItem.TerritoryId = Convert.ToInt64(reader["TerritoryId"]);
                    else oItem.TerritoryId = -1;
                    if (reader["TerritoryCode"] != DBNull.Value)
                        oItem.TerritoryCode = (string)(reader["TerritoryCode"]);
                    else oItem.TerritoryCode = "";
                    if (reader["TerritoryName"] != DBNull.Value)
                        oItem.TerritoryName = (string)(reader["TerritoryName"]);
                    else oItem.TerritoryName = "";

                    if (reader["JanSales"] != DBNull.Value)
                        oItem.JanSales = Convert.ToDouble(reader["JanSales"]);
                    else oItem.JanSales = 0;
                    if (reader["FebSales"] != DBNull.Value)
                        oItem.FebSales = Convert.ToDouble(reader["FebSales"]);
                    else oItem.FebSales = 0;
                    if (reader["MarSales"] != DBNull.Value)
                        oItem.MarSales = Convert.ToDouble(reader["MarSales"]);
                    else oItem.MarSales = 0;
                    if (reader["AprSales"] != DBNull.Value)
                        oItem.AprSales = Convert.ToDouble(reader["AprSales"]);
                    else oItem.AprSales = 0;
                    if (reader["MaySales"] != DBNull.Value)
                        oItem.MaySales = Convert.ToDouble(reader["MaySales"]);
                    else oItem.MaySales = 0;
                    if (reader["JunSales"] != DBNull.Value)
                        oItem.JunSales = Convert.ToDouble(reader["JunSales"]);
                    else oItem.JunSales = 0;
                    if (reader["JulSales"] != DBNull.Value)
                        oItem.JulSales = Convert.ToDouble(reader["JulSales"]);
                    else oItem.JulSales = 0;
                    if (reader["AugSales"] != DBNull.Value)
                        oItem.AugSales = Convert.ToDouble(reader["AugSales"]);
                    else oItem.AugSales = 0;
                    if (reader["SepSales"] != DBNull.Value)
                        oItem.SepSales = Convert.ToDouble(reader["SepSales"]);
                    else oItem.SepSales = 0;
                    if (reader["OctSales"] != DBNull.Value)
                        oItem.OctSales = Convert.ToDouble(reader["OctSales"]);
                    else oItem.OctSales = 0;
                    if (reader["NovSales"] != DBNull.Value)
                        oItem.NovSales = Convert.ToDouble(reader["NovSales"]);
                    else oItem.NovSales = 0;
                    if (reader["DecSales"] != DBNull.Value)
                        oItem.DecSales = Convert.ToDouble(reader["DecSales"]);
                    else oItem.DecSales = 0;

                    if (reader["JanColl"] != DBNull.Value)
                        oItem.JanColl = Convert.ToDouble(reader["JanColl"]);
                    else oItem.JanColl = 0;
                    if (reader["FebColl"] != DBNull.Value)
                        oItem.FebColl = Convert.ToDouble(reader["FebColl"]);
                    else oItem.FebColl = 0;
                    if (reader["MarColl"] != DBNull.Value)
                        oItem.MarColl = Convert.ToDouble(reader["MarColl"]);
                    else oItem.MarColl = 0;
                    if (reader["AprColl"] != DBNull.Value)
                        oItem.AprColl = Convert.ToDouble(reader["AprColl"]);
                    else oItem.AprColl = 0;
                    if (reader["MayColl"] != DBNull.Value)
                        oItem.MayColl = Convert.ToDouble(reader["MayColl"]);
                    else oItem.MayColl = 0;
                    if (reader["JunColl"] != DBNull.Value)
                        oItem.JunColl = Convert.ToDouble(reader["JunColl"]);
                    else oItem.JunColl = 0;
                    if (reader["JulColl"] != DBNull.Value)
                        oItem.JulColl = Convert.ToDouble(reader["JulColl"]);
                    else oItem.JulColl = 0;
                    if (reader["AugColl"] != DBNull.Value)
                        oItem.AugColl = Convert.ToDouble(reader["AugColl"]);
                    else oItem.AugColl = 0;
                    if (reader["SepColl"] != DBNull.Value)
                        oItem.SepColl = Convert.ToDouble(reader["SepColl"]);
                    else oItem.SepColl = 0;
                    if (reader["OctColl"] != DBNull.Value)
                        oItem.OctColl = Convert.ToDouble(reader["OctColl"]);
                    else oItem.OctColl = 0;
                    if (reader["NovColl"] != DBNull.Value)
                        oItem.NovColl = Convert.ToDouble(reader["NovColl"]);
                    else oItem.NovColl = 0;
                    if (reader["DecColl"] != DBNull.Value)
                        oItem.DecColl = Convert.ToDouble(reader["DecColl"]);
                    else oItem.DecColl = 0;

                    if (reader["CumSalesCYR"] != DBNull.Value)
                        oItem.CumSalesCYR = Convert.ToDouble(reader["CumSalesCYR"]);
                    else oItem.CumSalesCYR = 0;
                    if (reader["CumCollCYR"] != DBNull.Value)
                        oItem.CumCollCYR = Convert.ToDouble(reader["CumCollCYR"]);
                    else oItem.CumCollCYR = 0;
                    if (reader["CumSalesLYR"] != DBNull.Value)
                        oItem.CumSalesLYR = Convert.ToDouble(reader["CumSalesLYR"]);
                    else oItem.CumSalesLYR = 0;
                    if (reader["CumCollLYR"] != DBNull.Value)
                        oItem.CumCollLYR = Convert.ToDouble(reader["CumCollLYR"]);
                    else oItem.CumCollLYR = 0;
                    if (reader["TotalSalesLYR"] != DBNull.Value)
                        oItem.TotalSalesLYR = Convert.ToDouble(reader["TotalSalesLYR"]);
                    else oItem.TotalSalesLYR = 0;
                    if (reader["TotalCollLYR"] != DBNull.Value)
                        oItem.TotalCollLYR = Convert.ToDouble(reader["TotalCollLYR"]);
                    else oItem.TotalCollLYR = 0;
                    if (reader["TargetTO"] != DBNull.Value)
                        oItem.TargetTO = Convert.ToDouble(reader["TargetTO"]);
                    else oItem.TargetTO = 0;
                    if (reader["CurrentOS"] != DBNull.Value)
                        oItem.CurrentOS = Convert.ToDouble(reader["CurrentOS"]);
                    else oItem.CurrentOS = 0;


                    Add(oItem);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void FromDataSetTerritoryWise(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    rptSalesVSCollection oItem = new rptSalesVSCollection();


                    oItem.SBUID = Convert.ToInt64(oRow["SBUID"]);
                    oItem.SBUCode = (string)(oRow["SBUCode"]);
                    oItem.SBUName = (string)(oRow["SBUName"]);

                    oItem.ChannelId = Convert.ToInt64(oRow["ChannelId"]);
                    oItem.ChannelCode = (string)(oRow["ChannelCode"]);
                    oItem.ChannelName = (string)(oRow["ChannelName"]);
                    oItem.CustomerTypeId = Convert.ToInt64(oRow["CustomerTypeId"]);
                    oItem.CustomerTypeCode = (string)(oRow["CustomerTypeCode"]);
                    oItem.CustomerTypeName = (string)(oRow["CustomerTypeName"]);
                    oItem.AreaId = Convert.ToInt64(oRow["AreaId"]);
                    oItem.AreaCode = (string)(oRow["AreaCode"]);
                    oItem.AreaName = (string)(oRow["AreaName"]);
                    oItem.CustomerId = Convert.ToInt64(oRow["CustomerId"]);
                    oItem.CustomerCode = (string)(oRow["CustomerCode"]);
                    oItem.CustomerName = (string)(oRow["CustomerName"]);
                    oItem.IsActive = Convert.ToInt16(oRow["IsActive"]);
                    oItem.ParentCustomerID = Convert.ToInt64(oRow["ParentCustomerID"]);
                    oItem.ParentCustomerCode = (string)(oRow["ParentCustomerCode"]);
                    oItem.ParentCustomerName = (string)(oRow["ParentCustomerName"]);
                    oItem.TerritoryId = Convert.ToInt64(oRow["TerritoryId"]);
                    oItem.TerritoryCode = (string)(oRow["TerritoryCode"]);
                    oItem.TerritoryName = (string)(oRow["TerritoryName"]);

                    oItem.JanSales = Convert.ToDouble(oRow["JanSales"]);
                    oItem.FebSales = Convert.ToDouble(oRow["FebSales"]);
                    oItem.MarSales = Convert.ToDouble(oRow["MarSales"]);
                    oItem.AprSales = Convert.ToDouble(oRow["AprSales"]);
                    oItem.MaySales = Convert.ToDouble(oRow["MaySales"]);
                    oItem.JunSales = Convert.ToDouble(oRow["JunSales"]);
                    oItem.JulSales = Convert.ToDouble(oRow["JulSales"]);
                    oItem.AugSales = Convert.ToDouble(oRow["AugSales"]);
                    oItem.SepSales = Convert.ToDouble(oRow["SepSales"]);
                    oItem.OctSales = Convert.ToDouble(oRow["OctSales"]);
                    oItem.NovSales = Convert.ToDouble(oRow["NovSales"]);
                    oItem.DecSales = Convert.ToDouble(oRow["DecSales"]);

                    oItem.JanColl = Convert.ToDouble(oRow["JanColl"]);
                    oItem.FebColl = Convert.ToDouble(oRow["FebColl"]);
                    oItem.MarColl = Convert.ToDouble(oRow["MarColl"]);
                    oItem.AprColl = Convert.ToDouble(oRow["AprColl"]);
                    oItem.MayColl = Convert.ToDouble(oRow["MayColl"]);
                    oItem.JunColl = Convert.ToDouble(oRow["JunColl"]);
                    oItem.JulColl = Convert.ToDouble(oRow["JulColl"]);
                    oItem.AugColl = Convert.ToDouble(oRow["AugColl"]);
                    oItem.SepColl = Convert.ToDouble(oRow["SepColl"]);
                    oItem.OctColl = Convert.ToDouble(oRow["OctColl"]);
                    oItem.NovColl = Convert.ToDouble(oRow["NovColl"]);
                    oItem.DecColl = Convert.ToDouble(oRow["DecColl"]);

                    oItem.CumSalesCYR = Convert.ToDouble(oRow["CumSalesCYR"]);
                    oItem.CumCollCYR = Convert.ToDouble(oRow["CumCollCYR"]);
                    oItem.CumSalesLYR = Convert.ToDouble(oRow["CumSalesLYR"]);
                    oItem.CumCollLYR = Convert.ToDouble(oRow["CumCollLYR"]);
                    oItem.TotalSalesLYR = Convert.ToDouble(oRow["TotalSalesLYR"]);
                    oItem.TotalCollLYR = Convert.ToDouble(oRow["TotalCollLYR"]);
                    oItem.TargetTO = Convert.ToDouble(oRow["TargetTO"]);
                    oItem.CurrentOS = Convert.ToDouble(oRow["CurrentOS"]);

                    InnerList.Add(oItem);
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
