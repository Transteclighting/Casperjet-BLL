/// <summary>
/// Compamy: Transcom Electronics Limited
/// Author: Md. Shahnoor Saeed
/// Date: July 09, 2011
/// Time : 09:43 AM
/// Description: Goods Movement Summary
/// Modify Person And Date:
/// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using System.Data;
using System.Data.OleDb;


namespace CJ.Class.Report
{
    /// <summary>
    /// Database Layer of Warehouse wise Stock Report
    /// </summary>

    [Serializable]
    public class WarehouseStock
    {
        public WarehouseStock()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        
        public 	long	_SBUID;
        public 	string	_SBUCode;
        public 	string	_SBUName;
        public 	long	_ChannelID;
        public 	string	_ChannelName;
        public 	string	_ChannelCode;
        public 	long	_WarehouseParentID;
        public 	string	_WarehouseParentCode;
        public 	string	_WarehouseParentName;
        public 	long	_WarehouseID;
        public 	string	_WarehouseCode;
        public 	string	_WarehouseName;
        //public 	long	_WarehouseCodeInNumber;
        public 	long	_ProductID;
        public 	string	_ProductName;
        public 	string	_ProductCode;
        public 	long	_ProductCodeInNumber;
        public 	short	_IsActive;
        public 	long	_AGID;
        public 	string	_AGName;
        public 	string	_AGCode;
        public 	long	_ASGID;
        public 	string	_ASGName;
        public 	string	_ASGCode;
        public 	long	_MAGID;
        public 	string	_MAGName;
        public 	string	_MAGCode;
        public 	long	_PGID;
        public 	string	_PGName;
        public 	string	_PGCode;
        public 	long	_BrandID;
        public 	string	_BrandName;
        public 	string	_BrandCode;
        public 	long	_OpeningStock;
        public 	double	_OpeningStockValue;
        public 	long	_BookingStock;
        public 	long	_ReceivedStockBYTranfer;
        public 	double	_ReceivedStockBYTranferValue;
        public 	long	_ReceivedStockBYIssue;
        public 	double	_ReceivedStockBYIssueValue;
        public 	long	_GoodsReceived;
        public 	double	_GoodsReceivedValue;
        public 	long	_IssuedStock;
        public 	double	_IssuedStockValue;
        public 	long	_Invoiced;
        public 	double	_InvoicedValue;
        public 	long	_Replacement;
        public 	double	_ReplacementValue;
        public 	long	_RepAdjustment;
        public 	double	_RepAdjustmentValue;
        public 	long	_TransitStockQuantity;
        public 	double	_TransitStockValue;
        public 	long	_AdjustmentPv;
        public 	double	_AdjustmentPvValue;
        public 	long	_ProductReturn;
        public 	double	_ProductReturnValue;
        public 	long	_AdjustmentNv;
        public 	double	_AdjustmentNvValue;
        public 	long	_TranferedStock;
        public 	double	_TranferedStockValue;
        public 	long	_Closing;
        public 	double	_ClosingValue;
        public 	double	_CostPrice;
        public 	double	_NSP;
        public 	double	_RSP;
        public 	double	_UOMConversionFactor;
        public short _ProductType;

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
        public long ChannelID
        {
            get { return _ChannelID; }
            set { _ChannelID = value; }
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
        public long WarehouseParentID
        {
            get { return _WarehouseParentID; }
            set { _WarehouseParentID = value; }
        }
        public string WarehouseParentCode
        {
            get { return _WarehouseParentCode; }
            set { _WarehouseParentCode = value; }
        }
        public string WarehouseParentName
        {
            get { return _WarehouseParentName; }
            set { _WarehouseParentName = value; }
        }
        public long WarehouseID
        {
            get { return _WarehouseID; }
            set { _WarehouseID = value; }
        }
        public string WarehouseCode
        {
            get { return _WarehouseCode; }
            set { _WarehouseCode = value; }
        }
        public string WarehouseName
        {
            get { return _WarehouseName; }
            set { _WarehouseName = value; }
        }
        public long ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }
        public string ProductCode
        {
            get { return _ProductCode; }
            set { _ProductCode = value; }
        }
        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }
        public long ProductCodeInNumber
        {
            get { return _ProductCodeInNumber; }
            set { _ProductCodeInNumber = value; }
        }
        public short IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
        public long PGID
        {
            get { return _PGID; }
            set { _PGID = value; }
        }
        public string PGCode
        {
            get { return _PGCode; }
            set { _PGCode = value; }
        }
        public string PGName
        {
            get { return _PGName; }
            set { _PGName = value; }
        }
        public long MAGID
        {
            get { return _MAGID; }
            set { _MAGID = value; }
        }
        public string MAGCode
        {
            get { return _MAGCode; }
            set { _MAGCode = value; }
        }
        public string MAGName
        {
            get { return _MAGName; }
            set { _MAGName = value; }
        }
        public long ASGID
        {
            get { return _ASGID; }
            set { _ASGID = value; }
        }
        public string ASGCode
        {
            get { return _ASGCode; }
            set { _ASGCode = value; }
        }
        public string ASGName
        {
            get { return _ASGName; }
            set { _ASGName = value; }
        }
        public long AGID
        {
            get { return _AGID; }
            set { _AGID = value; }
        }
        public string AGCode
        {
            get { return _AGCode; }
            set { _AGCode = value; }
        }
        public string AGName
        {
            get { return _AGName; }
            set { _AGName = value; }
        }
        public long BrandID
        {
            get { return _BrandID; }
            set { _BrandID = value; }
        }
        public string BrandCode
        {
            get { return _BrandCode; }
            set { _BrandCode = value; }
        }
        public string BrandName
        {
            get { return _BrandName; }
            set { _BrandName = value; }
        }
        public long OpeningStock
        {
            get { return _OpeningStock; }
            set { _OpeningStock = value; }
        }
        public double OpeningStockValue
        {
            get { return _OpeningStockValue; }
            set { _OpeningStockValue = value; }
        }
        public long BookingStock
        {
            get { return _BookingStock; }
            set { _BookingStock = value; }
        }
        public long ReceivedStockBYTranfer
        {
            get { return _ReceivedStockBYTranfer; }
            set { _ReceivedStockBYTranfer = value; }
        }
        public double ReceivedStockBYTranferValue
        {
            get { return _ReceivedStockBYTranferValue; }
            set { _ReceivedStockBYTranferValue = value; }
        }
        public long ReceivedStockBYIssue
        {
            get { return _ReceivedStockBYIssue; }
            set { _ReceivedStockBYIssue = value; }
        }
        public double ReceivedStockBYIssueValue
        {
            get { return _ReceivedStockBYIssueValue; }
            set { _ReceivedStockBYIssueValue = value; }
        }
        public long GoodsReceived
        {
            get { return _GoodsReceived; }
            set { _GoodsReceived = value; }
        }
        public double GoodsReceivedValue
        {
            get { return _GoodsReceivedValue; }
            set { _GoodsReceivedValue = value; }
        }
        public long IssuedStock
        {
            get { return _IssuedStock; }
            set { _IssuedStock = value; }
        }
        public double IssuedStockValue
        {
            get { return _IssuedStockValue; }
            set { _IssuedStockValue = value; }
        }
        public long Invoiced
        {
            get { return _Invoiced; }
            set { _Invoiced = value; }
        }
        public double InvoicedValue
        {
            get { return _InvoicedValue; }
            set { _InvoicedValue = value; }
        }
        public long Replacement
        {
            get { return _Replacement; }
            set { _Replacement = value; }
        }
        public double ReplacementValue
        {
            get { return _ReplacementValue; }
            set { _ReplacementValue = value; }
        }
        public long RepAdjustment
        {
            get { return _RepAdjustment; }
            set { _RepAdjustment = value; }
        }
        public double RepAdjustmentValue
        {
            get { return _RepAdjustmentValue; }
            set { _RepAdjustmentValue = value; }
        }
        public long TransitStockQuantity
        {
            get { return _TransitStockQuantity; }
            set { _TransitStockQuantity = value; }
        }
        public double TransitStockValue
        {
            get { return _TransitStockValue; }
            set { _TransitStockValue = value; }
        }
        public long AdjustmentPv
        {
            get { return _AdjustmentPv; }
            set { _AdjustmentPv = value; }
        }
        public double AdjustmentPvValue
        {
            get { return _AdjustmentPvValue; }
            set { _AdjustmentPvValue = value; }
        }
        public long ProductReturn
        {
            get { return _ProductReturn; }
            set { _ProductReturn = value; }
        }
        public double ProductReturnValue
        {
            get { return _ProductReturnValue; }
            set { _ProductReturnValue = value; }
        }
        public long AdjustmentNv
        {
            get { return _AdjustmentNv; }
            set { _AdjustmentNv = value; }
        }
        public double AdjustmentNvValue
        {
            get { return _AdjustmentNvValue; }
            set { _AdjustmentNvValue = value; }
        }
        public long TranferedStock
        {
            get { return _TranferedStock; }
            set { _TranferedStock = value; }
        }
        public double TranferedStockValue
        {
            get { return _TranferedStockValue; }
            set { _TranferedStockValue = value; }
        }
        public long Closing
        {
            get { return _Closing; }
            set { _Closing = value; }
        }
        public double ClosingValue
        {
            get { return _ClosingValue; }
            set { _ClosingValue = value; }
        }
        public double CostPrice
        {
            get { return _CostPrice; }
            set { _CostPrice = value; }
        }
        public double NSP
        {
            get { return _NSP; }
            set { _NSP = value; }
        }
        public double RSP
        {
            get { return _RSP; }
            set { _RSP = value; }
        }
        public double UOMConversionFactor
        {
            get { return _UOMConversionFactor; }
            set { _UOMConversionFactor = value; }
        }
        public short ProductType
        {
            get { return _ProductType; }
            set { _ProductType = value; }
        }
       
    }
    public class WarehouseStocks : CollectionBaseCustom
    {

        public void Add(WarehouseStock oWarehouseStock)
        {
            this.List.Add(oWarehouseStock);
        }
        public WarehouseStock this[Int32 Index]
        {
            get
            {
                return (WarehouseStock)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(WarehouseStock))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        public void GoodsMovementSummarySKUWise(DateTime dDFromDate, DateTime dDToDate, string sQueryExpr)
        {
            dDToDate = dDToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();
                        
            sQueryStringMaster.Append(" select     ");
            sQueryStringMaster.Append(" ProductID, ProductCode, ProductName    ");
            sQueryStringMaster.Append(" ,PGID, PGCode, PGName    ");
            sQueryStringMaster.Append(" ,MAGID, MAGCode, MAGName    ");
            sQueryStringMaster.Append(" ,ASGID, ASGCode, ASGName    ");
            sQueryStringMaster.Append(" ,AGID, AGCode, AGName    ");
            sQueryStringMaster.Append(" ,BrandID, BrandCode, BrandDesc as BrandName    ");
            sQueryStringMaster.Append(" ,producttype    ");
            sQueryStringMaster.Append(" ,isnull(NSP,0) NSP,isnull(RSP,0) RSP,isnull(CostPrice,0) CostPrice,IsActive    ");
            sQueryStringMaster.Append(" ,sum(OpenningStock) as OpeningStock, isnull(sum(OpenningStock * CostPrice),0) as OpeningStockValue    ");
            sQueryStringMaster.Append(" ,sum(GoodsReceived) as GoodsReceived    ");
            sQueryStringMaster.Append(" ,sum(ReceivedStockBYTranfer) as ReceivedStockBYTranfer    ");
            sQueryStringMaster.Append(" ,sum(ReceivedStockBYIssue) as ReceivedStockBYIssue    ");
            sQueryStringMaster.Append(" ,sum(AdjustmentPv) as AdjustmentPv    ");
            sQueryStringMaster.Append(" ,sum(ProductReturn) as ProductReturn    ");
            sQueryStringMaster.Append(" ,sum(TranferedStock) as TranferedStock    ");
            sQueryStringMaster.Append(" ,sum(IssuedStock) as IssuedStock    ");
            sQueryStringMaster.Append(" ,sum(Invoiced) as Invoiced    ");
            sQueryStringMaster.Append(" ,sum(AdjustmentNv) as AdjustmentNv    ");
            sQueryStringMaster.Append(" ,sum(RepAdjustment) as RepAdjustment    ");
            sQueryStringMaster.Append(" From    ");
            sQueryStringMaster.Append(" (    ");
            sQueryStringMaster.Append(" select ProductDetails.*, WarehouseDetail.*    ");
            sQueryStringMaster.Append(" ,((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as OpenningStock    ");
            sQueryStringMaster.Append(" ,((x.CurrentStockValue + isnull(z.StockValue,0) ) - isnull(y.StockValue,0)) as OpenningStockValue    ");
            sQueryStringMaster.Append(" ,isnull(GoodsReceived.Qty,0) as GoodsReceived    ");
            sQueryStringMaster.Append(" ,isnull(ReceivedStockBYTranfer.Qty,0) as ReceivedStockBYTranfer    ");
            sQueryStringMaster.Append(" ,isnull(ReceivedStockBYIssue.Qty,0) as ReceivedStockBYIssue    ");
            sQueryStringMaster.Append(" ,isnull(AdjustmentPv.Qty,0) as AdjustmentPv    ");
            sQueryStringMaster.Append(" ,isnull(ProductReturn.Qty,0) as ProductReturn    ");
            sQueryStringMaster.Append(" ,isnull(TranferedStock.Qty,0) as TranferedStock    ");
            sQueryStringMaster.Append(" ,isnull(IssuedStock.Qty,0) as IssuedStock    ");
            sQueryStringMaster.Append(" ,isnull(Invoiced.Qty,0) as Invoiced    ");
            sQueryStringMaster.Append(" ,isnull(AdjustmentNv.Qty,0) as AdjustmentNv    ");
            sQueryStringMaster.Append(" ,isnull(RepAdjustment.Qty,0) as RepAdjustment ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Productid, warehouseid, channelid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock  ");
            sQueryStringMaster.Append("where channelid <> 1 and warehouseid <> 1  ");
            sQueryStringMaster.Append("group by ProductID,warehouseid,channelid ");
            sQueryStringMaster.Append(") as x  ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid,towhid, tochannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ? and trandate < ? and sm.Status=1 ");
            sQueryStringMaster.Append("group by sd.productid,towhid, tochannelid ");
            sQueryStringMaster.Append(") as y ");
            sQueryStringMaster.Append("on x.productid = y.productid and x.channelid = y.tochannelid and x.warehouseid = y.towhid ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Fromwhid, FromChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ?  and trandate < ?  and sm.Status=1 ");
            sQueryStringMaster.Append("group by sd.productid,Fromwhid, FromChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as z ");
            sQueryStringMaster.Append("on x.productid = z.productid and x.channelid = z.FromChannelid and x.warehouseid = z.Fromwhid ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Towhid, ToChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid  and trandate between ? and ?  and trandate < ? and sm.Status=1 ");
            sQueryStringMaster.Append("and trantypeid in (1) ");
            sQueryStringMaster.Append("group by sd.productid,Towhid, ToChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as GoodsReceived ");
            sQueryStringMaster.Append("on x.productid = GoodsReceived.productid and x.channelid = GoodsReceived.ToChannelid and x.warehouseid = GoodsReceived.Towhid ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Towhid,ToChannelID,productid, sum(qty) as Qty from  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select qq1.*, qq2.warehouseparentid as fromWHParentID, qq3.warehouseparentid as TOWhParentID from  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.*, q2.Productid, q2.Qty from t_productStockTran q1,  t_productStockTranItem q2  ");
            sQueryStringMaster.Append("where trantypeid in (3) and trandate between ? and ?  and trandate < ?  and q1.Status=1 ");
            sQueryStringMaster.Append("and q1.tranid = q2.tranid ");
            sQueryStringMaster.Append(") qq1  ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select * from t_warehouse ");
            sQueryStringMaster.Append(") as qq2 on qq1.fromwhid = qq2.warehouseid ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select * from t_warehouse ");
            sQueryStringMaster.Append(") as qq3 on qq1.Towhid = qq3.warehouseid ");
            sQueryStringMaster.Append(") as qqq where fromwhparentid <> towhparentid ");
            sQueryStringMaster.Append("group by Towhid,ToChannelID,productid ");
            sQueryStringMaster.Append(") as ReceivedStockBYTranfer ");
            sQueryStringMaster.Append("on x.productid = ReceivedStockBYTranfer.productid and x.channelid = ReceivedStockBYTranfer.ToChannelid and x.warehouseid = ReceivedStockBYTranfer.Towhid ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Towhid, ToChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid  and trandate between ? and ?  and trandate < ? ");
            sQueryStringMaster.Append("and trantypeid in (4,9,10,13,14,15,16,18,19,20) and sm.Status=1 ");
            sQueryStringMaster.Append("group by sd.productid,Towhid, ToChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as ReceivedStockBYIssue ");
            sQueryStringMaster.Append("on x.productid = ReceivedStockBYIssue.productid and x.channelid = ReceivedStockBYIssue.ToChannelid and x.warehouseid = ReceivedStockBYIssue.Towhid ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Towhid, ToChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid  and trandate between ? and ?  and trandate < ? ");
            sQueryStringMaster.Append("and trantypeid in (5)  and sm.Status=1 ");
            sQueryStringMaster.Append("group by sd.productid,Towhid, ToChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as ProductReturn ");
            sQueryStringMaster.Append("on x.productid = ProductReturn.productid and x.channelid = ProductReturn.ToChannelid and x.warehouseid = ProductReturn.Towhid ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Towhid, ToChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd, t_productstocktrantype stp  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid  and trandate between ? and ?  and trandate < ? ");
            sQueryStringMaster.Append("and stp.TranTypeid = sm.TranTypeID and stp.transactionside = 1 and stp.IsSystem = 2 and sm.Status=1 ");
            sQueryStringMaster.Append("group by sd.productid,Towhid, ToChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as AdjustmentPv ");
            sQueryStringMaster.Append("on x.productid = AdjustmentPv.productid and x.channelid = AdjustmentPv.ToChannelid and x.warehouseid = AdjustmentPv.Towhid ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Fromwhid,FromChannelID,productid, sum(qty) as Qty from  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select qq1.*, qq2.warehouseparentid as fromWHParentID, qq3.warehouseparentid as TOWhParentID from  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.*, q2.Productid, q2.Qty from t_productStockTran q1,  t_productStockTranItem q2  ");
            sQueryStringMaster.Append("where trantypeid in (3) and trandate between ? and ?  and trandate < ?  and q1.Status=1");
            sQueryStringMaster.Append("and q1.tranid = q2.tranid ");
            sQueryStringMaster.Append(") qq1  ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select * from t_warehouse ");
            sQueryStringMaster.Append(") as qq2 on qq1.fromwhid = qq2.warehouseid ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select * from t_warehouse ");
            sQueryStringMaster.Append(") as qq3 on qq1.Towhid = qq3.warehouseid ");
            sQueryStringMaster.Append(") as qqq  ");
            sQueryStringMaster.Append("where fromwhparentid <> towhparentid group by Fromwhid,FromChannelID,productid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as TranferedStock ");
            sQueryStringMaster.Append("on x.productid = TranferedStock.productid and x.channelid = TranferedStock.FromChannelid and x.warehouseid = TranferedStock.Fromwhid ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Fromwhid, FromChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid  and trandate between ? and ?  and trandate < ?  ");
            sQueryStringMaster.Append("and trantypeid in (4,9,10,13,14,15,16,18,19,20) and sm.Status=1 ");
            sQueryStringMaster.Append("group by sd.productid,Fromwhid, FromChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as IssuedStock ");
            sQueryStringMaster.Append("on x.productid = IssuedStock.productid and x.channelid = IssuedStock.FromChannelid and x.warehouseid = IssuedStock.Fromwhid ");

            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Fromwhid, FromChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid  and trandate between ? and ?  and trandate < ? ");
            sQueryStringMaster.Append("and trantypeid in (5)  and sm.status=1 ");
            sQueryStringMaster.Append("group by sd.productid,Fromwhid, FromChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as Invoiced ");
            sQueryStringMaster.Append("on x.productid = Invoiced.productid and x.channelid = Invoiced.FromChannelid and x.warehouseid = Invoiced.Fromwhid ");

            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Fromwhid, FromChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd, t_productstocktrantype stp  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid  and trandate between ? and ?  and trandate < ? ");
            sQueryStringMaster.Append("and stp.TranTypeid = sm.TranTypeID and stp.transactionside = 2 and stp.IsSystem = 2 and sm.trantypeid not in (4,9,10,11,13,14,15,16,17,18,19,20) and sm.status=1 ");
            sQueryStringMaster.Append("group by sd.productid,Fromwhid, FromChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as AdjustmentNv ");
            sQueryStringMaster.Append("on x.productid = AdjustmentNv.productid and x.channelid = AdjustmentNv.FromChannelid and x.warehouseid = AdjustmentNv.Fromwhid ");

            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Fromwhid, FromChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid  and trandate between ? and ?  and trandate < ? ");
            sQueryStringMaster.Append("and trantypeid in (11,17) and sm.status=1 ");
            sQueryStringMaster.Append("group by sd.productid,Fromwhid, FromChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as RepAdjustment ");
            sQueryStringMaster.Append("on x.productid = RepAdjustment.productid and x.channelid = RepAdjustment.FromChannelid and x.warehouseid = RepAdjustment.Fromwhid ");

            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select * from v_ProductDetails ");
            sQueryStringMaster.Append(") ");
            sQueryStringMaster.Append("as ProductDetails ");
            sQueryStringMaster.Append("on x.ProductID = ProductDetails.ProductID ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select WH.WarehouseID, WH.WarehouseCode, WH.WarehouseName ");
            sQueryStringMaster.Append(",WHP.WarehouseParentID, WHP.WarehouseParentCode, WHP.WarehouseParentName ");
            sQueryStringMaster.Append(",CH.ChannelID, CH.ChannelCode, CH.ChannelDescription as ChannelName ");
            sQueryStringMaster.Append(",SBU.SBUID, SBU.SBUCode, SBU.SBUName ");
            sQueryStringMaster.Append("from t_Warehouse WH, t_WarehouseParent WHP, t_channel CH, t_SBU  SBU ");
            sQueryStringMaster.Append("WHERE WH.ChannelID = CH.ChannelID and WH.WarehouseParentID = WHP.WarehouseParentID ");
            sQueryStringMaster.Append("and CH.SBUID = SBU.SBUID ");
            sQueryStringMaster.Append(") ");
            sQueryStringMaster.Append("as WarehouseDetail ");
            sQueryStringMaster.Append("on WarehouseDetail.WarehouseID = x.WarehouseID and WarehouseDetail.ChannelID = x.ChannelID ");
            sQueryStringMaster.Append(" )    ");
            sQueryStringMaster.Append(" as FinalQuery     ");
            if (sQueryExpr != "")
            {
                sQueryStringMaster.Append(sQueryExpr.ToString());
            }

            sQueryStringMaster.Append(" Group By    ");
            sQueryStringMaster.Append(" ProductID, ProductCode, ProductName    ");
            sQueryStringMaster.Append(" ,PGID, PGCode, PGName    ");
            sQueryStringMaster.Append(" ,MAGID, MAGCode, MAGName    ");
            sQueryStringMaster.Append(" ,ASGID, ASGCode, ASGName    ");
            sQueryStringMaster.Append(" ,AGID, AGCode, AGName    ");
            sQueryStringMaster.Append(" ,BrandID, BrandCode, BrandDesc,producttype    ");
            sQueryStringMaster.Append(" ,NSP,RSP,CostPrice,IsActive    ");
            sQueryStringMaster.Append(" having  (sum(OpenningStock) + sum(GoodsReceived)+ sum(ReceivedStockBYTranfer) + sum(ReceivedStockBYIssue)+ sum(AdjustmentPv)+ sum(ProductReturn)) > 0    ");


            OleDbCommand oCmd = DBController.Instance.GetCommand();
            //Command time out
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();


            //Openning stock date range
            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date.AddDays(1));
            //oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date.AddDays(1));
            //oCmd.Parameters.AddWithValue("TranDate", dDToDate);


            //Stock Transaction date range
            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            GetGoodsMovementSummarySKUWise(oCmd);
            
                
            }

        public void GoodsMovementSummarySKUWiseNEW(DateTime dDFromDate, DateTime dDToDate, string sQueryExpr, int nParentWarehouseID, int nWarehouseID, int nIsWarehouseWise)
        {
            dDToDate = dDToDate.AddDays(1);

            string sFromDate= dDFromDate.ToString("dd-MMM-yyyy");
            string sToDate = dDToDate.ToString("dd-MMM-yyyy");
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            if (nIsWarehouseWise == 1)
            {
                sSQL = "Select * From " +
                    "( " +
                    "Select main.ProductID,ProductCode,ProductName,PGID, PGCode,PGName,MAGID, MAGCode, MAGName, " +
                    "ASGID, ASGCode, ASGName,AGID, AGCode,AGName,BrandID, BrandCode, BrandDesc as BrandName,isnull(NSP,0) NSP,isnull(RSP,0) RSP,isnull(CostPrice,0) CostPrice,ProductType, " +
                    "IsActive,sum(CurrentStock) CurrentStock,sum(StockInQty) StockInQty,sum(StockOutQty) StockOutQty,    " +
                    "sum(CurrentStock+StockOutQty-StockInQty) as OpeningStock,  " +
                    "isnull(sum((CurrentStock+StockOutQty-StockInQty) * isnull(CostPrice,0)),0) as OpeningStockValue, " +
                    "sum(GoodsReceived) as GoodsReceived ,sum(ReceivedStockBYTranfer) as ReceivedStockBYTranfer, " +
                    "sum(AdjustmentPv) as AdjustmentPv,sum(ProductReturn) as ProductReturn, " +
                    "sum(TranferedStock) as TranferedStock,sum(IssuedStock) as IssuedStock,sum(Invoiced) as Invoiced , " +
                    "sum(AdjustmentNv) as AdjustmentNv,sum(RepAdjustment) as RepAdjustment , " +
                    "sum(((CurrentStock+StockOutQty-StockInQty)+GoodsReceived+ReceivedStockBYTranfer+AdjustmentPv+ProductReturn)-(Invoiced+TranferedStock+IssuedStock+AdjustmentNv+RepAdjustment)) as Closing , " +
                    "sum((((CurrentStock+StockOutQty-StockInQty)+GoodsReceived+ReceivedStockBYTranfer+AdjustmentPv+ProductReturn)-(Invoiced+TranferedStock+IssuedStock+AdjustmentNv+RepAdjustment))*isnull(CostPrice,0)) as ClosingValue     " +
                    "From  " +
                    "( " +
                    //--CurrentStock---
                    "Select ProductID,CurrentStock,0 as StockInQty,0 as StockOutQty,0 as GoodsReceived,0 as ReceivedStockBYTranfer,0 as ProductReturn, " +
                    "0 as AdjustmentPv,0 as TranferedStock,0 as IssuedStock,0 as Invoiced,0 as AdjustmentNv, " +
                    "0 as RepAdjustment From t_ProductStock a,t_Warehouse b " +
                    "where a.WarehouseID=b.WarehouseID and a.WarehouseID=" + nWarehouseID + "  " +
                    //--and ProductID=5703
                    //--End CurrentStock---
                    "Union All " +
                    //--Total Stock In--
                    "Select ProductID,0 as CurrentStock,Qty as StockInQty,0 as StockOutQty,0 as GoodsReceived,0 as ReceivedStockBYTranfer,0 as ProductReturn, " +
                    "0 as AdjustmentPv,0 as TranferedStock,0 as IssuedStock,0 as Invoiced,0 as AdjustmentNv, " +
                    "0 as RepAdjustment From t_ProductStockTran a,t_ProductStockTranItem b " +
                    "where a.TranID=b.TranID and a.Status=1 and ToWHID=" + nWarehouseID + "  " +
                    "and TranDate between '" + sFromDate + "' and cast(getdate()+1 as Date) and TranDate < cast(getdate()+1 as Date) " +
                    //--and ProductID=5703 
                    //--End Total Stock In--
                    "Union All " +
                    //--Total Stock Out--
                    "Select ProductID,0 as CurrentStock,0 as StockInQty,Qty as StockOutQty,0 as GoodsReceived,0 as ReceivedStockBYTranfer,0 as ProductReturn, " +
                    "0 as AdjustmentPv,0 as TranferedStock,0 as IssuedStock,0 as Invoiced,0 as AdjustmentNv, " +
                    "0 as RepAdjustment From t_ProductStockTran a,t_ProductStockTranItem b " +
                    "where a.TranID=b.TranID and a.Status=1 and FromWHID=" + nWarehouseID + "  " +
                    "and TranDate between '" + sFromDate + "' and cast(getdate()+1 as Date) and TranDate < cast(getdate()+1 as Date) " +
                    //--and ProductID=5703
                    //--End Total Stock Out--
                    "Union All " +
                    //--Stock In--
                    "Select ProductID,0 as CurrentStock,0 as StockInQty,0 as StockOutQty, " +
                    "case when a.TranTypeID=1 then Qty else 0 end as GoodsReceived, " +
                    "case when a.TranTypeID=3 then Qty else 0 end as ReceivedStockBYTranfer, " +
                    "case when a.TranTypeID=5 then Qty else 0 end as ProductReturn, " +
                    "case when a.TranTypeID in (Select TranTypeID from t_ProductStockTranType where TransactionSide = 1 and IsSystem = 2) then Qty else 0 end as AdjustmentPv, " +
                    "0 as TranferedStock,0 as IssuedStock,0 as Invoiced, " +
                    "0 as AdjustmentNv,0 as RepAdjustment From t_ProductStockTran a,t_ProductStockTranItem b " +
                    "where a.TranID=b.TranID and a.Status=1 and ToWHID=" + nWarehouseID + "  " +
                    "and TranDate between '" + sFromDate + "' and '" + sToDate + "' and TranDate < '" + sToDate + "' " +
                    //--and ProductID=5703
                    //--End Stock In--
                    "Union All " +
                    //--Stock Out--
                    "Select ProductID,0 as CurrentStock,0 as StockInQty,0 as StockOutQty,0 GoodsReceived, " +
                    "0 ReceivedStockBYTranfer,0 ProductReturn,0 AdjustmentPv, " +
                    "case when a.TranTypeID=3 then Qty else 0 end as TranferedStock, " +
                    "case when a.TranTypeID in (4,9,10,13,14,15,16,18,19,20) then Qty else 0 end as IssuedStock, " +
                    "case when a.TranTypeID=5 then Qty else 0 end as Invoiced, " +
                    "case when a.TranTypeID not in (3,5,11,17,4,9,10,13,14,15,16,18,19,20) then Qty else 0 end as AdjustmentNv, " +
                    "case when a.TranTypeID in (11,17)  then Qty else 0 end as RepAdjustment " +
                    "From t_ProductStockTran a,t_ProductStockTranItem b  " +
                    "where a.TranID=b.TranID and a.Status=1 and FromWHID=" + nWarehouseID + " " +
                    "and TranDate between '" + sFromDate + "' and '" + sToDate + "' and TranDate < '" + sToDate + "' " +
                    //--and ProductID=5703
                    //--End Stock Out--
                    ") Main,v_ProductDetails pv where Main.ProductID=pv.ProductID  " +
                    "Group By Main.ProductID, ProductCode, ProductName,PGID, PGCode, PGName,MAGID, MAGCode, MAGName, " +
                    "ASGID, ASGCode, ASGName,AGID, AGCode, AGName,BrandID, BrandCode, BrandDesc,producttype,isnull(NSP,0),isnull(RSP,0),isnull(CostPrice,0),IsActive     " +
                    "having  sum(CurrentStock) +sum(StockInQty) +sum(StockOutQty)<> 0     " +
                    ") a";
            }
            else
            {
                sSQL = "Select * From  " +
                    "(  " +
                    "Select main.ProductID,ProductCode,ProductName,PGID, PGCode,PGName,MAGID, MAGCode, MAGName,  " +
                    "ASGID, ASGCode, ASGName,AGID, AGCode,AGName,BrandID, BrandCode, BrandDesc as BrandName,isnull(NSP,0) NSP,isnull(RSP,0) RSP,isnull(CostPrice,0) CostPrice,ProductType,  " +
                    "IsActive,sum(CurrentStock) CurrentStock,sum(StockInQty) StockInQty,sum(StockOutQty) StockOutQty,     " +
                    "sum(CurrentStock+StockOutQty-StockInQty) as OpeningStock,   " +
                    "isnull(sum((CurrentStock+StockOutQty-StockInQty) * isnull(CostPrice,0)),0) as OpeningStockValue,  " +
                    "sum(GoodsReceived) as GoodsReceived ,sum(ReceivedStockBYTranfer) as ReceivedStockBYTranfer,  " +
                    "sum(AdjustmentPv) as AdjustmentPv,sum(ProductReturn) as ProductReturn,  " +
                    "sum(TranferedStock) as TranferedStock,sum(IssuedStock) as IssuedStock,sum(Invoiced) as Invoiced ,  " +
                    "sum(AdjustmentNv) as AdjustmentNv,sum(RepAdjustment) as RepAdjustment ,  " +
                    "sum(((CurrentStock+StockOutQty-StockInQty)+GoodsReceived+ReceivedStockBYTranfer+AdjustmentPv+ProductReturn)-(Invoiced+TranferedStock+IssuedStock+AdjustmentNv+RepAdjustment)) as Closing ,  " +
                    "sum((((CurrentStock+StockOutQty-StockInQty)+GoodsReceived+ReceivedStockBYTranfer+AdjustmentPv+ProductReturn)-(Invoiced+TranferedStock+IssuedStock+AdjustmentNv+RepAdjustment))*isnull(CostPrice,0)) as ClosingValue      " +
                    "From   " +
                    "(  " +
                    //--CurrentStock---
                    "Select ProductID,CurrentStock,0 as StockInQty,0 as StockOutQty,0 as GoodsReceived,0 as ReceivedStockBYTranfer,0 as ProductReturn,  " +
                    "0 as AdjustmentPv,0 as TranferedStock,0 as IssuedStock,0 as Invoiced,0 as AdjustmentNv,  " +
                    "0 as RepAdjustment From t_ProductStock a,t_Warehouse b  " +
                    "where a.WarehouseID=b.WarehouseID and WarehouseParentID=" + nParentWarehouseID + "   " +
                    //--and ProductID=5703
                    //--End CurrentStock---
                    "Union All  " +
                    //--Total Stock In--
                    "Select ProductID,0 as CurrentStock,Qty as StockInQty,0 as StockOutQty,0 as GoodsReceived,0 as ReceivedStockBYTranfer,0 as ProductReturn,  " +
                    "0 as AdjustmentPv,0 as TranferedStock,0 as IssuedStock,0 as Invoiced,0 as AdjustmentNv,  " +
                    "0 as RepAdjustment  " +
                    "From t_ProductStockTran a,t_ProductStockTranItem b,t_Warehouse c  " +
                    "where a.TranID=b.TranID and a.ToWHID=c.WarehouseID and a.Status=1   " +
                    "and WarehouseParentID=" + nParentWarehouseID + " and FromWHID not in (Select WarehouseID from t_Warehouse where WarehouseParentID=" + nParentWarehouseID + ")  " +
                    "and TranDate between '" + sFromDate + "' and cast(getdate()+1 as Date) and TranDate < cast(getdate()+1 as Date)  " +
                    //--and ProductID=5703
                    //--End Total Stock In--
                    "Union All  " +
                    //--Total Stock Out--
                    "Select ProductID,0 as CurrentStock,0 as StockInQty,Qty as StockOutQty,0 as GoodsReceived,0 as ReceivedStockBYTranfer,0 as ProductReturn,  " +
                    "0 as AdjustmentPv,0 as TranferedStock,0 as IssuedStock,0 as Invoiced,0 as AdjustmentNv,  " +
                    "0 as RepAdjustment  " +
                    "From t_ProductStockTran a,t_ProductStockTranItem b,t_Warehouse c  " +
                    "where a.TranID=b.TranID and a.FromWHID=c.WarehouseID and a.Status=1  " +
                    "and WarehouseParentID=" + nParentWarehouseID + " and ToWHID not in (Select WarehouseID from t_Warehouse where WarehouseParentID=" + nParentWarehouseID + ")  " +
                    "and TranDate between '" + sFromDate + "' and cast(getdate()+1 as Date) and TranDate < cast(getdate()+1 as Date)  " +
                    //--and ProductID=5703
                    //--End Total Stock Out--
                    "Union All  " +
                    //--Stock In--
                    "Select ProductID,0 as CurrentStock,0 as StockInQty,0 as StockOutQty,  " +
                    "case when a.TranTypeID=1 then Qty else 0 end as GoodsReceived,  " +
                    "case when a.TranTypeID=3 then Qty else 0 end as ReceivedStockBYTranfer,  " +
                    "case when a.TranTypeID=5 then Qty else 0 end as ProductReturn,  " +
                    "case when a.TranTypeID in (Select TranTypeID from t_ProductStockTranType where TransactionSide = 1 and IsSystem = 2) then Qty else 0 end as AdjustmentPv,  " +
                    "0 as TranferedStock,0 as IssuedStock,0 as Invoiced,  " +
                    "0 as AdjustmentNv,0 as RepAdjustment  " +
                    "From t_ProductStockTran a,t_ProductStockTranItem b,t_Warehouse c  " +
                    "where a.TranID=b.TranID and a.ToWHID=c.WarehouseID and a.Status=1   " +
                    "and WarehouseParentID=" + nParentWarehouseID + " and FromWHID not in (Select WarehouseID from t_Warehouse where WarehouseParentID=" + nParentWarehouseID + ")  " +
                    "and TranDate between '" + sFromDate + "' and '" + sToDate + "' and TranDate < '" + sToDate + "'  " +
                    //--and ProductID=5703
                    //--End Stock In--
                    "Union All  " +
                    //--Stock Out--
                    "Select ProductID,0 as CurrentStock,0 as StockInQty,0 as StockOutQty,0 GoodsReceived,  " +
                    "0 ReceivedStockBYTranfer,0 ProductReturn,0 AdjustmentPv,  " +
                    "case when a.TranTypeID=3 then Qty else 0 end as TranferedStock,  " +
                    "case when a.TranTypeID in (4,9,10,13,14,15,16,18,19,20) then Qty else 0 end as IssuedStock,  " +
                    "case when a.TranTypeID=5 then Qty else 0 end as Invoiced,  " +
                    "case when a.TranTypeID not in (3,5,11,17,4,9,10,13,14,15,16,18,19,20) then Qty else 0 end as AdjustmentNv,  " +
                    "case when a.TranTypeID in (11,17)  then Qty else 0 end as RepAdjustment  " +
                    "From t_ProductStockTran a,t_ProductStockTranItem b,t_Warehouse c  " +
                    "where a.TranID=b.TranID and a.FromWHID=c.WarehouseID and a.Status=1  " +
                    "and WarehouseParentID=" + nParentWarehouseID + " and ToWHID not in (Select WarehouseID from t_Warehouse where WarehouseParentID=" + nParentWarehouseID + ")  " +
                    "and TranDate between '" + sFromDate + "' and '" + sToDate + "' and TranDate < '" + sToDate + "'  " +
                    //--and ProductID=5703
                    //--End Stock Out--
                    ") Main,v_ProductDetails pv where Main.ProductID=pv.ProductID   " +
                    "Group By Main.ProductID, ProductCode, ProductName,PGID, PGCode, PGName,MAGID, MAGCode, MAGName,  " +
                    "ASGID, ASGCode, ASGName,AGID, AGCode, AGName,BrandID, BrandCode, BrandDesc,ProductType,isnull(NSP,0),isnull(RSP,0),isnull(CostPrice,0),IsActive      " +
                    "having  sum(CurrentStock) +sum(StockInQty) +sum(StockOutQty)<> 0      " +
                    ") a ";

            }

            if (sQueryExpr != "")
            {
                sSQL = sSQL + " " + sQueryExpr.ToString();
            }

            OleDbCommand oCmd = DBController.Instance.GetCommand();
            //Command time out
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sSQL.ToString();
             GetGoodsMovementSummarySKUWise(oCmd);


        }
        private void GetGoodsMovementSummarySKUWise(OleDbCommand cmd)
        {
           
            try
            {


                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    WarehouseStock oItem = new WarehouseStock();
                    oItem.SBUID = -1;
                    oItem.SBUCode = "";
                    oItem.SBUName = "";
                    oItem.ChannelID = -1;
                    oItem.ChannelCode = "";
                    oItem.ChannelName = ""; 
                    oItem.WarehouseParentID = -1;
                    oItem.WarehouseParentCode = "";
                    oItem.WarehouseParentName = ""; 
                    oItem.WarehouseID = -1;
                    oItem.WarehouseCode = "";
                    oItem.WarehouseName = "";
                    oItem.ProductID = Convert.ToInt64(reader["ProductID"]);
                    oItem.ProductCode = (string)reader["ProductCode"];
                    oItem.ProductName = (string)reader["ProductName"];
                    try
                    {
                        oItem.ProductCodeInNumber = Convert.ToInt64((string)reader["ProductCode"]);
                    }
                    catch
                    {
                        oItem.ProductCodeInNumber = 1;
                    }
                    oItem.IsActive = Convert.ToInt16(reader["IsActive"]);

                    oItem.AGID = Convert.ToInt64(reader["AGID"]);
                    oItem.AGCode = (string)reader["AGCode"];
                    oItem.AGName = (string)reader["AGName"];
                    oItem.ASGID = Convert.ToInt64(reader["ASGID"]);
                    oItem.ASGCode = (string)reader["ASGCode"];
                    oItem.ASGName = (string)reader["ASGName"];
                    oItem.MAGID = Convert.ToInt64(reader["MAGID"]);
                    oItem.MAGCode = (string)reader["MAGCode"];
                    oItem.MAGName = (string)reader["MAGName"];
                    oItem.PGID = Convert.ToInt64(reader["PGID"]);
                    oItem.PGCode = (string)reader["PGCode"];
                    oItem.PGName = (string)reader["PGName"];
                    oItem.BrandID = Convert.ToInt64(reader["BrandID"]);
                    oItem.BrandCode = (string)reader["BrandCode"];
                    oItem.BrandName = (string)reader["BrandName"];
                    oItem.OpeningStock = Convert.ToInt64(reader["OpeningStock"]);
                    oItem.OpeningStockValue = Convert.ToDouble(reader["OpeningStockValue"]);
                    oItem.BookingStock = 0;
                    oItem.ReceivedStockBYTranfer = Convert.ToInt64(reader["ReceivedStockBYTranfer"]);
                    oItem.ReceivedStockBYTranferValue = 0;
                    //oItem.ReceivedStockBYIssue = Convert.ToInt64(reader["ReceivedStockBYIssue"]);
                    //oItem.ReceivedStockBYIssueValue = 0;
                    oItem.GoodsReceived = Convert.ToInt64(reader["GoodsReceived"]);
                    oItem.GoodsReceivedValue = 0;
                    oItem.IssuedStock = Convert.ToInt64(reader["IssuedStock"]);
                    oItem.IssuedStockValue = 0;
                    oItem.Invoiced = Convert.ToInt64(reader["Invoiced"]);
                    oItem.InvoicedValue = 0;
                    oItem.Replacement = 0;
                    oItem.ReplacementValue = 0; 
                    oItem.RepAdjustment = Convert.ToInt64(reader["RepAdjustment"]);
                    oItem.RepAdjustmentValue = 0;
                    oItem.TransitStockQuantity = 0;
                    oItem.TransitStockValue = 0; 
                    oItem.AdjustmentPv = Convert.ToInt64(reader["AdjustmentPv"]);
                    oItem.AdjustmentPvValue = 0;
                    oItem.ProductReturn = Convert.ToInt64(reader["ProductReturn"]);
                    oItem.ProductReturnValue = 0;
                    oItem.AdjustmentNv = Convert.ToInt64(reader["AdjustmentNv"]);
                    oItem.AdjustmentNvValue = 0;
                    oItem.TranferedStock = Convert.ToInt64(reader["TranferedStock"]);
                    oItem.TranferedStockValue = 0;
                    oItem.Closing = 0;
                    oItem.ClosingValue = 0;
                    oItem.CostPrice = Convert.ToDouble(reader["CostPrice"]);
                    oItem.NSP = Convert.ToDouble(reader["NSP"]);
                    oItem.RSP = Convert.ToDouble(reader["RSP"]);
                    oItem.UOMConversionFactor = 0; 
                    oItem.ProductType = Convert.ToInt16(reader["ProductType"]);

                    //Add(oItem);

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
        public void GoodsMovementSummaryAGWise(DateTime dDFromDate, DateTime dDToDate, string sQueryExpr)
        {
            dDToDate = dDToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            sQueryStringMaster.Append(" select     ");
            sQueryStringMaster.Append(" PGID, PGCode, PGName    ");
            sQueryStringMaster.Append(" ,MAGID, MAGCode, MAGName    ");
            sQueryStringMaster.Append(" ,ASGID, ASGCode, ASGName    ");
            sQueryStringMaster.Append(" ,AGID, AGCode, AGName    ");
            sQueryStringMaster.Append(" ,BrandID, BrandCode, BrandDesc as BrandName    ");
            sQueryStringMaster.Append(" ,sum(OpenningStock) as OpeningStock, isnull(sum(OpenningStock * CostPrice),0) as OpeningStockValue    ");
            sQueryStringMaster.Append(" ,sum(GoodsReceived) as GoodsReceived    ");
            sQueryStringMaster.Append(" ,sum(ReceivedStockBYTranfer) as ReceivedStockBYTranfer    ");
            sQueryStringMaster.Append(" ,sum(ReceivedStockBYIssue) as ReceivedStockBYIssue    ");
            sQueryStringMaster.Append(" ,sum(AdjustmentPv) as AdjustmentPv    ");
            sQueryStringMaster.Append(" ,sum(ProductReturn) as ProductReturn    ");
            sQueryStringMaster.Append(" ,sum(TranferedStock) as TranferedStock    ");
            sQueryStringMaster.Append(" ,sum(IssuedStock) as IssuedStock    ");
            sQueryStringMaster.Append(" ,sum(Invoiced) as Invoiced    ");
            sQueryStringMaster.Append(" ,sum(AdjustmentNv) as AdjustmentNv    ");
            sQueryStringMaster.Append(" ,sum(RepAdjustment) as RepAdjustment    ");
            sQueryStringMaster.Append(" ,sum((OpenningStock+GoodsReceived+ReceivedStockBYTranfer+AdjustmentPv+ProductReturn)-(Invoiced+TranferedStock+IssuedStock+AdjustmentNv+RepAdjustment)) as Closing   ");
            sQueryStringMaster.Append(" ,sum(((OpenningStock+GoodsReceived+ReceivedStockBYTranfer+AdjustmentPv+ProductReturn)-(Invoiced+TranferedStock+IssuedStock+AdjustmentNv+RepAdjustment))*isnull(CostPrice,0)) as ClosingValue  ");
            sQueryStringMaster.Append(" From    ");
            sQueryStringMaster.Append(" (    ");
            sQueryStringMaster.Append(" select ProductDetails.*, WarehouseDetail.*    ");
            sQueryStringMaster.Append(" ,((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as OpenningStock    ");
            sQueryStringMaster.Append(" ,((x.CurrentStockValue + isnull(z.StockValue,0) ) - isnull(y.StockValue,0)) as OpenningStockValue    ");
            sQueryStringMaster.Append(" ,isnull(GoodsReceived.Qty,0) as GoodsReceived    ");
            sQueryStringMaster.Append(" ,isnull(ReceivedStockBYTranfer.Qty,0) as ReceivedStockBYTranfer    ");
            sQueryStringMaster.Append(" ,isnull(ReceivedStockBYIssue.Qty,0) as ReceivedStockBYIssue    ");
            sQueryStringMaster.Append(" ,isnull(AdjustmentPv.Qty,0) as AdjustmentPv    ");
            sQueryStringMaster.Append(" ,isnull(ProductReturn.Qty,0) as ProductReturn    ");
            sQueryStringMaster.Append(" ,isnull(TranferedStock.Qty,0) as TranferedStock    ");
            sQueryStringMaster.Append(" ,isnull(IssuedStock.Qty,0) as IssuedStock    ");
            sQueryStringMaster.Append(" ,isnull(Invoiced.Qty,0) as Invoiced    ");
            sQueryStringMaster.Append(" ,isnull(AdjustmentNv.Qty,0) as AdjustmentNv    ");
            sQueryStringMaster.Append(" ,isnull(RepAdjustment.Qty,0) as RepAdjustment ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Productid, warehouseid, channelid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock  ");
            sQueryStringMaster.Append("where channelid <> 1 and warehouseid <> 1  ");
            sQueryStringMaster.Append("group by ProductID,warehouseid,channelid ");
            sQueryStringMaster.Append(") as x  ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid,towhid, tochannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ? and trandate < ?  and sm.Status=1 ");
            sQueryStringMaster.Append("group by sd.productid,towhid, tochannelid ");
            sQueryStringMaster.Append(") as y ");
            sQueryStringMaster.Append("on x.productid = y.productid and x.channelid = y.tochannelid and x.warehouseid = y.towhid ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Fromwhid, FromChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ?  and trandate < ?  and sm.Status=1 ");
            sQueryStringMaster.Append("group by sd.productid,Fromwhid, FromChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as z ");
            sQueryStringMaster.Append("on x.productid = z.productid and x.channelid = z.FromChannelid and x.warehouseid = z.Fromwhid ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Towhid, ToChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid  and trandate between ? and ?  and trandate < ?  and sm.Status=1 ");
            sQueryStringMaster.Append("and trantypeid in (1) ");
            sQueryStringMaster.Append("group by sd.productid,Towhid, ToChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as GoodsReceived ");
            sQueryStringMaster.Append("on x.productid = GoodsReceived.productid and x.channelid = GoodsReceived.ToChannelid and x.warehouseid = GoodsReceived.Towhid ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Towhid,ToChannelID,productid, sum(qty) as Qty from  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select qq1.*, qq2.warehouseparentid as fromWHParentID, qq3.warehouseparentid as TOWhParentID from  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.*, q2.Productid, q2.Qty from t_productStockTran q1,  t_productStockTranItem q2  ");
            sQueryStringMaster.Append("where trantypeid in (3) and trandate between ? and ?  and trandate < ?  and q1.Status=1  ");
            sQueryStringMaster.Append("and q1.tranid = q2.tranid ");
            sQueryStringMaster.Append(") qq1  ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select * from t_warehouse ");
            sQueryStringMaster.Append(") as qq2 on qq1.fromwhid = qq2.warehouseid ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select * from t_warehouse ");
            sQueryStringMaster.Append(") as qq3 on qq1.Towhid = qq3.warehouseid ");
            sQueryStringMaster.Append(") as qqq where fromwhparentid <> towhparentid ");
            sQueryStringMaster.Append("group by Towhid,ToChannelID,productid ");
            sQueryStringMaster.Append(") as ReceivedStockBYTranfer ");
            sQueryStringMaster.Append("on x.productid = ReceivedStockBYTranfer.productid and x.channelid = ReceivedStockBYTranfer.ToChannelid and x.warehouseid = ReceivedStockBYTranfer.Towhid ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Towhid, ToChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid  and trandate between ? and ?  and trandate < ? ");
            sQueryStringMaster.Append("and trantypeid in (4,9,10,13,14,15,16,18,19,20) and sm.Status=1 ");
            sQueryStringMaster.Append("group by sd.productid,Towhid, ToChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as ReceivedStockBYIssue ");
            sQueryStringMaster.Append("on x.productid = ReceivedStockBYIssue.productid and x.channelid = ReceivedStockBYIssue.ToChannelid and x.warehouseid = ReceivedStockBYIssue.Towhid ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Towhid, ToChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid  and trandate between ? and ?  and trandate < ? ");
            sQueryStringMaster.Append("and trantypeid in (5)  and sm.Status=1 ");
            sQueryStringMaster.Append("group by sd.productid,Towhid, ToChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as ProductReturn ");
            sQueryStringMaster.Append("on x.productid = ProductReturn.productid and x.channelid = ProductReturn.ToChannelid and x.warehouseid = ProductReturn.Towhid ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Towhid, ToChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd, t_productstocktrantype stp  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid  and trandate between ? and ?  and trandate < ?  ");
            sQueryStringMaster.Append("and stp.TranTypeid = sm.TranTypeID and stp.transactionside = 1 and stp.IsSystem = 2 and sm.Status=1 ");
            sQueryStringMaster.Append("group by sd.productid,Towhid, ToChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as AdjustmentPv ");
            sQueryStringMaster.Append("on x.productid = AdjustmentPv.productid and x.channelid = AdjustmentPv.ToChannelid and x.warehouseid = AdjustmentPv.Towhid ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Fromwhid,FromChannelID,productid, sum(qty) as Qty from  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select qq1.*, qq2.warehouseparentid as fromWHParentID, qq3.warehouseparentid as TOWhParentID from  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.*, q2.Productid, q2.Qty from t_productStockTran q1,  t_productStockTranItem q2  ");
            sQueryStringMaster.Append("where trantypeid in (3) and trandate between ? and ?  and trandate < ? ");
            sQueryStringMaster.Append("and q1.tranid = q2.tranid and q1.Status=1 ");
            sQueryStringMaster.Append(") qq1  ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select * from t_warehouse ");
            sQueryStringMaster.Append(") as qq2 on qq1.fromwhid = qq2.warehouseid ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select * from t_warehouse ");
            sQueryStringMaster.Append(") as qq3 on qq1.Towhid = qq3.warehouseid ");
            sQueryStringMaster.Append(") as qqq  ");
            sQueryStringMaster.Append("where fromwhparentid <> towhparentid group by Fromwhid,FromChannelID,productid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as TranferedStock ");
            sQueryStringMaster.Append("on x.productid = TranferedStock.productid and x.channelid = TranferedStock.FromChannelid and x.warehouseid = TranferedStock.Fromwhid ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Fromwhid, FromChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid  and trandate between ? and ?  and trandate < ? ");
            sQueryStringMaster.Append("and trantypeid in (4,9,10,13,14,15,16,18,19,20) and sm.Status=1 ");
            sQueryStringMaster.Append("group by sd.productid,Fromwhid, FromChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as IssuedStock ");
            sQueryStringMaster.Append("on x.productid = IssuedStock.productid and x.channelid = IssuedStock.FromChannelid and x.warehouseid = IssuedStock.Fromwhid ");

            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Fromwhid, FromChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid  and trandate between ? and ?  and trandate < ? ");
            sQueryStringMaster.Append("and trantypeid in (5)  and sm.Status=1 ");
            sQueryStringMaster.Append("group by sd.productid,Fromwhid, FromChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as Invoiced ");
            sQueryStringMaster.Append("on x.productid = Invoiced.productid and x.channelid = Invoiced.FromChannelid and x.warehouseid = Invoiced.Fromwhid ");

            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Fromwhid, FromChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd, t_productstocktrantype stp  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid  and trandate between ? and ?  and trandate < ? ");
            sQueryStringMaster.Append("and stp.TranTypeid = sm.TranTypeID and stp.transactionside = 2 and stp.IsSystem = 2 and sm.trantypeid not in (4,9,10,11,13,14,15,16,17,18,19,20) and sm.Status=1 ");
            sQueryStringMaster.Append("group by sd.productid,Fromwhid, FromChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as AdjustmentNv ");
            sQueryStringMaster.Append("on x.productid = AdjustmentNv.productid and x.channelid = AdjustmentNv.FromChannelid and x.warehouseid = AdjustmentNv.Fromwhid ");

            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Fromwhid, FromChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid  and trandate between ? and ?  and trandate < ? ");
            sQueryStringMaster.Append("and trantypeid in (11,17) and sm.Status=1 ");
            sQueryStringMaster.Append("group by sd.productid,Fromwhid, FromChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as RepAdjustment ");
            sQueryStringMaster.Append("on x.productid = RepAdjustment.productid and x.channelid = RepAdjustment.FromChannelid and x.warehouseid = RepAdjustment.Fromwhid ");

            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select * from v_ProductDetails ");
            sQueryStringMaster.Append(") ");
            sQueryStringMaster.Append("as ProductDetails ");
            sQueryStringMaster.Append("on x.ProductID = ProductDetails.ProductID ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select WH.WarehouseID, WH.WarehouseCode, WH.WarehouseName ");
            sQueryStringMaster.Append(",WHP.WarehouseParentID, WHP.WarehouseParentCode, WHP.WarehouseParentName ");
            sQueryStringMaster.Append(",CH.ChannelID, CH.ChannelCode, CH.ChannelDescription as ChannelName ");
            sQueryStringMaster.Append(",SBU.SBUID, SBU.SBUCode, SBU.SBUName ");
            sQueryStringMaster.Append("from t_Warehouse WH, t_WarehouseParent WHP, t_channel CH, t_SBU  SBU ");
            sQueryStringMaster.Append("WHERE WH.ChannelID = CH.ChannelID and WH.WarehouseParentID = WHP.WarehouseParentID ");
            sQueryStringMaster.Append("and CH.SBUID = SBU.SBUID ");
            sQueryStringMaster.Append(") ");
            sQueryStringMaster.Append("as WarehouseDetail ");
            sQueryStringMaster.Append("on WarehouseDetail.WarehouseID = x.WarehouseID and WarehouseDetail.ChannelID = x.ChannelID ");
            sQueryStringMaster.Append(" )    ");
            sQueryStringMaster.Append(" as FinalQuery     ");
            if (sQueryExpr != "")
            {
                sQueryStringMaster.Append(sQueryExpr.ToString());
            }

            sQueryStringMaster.Append(" Group By    ");
            sQueryStringMaster.Append(" PGID, PGCode, PGName    ");
            sQueryStringMaster.Append(" ,MAGID, MAGCode, MAGName    ");
            sQueryStringMaster.Append(" ,ASGID, ASGCode, ASGName    ");
            sQueryStringMaster.Append(" ,AGID, AGCode, AGName    ");
            sQueryStringMaster.Append(" ,BrandID, BrandCode, BrandDesc ");
            sQueryStringMaster.Append(" having  (sum(OpenningStock) + sum(GoodsReceived)+ sum(ReceivedStockBYTranfer) + sum(ReceivedStockBYIssue)+ sum(AdjustmentPv)+ sum(ProductReturn)) > 0    ");


            OleDbCommand oCmd = DBController.Instance.GetCommand();
            //Command time out
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();


            //Openning stock date range
            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date.AddDays(1));
            //oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date.AddDays(1));
            //oCmd.Parameters.AddWithValue("TranDate", dDToDate);


            //Stock Transaction date range
            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            GetGoodsMovementSummaryAGWise(oCmd);


        }

        public void GoodsMovementSummaryAGWiseNew(DateTime dDFromDate, DateTime dDToDate, string sQueryExpr)
        {
            dDToDate = dDToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "Select PGID, PGCode, PGName,MAGID,MAGCode,MAGName,ASGID,ASGCode,ASGName,AGID, " +
                        "AGCode,AGName,BrandID, BrandCode,BrandName,sum(OpeningStock) as OpeningStock,  " +
                        "isnull(sum(OpeningStock * CostPrice), 0) as OpeningStockValue ,sum(GoodsReceived) as GoodsReceived " +
                        ",sum(ReceivedStockBYTranfer) as ReceivedStockBYTranfer " +
                        ",sum(ReceivedStockBYIssue) as ReceivedStockBYIssue " +
                        ",sum(AdjustmentPv) as AdjustmentPv " +
                        ",sum(ProductReturn) as ProductReturn " +
                        ",sum(TranferedStock) as TranferedStock " +
                        ",sum(IssuedStock) as IssuedStock " +
                        ",sum(Invoiced) as Invoiced " +
                        ",sum(AdjustmentNv) as AdjustmentNv " +
                        ",sum(RepAdjustment) as RepAdjustment " +
                        ",sum((OpeningStock + GoodsReceived + ReceivedStockBYTranfer + AdjustmentPv + ProductReturn) - (Invoiced + TranferedStock + IssuedStock + AdjustmentNv + RepAdjustment)) as Closing " +
                        ",sum(((OpeningStock + GoodsReceived + ReceivedStockBYTranfer + AdjustmentPv + ProductReturn) - (Invoiced + TranferedStock + IssuedStock + AdjustmentNv + RepAdjustment)) * isnull(CostPrice, 0)) as ClosingValue From  " +
                        "( " +
                        "Select WarehouseID,WarehouseParentID,WarehouseParentName,ProductID, ProductCode, ProductName,PGID, PGCode, PGName,MAGID,MAGCode,  " +
                        "MAGName,ASGID, ASGCode, ASGName ,AGID, AGCode, AGName ,BrandID, BrandCode,  " +
                        "BrandDesc as BrandName ,ProductType,isnull(NSP,0) NSP,isnull(RSP,0) RSP, " +
                        "isnull(CostPrice,0) CostPrice,IsActive ,sum(OpeningStock) as OpeningStock,  " +
                        "isnull(sum(OpeningStock * CostPrice),0) as OpeningStockValue , " +
                        "sum(GoodsReceived) as GoodsReceived,sum(ReceivedStockBYTranfer) as ReceivedStockBYTranfer, " +
                        "sum(ReceivedStockBYIssue) as ReceivedStockBYIssue,sum(AdjustmentPv) as AdjustmentPv, " +
                        "sum(ProductReturn) as ProductReturn ,sum(TranferedStock) as TranferedStock,sum(IssuedStock) as IssuedStock, " +
                        "sum(Invoiced) as Invoiced,sum(AdjustmentNv) as AdjustmentNv,sum(RepAdjustment) as RepAdjustment     " +
                        "From     " +
                        "(     " +
                        "select ProductDetails.*, WarehouseDetail.*,OpeningStock ,isnull(GoodsReceived.Qty,0) as GoodsReceived , " +
                        "isnull(ReceivedStockBYTranfer.Qty,0) as ReceivedStockBYTranfer,isnull(ReceivedStockBYIssue.Qty,0) as ReceivedStockBYIssue, " +
                        "isnull(AdjustmentPv.Qty,0) as AdjustmentPv,isnull(ProductReturn.Qty,0) as ProductReturn, " +
                        "isnull(TranferedStock.Qty,0) as TranferedStock,isnull(IssuedStock.Qty,0) as IssuedStock, " +
                        "isnull(Invoiced.Qty,0) as Invoiced,isnull(AdjustmentNv.Qty,0) as AdjustmentNv, " +
                        "isnull(RepAdjustment.Qty,0) as RepAdjustment  " +
                        "from   " +
                        "(  " +
                        "Select main.ProductID,WarehouseID,sum(CurrentStock)+sum(StockOutQty)-sum(StockInQty) as OpeningStock " +
                        "From  " +
                        "( " +
                        "Select WarehouseID,ProductID,0 StockInQty,0 StockOutQty,CurrentStock From t_ProductStock  " +
                        "Union All " +
                        //"---Invoice--- " +
                        "Select WarehouseID,ProductID,0 as StockInQty, " +
                        "case when InvoiceTypeID in (6,7,8,9,10,11,12,16) then (Quantity+FreeQty)*-1 else (Quantity+FreeQty) end as StockOutQty,0 CurrentStock  " +
                        "From t_SalesInvoice a,t_SalesInvoiceDetail b where a.InvoiceID=b.InvoiceID and InvoiceStatus not in (3) " +
                        "and InvoiceDate between '" + dDFromDate + "' and FORMAT(GetDate()+1, 'dd-MMM-yyyy') and InvoiceDate<FORMAT(GetDate()+1, 'dd-MMM-yyyy') " +
                        //"---End Invoice--- " +
                        "Union All " +
                        "Select FromWHID,ProductID,0 as StockInQty,Qty as StockOutQty,0 CurrentStock  " +
                        "From t_ProductStockTran a,t_ProductStockTranItem b " +
                        "where a.TranID=b.TranID and TranDate between '" + dDFromDate + "' and FORMAT(GetDate()+1, 'dd-MMM-yyyy') and TranDate<FORMAT(GetDate()+1, 'dd-MMM-yyyy') " +
                        "and a.Status=1 and TranTypeID<>5 " +
                        "Union All " +
                        "Select ToWHID,ProductID,Qty as StockInQty,0 as StockOutQty,0 CurrentStock " +
                        "From t_ProductStockTran a,t_ProductStockTranItem b " +
                        "where a.TranID=b.TranID and TranDate between '" + dDFromDate + "' and FORMAT(GetDate()+1, 'dd-MMM-yyyy') and TranDate<FORMAT(GetDate()+1, 'dd-MMM-yyyy') " +
                        "and a.Status=1 and TranTypeID<>5 " +
                        ") Main  " +
                        "group by main.ProductID,WarehouseID  " +
                        ") as x   " +
                        "left outer join   " +
                        "(  " +
                        "select sd.productid, Towhid, ToChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   " +
                        "where sd.tranid  = sm.tranid  and trandate between '" + dDFromDate + "' and '" + dDToDate + "'  and trandate < '" + dDToDate + "' and sm.Status=1  " +
                        "and trantypeid in (1)  " +
                        "group by sd.productid,Towhid, ToChannelid  " +
                        ")   " +
                        "as GoodsReceived  " +
                        "on x.productid = GoodsReceived.productid and x.warehouseid = GoodsReceived.Towhid  " +
                        "left outer join   " +
                        "(  " +
                        "select Towhid,ToChannelID,productid, sum(qty) as Qty from   " +
                        "(  " +
                        "select qq1.*, qq2.warehouseparentid as fromWHParentID, qq3.warehouseparentid as TOWhParentID from   " +
                        "(  " +
                        "select q1.*, q2.Productid, q2.Qty from t_productStockTran q1,  t_productStockTranItem q2   " +
                        "where trantypeid in (3) and trandate between '" + dDFromDate + "' and '" + dDToDate + "'  and trandate < '" + dDToDate + "'  and q1.Status=1  " +
                        "and q1.tranid = q2.tranid  " +
                        ") qq1   " +
                        "inner join  " +
                        "(  " +
                        "select * from t_warehouse  " +
                        ") as qq2 on qq1.fromwhid = qq2.warehouseid  " +
                        "inner join  " +
                        "(  " +
                        "select * from t_warehouse  " +
                        ") as qq3 on qq1.Towhid = qq3.warehouseid  " +
                        ") as qqq where fromwhparentid <> towhparentid  " +
                        "group by Towhid,ToChannelID,productid  " +
                        ") as ReceivedStockBYTranfer  " +
                        "on x.productid = ReceivedStockBYTranfer.productid and x.warehouseid = ReceivedStockBYTranfer.Towhid  " +
                        "left outer join   " +
                        "(  " +
                        "select sd.productid, Towhid, ToChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   " +
                        "where sd.tranid  = sm.tranid  and trandate between '" + dDFromDate + "' and '" + dDToDate + "'  and trandate < '" + dDToDate + "'  " +
                        "and trantypeid in (4,9,10,13,14,15,16,18,19,20) and sm.Status=1  " +
                        "group by sd.productid,Towhid, ToChannelid  " +
                        ")   " +
                        "as ReceivedStockBYIssue  " +
                        "on x.productid = ReceivedStockBYIssue.productid and x.warehouseid = ReceivedStockBYIssue.Towhid  " +
                        "left outer join   " +
                        "(  " +
                        "select sd.productid, Towhid, ToChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   " +
                        "where sd.tranid  = sm.tranid  and trandate between '" + dDFromDate + "' and '" + dDToDate + "'  and trandate < '" + dDToDate + "'  " +
                        "and trantypeid in (5)  and sm.Status=1  " +
                        "group by sd.productid,Towhid, ToChannelid  " +
                        ")   " +
                        "as ProductReturn  " +
                        "on x.productid = ProductReturn.productid and x.warehouseid = ProductReturn.Towhid  " +
                        "left outer join   " +
                        "(  " +
                        "select sd.productid, Towhid, ToChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd, t_productstocktrantype stp   " +
                        "where sd.tranid  = sm.tranid  and trandate between '" + dDFromDate + "' and '" + dDToDate + "'  and trandate < '" + dDToDate + "'  " +
                        "and stp.TranTypeid = sm.TranTypeID and stp.transactionside = 1 and stp.IsSystem = 2 and sm.Status=1  " +
                        "group by sd.productid,Towhid, ToChannelid  " +
                        ")   " +
                        "as AdjustmentPv  " +
                        "on x.productid = AdjustmentPv.productid and x.warehouseid = AdjustmentPv.Towhid  " +
                        "left outer join   " +
                        "(  " +
                        "select Fromwhid,FromChannelID,productid, sum(qty) as Qty from   " +
                        "(  " +
                        "select qq1.*, qq2.warehouseparentid as fromWHParentID, qq3.warehouseparentid as TOWhParentID from   " +
                        "(  " +
                        "select q1.*, q2.Productid, q2.Qty from t_productStockTran q1,  t_productStockTranItem q2   " +
                        "where trantypeid in (3) and trandate between '" + dDFromDate + "' and '" + dDToDate + "'  and trandate < '" + dDToDate + "'  and q1.Status=1 " +
                        "and q1.tranid = q2.tranid  " +
                        ") qq1   " +
                        "inner join  " +
                        "(  " +
                        "select * from t_warehouse  " +
                        ") as qq2 on qq1.fromwhid = qq2.warehouseid  " +
                        "inner join  " +
                        "(  " +
                        "select * from t_warehouse  " +
                        ") as qq3 on qq1.Towhid = qq3.warehouseid  " +
                        ") as qqq   " +
                        "where fromwhparentid <> towhparentid group by Fromwhid,FromChannelID,productid  " +
                        ")   " +
                        "as TranferedStock  " +
                        "on x.productid = TranferedStock.productid and x.warehouseid = TranferedStock.Fromwhid  " +
                        "left outer join   " +
                        "(  " +
                        "select sd.productid, Fromwhid, FromChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   " +
                        "where sd.tranid  = sm.tranid  and trandate between '" + dDFromDate + "' and '" + dDToDate + "'  and trandate < '" + dDToDate + "'   " +
                        "and trantypeid in (4,9,10,13,14,15,16,18,19,20) and sm.Status=1  " +
                        "group by sd.productid,Fromwhid, FromChannelid  " +
                        ")   " +
                        "as IssuedStock  " +
                        "on x.productid = IssuedStock.productid and x.warehouseid = IssuedStock.Fromwhid  " +
                        "left outer join   " +
                        "(  " +
                        "select sd.productid, Fromwhid, FromChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   " +
                        "where sd.tranid  = sm.tranid  and trandate between '" + dDFromDate + "' and '" + dDToDate + "'  and trandate < '" + dDToDate + "'  " +
                        "and trantypeid in (5)  and sm.status=1  " +
                        "group by sd.productid,Fromwhid, FromChannelid  " +
                        ")   " +
                        "as Invoiced  " +
                        "on x.productid = Invoiced.productid and x.warehouseid = Invoiced.Fromwhid  " +
                        "left outer join   " +
                        "(  " +
                        "select sd.productid, Fromwhid, FromChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd, t_productstocktrantype stp   " +
                        "where sd.tranid  = sm.tranid  and trandate between '" + dDFromDate + "' and '" + dDToDate + "'  and trandate < '" + dDToDate + "'  " +
                        "and stp.TranTypeid = sm.TranTypeID and stp.transactionside = 2 and stp.IsSystem = 2 and sm.trantypeid not in (4,9,10,11,13,14,15,16,17,18,19,20) and sm.status=1  " +
                        "group by sd.productid,Fromwhid, FromChannelid  " +
                        ")   " +
                        "as AdjustmentNv  " +
                        "on x.productid = AdjustmentNv.productid and x.warehouseid = AdjustmentNv.Fromwhid  " +
                        "left outer join   " +
                        "(  " +
                        "select sd.productid, Fromwhid, FromChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   " +
                        "where sd.tranid  = sm.tranid  and trandate between '" + dDFromDate + "' and '" + dDToDate + "'  and trandate < '" + dDToDate + "'  " +
                        "and trantypeid in (11,17) and sm.status=1  " +
                        "group by sd.productid,Fromwhid, FromChannelid  " +
                        ")   " +
                        "as RepAdjustment  " +
                        "on x.productid = RepAdjustment.productid and x.warehouseid = RepAdjustment.Fromwhid  " +
                        "left outer join  " +
                        "(  " +
                        "select * from v_ProductDetails  " +
                        ")  " +
                        "as ProductDetails  " +
                        "on x.ProductID = ProductDetails.ProductID  " +
                        "left outer join  " +
                        "(  " +
                        "select WH.WarehouseID, WH.WarehouseCode, WH.WarehouseName  " +
                        ",WHP.WarehouseParentID, WHP.WarehouseParentCode, WHP.WarehouseParentName  " +
                        ",CH.ChannelID, CH.ChannelCode, CH.ChannelDescription as ChannelName  " +
                        ",SBU.SBUID, SBU.SBUCode, SBU.SBUName  " +
                        "from t_Warehouse WH, t_WarehouseParent WHP, t_channel CH, t_SBU  SBU  " +
                        "WHERE WH.ChannelID = CH.ChannelID and WH.WarehouseParentID = WHP.WarehouseParentID  " +
                        "and CH.SBUID = SBU.SBUID  " +
                        ")  " +
                        "as WarehouseDetail  " +
                        "on WarehouseDetail.WarehouseID = x.WarehouseID " +
                        ")     " +
                        "as FinalQuery      " +
                        "Group By WarehouseID,WarehouseParentID,WarehouseParentName,ProductID, ProductCode, ProductName ,PGID, PGCode, PGName,MAGID, MAGCode, MAGName,ASGID, ASGCode,  " +
                        "ASGName ,AGID, AGCode, AGName,BrandID, BrandCode, BrandDesc,ProductType,NSP,RSP,CostPrice,IsActive     " +
                        "having  (sum(OpeningStock) + sum(GoodsReceived)+ sum(ReceivedStockBYTranfer) + sum(ReceivedStockBYIssue)+ sum(AdjustmentPv)+ sum(ProductReturn)) > 0     " +
                        ") Main";            

            if (sQueryExpr != "")
            {
                sSQL = sSQL + " " + sQueryExpr.ToString();
            }

            sSQL = sSQL + " group by PGID,PGCode,PGName,MAGID,MAGCode,MAGName,ASGID,ASGCode,ASGName,AGID,AGCode,AGName,BrandID,BrandCode,BrandName";

            OleDbCommand oCmd = DBController.Instance.GetCommand();
            //Command time out
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sSQL.ToString();
            GetGoodsMovementSummaryAGWise(oCmd);


        }

        private void GetGoodsMovementSummaryAGWise(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    WarehouseStock oItem = new WarehouseStock();

                    oItem.SBUID = -1;
                    oItem.SBUCode = "";
                    oItem.SBUName = "";
                    oItem.ChannelID = -1;
                    oItem.ChannelCode = "";
                    oItem.ChannelName = "";
                    oItem.WarehouseParentID = -1;
                    oItem.WarehouseParentCode = "";
                    oItem.WarehouseParentName = "";
                    oItem.WarehouseID = -1;
                    oItem.WarehouseCode = "";
                    oItem.WarehouseName = "";
                    oItem.ProductID = -1;
                    oItem.ProductCode = "";
                    oItem.ProductName = "";
                    oItem.ProductCodeInNumber = -1;
                    oItem.IsActive = -1;

                    oItem.AGID = Convert.ToInt64(reader["AGID"]);
                    oItem.AGCode = (string)reader["AGCode"];
                    oItem.AGName = (string)reader["AGName"];
                    oItem.ASGID = Convert.ToInt64(reader["ASGID"]);
                    oItem.ASGCode = (string)reader["ASGCode"];
                    oItem.ASGName = (string)reader["ASGName"];
                    oItem.MAGID = Convert.ToInt64(reader["MAGID"]);
                    oItem.MAGCode = (string)reader["MAGCode"];
                    oItem.MAGName = (string)reader["MAGName"];
                    oItem.PGID = Convert.ToInt64(reader["PGID"]);
                    oItem.PGCode = (string)reader["PGCode"];
                    oItem.PGName = (string)reader["PGName"];
                    oItem.BrandID = Convert.ToInt64(reader["BrandID"]);
                    oItem.BrandCode = (string)reader["BrandCode"];
                    oItem.BrandName = (string)reader["BrandName"];
                    oItem.OpeningStock = Convert.ToInt64(reader["OpeningStock"]);
                    oItem.OpeningStockValue = Convert.ToDouble(reader["OpeningStockValue"]);
                    oItem.BookingStock = 0;
                    oItem.ReceivedStockBYTranfer = Convert.ToInt64(reader["ReceivedStockBYTranfer"]);
                    oItem.ReceivedStockBYTranferValue = 0;
                    oItem.ReceivedStockBYIssue = Convert.ToInt64(reader["ReceivedStockBYIssue"]);
                    oItem.ReceivedStockBYIssueValue = 0;
                    oItem.GoodsReceived = Convert.ToInt64(reader["GoodsReceived"]);
                    oItem.GoodsReceivedValue = 0;
                    oItem.IssuedStock = Convert.ToInt64(reader["IssuedStock"]);
                    oItem.IssuedStockValue = 0;
                    oItem.Invoiced = Convert.ToInt64(reader["Invoiced"]);
                    oItem.InvoicedValue = 0;
                    oItem.Replacement = 0;
                    oItem.ReplacementValue = 0;
                    oItem.RepAdjustment = Convert.ToInt64(reader["RepAdjustment"]);
                    oItem.RepAdjustmentValue = 0;
                    oItem.TransitStockQuantity = 0;
                    oItem.TransitStockValue = 0;
                    oItem.AdjustmentPv = Convert.ToInt64(reader["AdjustmentPv"]);
                    oItem.AdjustmentPvValue = 0;
                    oItem.ProductReturn = Convert.ToInt64(reader["ProductReturn"]);
                    oItem.ProductReturnValue = 0;
                    oItem.AdjustmentNv = Convert.ToInt64(reader["AdjustmentNv"]);
                    oItem.AdjustmentNvValue = 0;
                    oItem.TranferedStock = Convert.ToInt64(reader["TranferedStock"]);
                    oItem.TranferedStockValue = 0;
                    oItem.Closing = Convert.ToInt64(reader["Closing"]);
                    oItem.ClosingValue = Convert.ToDouble(reader["ClosingValue"]);
                    oItem.CostPrice = 0;
                    oItem.NSP = 0;
                    oItem.RSP = 0;
                    oItem.UOMConversionFactor = 0;
                    oItem.ProductType = -1;

                    Add(oItem);

                    //InnerList.Add(oItem);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GoodsMovementSummaryASGWise(DateTime dDFromDate, DateTime dDToDate, string sQueryExpr)
        {
            dDToDate = dDToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            sQueryStringMaster.Append(" select     ");
            sQueryStringMaster.Append(" PGID, PGCode, PGName    ");
            sQueryStringMaster.Append(" ,MAGID, MAGCode, MAGName    ");
            sQueryStringMaster.Append(" ,ASGID, ASGCode, ASGName    ");
            sQueryStringMaster.Append(" ,BrandID, BrandCode, BrandDesc as BrandName    ");
            sQueryStringMaster.Append(" ,sum(OpenningStock) as OpeningStock, isnull(sum(OpenningStock * CostPrice),0) as OpeningStockValue    ");
            sQueryStringMaster.Append(" ,sum(GoodsReceived) as GoodsReceived    ");
            sQueryStringMaster.Append(" ,sum(ReceivedStockBYTranfer) as ReceivedStockBYTranfer    ");
            sQueryStringMaster.Append(" ,sum(ReceivedStockBYIssue) as ReceivedStockBYIssue    ");
            sQueryStringMaster.Append(" ,sum(AdjustmentPv) as AdjustmentPv    ");
            sQueryStringMaster.Append(" ,sum(ProductReturn) as ProductReturn    ");
            sQueryStringMaster.Append(" ,sum(TranferedStock) as TranferedStock    ");
            sQueryStringMaster.Append(" ,sum(IssuedStock) as IssuedStock    ");
            sQueryStringMaster.Append(" ,sum(Invoiced) as Invoiced    ");
            sQueryStringMaster.Append(" ,sum(AdjustmentNv) as AdjustmentNv    ");
            sQueryStringMaster.Append(" ,sum(RepAdjustment) as RepAdjustment    ");
            sQueryStringMaster.Append(" ,sum((OpenningStock+GoodsReceived+ReceivedStockBYTranfer+AdjustmentPv+ProductReturn)-(Invoiced+TranferedStock+IssuedStock+AdjustmentNv+RepAdjustment)) as Closing   ");
            sQueryStringMaster.Append(" ,sum(((OpenningStock+GoodsReceived+ReceivedStockBYTranfer+AdjustmentPv+ProductReturn)-(Invoiced+TranferedStock+IssuedStock+AdjustmentNv+RepAdjustment))*isnull(CostPrice,0)) as ClosingValue  ");
            sQueryStringMaster.Append(" From    ");
            sQueryStringMaster.Append(" (    ");
            sQueryStringMaster.Append(" select ProductDetails.*, WarehouseDetail.*    ");
            sQueryStringMaster.Append(" ,((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as OpenningStock    ");
            sQueryStringMaster.Append(" ,((x.CurrentStockValue + isnull(z.StockValue,0) ) - isnull(y.StockValue,0)) as OpenningStockValue    ");
            sQueryStringMaster.Append(" ,isnull(GoodsReceived.Qty,0) as GoodsReceived    ");
            sQueryStringMaster.Append(" ,isnull(ReceivedStockBYTranfer.Qty,0) as ReceivedStockBYTranfer    ");
            sQueryStringMaster.Append(" ,isnull(ReceivedStockBYIssue.Qty,0) as ReceivedStockBYIssue    ");
            sQueryStringMaster.Append(" ,isnull(AdjustmentPv.Qty,0) as AdjustmentPv    ");
            sQueryStringMaster.Append(" ,isnull(ProductReturn.Qty,0) as ProductReturn    ");
            sQueryStringMaster.Append(" ,isnull(TranferedStock.Qty,0) as TranferedStock    ");
            sQueryStringMaster.Append(" ,isnull(IssuedStock.Qty,0) as IssuedStock    ");
            sQueryStringMaster.Append(" ,isnull(Invoiced.Qty,0) as Invoiced    ");
            sQueryStringMaster.Append(" ,isnull(AdjustmentNv.Qty,0) as AdjustmentNv    ");
            sQueryStringMaster.Append(" ,isnull(RepAdjustment.Qty,0) as RepAdjustment ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Productid, warehouseid, channelid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock  ");
            sQueryStringMaster.Append("where channelid <> 1 and warehouseid <> 1  ");
            sQueryStringMaster.Append("group by ProductID,warehouseid,channelid ");
            sQueryStringMaster.Append(") as x  ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid,towhid, tochannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ? and trandate < ? and sm.Status=1 ");
            sQueryStringMaster.Append("group by sd.productid,towhid, tochannelid ");
            sQueryStringMaster.Append(") as y ");
            sQueryStringMaster.Append("on x.productid = y.productid and x.channelid = y.tochannelid and x.warehouseid = y.towhid ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Fromwhid, FromChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ? and trandate < ?  and sm.Status=1 ");
            sQueryStringMaster.Append("group by sd.productid,Fromwhid, FromChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as z ");
            sQueryStringMaster.Append("on x.productid = z.productid and x.channelid = z.FromChannelid and x.warehouseid = z.Fromwhid ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Towhid, ToChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid  and trandate between ? and ? and trandate < ?  and sm.Status=1 ");
            sQueryStringMaster.Append("and trantypeid in (1) ");
            sQueryStringMaster.Append("group by sd.productid,Towhid, ToChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as GoodsReceived ");
            sQueryStringMaster.Append("on x.productid = GoodsReceived.productid and x.channelid = GoodsReceived.ToChannelid and x.warehouseid = GoodsReceived.Towhid ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Towhid,ToChannelID,productid, sum(qty) as Qty from  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select qq1.*, qq2.warehouseparentid as fromWHParentID, qq3.warehouseparentid as TOWhParentID from  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.*, q2.Productid, q2.Qty from t_productStockTran q1,  t_productStockTranItem q2  ");
            sQueryStringMaster.Append("where trantypeid in (3) and trandate between ? and ? and trandate < ? and q1.Status=1 ");
            sQueryStringMaster.Append("and q1.tranid = q2.tranid ");
            sQueryStringMaster.Append(") qq1  ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select * from t_warehouse ");
            sQueryStringMaster.Append(") as qq2 on qq1.fromwhid = qq2.warehouseid ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select * from t_warehouse ");
            sQueryStringMaster.Append(") as qq3 on qq1.Towhid = qq3.warehouseid ");
            sQueryStringMaster.Append(") as qqq where fromwhparentid <> towhparentid ");
            sQueryStringMaster.Append("group by Towhid,ToChannelID,productid ");
            sQueryStringMaster.Append(") as ReceivedStockBYTranfer ");
            sQueryStringMaster.Append("on x.productid = ReceivedStockBYTranfer.productid and x.channelid = ReceivedStockBYTranfer.ToChannelid and x.warehouseid = ReceivedStockBYTranfer.Towhid ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Towhid, ToChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid  and trandate between ? and ? and trandate < ? ");
            sQueryStringMaster.Append("and trantypeid in (4,9,10,13,14,15,16,18,19,20) and sm.Status=1 ");
            sQueryStringMaster.Append("group by sd.productid,Towhid, ToChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as ReceivedStockBYIssue ");
            sQueryStringMaster.Append("on x.productid = ReceivedStockBYIssue.productid and x.channelid = ReceivedStockBYIssue.ToChannelid and x.warehouseid = ReceivedStockBYIssue.Towhid ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Towhid, ToChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid  and trandate between ? and ? and trandate < ? ");
            sQueryStringMaster.Append("and trantypeid in (5)  and sm.Status=1 ");
            sQueryStringMaster.Append("group by sd.productid,Towhid, ToChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as ProductReturn ");
            sQueryStringMaster.Append("on x.productid = ProductReturn.productid and x.channelid = ProductReturn.ToChannelid and x.warehouseid = ProductReturn.Towhid ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Towhid, ToChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd, t_productstocktrantype stp  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid  and trandate between ? and ? and trandate < ? ");
            sQueryStringMaster.Append("and stp.TranTypeid = sm.TranTypeID and stp.transactionside = 1 and stp.IsSystem = 2 and sm.Status=1 ");
            sQueryStringMaster.Append("group by sd.productid,Towhid, ToChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as AdjustmentPv ");
            sQueryStringMaster.Append("on x.productid = AdjustmentPv.productid and x.channelid = AdjustmentPv.ToChannelid and x.warehouseid = AdjustmentPv.Towhid ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Fromwhid,FromChannelID,productid, sum(qty) as Qty from  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select qq1.*, qq2.warehouseparentid as fromWHParentID, qq3.warehouseparentid as TOWhParentID from  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.*, q2.Productid, q2.Qty from t_productStockTran q1,  t_productStockTranItem q2  ");
            sQueryStringMaster.Append("where trantypeid in (3) and trandate between ? and ? and trandate < ? ");
            sQueryStringMaster.Append("and q1.tranid = q2.tranid and q1.Status=1 ");
            sQueryStringMaster.Append(") qq1  ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select * from t_warehouse ");
            sQueryStringMaster.Append(") as qq2 on qq1.fromwhid = qq2.warehouseid ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select * from t_warehouse ");
            sQueryStringMaster.Append(") as qq3 on qq1.Towhid = qq3.warehouseid ");
            sQueryStringMaster.Append(") as qqq  ");
            sQueryStringMaster.Append("where fromwhparentid <> towhparentid group by Fromwhid,FromChannelID,productid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as TranferedStock ");
            sQueryStringMaster.Append("on x.productid = TranferedStock.productid and x.channelid = TranferedStock.FromChannelid and x.warehouseid = TranferedStock.Fromwhid ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Fromwhid, FromChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid  and trandate between ? and ? and trandate < ? ");
            sQueryStringMaster.Append("and trantypeid in (4,9,10,13,14,15,16,18,19,20) and sm.Status=1 ");
            sQueryStringMaster.Append("group by sd.productid,Fromwhid, FromChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as IssuedStock ");
            sQueryStringMaster.Append("on x.productid = IssuedStock.productid and x.channelid = IssuedStock.FromChannelid and x.warehouseid = IssuedStock.Fromwhid ");

            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Fromwhid, FromChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid  and trandate between ? and ? and trandate < ? ");
            sQueryStringMaster.Append("and trantypeid in (5)  and sm.Status=1 ");
            sQueryStringMaster.Append("group by sd.productid,Fromwhid, FromChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as Invoiced ");
            sQueryStringMaster.Append("on x.productid = Invoiced.productid and x.channelid = Invoiced.FromChannelid and x.warehouseid = Invoiced.Fromwhid ");

            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Fromwhid, FromChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd, t_productstocktrantype stp  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid  and trandate between ? and ? and trandate < ? ");
            sQueryStringMaster.Append("and stp.TranTypeid = sm.TranTypeID and stp.transactionside = 2 and stp.IsSystem = 2 and sm.trantypeid not in (4,9,10,11,13,14,15,16,17,18,19,20)  and sm.Status=1 ");
            sQueryStringMaster.Append("group by sd.productid,Fromwhid, FromChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as AdjustmentNv ");
            sQueryStringMaster.Append("on x.productid = AdjustmentNv.productid and x.channelid = AdjustmentNv.FromChannelid and x.warehouseid = AdjustmentNv.Fromwhid ");

            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select sd.productid, Fromwhid, FromChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid  and trandate between ? and ? and trandate < ? ");
            sQueryStringMaster.Append("and trantypeid in (11,17) and sm.Status=1 ");
            sQueryStringMaster.Append("group by sd.productid,Fromwhid, FromChannelid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as RepAdjustment ");
            sQueryStringMaster.Append("on x.productid = RepAdjustment.productid and x.channelid = RepAdjustment.FromChannelid and x.warehouseid = RepAdjustment.Fromwhid ");

            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select * from v_ProductDetails ");
            sQueryStringMaster.Append(") ");
            sQueryStringMaster.Append("as ProductDetails ");
            sQueryStringMaster.Append("on x.ProductID = ProductDetails.ProductID ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select WH.WarehouseID, WH.WarehouseCode, WH.WarehouseName ");
            sQueryStringMaster.Append(",WHP.WarehouseParentID, WHP.WarehouseParentCode, WHP.WarehouseParentName ");
            sQueryStringMaster.Append(",CH.ChannelID, CH.ChannelCode, CH.ChannelDescription as ChannelName ");
            sQueryStringMaster.Append(",SBU.SBUID, SBU.SBUCode, SBU.SBUName ");
            sQueryStringMaster.Append("from t_Warehouse WH, t_WarehouseParent WHP, t_channel CH, t_SBU  SBU ");
            sQueryStringMaster.Append("WHERE WH.ChannelID = CH.ChannelID and WH.WarehouseParentID = WHP.WarehouseParentID ");
            sQueryStringMaster.Append("and CH.SBUID = SBU.SBUID ");
            sQueryStringMaster.Append(") ");
            sQueryStringMaster.Append("as WarehouseDetail ");
            sQueryStringMaster.Append("on WarehouseDetail.WarehouseID = x.WarehouseID and WarehouseDetail.ChannelID = x.ChannelID ");
            sQueryStringMaster.Append(" )    ");
            sQueryStringMaster.Append(" as FinalQuery     ");
            if (sQueryExpr != "")
            {
                sQueryStringMaster.Append(sQueryExpr.ToString());
            }

            sQueryStringMaster.Append(" Group By    ");
            sQueryStringMaster.Append(" PGID, PGCode, PGName    ");
            sQueryStringMaster.Append(" ,MAGID, MAGCode, MAGName    ");
            sQueryStringMaster.Append(" ,ASGID, ASGCode, ASGName    ");
            sQueryStringMaster.Append(" ,BrandID, BrandCode, BrandDesc   ");
            sQueryStringMaster.Append(" having  (sum(OpenningStock) + sum(GoodsReceived)+ sum(ReceivedStockBYTranfer) + sum(ReceivedStockBYIssue)+ sum(AdjustmentPv)+ sum(ProductReturn)) > 0    ");


            OleDbCommand oCmd = DBController.Instance.GetCommand();
            //Command time out
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();


            //Openning stock date range
            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date.AddDays(1));
            //oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date.AddDays(1));
            //oCmd.Parameters.AddWithValue("TranDate", dDToDate);


            //Stock Transaction date range
            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            GetGoodsMovementSummaryASGWise(oCmd);


        }


        public void GoodsMovementSummaryASGWiseNew(DateTime dDFromDate, DateTime dDToDate, string sQueryExpr)
        {
            dDToDate = dDToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "Select PGID, PGCode, PGName,MAGID,MAGCode,MAGName,ASGID,ASGCode,ASGName,AGID, " +
                        "AGCode,AGName,BrandID, BrandCode,BrandName,sum(OpeningStock) as OpeningStock,  " +
                        "isnull(sum(OpeningStock * CostPrice), 0) as OpeningStockValue ,sum(GoodsReceived) as GoodsReceived " +
                        ",sum(ReceivedStockBYTranfer) as ReceivedStockBYTranfer " +
                        ",sum(ReceivedStockBYIssue) as ReceivedStockBYIssue " +
                        ",sum(AdjustmentPv) as AdjustmentPv " +
                        ",sum(ProductReturn) as ProductReturn " +
                        ",sum(TranferedStock) as TranferedStock " +
                        ",sum(IssuedStock) as IssuedStock " +
                        ",sum(Invoiced) as Invoiced " +
                        ",sum(AdjustmentNv) as AdjustmentNv " +
                        ",sum(RepAdjustment) as RepAdjustment " +
                        ",sum((OpeningStock + GoodsReceived + ReceivedStockBYTranfer + AdjustmentPv + ProductReturn) - (Invoiced + TranferedStock + IssuedStock + AdjustmentNv + RepAdjustment)) as Closing " +
                        ",sum(((OpeningStock + GoodsReceived + ReceivedStockBYTranfer + AdjustmentPv + ProductReturn) - (Invoiced + TranferedStock + IssuedStock + AdjustmentNv + RepAdjustment)) * isnull(CostPrice, 0)) as ClosingValue From  " +
                        "( " +
                        "Select WarehouseID,WarehouseParentID,WarehouseParentName,ProductID, ProductCode, ProductName,PGID, PGCode, PGName,MAGID,MAGCode,  " +
                        "MAGName,ASGID, ASGCode, ASGName ,AGID, AGCode, AGName ,BrandID, BrandCode,  " +
                        "BrandDesc as BrandName ,ProductType,isnull(NSP,0) NSP,isnull(RSP,0) RSP, " +
                        "isnull(CostPrice,0) CostPrice,IsActive ,sum(OpeningStock) as OpeningStock,  " +
                        "isnull(sum(OpeningStock * CostPrice),0) as OpeningStockValue , " +
                        "sum(GoodsReceived) as GoodsReceived,sum(ReceivedStockBYTranfer) as ReceivedStockBYTranfer, " +
                        "sum(ReceivedStockBYIssue) as ReceivedStockBYIssue,sum(AdjustmentPv) as AdjustmentPv, " +
                        "sum(ProductReturn) as ProductReturn ,sum(TranferedStock) as TranferedStock,sum(IssuedStock) as IssuedStock, " +
                        "sum(Invoiced) as Invoiced,sum(AdjustmentNv) as AdjustmentNv,sum(RepAdjustment) as RepAdjustment     " +
                        "From     " +
                        "(     " +
                        "select ProductDetails.*, WarehouseDetail.*,OpeningStock ,isnull(GoodsReceived.Qty,0) as GoodsReceived , " +
                        "isnull(ReceivedStockBYTranfer.Qty,0) as ReceivedStockBYTranfer,isnull(ReceivedStockBYIssue.Qty,0) as ReceivedStockBYIssue, " +
                        "isnull(AdjustmentPv.Qty,0) as AdjustmentPv,isnull(ProductReturn.Qty,0) as ProductReturn, " +
                        "isnull(TranferedStock.Qty,0) as TranferedStock,isnull(IssuedStock.Qty,0) as IssuedStock, " +
                        "isnull(Invoiced.Qty,0) as Invoiced,isnull(AdjustmentNv.Qty,0) as AdjustmentNv, " +
                        "isnull(RepAdjustment.Qty,0) as RepAdjustment  " +
                        "from   " +
                        "(  " +
                        "Select main.ProductID,WarehouseID,sum(CurrentStock)+sum(StockOutQty)-sum(StockInQty) as OpeningStock " +
                        "From  " +
                        "( " +
                        "Select WarehouseID,ProductID,0 StockInQty,0 StockOutQty,CurrentStock From t_ProductStock  " +
                        "Union All " +
                        //"---Invoice--- " +
                        "Select WarehouseID,ProductID,0 as StockInQty, " +
                        "case when InvoiceTypeID in (6,7,8,9,10,11,12,16) then (Quantity+FreeQty)*-1 else (Quantity+FreeQty) end as StockOutQty,0 CurrentStock  " +
                        "From t_SalesInvoice a,t_SalesInvoiceDetail b where a.InvoiceID=b.InvoiceID and InvoiceStatus not in (3) " +
                        "and InvoiceDate between '" + dDFromDate + "' and FORMAT(GetDate()+1, 'dd-MMM-yyyy') and InvoiceDate<FORMAT(GetDate()+1, 'dd-MMM-yyyy') " +
                        //"---End Invoice--- " +
                        "Union All " +
                        "Select FromWHID,ProductID,0 as StockInQty,Qty as StockOutQty,0 CurrentStock  " +
                        "From t_ProductStockTran a,t_ProductStockTranItem b " +
                        "where a.TranID=b.TranID and TranDate between '" + dDFromDate + "' and FORMAT(GetDate()+1, 'dd-MMM-yyyy') and TranDate<FORMAT(GetDate()+1, 'dd-MMM-yyyy') " +
                        "and a.Status=1 and TranTypeID<>5 " +
                        "Union All " +
                        "Select ToWHID,ProductID,Qty as StockInQty,0 as StockOutQty,0 CurrentStock " +
                        "From t_ProductStockTran a,t_ProductStockTranItem b " +
                        "where a.TranID=b.TranID and TranDate between '" + dDFromDate + "' and FORMAT(GetDate()+1, 'dd-MMM-yyyy') and TranDate<FORMAT(GetDate()+1, 'dd-MMM-yyyy') " +
                        "and a.Status=1 and TranTypeID<>5 " +
                        ") Main  " +
                        "group by main.ProductID,WarehouseID  " +
                        ") as x   " +
                        "left outer join   " +
                        "(  " +
                        "select sd.productid, Towhid, ToChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   " +
                        "where sd.tranid  = sm.tranid  and trandate between '" + dDFromDate + "' and '" + dDToDate + "'  and trandate < '" + dDToDate + "' and sm.Status=1  " +
                        "and trantypeid in (1)  " +
                        "group by sd.productid,Towhid, ToChannelid  " +
                        ")   " +
                        "as GoodsReceived  " +
                        "on x.productid = GoodsReceived.productid and x.warehouseid = GoodsReceived.Towhid  " +
                        "left outer join   " +
                        "(  " +
                        "select Towhid,ToChannelID,productid, sum(qty) as Qty from   " +
                        "(  " +
                        "select qq1.*, qq2.warehouseparentid as fromWHParentID, qq3.warehouseparentid as TOWhParentID from   " +
                        "(  " +
                        "select q1.*, q2.Productid, q2.Qty from t_productStockTran q1,  t_productStockTranItem q2   " +
                        "where trantypeid in (3) and trandate between '" + dDFromDate + "' and '" + dDToDate + "'  and trandate < '" + dDToDate + "'  and q1.Status=1  " +
                        "and q1.tranid = q2.tranid  " +
                        ") qq1   " +
                        "inner join  " +
                        "(  " +
                        "select * from t_warehouse  " +
                        ") as qq2 on qq1.fromwhid = qq2.warehouseid  " +
                        "inner join  " +
                        "(  " +
                        "select * from t_warehouse  " +
                        ") as qq3 on qq1.Towhid = qq3.warehouseid  " +
                        ") as qqq where fromwhparentid <> towhparentid  " +
                        "group by Towhid,ToChannelID,productid  " +
                        ") as ReceivedStockBYTranfer  " +
                        "on x.productid = ReceivedStockBYTranfer.productid and x.warehouseid = ReceivedStockBYTranfer.Towhid  " +
                        "left outer join   " +
                        "(  " +
                        "select sd.productid, Towhid, ToChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   " +
                        "where sd.tranid  = sm.tranid  and trandate between '" + dDFromDate + "' and '" + dDToDate + "'  and trandate < '" + dDToDate + "'  " +
                        "and trantypeid in (4,9,10,13,14,15,16,18,19,20) and sm.Status=1  " +
                        "group by sd.productid,Towhid, ToChannelid  " +
                        ")   " +
                        "as ReceivedStockBYIssue  " +
                        "on x.productid = ReceivedStockBYIssue.productid and x.warehouseid = ReceivedStockBYIssue.Towhid  " +
                        "left outer join   " +
                        "(  " +
                        "select sd.productid, Towhid, ToChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   " +
                        "where sd.tranid  = sm.tranid  and trandate between '" + dDFromDate + "' and '" + dDToDate + "'  and trandate < '" + dDToDate + "'  " +
                        "and trantypeid in (5)  and sm.Status=1  " +
                        "group by sd.productid,Towhid, ToChannelid  " +
                        ")   " +
                        "as ProductReturn  " +
                        "on x.productid = ProductReturn.productid and x.warehouseid = ProductReturn.Towhid  " +
                        "left outer join   " +
                        "(  " +
                        "select sd.productid, Towhid, ToChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd, t_productstocktrantype stp   " +
                        "where sd.tranid  = sm.tranid  and trandate between '" + dDFromDate + "' and '" + dDToDate + "'  and trandate < '" + dDToDate + "'  " +
                        "and stp.TranTypeid = sm.TranTypeID and stp.transactionside = 1 and stp.IsSystem = 2 and sm.Status=1  " +
                        "group by sd.productid,Towhid, ToChannelid  " +
                        ")   " +
                        "as AdjustmentPv  " +
                        "on x.productid = AdjustmentPv.productid and x.warehouseid = AdjustmentPv.Towhid  " +
                        "left outer join   " +
                        "(  " +
                        "select Fromwhid,FromChannelID,productid, sum(qty) as Qty from   " +
                        "(  " +
                        "select qq1.*, qq2.warehouseparentid as fromWHParentID, qq3.warehouseparentid as TOWhParentID from   " +
                        "(  " +
                        "select q1.*, q2.Productid, q2.Qty from t_productStockTran q1,  t_productStockTranItem q2   " +
                        "where trantypeid in (3) and trandate between '" + dDFromDate + "' and '" + dDToDate + "'  and trandate < '" + dDToDate + "'  and q1.Status=1 " +
                        "and q1.tranid = q2.tranid  " +
                        ") qq1   " +
                        "inner join  " +
                        "(  " +
                        "select * from t_warehouse  " +
                        ") as qq2 on qq1.fromwhid = qq2.warehouseid  " +
                        "inner join  " +
                        "(  " +
                        "select * from t_warehouse  " +
                        ") as qq3 on qq1.Towhid = qq3.warehouseid  " +
                        ") as qqq   " +
                        "where fromwhparentid <> towhparentid group by Fromwhid,FromChannelID,productid  " +
                        ")   " +
                        "as TranferedStock  " +
                        "on x.productid = TranferedStock.productid and x.warehouseid = TranferedStock.Fromwhid  " +
                        "left outer join   " +
                        "(  " +
                        "select sd.productid, Fromwhid, FromChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   " +
                        "where sd.tranid  = sm.tranid  and trandate between '" + dDFromDate + "' and '" + dDToDate + "'  and trandate < '" + dDToDate + "'   " +
                        "and trantypeid in (4,9,10,13,14,15,16,18,19,20) and sm.Status=1  " +
                        "group by sd.productid,Fromwhid, FromChannelid  " +
                        ")   " +
                        "as IssuedStock  " +
                        "on x.productid = IssuedStock.productid and x.warehouseid = IssuedStock.Fromwhid  " +
                        "left outer join   " +
                        "(  " +
                        "select sd.productid, Fromwhid, FromChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   " +
                        "where sd.tranid  = sm.tranid  and trandate between '" + dDFromDate + "' and '" + dDToDate + "'  and trandate < '" + dDToDate + "'  " +
                        "and trantypeid in (5)  and sm.status=1  " +
                        "group by sd.productid,Fromwhid, FromChannelid  " +
                        ")   " +
                        "as Invoiced  " +
                        "on x.productid = Invoiced.productid and x.warehouseid = Invoiced.Fromwhid  " +
                        "left outer join   " +
                        "(  " +
                        "select sd.productid, Fromwhid, FromChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd, t_productstocktrantype stp   " +
                        "where sd.tranid  = sm.tranid  and trandate between '" + dDFromDate + "' and '" + dDToDate + "'  and trandate < '" + dDToDate + "'  " +
                        "and stp.TranTypeid = sm.TranTypeID and stp.transactionside = 2 and stp.IsSystem = 2 and sm.trantypeid not in (4,9,10,11,13,14,15,16,17,18,19,20) and sm.status=1  " +
                        "group by sd.productid,Fromwhid, FromChannelid  " +
                        ")   " +
                        "as AdjustmentNv  " +
                        "on x.productid = AdjustmentNv.productid and x.warehouseid = AdjustmentNv.Fromwhid  " +
                        "left outer join   " +
                        "(  " +
                        "select sd.productid, Fromwhid, FromChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   " +
                        "where sd.tranid  = sm.tranid  and trandate between '" + dDFromDate + "' and '" + dDToDate + "'  and trandate < '" + dDToDate + "'  " +
                        "and trantypeid in (11,17) and sm.status=1  " +
                        "group by sd.productid,Fromwhid, FromChannelid  " +
                        ")   " +
                        "as RepAdjustment  " +
                        "on x.productid = RepAdjustment.productid and x.warehouseid = RepAdjustment.Fromwhid  " +
                        "left outer join  " +
                        "(  " +
                        "select * from v_ProductDetails  " +
                        ")  " +
                        "as ProductDetails  " +
                        "on x.ProductID = ProductDetails.ProductID  " +
                        "left outer join  " +
                        "(  " +
                        "select WH.WarehouseID, WH.WarehouseCode, WH.WarehouseName  " +
                        ",WHP.WarehouseParentID, WHP.WarehouseParentCode, WHP.WarehouseParentName  " +
                        ",CH.ChannelID, CH.ChannelCode, CH.ChannelDescription as ChannelName  " +
                        ",SBU.SBUID, SBU.SBUCode, SBU.SBUName  " +
                        "from t_Warehouse WH, t_WarehouseParent WHP, t_channel CH, t_SBU  SBU  " +
                        "WHERE WH.ChannelID = CH.ChannelID and WH.WarehouseParentID = WHP.WarehouseParentID  " +
                        "and CH.SBUID = SBU.SBUID  " +
                        ")  " +
                        "as WarehouseDetail  " +
                        "on WarehouseDetail.WarehouseID = x.WarehouseID " +
                        ")     " +
                        "as FinalQuery      " +
                        "Group By WarehouseID,WarehouseParentID,WarehouseParentName,ProductID, ProductCode, ProductName ,PGID, PGCode, PGName,MAGID, MAGCode, MAGName,ASGID, ASGCode,  " +
                        "ASGName ,AGID, AGCode, AGName,BrandID, BrandCode, BrandDesc,ProductType,NSP,RSP,CostPrice,IsActive     " +
                        "having  (sum(OpeningStock) + sum(GoodsReceived)+ sum(ReceivedStockBYTranfer) + sum(ReceivedStockBYIssue)+ sum(AdjustmentPv)+ sum(ProductReturn)) > 0     " +
                        ") Main";

            if (sQueryExpr != "")
            {
                sSQL = sSQL + " " + sQueryExpr.ToString();
            }

            sSQL = sSQL + " group by PGID,PGCode,PGName,MAGID,MAGCode,MAGName,ASGID,ASGCode,ASGName,AGID,AGCode,AGName,BrandID,BrandCode,BrandName";


            OleDbCommand oCmd = DBController.Instance.GetCommand();
            //Command time out
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sSQL.ToString();

            GetGoodsMovementSummaryASGWise(oCmd);


        }
        private void GetGoodsMovementSummaryASGWise(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    WarehouseStock oItem = new WarehouseStock();

                    oItem.SBUID = -1;
                    oItem.SBUCode = "";
                    oItem.SBUName = "";
                    oItem.ChannelID = -1;
                    oItem.ChannelCode = "";
                    oItem.ChannelName = "";
                    oItem.WarehouseParentID = -1;
                    oItem.WarehouseParentCode = "";
                    oItem.WarehouseParentName = "";
                    oItem.WarehouseID = -1;
                    oItem.WarehouseCode = "";
                    oItem.WarehouseName = "";
                    oItem.ProductID = -1;
                    oItem.ProductCode = "";
                    oItem.ProductName = "";
                    oItem.ProductCodeInNumber = -1;
                    oItem.IsActive = -1;

                    oItem.AGID = -1;
                    oItem.AGCode = "";
                    oItem.AGName = "";
                    oItem.ASGID = Convert.ToInt64(reader["ASGID"]);
                    oItem.ASGCode = (string)reader["ASGCode"];
                    oItem.ASGName = (string)reader["ASGName"];
                    oItem.MAGID = Convert.ToInt64(reader["MAGID"]);
                    oItem.MAGCode = (string)reader["MAGCode"];
                    oItem.MAGName = (string)reader["MAGName"];
                    oItem.PGID = Convert.ToInt64(reader["PGID"]);
                    oItem.PGCode = (string)reader["PGCode"];
                    oItem.PGName = (string)reader["PGName"];
                    oItem.BrandID = Convert.ToInt64(reader["BrandID"]);
                    oItem.BrandCode = (string)reader["BrandCode"];
                    oItem.BrandName = (string)reader["BrandName"];
                    oItem.OpeningStock = Convert.ToInt64(reader["OpeningStock"]);
                    oItem.OpeningStockValue = Convert.ToDouble(reader["OpeningStockValue"]);
                    oItem.BookingStock = 0;
                    oItem.ReceivedStockBYTranfer = Convert.ToInt64(reader["ReceivedStockBYTranfer"]);
                    oItem.ReceivedStockBYTranferValue = 0;
                    oItem.ReceivedStockBYIssue = Convert.ToInt64(reader["ReceivedStockBYIssue"]);
                    oItem.ReceivedStockBYIssueValue = 0;
                    oItem.GoodsReceived = Convert.ToInt64(reader["GoodsReceived"]);
                    oItem.GoodsReceivedValue = 0;
                    oItem.IssuedStock = Convert.ToInt64(reader["IssuedStock"]);
                    oItem.IssuedStockValue = 0;
                    oItem.Invoiced = Convert.ToInt64(reader["Invoiced"]);
                    oItem.InvoicedValue = 0;
                    oItem.Replacement = 0;
                    oItem.ReplacementValue = 0;
                    oItem.RepAdjustment = Convert.ToInt64(reader["RepAdjustment"]);
                    oItem.RepAdjustmentValue = 0;
                    oItem.TransitStockQuantity = 0;
                    oItem.TransitStockValue = 0;
                    oItem.AdjustmentPv = Convert.ToInt64(reader["AdjustmentPv"]);
                    oItem.AdjustmentPvValue = 0;
                    oItem.ProductReturn = Convert.ToInt64(reader["ProductReturn"]);
                    oItem.ProductReturnValue = 0;
                    oItem.AdjustmentNv = Convert.ToInt64(reader["AdjustmentNv"]);
                    oItem.AdjustmentNvValue = 0;
                    oItem.TranferedStock = Convert.ToInt64(reader["TranferedStock"]);
                    oItem.TranferedStockValue = 0;
                    oItem.Closing = Convert.ToInt64(reader["Closing"]);
                    oItem.ClosingValue = Convert.ToDouble(reader["ClosingValue"]);
                    oItem.CostPrice = 0;
                    oItem.NSP = 0;
                    oItem.RSP = 0;
                    oItem.UOMConversionFactor = 0;
                    oItem.ProductType = -1;

                    Add(oItem);

                    //InnerList.Add(oItem);
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
        
    

        

