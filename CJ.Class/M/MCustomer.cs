// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: June 14, 2013
// Time :  12:38 PM
// Description: Class for Product for Mobile Version.
// Modify Person And Date: Dipak Kumar Chakraborty Date: 26-Sept-13
// </summary>


using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;



namespace CJ.Class.M
{
    public class MCustomer
    {
        private int _nCustomerID;
        private string _sCustomerCode;
        private string _sCustomerName;
        private string _sCustomerAddress;
        private int _nOrderQty;
        private int _nRevOrderQty;
        private int _nNOrderQty;
        private int _nIsActive;
        private int _nTotalOrder;
        private int _nQty;
        private double _Value;
        private string _sResult;
        private int _nSaleQty;


        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
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
        public string CustomerAddress
        {
            get { return _sCustomerAddress; }
            set { _sCustomerAddress = value; }
        }
        public int OrderQty
        {
            get { return _nOrderQty; }
            set { _nOrderQty = value; }
        }
        public int RevOrderQty
        {
            get { return _nRevOrderQty; }
            set { _nRevOrderQty = value; }
        }
        public int NOrderQty
        {
            get { return _nNOrderQty; }
            set { _nNOrderQty = value; }
        }      
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }

        }
        public int TotalOrder
        {
            get { return _nTotalOrder; }
            set { _nTotalOrder = value; }

        }
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }

        }
        public double Value
        {
            get { return _Value; }
            set { _Value = value; }

        }
        public string Result
        {
            get { return _sResult; }
            set { _sResult = value; }

        }
        public int SaleQty
        {
            get { return _nSaleQty; }
            set { _nSaleQty = value; }

        }


        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM v_CustomerDetails where CustomerID =?";
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sCustomerCode = (string)reader["CustomerCode"];
                    _sCustomerName = (string)reader["CustomerName"];
                    _sCustomerAddress = (string)reader["CustomerAddress"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(string sCustomerCode)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM v_CustomerDetails where CustomerCode=?";
                cmd.Parameters.AddWithValue("CustomerCode", sCustomerCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nCustomerID = (int)reader["CustomerID"];
                    _sCustomerCode = (string)reader["CustomerCode"];
                    _sCustomerName = (string)reader["CustomerName"];
                    _sCustomerAddress = (string)reader["CustomerAddress"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }

    public class MCustomers : CollectionBase
    {
        public MCustomer this[int i]
        {
            get { return (MCustomer)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(MCustomer oCustomer)
        {
            InnerList.Add(oCustomer);
        }
        public int GetIndex(int nCustomerID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].CustomerID == nCustomerID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void RefreshByArea(string sAreaCode, DateTime dDate)
        {
            InnerList.Clear();

            DateTime dFormDate = dDate.Date;
            DateTime dtToDate = dDate.Date.AddDays(1);
            DateTime dtSaleStartDate = dDate.Date.AddDays(-7);
            DateTime dtEndStartDate = dDate.Date.AddDays(-1);

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select Final.*, salesqty as SaleQty from (Select CD.CustomerID, CD.AreaCode, CD.CustomerCode, CD.CustomerName, IsNull(OrderNo,0) as OrderNo, " +
                            "IsNull(Qty,0) as Qty, IsNull(Value,0) as Value, IsNull(S,0)as S, IsNull(T,0)as T, IsNull(B,0)as B from " +
                            "(Select CustomerID, AreaCode, CustomerCode, CustomerName from v_CustomerDetails)cd " +
                            "left outer join " +
                            "( " +
                            "Select CustomerID,CustomerCode, CustomerName, OrderNo, Sum(Qty)Qty, Sum(Value)Value from ( " +
                            "Select OrderID, CustomerID,CustomerCode, CustomerName, OrderStatus, OrderNo, Qty=CASE When OrderStatus='CustomerOrder' then OrderQty " +
                            "When OrderStatus='AreaOrder' then RevOrderQty When OrderStatus='NationalOrder' then NOrderQty end, " +
                            "Value=CASE When OrderStatus='CustomerOrder' then OrderQty*UnitPrice When OrderStatus='AreaOrder' then RevOrderQty*UnitPrice " +
                            "When OrderStatus='NationalOrder' then NOrderQty*UnitPrice end from( " +
                            "Select OrderID, CustomerID,CustomerCode, CustomerName, OrderStatus, OrderNo, OrderQty, RevOrderQty, NOrderQty, CASE When PriceOptionID=1 then NSP " +
                            "When PriceOptionID=2 then RSP When PriceOptionID=3 then SP " +
                            "When PriceOptionID=4 then CP When PriceOptionID=5 then TP When PriceOptionID=6 then MRP end as UnitPrice  from ( " +
                            "select a.OrderID, c.CustomerID, c.CustomerCode, c.CustomerName, OrderStatus,OrderNo, IsNull(OrderQty,0)as OrderQty, " +
                            "IsNull(RevOrderQty,0) as RevOrderQty, " +
                            "IsNull(NOrderQty,0) as NOrderQty, PriceOptionID,CP,TP,NSP,RSP,SP,MRP " +
                            "from t_AndroidOrderDetail a INNER JOIN " +
                            "(Select ProductID, IsNull(CostPrice,0) as CP, IsNull(TradePrice,0)as TP, IsNull(NSP,0) as NSP, " +
                            "IsNull(RSP,0) as RSP, IsNull(SpecialPrice,0)as SP, IsNull(MRP,0)as MRP from t_FinishedGoodsPrice Where IsCurrent=1)Price " +
                            "ON Price.ProductID=a.ProductID INNER JOIN (Select * from t_AndroidOrder Where OrderDate Between ? " +
                            "and ? and OrderDate < ?) b ON B.OrderID=a.OrderID INNER JOIN t_Customer c " +
                            "ON C.CustomerID=b.CustomerID INNER JOIN t_CustomerTypeWisePriceSetting d ON D.CustTypeID=c.CustTypeID " +
                            "INNER JOIN " +
                            "(select a.CustomerID,CustomerCode, Count(a.CustomerID) orderNo from t_AndroidOrder a INNER JOIN t_Customer b " +
                            "On a.CustomerID=b.CustomerID Where OrderDate Between ? and ? and OrderDate < ? " +
                            "group by a.CustomerID,CustomerCode) as OrderNo " +
                            "on OrderNo.CustomerID=c.customerID)X)Final " +
                            ")a where value <>0 Group by CustomerID,CustomerCode, CustomerName, OrderNo " +
                            ")F On f.CustomerID=CD.CustomerID "+
                            "Left outer JOIN "+
                            "(Select CustomerID,CustomerCode, "+
                            "sum(case AGName when 'Smart' then Qty else 0 end) as S, "+
                            "sum(case AGName when 'Bar' then Qty else 0 end) as B, "+
                            "sum(case AGName when 'Touch' then Qty else 0 end) as T "+
                            "from (Select b.CustomerID, CustomerCode, AGName, Qty=CASE When OrderStatus='CustomerOrder' then OrderQty "+
                            "When OrderStatus='AreaOrder' then RevOrderQty When OrderStatus='NationalOrder' then NOrderQty end "+
                            "from t_AndroidOrderDetail a INNER JOIN t_AndroidOrder b ON B.OrderID=a.OrderID "+
                            "INNER JOIN (Select CustomerID, CustomerCode from t_Customer) c ON c.CustomerID=b.CustomerID "+
                            "INNER JOIN (Select ProductID, AGName from v_ProductDetails) PD ON PD.ProductID=a.ProductID "+
                            "Where OrderDate Between ? and ? and OrderDate < ? "+
                            ")a Group by CustomerID,CustomerCode)h "+
                            "on h.customerID=Cd.CustomerID Where AreaCode=? )Final " +

                             "Left Outer JOIN " +
                            "(select customerid,customercode,sum(salesqty) as salesqty, sum(salesvalue) as salesvalue, " +
                            "sum(BarQty) as BarQty,sum(TouchQty) as TouchQty,sum(SmartQty) as SmartQty, " +
                            "sum(BarValue) as BarValue,sum(TouchValue) as TouchValue,sum(SmartValue) as SmartValue from  " +
                            "(select d.customerid,d.customercode,sum(qty) as salesqty,sum(qty)*rsp as salesvalue, " +
                            "case  when PdtGroupName='BAR' then sum(qty) end BarQty, " +
                            "case when PdtGroupName='Touch' then sum(qty) end TouchQty, " +
                            "case when PdtGroupName='Smart' then sum(qty) end SmartQty, " +
                            "case  when PdtGroupName='BAR' then sum(qty)*RSP end BarValue, " +
                            "case when PdtGroupName='Touch' then sum(qty)*RSP end TouchValue, " +
                            "case when PdtGroupName='Smart' then sum(qty)*RSP end SmartValue  " +
                            "from dbo.t_DMSLiteSalesTran a,dbo.t_DMSLiteProductMapping b, dbo.t_DMSLiteCustomerMapping c, " +
                            "t_customer d, t_product e, t_FinishedGoodsPrice f,t_productGroup g " +
                            "where a.productcode=b.dlproductcode and f.productID=e.productid and Iscurrent=1  " +
                            "and g.PdtGroupID=e.ProductGroupID and PdtGroupType=4 " +
                            "and a.smdpcode=c.dlcustomercode " +
                            "and b.cproductcode=e.productcode " +
                            "and c.ccustomercode=d.customercode " +
                            "and invoicedate between ? and ? and invoicedate < ? " +
                            "group by d.customerid,d.customercode,rsp,PdtGroupName) x " +
                            "group by customerid,customercode)sale " +
                            "ON Sale.CustomerID=Final.CustomerID "+
                            "Order by OrderNo DESC ";

            cmd.Parameters.AddWithValue("OrderDate", dFormDate);
            cmd.Parameters.AddWithValue("OrderDate", dtToDate);
            cmd.Parameters.AddWithValue("OrderDate", dtToDate);
            cmd.Parameters.AddWithValue("OrderDate", dFormDate);
            cmd.Parameters.AddWithValue("OrderDate", dtToDate);
            cmd.Parameters.AddWithValue("OrderDate", dtToDate);
            cmd.Parameters.AddWithValue("OrderDate", dFormDate);
            cmd.Parameters.AddWithValue("OrderDate", dtToDate);
            cmd.Parameters.AddWithValue("OrderDate", dtToDate);
            cmd.Parameters.AddWithValue("AreaCode", sAreaCode);

            cmd.Parameters.AddWithValue("invoicedate", dtSaleStartDate);
            cmd.Parameters.AddWithValue("invoicedate", dtEndStartDate);
            cmd.Parameters.AddWithValue("invoicedate", dtEndStartDate);
            //cmd.Parameters.AddWithValue("CustomerCode", sCustomerCode);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    MCustomer oCustomer = new MCustomer();
                    oCustomer.CustomerCode = reader["CustomerCode"].ToString();
                    oCustomer.CustomerName = reader["CustomerName"].ToString();
                    oCustomer.TotalOrder = (int)reader["OrderNo"];
                    oCustomer.Qty = int.Parse(reader["Qty"].ToString());
                    oCustomer.Value = Convert.ToDouble(reader["Value"].ToString());
                    oCustomer.Result = (int)reader["Qty"] + " (S=" + (int)reader["S"] + "; T=" + (int)reader["T"] + "; B=" + (int)reader["B"] + ")";

                    if (reader["SaleQty"] != DBNull.Value)
                    {
                        oCustomer.SaleQty = int.Parse(reader["SaleQty"].ToString());
                    }
                    else
                    {
                        oCustomer.SaleQty = 0;
                    }

                    InnerList.Add(oCustomer);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByAreaBLL(string sAreaCode, DateTime dDate)
        {
            InnerList.Clear();

            DateTime dFormDate = dDate.Date;
            DateTime dtToDate = dDate.Date.AddDays(1);
            DateTime dtSaleStartDate = dDate.Date.AddDays(-7);
            DateTime dtEndStartDate = dDate.Date.AddDays(-1);

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " Select Final.*, salesqty as SaleQty from (Select CD.CustomerID, CD.AreaCode, CD.CustomerCode, CD.CustomerName, IsNull(OrderNo,0) as OrderNo, " +
                 " IsNull(Qty,0) as Qty, IsNull(Value,0) as Value, IsNull(S,0)as S, IsNull(T,0)as T, IsNull(B,0)as B from  " +
                 " (Select CustomerID, AreaCode, CustomerCode, CustomerName from v_CustomerDetails)cd  " +
                 " left outer join  " +
                 " ( " +
                 " Select CustomerID,CustomerCode, CustomerName, OrderNo, Sum(Qty)Qty, Sum(Value)Value from (  " +
                 " Select OrderID, CustomerID,CustomerCode, CustomerName, OrderStatus, OrderNo, Qty=CASE When OrderStatus='CustomerOrder' then OrderQty  " +
                 " When OrderStatus='AreaOrder' then RevOrderQty When OrderStatus='NationalOrder' then NOrderQty end,  " +
                 " Value=CASE When OrderStatus='CustomerOrder' then OrderQty*UnitPrice When OrderStatus='AreaOrder' then RevOrderQty*UnitPrice  " +
                 " When OrderStatus='NationalOrder' then NOrderQty*UnitPrice end from(  " +
                 " Select OrderID, CustomerID,CustomerCode, CustomerName, OrderStatus, OrderNo, OrderQty, RevOrderQty, NOrderQty, CASE When PriceOptionID=1 then NSP  " +
                 " end as UnitPrice  from ( " +
                 " select a.OrderID, c.CustomerID, c.CustomerCode, c.CustomerName, OrderStatus,OrderNo, IsNull(OrderQty,0)as OrderQty,  " +
                 " IsNull(RevOrderQty,0) as RevOrderQty,  " +
                 " IsNull(NOrderQty,0) as NOrderQty, PriceOptionID,CP,TP,NSP,RSP,SP  " +
                 " from t_AndroidOrderDetail a INNER JOIN  " +
                 " (Select ProductID, IsNull(CostPrice,0) as CP, IsNull(TradePrice,0)as TP, IsNull(NSP,0) as NSP,  " +
                 " IsNull(RSP,0) as RSP, IsNull(SpecialPrice,0)as SP from t_FinishedGoodsPrice Where IsCurrent=1)Price  " +
                 " ON Price.ProductID=a.ProductID INNER JOIN (Select * from t_AndroidOrder Where OrderDate Between ? " +
                 " and ? and OrderDate < ? ) b ON B.OrderID=a.OrderID INNER JOIN t_Customer c  " +
                 " ON C.CustomerID=b.CustomerID INNER JOIN t_CustomerTypeWisePriceSetting d ON D.CustTypeID=c.CustTypeID " +
                 " INNER JOIN  " +
                 " (select a.CustomerID,CustomerCode, Count(a.CustomerID) orderNo from t_AndroidOrder a INNER JOIN t_Customer b  " +
                 " On a.CustomerID=b.CustomerID Where OrderDate Between ? " +
                 " and ? and OrderDate < ?  " +
                 " group by a.CustomerID,CustomerCode) as OrderNo  " +
                 " on OrderNo.CustomerID=c.customerID)X)Final  " +
                 " )a where value <>0 Group by CustomerID,CustomerCode, CustomerName, OrderNo  " +
                 " )F On f.CustomerID=CD.CustomerID  " +
                 " Left outer JOIN  " +

                 " (Select CustomerID,CustomerCode,  " +
                 " sum(case ASGName when 'GLS' then Qty else 0 end) as S,  " +
                 " sum(case ASGName when 'CFL' then Qty else 0 end) as B,  " +
                 " sum(case ASGName when 'TL' then Qty else 0 end) as T " +
                 " from (Select b.CustomerID, CustomerCode, ASGName, Qty=CASE When OrderStatus='CustomerOrder' then OrderQty  " +
                 " When OrderStatus='AreaOrder' then RevOrderQty When OrderStatus='NationalOrder' then NOrderQty end  " +
                 " from t_AndroidOrderDetail a INNER JOIN t_AndroidOrder b ON B.OrderID=a.OrderID  " +
                 " INNER JOIN (Select CustomerID, CustomerCode from t_Customer) c ON c.CustomerID=b.CustomerID  " +
                 " INNER JOIN (Select ProductID, ASGName from v_ProductDetails) PD ON PD.ProductID=a.ProductID  " +
                 " Where OrderDate Between ? and ? and OrderDate < ? " +
                 " )a Group by CustomerID,CustomerCode)h  " +
                 " on h.customerID=Cd.CustomerID Where AreaCode= ? )Final  " +

                 " Left Outer JOIN  " +
                 " (select customerid,customercode,sum(salesqty) as salesqty, sum(salesvalue) as salesvalue, " +
                 "sum(GLSQty) as BarQty,sum(CFLQty) as TouchQty,sum(TLQty) as SmartQty, " +
                 "  sum(GLSValue) as BarValue,sum(CFLValue) as TouchValue,sum(TLValue) as SmartValue from  " +
                 " (select d.customerid,d.customercode,sum(qty) as salesqty,sum(qty)*NSP as salesvalue,  " +
                 " case when PdtGroupName='GLS' then sum(qty) end GLSQty,  " +
                 " case when PdtGroupName='CFL' then sum(qty) end CFLQty,  " +
                 " case when PdtGroupName='TL' then sum(qty) end TLQty,  " +
                 " case when PdtGroupName='GLS' then sum(qty)*NSP end GLSValue,  " +
                 " case when PdtGroupName='CFL' then sum(qty)*NSP end CFLValue,  " +
                 " case when PdtGroupName='TL' then sum(qty)*NSP end TLValue   " +
                 " from dbo.t_DMSLiteSalesTran a,dbo.t_DMSLiteProductMapping b, dbo.t_DMSLiteCustomerMapping c,  " +
                 " t_customer d, t_product e, t_FinishedGoodsPrice f,t_productGroup g  " +
                 " where a.productcode=b.dlproductcode and f.productID=e.productid and Iscurrent=1   " +
                 " and g.PdtGroupID=e.ProductGroupID and PdtGroupType=4  " +
                 " and a.smdpcode=c.dlcustomercode  " +
                 " and b.cproductcode=e.productcode  " +
                 " and c.ccustomercode=d.customercode  " +
                 " and invoicedate between ? and ? and invoicedate < ? " +
                 " group by d.customerid,d.customercode,NSP,PdtGroupName) x  " +
                 " group by customerid,customercode)sale  " +
                 " ON Sale.CustomerID=Final.CustomerID  " +
                 " Order by OrderNo DESC ";

            

            cmd.Parameters.AddWithValue("OrderDate", dFormDate);
            cmd.Parameters.AddWithValue("OrderDate", dtToDate);
            cmd.Parameters.AddWithValue("OrderDate", dtToDate);
            cmd.Parameters.AddWithValue("OrderDate", dFormDate);
            cmd.Parameters.AddWithValue("OrderDate", dtToDate);
            cmd.Parameters.AddWithValue("OrderDate", dtToDate);
            cmd.Parameters.AddWithValue("OrderDate", dFormDate);
            cmd.Parameters.AddWithValue("OrderDate", dtToDate);
            cmd.Parameters.AddWithValue("OrderDate", dtToDate);
            cmd.Parameters.AddWithValue("AreaCode", sAreaCode);

            cmd.Parameters.AddWithValue("invoicedate", dtSaleStartDate);
            cmd.Parameters.AddWithValue("invoicedate", dtEndStartDate);
            cmd.Parameters.AddWithValue("invoicedate", dtEndStartDate);
           

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    MCustomer oCustomer = new MCustomer();
                    oCustomer.CustomerCode = reader["CustomerCode"].ToString();
                    oCustomer.CustomerName = reader["CustomerName"].ToString();
                    oCustomer.TotalOrder = (int)reader["OrderNo"];
                    oCustomer.Qty = int.Parse(reader["Qty"].ToString());
                    oCustomer.Value = Convert.ToDouble(reader["Value"].ToString());
                    oCustomer.Result = (int)reader["Qty"] + " (S=" + (int)reader["S"] + "; T=" + (int)reader["T"] + "; B=" + (int)reader["B"] + ")";

                    if (reader["SaleQty"] != DBNull.Value)
                    {
                        oCustomer.SaleQty = int.Parse(reader["SaleQty"].ToString());
                    }
                    else
                    {
                        oCustomer.SaleQty = 0;
                    }

                    InnerList.Add(oCustomer);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByCustomer(string sCustomerCode, DateTime dDate)
        {
            bool _OrderID = false;
            string sSql = "";
            DateTime dFormDate = dDate.Date;
            DateTime dtToDate = dDate.Date.AddDays(1);
            DateTime dtSaleStartDate = dDate.Date.AddDays(-7);
            DateTime dtEndStartDate = dDate.Date.AddDays(-1);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            sSql = "SELECT MAX([OrderID]) FROM t_AndroidOrder a, t_Customer b where a.CustomerID=b.CustomerID " +
                   "and b.CustomerCode=? and OrderDate Between ? and ? and OrderDate < ? ";

            cmd.Parameters.AddWithValue("CustomerCode", sCustomerCode);
            cmd.Parameters.AddWithValue("OrderDate", dFormDate);
            cmd.Parameters.AddWithValue("OrderDate", dtToDate);
            cmd.Parameters.AddWithValue("OrderDate", dtToDate);

            cmd.CommandText = sSql;
            object maxID = cmd.ExecuteScalar();
            if (maxID == DBNull.Value)
            {
                _OrderID = false;
            }
            else
            {
                _OrderID = true;
            }

            cmd.Dispose();
            cmd = DBController.Instance.GetCommand();

            if (_OrderID == true)
            {
                sSql = "";

                sSql = "Select Final.*, salesqty as SaleQty from (SElect x.CustomerID,x.CustomerCode,CustomerName,OrderNo,Qty,Value, IsNull(S,0)as S, IsNull(T,0)as T, IsNull(B,0)as B from ( " +
                "Select CustomerID,CustomerCode, CustomerName, OrderNo, Sum(Qty)Qty, Sum(Value)Value from ( " +
                "Select OrderID, CustomerID,CustomerCode, CustomerName, OrderStatus, OrderNo, Qty=CASE When OrderStatus='CustomerOrder' then OrderQty " +
                "When OrderStatus='AreaOrder' then RevOrderQty When OrderStatus='NationalOrder' then NOrderQty end, " +
                "Value=CASE When OrderStatus='CustomerOrder' then OrderQty*UnitPrice When OrderStatus='AreaOrder' then RevOrderQty*UnitPrice " +
                "When OrderStatus='NationalOrder' then NOrderQty*UnitPrice end  from( " +
                "Select OrderID, CustomerID,CustomerCode, CustomerName, OrderStatus, OrderNo, OrderQty, RevOrderQty, NOrderQty, CASE When PriceOptionID=1 then NSP " +
                "When PriceOptionID=2 then RSP When PriceOptionID=3 then SP " +
                "When PriceOptionID=4 then CP When PriceOptionID=5 then TP When PriceOptionID=6 then MRP end as UnitPrice  from ( " +
                "select a.OrderID, c.CustomerID, c.CustomerCode, c.CustomerName, OrderStatus,OrderNo, IsNull(OrderQty,0)as OrderQty, " +
                "IsNull(RevOrderQty,0) as RevOrderQty, " +
                "IsNull(NOrderQty,0) as NOrderQty, PriceOptionID,CP,TP,NSP,RSP,SP,MRP  " +
                "from t_AndroidOrderDetail a INNER JOIN  " +
                "(Select ProductID, IsNull(CostPrice,0) as CP, IsNull(TradePrice,0)as TP, IsNull(NSP,0) as NSP, " +
                "IsNull(RSP,0) as RSP, IsNull(SpecialPrice,0)as SP, IsNull(MRP,0)as MRP from t_FinishedGoodsPrice Where IsCurrent=1)Price " +
                "ON Price.ProductID=a.ProductID INNER JOIN (Select * from t_AndroidOrder Where OrderDate Between ? " +
                "and ? and OrderDate < ? ) b ON B.OrderID=a.OrderID INNER JOIN (Select * from t_Customer Where CustomerCode=? ) c " +
                "ON C.CustomerID=b.CustomerID INNER JOIN t_CustomerTypeWisePriceSetting d ON D.CustTypeID=c.CustTypeID " +
                "INNER JOIN " +
                "(select a.CustomerID,CustomerCode, Count(a.CustomerID) orderNo from t_AndroidOrder a INNER JOIN t_Customer b " +
                "On a.CustomerID=b.CustomerID Where OrderDate Between ? and ? and OrderDate < ? " +
                "and CustomerCode=?  group by a.CustomerID,CustomerCode) as OrderNo " +
                "on OrderNo.CustomerID=c.customerID)X)Final " +
                ")a where value <>0 Group by CustomerID,CustomerCode, CustomerName, OrderNo )x " +
                "Left outer JOIN " +
                "(Select CustomerID,CustomerCode, " +
                "sum(case AGName when 'Smart' then Qty else 0 end) as S, " +
                "sum(case AGName when 'Bar' then Qty else 0 end) as B, " +
                "sum(case AGName when 'Touch' then Qty else 0 end) as T " +
                "from (Select b.CustomerID, CustomerCode, AGName, Qty=CASE When OrderStatus='CustomerOrder' then OrderQty " +
                "When OrderStatus='AreaOrder' then RevOrderQty When OrderStatus='NationalOrder' then NOrderQty end " +
                "from t_AndroidOrderDetail a INNER JOIN t_AndroidOrder b ON B.OrderID=a.OrderID " +
                "INNER JOIN (Select CustomerID, CustomerCode from t_Customer where customerCode=? ) c ON c.CustomerID=b.CustomerID " +
                "INNER JOIN (Select ProductID, AGName from v_ProductDetails) PD ON PD.ProductID=a.ProductID " +
                "Where OrderDate Between ? and ? and OrderDate < ? " +
                ")a Group by CustomerID,CustomerCode) h " +
                "on h.customerID=x.CustomerID where value <>0 ) Final " +

                "Left Outer JOIN " +
                "(select customerid,customercode,sum(salesqty) as salesqty, sum(salesvalue) as salesvalue, " +
                "sum(BarQty) as BarQty,sum(TouchQty) as TouchQty,sum(SmartQty) as SmartQty, " +
                "sum(BarValue) as BarValue,sum(TouchValue) as TouchValue,sum(SmartValue) as SmartValue from  " +
                "(select d.customerid,d.customercode,sum(qty) as salesqty,sum(qty)*rsp as salesvalue, " +
                "case  when PdtGroupName='BAR' then sum(qty) end BarQty, " +
                "case when PdtGroupName='Touch' then sum(qty) end TouchQty, " +
                "case when PdtGroupName='Smart' then sum(qty) end SmartQty, " +
                "case  when PdtGroupName='BAR' then sum(qty)*RSP end BarValue, " +
                "case when PdtGroupName='Touch' then sum(qty)*RSP end TouchValue, " +
                "case when PdtGroupName='Smart' then sum(qty)*RSP end SmartValue  " +
                "from dbo.t_DMSLiteSalesTran a,dbo.t_DMSLiteProductMapping b, dbo.t_DMSLiteCustomerMapping c, " +
                "t_customer d, t_product e, t_FinishedGoodsPrice f,t_productGroup g " +
                "where a.productcode=b.dlproductcode and f.productID=e.productid and Iscurrent=1  " +
                "and g.PdtGroupID=e.ProductGroupID and PdtGroupType=4 " +
                "and a.smdpcode=c.dlcustomercode " +
                "and b.cproductcode=e.productcode " +
                "and c.ccustomercode=d.customercode " +
                "and invoicedate between ? and ? and invoicedate < ? and d.CustomerCode=? " +
                "group by d.customerid,d.customercode,rsp,PdtGroupName) x " +
                "group by customerid,customercode)sale " +
                "ON Sale.CustomerID=Final.CustomerID ";
                

                cmd.Parameters.AddWithValue("OrderDate", dFormDate);
                cmd.Parameters.AddWithValue("OrderDate", dtToDate);
                cmd.Parameters.AddWithValue("OrderDate", dtToDate);
                cmd.Parameters.AddWithValue("CustomerCode", sCustomerCode);

                cmd.Parameters.AddWithValue("OrderDate", dFormDate);
                cmd.Parameters.AddWithValue("OrderDate", dtToDate);
                cmd.Parameters.AddWithValue("OrderDate", dtToDate);
                cmd.Parameters.AddWithValue("CustomerCode", sCustomerCode);

                cmd.Parameters.AddWithValue("CustomerCode", sCustomerCode);
                cmd.Parameters.AddWithValue("OrderDate", dFormDate);
                cmd.Parameters.AddWithValue("OrderDate", dtToDate);
                cmd.Parameters.AddWithValue("OrderDate", dtToDate);

                cmd.Parameters.AddWithValue("invoicedate", dtSaleStartDate);
                cmd.Parameters.AddWithValue("invoicedate", dtEndStartDate);
                cmd.Parameters.AddWithValue("invoicedate", dtEndStartDate);
                cmd.Parameters.AddWithValue("CustomerCode", sCustomerCode);


            }
            else
            {
                sSql = "";
                sSql = "select CustomerCode, CustomerName, 0 as OrderNo, 0 as Qty, 0 as Value, 0 as S, 0 as T, 0 as B, 0 as SaleQty from t_Customer where customerCode =? ";
                cmd.Parameters.AddWithValue("CustomerCode", sCustomerCode);
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    MCustomer oCustomer = new MCustomer();
                    oCustomer.CustomerCode = reader["CustomerCode"].ToString();
                    oCustomer.CustomerName = reader["CustomerName"].ToString();
                    oCustomer.TotalOrder = (int)reader["OrderNo"];
                    oCustomer.Qty = int.Parse(reader["Qty"].ToString());
                    oCustomer.Value =Convert.ToDouble(reader["Value"].ToString());
                    oCustomer.Result = (int)reader["Qty"] + " (S=" + (int)reader["S"] + "; T=" + (int)reader["T"] + "; B=" + (int)reader["B"] + ")";
                    if (reader["SaleQty"] != DBNull.Value)
                    {
                        oCustomer.SaleQty = int.Parse(reader["SaleQty"].ToString());
                    }
                    else
                    {
                        oCustomer.SaleQty = 0;
                    }

                    InnerList.Add(oCustomer);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByCustomerBLL(string sCustomerCode, DateTime dDate)
        {
            // For BLL 
            bool _OrderID = false;
            string sSql = "";
            DateTime dFormDate = dDate.Date;
            DateTime dtToDate = dDate.Date.AddDays(1);
            DateTime dtSaleStartDate = dDate.Date.AddDays(-7);
            DateTime dtEndStartDate = dDate.Date.AddDays(-1);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            sSql = "SELECT MAX([OrderID]) FROM t_AndroidOrder a, t_Customer b where a.CustomerID=b.CustomerID " +
                   "and b.CustomerCode=? and OrderDate Between ? and ? and OrderDate < ? ";

            cmd.Parameters.AddWithValue("CustomerCode", sCustomerCode);
            cmd.Parameters.AddWithValue("OrderDate", dFormDate);
            cmd.Parameters.AddWithValue("OrderDate", dtToDate);
            cmd.Parameters.AddWithValue("OrderDate", dtToDate);

            cmd.CommandText = sSql;
            object maxID = cmd.ExecuteScalar();
            if (maxID == DBNull.Value)
            {
                _OrderID = false;
            }
            else
            {
                _OrderID = true;
            }

            cmd.Dispose();
            cmd = DBController.Instance.GetCommand();

            if (_OrderID == true)
            {

        sSql = " Select Final.*, salesqty as SaleQty from (SElect x.CustomerID,x.CustomerCode,CustomerName,OrderNo,Qty,Value, IsNull(S,0)as S, IsNull(T,0)as T, IsNull(B,0)as B  " +
               " from " +
               " ( " +
               " Select CustomerID,CustomerCode, CustomerName, OrderNo, Sum(Qty)Qty, Sum(Value)Value  " +
               " from  " +
               " (  " +
               " Select OrderID, CustomerID,CustomerCode, CustomerName, OrderStatus, OrderNo, Qty=CASE When OrderStatus='CustomerOrder' then OrderQty  " +
               " When OrderStatus='AreaOrder' then RevOrderQty When OrderStatus='NationalOrder' then NOrderQty end,  " +
               " Value=CASE When OrderStatus='CustomerOrder' then OrderQty*UnitPrice When OrderStatus='AreaOrder' then RevOrderQty*UnitPrice " +
               " When OrderStatus='NationalOrder' then NOrderQty*UnitPrice end   " +
               " from(  " +
               " Select OrderID, CustomerID,CustomerCode, CustomerName, OrderStatus, OrderNo, OrderQty, RevOrderQty, NOrderQty, CASE When PriceOptionID=1 then NSP  " +
               " When PriceOptionID=2 then RSP end as UnitPrice  " +
               " from (  " +
               " select a.OrderID, c.CustomerID, c.CustomerCode, c.CustomerName, OrderStatus,OrderNo, IsNull(OrderQty,0)as OrderQty,  " +
               " IsNull(RevOrderQty,0) as RevOrderQty,  " +
               " IsNull(NOrderQty,0) as NOrderQty, PriceOptionID,NSP,RSP   " +
               " from t_AndroidOrderDetail a  " +
               " INNER JOIN   " +
               " ( " +
               " Select ProductID, IsNull(CostPrice,0) as CP, IsNull(TradePrice,0)as TP, IsNull(NSP,0) as NSP,  " +
               " IsNull(RSP,0) as RSP from t_FinishedGoodsPrice Where IsCurrent=1 " +
               " )Price  " +
               " ON Price.ProductID=a.ProductID  " +
               " INNER JOIN  " +
               " ( " +
               " Select * from t_AndroidOrder Where OrderDate Between ? " +
               " and ? and OrderDate < ? ) b ON B.OrderID=a.OrderID INNER JOIN (Select * from t_Customer Where CustomerCode= ?  ) c  " +
               " ON C.CustomerID=b.CustomerID INNER JOIN t_CustomerTypeWisePriceSetting d ON D.CustTypeID=c.CustTypeID  " +
               " INNER JOIN  " +
               " ( " +
               " select a.CustomerID,CustomerCode, Count(a.CustomerID) orderNo from t_AndroidOrder a INNER JOIN t_Customer b " +
               " On a.CustomerID=b.CustomerID Where OrderDate Between ? and ? and OrderDate < ? " +
               " and CustomerCode= ?  group by a.CustomerID,CustomerCode) as OrderNo  " +
               " on OrderNo.CustomerID=c.customerID)X)Final  " +
               " )a where value <>0 Group by CustomerID,CustomerCode, CustomerName, OrderNo )x  " +
               " Left outer JOIN  " +
               " (Select CustomerID,CustomerCode,  " +
               " sum(case ASGName when 'GLS' then Qty else 0 end) as S,  " +
               " sum(case ASGName when 'CFL' then Qty else 0 end) as B,  " +
               " sum(case ASGName when 'TL' then Qty else 0 end) as T  " +
               " from (Select b.CustomerID, CustomerCode, ASGName, Qty=CASE When OrderStatus='CustomerOrder' then OrderQty  " +
               " When OrderStatus='AreaOrder' then RevOrderQty When OrderStatus='NationalOrder' then NOrderQty end  " +
               " from t_AndroidOrderDetail a INNER JOIN t_AndroidOrder b ON B.OrderID=a.OrderID  " +
               " INNER JOIN (Select CustomerID, CustomerCode from t_Customer where customerCode= ? ) c ON c.CustomerID=b.CustomerID  " +
               " INNER JOIN (Select ProductID, ASGName from v_ProductDetails) PD ON PD.ProductID=a.ProductID  " +
               " Where OrderDate Between ? and ? and OrderDate < ?  " +
               " )a Group by CustomerID,CustomerCode) h  " +
               " on h.customerID=x.CustomerID where value <>0 ) Final  " +
               " Left Outer JOIN  " +
               " (select customerid,customercode,sum(salesqty) as salesqty, sum(salesvalue) as salesvalue,  " +
               " sum(BarQty) as BarQty,sum(TouchQty) as TouchQty,sum(SmartQty) as SmartQty,  " +
               " sum(BarValue) as BarValue,sum(TouchValue) as TouchValue,sum(SmartValue) as SmartValue from   " +
               " (select d.customerid,d.customercode,sum(qty) as salesqty,sum(qty)*NSP as salesvalue,  " +
               " case  when PdtGroupName='GLS' then sum(qty) end BarQty,  " +
               " case when PdtGroupName='CFL' then sum(qty) end TouchQty,  " +
               " case when PdtGroupName='TL' then sum(qty) end SmartQty,  " +
               " case  when PdtGroupName='GLS' then sum(qty)*NSP end BarValue,  " +
               " case when PdtGroupName='CFL' then sum(qty)*NSP end TouchValue,  " +
               " case when PdtGroupName='TL' then sum(qty)*NSP end SmartValue   " +
               " from dbo.t_DMSLiteSalesTran a,dbo.t_DMSLiteProductMapping b, dbo.t_DMSLiteCustomerMapping c,  " +
               " t_customer d, t_product e, t_FinishedGoodsPrice f,t_productGroup g  " +
               " where a.productcode=b.dlproductcode and f.productID=e.productid and Iscurrent=1   " +
               " and g.PdtGroupID=e.ProductGroupID and PdtGroupType=4  " +
               " and a.smdpcode=c.dlcustomercode  " +
               " and b.cproductcode=e.productcode  " +
               " and c.ccustomercode=d.customercode  " +
               " and invoicedate between ? and ? and invoicedate < ? and d.CustomerCode= ?   " +
               " group by d.customerid,d.customercode,NSP,PdtGroupName) x  " +
               " group by customerid,customercode)sale  " +
               " ON Sale.CustomerID=Final.CustomerID  ";
                 

                cmd.Parameters.AddWithValue("OrderDate", dFormDate);
                cmd.Parameters.AddWithValue("OrderDate", dtToDate);
                cmd.Parameters.AddWithValue("OrderDate", dtToDate);
                cmd.Parameters.AddWithValue("CustomerCode", sCustomerCode);

                cmd.Parameters.AddWithValue("OrderDate", dFormDate);
                cmd.Parameters.AddWithValue("OrderDate", dtToDate);
                cmd.Parameters.AddWithValue("OrderDate", dtToDate);
                cmd.Parameters.AddWithValue("CustomerCode", sCustomerCode);

                cmd.Parameters.AddWithValue("CustomerCode", sCustomerCode);
                cmd.Parameters.AddWithValue("OrderDate", dFormDate);
                cmd.Parameters.AddWithValue("OrderDate", dtToDate);
                cmd.Parameters.AddWithValue("OrderDate", dtToDate);

                cmd.Parameters.AddWithValue("invoicedate", dtSaleStartDate);
                cmd.Parameters.AddWithValue("invoicedate", dtEndStartDate);
                cmd.Parameters.AddWithValue("invoicedate", dtEndStartDate);
                cmd.Parameters.AddWithValue("CustomerCode", sCustomerCode);


            }
            else
            {
                sSql = "";
                sSql = "select CustomerCode, CustomerName, 0 as OrderNo, 0 as Qty, 0 as Value, 0 as S, 0 as T, 0 as B, 0 as SaleQty from t_Customer where customerCode =? ";
                cmd.Parameters.AddWithValue("CustomerCode", sCustomerCode);
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    MCustomer oCustomer = new MCustomer();
                    oCustomer.CustomerCode = reader["CustomerCode"].ToString();
                    oCustomer.CustomerName = reader["CustomerName"].ToString();
                    oCustomer.TotalOrder = (int)reader["OrderNo"];
                    oCustomer.Qty = int.Parse(reader["Qty"].ToString());
                    oCustomer.Value = Convert.ToDouble(reader["Value"].ToString());
                    oCustomer.Result = (int)reader["Qty"] + " (S=" + (int)reader["S"] + "; T=" + (int)reader["T"] + "; B=" + (int)reader["B"] + ")";
                    if (reader["SaleQty"] != DBNull.Value)
                    {
                        oCustomer.SaleQty = int.Parse(reader["SaleQty"].ToString());
                    }
                    else
                    {
                        oCustomer.SaleQty = 0;
                    }

                    InnerList.Add(oCustomer);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }


    public class MOrderItem
    {
        private int _nOrderID;
        private int _nProductID;
        private string _sAG;
        private string _sProductCode;
        private string _sProductName;
        private double _ProductPrice;
        private int _nOrderQty;
        private int _nRevOrderQty;
        private int _nNOrderQty;
        private double _OrderValue;
        private int _nStock;
        private int _nMOQ;


        public int OrderID
        {
            get { return _nOrderID;}
            set { _nOrderID = value;}
        }
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        public string AG
        {
            get { return _sAG; }
            set { _sAG = value; }
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
        public double ProductPrice
        {
            get { return _ProductPrice; }
            set { _ProductPrice = value; }
        }
        public int OrderQty
        {
            get { return _nOrderQty; }
            set { _nOrderQty = value; }
        }
        public int RevOrderQty
        {
            get { return _nRevOrderQty; }
            set { _nRevOrderQty = value; }
        }
        public int NOrderQty
        {
            get { return _nNOrderQty; }
            set { _nNOrderQty = value; }
        }
        public double OrderValue
        {
            get { return _OrderValue; }
            set { _OrderValue = value; }
        }
        public int Stock
        {
            get { return _nStock; }
            set { _nStock = value; }
        }

        public int MOQ
        {
            get { return _nMOQ; }
            set { _nMOQ = value; }
        }


        public void Insert(int nOrderID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_AndroidOrderDetail(OrderID,ProductID, OrderQty, RevOrderQty, NOrderQty) VALUES (?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OrderID", nOrderID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("OrderQty", _nOrderQty);
                cmd.Parameters.AddWithValue("RevOrderQty", _nRevOrderQty);
                cmd.Parameters.AddWithValue("NOrderQty", _nNOrderQty);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Delete(int nOrderID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from  t_AndroidOrderDetail Where OrderID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", nOrderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

    }

    public class MOrder : CollectionBase
    {
        private int _nOrderID;
        private string _sOrderNo;
        private string _sOrderStatus;
        private int _nCustomerID;
        private string _sRemarks;
        private bool _bIsComplete;
        
        

        public int OrderID
        {
            get { return _nOrderID; }
            set { _nOrderID = value; }
        }
        public string OrderNo
        {
            get 
            {
                if(_sOrderNo==null) 
                    _sOrderNo = "Order#" + _nOrderID.ToString()+" ("+_sOrderStatus+"/"+_bIsComplete+")";
                return _sOrderNo; 
            }
            set { _sOrderNo = value; }
        }
        public string OrderStatus
        {
            get { return _sOrderStatus;}
            set { _sOrderStatus = value;}
        }
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }
        public bool IsComplete
        {
            get { return _bIsComplete; }
            set { _bIsComplete = value; }
        }

        
        
        public MOrderItem this[int i]
        {
            get { return (MOrderItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(MOrderItem oProduct)
        {
            InnerList.Add(oProduct);
        }

        public int GetIndex(int nProductID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ProductID == nProductID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Refresh(int nOrderID, int nCustomerID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select AGName, Basic.ProductID, Basic.ProductCode, ProductName, PetName, IsNull(Total_Stock,0)Total_Stock, UnitPrice, IsNull(OrderQty,0) as OrderQty, " +
                        "IsNull(RevOrderQty,0) as RevOrderQty, IsNull(NOrderQty,0) as NOrderQty from " +
                        "( " +
                        "select Prod.*, Cust.CustomerID,Cust.CustomerCode, PriceOptionID, UnitPrice = CASE When Cust.PriceOptionID=1 then NSP " +
                        "When Cust.PriceOptionID=2 then RSP When Cust.PriceOptionID=3 then SP " +
                        "When Cust.PriceOptionID=4 then CP When Cust.PriceOptionID=5 then TP When Cust.PriceOptionID=6 then MRP end from " +
                        "( " +
                        "select PdtGroupName as AGName, Prod.ProductID,Prod.ProductCode,substring(ProductName,16,20)as ProductName, " +
                        "PetName,IsNull(FGP.CostPrice,0)as CP, IsNull(FGP.TradePrice,0)as TP, IsNull(FGP.SpecialPrice,0)as SP,  " +
                        "IsNull(FGP.NSP,0)as NSP,IsNull(FGP.RSP,0) as RSP,IsNull(MRP,0) as MRP  " +
                        "from t_FinishedGoodsPrice FGP inner join t_product Prod  " +
                        "on FGP.ProductID=Prod.ProductID INNER JOIN t_ProductGroup PG  " +
                        "ON Pg.PdtgroupID=Prod.ProductgroupID  " +
                        "where IsCurrent=1 and InventoryCategory=1)Prod,  " +
                        "( " +
                        "select Cust.CustomerID, Cust.CustomerCode, CTWPS.PriceOptionID " +
                        "from t_Customer Cust  " +
                        "INNER JOIN t_CustomerTypeWisePriceSetting CTWPS ON Cust.CustTypeID=CTWPS.CustTypeID )Cust Where Cust.CustomerID=? " +
                        ")Basic  " +
                        "Left Outer JOIN  " +
                        "(select IsNull(CProductCode,0) as ProductCode, IsNull(CCustomerCode,0) as CustomerCode,  " +
                        "IsNull(Total_Stock,0)Total_Stock from t_DMSLiteRDSStock a INNER JOIN  " +
                        "t_DMSLiteProductMapping b ON a.ProductCode=b.DLProductCode  " +
                        "INNER JOIN t_DMSLiteCustomerMapping c on a.Channel_Code=c.DLCustomerCode)SMDPStk  " +
                        "ON SMDPStk.CustomerCode=Basic.CustomerCode and SMDPStk.productCode=Basic.productcode " +
                        "left outer join  " +
                        "(select ProductID,IsNull(OrderQty,0) as OrderQty, IsNull(RevOrderQty,0) as RevOrderQty,  " +
                        "IsNull(NOrderQty,0) as NOrderQty from t_AndroidOrderDetail where OrderID = ?) B  " +
                        "on Basic.ProductID=B.ProductID  " +
                        "Order by UnitPrice DESC";

            cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
            cmd.Parameters.AddWithValue("OrderID", nOrderID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    MOrderItem oItem = new MOrderItem();

                    oItem.ProductID = (int)reader["ProductID"];
                    oItem.ProductName = reader["ProductName"].ToString();
                    oItem.AG = reader["AGName"].ToString();
                    oItem.ProductPrice = (double)reader["UnitPrice"];
                    oItem.OrderQty=(int)reader["OrderQty"];
                    oItem.RevOrderQty = (int)reader["RevOrderQty"];
                    oItem.NOrderQty = (int)reader["NOrderQty"];
                    oItem.Stock = int.Parse(reader["Total_Stock"].ToString());
                    //oItem.AreaName = reader["AreaName"].ToString();

                    InnerList.Add(oItem);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshBLL(int nOrderID, int nCustomerID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "select K1.ASGName,MOQ, K1.ProductID, K1.ProductCode, K2.ProductName,  IsNull(Total_Stock,0)Total_Stock, UnitPrice, IsNull(OrderQty,0) as OrderQty, " +
                   " IsNull(RevOrderQty,0) as RevOrderQty, IsNull(NOrderQty,0) as NOrderQty " +
                   " from " +
                   " ( " +
                   " select ASGName,ASGID,BrandDesc,UOMConversionFactor as MOQ, ProductCode,ProductID from v_ProductDetails where IsActive=1 and ASGID in (125,126,127,139,140)and NSP>0 " +
                   " and productCode not in (14219,14220,14019,14021,14048,14049,14050,14051,14056,14057,14059,14061,14064,14071,14072,14079,14080,14081,71007,990017) " +
                   " ) K1 " +
                   " left outer join " +
                   " ( " +
                   " Select AGName, Basic.ProductID, Basic.ProductCode, ProductName,  IsNull(Total_Stock,0)Total_Stock, UnitPrice, IsNull(OrderQty,0) as OrderQty,  " +
                   " IsNull(RevOrderQty,0) as RevOrderQty, IsNull(NOrderQty,0) as NOrderQty from  " +
                   " (  " +
                   " select Prod.*, Cust.CustomerID,Cust.CustomerCode, PriceOptionID, UnitPrice = CASE When Cust.PriceOptionID=1 then NSP  " +
                   "  When Cust.PriceOptionID=2 then RSP   " +
                   "  end from  " +
                   " (  " +
                   " select PdtGroupName as AGName, Prod.ProductID,Prod.ProductCode,Prod.ProductName,  " +
                   " IsNull(FGP.CostPrice,0)as CP, IsNull(FGP.TradePrice,0)as TP, IsNull(FGP.SpecialPrice,0)as SP,   " +
                   " IsNull(FGP.NSP,0)as NSP,IsNull(FGP.RSP,0) as RSP " +
                   " from t_FinishedGoodsPrice FGP inner join t_product Prod   " +
                   " on FGP.ProductID=Prod.ProductID INNER JOIN t_ProductGroup PG " +
                   " ON Pg.PdtgroupID=Prod.ProductgroupID   " +
                   " where IsCurrent=1 and InventoryCategory=1)Prod,   " +
                   " (  " +
                   " select Cust.CustomerID, Cust.CustomerCode, CTWPS.PriceOptionID  " +
                   " from t_Customer Cust   " +
                   " INNER JOIN t_CustomerTypeWisePriceSetting CTWPS ON Cust.CustTypeID=CTWPS.CustTypeID )Cust Where Cust.CustomerID= ?  " +
                   " )Basic  " +
                   " Left Outer JOIN  " +
                   " (select IsNull(CProductCode,0) as ProductCode, IsNull(CCustomerCode,0) as CustomerCode, " +
                   " IsNull(Total_Stock,0)Total_Stock from t_DMSLiteRDSStock a INNER JOIN   " +
                   " t_DMSLiteProductMapping b ON a.ProductCode=b.DLProductCode   " +
                   " INNER JOIN t_DMSLiteCustomerMapping c on a.Channel_Code=c.DLCustomerCode)SMDPStk   " +
                   " ON SMDPStk.CustomerCode=Basic.CustomerCode and SMDPStk.productCode=Basic.productcode  " +
                   " left outer join   " +
                   " (select ProductID,IsNull(OrderQty,0) as OrderQty, IsNull(RevOrderQty,0) as RevOrderQty,  " +
                   " IsNull(NOrderQty,0) as NOrderQty from t_AndroidOrderDetail where OrderID = ?) B  " +
                   " on Basic.ProductID=B.ProductID   " +
                   " ) K2 on K1.ProductCode=K2.ProductCode " +
                   " Order by ASGID,BrandDesc,K1.ProductCode ";

            cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
            cmd.Parameters.AddWithValue("OrderID", nOrderID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    MOrderItem oItem = new MOrderItem();

                    oItem.ProductID = (int)reader["ProductID"];
                    oItem.ProductName = reader["ProductName"].ToString();
                    oItem.AG = reader["ProductCode"].ToString();
                    oItem.ProductPrice = (double)reader["UnitPrice"];
                    oItem.OrderQty = (int)reader["OrderQty"];
                    oItem.RevOrderQty = (int)reader["RevOrderQty"];
                    oItem.NOrderQty = (int)reader["NOrderQty"];
                    oItem.Stock = int.Parse(reader["Total_Stock"].ToString());
                    oItem.MOQ = int.Parse(reader["MOQ"].ToString());
                    
                    //oItem.AreaName = reader["AreaName"].ToString();

                    InnerList.Add(oItem);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Insert()
        {
            int nMaxOrderID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                cmd.CommandText = "INSERT INTO t_AndroidOrder(OrderDate,CustomerID,OrderStatus,Remarks,IsComplete) VALUES(?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                //cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("OrderDate", DateTime.Now);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                //cmd.Parameters.AddWithValue("OrderStatus", _sOrderStatus);
                cmd.Parameters.AddWithValue("OrderStatus", "AreaOrder");
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsComplete", _bIsComplete);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                sSql = "SELECT MAX([OrderID]) FROM t_AndroidOrder";
                cmd.CommandText = sSql;
                object maxOrderID = cmd.ExecuteScalar();
                if (maxOrderID == DBNull.Value)
                {
                    nMaxOrderID = 1;
                }
                else
                {
                    nMaxOrderID = int.Parse(maxOrderID.ToString());

                }
                // _nOrderID = nMaxOrderID;

                cmd.Dispose();

                foreach (MOrderItem oItem in this)
                {
                    oItem.Insert(nMaxOrderID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Update()
        {
            int nCount = 1;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_AndroidOrder set OrderStatus=? Where CustomerID=? and OrderID=? ";
                cmd.CommandType = CommandType.Text;

                
                
                
                cmd.Parameters.AddWithValue("OrderStatus", _sOrderStatus);

                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);


                cmd.ExecuteNonQuery();
                cmd.Dispose();


                foreach (MOrderItem oItem in this)
                {
                    if (nCount == 1)
                    {
                        oItem.Delete(_nOrderID);
                        nCount++;
                    }
                    oItem.Insert(_nOrderID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Delete(int nOrderID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from t_AndroidOrderDetail where OrderID =? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OrderID", nOrderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "Delete from t_AndroidOrder where OrderID =? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OrderID", nOrderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetOrderStatusByOrderID(int nOrderID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_AndroidOrder where OrderID = ?";
                cmd.Parameters.AddWithValue("OrderID", nOrderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int IsCom = 0;
                    _sOrderStatus = (string)reader["OrderStatus"];

                    //IsCom = int.Parse(reader["IsComplete"].ToString());
                    _bIsComplete = (bool)reader["IsComplete"];
                   
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
    }

    public class MOrders : CollectionBase
    {
        public MOrder this[int i]
        {
            get { return (MOrder)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(MOrder oOrder)
        {
            InnerList.Add(oOrder);
        }
        public int GetIndex(int nOrderID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].OrderID == nOrderID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(DateTime dTranDate, int nCustomerID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from t_AndroidOrder where CustomerID=? and OrderDate between ? and ?";

            cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
            cmd.Parameters.AddWithValue("FromDate", dTranDate);
            cmd.Parameters.AddWithValue("ToDate", dTranDate.AddDays(1));
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    MOrder oOrder = new MOrder();

                    //oProduct.ProductCode = reader["ProductCode"].ToString();
                    oOrder.OrderID = (int)reader["OrderID"];
                    oOrder.OrderStatus = (string)reader["OrderStatus"];
                    oOrder.IsComplete = (bool)reader["IsComplete"];
                    //oOrder.AG = reader["AGName"].ToString();
                    //oOrder.ProductPrice = (double)reader["NSP"];
                    //oItem.AreaName = reader["AreaName"].ToString();

                    InnerList.Add(oOrder);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }

    public class MArea
    {
        private int _nAreaID;
        private string _sAreaCode;
        private string _sAreaName;

        public int AreaID
        {
            get { return _nAreaID; }
            set { _nAreaID = value; }
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
    }

    public class MAreas : CollectionBase
    {
        public MArea this[int i]
        {
            get { return (MArea)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(MArea oMArea)
        {
            InnerList.Add(oMArea);
        }
        public int GetIndex(int nAreaID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].AreaID == nAreaID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(string sUserType,string sCode)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql="";

            if (sUserType == "Customer")
            {
                sSql = "select MarketGroupID,MarketGroupCode,MarketGroupDesc "
                    + " from t_MarketGroup A"
                    + " inner join v_CustomerDetails B"
                    + " on A.MarketGroupID=B.AreaID"
                    + " where CustomerCode=?";
                cmd.Parameters.AddWithValue("CustomerCode", sCode);
            }
            else if (sUserType == "Area")
            {
                sSql = "select * from t_MarketGroup where MarketGroupType=1 and MarketGroupCode=?";
                cmd.Parameters.AddWithValue("MarketGroupCode", sCode);
            }
            else if (sUserType == "National")
            {
                sSql = "select * from t_MarketGroup where MarketGroupType=1";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    MArea oMArea = new MArea();

                    oMArea.AreaID = (int)reader["MarketGroupID"];
                    oMArea.AreaCode = reader["MarketGroupCode"].ToString();
                    oMArea.AreaName = reader["MarketGroupDesc"].ToString();

                    InnerList.Add(oMArea);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }

}






