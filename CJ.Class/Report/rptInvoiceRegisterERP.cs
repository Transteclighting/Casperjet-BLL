// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sunadr Biswas
// Date: Sep 27;2011
// Time :  11:30 AM
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
    public class rptInvoiceRegisterERP
    {
        private long _CustomerID;
        private string _Remarks;
        private long _ChannelID;
        private string _ChannelCode;
        private string _ChannelDescription;
        private string _SalesOrderNo;
        private double _Discount;
        private double _SalesProvission;
        private double _VatAmount;
        private double _InvoiceAmount;
        private string _CustomerName;
        private string _CustomerCode;
        private DateTime _InvoiceDate;
        private string _InvoiceNo;
        private DateTime _OrderDate;
        private long _InvoiceTypeID;
        private string _InvoiceTypeName;
        private string _ProductCode;
        private string _ProductDetail;
        private long _Qty;
        private string _UOM;
        private double _UnitPrice;
        private double _InvoiceValue;
        private long _InvoiceID;
        private long _WareHouseID;
        private string _WareHouseCode;
        private string _WareHouseName;
        private string _ProductERPCode;
        private string _CustomerERPCode;
        private string _WareHouseERPCode;
        private long _CustomerTypeID;
        private string _CustomerTypeName;
        private string _CustomerTypeCode;
        private double _OtherCharge;
        private string _SalesPersonName;
        private string _SalesPersonCode;
        private long _SalesPersonID;
        private double _AdjustedPWAmount;
        private double _AdjustedDPAmount;
        private int _FreeQty;
        private double _AdjustedTPAmount;

        public long CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
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
        public string ChannelDescription
        {
            get { return _ChannelDescription; }
            set { _ChannelDescription = value; }
        }
        public string SalesOrderNo
        {
            get { return _SalesOrderNo; }
            set { _SalesOrderNo = value; }
        }
        public double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        public double SalesProvission
        {
            get { return _SalesProvission; }
            set { _SalesProvission = value; }
        }
        public double VatAmount
        {
            get { return _VatAmount; }
            set { _VatAmount = value; }
        }
        public double InvoiceAmount
        {
            get { return _InvoiceAmount; }
            set { _InvoiceAmount = value; }
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
        public DateTime OrderDate
        {
            get { return _OrderDate; }
            set { _OrderDate = value; }
        }
        public long InvoiceTypeID
        {
            get { return _InvoiceTypeID; }
            set { _InvoiceTypeID = value; }
        }
        public string InvoiceTypeName
        {
            get { return _InvoiceTypeName; }
            set { _InvoiceTypeName = value; }
        }
        public string ProductCode
        {
            get { return _ProductCode; }
            set { _ProductCode = value; }
        }
        public string ProductDetail
        {
            get { return _ProductDetail; }
            set { _ProductDetail = value; }
        }
        public long Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        public string UOM
        {
            get { return _UOM; }
            set { _UOM = value; }
        }
        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }
        public double InvoiceValue
        {
            get { return _InvoiceValue; }
            set { _InvoiceValue = value; }
        }
        public long InvoiceID
        {
            get { return _InvoiceID; }
            set { _InvoiceID = value; }
        }
        public long WareHouseID
        {
            get { return _WareHouseID; }
            set { _WareHouseID = value; }
        }
        public string WareHouseCode
        {
            get { return _WareHouseCode; }
            set { _WareHouseCode = value; }
        }
        public string WareHouseName
        {
            get { return _WareHouseName; }
            set { _WareHouseName = value; }
        }
        public string ProductERPCode
        {
            get { return _ProductERPCode; }
            set { _ProductERPCode = value; }
        }
        public string CustomerERPCode
        {
            get { return _CustomerERPCode; }
            set { _CustomerERPCode = value; }
        }
        public string WareHouseERPCode
        {
            get { return _WareHouseERPCode; }
            set { _WareHouseERPCode = value; }
        }
        public long CustomerTypeID
        {
            get { return _CustomerTypeID; }
            set { _CustomerTypeID = value; }
        }
        public string CustomerTypeName
        {
            get { return _CustomerTypeName; }
            set { _CustomerTypeName = value; }
        }
        public string CustomerTypeCode
        {
            get { return _CustomerTypeCode; }
            set { _CustomerTypeCode = value; }
        }
        public double OtherCharge
        {
            get { return _OtherCharge; }
            set { _OtherCharge = value; }
        }
        public string SalesPersonName
        {
            get { return _SalesPersonName; }
            set { _SalesPersonName = value; }
        }
        public string SalesPersonCode
        {
            get { return _SalesPersonCode; }
            set { _SalesPersonCode = value; }
        }
        public long SalesPersonID
        {
            get { return _SalesPersonID; }
            set { _SalesPersonID = value; }
        }
        public double AdjustedPWAmount
        {
            get { return _AdjustedPWAmount; }
            set { _AdjustedPWAmount = value; }
        }
        public double AdjustedDPAmount
        {
            get { return _AdjustedDPAmount; }
            set { _AdjustedDPAmount = value; }
        }
        public int FreeQty
        {
            get { return _FreeQty; }
            set { _FreeQty = value; }
        }
        public double AdjustedTPAmount
        {
            get { return _AdjustedTPAmount; }
            set { _AdjustedTPAmount = value; }
        }

    }
    public class rptInvoiceRegisterERPReport : CollectionBaseCustom
    {

        public void Add(rptInvoiceRegisterERP orptInvoiceRegisterERP)
        {
            this.List.Add(orptInvoiceRegisterERP);
        }
        public rptInvoiceRegisterERP this[Int32 Index]
        {
            get
            {
                return (rptInvoiceRegisterERP)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(rptInvoiceRegisterERP))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }
        public void GetInvoiceRegisterERP(DateTime dStartDate, DateTime dEndDate, long nFromInvoiceID, long nToInoiceID, string sFromInvoiceNo, string sToInvoiceNo, long nCousterID, int nInvoiceSelectionCriteria)
        {
            dEndDate = dEndDate.AddDays(1);
            StringBuilder sQueryStringMaster = new StringBuilder();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            cmd.CommandTimeout = 60;

            if (nInvoiceSelectionCriteria == Convert.ToInt64(Dictionary.InvoiceSelectionCriteria.BEWEEN_INVOICE_ID))
            {
                sQueryStringMaster.Append(" select QQ1.*,ISNull(qq6.SalesPersonName,'NA') as SalesPersonName ,ISNull(qq6.SalesPersonCode,'NA') as SalesPersonCode ,IsNull(QQ3.ProductERPCode,'...?') as ProductERPCode ,IsNull(QQ2.CustomerERPCode,'...?') as CustomerERPCode , IsNull(QQ4.WareHouseERPCode,'....?') as WareHouseERPCode , qq5.InvoiceTypeName   from ");
                sQueryStringMaster.Append(" (SELECT ");
                sQueryStringMaster.Append(" IM.InvoiceId, IM.InvoiceDate as OrderDate, IM.InvoiceNo as SalesOrderNo, IM.Remarks ");
                sQueryStringMaster.Append(" ,IM.InvoiceNo, IM.InvoiceDate,IM.InvoiceTypeID ");
                sQueryStringMaster.Append(" ,IM.InvoiceAmount, IM.Discount,isnull(IM.OtherCharge,0)as OtherCharge, isnull(IM.SalesPersonID,0) as  SalesPersonID");
                sQueryStringMaster.Append(" ,CD.CustomerCode, CD.CustomerName, CD.CustomerID ");
                sQueryStringMaster.Append(" ,CD.ChannelId, CD.ChannelCode, CD.ChannelDescription as ChannelDescription ");
                sQueryStringMaster.Append(" ,CD.CustomerTypeId, CD.CustomerTypeCode, CD.CustomerTypeName ");
                sQueryStringMaster.Append(" ,WR.WareHouseID, WR.WareHouseCode, WR.WareHouseName ");

                sQueryStringMaster.Append(" ,(ID.TradePrice*VATAmount*(Quantity + isnull(freeqty,0))) as VatAmount ");
                //sQueryStringMaster.Append(" ,(ID.TradePrice*VATAmount*Quantity) as VatAmount ");

                sQueryStringMaster.Append(" ,((customerProfitmargin*Quantity) + (customerSellingExpense*Quantity) +  (TradePromotion*Quantity))as SalesProvission  ");
                sQueryStringMaster.Append(", isnull((AdjustedDPAmount*Quantity),0) as  AdjustedDPAmount, isnull((AdjustedPWAmount*Quantity),0) as  AdjustedPWAmount, isnull((AdjustedTPAmount*Quantity),0) as  AdjustedTPAmount ");
                sQueryStringMaster.Append(" ,ID.Quantity as Qty,ID.UnitPrice as UnitPrice, (ID.Quantity * ID.UnitPrice) as InvoiceValue ");
                sQueryStringMaster.Append(" ,PD.ProductCode, PD.ProductName as ProductDetail,PD.SmallUnitOfMeasure as UOM, ID.FreeQty ");
                sQueryStringMaster.Append(" from t_SalesInvoice  IM, t_SalesInvoiceDetail ID, v_customerDetails CD, v_ProductDetails PD, ");
                sQueryStringMaster.Append(" t_WareHouse WR ");
                sQueryStringMaster.Append(" where  ");
                sQueryStringMaster.Append(" IM.InvoiceID = ID.InvoiceID ");
                sQueryStringMaster.Append(" and ID.Productid = PD.Productid ");
                sQueryStringMaster.Append(" and IM.CustomerID = CD.CustomerId and IM.WareHouseID=WR.WareHouseID ");
                sQueryStringMaster.Append(" and IM.InvoiceID between ? and ?  and InvoiceStatus <> ? ) as QQ1 Left Outer Join ");
                sQueryStringMaster.Append(" (select * from t_MAPERPCustomer) as QQ2 on QQ2.CustomerCode=QQ1.CustomerCode ");
                sQueryStringMaster.Append(" Left Outer Join ");
                sQueryStringMaster.Append(" (select * from t_MAPERPProduct) as QQ3 on QQ3.ProductCode=QQ1.ProductCode ");
                sQueryStringMaster.Append(" Left Outer Join ");
                sQueryStringMaster.Append(" (select * from t_MAPERPWareHouse) as QQ4 on QQ4.WareHouseCode=QQ1.WareHouseCode ");
                sQueryStringMaster.Append(" left outer join ");
                sQueryStringMaster.Append(" (select * from t_InvoiceType) as qq5 on qq1.InvoiceTypeID = qq5.InvoiceTypeID ");
                sQueryStringMaster.Append(" left outer join");
                sQueryStringMaster.Append(" (");
                sQueryStringMaster.Append(" select EmployeeName as SalesPersonName, q1.EmployeeID as SalesPersonID, q2.EmployeeCode as SalesPersonCode, q1.IsActive from t_EmployeeJobType q1, t_Employee q2  ");
                sQueryStringMaster.Append(" where q1.EmployeeID = q2.EmployeeID  and JobTypeID = ? ");
                sQueryStringMaster.Append(" )");
                sQueryStringMaster.Append(" as qq6 on qq1.SalesPersonID = qq6.SalesPersonID ");
                sQueryStringMaster.Append(" Order BY QQ1.InvoiceID ");


                cmd.CommandText = sQueryStringMaster.ToString();

                cmd.Parameters.AddWithValue("InvoiceID", nFromInvoiceID);
                cmd.Parameters.AddWithValue("InvoiceID", nToInoiceID);
                cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);
                cmd.Parameters.AddWithValue("JobTypeID", Dictionary.JobType.SALES_PERSONS);
            }
            else if (nInvoiceSelectionCriteria == Convert.ToInt64(Dictionary.InvoiceSelectionCriteria.BEWEEN_INVOICE_NO))
            {
                sQueryStringMaster.Append(" select QQ1.*,ISNull(qq6.SalesPersonName,'NA') as SalesPersonName ,ISNull(qq6.SalesPersonCode,'NA') as SalesPersonCode ,IsNull(QQ3.ProductERPCode,'...?') as ProductERPCode ,IsNull(QQ2.CustomerERPCode,'...?') as CustomerERPCode , IsNull(QQ4.WareHouseERPCode,'....?') as WareHouseERPCode , qq5.InvoiceTypeName   from ");
                sQueryStringMaster.Append(" (SELECT ");
                sQueryStringMaster.Append(" IM.InvoiceId, IM.InvoiceDate as OrderDate, IM.InvoiceNo as SalesOrderNo, IM.Remarks ");
                sQueryStringMaster.Append(" ,IM.InvoiceNo, IM.InvoiceDate,IM.InvoiceTypeID ");
                sQueryStringMaster.Append(" ,IM.InvoiceAmount, IM.Discount,isnull(IM.OtherCharge,0)as OtherCharge, isnull(IM.SalesPersonID,0) as  SalesPersonID");
                sQueryStringMaster.Append(" ,CD.CustomerCode, CD.CustomerName, CD.CustomerID ");
                sQueryStringMaster.Append(" ,CD.ChannelId, CD.ChannelCode, CD.ChannelDescription as ChannelDescription ");
                sQueryStringMaster.Append(" ,CD.CustomerTypeId, CD.CustomerTypeCode, CD.CustomerTypeName ");
                sQueryStringMaster.Append(" ,WR.WareHouseID, WR.WareHouseCode, WR.WareHouseName ");

                sQueryStringMaster.Append(" ,(ID.TradePrice*VATAmount*(Quantity + isnull(freeqty,0))) as VatAmount ");
                //sQueryStringMaster.Append(" ,(ID.TradePrice*VATAmount*Quantity) as VatAmount ");

                sQueryStringMaster.Append(" ,((customerProfitmargin*Quantity) + (customerSellingExpense*Quantity) +  (TradePromotion*Quantity))as SalesProvission  ");
                sQueryStringMaster.Append(", isnull((AdjustedDPAmount*Quantity),0) as  AdjustedDPAmount, isnull((AdjustedPWAmount*Quantity),0) as  AdjustedPWAmount, isnull((AdjustedTPAmount*Quantity),0) as  AdjustedTPAmount ");
                sQueryStringMaster.Append(" ,ID.Quantity as Qty,ID.UnitPrice as UnitPrice, (ID.Quantity * ID.UnitPrice) as InvoiceValue ");
                sQueryStringMaster.Append(" ,PD.ProductCode, PD.ProductName as ProductDetail,PD.SmallUnitOfMeasure as UOM, ID.FreeQty  ");
                sQueryStringMaster.Append(" from t_SalesInvoice  IM, t_SalesInvoiceDetail ID, v_customerDetails CD, v_ProductDetails PD, ");
                sQueryStringMaster.Append(" t_WareHouse WR ");
                sQueryStringMaster.Append(" where  ");
                sQueryStringMaster.Append(" IM.InvoiceID = ID.InvoiceID ");
                sQueryStringMaster.Append(" and ID.Productid = PD.Productid ");
                sQueryStringMaster.Append(" and IM.CustomerID = CD.CustomerId and IM.WareHouseID=WR.WareHouseID ");
                sQueryStringMaster.Append(" and IM.InvoiceNo between ? and ?  and InvoiceStatus <> ? ) as QQ1 Left Outer Join ");
                sQueryStringMaster.Append(" (select * from t_MAPERPCustomer) as QQ2 on QQ2.CustomerCode=QQ1.CustomerCode ");
                sQueryStringMaster.Append(" Left Outer Join ");
                sQueryStringMaster.Append(" (select * from t_MAPERPProduct) as QQ3 on QQ3.ProductCode=QQ1.ProductCode ");
                sQueryStringMaster.Append(" Left Outer Join ");
                sQueryStringMaster.Append(" (select * from t_MAPERPWareHouse) as QQ4 on QQ4.WareHouseCode=QQ1.WareHouseCode ");
                sQueryStringMaster.Append(" left outer join ");
                sQueryStringMaster.Append(" (select * from t_InvoiceType) as qq5 on qq1.InvoiceTypeID = qq5.InvoiceTypeID ");
                sQueryStringMaster.Append(" left outer join");
                sQueryStringMaster.Append(" (");
                sQueryStringMaster.Append(" select EmployeeName as SalesPersonName, q1.EmployeeID as SalesPersonID, q2.EmployeeCode as SalesPersonCode, q1.IsActive from t_EmployeeJobType q1, t_Employee q2  ");
                sQueryStringMaster.Append(" where q1.EmployeeID = q2.EmployeeID  and JobTypeID = ? ");
                sQueryStringMaster.Append(" )");
                sQueryStringMaster.Append(" as qq6 on qq1.SalesPersonID = qq6.SalesPersonID ");
                sQueryStringMaster.Append(" Order BY QQ1.InvoiceNo ");


                cmd.CommandText = sQueryStringMaster.ToString();

                //cmd.Parameters.AddWithValue("InvoiceNo", Convert.ToString(oDSDataInteger.DataInteger[1].IntegerValue));
                //cmd.Parameters.AddWithValue("InvoiceNo", Convert.ToString(oDSDataInteger.DataInteger[2].IntegerValue));
                /// Added by Verma
                /// Date: 07-Dec-2008
                cmd.Parameters.AddWithValue("InvoiceNo", sFromInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceNo", sToInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);
                cmd.Parameters.AddWithValue("JobTypeID", Dictionary.JobType.SALES_PERSONS);
            }
            else if (nInvoiceSelectionCriteria == Convert.ToInt64(Dictionary.InvoiceSelectionCriteria.Between_Date))
            {
                sQueryStringMaster.Append(" select QQ1.*,ISNull(qq6.SalesPersonName,'NA') as SalesPersonName ,ISNull(qq6.SalesPersonCode,'NA') as SalesPersonCode ,IsNull(QQ3.ProductERPCode,'...?') as ProductERPCode ,IsNull(QQ2.CustomerERPCode,'...?') as CustomerERPCode , IsNull(QQ4.WareHouseERPCode,'....?') as WareHouseERPCode , qq5.InvoiceTypeName   from ");
                sQueryStringMaster.Append(" (SELECT ");
                sQueryStringMaster.Append(" IM.InvoiceId, IM.InvoiceDate as OrderDate, IM.InvoiceNo as SalesOrderNo, IM.Remarks ");
                sQueryStringMaster.Append(" ,IM.InvoiceNo, IM.InvoiceDate,IM.InvoiceTypeID ");
                sQueryStringMaster.Append(" ,IM.InvoiceAmount, IM.Discount,isnull(IM.OtherCharge,0)as OtherCharge, isnull(IM.SalesPersonID,0) as  SalesPersonID");
                sQueryStringMaster.Append(" ,CD.CustomerCode, CD.CustomerName, CD.CustomerID ");
                sQueryStringMaster.Append(" ,CD.ChannelId, CD.ChannelCode, CD.ChannelDescription as ChannelDescription ");
                sQueryStringMaster.Append(" ,CD.CustomerTypeId, CD.CustomerTypeCode, CD.CustomerTypeName ");
                sQueryStringMaster.Append(" ,WR.WareHouseID, WR.WareHouseCode, WR.WareHouseName ");

                sQueryStringMaster.Append(" ,(ID.TradePrice*VATAmount*(Quantity + isnull(freeqty,0))) as VatAmount ");
                //sQueryStringMaster.Append(" ,(ID.TradePrice*VATAmount*Quantity) as VatAmount ");

                sQueryStringMaster.Append(" ,((customerProfitmargin*Quantity) + (customerSellingExpense*Quantity) +  (TradePromotion*Quantity))as SalesProvission  ");
                sQueryStringMaster.Append(", isnull((AdjustedDPAmount*Quantity),0) as  AdjustedDPAmount, isnull((AdjustedPWAmount*Quantity),0) as  AdjustedPWAmount, isnull((AdjustedTPAmount*Quantity),0) as  AdjustedTPAmount ");
                sQueryStringMaster.Append(" ,ID.Quantity as Qty,ID.UnitPrice as UnitPrice, (ID.Quantity * ID.UnitPrice) as InvoiceValue ");
                sQueryStringMaster.Append(" ,PD.ProductCode, PD.ProductName as ProductDetail,PD.SmallUnitOfMeasure as UOM, ID.FreeQty  ");
                sQueryStringMaster.Append(" from t_SalesInvoice  IM, t_SalesInvoiceDetail ID, v_customerDetails CD, v_ProductDetails PD, ");
                sQueryStringMaster.Append(" t_WareHouse WR ");
                sQueryStringMaster.Append(" where  ");
                sQueryStringMaster.Append(" IM.InvoiceID = ID.InvoiceID ");
                sQueryStringMaster.Append(" and ID.Productid = PD.Productid ");
                sQueryStringMaster.Append(" and IM.CustomerID = CD.CustomerId and IM.WareHouseID=WR.WareHouseID ");
                sQueryStringMaster.Append(" and IM.InvoiceDate between ? and ? and IM.InvoiceDate < ? and InvoiceStatus <> ? ) as QQ1 Left Outer Join ");
                sQueryStringMaster.Append(" (select * from t_MAPERPCustomer) as QQ2 on QQ2.CustomerCode=QQ1.CustomerCode ");
                sQueryStringMaster.Append(" Left Outer Join ");
                sQueryStringMaster.Append(" (select * from t_MAPERPProduct) as QQ3 on QQ3.ProductCode=QQ1.ProductCode ");
                sQueryStringMaster.Append(" Left Outer Join ");
                sQueryStringMaster.Append(" (select * from t_MAPERPWareHouse) as QQ4 on QQ4.WareHouseCode=QQ1.WareHouseCode ");
                sQueryStringMaster.Append(" left outer join ");
                sQueryStringMaster.Append(" (select * from t_InvoiceType) as qq5 on qq1.InvoiceTypeID = qq5.InvoiceTypeID ");
                sQueryStringMaster.Append(" left outer join");
                sQueryStringMaster.Append(" (");
                sQueryStringMaster.Append(" select EmployeeName as SalesPersonName, q1.EmployeeID as SalesPersonID, q2.EmployeeCode as SalesPersonCode, q1.IsActive from t_EmployeeJobType q1, t_Employee q2  ");
                sQueryStringMaster.Append(" where q1.EmployeeID = q2.EmployeeID  and JobTypeID = ? ");
                sQueryStringMaster.Append(" )");
                sQueryStringMaster.Append(" as qq6 on qq1.SalesPersonID = qq6.SalesPersonID ");
                sQueryStringMaster.Append(" Order BY QQ1.InvoiceID ");


                cmd.CommandText = sQueryStringMaster.ToString();

                cmd.Parameters.AddWithValue("InvoiceDate", dStartDate);
                cmd.Parameters.AddWithValue("InvoiceDate", dEndDate);
                cmd.Parameters.AddWithValue("InvoiceDate", dEndDate);
                cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);
                cmd.Parameters.AddWithValue("JobTypeID", Dictionary.JobType.SALES_PERSONS);
            }
            else if (nInvoiceSelectionCriteria == Convert.ToInt64(Dictionary.InvoiceSelectionCriteria.BY_CUSTOMER_ID))
            {
                sQueryStringMaster.Append(" select QQ1.*,ISNull(qq6.SalesPersonName,'NA') as SalesPersonName ,ISNull(qq6.SalesPersonCode,'NA') as SalesPersonCode ,IsNull(QQ3.ProductERPCode,'...?') as ProductERPCode ,IsNull(QQ2.CustomerERPCode,'...?') as CustomerERPCode , IsNull(QQ4.WareHouseERPCode,'....?') as WareHouseERPCode , qq5.InvoiceTypeName   from ");
                sQueryStringMaster.Append(" (SELECT ");
                sQueryStringMaster.Append(" IM.InvoiceId, IM.InvoiceDate as OrderDate, IM.InvoiceNo as SalesOrderNo, IM.Remarks ");
                sQueryStringMaster.Append(" ,IM.InvoiceNo, IM.InvoiceDate,IM.InvoiceTypeID ");
                sQueryStringMaster.Append(" ,IM.InvoiceAmount, IM.Discount,isnull(IM.OtherCharge,0)as OtherCharge, isnull(IM.SalesPersonID,0) as  SalesPersonID");
                sQueryStringMaster.Append(" ,CD.CustomerCode, CD.CustomerName, CD.CustomerID ");
                sQueryStringMaster.Append(" ,CD.ChannelId, CD.ChannelCode, CD.ChannelDescription as ChannelDescription ");
                sQueryStringMaster.Append(" ,CD.CustomerTypeId, CD.CustomerTypeCode, CD.CustomerTypeName ");
                sQueryStringMaster.Append(" ,WR.WareHouseID, WR.WareHouseCode, WR.WareHouseName ");

                sQueryStringMaster.Append(" ,(ID.TradePrice*VATAmount*(Quantity + isnull(freeqty,0))) as VatAmount ");
                //sQueryStringMaster.Append(" ,(ID.TradePrice*VATAmount*Quantity) as VatAmount ");

                sQueryStringMaster.Append(" ,((customerProfitmargin*Quantity) + (customerSellingExpense*Quantity) +  (TradePromotion*Quantity))as SalesProvission  ");
                sQueryStringMaster.Append(", isnull((AdjustedDPAmount*Quantity),0) as  AdjustedDPAmount, isnull((AdjustedPWAmount*Quantity),0) as  AdjustedPWAmount, isnull((AdjustedTPAmount*Quantity),0) as  AdjustedTPAmount ");
                sQueryStringMaster.Append(" ,ID.Quantity as Qty,ID.UnitPrice as UnitPrice, (ID.Quantity * ID.UnitPrice) as InvoiceValue ");
                sQueryStringMaster.Append(" ,PD.ProductCode, PD.ProductName as ProductDetail,PD.SmallUnitOfMeasure as UOM, ID.FreeQty  ");
                sQueryStringMaster.Append(" from t_SalesInvoice  IM, t_SalesInvoiceDetail ID, v_customerDetails CD, v_ProductDetails PD, ");
                sQueryStringMaster.Append(" t_WareHouse WR ");
                sQueryStringMaster.Append(" where  ");
                sQueryStringMaster.Append(" IM.InvoiceID = ID.InvoiceID ");
                sQueryStringMaster.Append(" and ID.Productid = PD.Productid ");
                sQueryStringMaster.Append(" and IM.CustomerID = CD.CustomerId and IM.WareHouseID=WR.WareHouseID ");
                sQueryStringMaster.Append(" and IM.InvoiceDate between ? and ? and IM.InvoiceDate < ? and  CD.CustomerCode = ? and InvoiceStatus <> ? ) as QQ1 Left Outer Join ");
                sQueryStringMaster.Append(" (select * from t_MAPERPCustomer) as QQ2 on QQ2.CustomerCode=QQ1.CustomerCode ");
                sQueryStringMaster.Append(" Left Outer Join ");
                sQueryStringMaster.Append(" (select * from t_MAPERPProduct) as QQ3 on QQ3.ProductCode=QQ1.ProductCode ");
                sQueryStringMaster.Append(" Left Outer Join ");
                sQueryStringMaster.Append(" (select * from t_MAPERPWareHouse) as QQ4 on QQ4.WareHouseCode=QQ1.WareHouseCode ");
                sQueryStringMaster.Append(" left outer join ");
                sQueryStringMaster.Append(" (select * from t_InvoiceType) as qq5 on qq1.InvoiceTypeID = qq5.InvoiceTypeID ");
                sQueryStringMaster.Append(" left outer join");
                sQueryStringMaster.Append(" (");
                sQueryStringMaster.Append(" select EmployeeName as SalesPersonName, q1.EmployeeID as SalesPersonID, q2.EmployeeCode as SalesPersonCode, q1.IsActive from t_EmployeeJobType q1, t_Employee q2  ");
                sQueryStringMaster.Append(" where q1.EmployeeID = q2.EmployeeID  and JobTypeID = ? ");
                sQueryStringMaster.Append(" )");
                sQueryStringMaster.Append(" as qq6 on qq1.SalesPersonID = qq6.SalesPersonID ");
                sQueryStringMaster.Append(" Order BY QQ1.InvoiceID ");


                cmd.CommandText = sQueryStringMaster.ToString();

                cmd.Parameters.AddWithValue("InvoiceDate", dStartDate);
                cmd.Parameters.AddWithValue("InvoiceDate", dEndDate);
                cmd.Parameters.AddWithValue("InvoiceDate", dEndDate);
                cmd.Parameters.AddWithValue("CustomerCode", nCousterID);
                cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);
                cmd.Parameters.AddWithValue("JobTypeID", Dictionary.JobType.SALES_PERSONS);
            }

            GetInvoiceRegisterERPData(cmd);
        }
        private void GetInvoiceRegisterERPData(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptInvoiceRegisterERP oItem = new rptInvoiceRegisterERP();

                    if (reader["CustomerID"] != DBNull.Value)
                        oItem.CustomerID = Convert.ToInt64(reader["CustomerID"]);
                    else oItem.CustomerID = -1;
                    if (reader["CustomerCode"] != DBNull.Value)
                        oItem.CustomerCode = (string)(reader["CustomerCode"]);
                    else oItem.CustomerCode = "";
                    if (reader["CustomerName"] != DBNull.Value)
                        oItem.CustomerName = (string)(reader["CustomerName"]);
                    else oItem.CustomerName = "";
                    if (reader["InvoiceNo"] != DBNull.Value)
                        oItem.InvoiceNo = (string)(reader["InvoiceNo"]);
                    else oItem.InvoiceNo = "";
                    if (reader["InvoiceAmount"] != DBNull.Value)
                        oItem.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"]);
                    else oItem.InvoiceAmount = 0;
                    if (reader["OtherCharge"] != DBNull.Value)
                        oItem.OtherCharge = Convert.ToDouble(reader["OtherCharge"]);
                    else oItem.OtherCharge = 0;
                    if (reader["Remarks"] != DBNull.Value)
                        oItem.Remarks = (string)(reader["Remarks"]);
                    else oItem.Remarks = "";
                    if (reader["ChannelID"] != DBNull.Value)
                        oItem.ChannelID = Convert.ToInt64(reader["ChannelID"]);
                    else oItem.ChannelID = -1;
                    if (reader["ChannelCode"] != DBNull.Value)
                        oItem.ChannelCode = (string)(reader["ChannelCode"]);
                    else oItem.ChannelCode = "";
                    if (reader["ChannelDescription"] != DBNull.Value)
                        oItem.ChannelDescription = (string)(reader["ChannelDescription"]);
                    else oItem.ChannelDescription = "";
                    if (reader["InvoiceTypeID"] != DBNull.Value)
                        oItem.InvoiceTypeID = Convert.ToInt64(reader["InvoiceTypeID"]);
                    else oItem.InvoiceTypeID = -1;
                    if (reader["InvoiceTypeName"] != DBNull.Value)
                        oItem.InvoiceTypeName = (string)(reader["InvoiceTypeName"]);
                    else oItem.InvoiceTypeName = "";
                    if (reader["InvoiceDate"] != DBNull.Value)
                        oItem.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    else oItem.InvoiceDate = DateTime.Today.Date;
                    if (reader["SalesOrderNo"] != DBNull.Value)
                        oItem.SalesOrderNo = (string)(reader["SalesOrderNo"]);
                    else oItem.SalesOrderNo = "";
                    if (reader["OrderDate"] != DBNull.Value)
                        oItem.OrderDate = Convert.ToDateTime(reader["OrderDate"].ToString());
                    else oItem.OrderDate = DateTime.Today.Date;
                    if (reader["SalesProvission"] != DBNull.Value)
                        oItem.SalesProvission = Convert.ToDouble(reader["SalesProvission"]);
                    else oItem.SalesProvission = 0;
                    if (reader["VatAmount"] != DBNull.Value)
                        oItem.VatAmount = Convert.ToDouble(reader["VatAmount"]);
                    else oItem.VatAmount = 0;
                    if (reader["AdjustedDPAmount"] != DBNull.Value)
                        oItem.AdjustedDPAmount = Convert.ToDouble(reader["AdjustedDPAmount"]);
                    else oItem.AdjustedDPAmount = 0;
                    if (reader["AdjustedPWAmount"] != DBNull.Value)
                        oItem.AdjustedPWAmount = Convert.ToDouble(reader["AdjustedPWAmount"]);
                    else oItem.AdjustedPWAmount = 0;
                    if (reader["AdjustedTPAmount"] != DBNull.Value)
                        oItem.AdjustedTPAmount = Convert.ToDouble(reader["AdjustedTPAmount"]);
                    else oItem.AdjustedTPAmount = 0;
                    if (reader["Discount"] != DBNull.Value)
                        oItem.Discount = Convert.ToDouble(reader["Discount"]);
                    else oItem.Discount = 0;
                    if (reader["Qty"] != DBNull.Value)
                        oItem.Qty = Convert.ToInt64(reader["Qty"]);
                    else oItem.Qty = 0;
                    if (reader["UnitPrice"] != DBNull.Value)
                        oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"]);
                    else oItem.UnitPrice = 0;
                    if (reader["InvoiceValue"] != DBNull.Value)
                        oItem.InvoiceValue = Convert.ToDouble(reader["InvoiceValue"]);
                    else oItem.InvoiceValue = 0;
                    if (reader["ProductCode"] != DBNull.Value)
                        oItem.ProductCode = (string)(reader["ProductCode"]);
                    else oItem.ProductCode = "";
                    if (reader["ProductDetail"] != DBNull.Value)
                        oItem.ProductDetail = (string)(reader["ProductDetail"]);
                    else oItem.ProductDetail = "";
                    if (reader["UOM"] != DBNull.Value)
                        oItem.UOM = (string)(reader["UOM"]);
                    else oItem.UOM = "";
                    if (reader["InvoiceID"] != DBNull.Value)
                        oItem.InvoiceID = Convert.ToInt64(reader["InvoiceID"]);
                    else oItem.InvoiceID = -1;
                    if (reader["WareHouseID"] != DBNull.Value)
                        oItem.WareHouseID = Convert.ToInt64(reader["WareHouseID"]);
                    else oItem.WareHouseID = -1;
                    if (reader["WareHouseCode"] != DBNull.Value)
                        oItem.WareHouseCode = (string)(reader["WareHouseCode"]);
                    else oItem.WareHouseCode = "";
                    if (reader["WareHouseName"] != DBNull.Value)
                        oItem.WareHouseName = (string)(reader["WareHouseName"]);
                    else oItem.WareHouseName = "";
                    if (reader["ProductERPCode"] != DBNull.Value)
                        oItem.ProductERPCode = (string)(reader["ProductERPCode"]);
                    else oItem.ProductERPCode = "";
                    if (reader["CustomerERPCode"] != DBNull.Value)
                        oItem.CustomerERPCode = (string)(reader["CustomerERPCode"]);
                    else oItem.CustomerERPCode = "";
                    if (reader["WareHouseERPCode"] != DBNull.Value)
                        oItem.WareHouseERPCode = (string)(reader["WareHouseERPCode"]);
                    else oItem.WareHouseERPCode = "";
                    if (reader["CustomerTypeID"] != DBNull.Value)
                        oItem.CustomerTypeID = Convert.ToInt64(reader["CustomerTypeID"]);
                    else oItem.CustomerTypeID = -1;
                    if (reader["CustomerTypeCode"] != DBNull.Value)
                        oItem.CustomerTypeCode = (string)(reader["CustomerTypeCode"]);
                    else oItem.CustomerTypeCode = "";
                    if (reader["CustomerTypeName"] != DBNull.Value)
                        oItem.CustomerTypeName = (string)(reader["CustomerTypeName"]);
                    else oItem.CustomerTypeName = "";
                    if (reader["SalesPersonID"] != DBNull.Value)
                        oItem.SalesPersonID = Convert.ToInt64(reader["SalesPersonID"]);
                    else oItem.SalesPersonID = -1;
                    if (reader["SalesPersonCode"] != DBNull.Value)
                        oItem.SalesPersonCode = (string)(reader["SalesPersonCode"]);
                    else oItem.SalesPersonCode = "";
                    if (reader["SalesPersonName"] != DBNull.Value)
                        oItem.SalesPersonName = (string)(reader["SalesPersonName"]);
                    else oItem.SalesPersonName = "";
                    if (reader["SalesPersonName"] != DBNull.Value)
                        oItem.FreeQty = Convert.ToInt32(reader["FreeQty"]);
                    else oItem.FreeQty = 0;

                    Add(oItem);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
      


    }

}
