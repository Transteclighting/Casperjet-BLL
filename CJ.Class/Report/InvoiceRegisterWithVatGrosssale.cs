// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Feb 23, 2012
// Time :  02:40 PM
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
    public class InvoiceRegisterWithVatGrosssale
    {
        private int _WarehouseID;
        private string _WarehouseCode;
        private string _WarehouseName;
        private double _Discount;
        private double _InvoiceAmount;
        private double _OtherCharge;
        private string _CustomerName;
        private string _CustomerCode;
        private DateTime _InvoiceDate;
        private string _InvoiceNo;
        private long _SBUID;
        private string _SBUName;
        private long _VatChallanNo;
        private double _GrossSales;
        private double _VAT;
        private double _TradePrice;
        private DateTime _DeliveryDate;
        private double _AdjustedDPAmount;
        private double _AdjustedPWAmount;
        private int _nChannelId;
        private int _nAreaId;
        private int _nTerritoryId;
        private int _nDistrictID;
        private int _nThanaID;
        private int _nInvoiceType;
        private int _nCoustomerType;

        public int WarehouseID
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
        public double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        public double InvoiceAmount
        {
            get { return _InvoiceAmount; }
            set { _InvoiceAmount = value; }
        }
        public double OtherCharge
        {
            get { return _OtherCharge; }
            set { _OtherCharge = value; }
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
        public DateTime InvoiceDate
        {
            get { return _InvoiceDate; }
            set { _InvoiceDate = value; }
        }
        public string InvoiceNo
        {
            get { return _InvoiceNo; }
            set { _InvoiceNo = value; }

        }
        public long SBUID
        {
            get { return _SBUID; }
            set { _SBUID = value; }
        }
        public string SBUName
        {
            get { return _SBUName; }
            set { _SBUName = value; }
        }
        public long VatChallanNo
        {
            get { return _VatChallanNo; }
            set { _VatChallanNo = value; }
        }
        public double GrossSales
        {
            get { return _GrossSales; }
            set { _GrossSales = value; }
        }
        public double VAT
        {
            get { return _VAT; }
            set { _VAT = value; }
        }
        public double TradePrice
        {
            get { return _TradePrice; }
            set { _TradePrice = value; }
        }
        public DateTime DeliveryDate
        {
            get { return _DeliveryDate; }
            set { _DeliveryDate = value; }
        }  
        public double AdjustedDPAmount
        {
            get { return _AdjustedDPAmount; }
            set { _AdjustedDPAmount = value; }
        }
        public double AdjustedPWAmount
        {
            get { return _AdjustedPWAmount; }
            set { _AdjustedPWAmount = value; }

        }
        public int ChannelId
        {
            get { return _nChannelId; }
            set { _nChannelId = value; }
        }
        public int AreaId
        {
            get { return _nAreaId; }
            set { _nAreaId = value; }
        }
        public int TerritoryId
        {
            get { return _nTerritoryId; }
            set { _nTerritoryId = value; }
        }

        public int DistrictID
        {
            get { return _nDistrictID; }
            set { _nDistrictID = value; }
        }
        public int ThanaID
        {
            get { return _nThanaID; }
            set { _nThanaID = value; }
        }
        public int InvoiceType
        {
            get { return _nInvoiceType; }
            set { _nInvoiceType = value; }
        }
        public int CoustomerType
        {
            get { return _nCoustomerType; }
            set { _nCoustomerType = value; }
        }
       
    }
    public class InvoiceRegisterWithVatGrosssaleReport : CollectionBaseCustom
    {

        public void Add(InvoiceRegisterWithVatGrosssale oInvoiceRegisterWithVatGrosssale)
        {
            this.List.Add(oInvoiceRegisterWithVatGrosssale);
        }
        public InvoiceRegisterWithVatGrosssale this[Int32 Index]
        {
            get
            {
                return (InvoiceRegisterWithVatGrosssale)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(InvoiceRegisterWithVatGrosssale))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        ///
        public void GetInvoiceRegisterWithVatGrosssale(int nInvoiceSelectionCriteria, DateTime _dStartDate, DateTime _dEndDate, long _nFromVATChallanNo, long _nToVATChallanNo, long _FromInvoiceNo, long _ToInvoiceNo)
        {

            // InnerList.Clear();
            OleDbCommand oCmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            if (nInvoiceSelectionCriteria == (long)Dictionary.InvoiceSelectionCriteria.Between_Date)
            {               

                sQueryStringMaster.Append("select    ");
                sQueryStringMaster.Append("q1.InvoiceID, q1.InvoiceNo, q1.InvoiceDate, q1.DeliveryDate, q1.VATChallanNo,q1.WarehouseID, q1.WarehouseCode, q1.WarehouseName, q1.InvoiceTypeID, q1.InvoiceTypeName, q1.InvoiceAmount, q1.Discount, q1.OtherCharge   ");
                sQueryStringMaster.Append(",q3.Quantity, GrossSales = CASE WHEN q1.InvoiceTypeID = ? THEN 0 WHEN q1.InvoiceTypeID = ? THEN 0 ELSE q3.GrossSales END, q3.CostPrice, q3.TradePrice, q3.ProductDiscount, q3.VAT,q3.AdjustedDPAmount,q3.AdjustedPWAmount   ");
                sQueryStringMaster.Append(",q2.*    ");
                sQueryStringMaster.Append("from   ");
                sQueryStringMaster.Append("(   ");
                sQueryStringMaster.Append("Select IM.InvoiceID, IM.Invoiceno, IM.CustomerID, WH.WarehouseID, WH.WarehouseCode, WH.WarehouseName,IM.InvoiceDate, IM.VATChallanNo, IM.DeliveryDate, IM.InvoiceTypeID, IT.InvoiceTypeName   ");
                sQueryStringMaster.Append(",InvoiceAmount = CASE WHEN IM.InvoiceTypeID = ? THEN 0 ELSE IM.InvoiceAmount END, Discount = CASE WHEN IM.InvoiceTypeID = ? THEN 0 ELSE IM.Discount END, IM.OtherCharge    ");
                sQueryStringMaster.Append("from t_SalesInvoice IM, t_InvoiceType IT, t_Warehouse WH   ");
                sQueryStringMaster.Append("where IM.InvoiceDate Between ? and ? and IM.InvoiceDate < ? and IM.WarehouseID = WH.WarehouseID  ");
                sQueryStringMaster.Append("and IM.InvoiceTypeID in (?,?,?,?,?,?) and InvoiceStatus not in (?) and IM.InvoiceTypeID = IT.InvoiceTypeID   ");
                sQueryStringMaster.Append("UNION ALL   ");
                sQueryStringMaster.Append("Select IM.InvoiceID, IM.Invoiceno, IM.CustomerID,WH.WarehouseID, WH.WarehouseCode, WH.WarehouseName, IM.InvoiceDate, IM.VATChallanNo, IM.DeliveryDate, IM.InvoiceTypeID, IT.InvoiceTypeName   ");
                sQueryStringMaster.Append(",InvoiceAmount = CASE WHEN IM.InvoiceTypeID = ? THEN 0 ELSE -IM.InvoiceAmount END, Discount = CASE WHEN IM.InvoiceTypeID = ? THEN 0 ELSE -Abs(IM.Discount) END, IM.OtherCharge    ");
                sQueryStringMaster.Append("from t_SalesInvoice IM, t_InvoiceType IT,  t_Warehouse WH   ");
                sQueryStringMaster.Append("where IM.InvoiceDate Between ? and ? and IM.InvoiceDate < ? and IM.WarehouseID = WH.WarehouseID  ");
                sQueryStringMaster.Append("and IM.InvoiceTypeID in (?,?,?,?,?,?,?)  and InvoiceStatus not in (?) and IM.InvoiceTypeID = IT.InvoiceTypeID   ");
                sQueryStringMaster.Append(") as q1   ");
                sQueryStringMaster.Append("left outer join   ");
                sQueryStringMaster.Append("(   ");
                sQueryStringMaster.Append("select * from v_CustomerDetails    ");
                sQueryStringMaster.Append(")   ");
                sQueryStringMaster.Append("as q2   ");
                sQueryStringMaster.Append("on q1.CustomerID = q2.CustomerID   ");
                sQueryStringMaster.Append("left outer join   ");
                sQueryStringMaster.Append("(   ");
                sQueryStringMaster.Append("select InvoiceID, (CRQuantity - DRQuantity) as Quantity, (CRGrossSales - DRGrossSales) as GrossSales   ");
                sQueryStringMaster.Append(",(CRCostPrice - CRCostPrice ) as CostPrice, (CRTradePrice - DRTradePrice) as TradePrice   ");
                sQueryStringMaster.Append(",(CRVAT - DRVAT) as VAT, (CRProductDiscount - DRProductDiscount) as ProductDiscount,(CRAdjustedDPAmount - DRAdjustedDPAmount) as AdjustedDPAmount,(CRAdjustedPWAmount - DRAdjustedPWAmount) as AdjustedPWAmount   ");
                sQueryStringMaster.Append("from   ");
                sQueryStringMaster.Append("(   ");
                sQueryStringMaster.Append("Select IM.InvoiceID   ");
                sQueryStringMaster.Append(",sum(Quantity+ isnull(freeQty,0)) as CRQuantity, sum((Quantity+ isnull(freeQty,0)) * UnitPrice) as CRGrossSales, sum(Quantity * CostPrice) as CRCostPrice, sum((Quantity+ isnull(freeqty,0))*TradePrice) as CRTradePrice, sum((Quantity + isnull(freeqty,0)) * VATAmount * TradePrice) as CRVAT, sum(Quantity * ProductDiscount) as CRProductDiscount, isnull(sum(Quantity * AdjustedDPAmount),0) as CRAdjustedDPAmount, isnull(sum(Quantity * AdjustedPWAmount),0) as CRAdjustedPWAmount   ");
                sQueryStringMaster.Append(",0 as DRQuantity, 0 as DRGrossSales, 0 as DRCostPrice, 0 as DRTradePrice, 0 as DRVAT , 0 as DRProductDiscount, 0 as DRAdjustedDPAmount, 0 as DRAdjustedPWAmount   ");
                sQueryStringMaster.Append("from t_SalesInvoice IM, t_SalesInvoiceDetail ID    ");
                sQueryStringMaster.Append("where IM.InvoiceID = ID.InvoiceID and IM.InvoiceDate Between ? and ? and IM.InvoiceDate < ?   ");
                sQueryStringMaster.Append("and IM.InvoiceTypeID in (?,?,?,?,?,?) and IM.invoicestatus not in (?)    ");
                sQueryStringMaster.Append("Group by IM.InvoiceID   ");
                sQueryStringMaster.Append("union all   ");
                sQueryStringMaster.Append("Select IM.InvoiceID   ");
                sQueryStringMaster.Append(",0 as CRQuantity, 0 as CRGrossSales, 0 as CRCostPrice, 0 as CRTradePrice, 0 as CRVAT, 0 as CRProductDiscount, 0 as CRAdjustedDPAmount, 0 as CRAdjustedPWAmount   ");
                sQueryStringMaster.Append(",abs(sum( Quantity+ isnull(freeQty,0))) as DRQuantity, abs (sum((Quantity + isnull(freeQty,0))* UnitPrice)) as DRGrossSales,abs(sum(Quantity * CostPrice)) as DRCostPrice, abs(sum((Quantity + isnull(freeqty,0))*TradePrice)) as DRTradePrice, abs(sum((Quantity + isnull(freeqty,0)) * VATAmount * TradePrice)) as DRVAT, sum(Quantity * ProductDiscount) as DRProductDiscount, isnull(sum(Quantity * AdjustedDPAmount),0) as DRAdjustedDPAmount, isnull(sum(Quantity * AdjustedPWAmount),0) as DRAdjustedPWAmount   ");
                sQueryStringMaster.Append("from t_SalesInvoice IM, t_SalesInvoiceDetail ID    ");
                sQueryStringMaster.Append("where IM.InvoiceID = ID.InvoiceID and IM.InvoiceDate Between ? and ? and IM.InvoiceDate < ?   ");
                sQueryStringMaster.Append("and IM.InvoiceTypeID in (?,?,?,?,?,?,?) and IM.invoicestatus not in (?)    ");
                sQueryStringMaster.Append("Group by IM.InvoiceID   ");
                sQueryStringMaster.Append(") as P1   ");
                sQueryStringMaster.Append(")as q3   ");
                sQueryStringMaster.Append("on q1.InvoiceID = q3.InvoiceID   ");

                oCmd.CommandTimeout = 0;
                oCmd.CommandText = sQueryStringMaster.ToString();

                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT_REVERSE);

                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT);

                oCmd.Parameters.AddWithValue("InvoiceDate", _dStartDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);

                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT);

                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION);

                oCmd.Parameters.AddWithValue("InvoiceStatus", (short)Dictionary.InvoiceStatus.CANCEL);

                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT_REVERSE);

                oCmd.Parameters.AddWithValue("InvoiceDate", _dStartDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);

                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT_REVERSE);

                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION_REVERSE);

                oCmd.Parameters.AddWithValue("InvoiceStatus", (short)Dictionary.InvoiceStatus.CANCEL);

                oCmd.Parameters.AddWithValue("InvoiceDate", _dStartDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);

                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT);

                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION);

                oCmd.Parameters.AddWithValue("InvoiceStatus", (short)Dictionary.InvoiceStatus.CANCEL);

                oCmd.Parameters.AddWithValue("InvoiceDate", _dStartDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);

                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT_REVERSE);

                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION_REVERSE);

                oCmd.Parameters.AddWithValue("InvoiceStatus", (short)Dictionary.InvoiceStatus.CANCEL);

            }
            else if (nInvoiceSelectionCriteria == (long)Dictionary.InvoiceSelectionCriteria.BETWEEN_VAT_CHALLAN_NO)
            {               

                sQueryStringMaster.Append("  select   ");
                sQueryStringMaster.Append("  q1.InvoiceID, q1.InvoiceNo, q1.InvoiceDate, q1.DeliveryDate, q1.VATChallanNo,q1.WarehouseID, q1.WarehouseCode, q1.WarehouseName, q1.InvoiceTypeID, q1.InvoiceTypeName, q1.InvoiceAmount, q1.Discount, q1.OtherCharge  ");
                sQueryStringMaster.Append("  ,q3.Quantity, q3.GrossSales, q3.CostPrice, q3.TradePrice, q3.ProductDiscount, q3.VAT,q3.AdjustedDPAmount,q3.AdjustedPWAmount   ");
                sQueryStringMaster.Append("  ,q2.*   ");
                sQueryStringMaster.Append("  from  ");
                sQueryStringMaster.Append("  (  ");
                sQueryStringMaster.Append("  Select IM.InvoiceID, IM.Invoiceno, IM.DeliveryDate, IM.CustomerID, WH.WarehouseID, WH.WarehouseCode, WH.WarehouseName,IM.InvoiceDate, IM.VATChallanNo, IM.InvoiceTypeID, IT.InvoiceTypeName  ");
                sQueryStringMaster.Append("  ,IM.InvoiceAmount, Abs( IM.Discount) as Discount, IM.OtherCharge   ");
                sQueryStringMaster.Append("  from t_SalesInvoice IM, t_InvoiceType IT, t_Warehouse WH  ");
                sQueryStringMaster.Append("  where IM.InvoiceDate Between ? and ? and IM.InvoiceDate < ?  and IM.VATChallanNo Between ? and ?  and IM.WarehouseID = WH.WarehouseID");
                sQueryStringMaster.Append("  and IM.InvoiceTypeID in (?,?,?,?,?,?) and InvoiceStatus not in (?) and IM.InvoiceTypeID = IT.InvoiceTypeID  ");
                sQueryStringMaster.Append("  UNION ALL  ");
                sQueryStringMaster.Append("  Select IM.InvoiceID, IM.Invoiceno, IM.DeliveryDate, IM.CustomerID, WH.WarehouseID, WH.WarehouseCode, WH.WarehouseName, IM.InvoiceDate, IM.VATChallanNo, IM.InvoiceTypeID, IT.InvoiceTypeName  ");
                sQueryStringMaster.Append("  ,-IM.InvoiceAmount, -Abs( IM.Discount) as Discount, IM.OtherCharge   ");
                sQueryStringMaster.Append("  from t_SalesInvoice IM, t_InvoiceType IT, t_Warehouse WH  ");
                sQueryStringMaster.Append("  where IM.InvoiceDate Between ? and ? and IM.InvoiceDate < ? and IM.VATChallanNo Between ? and ?  and IM.WarehouseID = WH.WarehouseID");
                sQueryStringMaster.Append("  and IM.InvoiceTypeID in (?,?,?,?,?,?,?)  and InvoiceStatus not in (?) and IM.InvoiceTypeID = IT.InvoiceTypeID  ");
                sQueryStringMaster.Append("  ) as q1  ");
                sQueryStringMaster.Append("  left outer join  ");
                sQueryStringMaster.Append("  (  ");
                sQueryStringMaster.Append("  select * from v_CustomerDetails   ");
                sQueryStringMaster.Append("  )  ");
                sQueryStringMaster.Append("  as q2  ");
                sQueryStringMaster.Append("  on q1.CustomerID = q2.CustomerID  ");
                sQueryStringMaster.Append("  left outer join  ");
                sQueryStringMaster.Append("  (  ");
                sQueryStringMaster.Append("  select InvoiceID, (CRQuantity - DRQuantity) as Quantity, (CRGrossSales - DRGrossSales) as GrossSales  ");
                sQueryStringMaster.Append("  ,(CRCostPrice - CRCostPrice ) as CostPrice, (CRTradePrice - DRTradePrice) as TradePrice  ");
                sQueryStringMaster.Append("  ,(CRVAT - DRVAT) as VAT, (CRProductDiscount - DRProductDiscount) as ProductDiscount,(CRAdjustedDPAmount - DRAdjustedDPAmount) as AdjustedDPAmount,(CRAdjustedPWAmount - DRAdjustedPWAmount) as AdjustedPWAmount  ");
                sQueryStringMaster.Append("  from  ");
                sQueryStringMaster.Append("  (  ");
                sQueryStringMaster.Append("  Select IM.InvoiceID  ");
                sQueryStringMaster.Append("  ,sum(Quantity + isnull(freeQty,0)) as CRQuantity, sum((Quantity + isnull(freeQty,0)) * UnitPrice) as CRGrossSales, sum(Quantity * CostPrice) as CRCostPrice, sum((Quantity + isnull(freeqty,0))*TradePrice) as CRTradePrice, sum((Quantity+ isnull(freeqty,0)) * VATAmount * TradePrice) as CRVAT, sum(Quantity * ProductDiscount) as CRProductDiscount, isnull(sum(Quantity * AdjustedDPAmount),0) as CRAdjustedDPAmount, isnull(sum(Quantity * AdjustedPWAmount),0) as CRAdjustedPWAmount  ");
                sQueryStringMaster.Append("  ,0 as DRQuantity, 0 as DRGrossSales, 0 as DRCostPrice, 0 as DRTradePrice, 0 as DRVAT , 0 as DRProductDiscount, 0 as DRAdjustedDPAmount, 0 as DRAdjustedPWAmount  ");
                sQueryStringMaster.Append("  from t_SalesInvoice IM, t_SalesInvoiceDetail ID   ");
                sQueryStringMaster.Append("  where IM.InvoiceID = ID.InvoiceID and IM.InvoiceDate Between ? and ? and IM.InvoiceDate < ?  and IM.VATChallanNo Between ? and ? ");
                sQueryStringMaster.Append("  and IM.InvoiceTypeID in (?,?,?,?,?,?) and IM.invoicestatus not in (?)   ");
                sQueryStringMaster.Append("  Group by IM.InvoiceID  ");
                sQueryStringMaster.Append("  union all  ");
                sQueryStringMaster.Append("  Select IM.InvoiceID  ");
                sQueryStringMaster.Append("  ,0 as CRQuantity, 0 as CRGrossSales, 0 as CRCostPrice, 0 as CRTradePrice, 0 as CRVAT, 0 as CRProductDiscount, 0 as CRAdjustedDPAmount, 0 as CRAdjustedPWAmount  ");
                sQueryStringMaster.Append("  ,abs(sum( Quantity + isnull(freeQty,0))) as DRQuantity, abs (sum((Quantity + isnull(freeQty,0)) * UnitPrice)) as DRGrossSales,abs(sum(Quantity * CostPrice)) as DRCostPrice, abs(sum((Quantity + isnull(freeqty,0))*TradePrice)) as DRTradePrice, abs(sum((Quantity+ isnull(freeqty,0)) * VATAmount * TradePrice)) as DRVAT, sum(Quantity * ProductDiscount) as DRProductDiscount, isnull(sum(Quantity * AdjustedDPAmount),0) as DRAdjustedDPAmount, isnull(sum(Quantity * AdjustedPWAmount),0) as DRAdjustedPWAmount  ");
                sQueryStringMaster.Append("  from t_SalesInvoice IM, t_SalesInvoiceDetail ID   ");
                sQueryStringMaster.Append("  where IM.InvoiceID = ID.InvoiceID and IM.InvoiceDate Between ? and ? and IM.InvoiceDate < ?  and IM.VATChallanNo Between ? and ? ");
                sQueryStringMaster.Append("  and IM.InvoiceTypeID in (?,?,?,?,?,?,?) and IM.invoicestatus not in (?)   ");
                sQueryStringMaster.Append("  Group by IM.InvoiceID  ");
                sQueryStringMaster.Append("  ) as P1  ");
                sQueryStringMaster.Append("  )as q3  ");
                sQueryStringMaster.Append("  on q1.InvoiceID = q3.InvoiceID  ");

                //Command time out
                oCmd.CommandTimeout = 0;
                oCmd.CommandText = sQueryStringMaster.ToString();

                oCmd.Parameters.AddWithValue("InvoiceDate", _dStartDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);

                oCmd.Parameters.AddWithValue("VATChallanNo", _nFromVATChallanNo);
                oCmd.Parameters.AddWithValue("VATChallanNo", _nToVATChallanNo);


                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);

                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION);

                oCmd.Parameters.AddWithValue("InvoiceStatus", (short)Dictionary.InvoiceStatus.CANCEL);

                oCmd.Parameters.AddWithValue("InvoiceDate", _dStartDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);

                oCmd.Parameters.AddWithValue("VATChallanNo", _nFromVATChallanNo);
                oCmd.Parameters.AddWithValue("VATChallanNo", _nToVATChallanNo);

                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);

                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION_REVERSE);

                oCmd.Parameters.AddWithValue("InvoiceStatus", (short)Dictionary.InvoiceStatus.CANCEL);

                oCmd.Parameters.AddWithValue("InvoiceDate", _dStartDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);

                oCmd.Parameters.AddWithValue("VATChallanNo", _nFromVATChallanNo);
                oCmd.Parameters.AddWithValue("VATChallanNo", _nToVATChallanNo);

                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);

                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION);

                oCmd.Parameters.AddWithValue("InvoiceStatus", (short)Dictionary.InvoiceStatus.CANCEL);

                oCmd.Parameters.AddWithValue("InvoiceDate", _dStartDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);

                oCmd.Parameters.AddWithValue("VATChallanNo", _nFromVATChallanNo);
                oCmd.Parameters.AddWithValue("VATChallanNo", _nToVATChallanNo);

                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);

                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION_REVERSE);

                oCmd.Parameters.AddWithValue("InvoiceStatus", (short)Dictionary.InvoiceStatus.CANCEL);

            }
            else if (nInvoiceSelectionCriteria == (long)Dictionary.InvoiceSelectionCriteria.BEWEEN_INVOICE_NO)
            {            

                sQueryStringMaster.Append("  select   ");
                sQueryStringMaster.Append("  q1.InvoiceID, q1.InvoiceNo, q1.InvoiceDate, q1.DeliveryDate, q1.VATChallanNo, q1.WarehouseID, q1.WarehouseCode, q1.WarehouseName, q1.InvoiceTypeID, q1.InvoiceTypeName, q1.InvoiceAmount, q1.Discount, q1.OtherCharge  ");
                sQueryStringMaster.Append("  ,q3.Quantity, q3.GrossSales, q3.CostPrice, q3.TradePrice, q3.ProductDiscount, q3.VAT,q3.AdjustedDPAmount,q3.AdjustedPWAmount   ");
                sQueryStringMaster.Append("  ,q2.*   ");
                sQueryStringMaster.Append("  from  ");
                sQueryStringMaster.Append("  (  ");
                sQueryStringMaster.Append("  Select IM.InvoiceID, IM.Invoiceno, IM.DeliveryDate, IM.CustomerID,WH.WarehouseID, WH.WarehouseCode, WH.WarehouseName, IM.InvoiceDate, IM.VATChallanNo, IM.InvoiceTypeID, IT.InvoiceTypeName  ");
                sQueryStringMaster.Append("  ,IM.InvoiceAmount, Abs( IM.Discount) as Discount, IM.OtherCharge   ");
                sQueryStringMaster.Append("  from t_SalesInvoice IM, t_InvoiceType IT, t_Warehouse WH  ");
                sQueryStringMaster.Append("  where IM.InvoiceNo Between ? and ? and IM.WarehouseID = WH.WarehouseID ");
                sQueryStringMaster.Append("  and IM.InvoiceTypeID in (?,?,?,?,?,?) and InvoiceStatus not in (?) and IM.InvoiceTypeID = IT.InvoiceTypeID  ");
                sQueryStringMaster.Append("  UNION ALL  ");
                sQueryStringMaster.Append("  Select IM.InvoiceID, IM.Invoiceno, IM.DeliveryDate, IM.CustomerID, WH.WarehouseID, WH.WarehouseCode, WH.WarehouseName, IM.InvoiceDate, IM.VATChallanNo, IM.InvoiceTypeID, IT.InvoiceTypeName  ");
                sQueryStringMaster.Append("  ,-IM.InvoiceAmount, -Abs( IM.Discount) as Discount, IM.OtherCharge   ");
                sQueryStringMaster.Append("  from t_SalesInvoice IM, t_InvoiceType IT, t_Warehouse WH  ");
                sQueryStringMaster.Append("  where IM.InvoiceNo Between ? and ? and IM.WarehouseID = WH.WarehouseID ");
                sQueryStringMaster.Append("  and IM.InvoiceTypeID in (?,?,?,?,?,?,?)  and InvoiceStatus not in (?) and IM.InvoiceTypeID = IT.InvoiceTypeID  ");
                sQueryStringMaster.Append("  ) as q1  ");
                sQueryStringMaster.Append("  left outer join  ");
                sQueryStringMaster.Append("  (  ");
                sQueryStringMaster.Append("  select * from v_CustomerDetails   ");
                sQueryStringMaster.Append("  )  ");
                sQueryStringMaster.Append("  as q2  ");
                sQueryStringMaster.Append("  on q1.CustomerID = q2.CustomerID  ");
                sQueryStringMaster.Append("  left outer join  ");
                sQueryStringMaster.Append("  (  ");
                sQueryStringMaster.Append("  select InvoiceID, (CRQuantity - DRQuantity) as Quantity, (CRGrossSales - DRGrossSales) as GrossSales  ");
                sQueryStringMaster.Append("  ,(CRCostPrice - CRCostPrice ) as CostPrice, (CRTradePrice - DRTradePrice) as TradePrice  ");
                sQueryStringMaster.Append("  ,(CRVAT - DRVAT) as VAT, (CRProductDiscount - DRProductDiscount) as ProductDiscount,(CRAdjustedDPAmount - DRAdjustedDPAmount) as AdjustedDPAmount,(CRAdjustedPWAmount - DRAdjustedPWAmount) as AdjustedPWAmount  ");
                sQueryStringMaster.Append("  from  ");
                sQueryStringMaster.Append("  (  ");
                sQueryStringMaster.Append("  Select IM.InvoiceID  ");
                sQueryStringMaster.Append("  ,sum(Quantity+ isnull(freeQty,0)) as CRQuantity, sum((Quantity+ isnull(freeQty,0)) * UnitPrice) as CRGrossSales, sum(Quantity * CostPrice) as CRCostPrice, sum((Quantity + isnull(freeqty,0))*TradePrice) as CRTradePrice, sum((Quantity+ isnull(freeqty,0)) * VATAmount * TradePrice) as CRVAT, sum(Quantity * ProductDiscount) as CRProductDiscount, isnull(sum(Quantity * AdjustedDPAmount),0) as CRAdjustedDPAmount, isnull(sum(Quantity * AdjustedPWAmount),0) as CRAdjustedPWAmount  ");
                sQueryStringMaster.Append("  ,0 as DRQuantity, 0 as DRGrossSales, 0 as DRCostPrice, 0 as DRTradePrice, 0 as DRVAT , 0 as DRProductDiscount, 0 as DRAdjustedDPAmount, 0 as DRAdjustedPWAmount  ");
                sQueryStringMaster.Append("  from t_SalesInvoice IM, t_SalesInvoiceDetail ID   ");
                sQueryStringMaster.Append("  where IM.InvoiceID = ID.InvoiceID  and IM.InvoiceNo Between ? and ? ");
                sQueryStringMaster.Append("  and IM.InvoiceTypeID in (?,?,?,?,?,?) and IM.invoicestatus not in (?)   ");
                sQueryStringMaster.Append("  Group by IM.InvoiceID  ");
                sQueryStringMaster.Append("  union all  ");
                sQueryStringMaster.Append("  Select IM.InvoiceID  ");
                sQueryStringMaster.Append("  ,0 as CRQuantity, 0 as CRGrossSales, 0 as CRCostPrice, 0 as CRTradePrice, 0 as CRVAT, 0 as CRProductDiscount, 0 as CRAdjustedDPAmount, 0 as CRAdjustedPWAmount  ");
                sQueryStringMaster.Append("  ,abs(sum( Quantity+ isnull(freeQty,0))) as DRQuantity, abs (sum((Quantity+ isnull(freeQty,0)) * UnitPrice)) as DRGrossSales,abs(sum(Quantity * CostPrice)) as DRCostPrice, abs(sum((Quantity + isnull(freeqty,0))*TradePrice)) as DRTradePrice, abs(sum((Quantity+ isnull(freeqty,0)) * VATAmount * TradePrice)) as DRVAT, sum(Quantity * ProductDiscount) as DRProductDiscount, isnull(sum(Quantity * AdjustedDPAmount),0) as DRAdjustedDPAmount, isnull(sum(Quantity * AdjustedPWAmount),0) as DRAdjustedPWAmount  ");
                sQueryStringMaster.Append("  from t_SalesInvoice IM, t_SalesInvoiceDetail ID   ");
                sQueryStringMaster.Append("  where IM.InvoiceID = ID.InvoiceID and  IM.InvoiceNo Between ? and ? ");
                sQueryStringMaster.Append("  and IM.InvoiceTypeID in (?,?,?,?,?,?,?) and IM.invoicestatus not in (?)   ");
                sQueryStringMaster.Append("  Group by IM.InvoiceID  ");
                sQueryStringMaster.Append("  ) as P1  ");
                sQueryStringMaster.Append("  )as q3  ");
                sQueryStringMaster.Append("  on q1.InvoiceID = q3.InvoiceID  ");

                //Command time out
                oCmd.CommandTimeout = 0;
                oCmd.CommandText = sQueryStringMaster.ToString();

                oCmd.Parameters.AddWithValue("InvoiceNo", _FromInvoiceNo);
                oCmd.Parameters.AddWithValue("InvoiceNo", _ToInvoiceNo);


                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);

                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION);

                oCmd.Parameters.AddWithValue("InvoiceStatus", (short)Dictionary.InvoiceStatus.CANCEL);


                oCmd.Parameters.AddWithValue("InvoiceNo", _FromInvoiceNo);
                oCmd.Parameters.AddWithValue("InvoiceNo", _ToInvoiceNo);

                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);

                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION_REVERSE);

                oCmd.Parameters.AddWithValue("InvoiceStatus", (short)Dictionary.InvoiceStatus.CANCEL);

                oCmd.Parameters.AddWithValue("InvoiceNo", _FromInvoiceNo);
                oCmd.Parameters.AddWithValue("InvoiceNo", _ToInvoiceNo);

                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);

                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION);

                oCmd.Parameters.AddWithValue("InvoiceStatus", (short)Dictionary.InvoiceStatus.CANCEL);


                oCmd.Parameters.AddWithValue("InvoiceNo", _FromInvoiceNo);
                oCmd.Parameters.AddWithValue("InvoiceNo", _ToInvoiceNo);

                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);

                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT_REVERSE);
                oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION_REVERSE);

                oCmd.Parameters.AddWithValue("InvoiceStatus", (short)Dictionary.InvoiceStatus.CANCEL);

            }

            InvoiceRegisterWithVatGrosssaleDetail(oCmd);

        }
        private void InvoiceRegisterWithVatGrosssaleDetail(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    InvoiceRegisterWithVatGrosssale oItem = new InvoiceRegisterWithVatGrosssale();

                    if (reader["SBUID"] != DBNull.Value)
                        oItem.SBUID = Convert.ToInt32(reader["SBUID"]);
                    else oItem.SBUID = -1;
                    if (reader["SBUName"] != DBNull.Value)
                        oItem.SBUName = (reader["SBUName"].ToString());
                    else oItem.SBUName = "";
                    if (reader["ChannelID"] != DBNull.Value)
                        oItem.ChannelId = (int)reader["ChannelID"];
                    else oItem.ChannelId = -1;                 
                    if (reader["AreaId"] != DBNull.Value)
                        oItem.AreaId = (int)reader["AreaId"];
                    else oItem.AreaId = -1;                  
                    if (reader["TerritoryId"] != DBNull.Value)
                        oItem.TerritoryId = (int)reader["TerritoryId"];
                    else oItem.TerritoryId = -1;         
                    if (reader["CustomerCode"] != DBNull.Value)
                        oItem.CustomerCode = (string)reader["CustomerCode"];
                    else oItem.CustomerCode = "";
                    if (reader["CustomerName"] != DBNull.Value)
                        oItem.CustomerName = (string)reader["CustomerName"];
                    else oItem.CustomerName = "";                  
                    if (reader["InvoiceAmount"] != DBNull.Value)
                        oItem.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    else oItem.InvoiceAmount = 0;
                    if (reader["Discount"] != DBNull.Value)
                        oItem.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    else oItem.Discount = 0;
                    if (reader["InvoiceNo"] != DBNull.Value)
                        oItem.InvoiceNo = (string)reader["InvoiceNo"];
                    else oItem.InvoiceNo = "";
                    if (reader["InvoiceDate"] != DBNull.Value)
                        oItem.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"]);
                    else oItem.InvoiceDate = DateTime.Today.Date;
                    if (reader["WarehouseID"] != DBNull.Value)
                        oItem.WarehouseID = Convert.ToInt32(reader["WarehouseID"]);
                    else oItem.WarehouseID = -1;
                    if (reader["WarehouseCode"] != DBNull.Value)
                        oItem.WarehouseCode = (reader["WarehouseCode"].ToString());
                    else oItem.WarehouseCode = "";
                    if (reader["WarehouseName"] != DBNull.Value)
                        oItem.WarehouseName = (reader["WarehouseName"].ToString());
                    else oItem.WarehouseName = "";
                    if (reader["VatChallanNo"] != DBNull.Value)
                        oItem.VatChallanNo = Convert.ToInt32(reader["VatChallanNo"]);
                    else oItem.VatChallanNo = -1;
                    if (reader["GrossSales"] != DBNull.Value)
                        oItem.GrossSales = Convert.ToDouble(reader["GrossSales"].ToString());
                    else oItem.GrossSales = 0;
                    if (reader["VAT"] != DBNull.Value)
                        oItem.VAT = Convert.ToDouble(reader["VAT"].ToString());
                    else oItem.VAT = 0;
                    if (reader["TradePrice"] != DBNull.Value)
                        oItem.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    else oItem.TradePrice = 0;
                    if (reader["DeliveryDate"] != DBNull.Value)
                        oItem.DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"]);
                    else oItem.DeliveryDate = DateTime.Today.Date;
                    if (reader["AdjustedDPAmount"] != DBNull.Value)
                        oItem.AdjustedDPAmount = Convert.ToDouble(reader["AdjustedDPAmount"].ToString());
                    else oItem.AdjustedDPAmount = 0;
                    if (reader["AdjustedPWAmount"] != DBNull.Value)
                        oItem.AdjustedPWAmount = Convert.ToDouble(reader["AdjustedPWAmount"].ToString());
                    else oItem.AdjustedPWAmount = 0;
                    if (reader["CustomerTypeID"] != DBNull.Value)
                        oItem.CoustomerType = Convert.ToInt32(reader["CustomerTypeID"]);
                    else oItem.CoustomerType = -1;
                    if (reader["InvoiceTypeID"] != DBNull.Value)
                        oItem.InvoiceType = Convert.ToInt32(reader["InvoiceTypeID"]);
                    else oItem.InvoiceType = -1;


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
        public void FromDataSetForInvoiceRegisterWithVatGrosssale(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    InvoiceRegisterWithVatGrosssale oInvoiceRegisterWithVatGrosssale = new InvoiceRegisterWithVatGrosssale();

               
                        oInvoiceRegisterWithVatGrosssale.SBUID = Convert.ToInt32(oRow["SBUID"]);                   
                        oInvoiceRegisterWithVatGrosssale.SBUName = (oRow["SBUName"].ToString());                   
                        oInvoiceRegisterWithVatGrosssale.ChannelId = (int)oRow["ChannelID"];                   
                        oInvoiceRegisterWithVatGrosssale.AreaId = (int)oRow["AreaId"];                    
                        oInvoiceRegisterWithVatGrosssale.TerritoryId = (int)oRow["TerritoryId"];                    
                        oInvoiceRegisterWithVatGrosssale.CustomerCode = (string)oRow["CustomerCode"];                    
                        oInvoiceRegisterWithVatGrosssale.CustomerName = (string)oRow["CustomerName"];                  
                        oInvoiceRegisterWithVatGrosssale.InvoiceAmount = Convert.ToDouble(oRow["InvoiceAmount"].ToString());                   
                        oInvoiceRegisterWithVatGrosssale.Discount = Convert.ToDouble(oRow["Discount"].ToString());                 
                        oInvoiceRegisterWithVatGrosssale.InvoiceNo = (string)oRow["InvoiceNo"];                
                        oInvoiceRegisterWithVatGrosssale.InvoiceDate = Convert.ToDateTime(oRow["InvoiceDate"]);              
                        oInvoiceRegisterWithVatGrosssale.WarehouseID = Convert.ToInt32(oRow["WarehouseID"]);               
                        oInvoiceRegisterWithVatGrosssale.WarehouseCode = (oRow["WarehouseCode"].ToString());             
                        oInvoiceRegisterWithVatGrosssale.WarehouseName = (oRow["WarehouseName"].ToString());             
                        oInvoiceRegisterWithVatGrosssale.VatChallanNo = Convert.ToInt32(oRow["VatChallanNo"]);            
                        oInvoiceRegisterWithVatGrosssale.GrossSales = Convert.ToDouble(oRow["GrossSales"].ToString());                  
                        oInvoiceRegisterWithVatGrosssale.VAT = Convert.ToDouble(oRow["VAT"].ToString());
                        oInvoiceRegisterWithVatGrosssale.TradePrice = Convert.ToDouble(oRow["TradePrice"].ToString());                
                        oInvoiceRegisterWithVatGrosssale.DeliveryDate = Convert.ToDateTime(oRow["DeliveryDate"]);         
                        oInvoiceRegisterWithVatGrosssale.AdjustedDPAmount = Convert.ToDouble(oRow["AdjustedDPAmount"].ToString());
                        oInvoiceRegisterWithVatGrosssale.AdjustedPWAmount = Convert.ToDouble(oRow["AdjustedPWAmount"].ToString());             
                        oInvoiceRegisterWithVatGrosssale.CoustomerType = Convert.ToInt32(oRow["CoustomerType"]);                
                        oInvoiceRegisterWithVatGrosssale.InvoiceType = Convert.ToInt32(oRow["InvoiceType"]);             

                    InnerList.Add(oInvoiceRegisterWithVatGrosssale);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetDutyRegister(int nInvoiceSelectionCriteria, int nChallanType, DateTime _dStartDate, DateTime _dEndDate, long _nFromVATChallanNo, long _nToVATChallanNo, long _FromInvoiceNo, long _ToInvoiceNo)
        {
            _dEndDate = _dEndDate.AddDays(1);
            OleDbCommand oCmd = DBController.Instance.GetCommand();         
            string sSql = "";

            if (nInvoiceSelectionCriteria == (long)Dictionary.InvoiceSelectionCriteria.Between_Date)
            {

                sSql = " Set DateFormat dmy "
                               + " Select VatChallanNo,InvoiceNo as DocumentNo,InvoiceDate,cast(convert(nvarchar(12),DeliveryDate,106)as DateTime) as DeliveryDate,CustomerCode,CustomerName,GrossSales, "
                               + " TradePrice = case when invoicetypeid in (6,7,9,10,12,8,16) then -TradePrice else TradePrice end "
                               + " ,VAT = case when invoicetypeid in (6,7,9,10,12,8,16) then -VAT else VAT end, "
                               + " OtherCharge, Discount,Quantity, InvoiceAmount,ProductDiscount,AdjustedDPAmount,AdjustedPWAmount,AdjustedTPAmount,CostPrice, "
                               + " WarehouseID,WarehouseCode,WarehouseName "
                               + " From "
                               + " ( "
                               + " Select DutyTranNo as VatChallanNo,DutyTranDate as DeliveryDate,RefID as InvoiceID, round(sum(Qty*dutyprice*dutyrate),4)as VAT,round(sum(Qty*dutyprice),4) as TradePrice  "
                               + " from t_dutytran a,t_dutytrandetail b "
                               + " where a.dutytranid = b.dutytranid and DutyTrantypeid = 1 and Challantypeid = ? and DutyTranDate between ? and ? and DutyTranDate < ? "
                               + " Group by DutyTranNo,DutyTranDate,RefID  "
                               + " ) as a "
                               + " left outer join "
                               + " ( "
                               + " Select q1.InvoiceID,InvoiceNo, InvoiceDate,CustomerCode,CustomerName,WarehouseID,WarehouseCode,WarehouseName, InvoiceTypeID, InvoiceTypeName,InvoiceAmount, Discount,isnull(OtherCharge,0) as OtherCharge   "
                               + " ,Quantity, GrossSales = CASE WHEN q1.InvoiceTypeID = 3 THEN 0 WHEN q1.InvoiceTypeID = 8 THEN 0 ELSE GrossSales END, CostPrice,ProductDiscount,AdjustedDPAmount,AdjustedPWAmount,AdjustedTPAmount  "
                               + " from "
                               + " ( "
                               + " Select IM.InvoiceID, IM.Invoiceno, IM.CustomerID, WH.WarehouseID, WH.WarehouseCode, WH.WarehouseName,IM.InvoiceDate,IM.InvoiceTypeID, IT.InvoiceTypeName  "
                               + " ,InvoiceAmount = CASE WHEN IM.InvoiceTypeID = 3 THEN 0 ELSE IM.InvoiceAmount END, Discount = CASE WHEN IM.InvoiceTypeID = 3 THEN 0 ELSE IM.Discount END, IM.OtherCharge  "
                               + " from t_SalesInvoice IM, t_InvoiceType IT, t_Warehouse WH  "
                               + " where IM.DeliveryDate Between ? and ? and IM.DeliveryDate < ? and IM.WarehouseID = WH.WarehouseID  "
                               + " and IM.InvoiceTypeID in (1,2,3,4,5,15) and InvoiceStatus not in (3) and IM.InvoiceTypeID = IT.InvoiceTypeID  "
                               + " UNION ALL  "
                               + " Select IM.InvoiceID, IM.Invoiceno, IM.CustomerID,WH.WarehouseID, WH.WarehouseCode, WH.WarehouseName, IM.InvoiceDate,IM.InvoiceTypeID, IT.InvoiceTypeName  "
                               + " ,InvoiceAmount = CASE WHEN IM.InvoiceTypeID = 3 THEN 0 ELSE -IM.InvoiceAmount END, Discount = CASE WHEN IM.InvoiceTypeID = 3 THEN 0 ELSE -Abs(IM.Discount) END, IM.OtherCharge  "
                               + " from t_SalesInvoice IM, t_InvoiceType IT, t_Warehouse WH  "
                               + " where IM.DeliveryDate Between ? and ? and IM.DeliveryDate < ? and IM.WarehouseID = WH.WarehouseID  "
                               + " and IM.InvoiceTypeID in (6,7,9,10,12,8,16) and InvoiceStatus not in (3) and IM.InvoiceTypeID = IT.InvoiceTypeID  "
                               + " ) as q1 "
                               + " left outer join     "
                               + " (     "
                               + " select CustomerID,CustomerCode,CustomerName from t_Customer   "
                               + " )    "
                               + " as q3     "
                               + " on q1.CustomerID = q3.CustomerID  "
                               + " left outer join "
                               + " (  "
                               + " select InvoiceID, (CRQuantity - DRQuantity) as Quantity, (CRGrossSales - DRGrossSales) as GrossSales,(CRCostPrice - CRCostPrice ) as CostPrice,  "
                               + " (CRProductDiscount - DRProductDiscount) as ProductDiscount,(CRAdjustedDPAmount - DRAdjustedDPAmount) as AdjustedDPAmount,(CRAdjustedPWAmount - DRAdjustedPWAmount) as AdjustedPWAmount "
                               + " ,(CRAdjustedTPAmount - DRAdjustedTPAmount) as AdjustedTPAmount  "
                               + " from  "
                               + " (  "
                               + " Select IM.InvoiceID  "
                               + " ,sum(Quantity+ isnull(freeQty,0)) as CRQuantity, sum((Quantity+ isnull(freeQty,0)) * UnitPrice) as CRGrossSales, sum(Quantity * CostPrice) as CRCostPrice, sum((Quantity+ isnull(freeqty,0))*TradePrice) as CRTradePrice, sum((Quantity + isnull(freeqty,0)) * VATAmount * TradePrice) as CRVAT, sum(Quantity * ProductDiscount) as CRProductDiscount "
                               + " ,isnull(sum(Quantity * AdjustedDPAmount),0) as CRAdjustedDPAmount, isnull(sum(Quantity * AdjustedPWAmount),0) as CRAdjustedPWAmount, isnull(sum(Quantity * AdjustedTPAmount),0) as CRAdjustedTPAmount  "
                               + " ,0 as DRQuantity, 0 as DRGrossSales, 0 as DRCostPrice, 0 as DRTradePrice, 0 as DRVAT , 0 as DRProductDiscount, 0 as DRAdjustedDPAmount, 0 as DRAdjustedPWAmount, 0 as DRAdjustedTPAmount  "
                               + " from t_SalesInvoice IM, t_SalesInvoiceDetail ID  "
                               + " where IM.InvoiceID = ID.InvoiceID and IM.DeliveryDate Between ? and ? and IM.DeliveryDate < ?  "
                               + " and IM.InvoiceTypeID in (1,2,3,4,5,15) and IM.invoicestatus not in (3)  "
                               + " Group by IM.InvoiceID  "
                               + " union all  "
                               + " Select IM.InvoiceID  "
                               + " ,0 as CRQuantity, 0 as CRGrossSales, 0 as CRCostPrice, 0 as CRTradePrice, 0 as CRVAT, 0 as CRProductDiscount, 0 as CRAdjustedDPAmount, 0 as CRAdjustedPWAmount, 0 as CRAdjustedTPAmount  "
                               + " ,abs(sum( Quantity+ isnull(freeQty,0))) as DRQuantity, abs (sum((Quantity + isnull(freeQty,0))* UnitPrice)) as DRGrossSales,abs(sum(Quantity * CostPrice)) as DRCostPrice, abs(sum((Quantity + isnull(freeqty,0))*TradePrice)) as DRTradePrice, abs(sum((Quantity + isnull(freeqty,0)) * VATAmount * TradePrice)) as DRVAT, sum(Quantity * ProductDiscount) as DRProductDiscount "
                               + " ,isnull(sum(Quantity * AdjustedDPAmount),0) as DRAdjustedDPAmount, isnull(sum(Quantity * AdjustedPWAmount),0) as DRAdjustedPWAmount, isnull(sum(Quantity * AdjustedTPAmount),0) as DRAdjustedTPAmount  "
                               + " from t_SalesInvoice IM, t_SalesInvoiceDetail ID  "
                               + " where IM.InvoiceID = ID.InvoiceID and IM.DeliveryDate Between ? and ? and IM.DeliveryDate < ? "
                               + " and IM.InvoiceTypeID in (6,7,9,10,12,8,16) and IM.invoicestatus not in (3)  "
                               + " Group by IM.InvoiceID  "
                               + " ) as P1  "
                               + " ) as q2 on q1.invoiceid = q2.invoiceid "
                               + " ) as b on a.invoiceid = b.invoiceid "
                               + " union all  "
                               + " Select VatChallanNo,TranNo as DocumentNo,DeliveryDate as InvoiceDate,cast(convert(nvarchar(12),DeliveryDate,106)as DateTime) as DeliveryDate, "
                               + " CustomerCode = case when CustomerCode is null then WarehouseCode else CustomerCode end, "
                               + " CustomerName = case when CustomerName is null then WarehouseName else CustomerName end, "
                               + " GrossSales,TradePrice,VAT,  "
                               + " OtherCharge=0, Discount=0,Quantity=0, GrossSales as InvoiceAmount,ProductDiscount=0,AdjustedDPAmount=0,AdjustedPWAmount=0,AdjustedTPAmount=0,CostPrice=0, "
                               + " WarehouseID,WarehouseCode,WarehouseName "
                               + " from "
                               + " ( "
                               + " Select VatChallanNo,DeliveryDate,TranNo,CustomerCode,CustomerName,(TradePrice*1.04)as GrossSales,TradePrice,VAT,WHID as WarehouseID,WarehouseCode,WarehouseName "
                               + " from "
                               + " ( "
                               + " select qq1.*,WarehouseCode as CustomerCode,WarehouseName as CustomerName,WarehouseCode,WarehouseName "
                               + " from "
                               + " ( "
                               + " Select DutyTranNo as VatChallanNo,DutyTranDate as DeliveryDate,DocumentNo as TranNo,RefID as TranID,WHID, round(sum(Qty*dutyprice*dutyrate),4)as VAT,round(sum(Qty*dutyprice),4) as TradePrice  "
                               + " from t_dutytran a,t_dutytrandetail b "
                               + " where a.dutytranid = b.dutytranid and DutyTrantypeid = 2 and Challantypeid = ? and DutyTranDate between ? and ? and DutyTranDate < ?  "
                               + " Group by DutyTranNo,DutyTranDate,RefID,WHID,DocumentNo "
                               + " ) as qq1 "
                               + " left outer join "
                               + " ( "
                               + " Select * from t_warehouse  "
                               + " ) as wh on qq1.whid = wh.warehouseid "
                               + " ) as final "
                               + " ) as aa ";

                oCmd.CommandTimeout = 0;
                oCmd.CommandText = sSql;

                oCmd.Parameters.AddWithValue("Challantypeid", nChallanType);
                oCmd.Parameters.AddWithValue("DutyTranDate", _dStartDate.Date);
                oCmd.Parameters.AddWithValue("DutyTranDate", _dEndDate.Date);
                oCmd.Parameters.AddWithValue("DutyTranDate", _dEndDate.Date);

                oCmd.Parameters.AddWithValue("InvoiceDate", _dStartDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);

                oCmd.Parameters.AddWithValue("InvoiceDate", _dStartDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);

                oCmd.Parameters.AddWithValue("InvoiceDate", _dStartDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);

                oCmd.Parameters.AddWithValue("InvoiceDate", _dStartDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);

                oCmd.Parameters.AddWithValue("Challantypeid", nChallanType);

                oCmd.Parameters.AddWithValue("DutyTranDate", _dStartDate.Date);
                oCmd.Parameters.AddWithValue("DutyTranDate", _dEndDate.Date);
                oCmd.Parameters.AddWithValue("DutyTranDate", _dEndDate.Date);


            }
            else if (nInvoiceSelectionCriteria == (long)Dictionary.InvoiceSelectionCriteria.BETWEEN_VAT_CHALLAN_NO)
            {
                sSql = " Set DateFormat dmy "
                              + " Select VatChallanNo,InvoiceNo as DocumentNo,InvoiceDate,cast(convert(nvarchar(12),DeliveryDate,106)as DateTime) as DeliveryDate,CustomerCode,CustomerName,GrossSales, "
                              + " TradePrice = case when invoicetypeid in (6,7,9,10,12,8,16) then -TradePrice else TradePrice end "
                              + " ,VAT = case when invoicetypeid in (6,7,9,10,12,8,16) then -VAT else VAT end, "
                              + " OtherCharge, Discount,Quantity, InvoiceAmount,ProductDiscount,AdjustedDPAmount,AdjustedPWAmount,AdjustedTPAmount,CostPrice, "
                              + " WarehouseID,WarehouseCode,WarehouseName "
                              + " From "
                              + " ( "
                              + " Select DutyTranNo as VatChallanNo,DutyTranDate as DeliveryDate,RefID as InvoiceID, round(sum(Qty*dutyprice*dutyrate),4)as VAT,round(sum(Qty*dutyprice),4) as TradePrice  "
                              + " from t_dutytran a,t_dutytrandetail b "
                              + " where a.dutytranid = b.dutytranid and DutyTrantypeid = 1 and Challantypeid = ? and DutyTranDate between ? and ? and DutyTranDate < ? "
                              + " and DutyTranNo Between ? and ? "
                              + " Group by DutyTranNo,DutyTranDate,RefID  "
                              + " ) as a "
                              + " left outer join "
                              + " ( "
                              + " Select q1.InvoiceID,InvoiceNo, InvoiceDate,CustomerCode,CustomerName,WarehouseID,WarehouseCode,WarehouseName, InvoiceTypeID, InvoiceTypeName,InvoiceAmount, Discount,isnull(OtherCharge,0) as OtherCharge   "
                              + " ,Quantity, GrossSales = CASE WHEN q1.InvoiceTypeID = 3 THEN 0 WHEN q1.InvoiceTypeID = 8 THEN 0 ELSE GrossSales END, CostPrice,ProductDiscount,AdjustedDPAmount,AdjustedPWAmount,AdjustedTPAmount  "
                              + " from "
                              + " ( "
                              + " Select IM.InvoiceID, IM.Invoiceno, IM.CustomerID, WH.WarehouseID, WH.WarehouseCode, WH.WarehouseName,IM.InvoiceDate,IM.InvoiceTypeID, IT.InvoiceTypeName  "
                              + " ,InvoiceAmount = CASE WHEN IM.InvoiceTypeID = 3 THEN 0 ELSE IM.InvoiceAmount END, Discount = CASE WHEN IM.InvoiceTypeID = 3 THEN 0 ELSE IM.Discount END, IM.OtherCharge  "
                              + " from t_SalesInvoice IM, t_InvoiceType IT, t_Warehouse WH  "
                              + " where IM.DeliveryDate Between ? and ? and IM.DeliveryDate < ? and IM.WarehouseID = WH.WarehouseID  "
                              + " and IM.InvoiceTypeID in (1,2,3,4,5,15) and InvoiceStatus not in (3) and IM.InvoiceTypeID = IT.InvoiceTypeID  "
                              + " UNION ALL  "
                              + " Select IM.InvoiceID, IM.Invoiceno, IM.CustomerID,WH.WarehouseID, WH.WarehouseCode, WH.WarehouseName, IM.InvoiceDate,IM.InvoiceTypeID, IT.InvoiceTypeName  "
                              + " ,InvoiceAmount = CASE WHEN IM.InvoiceTypeID = 3 THEN 0 ELSE -IM.InvoiceAmount END, Discount = CASE WHEN IM.InvoiceTypeID = 3 THEN 0 ELSE -Abs(IM.Discount) END, IM.OtherCharge  "
                              + " from t_SalesInvoice IM, t_InvoiceType IT, t_Warehouse WH  "
                              + " where IM.DeliveryDate Between ? and ? and IM.DeliveryDate < ? and IM.WarehouseID = WH.WarehouseID  "
                              + " and IM.InvoiceTypeID in (6,7,9,10,12,8,16) and InvoiceStatus not in (3) and IM.InvoiceTypeID = IT.InvoiceTypeID  "
                              + " ) as q1 "
                              + " left outer join     "
                              + " (     "
                              + " select CustomerID,CustomerCode,CustomerName from t_Customer   "
                              + " )    "
                              + " as q3     "
                              + " on q1.CustomerID = q3.CustomerID  "
                              + " left outer join "
                              + " (  "
                              + " select InvoiceID, (CRQuantity - DRQuantity) as Quantity, (CRGrossSales - DRGrossSales) as GrossSales,(CRCostPrice - CRCostPrice ) as CostPrice,  "
                              + " (CRProductDiscount - DRProductDiscount) as ProductDiscount,(CRAdjustedDPAmount - DRAdjustedDPAmount) as AdjustedDPAmount,(CRAdjustedPWAmount - DRAdjustedPWAmount) as AdjustedPWAmount "
                              + " ,(CRAdjustedTPAmount - DRAdjustedTPAmount) as AdjustedTPAmount  "
                              + " from  "
                              + " (  "
                              + " Select IM.InvoiceID  "
                              + " ,sum(Quantity+ isnull(freeQty,0)) as CRQuantity, sum((Quantity+ isnull(freeQty,0)) * UnitPrice) as CRGrossSales, sum(Quantity * CostPrice) as CRCostPrice, sum((Quantity+ isnull(freeqty,0))*TradePrice) as CRTradePrice, sum((Quantity + isnull(freeqty,0)) * VATAmount * TradePrice) as CRVAT, sum(Quantity * ProductDiscount) as CRProductDiscount "
                              + " ,isnull(sum(Quantity * AdjustedDPAmount),0) as CRAdjustedDPAmount, isnull(sum(Quantity * AdjustedPWAmount),0) as CRAdjustedPWAmount, isnull(sum(Quantity * AdjustedTPAmount),0) as CRAdjustedTPAmount  "
                              + " ,0 as DRQuantity, 0 as DRGrossSales, 0 as DRCostPrice, 0 as DRTradePrice, 0 as DRVAT , 0 as DRProductDiscount, 0 as DRAdjustedDPAmount, 0 as DRAdjustedPWAmount, 0 as DRAdjustedTPAmount  "
                              + " from t_SalesInvoice IM, t_SalesInvoiceDetail ID  "
                              + " where IM.InvoiceID = ID.InvoiceID and IM.DeliveryDate Between ? and ? and IM.DeliveryDate < ?  "
                              + " and IM.InvoiceTypeID in (1,2,3,4,5,15) and IM.invoicestatus not in (3)  "
                              + " Group by IM.InvoiceID  "
                              + " union all  "
                              + " Select IM.InvoiceID  "
                              + " ,0 as CRQuantity, 0 as CRGrossSales, 0 as CRCostPrice, 0 as CRTradePrice, 0 as CRVAT, 0 as CRProductDiscount, 0 as CRAdjustedDPAmount, 0 as CRAdjustedPWAmount, 0 as CRAdjustedTPAmount  "
                              + " ,abs(sum( Quantity+ isnull(freeQty,0))) as DRQuantity, abs (sum((Quantity + isnull(freeQty,0))* UnitPrice)) as DRGrossSales,abs(sum(Quantity * CostPrice)) as DRCostPrice, abs(sum((Quantity + isnull(freeqty,0))*TradePrice)) as DRTradePrice, abs(sum((Quantity + isnull(freeqty,0)) * VATAmount * TradePrice)) as DRVAT, sum(Quantity * ProductDiscount) as DRProductDiscount "
                              + " ,isnull(sum(Quantity * AdjustedDPAmount),0) as DRAdjustedDPAmount, isnull(sum(Quantity * AdjustedPWAmount),0) as DRAdjustedPWAmount, isnull(sum(Quantity * AdjustedTPAmount),0) as DRAdjustedTPAmount  "
                              + " from t_SalesInvoice IM, t_SalesInvoiceDetail ID  "
                              + " where IM.InvoiceID = ID.InvoiceID and IM.DeliveryDate Between ? and ? and IM.DeliveryDate < ? "
                              + " and IM.InvoiceTypeID in (6,7,9,10,12,8,16) and IM.invoicestatus not in (3)  "
                              + " Group by IM.InvoiceID  "
                              + " ) as P1  "
                              + " ) as q2 on q1.invoiceid = q2.invoiceid "
                              + " ) as b on a.invoiceid = b.invoiceid "
                              + " union all  "
                              + " Select VatChallanNo,TranNo as DocumentNo,DeliveryDate as InvoiceDate,cast(convert(nvarchar(12),DeliveryDate,106)as DateTime) as DeliveryDate, "
                              + " CustomerCode = case when CustomerCode is null then WarehouseCode else CustomerCode end, "
                              + " CustomerName = case when CustomerName is null then WarehouseName else CustomerName end, "
                              + " GrossSales,TradePrice,VAT,  "
                              + " OtherCharge=0, Discount=0,Quantity=0, GrossSales as InvoiceAmount,ProductDiscount=0,AdjustedDPAmount=0,AdjustedPWAmount=0,AdjustedTPAmount=0,CostPrice=0, "
                              + " WarehouseID,WarehouseCode,WarehouseName "
                              + " from "
                              + " ( "
                              + " Select VatChallanNo,DeliveryDate,TranNo,CustomerCode,CustomerName,(TradePrice*1.04)as GrossSales,TradePrice,VAT,WHID as WarehouseID,WarehouseCode,WarehouseName "
                              + " from "
                              + " ( "
                              + " select qq1.*,WarehouseCode as CustomerCode,WarehouseName as CustomerName,WarehouseCode,WarehouseName "
                              + " from "
                              + " ( "
                              + " Select DutyTranNo as VatChallanNo,DutyTranDate as DeliveryDate,DocumentNo as TranNo,RefID as TranID,WHID, round(sum(Qty*dutyprice*dutyrate),4)as VAT,round(sum(Qty*dutyprice),4) as TradePrice  "
                              + " from t_dutytran a,t_dutytrandetail b "
                              + " where a.dutytranid = b.dutytranid and DutyTrantypeid = 2 and Challantypeid = ? and DutyTranDate between ? and ? and DutyTranDate < ?  "
                              + " and DutyTranNo Between ? and ? "
                              + " Group by DutyTranNo,DutyTranDate,RefID,WHID,DocumentNo "
                              + " ) as qq1 "
                              + " left outer join "
                              + " ( "
                              + " Select * from t_warehouse  "
                              + " ) as wh on qq1.whid = wh.warehouseid "
                              + " ) as final "
                              + " ) as aa ";

                oCmd.CommandTimeout = 0;
                oCmd.CommandText = sSql;

                oCmd.Parameters.AddWithValue("Challantypeid", nChallanType);
                oCmd.Parameters.AddWithValue("DutyTranDate", _dStartDate.Date);
                oCmd.Parameters.AddWithValue("DutyTranDate", _dEndDate.Date);
                oCmd.Parameters.AddWithValue("DutyTranDate", _dEndDate.Date);
                oCmd.Parameters.AddWithValue("DutyTranNo", _nFromVATChallanNo);
                oCmd.Parameters.AddWithValue("DutyTranNo", _nToVATChallanNo);

                oCmd.Parameters.AddWithValue("InvoiceDate", _dStartDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);

                oCmd.Parameters.AddWithValue("InvoiceDate", _dStartDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);

                oCmd.Parameters.AddWithValue("InvoiceDate", _dStartDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);

                oCmd.Parameters.AddWithValue("InvoiceDate", _dStartDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);
                oCmd.Parameters.AddWithValue("InvoiceDate", _dEndDate.Date);

                oCmd.Parameters.AddWithValue("Challantypeid", nChallanType);

                oCmd.Parameters.AddWithValue("DutyTranDate", _dStartDate.Date);
                oCmd.Parameters.AddWithValue("DutyTranDate", _dEndDate.Date);
                oCmd.Parameters.AddWithValue("DutyTranDate", _dEndDate.Date);
                oCmd.Parameters.AddWithValue("DutyTranNo", _nFromVATChallanNo);
                oCmd.Parameters.AddWithValue("DutyTranNo", _nToVATChallanNo);

            }
            else if (nInvoiceSelectionCriteria == (long)Dictionary.InvoiceSelectionCriteria.BEWEEN_INVOICE_NO)
            {
            }

            DutyRegister(oCmd);

        }
        private void DutyRegister(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    InvoiceRegisterWithVatGrosssale oItem = new InvoiceRegisterWithVatGrosssale();

                    oItem.SBUID = -1;
                    oItem.SBUName = "";
                    oItem.ChannelId = -1;
                    oItem.AreaId = -1;
                    oItem.TerritoryId = -1;
                    if (reader["CustomerCode"] != DBNull.Value)
                        oItem.CustomerCode = (string)reader["CustomerCode"];
                    else oItem.CustomerCode = "";
                    if (reader["CustomerName"] != DBNull.Value)
                        oItem.CustomerName = (string)reader["CustomerName"];
                    else oItem.CustomerName = "";
                    if (reader["InvoiceAmount"] != DBNull.Value)
                        oItem.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    else oItem.InvoiceAmount = 0;
                    if (reader["Discount"] != DBNull.Value)
                        oItem.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    else oItem.Discount = 0;
                    if (reader["DocumentNo"] != DBNull.Value)
                        oItem.InvoiceNo = (string)reader["DocumentNo"];
                    else oItem.InvoiceNo = "";
                    if (reader["InvoiceDate"] != DBNull.Value)
                        oItem.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"]);
                    else oItem.InvoiceDate = DateTime.Today.Date;
                    if (reader["WarehouseID"] != DBNull.Value)
                        oItem.WarehouseID = Convert.ToInt32(reader["WarehouseID"]);
                    else oItem.WarehouseID = -1;
                    if (reader["WarehouseCode"] != DBNull.Value)
                        oItem.WarehouseCode = (reader["WarehouseCode"].ToString());
                    else oItem.WarehouseCode = "";
                    if (reader["WarehouseName"] != DBNull.Value)
                        oItem.WarehouseName = (reader["WarehouseName"].ToString());
                    else oItem.WarehouseName = "";
                    if (reader["VatChallanNo"] != DBNull.Value)
                        oItem.VatChallanNo = Convert.ToInt32(reader["VatChallanNo"]);
                    else oItem.VatChallanNo = -1;
                    if (reader["GrossSales"] != DBNull.Value)
                        oItem.GrossSales = Convert.ToDouble(reader["GrossSales"].ToString());
                    else oItem.GrossSales = 0;
                    if (reader["VAT"] != DBNull.Value)
                        oItem.VAT = Convert.ToDouble(reader["VAT"].ToString());
                    else oItem.VAT = 0;
                    if (reader["TradePrice"] != DBNull.Value)
                        oItem.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    else oItem.TradePrice = 0;
                    if (reader["DeliveryDate"] != DBNull.Value)
                        oItem.DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"]);
                    else oItem.DeliveryDate = DateTime.Today.Date;
                    if (reader["AdjustedDPAmount"] != DBNull.Value)
                        oItem.AdjustedDPAmount = Convert.ToDouble(reader["AdjustedDPAmount"].ToString());
                    else oItem.AdjustedDPAmount = 0;
                    if (reader["AdjustedPWAmount"] != DBNull.Value)
                        oItem.AdjustedPWAmount = Convert.ToDouble(reader["AdjustedPWAmount"].ToString());
                    else oItem.AdjustedPWAmount = 0;
                    oItem.CoustomerType = -1;
                    oItem.InvoiceType = -1;


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
        public void FromDataSetForDutyRegister(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    InvoiceRegisterWithVatGrosssale oInvoiceRegisterWithVatGrosssale = new InvoiceRegisterWithVatGrosssale();


                    oInvoiceRegisterWithVatGrosssale.SBUID = Convert.ToInt32(oRow["SBUID"]);
                    oInvoiceRegisterWithVatGrosssale.SBUName = (oRow["SBUName"].ToString());
                    oInvoiceRegisterWithVatGrosssale.ChannelId = (int)oRow["ChannelID"];
                    oInvoiceRegisterWithVatGrosssale.AreaId = (int)oRow["AreaId"];
                    oInvoiceRegisterWithVatGrosssale.TerritoryId = (int)oRow["TerritoryId"];
                    oInvoiceRegisterWithVatGrosssale.CustomerCode = (string)oRow["CustomerCode"];
                    oInvoiceRegisterWithVatGrosssale.CustomerName = (string)oRow["CustomerName"];
                    oInvoiceRegisterWithVatGrosssale.InvoiceAmount = Convert.ToDouble(oRow["InvoiceAmount"].ToString());
                    oInvoiceRegisterWithVatGrosssale.Discount = Convert.ToDouble(oRow["Discount"].ToString());
                    oInvoiceRegisterWithVatGrosssale.InvoiceNo = (string)oRow["InvoiceNo"];
                    oInvoiceRegisterWithVatGrosssale.InvoiceDate = Convert.ToDateTime(oRow["InvoiceDate"]);
                    oInvoiceRegisterWithVatGrosssale.WarehouseID = Convert.ToInt32(oRow["WarehouseID"]);
                    oInvoiceRegisterWithVatGrosssale.WarehouseCode = (oRow["WarehouseCode"].ToString());
                    oInvoiceRegisterWithVatGrosssale.WarehouseName = (oRow["WarehouseName"].ToString());
                    oInvoiceRegisterWithVatGrosssale.VatChallanNo = Convert.ToInt32(oRow["VatChallanNo"]);
                    oInvoiceRegisterWithVatGrosssale.GrossSales = Convert.ToDouble(oRow["GrossSales"].ToString());
                    oInvoiceRegisterWithVatGrosssale.VAT = Convert.ToDouble(oRow["VAT"].ToString());
                    oInvoiceRegisterWithVatGrosssale.TradePrice = Convert.ToDouble(oRow["TradePrice"].ToString());
                    oInvoiceRegisterWithVatGrosssale.DeliveryDate = Convert.ToDateTime(oRow["DeliveryDate"]);
                    oInvoiceRegisterWithVatGrosssale.AdjustedDPAmount = Convert.ToDouble(oRow["AdjustedDPAmount"].ToString());
                    oInvoiceRegisterWithVatGrosssale.AdjustedPWAmount = Convert.ToDouble(oRow["AdjustedPWAmount"].ToString());
                    oInvoiceRegisterWithVatGrosssale.CoustomerType = Convert.ToInt32(oRow["CoustomerType"]);
                    oInvoiceRegisterWithVatGrosssale.InvoiceType = Convert.ToInt32(oRow["InvoiceType"]);

                    InnerList.Add(oInvoiceRegisterWithVatGrosssale);
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
