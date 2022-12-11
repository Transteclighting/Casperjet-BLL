// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak kumar Chakraborty
// Date: Feb 15; 2012
// Time :  10:00 AM
// Description: Class for Warehouse Wise Stock Report
// Modify Person And Date:
// </summary> 

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;

namespace CJ.Class.Report
{
    public class RptWarehouseWiseStockReport
    {
        private long _nProductID; 
        private string _sProductCode;
        private string _sProductName;
        private long _nPGID;
        private string _sPGCode;
        private string _sPGName;
        private long _nMAGID;
        private string _sMAGCode;
        private string _sMAGName;
        private long _nASGID;
        private string _sASGCode;
        private string _sASGName;
        private long _nAGID;
        private string _sAGCode;
        private string _sAGName;
        private long _nBrandID;
        private string _sBrandCode;
        private string _sBrandDesc;
        private int _nProductType;
        private double _nCostPrice;
        private double _nTradePrice;
        private double _nNSP; 
        private double _nRSP; 
        private int _nIsActive;
        private double _nW12;
        private double _nW13;
        private double _nW9;
        private double _nW15;
        private double _nW16;
        private double _nW14;
        private double _nW7;
        private double _nW5;
        private double _nW6;
        private double _nW22;
        private double _nW8;
        private double _nW23;
        private double _nW42;
        private double _nW43;
        private double _nW44;
        private double _nW1;
        private double _nW2;
        private double _nW3;
        private double _nW19;
        private double _nW4;

        public long ProductID
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

        public long PGID
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
        public long MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
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
        public long ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
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
        public long AGID
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
        public long BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }
        public string BrandCode
        {
            get { return _sBrandCode; }
            set { _sBrandCode = value; }
        }
        public string BrandDesc
        {
            get { return _sBrandDesc; }
            set { _sBrandDesc = value; }
        }

        public int ProductType
        {
            get { return _nProductType; }
            set { _nProductType = value; }
        }

        public double CostPrice
        {
            get { return _nCostPrice; }
            set { _nCostPrice = value; }
        
        }
        public double TradePrice
        {
            get { return _nTradePrice; }
            set { _nTradePrice = value; }

        }
        public double NSP
        {
            get { return _nNSP; }
            set { _nNSP = value; }

        }
        public double RSP
        {
            get { return _nRSP; }
            set { _nRSP = value; }

        }
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }

        }

        public double W12
        {
            get { return _nW12; }
            set { _nW12 = value; }

        }
        public double W13
        {
            get { return _nW13; }
            set { _nW13 = value; }

        }
        public double W9
        {
            get { return _nW9; }
            set { _nW9 = value; }

        }
        public double W15
        {
            get { return _nW15; }
            set { _nW15 = value; }

        }
        public double W16
        {
            get { return _nW16; }
            set { _nW16 = value; }

        }
        public double W14
        {
            get { return _nW14; }
            set { _nW14 = value; }

        }
        public double W7
        {
            get { return _nW7; }
            set { _nW7 = value; }

        }
        public double W5
        {
            get { return _nW5; }
            set { _nW5 = value; }

        }

        public double W6
        {
            get { return _nW6; }
            set { _nW6 = value; }

        }
        public double W22
        {
            get { return _nW22; }
            set { _nW22 = value; }

        }
        public double W8
        {
            get { return _nW8; }
            set { _nW8 = value; }

        }
        public double W23
        {
            get { return _nW23; }
            set { _nW23 = value; }

        }
        public double W42
        {
            get { return _nW42; }
            set { _nW42 = value; }

        }
        public double W43
        {
            get { return _nW43; }
            set { _nW43 = value; }

        }
        public double W44
        {
            get { return _nW44; }
            set { _nW44 = value; }

        }
        public double W1
        {
            get { return _nW1; }
            set { _nW1 = value; }

        }
        public double W2
        {
            get { return _nW2; }
            set { _nW2 = value; }

        }
        public double W3
        {
            get { return _nW3; }
            set { _nW3 = value; }

        }
        public double W19
        {
            get { return _nW19; }
            set { _nW19 = value; }

        }
        public double W4
        {
            get { return _nW4; }
            set { _nW4 = value; }

        }
                

    }

    public class RptWarehouseWiseStockReportDetails : CollectionBaseCustom
    {
        public void Add(RptWarehouseWiseStockReport oRptWarehouseWiseStockReport)
        {
            this.List.Add(oRptWarehouseWiseStockReport);
        }
        public RptWarehouseWiseStockReport this[Int32 Index]
        {
            get
            {
                return (RptWarehouseWiseStockReport)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(RptWarehouseWiseStockReport))))
                {
                    throw new Exception(" Type can't be converted");
                }
                this.List[Index] = value;
            }
        }


        public void WarehouseWiseStockReport(DateTime dStartDate, DateTime dEndDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            sQueryStringMaster.Append("   	select ProductID, ProductCode, ProductName  	 ");
            sQueryStringMaster.Append("   	, PGID, PGCode, PGName, MAGID, MAGCode, MAGName  	 ");
            sQueryStringMaster.Append("   	, ASGID, ASGCode, ASGName, AGID, AGCode, AGName  	 ");
            sQueryStringMaster.Append("   	, BrandID, BrandCode, BrandDesc ");
            sQueryStringMaster.Append("   	,ProductType, CostPrice, TradePrice, NSP, RSP, IsActive  	 ");
            sQueryStringMaster.Append("   	,W12,W13,W9,W15,W16,W14 ,W7,W5,W6,W22,W8,W23,W42,W43,W44,W1,W2,W3,W19,W4	 ");
            sQueryStringMaster.Append("   	from  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select P1.*  	 ");
            sQueryStringMaster.Append("   	,Isnull(P2.StockQty,0) as  W12, Isnull(P3.StockQty,0) as W13  	 ");
            sQueryStringMaster.Append("   	,Isnull(P4.StockQty,0) as  W9, Isnull(P5.StockQty,0) as W15  	 ");
            sQueryStringMaster.Append("   	,Isnull(P6.StockQty,0) as  W16, Isnull(P7.StockQty,0) as W14  	 ");
            sQueryStringMaster.Append("   	,Isnull(P8.StockQty,0) as  W7, Isnull(P9.StockQty,0) as W5  	 ");
            sQueryStringMaster.Append("   	,Isnull(P10.StockQty,0) as  W6, Isnull(P11.StockQty,0) as W22  	 ");
            sQueryStringMaster.Append("   	,Isnull(P12.StockQty,0) as  W8, Isnull(P13.StockQty,0) as W23  	 ");
            sQueryStringMaster.Append("   	,Isnull(P14.StockQty,0) as  W42, Isnull(P15.StockQty,0) as W43  	 ");
            sQueryStringMaster.Append("   	,Isnull(P16.StockQty,0) as  W44,Isnull(P23.StockQty,0) as  W1	 ");
            sQueryStringMaster.Append("   	,Isnull(P21.StockQty,0) as  W2, Isnull(P22.StockQty,0) as W3  	 ");
            sQueryStringMaster.Append("   	,Isnull(P25.StockQty,0) as  W19,Isnull(P26.StockQty,0) as  W4  	 ");
            sQueryStringMaster.Append("   	from   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select * from v_ProductDetails  	 ");
            sQueryStringMaster.Append("   	)  	 ");
            sQueryStringMaster.Append("   	as P1  	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select x.productid,  	 ");
            sQueryStringMaster.Append("   	((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as StockQty  	 ");
            sQueryStringMaster.Append("   	from   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select Productid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock   	 ");
            sQueryStringMaster.Append("   	where channelid <> 1 and warehouseid <> 1 and warehouseid in ('74')  	 ");
            sQueryStringMaster.Append("   	group by ProductID  	 ");
            sQueryStringMaster.Append("   	) as x   	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and towhid in ('74')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	) as y  	 ");
            sQueryStringMaster.Append("   	on x.productid = y.productid   	 ");
            sQueryStringMaster.Append("   	left outer join   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid,  sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and fromwhid in ('74')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	)   	 ");
            sQueryStringMaster.Append("   	as z  	 ");
            sQueryStringMaster.Append("   	on x.productid = Z.productid   	 ");
            sQueryStringMaster.Append("   	)  	 ");
            sQueryStringMaster.Append("   	as P23  	 ");
            sQueryStringMaster.Append("   	on  	 ");
            sQueryStringMaster.Append("   	p1.ProductID = p23.ProductID  	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select x.productid,  	 ");
            sQueryStringMaster.Append("   	((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as StockQty  	 ");
            sQueryStringMaster.Append("   	from   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select Productid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock   	 ");
            sQueryStringMaster.Append("   	where channelid <> 1 and warehouseid <> 1 and warehouseid in ('68')  	 ");
            sQueryStringMaster.Append("   	group by ProductID  	 ");
            sQueryStringMaster.Append("   	) as x   	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and towhid in ('68')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	) as y  	 ");
            sQueryStringMaster.Append("   	on x.productid = y.productid   	 ");
            sQueryStringMaster.Append("   	left outer join   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid,  sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and fromwhid in ('68')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	)   	 ");
            sQueryStringMaster.Append("   	as z  	 ");
            sQueryStringMaster.Append("   	on x.productid = Z.productid   	 ");
            sQueryStringMaster.Append("   	)  	 ");
            sQueryStringMaster.Append("   	as P2  	 ");
            sQueryStringMaster.Append("   	on  	 ");
            sQueryStringMaster.Append("   	p1.ProductID = p2.ProductID  	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select x.productid,  	 ");
            sQueryStringMaster.Append("   	((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as StockQty  	 ");
            sQueryStringMaster.Append("   	from   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select Productid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock   	 ");
            sQueryStringMaster.Append("   	where channelid <> 1 and warehouseid <> 1 and warehouseid in ('69')  	 ");
            sQueryStringMaster.Append("   	group by ProductID  	 ");
            sQueryStringMaster.Append("   	) as x   	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and towhid in ('69')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	) as y  	 ");
            sQueryStringMaster.Append("   	on x.productid = y.productid   	 ");
            sQueryStringMaster.Append("   	left outer join   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid,  sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and fromwhid in ('69')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	)   	 ");
            sQueryStringMaster.Append("   	as z  	 ");
            sQueryStringMaster.Append("   	on x.productid = Z.productid   	 ");
            sQueryStringMaster.Append("   	)  	 ");
            sQueryStringMaster.Append("   	as P3  	 ");
            sQueryStringMaster.Append("   	on  	 ");
            sQueryStringMaster.Append("   	p1.ProductID = p3.ProductID  	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select x.productid,  	 ");
            sQueryStringMaster.Append("   	((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as StockQty  	 ");
            sQueryStringMaster.Append("   	from   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select Productid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock   	 ");
            sQueryStringMaster.Append("   	where channelid <> 1 and warehouseid <> 1 and warehouseid in ('72')  	 ");
            sQueryStringMaster.Append("   	group by ProductID  	 ");
            sQueryStringMaster.Append("   	) as x   	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and towhid in ('72')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	) as y  	 ");
            sQueryStringMaster.Append("   	on x.productid = y.productid   	 ");
            sQueryStringMaster.Append("   	left outer join   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid,  sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and fromwhid in ('72')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	)   	 ");
            sQueryStringMaster.Append("   	as z  	 ");
            sQueryStringMaster.Append("   	on x.productid = Z.productid   	 ");
            sQueryStringMaster.Append("   	)  	 ");
            sQueryStringMaster.Append("   	as P4  	 ");
            sQueryStringMaster.Append("   	on  	 ");
            sQueryStringMaster.Append("   	p1.ProductID = p4.ProductID  	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select x.productid,  	 ");
            sQueryStringMaster.Append("   	((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as StockQty  	 ");
            sQueryStringMaster.Append("   	from   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select Productid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock   	 ");
            sQueryStringMaster.Append("   	where channelid <> 1 and warehouseid <> 1 and warehouseid in ('65')  	 ");
            sQueryStringMaster.Append("   	group by ProductID  	 ");
            sQueryStringMaster.Append("   	) as x   	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and towhid in ('65')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	) as y  	 ");
            sQueryStringMaster.Append("   	on x.productid = y.productid   	 ");
            sQueryStringMaster.Append("   	left outer join   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid,  sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and fromwhid in ('65')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	)   	 ");
            sQueryStringMaster.Append("   	as z  	 ");
            sQueryStringMaster.Append("   	on x.productid = Z.productid   	 ");
            sQueryStringMaster.Append("   	)  	 ");
            sQueryStringMaster.Append("   	as P5  	 ");
            sQueryStringMaster.Append("   	on  	 ");
            sQueryStringMaster.Append("   	p1.ProductID = p5.ProductID  	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select x.productid,  	 ");
            sQueryStringMaster.Append("   	((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as StockQty  	 ");
            sQueryStringMaster.Append("   	from   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select Productid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock   	 ");
            sQueryStringMaster.Append("   	where channelid <> 1 and warehouseid <> 1 and warehouseid in ('66')  	 ");
            sQueryStringMaster.Append("   	group by ProductID  	 ");
            sQueryStringMaster.Append("   	) as x   	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and towhid in ('66')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	) as y  	 ");
            sQueryStringMaster.Append("   	on x.productid = y.productid   	 ");
            sQueryStringMaster.Append("   	left outer join   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid,  sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and fromwhid in ('66')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	)   	 ");
            sQueryStringMaster.Append("   	as z  	 ");
            sQueryStringMaster.Append("   	on x.productid = Z.productid   	 ");
            sQueryStringMaster.Append("   	)  	 ");
            sQueryStringMaster.Append("   	as P6  	 ");
            sQueryStringMaster.Append("   	on  	 ");
            sQueryStringMaster.Append("   	p1.ProductID = p6.ProductID  	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select x.productid,  	 ");
            sQueryStringMaster.Append("   	((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as StockQty  	 ");
            sQueryStringMaster.Append("   	from   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select Productid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock   	 ");
            sQueryStringMaster.Append("   	where channelid <> 1 and warehouseid <> 1 and warehouseid in ('70')  	 ");
            sQueryStringMaster.Append("   	group by ProductID  	 ");
            sQueryStringMaster.Append("   	) as x   	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and towhid in ('70')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	) as y  	 ");
            sQueryStringMaster.Append("   	on x.productid = y.productid   	 ");
            sQueryStringMaster.Append("   	left outer join   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid,  sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and fromwhid in ('70')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	)   	 ");
            sQueryStringMaster.Append("   	as z  	 ");
            sQueryStringMaster.Append("   	on x.productid = Z.productid   	 ");
            sQueryStringMaster.Append("   	)  	 ");
            sQueryStringMaster.Append("   	as P7  	 ");
            sQueryStringMaster.Append("   	on  	 ");
            sQueryStringMaster.Append("   	p1.ProductID = p7.ProductID  	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select x.productid,  	 ");
            sQueryStringMaster.Append("   	((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as StockQty  	 ");
            sQueryStringMaster.Append("   	from   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select Productid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock   	 ");
            sQueryStringMaster.Append("   	where channelid <> 1 and warehouseid <> 1 and warehouseid in ('71')  	 ");
            sQueryStringMaster.Append("   	group by ProductID  	 ");
            sQueryStringMaster.Append("   	) as x   	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and towhid in ('71')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	) as y  	 ");
            sQueryStringMaster.Append("   	on x.productid = y.productid   	 ");
            sQueryStringMaster.Append("   	left outer join   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid,  sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and fromwhid in ('71')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	)   	 ");
            sQueryStringMaster.Append("   	as z  	 ");
            sQueryStringMaster.Append("   	on x.productid = Z.productid   	 ");
            sQueryStringMaster.Append("   	)  	 ");
            sQueryStringMaster.Append("   	as P8  	 ");
            sQueryStringMaster.Append("   	on  	 ");
            sQueryStringMaster.Append("   	p1.ProductID = p8.ProductID  	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select x.productid,  	 ");
            sQueryStringMaster.Append("   	((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as StockQty  	 ");
            sQueryStringMaster.Append("   	from   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select Productid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock   	 ");
            sQueryStringMaster.Append("   	where channelid <> 1 and warehouseid <> 1 and warehouseid in ('75')  	 ");
            sQueryStringMaster.Append("   	group by ProductID  	 ");
            sQueryStringMaster.Append("   	) as x   	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and towhid in ('75')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	) as y  	 ");
            sQueryStringMaster.Append("   	on x.productid = y.productid   	 ");
            sQueryStringMaster.Append("   	left outer join   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid,  sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and fromwhid in ('75')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	)   	 ");
            sQueryStringMaster.Append("   	as z  	 ");
            sQueryStringMaster.Append("   	on x.productid = Z.productid   	 ");
            sQueryStringMaster.Append("   	)  	 ");
            sQueryStringMaster.Append("   	as P9  	 ");
            sQueryStringMaster.Append("   	on  	 ");
            sQueryStringMaster.Append("   	p1.ProductID = p9.ProductID  	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select x.productid,  	 ");
            sQueryStringMaster.Append("   	((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as StockQty  	 ");
            sQueryStringMaster.Append("   	from   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select Productid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock   	 ");
            sQueryStringMaster.Append("   	where channelid <> 1 and warehouseid <> 1 and warehouseid in ('76')  	 ");
            sQueryStringMaster.Append("   	group by ProductID  	 ");
            sQueryStringMaster.Append("   	) as x   	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and towhid in ('76')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	) as y  	 ");
            sQueryStringMaster.Append("   	on x.productid = y.productid   	 ");
            sQueryStringMaster.Append("   	left outer join   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid,  sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and fromwhid in ('76')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	)   	 ");
            sQueryStringMaster.Append("   	as z  	 ");
            sQueryStringMaster.Append("   	on x.productid = Z.productid   	 ");
            sQueryStringMaster.Append("   	)  	 ");
            sQueryStringMaster.Append("   	as P10  	 ");
            sQueryStringMaster.Append("   	on  	 ");
            sQueryStringMaster.Append("   	p1.ProductID = p10.ProductID  	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select x.productid,  	 ");
            sQueryStringMaster.Append("   	((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as StockQty  	 ");
            sQueryStringMaster.Append("   	from   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select Productid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock   	 ");
            sQueryStringMaster.Append("   	where channelid <> 1 and warehouseid <> 1 and warehouseid in ('10')  	 ");
            sQueryStringMaster.Append("   	group by ProductID  	 ");
            sQueryStringMaster.Append("   	) as x   	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and towhid in ('10')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	) as y  	 ");
            sQueryStringMaster.Append("   	on x.productid = y.productid   	 ");
            sQueryStringMaster.Append("   	left outer join   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid,  sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and fromwhid in ('10')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	)   	 ");
            sQueryStringMaster.Append("   	as z  	 ");
            sQueryStringMaster.Append("   	on x.productid = Z.productid   	 ");
            sQueryStringMaster.Append("   	)  	 ");
            sQueryStringMaster.Append("   	as P11  	 ");
            sQueryStringMaster.Append("   	on  	 ");
            sQueryStringMaster.Append("   	p1.ProductID = p11.ProductID  	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select x.productid,  	 ");
            sQueryStringMaster.Append("   	((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as StockQty  	 ");
            sQueryStringMaster.Append("   	from   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select Productid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock   	 ");
            sQueryStringMaster.Append("   	where channelid <> 1 and warehouseid <> 1 and warehouseid in ('77')  	 ");
            sQueryStringMaster.Append("   	group by ProductID  	 ");
            sQueryStringMaster.Append("   	) as x   	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and towhid in ('77')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	) as y  	 ");
            sQueryStringMaster.Append("   	on x.productid = y.productid   	 ");
            sQueryStringMaster.Append("   	left outer join   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid,  sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and fromwhid in ('77')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	)   	 ");
            sQueryStringMaster.Append("   	as z  	 ");
            sQueryStringMaster.Append("   	on x.productid = Z.productid   	 ");
            sQueryStringMaster.Append("   	)  	 ");
            sQueryStringMaster.Append("   	as P12  	 ");
            sQueryStringMaster.Append("   	on  	 ");
            sQueryStringMaster.Append("   	p1.ProductID = p12.ProductID  	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select x.productid,  	 ");
            sQueryStringMaster.Append("   	((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as StockQty  	 ");
            sQueryStringMaster.Append("   	from   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select Productid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock   	 ");
            sQueryStringMaster.Append("   	where channelid <> 1 and warehouseid <> 1 and warehouseid in ('11')  	 ");
            sQueryStringMaster.Append("   	group by ProductID  	 ");
            sQueryStringMaster.Append("   	) as x   	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and towhid in ('11')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	) as y  	 ");
            sQueryStringMaster.Append("   	on x.productid = y.productid   	 ");
            sQueryStringMaster.Append("   	left outer join   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid,  sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and fromwhid in ('11')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	)   	 ");
            sQueryStringMaster.Append("   	as z  	 ");
            sQueryStringMaster.Append("   	on x.productid = Z.productid   	 ");
            sQueryStringMaster.Append("   	)  	 ");
            sQueryStringMaster.Append("   	as P13  	 ");
            sQueryStringMaster.Append("   	on  	 ");
            sQueryStringMaster.Append("   	p1.ProductID = p13.ProductID  	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select x.productid,  	 ");
            sQueryStringMaster.Append("   	((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as StockQty  	 ");
            sQueryStringMaster.Append("   	from   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select Productid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock   	 ");
            sQueryStringMaster.Append("   	where channelid <> 1 and warehouseid <> 1 and warehouseid in ('2')  	 ");
            sQueryStringMaster.Append("   	group by ProductID  	 ");
            sQueryStringMaster.Append("   	) as x   	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and towhid in ('2')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	) as y  	 ");
            sQueryStringMaster.Append("   	on x.productid = y.productid   	 ");
            sQueryStringMaster.Append("   	left outer join   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid,  sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and fromwhid in ('2')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	)   	 ");
            sQueryStringMaster.Append("   	as z  	 ");
            sQueryStringMaster.Append("   	on x.productid = Z.productid   	 ");
            sQueryStringMaster.Append("   	)  	 ");
            sQueryStringMaster.Append("   	as P14  	 ");
            sQueryStringMaster.Append("   	on  	 ");
            sQueryStringMaster.Append("   	p1.ProductID = p14.ProductID  	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select x.productid,  	 ");
            sQueryStringMaster.Append("   	((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as StockQty  	 ");
            sQueryStringMaster.Append("   	from   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select Productid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock   	 ");
            sQueryStringMaster.Append("   	where channelid <> 1 and warehouseid <> 1 and warehouseid in ('4')  	 ");
            sQueryStringMaster.Append("   	group by ProductID  	 ");
            sQueryStringMaster.Append("   	) as x   	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and towhid in ('4')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	) as y  	 ");
            sQueryStringMaster.Append("   	on x.productid = y.productid   	 ");
            sQueryStringMaster.Append("   	left outer join   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid,  sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and fromwhid in ('4')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	)   	 ");
            sQueryStringMaster.Append("   	as z  	 ");
            sQueryStringMaster.Append("   	on x.productid = Z.productid   	 ");
            sQueryStringMaster.Append("   	)  	 ");
            sQueryStringMaster.Append("   	as P15  	 ");
            sQueryStringMaster.Append("   	on  	 ");
            sQueryStringMaster.Append("   	p1.ProductID = p15.ProductID  	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select x.productid,  	 ");
            sQueryStringMaster.Append("   	((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as StockQty  	 ");
            sQueryStringMaster.Append("   	from   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select Productid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock   	 ");
            sQueryStringMaster.Append("   	where channelid <> 1 and warehouseid <> 1 and warehouseid in ('5')  	 ");
            sQueryStringMaster.Append("   	group by ProductID  	 ");
            sQueryStringMaster.Append("   	) as x   	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and towhid in ('5')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	) as y  	 ");
            sQueryStringMaster.Append("   	on x.productid = y.productid   	 ");
            sQueryStringMaster.Append("   	left outer join   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid,  sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and fromwhid in ('5')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	)   	 ");
            sQueryStringMaster.Append("   	as z  	 ");
            sQueryStringMaster.Append("   	on x.productid = Z.productid   	 ");
            sQueryStringMaster.Append("   	)  	 ");
            sQueryStringMaster.Append("   	as P16  	 ");
            sQueryStringMaster.Append("   	on  	 ");
            sQueryStringMaster.Append("   	p1.ProductID = p16.ProductID  	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select x.productid,  	 ");
            sQueryStringMaster.Append("   	((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as StockQty  	 ");
            sQueryStringMaster.Append("   	from   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select Productid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock   	 ");
            sQueryStringMaster.Append("   	where channelid <> 1 and warehouseid <> 1 and warehouseid in ('95')  	 ");
            sQueryStringMaster.Append("   	group by ProductID  	 ");
            sQueryStringMaster.Append("   	) as x   	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and towhid in ('95')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	) as y  	 ");
            sQueryStringMaster.Append("   	on x.productid = y.productid   	 ");
            sQueryStringMaster.Append("   	left outer join   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid,  sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and fromwhid in ('95')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	)   	 ");
            sQueryStringMaster.Append("   	as z  	 ");
            sQueryStringMaster.Append("   	on x.productid = Z.productid   	 ");
            sQueryStringMaster.Append("   	)  	 ");
            sQueryStringMaster.Append("   	as P21  	 ");
            sQueryStringMaster.Append("   	on  	 ");
            sQueryStringMaster.Append("   	p1.ProductID = p21.ProductID  	 ");
            sQueryStringMaster.Append("   		 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select x.productid,  	 ");
            sQueryStringMaster.Append("   	((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as StockQty  	 ");
            sQueryStringMaster.Append("   	from   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select Productid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock   	 ");
            sQueryStringMaster.Append("   	where channelid <> 1 and warehouseid <> 1 and warehouseid in ('96')  	 ");
            sQueryStringMaster.Append("   	group by ProductID  	 ");
            sQueryStringMaster.Append("   	) as x   	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and towhid in ('96')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	) as y  	 ");
            sQueryStringMaster.Append("   	on x.productid = y.productid   	 ");
            sQueryStringMaster.Append("   	left outer join   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid,  sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and fromwhid in ('96')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	)   	 ");
            sQueryStringMaster.Append("   	as z  	 ");
            sQueryStringMaster.Append("   	on x.productid = Z.productid   	 ");
            sQueryStringMaster.Append("   	)  	 ");
            sQueryStringMaster.Append("   	as P22  	 ");
            sQueryStringMaster.Append("   	on  	 ");
            sQueryStringMaster.Append("   	p1.ProductID = p22.ProductID  	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select x.productid,  	 ");
            sQueryStringMaster.Append("   	((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as StockQty  	 ");
            sQueryStringMaster.Append("   	from   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select Productid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock   	 ");
            sQueryStringMaster.Append("   	where channelid <> 1 and warehouseid <> 1 and warehouseid in ('108')  	 ");
            sQueryStringMaster.Append("   	group by ProductID  	 ");
            sQueryStringMaster.Append("   	) as x   	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and towhid in ('108')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	) as y  	 ");
            sQueryStringMaster.Append("   	on x.productid = y.productid   	 ");
            sQueryStringMaster.Append("   	left outer join   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid,  sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and fromwhid in ('108')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	)   	 ");
            sQueryStringMaster.Append("   	as z  	 ");
            sQueryStringMaster.Append("   	on x.productid = Z.productid   	 ");
            sQueryStringMaster.Append("   	)  	 ");
            sQueryStringMaster.Append("   	as P25  	 ");
            sQueryStringMaster.Append("   	on  	 ");
            sQueryStringMaster.Append("   	p1.ProductID = p25.ProductID  	 ");
            sQueryStringMaster.Append("   		 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select x.productid,  	 ");
            sQueryStringMaster.Append("   	((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as StockQty  	 ");
            sQueryStringMaster.Append("   	from   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select Productid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock   	 ");
            sQueryStringMaster.Append("   	where channelid <> 1 and warehouseid <> 1 and warehouseid in ('111')  	 ");
            sQueryStringMaster.Append("   	group by ProductID  	 ");
            sQueryStringMaster.Append("   	) as x   	 ");
            sQueryStringMaster.Append("   	left outer join  	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and towhid in ('111')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	) as y  	 ");
            sQueryStringMaster.Append("   	on x.productid = y.productid   	 ");
            sQueryStringMaster.Append("   	left outer join   	 ");
            sQueryStringMaster.Append("   	(  	 ");
            sQueryStringMaster.Append("   	select sd.productid,  sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   	 ");
            sQueryStringMaster.Append("   	where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ?  	 ");
            sQueryStringMaster.Append("   	and fromwhid in ('111')  	 ");
            sQueryStringMaster.Append("   	group by sd.productid  	 ");
            sQueryStringMaster.Append("   	)   	 ");
            sQueryStringMaster.Append("   	as z  	 ");
            sQueryStringMaster.Append("   	on x.productid = Z.productid   	 ");
            sQueryStringMaster.Append("   	)  	 ");
            sQueryStringMaster.Append("   	as P26  	 ");
            sQueryStringMaster.Append("   	on  	 ");
            sQueryStringMaster.Append("   	p1.ProductID = p26.ProductID ) as Final order by ProductCode	 ");

            
            OleDbCommand oCmd = DBController.Instance.GetCommand();
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();

            //oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            //oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date);
            //oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date);

            //dStartDate=DateTime.
            //dStartDate = oDSDataDateRange.DataDateRange[0].FromDate;
            //dStartDate = dStartDate.AddDays(1);

            ////dStartDate = new DateTime();
            //dEndDate = oDSSystemDate.SystemDate[0].CurrentDate;
            //dEndDate = dEndDate.AddDays(1);

            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);

            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);

            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);

            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);

            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);

            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);

            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);

            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);

            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);

            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);

            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);

            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);

            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);

            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);

            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);

            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);

            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);

            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);

            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);

            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate);


            GetWarehouseWiseStockReport(oCmd);

        }


        public void GetWarehouseWiseStockReport(OleDbCommand cmd)
        {
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   
                    RptWarehouseWiseStockReport oItem = new RptWarehouseWiseStockReport();

                    
                    if (reader["ProductID"] != DBNull.Value)
                        oItem.ProductID = (int)reader["ProductID"];
                    else oItem.ProductID = -1;

                    if (reader["ProductCode"] != DBNull.Value)
                        oItem.ProductCode = (string)reader["ProductCode"];
                    else oItem.ProductCode = "";

                    if (reader["ProductName"] != DBNull.Value)
                        oItem.ProductName = (string)reader["ProductName"];
                    else oItem.ProductName = "";

                    if (reader["PGID"] != DBNull.Value)
                        oItem.PGID = (int)reader["PGID"];
                    else oItem.PGID = -1;

                    if (reader["PGCode"] != DBNull.Value)
                        oItem.PGCode = (string)reader["PGCode"];
                    else oItem.PGCode = "";

                    if (reader["PGName"] != DBNull.Value)
                        oItem.PGName = (string)reader["PGName"];
                    else oItem.PGName = "";

                    if (reader["MAGID"] != DBNull.Value)
                        oItem.MAGID = (int)reader["MAGID"];
                    else oItem.MAGID = -1;

                    if (reader["MAGCode"] != DBNull.Value)
                        oItem.MAGCode = (string)reader["MAGCode"];
                    else oItem.MAGCode = "";

                    if (reader["MAGName"] != DBNull.Value)
                        oItem.MAGName = (string)reader["MAGName"];
                    else oItem.MAGName = "";

                    if (reader["ASGID"] != DBNull.Value)
                        oItem.ASGID = (int)reader["ASGID"];
                    else oItem.ASGID = -1;

                    if (reader["ASGCode"] != DBNull.Value)
                        oItem.ASGCode = (string)reader["ASGCode"];
                    else oItem.ASGCode = "";                    

                    if (reader["ASGName"] != DBNull.Value)
                        oItem.ASGName = (string)reader["ASGName"];
                    else oItem.ASGName = "";

                    if (reader["AGID"] != DBNull.Value)
                        oItem.AGID = (int)reader["AGID"];
                    else oItem.AGID = -1;

                    if (reader["AGCode"] != DBNull.Value)
                        oItem.AGCode = (string)reader["AGCode"];
                    else oItem.AGCode = ""; 

                    if (reader["AGName"] != DBNull.Value)
                        oItem.AGName = (string)reader["AGName"];
                    else oItem.AGName = "";                   

                    if (reader["BrandID"] != DBNull.Value)
                        oItem.BrandID = (int)reader["BrandID"];
                    else oItem.BrandID = -1;

                    if (reader["BrandCode"] != DBNull.Value)
                        oItem.BrandCode = (string)reader["BrandCode"];
                    else oItem.BrandCode = "";

                    if (reader["BrandDesc"] != DBNull.Value)
                        oItem.BrandDesc = (string)reader["BrandDesc"];
                    else oItem.BrandDesc = "";

                    if (reader["ProductType"] != DBNull.Value)
                        oItem.ProductType = (int)reader["ProductType"];
                    else oItem.ProductType = -1;

                    if (reader["CostPrice"] != DBNull.Value)
                        oItem.CostPrice = Convert.ToDouble(reader["CostPrice"]);
                    else oItem.CostPrice = -1;

                    if (reader["TradePrice"] != DBNull.Value)
                        oItem.TradePrice = Convert.ToDouble(reader["TradePrice"]);
                    else oItem.TradePrice = -1;

                    if (reader["NSP"] != DBNull.Value)
                        oItem.NSP = Convert.ToDouble(reader["NSP"]);
                    else oItem.NSP = -1;

                    if (reader["RSP"] != DBNull.Value)
                        oItem.RSP = Convert.ToDouble(reader["RSP"]);
                    else oItem.RSP = -1;

                    if (reader["IsActive"] != DBNull.Value)
                        oItem.IsActive =Convert.ToInt32(reader["IsActive"]);
                    else oItem.IsActive = -1;


                    if (reader["W12"] != DBNull.Value)
                        oItem.W12 = Convert.ToDouble(reader["W12"]);
                    else oItem.W12 = -1;

                    if (reader["W13"] != DBNull.Value)
                        oItem.W13 = Convert.ToDouble(reader["W13"]);
                    else oItem.W13 = -1;

                    if (reader["W9"] != DBNull.Value)
                        oItem.W9 = Convert.ToDouble(reader["W9"]);
                    else oItem.W9 = -1;

                    if (reader["W15"] != DBNull.Value)
                        oItem.W15 = Convert.ToDouble(reader["W15"]);
                    else oItem.W15 = -1;

                    if (reader["W16"] != DBNull.Value)
                        oItem.W16 = Convert.ToDouble(reader["W16"]);
                    else oItem.W16 = -1;

                    if (reader["W14"] != DBNull.Value)
                        oItem.W14 = Convert.ToDouble(reader["W14"]);
                    else oItem.W14 = -1;

                    if (reader["W7"] != DBNull.Value)
                        oItem.W7 = Convert.ToDouble(reader["W7"]);
                    else oItem.W7 = -1;

                    if (reader["W5"] != DBNull.Value)
                        oItem.W5 = Convert.ToDouble(reader["W5"]);
                    else oItem.W5 = -1;

                    if (reader["W6"] != DBNull.Value)
                        oItem.W6 = Convert.ToDouble(reader["W6"]);
                    else oItem.W6 = -1;

                    if (reader["W22"] != DBNull.Value)
                        oItem.W22 = Convert.ToDouble(reader["W22"]);
                    else oItem.W22 = -1;

                    if (reader["W8"] != DBNull.Value)
                        oItem.W8 = Convert.ToDouble(reader["W8"]);
                    else oItem.W8 = -1;

                    if (reader["W23"] != DBNull.Value)
                        oItem.W23 = Convert.ToDouble(reader["W23"]);
                    else oItem.W23 = -1;

                    if (reader["W42"] != DBNull.Value)
                        oItem.W42 = Convert.ToDouble(reader["W42"]);
                    else oItem.W42 = -1;

                    if (reader["W43"] != DBNull.Value)
                        oItem.W43 = Convert.ToDouble(reader["W43"]);
                    else oItem.W43 = -1;

                    if (reader["W44"] != DBNull.Value)
                        oItem.W44 = Convert.ToDouble(reader["W44"]);
                    else oItem.W44 = -1;

                    if (reader["W1"] != DBNull.Value)
                        oItem.W1 = Convert.ToDouble(reader["W1"]);
                    else oItem.W1 = -1;

                    if (reader["W2"] != DBNull.Value)
                        oItem.W2 = Convert.ToDouble(reader["W2"]);
                    else oItem.W2 = -1;

                    if (reader["W3"] != DBNull.Value)
                        oItem.W3 = Convert.ToDouble(reader["W3"]);
                    else oItem.W3 = -1;

                    if (reader["W19"] != DBNull.Value)
                        oItem.W19 = Convert.ToDouble(reader["W19"]);
                    else oItem.W19 = -1;

                    if (reader["W1"] != DBNull.Value)
                        oItem.W4 = Convert.ToDouble(reader["W4"]);
                    else oItem.W4 = -1;
                    
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

        public void FromDataSetWarehouseWiseStockReport(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    RptWarehouseWiseStockReport oRptWarehouseWiseStockReport = new RptWarehouseWiseStockReport();

                    oRptWarehouseWiseStockReport.ProductID = Convert.ToInt32(oRow["ProductID"]);
                    oRptWarehouseWiseStockReport.ProductCode = (string)oRow["ProductCode"];
                    oRptWarehouseWiseStockReport.ProductName = (string)oRow["ProductName"];

                    oRptWarehouseWiseStockReport.PGID = Convert.ToInt32(oRow["PGID"]);
                    oRptWarehouseWiseStockReport.PGCode = (string)oRow["PGCode"];
                    oRptWarehouseWiseStockReport.PGName = (string)oRow["PGName"];

                    oRptWarehouseWiseStockReport.MAGID = Convert.ToInt32(oRow["MAGID"]);
                    oRptWarehouseWiseStockReport.MAGCode = (string)oRow["MAGCode"];
                    oRptWarehouseWiseStockReport.MAGName = (string)oRow["MAGName"];

                    oRptWarehouseWiseStockReport.ASGID = Convert.ToInt32(oRow["ASGID"]);
                    oRptWarehouseWiseStockReport.ASGCode = (string)oRow["ASGCode"];
                    oRptWarehouseWiseStockReport.ASGName = (string)oRow["ASGName"];

                    oRptWarehouseWiseStockReport.AGID = Convert.ToInt32(oRow["AGID"]);
                    oRptWarehouseWiseStockReport.AGCode = (string)oRow["AGCode"];
                    oRptWarehouseWiseStockReport.AGName = (string)oRow["AGName"];

                    oRptWarehouseWiseStockReport.BrandID = Convert.ToInt32(oRow["BrandID"]);
                    oRptWarehouseWiseStockReport.BrandCode = (string)oRow["BrandCode"];
                    oRptWarehouseWiseStockReport.BrandDesc = (string)oRow["BrandDesc"];

                    oRptWarehouseWiseStockReport.ProductType=Convert.ToInt32( oRow["ProductType"]);
                    oRptWarehouseWiseStockReport.CostPrice=Convert.ToDouble (oRow ["CostPrice"]);
                    oRptWarehouseWiseStockReport.TradePrice=Convert.ToDouble (oRow ["TradePrice"]);

                    oRptWarehouseWiseStockReport.NSP=Convert.ToDouble (oRow ["NSP"]);
                    oRptWarehouseWiseStockReport.RSP=Convert.ToDouble(oRow["RSP"]);
                    oRptWarehouseWiseStockReport.IsActive=Convert.ToInt32(oRow["IsActive"]);

                    oRptWarehouseWiseStockReport.W12= Convert.ToDouble (oRow ["W12"]);
                    oRptWarehouseWiseStockReport.W13=Convert.ToDouble (oRow ["W13"]);
                    oRptWarehouseWiseStockReport.W9 = Convert.ToDouble(oRow["W9"]);

                    oRptWarehouseWiseStockReport.W15 = Convert.ToDouble(oRow["W15"]);
                    oRptWarehouseWiseStockReport.W16 = Convert.ToDouble(oRow["W16"]);
                    oRptWarehouseWiseStockReport.W14 = Convert.ToDouble(oRow["W14"]);
                    oRptWarehouseWiseStockReport.W7 = Convert.ToDouble(oRow["W7"]);

                    oRptWarehouseWiseStockReport.W5 = Convert.ToDouble(oRow["W5"]);
                    oRptWarehouseWiseStockReport.W6 = Convert.ToDouble(oRow["W6"]);
                    oRptWarehouseWiseStockReport.W22 = Convert.ToDouble(oRow["W22"]);

                    oRptWarehouseWiseStockReport.W8 = Convert.ToDouble(oRow["W8"]);
                    oRptWarehouseWiseStockReport.W23 = Convert.ToDouble(oRow["W23"]);
                    oRptWarehouseWiseStockReport.W42 = Convert.ToDouble(oRow["W42"]);

                    oRptWarehouseWiseStockReport.W43 = Convert.ToDouble(oRow["W43"]);
                    oRptWarehouseWiseStockReport.W44 = Convert.ToDouble(oRow["W44"]);
                    oRptWarehouseWiseStockReport.W1 = Convert.ToDouble(oRow["W1"]);

                    oRptWarehouseWiseStockReport.W2 = Convert.ToDouble(oRow["W2"]);
                    oRptWarehouseWiseStockReport.W3 = Convert.ToDouble(oRow["W3"]);
                    oRptWarehouseWiseStockReport.W19 = Convert.ToDouble(oRow["W19"]);
                    oRptWarehouseWiseStockReport.W4 = Convert.ToDouble(oRow["W4"]);

                    InnerList.Add(oRptWarehouseWiseStockReport);
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
